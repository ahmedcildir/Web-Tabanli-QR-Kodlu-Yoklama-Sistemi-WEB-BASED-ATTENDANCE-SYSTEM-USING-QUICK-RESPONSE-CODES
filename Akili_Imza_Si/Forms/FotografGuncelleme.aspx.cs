using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.Forms
{
    public partial class FotografGuncelleme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            imzaSistemiDBContext ctx = new imzaSistemiDBContext();
            if (Session["id"]!=null)
            {
                int id = int.Parse(Session["id"].ToString());
                if (resimyukle.HasFile)
                {
                    string fileName = resimyukle.FileName;
                    Guid G = Guid.NewGuid();
                    string yol = G + "-u-" + resimyukle.FileName;
                    Image1.ImageUrl = "~/Forms/images/" + yol;
                    resimyukle.SaveAs(Server.MapPath("~/Forms/images/" + yol));

                    var resim = ctx.tblUsers.First(x => x.Id == id);
                    resim.Fotograf = "~/Forms/images/" + yol;
                    ctx.SaveChanges();
                }
                else
                {
                    Response.Write("Lütfen Yüklenecek Bir Resim Seçiniz.");
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            
           
        }
    }
}