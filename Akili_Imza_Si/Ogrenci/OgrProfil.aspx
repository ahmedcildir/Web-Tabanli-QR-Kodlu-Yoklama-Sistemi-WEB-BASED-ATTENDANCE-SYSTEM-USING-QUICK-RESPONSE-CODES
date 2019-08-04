<%@ Page Title="" Language="C#" MasterPageFile="~/OgrenciMastr.Master" AutoEventWireup="true" CodeBehind="OgrProfil.aspx.cs" Inherits="Akili_Imza_Si.Ogrenci.OgrProfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-4 col-md-12 col-sm-12 text-xl-center">

                <asp:Image ID="imgfoto" class="img-thumbnail rounded-circle" runat="server" Height="150px" Width="150px" />
            </div>
            <div class="col-lg-8 col-md-12 col-sm-12">
                <br />
                <table class="table table-borderless ">
                    <tbody>
                        <tr>
                            <td><i class="far fa-user">&emsp; Ad Soyad :</i></td>
                            <td>
                                <asp:Label ID="lblAd" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td><i class="fas fa-id-badge">&emsp;Öğrenci No :</i></td>
                            <td>
                                <asp:Label ID="lblOgrNo" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td><i class="far fa-id-card">&emsp;TC Kimlik No :</i></td>
                            <td>
                                <asp:Label ID="lblTc" runat="server"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <th><i class="far fa-calendar-alt">&emsp; Doğum Tarihi :</i></th>
                            <td>
                                <asp:Label ID="lblDogumTarihi" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:FileUpload ID="resimyukle" runat="server" Font-Names="Arial Narrow" ForeColor="Blue" />
                            </td>
                            <td>
                                <asp:Button ID="btnfoto" runat="server" class="btn btn-outline-primary" Text="Kaydet" OnClick="btnfoto_Click" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <hr />
        <hr />
        <div class="row">
            <div class="col-sm">
                <table class="table table-borderless">
                    <tbody>
                        <%--   <tr>
                        <td style="width: 162px"><i class="fas fa-id-badge">&emsp; Kullanıcı Adı :</i></td>
                        <td>
                            <asp:TextBox ID="txtKullanıcıAd" class="form-control mr-sm-4" runat="server" placeholder="Kullanıcı Adı..."></asp:TextBox>

                        </td>
                    </tr>--%>
                        <tr>
                            <td style="width: 162px"><i class="fas fa-mobile-alt">&emsp; Telefon :</i></td>
                            <td>
                                <asp:TextBox ID="txtTelefon" class="form-control mr-sm-4" runat="server" placeholder="Telefon..."></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 30px; width: 162px"><i class="fas fa-at">&emsp;E-posta :</i>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEposta" ErrorMessage="Geçerli E-Posta Girin Lütfen." ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>

                            </td>
                            <td style="height: 30px">
                                <asp:TextBox ID="txtEposta" class="form-control mr-sm-4" runat="server" placeholder="E-posta..."></asp:TextBox>
                            </td>
                        </tr>
                        <%--<tr>
                            <td style="width: 162px"><i class="fas fa-star">&emsp;Ünvan :</i></td>
                            <td>
                                <asp:TextBox ID="txtUnvan" class="form-control mr-sm-4" runat="server" placeholder="Ünvan..."></asp:TextBox>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                                <button type="button" class="btn btn-outline-primary" data-toggle="modal" data-target="#exampleModal" data-whatever="@getbootstrap">Kullanıcı Bilgilerimi Getir</button>
                                <br />
                                <asp:Label ID="lblBilgilendirme" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 162px">
                                <asp:Button ID="btnYukle" runat="server" class="btn btn-outline-primary" Text="Kaydet" OnClick="btnYukle_Click" />
                                <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                    <div class="modal-dialog" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <h5 class="modal-title" id="exampleModalLabel">ŞİFREYİ GİRİN..</h5>
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                            </div>
                                            <div class="modal-body">
                                                <form>
                                                    <div class="form-group">
                                                        <asp:TextBox ID="txtSifreD" type="password" placeholder="Şifreyi Giriniz..." class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </form>
                                            </div>
                                            <div class="modal-footer">
                                                <asp:Button ID="btnKapat" runat="server" Text="Kapat" class="btn btn-secondary" data-dismiss="modal" OnClick="btnKapat_Click" />
                                                <asp:Button ID="btnBGetir" runat="server" class="btn btn-outline-primary" Text="Tamam" OnClick="btnBGetir_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
