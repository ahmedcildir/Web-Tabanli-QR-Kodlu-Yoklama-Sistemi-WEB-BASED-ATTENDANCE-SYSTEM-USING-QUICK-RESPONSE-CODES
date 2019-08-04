using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.idari
{
    public partial class idariSifreGuncelleme : System.Web.UI.Page
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //Şifreyi Güncelle
        protected void btnYukle_Click(object sender, EventArgs e)
        {
            if (Session["iid"] != null)
            {
                int id = int.Parse(Session["iid"].ToString());
                if (IsvalidUser(txtEskiSifre.Text))
                {
                    var Sifre = ctx.tbIdariPersonels.First(x => x.PID == id);
                    Sifre.Password = txtYeniSifrr.Text;
                    ctx.SaveChanges();

                    Response.Write("<script> alert('Şifre Başarılı Bir Şekilde Güncellendi');</script>");
                    txtEskiSifre.Text = string.Empty;
                    txtYeniSifrr.Text = string.Empty;
                    txtYeniSifrrTekrar.Text = string.Empty;
                }
                else
                {
                    Response.Write("<script>alert('Eski Şifreyi Yanlış Girdiniz..');</script>");
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            
        }

        //Eski Şifreyi Kontrol Etme
        private bool IsvalidUser(string password)
        {

            int id = int.Parse(Session["iid"].ToString());
            var q1 = from p in ctx.tbIdariPersonels
                     where p.PID == id
                     select new { pas = p.Password };
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