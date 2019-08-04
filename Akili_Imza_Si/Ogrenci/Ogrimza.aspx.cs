using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.Ogrenci
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["OrgNo"] != null && Session["OgrLogin_onay"].ToString() == "OK")
            {
                string OrgNo = Session["OrgNo"].ToString();
                var ogrAS = ctx.tblOgr_Ogrenci.Where(x => x.Ogr_No == OrgNo).FirstOrDefault();

                labAdSoyad.Text = " " + ogrAS.Ogr_Ad + "  " + ogrAS.Ogr_SoyAd;
                imFoto.ImageUrl = ogrAS.Ogr_Fotograf;
                imFoto1.ImageUrl = ogrAS.Ogr_Fotograf;

            }
            else
            {
                Response.Redirect("OgrLogin.aspx");
            }
        }

        //İmzayı al ve veri Tabanına Kaydet
        protected void Button1_Click(object sender, EventArgs e)
        {

            string OgrNo = Session["OrgNo"].ToString();
            var ogrAS = ctx.tblOgr_Ogrenci.Where(x => x.Ogr_No == OgrNo).FirstOrDefault();
            string Ad = ogrAS.Ogr_Ad;
            string Soyad = ogrAS.Ogr_SoyAd;

            string str = HiddenField1.Value;
            string Veri = SifreCoz(str);
            string[] VeriListe = Veri.Split(',');

            if (str.Equals(""))
            {
                lblBilgi.Text = "İmzalamak İçin Lütfen Barkodu Okudunuz !";
                //Response.Write("<script> alert('İmzalamak İçin Lütfen Barkodu Okudunuz !'); </script>");
            }
            else
            {
                if (Hoca_imzasi(VeriListe))
                {
                    if (Tek_imza(Ad, Soyad, OgrNo, VeriListe[0], VeriListe[1], VeriListe[2], VeriListe[3]))
                    {
                        lblBilgi.Text = "İmza Daha Önce Zaten Alınmıştır !";
                        //Response.Write("<script> alert('İmza Daha Önce Zaten Alınmıştır !'); </script>");
                        HiddenField1.Value = "";
                    }
                    else
                    {
                        string zaman = ZamanKontrol(VeriListe);
                        if (Convert.ToDateTime(zaman + ":00").AddMinutes(10) > DateTime.Now)
                        {
                            tblimzaliste imza = new tblimzaliste()
                            {
                                Ogr_Ad = Ad,
                                Ogr_Soyad = Soyad,
                                Ogr_No = OgrNo,
                                Ders_Tipi = VeriListe[0],
                                Ders_Kod = VeriListe[1],
                                Ders_Saat = VeriListe[2],
                                Ders_Haftasi = VeriListe[3],
                                imza_Tarihi = DateTime.Now.ToShortDateString(),
                                imza_Saat = DateTime.Now.ToShortTimeString(),
                                Ogr_DerseKatilimSuresi = imzaToplamSaat(VeriListe[1], VeriListe[0], VeriListe[2])
                            };
                            ctx.tblimzalistes.Add(imza);
                            ctx.SaveChanges();
                            lblBilgi.Text = "İmza Başarılı Bir Şekilde Alındı.";
                            //Response.Write("<script> alert('İmza Başarılı Bir Şekilde Alındı.'); </script>");
                            HiddenField1.Value = "";
                            //Response.Redirect("OgrAnaSayfa.aspx");
                        }
                        else
                        {
                            lblBilgi.Text = "İmza Süresi Geçersiz !";
                            //Response.Write("<script> alert('İmza Süresi Geçersiz !'); </script>");
                            HiddenField1.Value = "";
                        }


                    }
                }
                else
                {
                    lblBilgi.Text = "Geçersiz Barkod İmza Bulunmadı !";
                    //Response.Write("<script> alert('Geçersiz Barkod İmza Bulunmadı !'); </script>");
                    HiddenField1.Value = "";
                }
            }
        }

        //Şifrelenmiş Barkodu Çöz
        public string hash = "AhmedÇILDIR";
        public string SifreCoz(string SifrelenmisDeger)
        {
            if (SifrelenmisDeger != "")
            {
                byte[] data = Convert.FromBase64String(SifrelenmisDeger);
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        ICryptoTransform transform = tripDes.CreateDecryptor();
                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                        return UTF8Encoding.UTF8.GetString(results);
                    }
                }

            }
            else
            {
                return "";
            }



        }

        //Hocanın imza aldığını Kontrol Et
        public bool Hoca_imzasi(string[] DersKod)
        {
            if (DersKod.Length > 1)
            {
                string[] dersKod = DersKod;
                string Kod = dersKod[1];
                var getAkedemisyenID = ctx.tblAkedimisyen_Al_Dersler.Where(x => x.Ders_Kod == Kod).FirstOrDefault();
                string Akd_İd = getAkedemisyenID.AkedimisyenID.ToString();
                int id = int.Parse(Akd_İd);

                var getAkedemisyen = ctx.tblUsers.Where(x => x.Id == id).FirstOrDefault();
                string Ak_Ad = getAkedemisyen.Ad;
                string Ak_Soyad = getAkedemisyen.Soyad;
                string Ak_Tc = getAkedemisyen.Tc;
                if (imzakontrol(Ak_Ad, Ak_Soyad, Ak_Tc, dersKod))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        //Hocanın imza aldığını Kontrol Et
        private bool imzakontrol(string userName, string Soyad, string Tc, string[] DersKod)
        {
            string[] d = DersKod;
            string dersTipi = d[0];
            string dersKodu = d[1];
            string dersSaati = d[2];
            string dersHaftası = d[3];
            var q1 = from p in ctx.tblAlinan_imza
                     where p.Ad == userName
                     && p.Soyad == Soyad && p.Tc == Tc
                     && p.Ders_Tipi == dersTipi && p.Ders_Kod == dersKodu
                     || p.Ders_Saat == dersSaati && p.Ders_Haftasi == dersHaftası
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

        //imzanın daha Önce atılmadığını Kontrol Et
        private bool Tek_imza(string OgrAd, string OgrSoyad, string OgrNo, string DersTipi, string DersKod, string DersSaati, string DersHafta)
        {

            var q1 = from p in ctx.tblimzalistes
                     where p.Ogr_Ad == OgrAd
                     && p.Ogr_Soyad == OgrSoyad && p.Ogr_No == OgrNo
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


        //hocanın imzayı aldığı tarih, saat ve dakikayı getirir.
        private string ZamanKontrol(string[] DersKod)
        {
            string[] dersKod = DersKod;
            string dersTipi = dersKod[0];
            string dersKodu = dersKod[1];
            string dersSaati = dersKod[2];
            string dersHaftası = dersKod[3];

            var getAkedemisyenID = ctx.tblAkedimisyen_Al_Dersler.Where(x => x.Ders_Kod == dersKodu).FirstOrDefault();
            string Akd_İd = getAkedemisyenID.AkedimisyenID.ToString();

            int id = int.Parse(Akd_İd);


            var getTc = ctx.tblUsers.Where(x => x.Id == id).FirstOrDefault();
            string Tc = getTc.Tc;


            var q1 = from p in ctx.tblAlinan_imza
                     where p.Tc == Tc
                     && p.Ders_Tipi == dersTipi && p.Ders_Kod == dersKodu
                     || p.Ders_Saat == dersSaati && p.Ders_Haftasi == dersHaftası
                     select p;
            string[] d = new string[2];
            foreach (var i in q1.ToList())
            {
                d[0] = i.imza_Tarihi;
                d[1] = i.imza_Saat;
            }
            string zaman = d[0] + " " + d[1];
            return zaman;

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