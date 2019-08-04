<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="idariLogin.aspx.cs" Inherits="Akili_Imza_Si.idari.idariLogin" %>

<!DOCTYPE html>
<%-- Fügür ekleme --%>
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>İdari Personel Girişi</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="icon" type="image/png" href="images/icons/favicon.ico" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" type="text/css" href="fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
    <link rel="stylesheet" type="text/css" href="vendor/animate/animate.css">
    <link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css">
    <link rel="stylesheet" type="text/css" href="vendor/animsition/css/animsition.min.css">
    <link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css">
    <link rel="stylesheet" type="text/css" href="vendor/daterangepicker/daterangepicker.css">
    <link rel="stylesheet" type="text/css" href="css/util.css">
    <link rel="stylesheet" type="text/css" href="css/main.css">
</head>
<body>

    <div class="limiter">
        <div class="container-login100" style="background-image: url('images/siu22.png');">
            <div class="wrap-login100 p-t-30 p-b-50">
                <span class="login100-form-title p-b-41"><i class="fas fa-pen"> İDARİ GİRİŞİ</i>
                </span>
                <form id="form1" runat="server" class="login100-form validate-form p-b-33 p-t-5">

                    <div class="wrap-input100 validate-input" data-validate="Kullanıcı adı girin">
                        <asp:TextBox ID="txtUser" class="input100" runat="server" placeholder="Kullanıcı Adı"></asp:TextBox>
                        <span class="focus-input100" data-placeholder="&#xe82a;"></span>
                    </div>
                    
                    <div class="wrap-input100 validate-input" data-validate="Şifre girin">
                        <asp:TextBox ID="txtPass" class="input100" runat="server" type="password" placeholder="Şifre"></asp:TextBox>
                        <span class="focus-input100" data-placeholder="&#xe80f;"></span>
                    </div>

                    <div class="container-login100-form-btn m-t-32">
                        <asp:Button ID="btnGiris" class="btn btn-outline-info btn-lg login100-form-btn " runat="server" Text="Giriş" OnClick="btnGiris_Click"/>
                    </div>
                    <h6>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Şifreyi&nbsp;<a href="#">Unuttum</a></h6>
                </form>
            </div>
        </div>
    </div>
    <script src="vendor/jquery/jquery-3.2.1.min.js"></script>
    <script src="vendor/animsition/js/animsition.min.js"></script>
    <script src="vendor/bootstrap/js/popper.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="vendor/select2/select2.min.js"></script>
    <script src="vendor/daterangepicker/moment.min.js"></script>
    <script src="vendor/daterangepicker/daterangepicker.js"></script>
    <script src="vendor/countdowntime/countdowntime.js"></script>
    <script src="js/main.js"></script>
</body>
</html>
