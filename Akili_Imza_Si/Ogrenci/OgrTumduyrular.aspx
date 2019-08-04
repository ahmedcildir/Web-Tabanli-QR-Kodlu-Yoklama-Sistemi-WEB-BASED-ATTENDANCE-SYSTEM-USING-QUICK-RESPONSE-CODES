<%@ Page Title="" Language="C#" MasterPageFile="~/OgrenciMastr.Master" AutoEventWireup="true" CodeBehind="OgrTumduyrular.aspx.cs" Inherits="Akili_Imza_Si.Ogrenci.OgrTumduyrular" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <div class="card">
                    <h5 class="card-header"><i class="far fa-bell">&emsp;Duyuru Detayı</i></h5>
                    <div class="card m-lg-auto col-lg-11 col-sm-11 col-md-11">
                        <div class="card-body">
                            <asp:ListView ID="lisDuyru" runat="server">
                                <ItemTemplate>
                                    <li class="list-group-item list-group-item-success"><b><i class="fas fa-check">&nbsp;Başlık :</i> </b>&nbsp;<%# Eval("Baslik") %>&emsp; &emsp; &emsp;<i class="far fa-calendar-alt">&nbsp;<%# Eval("Tarih","{0:dd MMMM yyyy}") %></i> <i class="fas fa-angle-double-right"></i>
                                        <%--<asp:LinkButton ID="linBoku" runat="server">oku </asp:LinkButton>--%>
                                        <a href="OgrDuyrudetayi.aspx?dd=<%# Eval("id") %>&bk=Duyru Detayı">oku</a>
                                    </li>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                    </div>
                    <div class="card-footer text-muted">
                        <i class="far fa-calendar-alt">&nbsp;Tarihi : 
                    <asp:Label ID="lblTarih" runat="server"></asp:Label></i>
                        <asp:Button ID="btnkapat" class="btn btn-outline-primary fa-pull-right" runat="server" Text="Kapat" OnClick="btnkapat_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
