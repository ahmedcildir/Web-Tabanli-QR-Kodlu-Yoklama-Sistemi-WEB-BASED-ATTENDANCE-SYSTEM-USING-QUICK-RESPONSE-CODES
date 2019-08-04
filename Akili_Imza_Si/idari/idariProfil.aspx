<%@ Page Title="" Language="C#" MasterPageFile="~/idariSa.Master" AutoEventWireup="true" CodeBehind="idariProfil.aspx.cs" Inherits="Akili_Imza_Si.idari.idariProfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2><i class="far fa-user"> Profilim</i></h2>
    <div class="container">
        <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-12 text-xl-center">
                <hr />
                <asp:Image ID="imgfoto" class="img-thumbnail rounded-circle" runat="server" Height="150px" Width="150px" />
            </div>
            <div class="col-sm">
                <hr />
                <table class="table table-borderless ">
                    <tbody>
                        <tr>
                            <td><i class="far fa-user">&emsp; Ad Soyad :</i></td>
                            <td>
                                <asp:Label ID="lblAd" runat="server"></asp:Label>
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
                            <th style="height: 10px; width: 194px;">
                                <asp:FileUpload ID="resimyukle" runat="server" class="btn btn-outline-danger" Font-Names="Arial Narrow" ForeColor="Blue" /></th>
                            <td style="height: 10px">
                                <asp:Button ID="btnfoto" runat="server" class="btn btn-outline-primary" Text="Fotoğrafı Değiştir" OnClick="btnfoto_Click" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-sm">
                <table class="table table-borderless">
                    <tbody>
                        <tr>
                            <td style="width: 162px"><i class="fas fa-id-badge">&emsp; Kullanıcı Adı :</i></td>
                            <td>
                                <asp:TextBox ID="txtKullanıcıAd" class="form-control mr-sm-4" runat="server" placeholder="Kullanıcı Adı..."></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 162px"><i class="fas fa-mobile-alt">&emsp; Telefon :</i></td>
                            <td>
                                <asp:TextBox ID="txtTelefon" class="form-control mr-sm-4" runat="server" placeholder="Telefon..."></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 30px; width: 162px"><i class="fas fa-at">&emsp;E-posta :</i></td>
                            <td style="height: 30px">
                                <asp:TextBox ID="txtEposta" class="form-control mr-sm-4" runat="server" placeholder="E-posta..."></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 162px">
                                <button type="button" class="btn btn-outline-primary" data-toggle="modal" data-target="#exampleModal" data-whatever="@getbootstrap">Kullanıcı Bilgilerimi Getir</button>
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
                                                <%--<div id="divbolum1"> 
                                                           <asp:Panel runat="server" DefaultButton="buton1">   // işte buradaki defaultbutton özelliği 
                                                              <asp:TextBox runat="server"></asp:TextBox> 
                                                              <asp:Button runat="server" ID="buton1"/> 
                                                           </asp:Panel> 
                                                        </div>--%>
                                                <asp:Button ID="btnKapat" runat="server" Text="Kapat" class="btn btn-secondary" data-dismiss="modal" />
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
