using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.Ogrenci
{
    public partial class devamsızlıkDetayi : System.Web.UI.Page
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Today;
            lblTarih.Text = dt.ToShortDateString();

            string dk = Request.QueryString["dk"];
            int HaftaSayisi = 14;
            int teorik = DersSuresi(dk, "Teorik");
            int Uygulamali = DersSuresi(dk, "Uygulamalı");
            int ToplamSaat = ((teorik + Uygulamali) * HaftaSayisi);
            double TeorikToplamDevamsizlik = Math.Round((double)((teorik * HaftaSayisi) * 30) / 100);
            double UygulamaliToplamDevamsizlik = Math.Round((double)((Uygulamali * HaftaSayisi) * 20) / 100);
            double Sayi = Math.Ceiling(99.5);

            //lblBilgi.Text = "Toplam 14 Hafta (" + ToplamSaat + " Saat). Teorik Toplamı " + (teorik * HaftaSayisi) + " Saat, Devamsızlık Oranı (%30)/" + TeorikToplamDevamsizlik + " Saat. Uygulama Toplamı " + (Uygulamali * HaftaSayisi) + " Saat, Devamsızlık Oranı (%20)/" + UygulamaliToplamDevamsizlik + " Saat.";
            //Toplam 14 Hafta (70 Saat). Teorik Toplamı 42 Saat, Devamsızlık Oranı (%30)/13 Saat. Uygulama Toplamı 28 Saat, Devamsızlık Oranı (%20)/6 Saat.
            lbltoplamhafta.Text = HaftaSayisi.ToString();
            lbltoplamsaat.Text = ToplamSaat.ToString();
            tblteoriktoplam.Text = (teorik * HaftaSayisi)+" Saat";
            lblteorikdevamsızlık.Text = TeorikToplamDevamsizlik + " Saat";
            lbluygulamalitoplam.Text = (Uygulamali * HaftaSayisi)+" Saat";
            lbluygulamalidevamsizlik.Text = UygulamaliToplamDevamsizlik + " Saat";
            int HAlinanTeorikSuresi = HocaToplamImza(dk, "Teorik");
            int AlinanUygulamaliSuresi = HocaToplamImza(dk, "Uygulamalı");

            int ogrTeorikImza = OgrToplamImza(dk, "Teorik");
            int ogrUygulamliImza = OgrToplamImza(dk, "Uygulamalı");

            int TeorikD = (HAlinanTeorikSuresi - ogrTeorikImza);
            int UygulamaliD = (AlinanUygulamaliSuresi - ogrUygulamliImza);
            if (TeorikD > TeorikToplamDevamsizlik||UygulamaliD>UygulamaliToplamDevamsizlik)
            {
                lblTDS.ForeColor = Color.Red;
                lblTDS.Text = "Devamsızlıktan Kaldınız (Teorik: " + TeorikD + ")(Uygulama: " + UygulamaliD + ")".ToString();
            }
            else
            {
                lblTDS.ForeColor = Color.Blue;
                lblTDS.Text = "(Teorik:" + TeorikD + ") (Uygulama:" + UygulamaliD + ")".ToString();

            }
           //lblTarih.Text=
        }
        //Teorik Ve Uyhulamalı Ders Saatlerini Getir
        private int DersSuresi(string dersKodu, string DersTipi)
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
            if (DersTipi.Equals("Teorik"))
            {
                return int.Parse(st[0]);
            }
            else if (DersTipi.Equals("Uygulamalı"))
            {
                return int.Parse(st[1]);
            }
            else
            {
                return 0;
            }
        }

        //Hocanın Aldığı Toplam İmza Saatini Getirir
        private int HocaToplamImza(string DersKou, string DersTipi)
        {
            var getSaat = from s in ctx.tblAlinan_imza
                          where (s.Ders_Kod == DersKou && s.Ders_Tipi == DersTipi)
                          select (s.IslenenDersSuresi);
            if (getSaat.Any())
            {
                return getSaat.Sum().Value;

            }
            else
            {
                return 0;
            }

        }

        //Öğrencinin İmzaladığı Toplam İmza Saatini Getirir
        private int OgrToplamImza(string DersKou, string DersTipi)
        {
            if (Session["OrgNo"] != null)
            {
                string OrgNo = Session["OrgNo"].ToString();

                var getSaat = from s in ctx.tblimzalistes
                              where (s.Ogr_No == OrgNo && s.Ders_Kod == DersKou && s.Ders_Tipi == DersTipi)
                              select (s.Ogr_DerseKatilimSuresi);
                if (getSaat.Any())
                {
                    return getSaat.Sum().Value;

                }
                else
                {
                    return 0;
                }
            }
            else
            {
                Response.Redirect("OgrLogin.aspx");
                return 0;

            }
        }

        protected void btnkapat_Click(object sender, EventArgs e)
        {
            Response.Redirect("Devamsizlik.aspx");
        }
    }
}