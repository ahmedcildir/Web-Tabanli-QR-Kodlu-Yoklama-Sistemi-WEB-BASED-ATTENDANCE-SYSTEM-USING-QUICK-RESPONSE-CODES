<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BarKode.aspx.cs" Inherits="Akili_Imza_Si.wep.Deneme2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<%-- Fügür ekleme --%>
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css">
<head runat="server">
    <script type="text/javascript" src="../web/theme-assets/js/qrcode.js"></script>
    <link href="../web/theme-assets/css/bootstrap.min.css" rel="stylesheet" />
    <title></title>
</head>

<body onload="createQrCode()">

    <nav class="navbar sticky-top navbar-expand-sm navbar-light " style="background-color: #141946">
        <a class="navbar-brand" href="home.aspx">
            <font face="Times" size="5" color="#ffffff"><i class="fas fa-edit"></i> Siirt Üniversitesi İmza Sistemi</font>
        </a>
    </nav>
    <div class="container">
        <div class="row ">
            <div class="col col-lg-12 col-md-12 col-sm-12 text-center ">
                <br />
                <div align="center" id="qrcode"></div>
            </div>
        </div>
        <div class="card-header  w-100 ">
            <div class="row">
                <div class="col-sm text-center">
                    <h6>Telif Hakkı © 2019 AHMED ÇILDIR </h6>
                </div>
            </div>
        </div>
    </div>

</body>

<script>
    function createQrCode() {
        var userInput = 'Ahmed';
        //document.getElementById('valor').value;

        var qrcode = new QRCode("qrcode", {
            text: userInput,
            width: 525,
            height: 525,

            colorDark: "black",
            colorLight: "white",

            correctLevel: QRCode.CorrectLevel.H
        });
    }
    </script>
</html>
