using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.Ogrenci
{
    public partial class OgrTumduyrular : System.Web.UI.Page
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["OrgNo"] != null && Session["OgrLogin_onay"].ToString() == "OK")
            {
                string OrgNo = Session["OrgNo"].ToString();
                DateTime dt = DateTime.Today;
                lblTarih.Text = dt.ToShortDateString();
                //ogr Aldığı Dersler
                List<string> dk = new List<string>();
                var getDersler = from dr in ctx.tblDersKaydı
                                 where (dr.Ogr_No == OrgNo)
                                 select new { dr.Ders_Kod };
                foreach (var d_k in getDersler)
                {
                    dk.Add(d_k.Ders_Kod);

                }
                //Duyruları Getir
                List<tblOgr_Duyrular> lst = new List<tblOgr_Duyrular>();
                List<tblOgr_Duyrular> lst2 = duyruMesaj(OrgNo);
                foreach (tblOgr_Duyrular item in lst2)
                {
                    lst.Add(item);
                }
                for (int i = 0; i < dk.Count(); i++)
                {
                    List<tblOgr_Duyrular> lst3 = duyruMesajDK(dk[i]);
                    foreach (tblOgr_Duyrular item in lst3)
                    {
                        lst.Add(item);
                    }
                }

                lisDuyru.DataSource = lst;
                lisDuyru.DataBind();

            }
            else
            {
                Response.Redirect("OgrLogin.aspx");
            }
        }
        //Duyruları Getir
        //private void duyruMesaj(string OgrNo, string Dk)
        //{
        //    var getDuyru = from du in ctx.tblOgr_Duyrular
        //                   where (du.OgrNo == OgrNo || du.DersKod == Dk)
        //                   select du;
        //    lisDuyru.DataSource = getDuyru.ToList();
        //    lisDuyru.DataBind();
        //}
        //Duyruları Getir
        private List<tblOgr_Duyrular> duyruMesaj(string OgrNo)
        {
            var getDuyru = ctx.tblOgr_Duyrular.Where(x => x.OgrNo == OgrNo).ToList();
            return getDuyru.ToList();
        }
        private List<tblOgr_Duyrular> duyruMesajDK(string DK)
        {
            var getDuyru = ctx.tblOgr_Duyrular.Where(x => x.DersKod == DK).ToList();
            return getDuyru.ToList();
        }

        protected void btnkapat_Click(object sender, EventArgs e)
        {
            Response.Redirect("OgrAnaSayfa.aspx?bk=Siirt Üniversitesi");
        }
    }
}