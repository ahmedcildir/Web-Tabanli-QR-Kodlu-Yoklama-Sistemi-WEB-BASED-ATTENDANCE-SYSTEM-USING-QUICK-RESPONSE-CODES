<%@ Page Title="" Language="C#" MasterPageFile="~/OgrenciMastr.Master" AutoEventWireup="true" CodeBehind="OgrAnaSayfa.aspx.cs" Inherits="Akili_Imza_Si.Ogr.OgrAnaSayfa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12 col-md-12 col-sm-12">
        <div class="alert alert-success" role="alert">
            <h4 class="alert-heading">Bilgilendirme</h4>
            <asp:Label ID="labBilgilendirme1" runat="server"></asp:Label>
            <hr>
            <p class="mb-0">
                <asp:Label ID="lablFakulte" runat="server"></asp:Label>
            </p>
        </div>
    </div>
    <div class="col-lg-3 col-md-4 col-sm-12">
        <div class="card text-white bg-primary">
            <div class="card-header">
                <h6>
                    <asp:Label ID="lblAktifDonem" runat="server"></asp:Label></h6>
            </div>
            <hr />
            <div class="card-body">
                <p class="card-title">
                    <asp:Label ID="lblBolum" runat="server" Text="Label"></asp:Label></p>
                <p class="card-text">
                    <asp:Label ID="labAkedemikBilgi" runat="server"></asp:Label>
                </p>
            </div>
        </div>

    </div>
    <div class="col-lg-9 col-md-8 col-sm-12">

        <div class="card">
            <h5 class="card-header"><i class="far fa-bell">&nbsp;Genel Duyurular</i></h5>
            <div class="card-body">
                <asp:ListView ID="lisDuyru" runat="server">
                    <ItemTemplate>
                        <li class="list-group-item list-group-item-success"><b><i class="fas fa-check"> &nbsp;Başlık :</i> &nbsp;<%# Eval("Baslik") %> </b>&emsp; &emsp; &emsp;<i class="far fa-calendar-alt"> &nbsp;<%# Eval("Tarih","{0:dd MMMM yyyy}") %></i>&emsp;<i class="fas fa-angle-double-right"></i>
                            <a href="OgrDuyrudetayi.aspx?dd=<%# Eval("id") %>&bk=Duyru Detayı">oku</a>
                        </li>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            <div class="card-footer text-muted">
                <i class="far fa-calendar-alt">&nbsp;Tarih : 
                    <asp:Label ID="lblTarih" runat="server"></asp:Label></i>
                <asp:Button ID="btnTumDuyrular" class="btn btn-outline-primary fa-pull-right" runat="server" Text="Tümünü Gör" OnClick="btnTumDuyrular_Click" />

            </div>
        </div>
    </div>
</asp:Content>
