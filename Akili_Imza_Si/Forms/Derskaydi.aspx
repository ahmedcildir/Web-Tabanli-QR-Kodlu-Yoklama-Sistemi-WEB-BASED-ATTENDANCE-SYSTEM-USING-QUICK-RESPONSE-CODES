<%@ Page Title="" Language="C#" MasterPageFile="~/AkademisyenSa.Master" AutoEventWireup="true" CodeBehind="Derskaydi.aspx.cs" Inherits="Akili_Imza_Si.Forms.Derskaydi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
     <asp:DropDownList ID="dropFakulte" Class="custom-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropFakulte_SelectedIndexChanged">
        <asp:ListItem>Fakulte Seçiniz..</asp:ListItem>
    </asp:DropDownList>
    <hr />
     <asp:DropDownList ID="dropBollum" Class="custom-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropBollum_SelectedIndexChanged">
        <asp:ListItem>Bölüm Seçiniz..</asp:ListItem>
    </asp:DropDownList>
    <hr />
     <asp:DropDownList ID="dropDersKodu" Class="custom-select" runat="server">
        <asp:ListItem>Ders Seçiniz..</asp:ListItem>
    </asp:DropDownList>
    <hr />
        <asp:Button ID="btnDersKaydi" class="btn btn-outline-primary" runat="server" Text="Dersi Kaydet" OnClick="btnDersKaydi_Click"  />

</asp:Content>
