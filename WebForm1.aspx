<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="APIForm.WebForm1" Async="true" Debug="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <style>
        .form-container {
            padding: 20px;
            background-color: #f7f7f7;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        .custom-btn {
            width: 100%;
            padding: 10px;
        }
        header .navbar {
            padding: 15px 10px; /* Adjusts the padding inside the navbar */
            background: #004a99; /* Sets a custom background color */
            border-bottom: 2px solid #003366; /* Adds a border under the navbar */
        }
        header .navbar-brand {
            color: #fff; /* Changes the brand text color */
            font-weight: bold; /* Makes the brand text bold */
        }
        header .navbar-nav .nav-link {
            color: #fff; /* Changes the nav link text color */
            margin-right: 15px; /* Adds spacing between nav links */
        }
        header .navbar-nav .nav-link:hover {
            color: #ffcc00; /* Changes the nav link text color on hover */
            transition: color 0.3s; /* Smooth transition for hover effect */
        }
    </style>
    <title>LinkAPI</title>
</head>
<body>
    <header>
        <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
            <a class="navbar-brand" href="#">LinkAPI</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav">
                    <li class="nav-item active">
                        <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Features</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Pricing</a>
                    </li>
                </ul>
            </div>
        </nav>
    </header>
    <div class="container mt-5">
        <form class="form-container" id="form1" runat="server">
        
        <div class="form-row">
    <div class="col-md-4 mb-3">
      <label for="validationServer01">Intitulé du poste</label>
        <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
      
    </div>
    <div class="col-md-4 mb-3">
      <label for="validationServer02">Société</label>
      <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
      <div class="valid-feedback">
        Looks good!
      </div>
    </div>
  </div>
  <div class="form-row">
    <div class="col-md-6 mb-3">
      <label for="validationServer03">Nombres d'années d'expérience</label>
      <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="col-md-3 mb-3">
      <label for="validationServer04">Salaire</label>
      <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="col-md-3 mb-3">
      <label for="validationServer05">Profile</label>
      <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
      <div class="col-md-3 mb-3">
      <label for="validationServer05">Détails</label>
      <asp:TextBox ID="TextBox6" CssClass="form-control" runat="server" Height="53px" TextMode="MultiLine"></asp:TextBox>
    </div>
  </div>
  <div class="form-group">
    <div class="form-check">
      <input class="form-check-input" type="checkbox" value="" id="invalidCheck3" runat="server"/>
      <label class="form-check-label" for="invalidCheck3">
        Agree to terms and conditions
      </label>
      <div class="invalid-feedback" id="invalidFeedback" runat="server">
        You must agree before submitting.
      </div>
    </div>
  </div>
  <asp:Button ID="Button1" runat="server" Text="S'autoriser" CssClass="btn btn-primary mt-3" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Poster" OnClick="Button2_Click" CssClass="btn btn-primary mt-3" />
        
           
        
  
    <script src="Scripts/bootstrap.min.js"></script>
 
   
        
    </form>
        </div>
</body>
</html>
