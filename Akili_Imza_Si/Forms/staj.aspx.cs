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
    public partial class staj : System.Web.UI.Page
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                if (!Page.IsPostBack)
                {
                    int id = int.Parse(Session["id"].ToString());
                    var akDersler = ctx.tblAkedimisyen_Al_Dersler;
                    var Dersler = ctx.tblDerslers;
                    var qgetirDers =
                        from akd in akDersler
                        join ders in Dersler on akd.Ders_Kod equals ders.Ders_Kod
                        where (akd.AkedimisyenID == id)
                        select new { DersAd = ders.Ders_Ad, DersKodu = akd.Ders_Kod, DerslikB = akd.Derslik_Ad, DerSaati = ders.Teori_Saati };
                    foreach (var q in qgetirDers)
                    {
                        dropDers.Items.Add(q.DersKodu);
                    }

                    for (int i = 1; i <= 30; i++)
                    {
                        dropGun.Items.Add(i + ".Gün");
                    }
                    dropI_O.Items.Add("Giriş");
                    dropI_O.Items.Add("Çıkş");
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

        protected void btnQrUret_Click(object sender, EventArgs e)
        {
            string Tarih = DateTime.Now.ToShortDateString();
            string derGun = dropGun.SelectedItem.Text;
            string dersI_O = dropI_O.SelectedItem.Text;
            string dersKod = dropDers.SelectedItem.Text;
            //string derslik = dropSinif.SelectedItem.Text;
            if (dropGun.SelectedItem.Text == "Gün Seçiniz.." || dropI_O.SelectedItem.Text == "Seçiniz..")
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
                if (Tek_imza(Ad, Soyad, Tcc, dersI_O, dersKod, "1", derGun))
                {
                    labUyari.Text = "İmza Daha Önce Alınmıştır Lütfen bilgileri Kontrol Ediniz.";
                }
                else
                {
                    Session["QR"] = Sifrele(dersI_O + "," + dersKod + "," + "0"+ "," + derGun);

                    tblAlinan_imza imza = new tblAlinan_imza()
                    {
                        Ad = KisiselBilgi[0],
                        Soyad = KisiselBilgi[1],
                        Tc = KisiselBilgi[2],
                        Ders_Tipi = dersI_O,
                        Ders_Kod = dersKod,
                        Ders_Saat = "1",
                        Ders_Haftasi = derGun,
                        imza_Tarihi = DateTime.Now.ToShortDateString(),
                        imza_Saat = DateTime.Now.ToShortTimeString(),
                        IslenenDersSuresi = 1
                    };
                    ctx.tblAlinan_imza.Add(imza);
                    ctx.SaveChanges();//<--
                    Response.Redirect("BarKode.aspx");

                }

            }
        }
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
    }
}