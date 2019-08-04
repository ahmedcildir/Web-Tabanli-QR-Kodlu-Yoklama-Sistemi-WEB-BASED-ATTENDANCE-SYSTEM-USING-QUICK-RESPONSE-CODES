using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.Forms
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        private bool IsvalidUser(string userName, string password)
        {
            imzaSistemiDBContext ctx = new imzaSistemiDBContext();

            var q1 = from p in ctx.tblUsers
                     where p.Kullanici_Adi == userName
                     && p.Password == password
                     select p;

            if (q1.Any())
            {
                var q2 = ctx.tblUsers.Where(x => x.Kullanici_Adi == userName && x.Password == password).FirstOrDefault();
                Session["id"] = q2.Id;

                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            if (IsvalidUser(txtUser.Text, txtPass.Text))
            {
                Session["eMail"] = txtUser.Text;
                Session["Login_onay"] = "OK";

                //HttpCookie cerez = new HttpCookie("YemekSepeti");
                //cerez["eMail"] = txtUser.Text;
                //cerez.Expires = DateTime.Now.AddDays(10);
                //Response.Cookies.Add(cerez);

                Response.Redirect("home.aspx");

            }
            else
            {
                Response.Write("<script> alert('Giriş Başarısız'); </script>");

            }
        }
    }
}