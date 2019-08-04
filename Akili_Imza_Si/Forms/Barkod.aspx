<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Barkod.aspx.cs" Inherits="Akili_Imza_Si.Barkod" %>

<!DOCTYPE html>
<%-- Fügür ekleme --%>
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../web/theme-assets/css/bootstrap.min.css" rel="stylesheet" />
    <title>İmza Sistemi</title>
</head>
<body>
    <style>
        body {
            background: #ffffff
        }

        @media (min-width: 1200px) {
            .container {
                max-width: 1200px;
            }
        }
    </style>
    <form id="form2" runat="server">
        <nav class="navbar sticky-top navbar-expand-sm navbar-light " style="background-color: #141946">
            <a class="navbar-brand" href="home.aspx">
                <font face="Times" size="5" color="#ffffff"><i class="fas fa-edit"></i> İmza Sistemi</font>
            </a>
        </nav>
        <div class="container">
            <div class="row ">
                <div class="col col-lg-12 col-md-12 col-sm-12 text-center ">
                    <%-- QR  cod yayın --%>
                    <asp:Image ID="ImgQRCode" class="rounded" runat="server" Height="600px" Width="600px" />                  
                </div>
            </div>
            <%-- heder --%>
            <div class="card-header  w-100 ">
                <div class="row">
                    <div class="col-sm">
                        <h6 >Telif Hakkı © 2019 AHMED ÇILDIR </h6>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
