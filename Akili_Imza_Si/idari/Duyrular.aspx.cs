using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.idari
{
    public partial class Duyrular : System.Web.UI.Page
    {

        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["iid"] != null)
            {
                int pid = int.Parse(Session["iid"].ToString());
                if (!Page.IsPostBack)
                {
                    //dropKatagori.Items.Add("Katagori Seçiniz..");
                    //dropKatagori.Items.Add("Tek Hocaya");
                    //dropKatagori.Items.Add("Tek Bölüme");


                    dropKatagori.Items.Insert(0, new ListItem("Katagori Seçiniz..", "0"));
                    dropKatagori.Items.Insert(1, new ListItem("Tek Hocaya", "1"));
                    dropKatagori.Items.Insert(2, new ListItem("Tek Bölüme", "2"));
                    dropKatagori.Items.Insert(3, new ListItem("Tüm Bölümlere", "3"));
                    

                    drophoca.Items.Add("Hoca Seçiniz..");
                    dropBolum.Items.Add("Bölüm Seçiniz..");
                    
                }


                if (dropKatagori.SelectedItem.Text.Equals("Tüm Bölümlere"))
                {
                    dropBolum.Enabled = false;
                }
                else
                {
                    dropBolum.Enabled = true;
                }
                if (dropKatagori.SelectedItem.Text.Equals("Tek Bölüme") || dropKatagori.SelectedItem.Text.Equals("Tüm Bölümlere"))
                {
                    drophoca.Enabled = false;
                }
                else
                {

                    drophoca.Enabled = true;
                }
            }

        }


        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (Session["iid"] != null)
            {
                string Mesaj = HiddenField.Value;
                int pid = int.Parse(Session["iid"].ToString());
                String BolumAd = dropBolum.SelectedItem.Text;
                String AK_Ad = drophoca.SelectedItem.Text;

                dropBolum.Items.Clear();
                drophoca.Items.Clear();
                drophoca.Items.Add("Hoca Seçiniz..");
                dropBolum.Items.Add("Bölüm Seçiniz..");

                string[] Bilgi = new string[2];
                Bilgi[0] = null;
                Bilgi[1] = null;
                var HocaID = from k in ctx.tblUsers
                             where (k.Unvani + ". " + k.Ad + " " + k.Soyad == AK_Ad)
                             select new { id = k.Id };
                foreach (var i in HocaID)
                {
                    Bilgi[0] = i.id.ToString();
                }

                var BolumKod = from b in ctx.tblBolumlers
                               where (b.Bolum_Ad == BolumAd)
                               select new { BolumKodu = b.Bolum_Kod };
                foreach (var i in BolumKod)
                {
                    Bilgi[1] = i.BolumKodu;
                }

                DateTime dt = DateTime.Today;
                int yil = dt.Year;
                int ay = dt.Month;
                int gun = dt.Day;

               string fk="a";

                if (dropKatagori.SelectedItem.Text.Equals("Tek Bölüme"))
                {
                    fk = "";
                }
                else
                {
                    if (Session["Fakulte"].ToString()!=null)
                    {
                        fk = Session["Fakulte"].ToString();
                    }
                   
                }
                tblDuyrular Duyru = new tblDuyrular()
                {
                    PresonelID = pid.ToString(),
                    BolumKod = Bilgi[1],
                    FakulteKod = fk,
                    AkID = Bilgi[0],
                    Baslik = txtBaslik.Text,
                    Mesaj = Mesaj,
                    Tarih=dt.ToShortDateString(),
                    Gun=gun.ToString(),
                    Ay=ay.ToString()
                };
                ctx.tblDuyrulars.Add(Duyru);
                ctx.SaveChanges();
                txtBaslik.Text = "";
                Response.Write("<script> alert('Duyru Başarılı Bir Şekilde gönderildi'); </script>");

            }
        }

        //Bolume Göre Hocayı Göster
        protected void dropBolum_SelectedIndexChanged(object sender, EventArgs e)
        {

            drophoca.Items.Clear();
            drophoca.Items.Add("Hoca Seçiniz");


            String BolumAd = dropBolum.SelectedItem.Text;


            var qidariUsers = ctx.tblUsers;
            var Bolum = ctx.tblBolumlers;
            var getHoca =
                from U in qidariUsers
                join B in Bolum on U.BolumKod equals B.Bolum_Kod
                where (B.Bolum_Ad == BolumAd)
                select new { U.Ad, U.Soyad, U.Unvani };
            foreach (var i in getHoca)
            {
                drophoca.Items.Add(i.Unvani + ". " + i.Ad + " " + i.Soyad);
            }


        }
        //Katagoriye Göre Bolumleri Getir
        protected void dropKatagori_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropBolum.Items.Clear();
            dropBolum.Items.Add("Bölüm Seçiniz..");
            int i = Int32.Parse(dropKatagori.SelectedItem.Value);
            if (i == 1 || i == 2)
            {
                int pid = int.Parse(Session["iid"].ToString());
                var qidariUsers = ctx.tbIdariPersonels;
                var Bolum = ctx.tblBolumlers;
                var getFakulta =
                    from U in qidariUsers
                    join B in Bolum on U.FakulteKod equals B.Fakulte_Kodu
                    where (U.PID == pid)
                    select new { B.Fakulte_Kodu, U.Gorev, B.Bolum_Ad, B.Bolum_Kod, U.FakulteKod };

                foreach (var qi in getFakulta)
                {
                    Session["Fakulte"] = qi.FakulteKod;
                    dropBolum.Items.Add(qi.Bolum_Ad);
                }
            }
            else
            {

            }

        }
    }
}