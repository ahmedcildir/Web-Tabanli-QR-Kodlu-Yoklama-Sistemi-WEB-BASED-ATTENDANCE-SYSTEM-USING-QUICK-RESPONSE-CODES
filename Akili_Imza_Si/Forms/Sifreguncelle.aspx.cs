using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.Forms
{
    public partial class Sifreguncelle : System.Web.UI.Page
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnYukle_Click(object sender, EventArgs e)
        {
            
            if (Session["id"] != null)
            {
                int id = int.Parse(Session["id"].ToString());
                if (IsvalidUser(txtEskiSifre.Text))
                {
                    var Sifre = ctx.tblUsers.First(x => x.Id == id);
                    Sifre.Password =txtYeniSifrr.Text;
                    ctx.SaveChanges();
                    
                    Response.Write("<script> alert('Şifre Başarılı Bir Şekilde Güncellendi');</script>");
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
            txtEskiSifre.Text = string.Empty;
            txtYeniSifrr.Text = string.Empty;
            txtYeniSifrrTekrar.Text = string.Empty;
        }
            private bool IsvalidUser(string password)
            {

                int id = int.Parse(Session["id"].ToString());
                var q1 = from p in ctx.tblUsers
                         where p.Id == id select new { pas = p.Password };
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