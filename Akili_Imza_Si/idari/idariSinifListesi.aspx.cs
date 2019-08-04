using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.idari
{
    public partial class idariSinifListesi : System.Web.UI.Page
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["iid"] != null)
            {
                int pid = int.Parse(Session["iid"].ToString());
                if (!Page.IsPostBack)
                {
                    dropbolum.Items.Add("Bölüm Seç..");
                    dropders.Items.Add("Ders Seç..");

                    var qidariUsers = ctx.tbIdariPersonels;
                    var Bolum = ctx.tblBolumlers;
                    var Akademisyen = ctx.tblUsers;
                    var getFakulta =
                        from U in qidariUsers
                        join B in Bolum on U.FakulteKod equals B.Fakulte_Kodu
                        where (U.PID == pid)
                        select new { B.Fakulte_Kodu, U.Gorev, B.Bolum_Ad, B.Bolum_Kod };
                    foreach (var i in getFakulta)
                    {  
                        dropbolum.Items.Add(i.Bolum_Ad);
                    }

                    //var CalistigiBolum =
                    //from cb in ctx.tbIdariPersonels
                    //where (cb.PID == pid)
                    //select cb;

                    //string[] c = new string[1];
                    //foreach (var i in CalistigiBolum)
                    //{
                    //    c[0] = i.FakulteKod;

                    //}

                    //string id = c[0];
                    //var bolum =
                    //   from b in ctx.tblBolumlers
                    //   where (b.Fakulte_Kodu == id)
                    //   select b;
                    //foreach (var i in bolum)
                    //{
                    //    dropbolum.Items.Add(i.Bolum_Ad);

                    //}
                }
            }
        }

        protected void btnQrUret_Click(object sender, EventArgs e)
        {

            if (dropders.SelectedItem.Text == "Ders Seç.." || dropbolum.SelectedItem.Text == "Bölüm Seç..")
            {
                lblmesaj.Text = "Lütfen İlgili Seçenekleri Seçiniz.";
            }
            else
            {
                lblmesaj.Text = "";
                string dersAd = dropders.SelectedItem.Text;
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
                var qSinifListesi =
                    from sl in ctx.tblDersKaydı
                    where (sl.Ders_Kod == DK)
                    select (new { sl.Ogr_No, sl.Ogr_Ad, sl.Ogr_Soyad, sl.Drs_S_Z });
                List<string> sayi = new List<string>();
                foreach (var i in qSinifListesi)
                {
                    sayi.Add(i.Ogr_No);
                }
                lblmesaj.Text = "Dersi Alan Öğrenci Sayısı( " + sayi.Count.ToString() + " )";
                repOgr.DataSource = qSinifListesi.ToList();
                repOgr.DataBind();
            }
        }

        protected void dropbolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropders.Items.Clear();
            dropders.Items.Add("Ders Seç..");
            string ders = dropbolum.SelectedItem.Text;
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
                dropders.Items.Add(i.Ders_Ad);
            }
        }
    }
}