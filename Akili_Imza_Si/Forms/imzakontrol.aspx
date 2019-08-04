<%@ Page Title="" Language="C#" MasterPageFile="~/AkademisyenSa.Master" AutoEventWireup="true" CodeBehind="imzakontrol.aspx.cs" Inherits="Akili_Imza_Si.Forms.imzakontrol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2><i class="far fa-clipboard"></i> İmza Kontrol</h2>
    <hr />
    <asp:DropDownList ID="dropPT" Class="custom-select" runat="server">
    </asp:DropDownList>
    <hr />
    <asp:DropDownList ID="dropDers" Class="custom-select" runat="server">
    </asp:DropDownList>
    <hr />
    <asp:DropDownList ID="dropSaat" Class="custom-select" runat="server">
        <asp:ListItem>Saat Seçiniz..</asp:ListItem>
    </asp:DropDownList>
    <hr />
    <asp:DropDownList ID="dropHafta" Class="custom-select" runat="server">
        <asp:ListItem>Haftayı Seçiniz..</asp:ListItem>
    </asp:DropDownList>
    <hr />
    <asp:Button ID="btnimzakontrol" class="btn btn-outline-primary" runat="server" Text="Kontrol Et" OnClick="btnimzakontrol_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="labUyari" runat="server" ForeColor="Red"></asp:Label>
    <hr />
    <table class="table">
        <thead class="thead-light">
            <tr>
                <th scope="col">Oğrenci No</th>
                <th scope="col">Ad</th>
                <th scope="col">Soyad</th>
                <th scope="col">İmza Tarihi</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="repimza" runat="server">
                <ItemTemplate>
                    <tr>
                        <th scope="row"><%# Eval("Ogr_No") %></th>
                        <td><%# Eval("Ogr_Ad") %></td>
                        <td><%# Eval("Ogr_Soyad") %></td>
                        <td><%# Eval("imza_Tarihi") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>


        </tbody>
    </table>
</asp:Content>
