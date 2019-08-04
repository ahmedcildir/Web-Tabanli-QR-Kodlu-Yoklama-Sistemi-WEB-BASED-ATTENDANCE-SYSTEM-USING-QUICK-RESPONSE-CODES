using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.Ogr
{
    public partial class OgrAnaSayfa : System.Web.UI.Page
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["OrgNo"] != null && Session["OgrLogin_onay"].ToString() == "OK")
            {
                string OrgNo = Session["OrgNo"].ToString();
                //Ders Sayısını Getir
                var DersSayisi = from d in ctx.tblDersKaydı
                                 where d.Ogr_No == OrgNo
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
                    labBilgilendirme1.Text = TarihOnce + "-" + yil + " BAHAR DÖNEMİ Döneminde " + DersSayisi.Count() + " Adet Onaylanmış Ders Kaydınız Mevcuttur.";
                    lblAktifDonem.Text= "Aktif Dönem: " + TarihOnce + "-" + yil + " BAHAR DÖNEMİ";
                }
                else if ((ay >= 9 && ay <= 12))
                {
                    labBilgilendirme1.Text = yil + "-" + TarihSonra + " GÜZ DÖNEMİ Döneminde " + DersSayisi.Count() + " Adet Onaylanmış Ders Kaydınız Mevcuttur.";
                    lblAktifDonem.Text = "Aktif Dönem: " + yil + "-" + TarihSonra + " BAHAR DÖNEMİ";
                }
                else if (ay < 2)
                {
                    labBilgilendirme1.Text = TarihOnce + "-" + yil + " GÜZ DÖNEMİ Döneminde " + DersSayisi.Count() + " Adet Onaylanmış Ders Kaydınız Mevcuttur.";
                    lblAktifDonem.Text = "Aktif Dönem: " + TarihOnce + "-" + yil + " BAHAR DÖNEMİ";
                }
                else
                {
                    labBilgilendirme1.Text = "Kayıt Bulunmamaktadır";
                    lblAktifDonem.Text = "Aktif Dönem:";
                }

                //Dönem Fakulte Ve Sınıf Bilgileri
                string[] Bilgi = new string[2];
                var qOgr = ctx.tblOgr_Ogrenci;
                var Fakulte = ctx.tblFakultelers;
                var getFakulta =
                    from O in qOgr
                    join F in Fakulte on O.Ogr_Fakulte equals F.Fakulte_Kod
                    where (O.Ogr_No == OrgNo)
                    select new { F.Fakulte_Adi, O.Ogr_Fakulte, O.Ogr_Program,O.Ogr_Sinif };
                foreach (var i in getFakulta)
                {
                    Bilgi[0] = i.Ogr_Fakulte;
                    Bilgi[1] = i.Ogr_Program;
                    lablFakulte.Text = i.Fakulte_Adi;
                    labAkedemikBilgi.Text = i.Ogr_Sinif+".Sınıf";
                }

                //Bölümü Getir
                string BolumKodu = Bilgi[1];
                var getBolum = from b in ctx.tblBolumlers
                               where (b.Bolum_Kod == BolumKodu)
                               select new { b.Bolum_Ad };
                foreach (var b in getBolum)
                {
                    lblBolum.Text = b.Bolum_Ad;
                }


                //ogr Aldığı Dersler
                List<string> dk = new List<string>();
                var getDersler = from dr in ctx.tblDersKaydı
                                 where (dr.Ogr_No == OrgNo)
                                 select new { dr.Ders_Kod };
                foreach (var d_k in getDersler)
                {
                    dk.Add(d_k.Ders_Kod);
                   
                }
               
                List<tblOgr_Duyrular> lst = new List<tblOgr_Duyrular>();
                List<tblOgr_Duyrular> lst2 = duyruMesaj(OrgNo);
                foreach (tblOgr_Duyrular item in lst2)
                {
                    lst.Add(item);
                }
                for (int i = 0; i < dk.Count(); i++)
                {
                    List<tblOgr_Duyrular> lst3 = duyruMesajDK(dk[i]);
                    foreach (tblOgr_Duyrular item in lst3)
                    {
                        lst.Add(item);
                    }
                }

                lisDuyru.DataSource = lst;
                lisDuyru.DataBind();
            }
            else
            {

            }
        }
        //Duyruları Getir
        private List<tblOgr_Duyrular> duyruMesaj(string OgrNo)
        {
            var getDuyru = ctx.tblOgr_Duyrular.OrderByDescending(x => x.Tarih).Take(2).Where(x => x.OgrNo == OgrNo).ToList();
            return getDuyru.ToList();
        }
        private List<tblOgr_Duyrular> duyruMesajDK(string DK)
        {
            var getDuyru = ctx.tblOgr_Duyrular.OrderByDescending(x => x.Tarih).Take(2).Where(x => x.DersKod == DK).ToList();
            return getDuyru.ToList();
        }

        protected void btnTumDuyrular_Click(object sender, EventArgs e)
        {
            Response.Redirect("OgrTumduyrular.aspx?bk=Tüm Duyrular");
        }
    }
}