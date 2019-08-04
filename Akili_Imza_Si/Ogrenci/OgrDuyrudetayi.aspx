<%@ Page Title="" Language="C#" MasterPageFile="~/OgrenciMastr.Master" AutoEventWireup="true" CodeBehind="OgrDuyrudetayi.aspx.cs" Inherits="Akili_Imza_Si.Ogrenci.OgrDuyrudetayi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <div class="card">
                    <h5 class="card-header"><i class="far fa-bell">&emsp;Duyuru Detayı</i></h5>
                    <div class="card m-lg-auto col-lg-11 col-sm-11 col-md-11">
                        <div class="card-body">
                            <ul class="list-group">
                                <li class="list-group-item list-group-item-success">
                                    <h3><i class="fas fa-check">Başlık</i> <i class="fas fa-angle-double-right">
                                        <asp:label id="lblBaslik" runat="server" text="Label"></asp:label>
                                    </i>
                                    </h3>
                                </li>
                            </ul>
                            <hr />
                            <hr />
                            <ul class="list-group">
                                <li class="list-group-item list-group-item-dark"><i class="fas fa-check">Mesaj :</i>
                                    <asp:label id="lblmesaj" runat="server" text="Label"></asp:label>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="card-footer text-muted">
                        <i class="far fa-calendar-alt">&nbsp;Tarihi : 
                    <asp:label id="lblTarih" runat="server"></asp:label>
                        </i>
                        <asp:button id="btnkapat" class="btn btn-outline-primary fa-pull-right" runat="server" text="Kapat" OnClick="btnkapat_Click" />

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
