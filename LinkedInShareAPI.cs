using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace APIForm
{
    public class LinkedInShareAPI
    {
        private const string ClientId = "86190paojd9x7g";
        private const string ClientSecret = "3Pe8Wd4zYc6BUQx0";
        private const string RedirectUri = "https://localhost:44376/WebForm1";

        public static string GetAuthorizationUrl()
        {
            var authorizationEndpoint = "https://www.linkedin.com/oauth/v2/authorization";
            var scope = "r_liteprofile%20r_emailaddress%20w_member_social%20openid%20email%20profile";
            var state = Guid.NewGuid().ToString();
            var authorizationUrl = $"{authorizationEndpoint}?response_type=code&client_id={ClientId}&redirect_uri={RedirectUri}&state={state}&scope={scope}";

            return authorizationUrl;
        }

        public static async Task<string> ExchangeAuthorizationCode(string authorizationCode)
        {
            try
            {
                var client = new HttpClient();

                var tokenEndpoint = "https://www.linkedin.com/oauth/v2/accessToken";
                var requestBody = $"grant_type=authorization_code&code={authorizationCode}&client_id={ClientId}&client_secret={ClientSecret}&redirect_uri={RedirectUri}";
                var content = new StringContent(requestBody, System.Text.Encoding.UTF8, "application/x-www-form-urlencoded");
                // Send the POST request to exchange the authorization code for an access token
                var response = await client.PostAsync(tokenEndpoint, content);
                response.EnsureSuccessStatusCode();

                // Parse the response to obtain the access token
                var responseJson = await response.Content.ReadAsStringAsync();
                var accessToken = ExtractAccessToken(responseJson);

                return accessToken;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string ExtractAccessToken(string responseJson)
        {
            // Parse the JSON response to extract the access token
            // Adapt this code based on the actual response format
            // The JSON might contain other properties like 'expires_in', 'refresh_token', etc.
            var tokenStartIndex = responseJson.IndexOf("\"access_token\":\"") + 16;
            var tokenEndIndex = responseJson.IndexOf("\"", tokenStartIndex);
            var accessToken = responseJson.Substring(tokenStartIndex, tokenEndIndex - tokenStartIndex);

            return accessToken;
        }

        public static async Task<string> PostToFeed(string post, string accessToken)
        {
            try
            {               
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "https://api.linkedin.com/v2/ugcPosts");
                request.Headers.Add("Authorization", $"Bearer {accessToken}");
                request.Headers.Add("Cookie", "bcookie=\"v=2&a694e138-5ae9-4a07-8f2e-510e62285bbd\"");
                var content = new StringContent($@"{{
        ""author"": ""urn:li:person:QAJqbzI6aj"",
        ""lifecycleState"": ""PUBLISHED"",
        ""specificContent"": {{
            ""com.linkedin.ugc.ShareContent"": {{
                ""shareCommentary"": {{
                    ""text"": ""{post}""
                }},
                ""shareMediaCategory"": ""NONE""
            }}
        }},
        ""visibility"": {{
            ""com.linkedin.ugc.MemberNetworkVisibility"": ""PUBLIC""
        }}
    }}", null, "application/json");
                
                request.Content = content;
                
                var response = await client.SendAsync(request);
                
                response.EnsureSuccessStatusCode();
                Debug.WriteLine(await response.Content.ReadAsStringAsync());

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception(errorMessage);
                    Debug.WriteLine(errorMessage);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}