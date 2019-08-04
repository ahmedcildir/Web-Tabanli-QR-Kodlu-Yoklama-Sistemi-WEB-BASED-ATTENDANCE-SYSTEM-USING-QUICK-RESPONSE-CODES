<%@ Page Title="" Language="C#" MasterPageFile="~/OgrenciMastr.Master" AutoEventWireup="true" CodeBehind="Devamsizlik.aspx.cs" Inherits="Akili_Imza_Si.Ogrenci.Devamsizlik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12 col-md-12 col-sm-12 ">
        <table class="table">
            <thead class="thead-light">
                <tr class="col-lg-12 col-md-12 col-sm-12 ">
                    <th scope="col">Ders Kodu <i class="fas fa-angle-double-right"></i>Ders Adı</th>
                    <th scope="col">T+U <i class="fas fa-angle-double-right"></i>Sınıf</th>
                    <th scope="col">Z-S</th>
                    <th scope="col">Toplam Devamsızlık Saati</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="repAlinanDersler" runat="server">
                    <ItemTemplate>
                        <tr class="col-lg-12 col-md-12 col-sm-12 ">
                            <th scope="row"><%# Eval("Ders_Kod") %> <i class="fas fa-angle-double-right"></i><%# Eval("Ders_Ad") %></th>
                            <td><%# Eval("Teori_Saati") %> + <%# Eval("Piratik_Saati") %> <i class="fas fa-angle-double-right"></i>S.<%# Eval("Sinif") %></td>
                            <td><%# Eval("Drs_S_Z") %></td>
                            <td><a href="devamsızlıkDetayi.aspx?dk=<%# Eval("Ders_Kod") %>">Devamsızlık Detayı</a></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
    <div class="col-lg-12 col-md-12 col-sm-12">
        <p>
            <asp:Label ID="Label1" runat="server" ></asp:Label>
            <%--Toplam 14 Hafta (70 Saat). Teorik Toplamı 42 Saat, Devamsızlık Oranı (%30)/13 Saat. Uygulama Toplamı 28 Saat, Devamsızlık Oranı (%20)/6 Saat.--%>
        </p>
    </div>

</asp:Content>
