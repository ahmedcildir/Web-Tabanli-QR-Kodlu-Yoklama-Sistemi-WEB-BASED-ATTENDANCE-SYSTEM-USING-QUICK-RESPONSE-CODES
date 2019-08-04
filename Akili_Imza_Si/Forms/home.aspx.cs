using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.Forms
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                int id = int.Parse(Session["id"].ToString());

                //Ders Sayısını Getir
                var DersSayisi = from d in ctx.tblAkedimisyen_Al_Dersler
                                 where d.AkedimisyenID == id
                                 select d.Ders_Kod;
                //Dönem Ayarlama
                DateTime dt = DateTime.Today;
                int yil = dt.Year;
                int ay = dt.Month;
                int gun = dt.Day;
                lblTarih.Text = dt.ToShortDateString();
                DateTime BirYilOncesi = DateTime.Now.AddYears(-1);
                DateTime BirYilSonrasi = DateTime.Now.AddYears(1);
                String TarihOnce = BirYilOncesi.Year.ToString();
                String TarihSonra = BirYilSonrasi.Year.ToString();
                if (ay >= 2 && ay < 7)
                {
                    labBilgilendirme1.Text = TarihOnce + "-" + yil + " BAHAR DÖNEMİ Döneminde " + DersSayisi.Count() + " Ders Kaydınız Mevcuttur.";
                }
                else if ((ay >= 9 && ay <= 12))
                {
                    labBilgilendirme1.Text = yil + "-" + TarihSonra + " GÜZ DÖNEMİ Döneminde " + DersSayisi.Count() + " Ders Kaydınız Mevcuttur.";
                }
                else if (ay < 2)
                {
                    labBilgilendirme1.Text = TarihOnce + "-" + yil + " GÜZ DÖNEMİ Döneminde " + DersSayisi.Count() + " Ders Kaydınız Mevcuttur.";
                }
                else
                {
                    labBilgilendirme1.Text = "Kayıt Bulunmamaktadır";
                }

                //Fakulte ve Unvanı Getir
                string[] Bilgi = new string[2];
                var qUsers = ctx.tblUsers;
                var Fakulte = ctx.tblFakultelers;
                var getFakulta =
                    from U in qUsers
                    join F in Fakulte on U.FakulteKod equals F.Fakulte_Kod
                    where (U.Id == id)
                    select new { F.Fakulte_Adi, U.Unvani, U.FakulteKod, U.BolumKod };
                foreach (var i in getFakulta)
                {
                    Bilgi[0] = i.FakulteKod;
                    Bilgi[1] = i.BolumKod;
                    lablFakulte.Text = i.Fakulte_Adi;
                    labAkedemikBilgi.Text = i.Unvani;
                }


                //Duyruları getir
                //string DuyruGun = (gun + 5).ToString();
                string Fk = Bilgi[0];
                string bk = Bilgi[1];
                //var getDuyru1 =
                //    from d in ctx.tblDuyrulars.OrderByDescending(x => x.DİD).Take(3)
                //    where (())
                //    select d;
                //lisDuyru.DataSource = getDuyru1.ToList();
                //lisDuyru.DataBind();

                var getDuyru =
                    from d in ctx.tblDuyrulars.OrderByDescending(x => x.DİD).Take(3)
                    where ((d.AkID == id.ToString())|| d.FakulteKod == Fk||d.BolumKod==bk)
                    select d;



                lisDuyru.DataSource = getDuyru.ToList();
                lisDuyru.DataBind();
            }
        }

        protected void linBoku_Click(object sender, EventArgs e)
        {

            //int id = 
            //var getDuyru = from d in ctx.tblDuyrulars
            //               where ((d.DİD ==id ))
            //               select d;
            //Response.Write("<script> alert('id sd'); </script>");
        }

        protected void btnkapat_Click(object sender, EventArgs e)
        {
            Response.Redirect("TumDuyrular.aspx");
        }
    }
}