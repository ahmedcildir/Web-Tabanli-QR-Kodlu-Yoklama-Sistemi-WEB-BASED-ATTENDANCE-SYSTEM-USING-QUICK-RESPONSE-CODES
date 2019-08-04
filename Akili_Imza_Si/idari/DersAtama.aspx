<%@ Page Title="" Language="C#" MasterPageFile="~/idariSa.Master" AutoEventWireup="true" CodeBehind="DersAtama.aspx.cs" Inherits="Akili_Imza_Si.idari.DersAtama" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2><i class="fas fa-clipboard-check"> Ders Atama</i></h2>
    <hr />
    <asp:DropDownList ID="dropBollum" Class="custom-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropBollum_SelectedIndexChanged1">
    </asp:DropDownList>
    <hr />
    <asp:DropDownList ID="dropDers" Class="custom-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropDers_SelectedIndexChanged">
    </asp:DropDownList>
    <hr />
    <asp:DropDownList ID="dropHoca" Class="custom-select" runat="server">
    </asp:DropDownList>
    <hr />
    <asp:Button ID="btnDersKaydi" class="btn btn-outline-primary" runat="server" Text="Dersi Kaydet" OnClick="btnDersKaydi_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblmesaj" runat="server" ForeColor="Red"></asp:Label>

</asp:Content>
