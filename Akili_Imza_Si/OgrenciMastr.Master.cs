using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si
{
    public partial class OgrenciMastr : System.Web.UI.MasterPage
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["OrgNo"] != null && Session["OgrLogin_onay"].ToString() == "OK")
            {
                string bk = Request.QueryString["bk"];
                baslik.InnerHtml = bk;
                string OrgNo = Session["OrgNo"].ToString();
                var ogrAS = ctx.tblOgr_Ogrenci.Where(x => x.Ogr_No == OrgNo).FirstOrDefault();
                //AdSoyad.InnerHtml= ogrAS.Ogr_Ad + "  " + ogrAS.Ogr_SoyAd;
                labAdSoyad.Text = " " + ogrAS.Ogr_Ad + "  " + ogrAS.Ogr_SoyAd;
                imFoto.ImageUrl = ogrAS.Ogr_Fotograf;
                imFoto1.ImageUrl = ogrAS.Ogr_Fotograf;
             
            }
            else
            {
                Response.Redirect("OgrLogin.aspx");
            }
        }
    }
}