using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.Ogrenci
{
    public partial class Devamsizlik : System.Web.UI.Page
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["OrgNo"] != null && Session["OgrLogin_onay"].ToString() == "OK")
            {
                string OrgNo = Session["OrgNo"].ToString();

                var getDersK = ctx.tblDersKaydı;
                var getDersler = ctx.tblDerslers;
                var getAlinanDersler =
                    from dk in getDersK
                    join d in getDersler on dk.Ders_Kod equals d.Ders_Kod
                    where (dk.Ogr_No == OrgNo)
                    select new { d.Ders_Kod, d.Teori_Saati, d.Piratik_Saati, d.Ders_Ad, dk.Drs_S_Z, dk.Sinif };

                
                repAlinanDersler.DataSource = getAlinanDersler.ToList();
                repAlinanDersler.DataBind();
               
            }
            else
            {
                Response.Redirect("OgrLogin.aspx");
            }
        }
    }
}