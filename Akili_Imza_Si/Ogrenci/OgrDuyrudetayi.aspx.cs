using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.Ogrenci
{
    public partial class OgrDuyrudetayi : System.Web.UI.Page
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            string deger = Request.QueryString["dd"];
            int id = int.Parse(deger);
            var getDuyru =
                   from d in ctx.tblOgr_Duyrular
                   where ((d.id == id))
                   select d;
            //List<string> duyry = new List<string>();
            foreach (var i in getDuyru)
            {
                lblBaslik.Text = i.Baslik;
                lblmesaj.Text = i.Mesaj;
                lblTarih.Text = i.Tarih.ToString();
            }
        }

        protected void btnkapat_Click(object sender, EventArgs e)
        {
            Response.Redirect("OgrAnaSayfa.aspx?bk=Siirt Üniversitesi");
        }
    }
}