<%@ Page Title="" Language="C#" MasterPageFile="~/AkademisyenSa.Master" AutoEventWireup="true" CodeBehind="AkDuyruYayinla.aspx.cs" Inherits="Akili_Imza_Si.Forms.AkDuyruYAyinla" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <h2><i class="far fa-envelope">&nbsp;Duyru Yayınlama</i></h2>
                <hr />
                <asp:DropDownList ID="dropKatagori" Class="custom-select" AutoPostBack="true" runat="server" OnSelectedIndexChanged="dropKatagori_SelectedIndexChanged"></asp:DropDownList>
                <hr />
                <asp:DropDownList ID="dropders" Class="custom-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropBolum_SelectedIndexChanged"></asp:DropDownList>
                <hr />
                <asp:DropDownList ID="dropOgr" Class="custom-select" runat="server"></asp:DropDownList>
                <hr />

                <div class="input-group input-group-lg">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="inputGroup-sizing-lg"><i class="fas fa-hashtag">Konu Başlığı</i></span>
                    </div>
                    <asp:TextBox ID="txtBaslik" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-default" runat="server"></asp:TextBox>
                </div>

                <hr />
                <div class="form-group">
                    <label for="comment">
                        <h3><i class="far fa-comment">&nbsp;Mesaj Yaz:</i></h3>
                    </label>
                    <textarea class="form-control" id="comment" rows="5"></textarea>
                </div>
                <asp:Button ID="btnYayinla" class="btn btn-outline-info" runat="server" Text="Gönder" OnClientClick="SetHiddenField()" OnClick="btnYayinla_Click" />
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
