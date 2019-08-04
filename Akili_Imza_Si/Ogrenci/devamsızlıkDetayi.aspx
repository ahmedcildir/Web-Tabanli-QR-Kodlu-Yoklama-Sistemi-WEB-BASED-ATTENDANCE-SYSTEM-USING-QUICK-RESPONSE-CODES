<%@ Page Title="" Language="C#" MasterPageFile="~/OgrenciMastr.Master" AutoEventWireup="true" CodeBehind="devamsızlıkDetayi.aspx.cs" Inherits="Akili_Imza_Si.Ogrenci.devamsızlıkDetayi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12 col-md-12 col-sm-12 ">
        <div class="card">
            <h5 class="card-header"><i class="far fa-bell">&emsp;Devamsızlık Detayı</i></h5>
            <div class="card m-lg-auto col-lg-11 col-sm-11 col-md-11">
                <div class="card-body">
                    <ul class="list-group">
                        <li class="list-group-item list-group-item-success">
                                <table class="table table-bordered col-lg-11 col-sm-11 col-md-11"">
                                    <thead>
                                        <tr>
                                            <td>Toplam Hafta Sayısı </td>
                                            <td>
                                                <asp:Label ID="lbltoplamhafta" runat="server" ForeColor="Blue" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>Toplam Saat</td>
                                            <td>
                                                <asp:Label ID="lbltoplamsaat" runat="server" ForeColor="Blue" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Teorik Toplamı</td>
                                            <td>
                                                <asp:Label ID="tblteoriktoplam" runat="server" ForeColor="Blue" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Teorik Devamsızlık Oranı (%30)</td>
                                            <td>
                                                <asp:Label ID="lblteorikdevamsızlık" runat="server" ForeColor="Blue" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Uygulama Toplamı</td>
                                            <td>
                                                <asp:Label ID="lbluygulamalitoplam" runat="server" ForeColor="Blue" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Uygulama Devamsızlık Oranı (%20)</td>
                                            <td>
                                                <asp:Label ID="lbluygulamalidevamsizlik" runat="server" ForeColor="Blue" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                        </li>
                    </ul>
                    <hr />
                    <hr />
                    <ul class="list-group">
                        <li class="list-group-item list-group-item-dark">
                            <h3><i class="fas fa-check">&nbsp;Toplam Devamsızlık Saati :</i>
                                <asp:Label ID="lblTDS" runat="server" ForeColor="Red"></asp:Label>
                            </h3>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="card-footer text-muted">
                <i class="far fa-calendar-alt">&nbsp;Tarihi : 
                    <asp:Label ID="lblTarih" runat="server"></asp:Label></i>
                <asp:Button ID="btnkapat" class="btn btn-outline-primary fa-pull-right" runat="server" Text="Kapat" OnClick="btnkapat_Click" />

            </div>
        </div>
    </div>
</asp:Content>
