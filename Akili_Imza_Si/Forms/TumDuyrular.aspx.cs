using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.Forms
{
    public partial class TumDuyrular : System.Web.UI.Page
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {

            DateTime dt = DateTime.Today;
            int yil = dt.Year;
            int ay = dt.Month;
            int gun = dt.Day;
            lblTarih.Text = dt.ToShortDateString();
            string id = Session["id"].ToString();
            //Fakulte ve Bölüm Kodunu getir Getir
            int AID = int.Parse(id);
            string[] Bilgi = new string[2];
            var qUsers = ctx.tblUsers;
            var Fakulte = ctx.tblFakultelers;
            var getFakulta =
                from U in qUsers
                join F in Fakulte on U.FakulteKod equals F.Fakulte_Kod
                where (U.Id == AID)
                select new { F.Fakulte_Adi, U.Unvani, U.FakulteKod, U.BolumKod };
            foreach (var i in getFakulta)
            {
                Bilgi[0] = i.FakulteKod;
                Bilgi[1] = i.BolumKod;
            }
            string Fk = Bilgi[0];
            string bk = Bilgi[1];

            var getDuyru =
                   from d in ctx.tblDuyrulars.OrderByDescending(x => x.DİD)
                   where ((d.AkID == id) || d.FakulteKod == Fk || d.BolumKod == bk)
                   select d;

            lisDuyru.DataSource = getDuyru.ToList();
            lisDuyru.DataBind();
        }

        protected void btnkapat_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }
    }
}