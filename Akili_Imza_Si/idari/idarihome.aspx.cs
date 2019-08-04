using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.idari
{
    public partial class idarihome : System.Web.UI.Page
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {

            DateTime dt = DateTime.Today;
            int yil = dt.Year;
            int ay = dt.Month;
            int gun = dt.Day;
            DateTime BirYilOncesi = DateTime.Now.AddYears(-1);
            DateTime BirYilSonrasi = DateTime.Now.AddYears(1);
            String TarihOnce = BirYilOncesi.Year.ToString();
            String TarihSonra = BirYilSonrasi.Year.ToString();
            if (ay >= 2 && ay < 7)
            {
                labBilgilendirme1.Text = TarihOnce + "-" + yil + " BAHAR DÖNEMİ.";
            }
            else if ((ay >= 9 && ay <= 12))
            {
                labBilgilendirme1.Text = yil + "-" + TarihSonra + " GÜZ DÖNEMİ.";
            }
            else if (ay < 2)
            {
                labBilgilendirme1.Text = TarihOnce + "-" + yil + " GÜZ DÖNEMİ.";
            }
            else
            {
                labBilgilendirme1.Text = "Yaz Dönemi.";
            }

            //Fakulte bilgisini Getir
            if (Session["iid"] != null)
            {
                int id = int.Parse(Session["iid"].ToString());
                var qidariUsers = ctx.tbIdariPersonels;
                var Fakulte = ctx.tblFakultelers;
                var getFakulta =
                    from U in qidariUsers
                    join F in Fakulte on U.FakulteKod equals F.Fakulte_Kod
                    where (U.PID == id)
                    select new { F.Fakulte_Adi,U.Gorev };
                foreach (var i in getFakulta)
                {
                    lblFakulte.Text = i.Fakulte_Adi+" / "+i.Gorev;
                }
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}