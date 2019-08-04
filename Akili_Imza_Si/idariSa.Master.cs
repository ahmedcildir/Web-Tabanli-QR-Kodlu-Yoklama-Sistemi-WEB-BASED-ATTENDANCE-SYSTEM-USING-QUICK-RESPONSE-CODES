using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si
{
    public partial class idariSa : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.Form.DefaultButton = btnVisible.UniqueID;

            imzaSistemiDBContext ctx = new imzaSistemiDBContext();
            if (Session["iid"] != null && Session["Login_onay1"].ToString() == "OK")
            {
                int id = int.Parse(Session["iid"].ToString());
                var qUser = ctx.tbIdariPersonels.Where(x => x.PID == id).FirstOrDefault();
                labAdSoyad.Text = " " + qUser.Ad + "  " + qUser.Soyad;

                //hocanın Ad Soyad Tc Bilgilerini al ve dizilere aktar-->
                string[] foto = new string[1];

                var fot = from f in ctx.tbIdariPersonels where (f.PID == id) select new { fotograf = f.Fotograf };
                foreach (var qf in fot)
                {
                    foto[0] = qf.fotograf.ToString();

                }//<--
                imFoto.ImageUrl = foto[0];

            }
            else
            {
                Response.Redirect("idariLogin.aspx");
            }
        }

        protected void cikis_Click(object sender, EventArgs e)
        {
            Session["Login_onay1"] = "No";
            Response.Redirect("idariLogin.aspx");
        }

        protected void btnVisible_Click(object sender, EventArgs e)
        {

        }
    }
}