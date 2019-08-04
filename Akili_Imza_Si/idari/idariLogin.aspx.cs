using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.idari
{
    public partial class idariLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            if (IsvalidUser(txtUser.Text, txtPass.Text))
            {
                //Session["eMail"] = txtUser.Text;
                Session["Login_onay1"] = "OK";

                Response.Redirect("idarihome.aspx");

            }
            else
            {
                Response.Write("<script> alert('Giriş Başarısız'); </script>");

            }
        }


        private bool IsvalidUser(string userName, string password)
        {
            imzaSistemiDBContext ctx = new imzaSistemiDBContext();

            var q1 = from p in ctx.tbIdariPersonels
                     where p.Kullanici_Ad == userName
                     && p.Password == password
                     select p;

            if (q1.Any())
            {
                var q2 = ctx.tbIdariPersonels.Where(x => x.Kullanici_Ad == userName && x.Password == password).FirstOrDefault();
                Session["iid"] = q2.PID;

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}