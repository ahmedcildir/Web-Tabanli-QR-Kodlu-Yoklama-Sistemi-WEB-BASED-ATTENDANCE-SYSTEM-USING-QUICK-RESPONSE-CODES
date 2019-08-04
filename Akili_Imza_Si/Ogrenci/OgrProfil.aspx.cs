using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.Ogrenci
{
    public partial class OgrProfil : System.Web.UI.Page
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["OrgNo"] != null && Session["OgrLogin_onay"].ToString() == "OK")
            {
                string OrgNo = Session["OrgNo"].ToString();
                var qprofil = from p in ctx.tblOgr_Ogrenci
                              where (p.Ogr_No == OrgNo)
                              select new
                              {
                                  ad = p.Ogr_Ad,
                                  soyad = p.Ogr_SoyAd,
                                  ogrNo = p.Ogr_No,
                                  tc = p.Ogr_Tc,
                                  dogumtarihi = p.Ogr_DogumTarihi,
                                  foto = p.Ogr_Fotograf
                              };
                foreach (var p in qprofil)
                {
                    lblAd.Text = p.ad + " " + p.soyad;
                    lblOgrNo.Text = p.ogrNo;
                    lblTc.Text = p.tc;
                    lblDogumTarihi.Text = p.dogumtarihi;
                    imgfoto.ImageUrl = p.foto;
                }
            }
            else
            {
                Response.Redirect("OgrLogin.aspx");
            }
        }
        //Fotoğrafı Güncelleme
        protected void btnfoto_Click(object sender, EventArgs e)
        {
            if (Session["OrgNo"] != null)
            {
                string OrgNo = Session["OrgNo"].ToString();
                if (resimyukle.HasFile)
                {
                    string fileName = resimyukle.FileName;
                    Guid G = Guid.NewGuid();
                    string yol = G + "-u-" + resimyukle.FileName;
                    imgfoto.ImageUrl = "~/Forms/images/" + yol;
                    resimyukle.SaveAs(Server.MapPath("~/Forms/images/" + yol));

                    var resim = ctx.tblOgr_Ogrenci.First(x => x.Ogr_No == OrgNo);
                    resim.Ogr_Fotograf = "~/Forms/images/" + yol;
                    ctx.SaveChanges();
                }
                else
                {
                    lblBilgilendirme.Text = "Lütfen Yüklenecek Bir Resim Seçiniz.";
                }
            }
            else
            {
                Response.Redirect("OgrLogin.aspx");
            }
        }

       

        protected void btnBGetir_Click(object sender, EventArgs e)
        {
            {
                if (Session["OrgNo"] != null)
                {
                    if (IsvalidUser(txtSifreD.Text))
                    {
                        string OrgNo = Session["OrgNo"].ToString();
                        var qprofil = from p in ctx.tblOgr_Ogrenci
                                      where (p.Ogr_No == OrgNo)
                                      select new
                                      {
                                          telefon = p.Ogr_telefon,
                                          eposta = p.Ogr_Eposta,
                                          //unvan = p.Unvani,
                                      };
                        foreach (var p in qprofil)
                        {
                            txtTelefon.Text = p.telefon;
                            txtEposta.Text = p.eposta;
                            //txtUnvan.Text = p.unvan;
                        }
                    }
                    else
                    {
                        lblBilgilendirme.Text = "Lütfen Şifreyi Doğru Girdiğinizden emin olunuz...";
                    }
                }
                else
                {
                    Response.Redirect("OgrLogin.aspx");
                }
                txtSifreD.Text = "";

            }
        }

        protected void btnKapat_Click(object sender, EventArgs e)
        {

        }

        protected void btnYukle_Click(object sender, EventArgs e)
        {
            if (txtTelefon.Text == "" || txtEposta.Text == "")
            {
                lblBilgilendirme.Text = "Lütfen İlgili Alanları Doldurduğunuzdan Emin Olun...";
            }
            else
            {
                if (Session["OrgNo"] != null)
                {
                    string OrgNo = Session["OrgNo"].ToString();

                    var qprof = from p in ctx.tblOgr_Ogrenci where (p.Ogr_No == OrgNo) select p;
                    foreach (var p in qprof)
                    {
                        p.Ogr_telefon = txtTelefon.Text;
                        p.Ogr_Eposta = txtEposta.Text;
                    }
                    ctx.SaveChanges();
                }
                else
                {
                    Response.Redirect("OgrLogin.aspx");
                }
            }
        }
        //Şifre doğrulama metodu
        private bool IsvalidUser(string password)
        {

            string OrgNo = Session["OrgNo"].ToString();
            var q1 = from p in ctx.tblOgr_Ogrenci
                     where p.Ogr_No == OrgNo
                     select new { pas = p.Ogr_Password };
            string[] pass = new string[1];
            foreach (var p in q1)
            {
                pass[0] = p.pas;
            }
            if (pass[0] == password)
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