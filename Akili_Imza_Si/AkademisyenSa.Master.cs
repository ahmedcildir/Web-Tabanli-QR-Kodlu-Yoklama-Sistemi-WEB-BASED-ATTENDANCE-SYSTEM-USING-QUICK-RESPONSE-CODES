using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.Forms
{
    public partial class AkademisyenSa : System.Web.UI.MasterPage
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (Session["id"]!=null && Session["Login_onay"].ToString() == "OK")
            {
                int id = int.Parse(Session["id"].ToString());
                var qUser = ctx.tblUsers.Where(x => x.Id == id).FirstOrDefault();
                labAdSoyad.Text = " " + qUser.Ad + "  " + qUser.Soyad;
                imFoto.ImageUrl = qUser.Fotograf;
                ////hocanın Ad Soyad Tc Bilgilerini al ve dizilere aktar-->
                //string[] foto = new string[1];

                //var fot = from f in ctx.tblUsers where (f.Id == id) select new { fotograf = f.Fotograf};
                //foreach (var qf in fot)
                //{
                //    foto[0] = qf.fotograf.ToString();

                //}//<--


            }
            else
            {
                Response.Redirect("Login.aspx");
            }
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Login_onay"] = "No";
            Response.Redirect("Login.aspx");
        }
    }
}