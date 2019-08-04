using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si
{
    public partial class anasayfa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAkademik_Click(object sender, EventArgs e)
        {
            Response.Redirect("Forms/Login.aspx");
        }

        protected void btnidari_Click(object sender, EventArgs e)
        {
            Response.Redirect("idari/idariLogin.aspx");
        }

        protected void btnOgrenci_Click(object sender, EventArgs e)
        {
            HttpCookie cerez = Request.Cookies["Mac"];
            if (cerez != null)
            {
                Response.Redirect("Ogrenci/OgrLogin.aspx");
            }
            else
            {
                Response.Redirect("Ogrenci/oisk.aspx");
            }
        }
    }
}