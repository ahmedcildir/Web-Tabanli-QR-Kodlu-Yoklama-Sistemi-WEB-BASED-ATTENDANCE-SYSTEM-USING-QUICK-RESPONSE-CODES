using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.Ogrenci
{
    public partial class OgrLogin : System.Web.UI.Page
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["OgrLogin_onay"] = "No";
        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            HttpCookie cerez = Request.Cookies["Mac"];
            if (cerez != null)
            {
                string Mac = cerez["MacAddress"];
                if (gecerliKullanici(txtUser.Text, txtPass.Text, Mac))
                {
                    Session["OgrLogin_onay"] = "OK";
                    Response.Redirect("OgrAnaSayfa.aspx?bk=Siirt Üniversitesi");
                }
                else
                {
                    Response.Write("<script> alert('Giriş Başarısız'); </script>");

                }
            }
            else
            {
                Response.Redirect("Ogrenci/oisk.aspx");
            }
        }
        private bool gecerliKullanici(string userName, string password, string Mac)
        {

            var Ogrenci = from Ogr in ctx.tblOgr_Ogrenci
                     where Ogr.Ogr_No == userName
                     && Ogr.Ogr_Password == password&&Ogr.Ogr_MacAddres==Mac
                     select Ogr;

            if (Ogrenci.Any())
            {
                var q1 = ctx.tblOgr_Ogrenci.Where(x => x.Ogr_No == userName && x.Ogr_Password == password && x.Ogr_MacAddres == Mac).FirstOrDefault();
                Session["OrgNo"] = q1.Ogr_No;

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}