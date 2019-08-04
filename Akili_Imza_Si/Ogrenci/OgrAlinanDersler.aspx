<%@ Page Title="" Language="C#" MasterPageFile="~/OgrenciMastr.Master" AutoEventWireup="true" CodeBehind="OgrAlinanDersler.aspx.cs" Inherits="Akili_Imza_Si.Ogrenci.OgrAlinanDersler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12 col-md-12 col-sm-12 ">
        <table class="table">
            <thead class="thead-light">
                <tr class="col-lg-12 col-md-12 col-sm-12 ">
                    <th scope="col">Ders Kodu <i class="fas fa-angle-double-right"></i>Ders Adı</th>
                    <th scope="col">T+U <i class="fas fa-angle-double-right"></i>Sınıf</th>
                    <th scope="col">Z-S</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="repAlinanDersler" runat="server">
                    <ItemTemplate>
                        <tr class="col-lg-12 col-md-12 col-sm-12 ">
                            <th scope="row"><%# Eval("Ders_Kod") %> <i class="fas fa-angle-double-right"></i><%# Eval("Ders_Ad") %></th>
                            <td><%# Eval("Teori_Saati") %> + <%# Eval("Teori_Saati") %> <i class="fas fa-angle-double-right"></i>S.<%# Eval("Sinif") %></td>
                            <td><%# Eval("Drs_S_Z") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>
</asp:Content>
