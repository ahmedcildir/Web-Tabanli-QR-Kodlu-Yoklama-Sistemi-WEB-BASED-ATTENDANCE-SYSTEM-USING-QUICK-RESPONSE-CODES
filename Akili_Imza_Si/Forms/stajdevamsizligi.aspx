<%@ Page Title="" Language="C#" MasterPageFile="~/AkademisyenSa.Master" AutoEventWireup="true" CodeBehind="stajdevamsizligi.aspx.cs" Inherits="Akili_Imza_Si.Forms.stajdevamsizligi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DropDownList ID="dropogr" class="custom-select" runat="server">
        <asp:ListItem>Seçiniz..</asp:ListItem>
    </asp:DropDownList>
    <hr />
    <asp:Button runat="server" Text="Ara" OnClick="Unnamed1_Click" />
    <hr />
    <table class="table">
        <thead>

            <tr>
                <th scope="col">Ad Soyad</th>
                <th scope="col">Gün / Tarih</th>
                <th scope="col">Saati</th>
                <th scope="col">Giriş / Çıkış</th>
            </tr>

        </thead>
        <tbody>
            <asp:Repeater ID="repliste" runat="server">
                <ItemTemplate>
                    <tr>
                        <th scope="row"><%# Eval("Ogr_Ad") %>&nbsp;<%# Eval("Ogr_Soyad") %></th>
                        <td><%# Eval("Ders_Tipi") %>&nbsp;/&nbsp;<%# Eval("imza_Tarihi") %></td>
                        <td><%# Eval("imza_Saat") %></td>
                        <td><%# Eval("Ders_Kod") %></td>

                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>


</asp:Content>
