using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.NetworkInformation;
using Akili_Imza_Si.DB;

namespace Akili_Imza_Si.Ogrenci
{
    public partial class oisk : System.Web.UI.Page
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        string MacAddress = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                NetworkInterface[] anics = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface adapter in anics)
                {
                    if (MacAddress == String.Empty)
                    {
                        IPInterfaceProperties properties = adapter.GetIPProperties();
                        MacAddress = adapter.GetPhysicalAddress().ToString();
                    }
                }
            }
            catch (Exception ex) { }
        }
       
        protected void btnKayit_Click(object sender, EventArgs e)
        {

            if (gecerliKullanici(txtOgrNo.Text,txtAd.Text,txtSoyad.Text))
            {
                

                var OgrenciAkti = from o in ctx.tblOgr_Ogrenci where (o.Ogr_No==txtOgrNo.Text) select o;
                foreach (var i in OgrenciAkti)
                {
                    i.Ogr_MacAddres = MacAddress;
                    i.Ogr_Password = txtSifre.Text;
                    i.Ogr_telefon = txtTelefon.Text;
                    i.Ogr_Eposta = txtEposta.Text;
                }
                ctx.SaveChanges();

                HttpCookie cerez = new HttpCookie("Mac");
                cerez["MacAddress"] = MacAddress;
                cerez["Tc"] = txtTc.Text;
                cerez.Expires = DateTime.Now.AddYears(4);
                Response.Cookies.Add(cerez);
                Response.Redirect("OgrLogin.aspx");
            }
            else
            {
                Response.Write("<script> alert('Kayıt Başarısız Lütfen Bilgilerinizi Doğru Girdiğinizden Emin Olun.. '); </script>");

            }

            
        }
        private bool gecerliKullanici(string OgrNo, string OgrAd, string OgrSoyad)
        {

            var Ogrenci = from Ogr in ctx.tblOgr_Ogrenci
                          where Ogr.Ogr_No == OgrNo
                          && Ogr.Ogr_Ad == OgrAd && Ogr.Ogr_SoyAd == OgrSoyad
                          select Ogr;

            if (Ogrenci.Any())
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