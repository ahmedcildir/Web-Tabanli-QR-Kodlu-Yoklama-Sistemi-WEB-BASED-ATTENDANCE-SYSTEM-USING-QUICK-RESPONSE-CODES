<%@ Page Title="" Language="C#" MasterPageFile="~/idariSa.Master" AutoEventWireup="true" CodeBehind="idarihome.aspx.cs" Inherits="Akili_Imza_Si.idari.idarihome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="alert alert-success" role="alert">
        <h4 class="alert-heading">Bilgilendirme</h4>
        <asp:Label ID="labBilgilendirme1" runat="server"></asp:Label>
        <hr>
        <p class="mb-0">
            <asp:Label ID="lblFakulte" runat="server" Text="Label"></asp:Label>
        </p>
    </div>

    <div class="row">
        <div class="col-lg-4 col-md-5 col-sm-8">
            <div class="card text-white bg-primary mb-3" style="max-width: 18rem;">
                <div class="card-header">Takvim</div>
                <div class="card-body">
                    <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#3366CC" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" OnSelectionChanged="Calendar1_SelectionChanged" Width="220px" BorderWidth="1px" CellPadding="1">
                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#009999" ForeColor="#CCFF99" Font-Bold="True" />
                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                        <TitleStyle BackColor="#003399" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" BorderColor="#3366CC" BorderWidth="1px" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                        <WeekendDayStyle BackColor="#CCCCFF" />
                    </asp:Calendar>
                </div>
            </div>

        </div>
        <div class="col-lg-8 col-md-8 col-sm-12">
            <div class="list-group">
                <a href="#" class="list-group-item list-group-item-action active">
                    <h5>Genel Duyurular</h5>
                </a>
                <a href="#" class="list-group-item list-group-item-action">
                    <div class="alert alert-info alert-dismissible fade show">
                        <button type="button" class="close" data-dismiss="alert">&times;</button>
                        <strong>Duyru!</strong> Nottt.
                    </div>
                </a>
            </div>
        </div>
    </div>
        <img src="images/siu4.png" />
</asp:Content>
