<%@ Page Title="" Language="C#" MasterPageFile="~/AkademisyenSa.Master" AutoEventWireup="true" CodeBehind="imzaUret.aspx.cs" Inherits="Akili_Imza_Si.Forms.imzaUret" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2><i class="fas fa-pencil-alt">  İmza İşlemi</i></h2>
    <hr />
    <asp:DropDownList ID="dropPT" Class="custom-select" runat="server" >  
    </asp:DropDownList>
    <hr />
    <asp:DropDownList ID="dropDers" Class="custom-select" runat="server"  >  
    </asp:DropDownList>
    <hr />
     <asp:DropDownList ID="dropSaat" Class="custom-select"  runat="server">
        <asp:ListItem>Saat Seçiniz..</asp:ListItem>
    </asp:DropDownList>
    <hr />
    <asp:DropDownList ID="dropHafta" Class="custom-select" runat="server">
        <asp:ListItem>Haftayı Seçiniz..</asp:ListItem>
    </asp:DropDownList>
    <hr />
    <%--<asp:DropDownList ID="dropSinif" Class="custom-select" runat="server">
        <asp:ListItem>Sınıfı Seçiniz..</asp:ListItem>
    </asp:DropDownList>--%>
    
    <asp:Button ID="btnQrUret" class="btn btn-outline-primary" runat="server" Text="İmza Al" OnClick="btnQrUret_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="labUyari" runat="server" ForeColor="Red"></asp:Label>
</asp:Content>
