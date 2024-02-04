<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThankYouPage.aspx.cs" Inherits="APIForm.ThankYouPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        body {
            font-family: 'Arial', sans-serif; /* Aesthetic font */
            background-color: #f4f4f4; /* Light grey background */
            margin: 0; /* Reset default margin */
            height: 100vh; /* Full height */
            display: flex; /* Enables flexbox */
            justify-content: center; /* Centers content horizontally */
            align-items: center; /* Centers content vertically */
            text-align: center; /* Aligns text to the center */
        }

        .thank-you-container {
            background-color: #fff; /* White background */
            padding: 40px; /* Padding around the text */
            border-radius: 10px; /* Rounded corners */
            box-shadow: 0 5px 15px rgba(0,0,0,0.1); /* Subtle shadow */
            max-width: 500px; /* Maximum width */
        }

        h1 {
            color: #333; /* Dark grey color for the text */
            margin-bottom: 20px; /* Margin at the bottom */
        }
    </style>
    <title>Thank You</title>
</head>
<body>
    <div class="thank-you-container">
        <h1>Thank You!</h1>
        <p>Your submission has been received. We will get back to you soon.</p>
    </div>
</body>
</html>
