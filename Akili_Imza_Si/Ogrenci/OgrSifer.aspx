<%@ Page Title="" Language="C#" MasterPageFile="~/OgrenciMastr.Master" AutoEventWireup="true" CodeBehind="OgrSifer.aspx.cs" Inherits="Akili_Imza_Si.Ogrenci.OgrSifer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <asp:TextBox ID="txtEskiSifre" class="form-control mr-sm-4" type="password" runat="server" placeholder="Eski Şifreyi Girin..."></asp:TextBox>
                <hr />
                <asp:TextBox ID="txtYeniSifrr" class="form-control mr-sm-4" type="password" runat="server" placeholder="Yeni Şifre Girin..."></asp:TextBox>
                <hr />
                <asp:TextBox ID="txtYeniSifrrTekrar" class="form-control mr-sm-4" type="password" runat="server" placeholder="Yeni Şifre Tekrar..."></asp:TextBox>
                <hr />
                <hr />
                <asp:Button ID="btnYukle" runat="server" class="btn btn-outline-primary" Text="Kaydet" OnClick="btnYukle_Click" />
                <asp:Label ID="lblUyari" runat="server" ForeColor="Red" ></asp:Label>
                <hr />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="(*Eski Şifre Kısmı Boş Geçilemez)" ControlToValidate="txtEskiSifre" ForeColor="Red"></asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="(*Yeni Şifre Kısmı Boş Geçilemez)" ControlToValidate="txtYeniSifrr" ForeColor="Red"></asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="(*Şifre Tekrar Kısmı Boş Geçilemez)" ControlToValidate="txtYeniSifrrTekrar" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="Regex1" runat="server" ControlToValidate="txtYeniSifrr"
                    ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$" ErrorMessage="*Şifreniz en az 8 karakter 1 numara ve 1 harf içermeli" ForeColor="Red"></asp:RegularExpressionValidator>
                <br />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtYeniSifrr" ControlToValidate="txtYeniSifrrTekrar" ErrorMessage="*Şifreler Aynı Değil." ForeColor="Red"></asp:CompareValidator>
            </div>
        </div>
        <br />
        <br />
        <br />
        <br />
    </div>
</asp:Content>
