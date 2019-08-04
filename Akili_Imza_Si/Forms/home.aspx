<%@ Page Title="" Language="C#" MasterPageFile="~/AkademisyenSa.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Akili_Imza_Si.Forms.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="alert alert-success" role="alert">
        <h4 class="alert-heading">Bilgilendirme</h4>
        <asp:Label ID="labBilgilendirme1" runat="server"></asp:Label>
        <hr>
        <p class="mb-0">
            <asp:Label ID="lablFakulte" runat="server" Text="Label"></asp:Label>
        </p>
    </div>

    <div class="row">
        <div class="col-lg-4 col-md-5 col-sm-8">
            <div class="card text-white bg-primary mb-3" style="max-width: 18rem;">
                <div class="card-header">Akademik Bilgi</div>
                <div class="card-body">
                    <h5 class="card-title">Görevi</h5>
                    <p class="card-text">
                        <asp:Label ID="labAkedemikBilgi" runat="server" Text="Label"></asp:Label>
                    </p>
                </div>
            </div>

        </div>
        <div class="col-lg-8 col-md-8 col-sm-12">

            <div class="card">
                <h5 class="card-header"><i class="far fa-bell">&nbsp;Genel Duyurular</i></h5>
                <div class="card-body">
                    <asp:ListView ID="lisDuyru" runat="server">
                        <ItemTemplate>
                            <li class="list-group-item list-group-item-success"><b><i class="fas fa-check"> Başlık :</i> </b><%# Eval("Baslik") %>&emsp; &emsp; &emsp;<i class="far fa-calendar-alt">  <%# Eval("Tarih") %></i> <i class="fas fa-angle-double-right"></i>
                                <%--<asp:LinkButton ID="linBoku" runat="server">oku </asp:LinkButton>--%>
                                <a href="DuyruDetayi.aspx?dud=<%# Eval("DİD") %>">oku</a>
                            </li>
                        </ItemTemplate>
                    </asp:ListView>
                            
                        
                </div>
                <div class="card-footer text-muted">
                    <i class="far fa-calendar-alt">&nbsp;Tarih : 
                    <asp:Label ID="lblTarih" runat="server"></asp:Label></i>
                    <asp:Button ID="btnkapat" class="btn btn-outline-primary fa-pull-right" runat="server" Text="Tümünü Gör" OnClick="btnkapat_Click"/>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
