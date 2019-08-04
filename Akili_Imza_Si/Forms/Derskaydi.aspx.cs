using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.Forms
{
    public partial class Derskaydi : System.Web.UI.Page
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            int x = 1;
            if (!Page.IsPostBack)
            {
                var qFakulteler = from f in ctx.tblFakultelers
                                  select new { fakulte = f.Fakulte_Adi, fakultekod = f.Fakulte_Kod };
                foreach (var qf in qFakulteler)
                {
                    dropFakulte.Items.Insert(x, new ListItem(qf.fakulte, qf.fakultekod));
                    x++;
                }
            }
            else
            {

            }
        }

        protected void dropFakulte_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = 1;
            dropBollum.Items.Clear();
            int i = Int32.Parse(dropFakulte.SelectedItem.Value);
            dropBollum.Items.Insert(0, new ListItem("Bölüm Seçiniz..", "0"));
            if (i != null)
            {
                var qBolum = from b in ctx.tblBolumlers
                             where (b.Fakulte_Kodu == i.ToString())
                             select new { bolum = b.Bolum_Ad, bolumKodu = b.Bolum_Kod };
                foreach (var qb in qBolum)
                {
                    dropBollum.Items.Insert(x, new ListItem(qb.bolum, qb.bolumKodu));
                    x++;
                }


            }
        }

        protected void dropBollum_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = 1;
            dropDersKodu.Items.Clear();
            int i = Int32.Parse(dropBollum.SelectedItem.Value);
            dropDersKodu.Items.Insert(0, new ListItem("Bölüm Seçiniz..", "0"));
            if (i.ToString() != null)
            {
                var qDers = from d in ctx.tblDerslers
                            where (d.Bolum_Kod == i.ToString())
                            select new { dersAdi = d.Ders_Ad, dersKodu = d.Ders_Kod ,did=d.DId};
                foreach (var qd in qDers)
                {
                    dropDersKodu.Items.Insert(x, new ListItem(qd.dersKodu, qd.did.ToString()));
                    x++;
                }
            }
        }

        protected void btnDersKaydi_Click(object sender, EventArgs e)
        {
            string kod = dropDersKodu.SelectedItem.Text;
            if (Session["id"] != null)
            {
                int id = int.Parse(Session["id"].ToString());
                if (DersKontrol(kod))
                {
                    Response.Write("<script> alert('Ders Daha Önce Kayd Edilmiştir'); </script>");
                }
                else
                {
                    tblAkedimisyen_Al_Dersler ekle = new tblAkedimisyen_Al_Dersler()
                    {
                        AkedimisyenID = id,
                        Ders_Kod = kod
                    };
                    ctx.tblAkedimisyen_Al_Dersler.Add(ekle);
                    ctx.SaveChanges();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        //Dersin Daha önce Alınıp Alınmadığını kontrol et
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