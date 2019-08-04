<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="oisk.aspx.cs" Inherits="Akili_Imza_Si.Ogrenci.oisk" %>

<!DOCTYPE html>

<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../web/theme-assets/css/bootstrap.min.css" rel="stylesheet" />
    <title>Siirt Üniversitesi İmza Sistemine Kayıt</title>
</head>
<body>
    <style>
        body {
            background: #ffffff
        }

        @media (min-width: 1000px) {
            .container {
                max-width: 1000px;
            }
        }
    </style>
    <nav class="navbar sticky-top navbar-expand-sm navbar-light " style="background-color: #141946">
        <a class="navbar-brand" href="#">
            <font face="Times" size="5" color="#ffffff"><i class="fas fa-edit"></i> Siirt Üniversitesi İmza Sistemine Kayıt</font>
        </a>
    </nav>
    <form id="form1" runat="server">
        <div class="container media">
            <div class="row ">
                <div class="col col-lg-12 col-md-12 col-sm-12">
                    <asp:Image ID="imgAnasayfa" runat="server" src="../idari/images/lo3.png" class="rounded mx-auto  col-sm-12" />
                    <table class="table table-borderless">
                        <thead>
                            <tr>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Ad :
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAd" ErrorMessage="Ad Kısmı Boş Geçilemez." ForeColor="Red">*</asp:RequiredFieldValidator>

                                </td>
                                <td>
                                    <asp:TextBox ID="txtAd" Class="form-control" placeholder="Ad.." runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Soyad
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSoyad" ErrorMessage="Soyad Kısmı Boş Geçilemez." ForeColor="Red">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSoyad" Class="form-control" placeholder="Soyad.." runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Tc :
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTc" ErrorMessage="Tc Kısmı Boş Geçilemez." ForeColor="Red">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTc" Class="form-control" placeholder="Tc.." runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Oğrenci No :
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtOgrNo" ErrorMessage="Oğrenci No Kısmı Boş Geçilemez." ForeColor="Red">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOgrNo" Class="form-control" placeholder="Oğrenci No.." runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Doğum Tarihi :
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDogumTarihi" ErrorMessage="Doğum Tarihi Kısmı Boş Geçilemez." ForeColor="Red">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDogumTarihi" Class="form-control" placeholder="Doğum Tarihi.." runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Telefon :
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtTelefon" ErrorMessage="Oğrenci No Kısmı Boş Geçilemez." ForeColor="Red">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTelefon" Class="form-control" placeholder="Telefon.." runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>E-posta :
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="E-Posta Kısmı Boş Geçilemez." ControlToValidate="txtEposta" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEposta" ErrorMessage="Geçerli E-Posta Girin Lütfen." ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>

                                </td>
                                <td>
                                    <asp:TextBox ID="txtEposta" Class="form-control" placeholder="E-posta.." runat="server"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td>Şifre :
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSifre" ErrorMessage="Şifre Kısmı Boş Geçilemez." ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="Regex1" runat="server" ControlToValidate="txtSifre"
                                        ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$" ErrorMessage="Şifreniz en az 8 karakter 1 numara ve 1 harf içermeli." ForeColor="Red">*</asp:RegularExpressionValidator>

                                </td>
                                <td>
                                    <asp:TextBox ID="txtSifre" Class="form-control" type="password" placeholder="Şifer.." runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Şifre Tekrar :
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSifreTekrar" ErrorMessage="Şifre Tekrar Kısmı Boş Geçilemez." ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtSifre" ControlToValidate="txtSifreTekrar" ErrorMessage="Şifreler Aynı Değil." ForeColor="Red">*</asp:CompareValidator>

                                </td>
                                <td>
                                    <asp:TextBox ID="txtSifreTekrar" Class="form-control" placeholder="Şifer Tekrer.." type="password" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" HeaderText="Hata" ForeColor="Red" />
                                </td>
                                <td>
                                    <asp:Button ID="btnKayit" class="btn btn-outline-info btn-block btn-lg" runat="server" Text="Kaydol"  OnClick="btnKayit_Click" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
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
