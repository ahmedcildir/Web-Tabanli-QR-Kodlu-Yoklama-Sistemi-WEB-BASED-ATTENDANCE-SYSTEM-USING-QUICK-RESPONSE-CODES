<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="anasayfa.aspx.cs" Inherits="Akili_Imza_Si.anasayfa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<%-- Fügür Kütüphanesi --%>
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css">
<head runat="server">
    <title>Ana Sayfa</title>
    <link href="web/theme-assets/css/bootstrap.min.css" rel="stylesheet" />
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
            &emsp; &emsp;
            <a class="navbar-brand col-sm-12" href="#">
                <font size="5"  color="#ffffff"><i class="fas fa-edit"> Siirt Üniversitesi İmza Sistemi</i></font>
            </a>
        </nav>
        <div class="container">
            <div class="row  col-lg-12 col-md-12 col-sm-12">
                <div class="col col-lg-12 col-md-12 col-sm-12 text-center ">
                    <asp:Image ID="imgAnasayfa" runat="server" src="idari/images/lo3.png" class="rounded mx-auto  col-sm-12" />

                    <table class="table table-borderless">
                        <thead>
                            <tr>
                                <td></td>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Button ID="btnOgrenci" class="btn btn-outline-info btn-block btn-lg" runat="server" Text="Öğrenci Girişi" OnClick="btnOgrenci_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnAkademik" class="btn btn-outline-info btn-block btn-lg" runat="server" Text="Akademisyen Girişi" OnClick="btnAkademik_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnidari" class="btn btn-outline-info btn-block btn-lg" runat="server" Text="İdari Girişi" OnClick="btnidari_Click" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <%-- heder --%>
        <div class="card-header  w-100 ">
            <div class="row">
                <div class="col-sm text-center">
                    <h6>Telif Hakkı © 2019 AHMED ÇILDIR </h6>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
