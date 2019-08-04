<%@ Page Title="" Language="C#" MasterPageFile="~/AkademisyenSa.Master" AutoEventWireup="true" CodeBehind="FotografGuncelleme.aspx.cs" Inherits="Akili_Imza_Si.Forms.FotografGuncelleme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <asp:Image ID="Image1" class="img-thumbnail" runat="server" Height="150px" Width="150px" />
    <hr />
    <hr />
    <asp:FileUpload ID="resimyukle" class="btn btn-outline-danger"  runat="server" />
    <asp:Button ID="btnYukle" runat="server" class="btn btn-outline-primary" Text="YÜKLE" OnClick="btnUpload_Click" />
    <hr />
</asp:Content>
