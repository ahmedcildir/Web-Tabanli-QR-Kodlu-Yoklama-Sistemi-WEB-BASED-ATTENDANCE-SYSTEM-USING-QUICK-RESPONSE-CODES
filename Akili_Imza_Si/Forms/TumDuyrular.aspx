<%@ Page Title="" Language="C#" MasterPageFile="~/AkademisyenSa.Master" AutoEventWireup="true" CodeBehind="TumDuyrular.aspx.cs" Inherits="Akili_Imza_Si.Forms.TumDuyrular" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2><i class="fas fa-bullhorn">&emsp;Duyury</i></h2>
    <hr />
    <div class="card">
        <h5 class="card-header"><i class="far fa-bell">&emsp;Duyuru Detayı</i></h5>
        <div class="card m-lg-auto col-lg-11 col-sm-11 col-md-11">
            <div class="card-body">
             <asp:ListView ID="lisDuyru" runat="server">
                        <ItemTemplate>
                            <li class="list-group-item list-group-item-success"><b><i class="fas fa-check"> Başlık :</i> </b><%# Eval("Baslik") %>&emsp; &emsp; &emsp;<i class="far fa-calendar-alt">  <%# Eval("Tarih") %></i> <i class="fas fa-angle-double-right"></i>
                                <%--<asp:LinkButton ID="linBoku" runat="server">oku </asp:LinkButton>--%>
                                <a href="DuyruDetayi.aspx?dud=<%# Eval("DİD") %>">oku</a>
                            </li>
                        </ItemTemplate>
                    </asp:ListView>
            </div>
        </div>
        <div class="card-footer text-muted">
            <i class="far fa-calendar-alt">&emsp;Duyru Tarihi : 
                    <asp:Label ID="lblTarih" runat="server"></asp:Label></i>
            <asp:Button ID="btnkapat" class="btn btn-outline-primary fa-pull-right" runat="server" Text="Kapat" OnClick="btnkapat_Click"/>
        </div>
    </div>
</asp:Content>
