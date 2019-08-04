<%@ Page Title="" Language="C#" MasterPageFile="~/idariSa.Master" AutoEventWireup="true" CodeBehind="Duyrular.aspx.cs" Inherits="Akili_Imza_Si.idari.Duyrular" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h2><i class="far fa-envelope"> Duyru Yayınlama</i></h2>
                <hr />
                <asp:DropDownList ID="dropKatagori" Class="custom-select" AutoPostBack="true" runat="server" OnSelectedIndexChanged="dropKatagori_SelectedIndexChanged"></asp:DropDownList>
                <hr />
                <asp:DropDownList ID="dropBolum" Class="custom-select"  runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropBolum_SelectedIndexChanged"></asp:DropDownList>
                <hr />
                <asp:DropDownList ID="drophoca" Class="custom-select" runat="server"></asp:DropDownList>
                <hr />

                <div class="input-group input-group-lg">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="inputGroup-sizing-lg"><i class="fas fa-hashtag"> Konu Başlığı</i></span>
                    </div>
                    <asp:TextBox ID="txtBaslik" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default" runat="server"></asp:TextBox>
                </div>

                <hr />
                <div class="form-group">
                    <label for="comment">
                        <h3><i class="far fa-comment"> Mesaj Yaz:</i></h3>
                    </label>
                    <textarea class="form-control" id="comment" rows="5"></textarea>
                </div>
                <asp:Button ID="Button1" class="btn btn-outline-info" runat="server" Text="Gönder" OnClick="Button1_Click1" OnClientClick="SetHiddenField()" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="HiddenField" runat="server" Value="" />
    <script type="text/javascript">
        function SetHiddenField() {
            var x = document.getElementById("comment").value;
            document.getElementById('<%=HiddenField.ClientID%>').value = x;
        }
    </script>
</asp:Content>
