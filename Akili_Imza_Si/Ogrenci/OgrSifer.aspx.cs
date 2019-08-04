using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.Ogrenci
{
    public partial class OgrSifer : System.Web.UI.Page
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnYukle_Click(object sender, EventArgs e)
        {
            if (Session["OrgNo"] != null)
            {
                string OrgNo = Session["OrgNo"].ToString();
                if (SifreKontrol(txtEskiSifre.Text))
                {
                    var Sifre = ctx.tblOgr_Ogrenci.First(x => x.Ogr_No == OrgNo);
                    Sifre.Ogr_Password = txtYeniSifrr.Text;
                    ctx.SaveChanges();
                    lblUyari.Text = "Şifre Başarılı Bir Şekilde Güncellendi";
                }
                else
                {
                    lblUyari.Text = "Eski Şifreyi Yanlış Girdiniz..";
                }

            }
            else
            {
                Response.Redirect("OgrLogin.aspx");
            }
            txtEskiSifre.Text = string.Empty;
            txtYeniSifrr.Text = string.Empty;
            txtYeniSifrrTekrar.Text = string.Empty;
        }
        //Şifreyi Kontrol et
        private bool SifreKontrol(string password)
        {
            string OrgNo = Session["OrgNo"].ToString();
            var q1 = from p in ctx.tblOgr_Ogrenci
                     where p.Ogr_No == OrgNo
                     select new { pas = p.Ogr_Password };
            string[] pass = new string[1];
            foreach (var p in q1)
            {
                pass[0] = p.pas;
            }
            if (pass[0] == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}