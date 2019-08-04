using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.Forms
{
    public partial class AkDuyruYAyinla : System.Web.UI.Page
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                if (!Page.IsPostBack)
                {
                    //dropKatagori.Items.Add("Katagori Seçiniz..");
                    //dropKatagori.Items.Add("Tek Hocaya");
                    //dropKatagori.Items.Add("Tek Bölüme");


                    dropKatagori.Items.Insert(0, new ListItem("Katagori Seçiniz..", "0"));
                    dropKatagori.Items.Insert(1, new ListItem("Tek Öğrenci", "1"));
                    dropKatagori.Items.Insert(2, new ListItem("Dersi Allan Öğrenciler", "2"));


                    dropOgr.Items.Add("Oğrenci Seçiniz..");
                    dropders.Items.Add("Ders Seçiniz..");

                }

                if (dropKatagori.SelectedItem.Text.Equals("Dersi Allan Öğrenciler"))
                {

                    dropOgr.Enabled = false;
                }
                else
                {

                    dropOgr.Enabled = true;
                }
            }
            else
            {

            }
        }

        //Dersleri Getir
        protected void dropKatagori_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropders.Items.Clear();
            dropders.Items.Add("Ders Seçiniz..");
            int i = Int32.Parse(dropKatagori.SelectedItem.Value);
            if (i == 1 || i == 2)
            {
                int Aid = int.Parse(Session["id"].ToString());
                var getDersler = from d in ctx.tblAkedimisyen_Al_Dersler
                                 where (d.AkedimisyenID == Aid)
                                 select d;
                foreach (var d in getDersler)
                {
                    dropders.Items.Add(d.Ders_Kod);
                }

            }
            else
            {

            }

        }
        //Dersi Alan Öğrencileri Getir
        protected void dropBolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropOgr.Items.Clear();
            dropOgr.Items.Add("Oğrenci Seçiniz");


            string DersKod = dropders.SelectedItem.Text;
            var getOgr = from o in ctx.tblDersKaydı
                         where (o.Ders_Kod == DersKod)
                         select o;
            foreach (var o in getOgr)
            {
                dropOgr.Items.Add(o.Ogr_No + " " + o.Ogr_Ad + " " + o.Ogr_Soyad);
            }
        }

        protected void btnYayinla_Click(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                string Mesaj = HiddenField.Value;
                int Aid = int.Parse(Session["id"].ToString());
                string DersKod = dropders.SelectedItem.Text;
                string OgrAS = dropOgr.SelectedItem.Text;
                //Ogrenci No Gerit
                string[] Bilgi = new string[2];
                var getOgrNo = from o in ctx.tblOgr_Ogrenci
                             where (o.Ogr_No + " " + o.Ogr_Ad + " " + o.Ogr_SoyAd == OgrAS)
                             select new {o.Ogr_No};
                foreach (var i in getOgrNo)
                {
                    Bilgi[0] = i.Ogr_No;
                }

                //Akedemisyenin Görevli Olduğu Bölümü Getir
                var getBolumKod = from b in ctx.tblUsers
                                  where (b.Id == Aid)
                                  select b;
                foreach (var b in getBolumKod)
                {
                    Bilgi[1] = b.BolumKod;
                }
                if (dropKatagori.SelectedItem.Text.Equals("Tek Öğrenci"))
                {
                    DersKod = "";
                }
                else
                {
                        
                }
                //Tarihi Al
                DateTime dt = DateTime.Now;
                DateTime dt1 = DateTime.Today;
                string saat = dt.ToShortTimeString();
                //Mesajı veri Tabanına Kaydet
                tblOgr_Duyrular Duyru = new tblOgr_Duyrular()
                {
                    AkedimisyenID = Aid.ToString(),
                    DersKod = DersKod,
                    BolumKod = Bilgi[1],
                    OgrNo = Bilgi[0],
                    Baslik = txtBaslik.Text,
                    Mesaj=Mesaj,
                    Tarih = dt.Date,
                    Saat = dt.ToShortTimeString()
                    

                };
                ctx.tblOgr_Duyrular.Add(Duyru);
                ctx.SaveChanges();
                txtBaslik.Text = "";
                Response.Write("<script> alert('Duyru Başarılı Bir Şekilde gönderildi'); </script>");

            }
            else
            {
                Response.Write("<script> alert('Hata Oluştu Lütfen Tekrar Deneyin.'); </script>");

            }
        }
    }
}