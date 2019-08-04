using Akili_Imza_Si.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Akili_Imza_Si.idari
{
    public partial class idariProfil : System.Web.UI.Page
    {
        imzaSistemiDBContext ctx = new imzaSistemiDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnBGetir.UniqueID;
            if (Session["iid"] != null && Session["Login_onay1"].ToString() == "OK")
            {
                int id = int.Parse(Session["iid"].ToString());
                var qprofil = from p in ctx.tbIdariPersonels
                              where (p.PID == id)
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
                Response.Redirect("idariLogin.aspx");
            }
        }
        //Şifre doğrulama metodu
        private bool IsvalidUser(string password)
        {

            int id = int.Parse(Session["iid"].ToString());
            var q1 = from p in ctx.tbIdariPersonels
                     where p.PID == id
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

        //Fotoğraf güncelleme
        protected void btnfoto_Click(object sender, EventArgs e)
        {
            if (Session["iid"] != null)
            {
                int id = int.Parse(Session["iid"].ToString());
                if (resimyukle.HasFile)
                {
                    string fileName = resimyukle.FileName;
                    Guid G = Guid.NewGuid();
                    string yol = G + "-u-" + resimyukle.FileName;
                    imgfoto.ImageUrl = "~/idari/images/" + yol;
                    resimyukle.SaveAs(Server.MapPath("~/idari/images/" + yol));

                    var resim = ctx.tbIdariPersonels.First(x => x.PID == id);
                    resim.Fotograf = "~/idari/images/" + yol;
                    ctx.SaveChanges();
                }
                else
                {
                    Response.Write("Lütfen Yüklenecek Bir Resim Seçiniz.");
                }
            }
            else
            {
                Response.Redirect("idariLogin.aspx");
            }
        }

        //bilgileri Güncelleme
        protected void btnYukle_Click(object sender, EventArgs e)
        {
            if (txtKullanıcıAd.Text == "" || txtTelefon.Text == "" || txtEposta.Text == "")
            {
                Response.Write("<script>alert('Lütfen İlgili Alanları Doldurduğunuzdan Emin Olun...');</script>");
            }
            else
            {
                if (Session["iid"] != null)
                {
                    int id = int.Parse(Session["iid"].ToString());

                    var qprof = from p in ctx.tbIdariPersonels where (p.PID == id) select p;
                    foreach (var p in qprof)
                    {
                        p.Kullanici_Ad = txtKullanıcıAd.Text;
                        p.Telefon = txtTelefon.Text;
                        p.E_posta = txtEposta.Text;
                        //p.Gorev = txtUnvan.Text;
                    }
                    ctx.SaveChanges();
                    Response.Write("<script>alert('Bilgileriniz Başarılı Bir Şekilde Güncellendi...');</script>");

                }
                else
                {
                    Response.Redirect("idariLogin.aspx");
                }
            }
        }

        //Kullanıcı Bilgilerini şifre ile doğrulayarak getir
        protected void btnBGetir_Click(object sender, EventArgs e)
        {
            if (Session["iid"] != null)
            {
                if (IsvalidUser(txtSifreD.Text))
                {
                    int id = int.Parse(Session["iid"].ToString());
                    var qprofil = from p in ctx.tbIdariPersonels
                                  where (p.PID == id)
                                  select new
                                  {
                                      kulaniciad = p.Kullanici_Ad,
                                      telefon = p.Telefon,
                                      eposta = p.E_posta,
                                      //unvan = p.Gorev,
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
                Response.Redirect("idariLogin.aspx");
            }
            txtSifreD.Text = "";
        }
    }
}