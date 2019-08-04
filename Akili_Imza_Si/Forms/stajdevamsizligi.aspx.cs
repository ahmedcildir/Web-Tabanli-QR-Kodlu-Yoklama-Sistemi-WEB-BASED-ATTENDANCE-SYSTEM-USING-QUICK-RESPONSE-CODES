using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.Forms
{
    public partial class stajdevamsizligi : System.Web.UI.Page
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var ogr = from o in ctx.tblOgr_Ogrenci
                          where (o.Ogr_OgrenimSekli.Equals("staj"))
                          select new { Ad = o.Ogr_Ad, Soyad = o.Ogr_SoyAd };
                foreach (var og in ogr)
                {
                    dropogr.Items.Add(og.Ad + " " + og.Soyad);
                }
            }
            else
            {

            }

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            //List<string> s = new List<string>();

            string OgrAd_S = dropogr.SelectedItem.Text;
            string[] parcalar = OgrAd_S.Split(' ');
            string ad = parcalar[0];
            string soyad = parcalar[1];
            var ogr = ctx.tblimzalistes.
                    Where(x => x.Ogr_Ad == ad && x.Ogr_Soyad == soyad).ToList();


            repliste.DataSource = ogr;
            repliste.DataBind();

        }
    }
}