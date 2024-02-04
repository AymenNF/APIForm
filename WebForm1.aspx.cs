using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace APIForm
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string authorizationUrl = LinkedInShareAPI.GetAuthorizationUrl();       
                Response.Redirect(authorizationUrl);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        protected async void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string authorizationCode = Request.QueryString["code"];
               

                if (!string.IsNullOrEmpty(Request.QueryString["code"]))
                {

                    // Exchange the authorization code for an access token
                    string accessToken = await LinkedInShareAPI.ExchangeAuthorizationCode(authorizationCode);

                    Debug.WriteLine(accessToken);

                    // Get the post content from the form fields
                    string jobTitle = TextBox1.Text;
                    string company = TextBox2.Text;
                    string experience = TextBox3.Text;
                    string salary = TextBox4.Text;
                    string profile = TextBox5.Text;
                    string details = TextBox6.Text;

                    string post =   $"#Offre de d'emploi: nous sommes à la recherche du profil suivant : " +
                                    $"Intitulé du travail: {jobTitle}, à "+
                                    $"la société: {company}, "+
                                    $"ayant une expérience de: {experience}, "+
                                    $"il obtiendra un salaire de: {salary}," +
                                    $"son profile doit aussi être au moins {profile} "+
                                    $"Details: {details}";
                       
                    // Post the content to LinkedIn using the access token
                    
                    await LinkedInShareAPI.PostToFeed(post, accessToken);
                    
                    Debug.WriteLine("LinkedIn post was successful.");

                    TextBox1.Text = string.Empty;
                    TextBox2.Text = string.Empty;
                    TextBox3.Text = string.Empty;
                    TextBox4.Text = string.Empty;
                    TextBox5.Text = string.Empty;
                    TextBox6.Text = string.Empty;

                    // Redirect to the thank you page
                    Response.Redirect("ThankYouPage.aspx");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}