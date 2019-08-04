using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.Ogrenci
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {


            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Silindi');</script>");

            //var imzaSaati = ctx.tblimzalistes.Where(x => x.Ogr_No == "99649774106").FirstOrDefault();
            //string saat = imzaSaati.imza_Saat;
            //string tarih = imzaSaati.imza_Tarihi;

            //Response.Write(tarih+" "+saat+" ");
            //string[] d = new string[4];
            //d[0] = "Teorik";
            //d[1] = "BM101";
            //d[2] = "Tek İmza";
            //d[3] = "1.Hafta";
            //string zaman = ZamanKontrol(d);
            //Response.Write(zaman);
            //Response.Write("Saaat "+Convert.ToDateTime(zaman+ ":00").AddMinutes(10));



            //if (Convert.ToDateTime(tarih + " " + saat + ":00").AddMinutes(10) > DateTime.Now)
            //{
            //    Label1.Text=DateTime.Now.AddMinutes(20).ToString()+" Ok";
            //}
            //else
            //{
            //    Label1.Text = "No";
            //}
        }
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
                     && p.Ders_Saat == dersSaati && p.Ders_Haftasi == dersHaftası
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Silindi');</script>");
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
            }

        }
    }
}