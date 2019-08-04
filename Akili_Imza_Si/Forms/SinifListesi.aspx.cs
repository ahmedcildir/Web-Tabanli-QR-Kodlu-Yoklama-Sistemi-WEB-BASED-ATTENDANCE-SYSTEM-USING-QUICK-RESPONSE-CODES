using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.Forms
{
    public partial class SinifListesi : System.Web.UI.Page
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["id"] != null)
            {

                int id = int.Parse(Session["id"].ToString());
                if (!Page.IsPostBack)
                {
                    dropDers.Items.Add("Der Seçinriz..");
                    foreach (var i in ctx.tblAkedimisyen_Al_Dersler.Where(x => x.AkedimisyenID == id))
                    {

                        dropDers.Items.Add(i.Ders_Kod);
                    }
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }
        
        protected void btnQrUret_Click(object sender, EventArgs e)
        {
            

            string ders = dropDers.SelectedItem.Text;
            

            var qSinifListesi = 
                from sl in ctx.tblDersKaydı
                where (sl.Ders_Kod == ders)
                select (new {sl.Ogr_No,sl.Ogr_Ad,sl.Ogr_Soyad,sl.Drs_S_Z });

            repOgr.DataSource = qSinifListesi.ToList();
            repOgr.DataBind();
            //dropDers.Items.Clear();

            //dropDers.Items.Add("Der Seçinriz..");
            //foreach (var i in ctx.tblAkedimisyen_Al_Dersler.Where(x => x.AkedimisyenID == 1))
            //{

            //    dropDers.Items.Add(i.Ders_Kod);
            //}


            //var ogrNo = from no in ctx.tblOgr_AlinanDrsler where (no.Ders_Kod == ders) select no.Ogr_No;
            //List<string> OgrNoLis = new List<string>();
            //List<string> qogr = new List<string>();
            //foreach (var it in ctx.tblOgr_AlinanDrsler.Where(x => x.Ders_Kod == ders).ToList())
            //{
            //    OgrNoLis.Add(it.Ogr_No);

            //}
            //int i1 = Convert.ToInt32(OgrNoLis.Count());
            //ListBox1.Items.Add(i1.ToString());
            //for (int i = 0; i < i1; i++)
            //{
            //   string no=OgrNoLis[i].ToString();
            //    //var qOgrenci = ctx.tblOgr_Ogrenci.Where(x => x.Ogr_No == no).Select(x => new { x.Ogr_No, x.Ogr_Ad, x.Ogr_SoyAd }).ToList();
            //    var qOgrenci = from ogr in ctx.tblOgr_Ogrenci where (ogr.Ogr_No == no) select ogr.Ogr_SoyAd;     
            //    ListBox1.Items.Add(qOgrenci.ToString());
            //    foreach (var item in qOgrenci)
            //    {
            //        qogr.Add(item.ToString());
            //    }
            //GridView1.DataSource = qogr.ToList();
            //GridView1.DataBind();
            //var ogrBilgi = from o in ctx.tblOgr_Ogrenci where (o.Ogr_No == OgrNoLis[0].ToString()) select o.Ogr_SoyAd;
            //GridView1.DataSource = ogrBilgi;
            //GridView1.DataBind();



        }
    }
}