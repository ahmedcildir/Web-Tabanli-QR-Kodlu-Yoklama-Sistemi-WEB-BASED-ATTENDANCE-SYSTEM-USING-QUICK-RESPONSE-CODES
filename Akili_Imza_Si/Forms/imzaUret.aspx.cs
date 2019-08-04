using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.Forms
{
    public partial class imzaUret : System.Web.UI.Page
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        //List<string> Ders_Kod1 = new List<string>();
        //var qAlinanDer = ctx.tblAkedimisyen_Al_Dersler.Where(x=>x.AkedimisyenID==id).Select(x => x.Ders_Kod);
        //var Ders = from d in ctx.tblAkedimisyen_Al_Dersler where(d.AkedimisyenID == id) select(new { d.Ders_Kod, d.id });
        //var Ders = from d in ctx.tblAkedimisyen_Al_Dersler where (d.AkedimisyenID == id) select d.Ders_Kod;
        //var DerslikAd = from d in ctx.tblAkedimisyen_Al_Dersler where (d.AkedimisyenID == id) select d.Derslik_Ad;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                if (!Page.IsPostBack)
                {
                    int id = int.Parse(Session["id"].ToString());
                    /*barkod oluşturmada kulanılan bilgileri veritabanından 
                      getir iki tablo birleştirme-->*/
                    var akDersler = ctx.tblAkedimisyen_Al_Dersler;
                    var Dersler = ctx.tblDerslers;
                    var qgetirDers =
                        from akd in akDersler
                        join ders in Dersler on akd.Ders_Kod equals ders.Ders_Kod
                        where (akd.AkedimisyenID == id)
                        select new { DersAd = ders.Ders_Ad, DersKodu = akd.Ders_Kod, DerslikB = akd.Derslik_Ad, DerSaati = ders.Teori_Saati };

                    dropDers.Items.Insert(0, new ListItem("Ders Seçiniz..", "0"));
                    dropPT.Items.Insert(0, new ListItem("Ders Tipi..", "0"));
                    dropPT.Items.Insert(1, new ListItem("Teorik", "1"));
                    dropPT.Items.Insert(2, new ListItem("Uygulamalı", "2"));

                    foreach (var q in qgetirDers)
                    {
                        dropDers.Items.Add(q.DersKodu);
                    }

                    dropSaat.Items.Add("Tek İmza");
                    dropSaat.Items.Add("1.Ders");
                    dropSaat.Items.Add("2.Ders");
                    dropSaat.Items.Add("3.Ders");
                    dropSaat.Items.Add("4.Ders");

                    for (int i = 1; i <= 14; i++)
                    {
                        dropHafta.Items.Add(i + ".Hafta");
                    }
                }
                else
                {
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        //Buton-->
        protected void btnQrUret_Click(object sender, EventArgs e)
        {
            string dersTP = dropPT.SelectedItem.Text;
            string dersKod = dropDers.SelectedItem.Text;
            string saat = dropSaat.SelectedItem.Text;
            string hafta = dropHafta.SelectedItem.Text;
            //string derslik = dropSinif.SelectedItem.Text;
            if (dropDers.SelectedItem.Text == "Der Seçiniz.." || dropHafta.SelectedItem.Text == "Haftayı Seçiniz.." || dropSaat.SelectedItem.Text == "Saat Seçiniz.." || dropPT.SelectedItem.Text == "Ders Tipi..")
            {
                labUyari.Text = "Lütfen İlgili Seçenekleri Seçiniz.";
            }
            else
            {
                //hocanın Ad Soyad Tc Bilgilerini al ve dizilere aktar-->
                string[] KisiselBilgi = new string[3];
                //string[] soyad = new string[1];
                //string[] tc = new string[1];
                int id = int.Parse(Session["id"].ToString());
                var Kul = from k in ctx.tblUsers where (k.Id == id) select new { Ad = k.Ad, Soyad = k.Soyad, Tc = k.Tc };
                foreach (var qk in Kul)
                {
                    KisiselBilgi[0] = qk.Ad.ToString();
                    KisiselBilgi[1] = qk.Soyad.ToString();
                    KisiselBilgi[2] = qk.Tc.ToString();
                }//<--
                string Ad = KisiselBilgi[0];
                string Soyad = KisiselBilgi[1];
                string Tcc = KisiselBilgi[2];
                if (Tek_imza(Ad, Soyad, Tcc, dersTP, dersKod, saat, hafta))
                {
                    labUyari.Text = "İmza Daha Önce Alınmıştır Lütfen bilgileri Kontrol Ediniz.";
                }
                else
                {
                    //Şifrelenmiş Veeriyi Barkod.aspx sayfasına gönder-->
                    Session["QR"] = Sifrele(dersTP + "," + dersKod + "," + saat + "," + hafta);//<--
                                                                                               //hoca imza oluşturduğu zaman billgileri veri Tabanıa tblimzaliste isimli tabloya bilgileri ekle-->
                    tblAlinan_imza imza = new tblAlinan_imza()
                    {
                        Ad = KisiselBilgi[0],
                        Soyad = KisiselBilgi[1],
                        Tc = KisiselBilgi[2],
                        Ders_Tipi = dersTP,
                        Ders_Kod = dersKod,
                        Ders_Saat = saat,
                        Ders_Haftasi = hafta,
                        imza_Tarihi = DateTime.Now.ToShortDateString(),
                        imza_Saat = DateTime.Now.ToShortTimeString(),
                        IslenenDersSuresi = imzaToplamSaat(dersKod, dersTP, saat)
                    };
                    ctx.tblAlinan_imza.Add(imza);
                    ctx.SaveChanges();//<--
                    Response.Redirect("BarKode.aspx");

                }
            }



        }//<--

        //Cümledeki Boşlukları Silme metodu-->
        public static string BoslukSil(string sil)
        {
            return sil.Trim().Replace(" ", string.Empty);
        }//<--


        //ders saatine göre dropSaat i Doldurma-->
        /* //protected void dropDers_SelectedIndexChanged2(object sender, EventArgs e)
         {
             //int y = 1;
            // int id = int.Parse(Session["id"].ToString());
             dropSaat.Items.Clear();
             int i = Int32.Parse(dropDers.SelectedItem.Value);
             dropSaat.Items.Insert(0, new ListItem("Saat Seçiniz..", "0"));
             if (i == 1)
             {
                 dropSaat.Items.Insert(1, new ListItem("Tek İmza", "1"));
                 dropSaat.Items.Insert(2, new ListItem("1.Ders", "2"));

             }
             else if (i == 2)
             {
                 dropSaat.Items.Insert(1, new ListItem("Tek İmza", "1"));
                 dropSaat.Items.Insert(2, new ListItem("1.Ders", "2"));
                 dropSaat.Items.Insert(3, new ListItem("2.Ders", "3"));
             }
             else if (i == 3)
             {
                 dropSaat.Items.Insert(1, new ListItem("Tek İmza", "1"));
                 dropSaat.Items.Insert(2, new ListItem("1.Ders", "2"));
                 dropSaat.Items.Insert(3, new ListItem("2.Ders", "3"));
                 dropSaat.Items.Insert(4, new ListItem("3.Ders", "5"));
             }
             else if (i == 4)
             {
                 dropSaat.Items.Insert(1, new ListItem("Tek İmza", "1"));
                 dropSaat.Items.Insert(2, new ListItem("1.Ders", "2"));
                 dropSaat.Items.Insert(3, new ListItem("2.Ders", "3"));
                 dropSaat.Items.Insert(4, new ListItem("3.Ders", "4"));
                 dropSaat.Items.Insert(5, new ListItem("4.Ders", "5"));
             }
             else if (i == 5)
             {
                 dropSaat.Items.Insert(1, new ListItem("Tek İmza", "1"));
                 dropSaat.Items.Insert(2, new ListItem("1.Ders", "2"));
                 dropSaat.Items.Insert(3, new ListItem("2.Ders", "3"));
                 dropSaat.Items.Insert(4, new ListItem("3.Ders", "4"));
                 dropSaat.Items.Insert(5, new ListItem("4.Ders", "5"));
                 dropSaat.Items.Insert(6, new ListItem("5.Ders", "6"));

             }
             else if (i == 6)
             {
                 dropSaat.Items.Insert(1, new ListItem("Tek İmza", "1"));
                 dropSaat.Items.Insert(2, new ListItem("1.Ders", "2"));
                 dropSaat.Items.Insert(3, new ListItem("2.Ders", "3"));
                 dropSaat.Items.Insert(4, new ListItem("3.Ders", "4"));
                 dropSaat.Items.Insert(5, new ListItem("4.Ders", "5"));
                 dropSaat.Items.Insert(6, new ListItem("5.Ders", "6"));
                 dropSaat.Items.Insert(7, new ListItem("6.Ders", "7"));
             }
             else
             {

             }
         }*/

        //QR kodu Şifreleme
        public string hash = "AhmedÇILDIR";
        public string Sifrele(string sifre)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(sifre);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }

        //İmzanın daha Önce alınıp Alınmadığını Kontrol et
        private bool Tek_imza(string Ad, string Soyad, string Tc, string DersTipi, string DersKod, string DersSaati, string DersHafta)
        {

            var q1 = from p in ctx.tblAlinan_imza
                     where p.Ad == Ad
                     && p.Soyad == Soyad && p.Tc == Tc
                     && p.Ders_Tipi == DersTipi && p.Ders_Kod == DersKod
                     && p.Ders_Saat == DersSaati && p.Ders_Haftasi == DersHafta
                     select p;

            if (q1.Any())
            {

                return true;
            }
            else
            {
                return false;
            }
        }


        //Ders Saatini Getir
        private int imzaToplamSaat(string dersKodu, string DersTipi, string DersSaati)
        {
            var getSaat = from s in ctx.tblDerslers
                          where (s.Ders_Kod == dersKodu)
                          select s;
            string[] st = new string[2];
            foreach (var i in getSaat)
            {
                st[0] = i.Teori_Saati;
                st[1] = i.Piratik_Saati;
            }
            if (DersTipi.Equals("Teorik") && DersSaati.Equals("Tek İmza"))
            {
                return int.Parse(st[0]);
            }
            else if (DersTipi.Equals("Uygulamalı") && DersSaati.Equals("Tek İmza"))
            {
                return int.Parse(st[1]);
            }
            else
            {
                return 1;
            }
        }

    }
}