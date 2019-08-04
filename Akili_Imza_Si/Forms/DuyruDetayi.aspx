<%@ Page Title="" Language="C#" MasterPageFile="~/AkademisyenSa.Master" AutoEventWireup="true" CodeBehind="DuyruDetayi.aspx.cs" Inherits="Akili_Imza_Si.Forms.DuyruDetayi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2><i class="fas fa-bullhorn">&emsp;Duyury</i></h2>
    <hr />
    <div class="card">
        <h5 class="card-header"><i class="far fa-bell">&emsp;Duyuru Detayı</i></h5>
        <div class="card m-lg-auto col-lg-11 col-sm-11 col-md-11">
            <div class="card-body">
                <ul class="list-group">
                    <li class="list-group-item list-group-item-success">
                        <h3><i class="fas fa-check">Başlık</i> <i class="fas fa-angle-double-right">
                            <asp:Label ID="lblBaslik" runat="server" Text="Label"></asp:Label></i>
                        </h3>
                    </li>
                </ul>
                <hr />
                <hr />
                <ul class="list-group">
                    <li class="list-group-item list-group-item-dark"><i class="fas fa-check">Mesaj :</i>
                        <asp:Label ID="lblmesaj" runat="server" Text="Label"></asp:Label>
                    </li>
                </ul>
            </div>
        </div>
        <div class="card-footer text-muted">
            <i class="far fa-calendar-alt">&emsp;Duyry Tarihi : 
                    <asp:Label ID="lblTarih" runat="server"></asp:Label></i>
            <asp:Button ID="btnkapat" class="btn btn-outline-primary fa-pull-right" runat="server" Text="Kapat" OnClick="btnkapat_Click" />

        </div>
    </div>
</asp:Content>
