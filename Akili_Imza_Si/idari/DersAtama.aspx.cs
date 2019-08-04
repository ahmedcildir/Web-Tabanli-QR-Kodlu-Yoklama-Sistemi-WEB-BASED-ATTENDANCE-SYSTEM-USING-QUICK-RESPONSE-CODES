using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.idari
{
    public partial class DersAtama : System.Web.UI.Page
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["iid"] != null)
            {
                int pid = int.Parse(Session["iid"].ToString());
                if (!Page.IsPostBack)
                {
                    dropBollum.Items.Add("Bölüm Seçiniz..");
                    dropDers.Items.Add("Ders Seçiniz..");
                    dropHoca.Items.Add("Hoca Seçiniz..");

                    var CalistigiBolum =
                    from cb in ctx.tbIdariPersonels
                    where (cb.PID == pid)
                    select cb;

                    string[] c = new string[1];
                    foreach (var i in CalistigiBolum)
                    {
                        c[0] = i.FakulteKod;

                    }

                    string id = c[0];
                    var bolum =
                       from b in ctx.tblBolumlers
                       where (b.Fakulte_Kodu == id)
                       select b;
                    foreach (var i in bolum)
                    {
                        dropBollum.Items.Add(i.Bolum_Ad);

                    }
                }
            }
        }

        protected void dropBollum_SelectedIndexChanged1(object sender, EventArgs e)
        {
            dropDers.Items.Clear();
            dropDers.Items.Add("Ders Seçiniz..");
            string ders = dropBollum.SelectedItem.Text;
            string[] bolKod = new string[1];
            var bolumKodu =
               from b in ctx.tblBolumlers
               where (b.Bolum_Ad == ders)
               select b;
            foreach (var i in bolumKodu)
            {
                bolKod[0] = i.Bolum_Kod;
            }

            string derAd = bolKod[0];
            var dersAd =
              from b in ctx.tblDerslers
              where (b.Bolum_Kod == derAd)
              select b;
            foreach (var i in dersAd)
            {
                dropDers.Items.Add(i.Ders_Ad);
            }
        }

        protected void dropDers_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropHoca.Items.Clear();
            dropHoca.Items.Add("Hoca Seçiniz..");
            var getHoca =
               from b in ctx.tblUsers
               select b;
            foreach (var i in getHoca)
            {
                dropHoca.Items.Add(i.Unvani + ". " + i.Ad + " " + i.Soyad);
            }
        }

        protected void btnDersKaydi_Click(object sender, EventArgs e)
        {
            if (dropBollum.SelectedItem.Text == "Bölüm Seçiniz.." || dropDers.SelectedItem.Text == "Ders Seçiniz.." || dropHoca.SelectedItem.Text == "Hoca Seçiniz..")
            {
                lblmesaj.Text = "Lütfen İlgili Seçenekleri Seçiniz.";
            }
            else
            {
                string dersAd = dropDers.SelectedItem.Text;
                string[] dersKodu = new string[1];
                var dersKou =
                  from b in ctx.tblDerslers
                  where (b.Ders_Ad == dersAd)
                  select b;
                foreach (var i in dersKou)
                {
                    dersKodu[0] = i.Ders_Kod;
                }
                string DK = dersKodu[0];


                string HID = dropHoca.SelectedItem.Text;
                string[] hocaID = new string[3];
                var hocaId =
                  from h in ctx.tblUsers
                  where (h.Unvani + ". " + h.Ad + " " + h.Soyad == HID)
                  select h;
                foreach (var i in hocaId)
                {
                    hocaID[0] = i.Id.ToString();
                }
                string id = hocaID[0];


                if (DersKontrol(DK))
                {

                    var DersAtananHoca =
                    from h in ctx.tblAkedimisyen_Al_Dersler
                    where (h.Ders_Kod == DK)
                    select h;
                    foreach (var i in DersAtananHoca)
                    {
                        hocaID[1] = i.AkedimisyenID.ToString();
                    }
                    int DAH = int.Parse(hocaID[1]);

                    var HocaBilgi =
                     from h in ctx.tblUsers
                     where (h.Id == DAH)
                     select h;
                    foreach (var i in HocaBilgi)
                    {
                        hocaID[2] = i.Unvani + ". " + i.Ad + " " + i.Soyad;
                    }
                    string HB = hocaID[2];
                    Response.Write("<script> alert('Ders Daha Önce " + HB + " İsimli Hocaya Atanmıştır !'); </script>");
                }
                else
                {
                    tblAkedimisyen_Al_Dersler ekle = new tblAkedimisyen_Al_Dersler()
                    {
                        AkedimisyenID = int.Parse(id),
                        Ders_Kod = DK
                    };
                    ctx.tblAkedimisyen_Al_Dersler.Add(ekle);
                    ctx.SaveChanges();
                    Response.Write("<script> alert('Ders Başarılı Bir Şekilde Kaydedildi'); </script>");
                }
            }
        }

        private bool DersKontrol(string derskod)
        {

            var q1 = from d in ctx.tblAkedimisyen_Al_Dersler
                     where d.Ders_Kod == derskod
                     select d;

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