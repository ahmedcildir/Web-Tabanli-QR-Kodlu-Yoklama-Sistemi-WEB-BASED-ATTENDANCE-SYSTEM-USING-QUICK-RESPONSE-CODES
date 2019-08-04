using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.Forms
{
    public partial class Profil : System.Web.UI.Page
    {
        //public string kad, tel, epo, un;
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["id"] != null && Session["Login_onay"].ToString() == "OK")
            {
                int id = int.Parse(Session["id"].ToString());
                var qprofil = from p in ctx.tblUsers
                              where (p.Id == id)
                              select new
                              {
                                  ad = p.Ad,
                                  soyad = p.Soyad,
                                  tc = p.Tc,
                                  dogumtarihi = p.D_Tarihi,
                                  foto = p.Fotograf
                              };
                foreach (var p in qprofil)
                {
                    lblAd.Text = p.ad + " " + p.soyad;
                    lblTc.Text = p.tc;
                    lblDogumTarihi.Text = p.dogumtarihi;
                    imgfoto.ImageUrl = p.foto;
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }


        //bilgileri Güncelleme
        protected void btnYukle_Click1(object sender, EventArgs e)
        {
            if (txtKullanıcıAd.Text=="" || txtTelefon.Text == "" || txtEposta.Text == "")
            {
                Response.Write("<script>alert('Lütfen İlgili Alanları Doldurduğunuzdan Emin Olun...');</script>");
            }
            else
            {
                if (Session["id"] != null)
                {
                    int id = int.Parse(Session["id"].ToString());

                    var qprof = from p in ctx.tblUsers where (p.Id == id) select p;
                    foreach (var p in qprof)
                    {
                        p.Kullanici_Adi = txtKullanıcıAd.Text;
                        p.Telefon = txtTelefon.Text;
                        p.E_posta = txtEposta.Text;
                        //p.Unvani = txtUnvan.Text;
                    }
                    ctx.SaveChanges();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
           
        }

        //Fotoğraf güncelleme
        protected void btnfoto_Click(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                int id = int.Parse(Session["id"].ToString());
                if (resimyukle.HasFile)
                {
                    string fileName = resimyukle.FileName;
                    Guid G = Guid.NewGuid();
                    string yol = G + "-u-" + resimyukle.FileName;
                    imgfoto.ImageUrl = "~/Forms/images/" + yol;
                    resimyukle.SaveAs(Server.MapPath("~/Forms/images/" + yol));

                    var resim = ctx.tblUsers.First(x => x.Id == id);
                    resim.Fotograf = "~/Forms/images/" + yol;
                    ctx.SaveChanges();
                }
                else
                {
                    Response.Write("Lütfen Yüklenecek Bir Resim Seçiniz.");
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }


        //Şifre doğrulama metodu
        private bool IsvalidUser(string password)
        {

            int id = int.Parse(Session["id"].ToString());
            var q1 = from p in ctx.tblUsers
                     where p.Id == id
                     select new { pas = p.Password };
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

        //Kullanıcı Bilgilerini şifre ile doğrulayarak getir
        protected void btnBGetir_Click(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                if (IsvalidUser(txtSifreD.Text))
                {
                    int id = int.Parse(Session["id"].ToString());
                    var qprofil = from p in ctx.tblUsers
                                  where (p.Id == id)
                                  select new
                                  {
                                      kulaniciad = p.Kullanici_Adi,
                                      telefon = p.Telefon,
                                      eposta = p.E_posta,
                                      //unvan = p.Unvani,
                                  };
                    foreach (var p in qprofil)
                    {
                        txtKullanıcıAd.Text = p.kulaniciad;
                        txtTelefon.Text = p.telefon;
                        txtEposta.Text = p.eposta;
                        //txtUnvan.Text = p.unvan;
                    }
                }
                else
                {
                    Response.Write("<script>alert('Lütfen Şifreyi Girdiğinizden emin olunuz...');</script>");
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            txtSifreD.Text = "";
        }
    }
}