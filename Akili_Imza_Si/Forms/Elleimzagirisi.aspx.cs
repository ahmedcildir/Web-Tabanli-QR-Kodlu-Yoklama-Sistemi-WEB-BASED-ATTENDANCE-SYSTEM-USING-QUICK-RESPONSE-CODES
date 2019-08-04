using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.Forms
{
    public partial class Elleimzagirisi : System.Web.UI.Page
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            int y = 1;
            if (Session["id"] != null)
            {
                //if (!Page.IsPostBack)
                //{
                    int id = int.Parse(Session["id"].ToString());
                    //barkod oluşturmada kulanılan bilgileri veritabanından getir iki tablo birleştirme-->
                    var akDersler = ctx.tblAkedimisyen_Al_Dersler;
                    var Dersler = ctx.tblDerslers;
                    var qgetirDers =
                        from akd in akDersler
                        join ders in Dersler on akd.Ders_Kod equals ders.Ders_Kod
                        where (akd.AkedimisyenID == id)
                        select new { DersKodu = akd.Ders_Kod, DerSaati = ders.Teori_Saati, ders.Piratik_Saati };

                    dropDers.Items.Insert(0, new ListItem("Ders Seçiniz..", "0"));
                    dropPT.Items.Insert(0, new ListItem("Ders Tipi..", "0"));
                    dropPT.Items.Insert(1, new ListItem("Teorik", "1"));
                    dropPT.Items.Insert(2, new ListItem("Uygulamalı", "2"));

                    foreach (var q in qgetirDers)
                    {
                        dropDers.Items.Insert(y, new ListItem(q.DersKodu, q.DerSaati));
                        //dropSinif.Items.Add(q.DerslikB);
                        y++;
                    }
                    for (int i = 1; i <= 14; i++)
                    {
                        dropHafta.Items.Add(i + ".Hafta");
                    }
                //}
                //else
                //{

                //}
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void dropDers_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropSaat.Items.Clear();
            int i = Int32.Parse(dropDers.SelectedItem.Value);
            dropSaat.Items.Insert(0, new ListItem("Saat Seçiniz..", "0"));
            if (i != null)
            {
                var Ogrenci = from o in ctx.tblDersKaydı
                              where (o.Ders_Kod == dropDers.SelectedItem.Text)
                              select new {ogrno=o.Ogr_No };
                foreach (var qo in Ogrenci)
                {
                    dropOgrenci.Items.Add(qo.ogrno);
                }
                
            }
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
        }

        protected void btnQrUret_Click(object sender, EventArgs e)
        {
            string dersTP = dropPT.SelectedItem.Text;
            string dersKod = dropDers.SelectedItem.Text;
            string saat = dropSaat.SelectedItem.Text;
            string hafta = dropHafta.SelectedItem.Text;
            string ogrNo = dropOgrenci.SelectedItem.Text;
            if (dropDers.SelectedItem.Text == "Der Seçiniz.." || dropHafta.SelectedItem.Text == "Haftayı Seçiniz.." || dropSaat.SelectedItem.Text == "Saat Seçiniz.." || dropPT.SelectedItem.Text == "Ders Tipi..")
            {
                labUyari.Text = "Lütfen İlgili Seçenekleri Seçiniz.";
            }
            else
            {
                //hocanın Ad Soyad Tc Bilgilerini al ve dizilere aktar-->
                string[] ad = new string[1];
                string[] soyad = new string[1];
                int id = int.Parse(Session["id"].ToString());
                var ogre = from o in ctx.tblDersKaydı
                           where (o.Ogr_No==ogrNo)
                           select new { Ad = o.Ogr_Ad, Soyad = o.Ogr_Soyad};
                foreach (var qo in ogre)
                {
                    ad[0] = qo.Ad.ToString();
                    soyad[0] = qo.Soyad.ToString();
                   
                }//<--
                //hoca elle imza oluşturduğu zaman billgileri veri Tabanıa tblimzaliste isimli tabloya bilgileri ekle-->
                tblimzaliste imza = new tblimzaliste()
                {
                    Ogr_Ad = ad[0],
                    Ogr_Soyad = soyad[0],
                    Ogr_No=ogrNo,
                    Ders_Tipi = dersTP,
                    Ders_Kod = dersKod,
                    Ders_Saat = saat,
                    Ders_Haftasi = hafta,
                    imza_Tarihi = DateTime.Now.ToShortDateString(),
                    imza_Saat = DateTime.Now.ToShortTimeString()
                };
                ctx.tblimzalistes.Add(imza);
                ctx.SaveChanges();//<--
                Response.Write("<script> alert('İmza Başarılı Bir Şekilde Kayıt edildi'); </script>");

            }
        }
    }
}