<%@ Page Title="" Language="C#" MasterPageFile="~/AkademisyenSa.Master" AutoEventWireup="true" CodeBehind="staj.aspx.cs" Inherits="Akili_Imza_Si.Forms.staj" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2><i class="fas fa-pencil-alt">  Yoklama</i></h2>
    <hr />
     <asp:DropDownList ID="dropDers" Class="custom-select" runat="server"  >  
    </asp:DropDownList>
    <hr />
    <asp:DropDownList ID="dropGun" Class="custom-select" runat="server" >  
        <asp:ListItem>Gün Seçiniz..</asp:ListItem>
    </asp:DropDownList>
    <hr />
    <asp:DropDownList ID="dropI_O" Class="custom-select" runat="server"  >  
        <asp:ListItem>Seçiniz..</asp:ListItem>
    </asp:DropDownList>
    <hr />
    <%--<asp:DropDownList ID="dropSinif" Class="custom-select" runat="server">
        <asp:ListItem>Sınıfı Seçiniz..</asp:ListItem>
    </asp:DropDownList>--%>
    
    <asp:Button ID="btnQrUret" class="btn btn-outline-primary" runat="server" Text="Yoklama Al" OnClick="btnQrUret_Click"  />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="labUyari" runat="server" ForeColor="Red"></asp:Label>

</asp:Content>
