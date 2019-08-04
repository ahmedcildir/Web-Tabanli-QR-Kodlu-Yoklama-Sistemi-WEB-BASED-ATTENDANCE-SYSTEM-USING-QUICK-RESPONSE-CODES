using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.Ogrenci
{
    public partial class OgrAlinanDersler : System.Web.UI.Page
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["OrgNo"] != null && Session["OgrLogin_onay"].ToString() == "OK")
            {
                string OrgNo = Session["OrgNo"].ToString();

                var getDersK = ctx.tblDersKaydı;
                var getDersler = ctx.tblDerslers;
                var getFakulta =
                    from dk in getDersK
                    join d in getDersler on dk.Ders_Kod equals d.Ders_Kod
                    where (dk.Ogr_No== OrgNo)
                    select new { d.Ders_Kod, d.Teori_Saati,d.Piratik_Saati,d.Ders_Ad,dk.Drs_S_Z,dk.Sinif };

                repAlinanDersler.DataSource = getFakulta.ToList();
                repAlinanDersler.DataBind();


                //var getAlinandersler =
                //from ad in ctx.tblDersKaydı
                //where (ad.Ogr_No == OrgNo)
                //select (new { ad.Ogr_No, ad.Ogr_Ad, ad.Ogr_Soyad, ad.Drs_S_Z });

                //repAlinanDersler.DataSource = getAlinandersler.ToList();
                //repAlinanDersler.DataBind();
            }
            else
            {
                Response.Redirect("OgrLogin.aspx");
            }
        }
    }
}