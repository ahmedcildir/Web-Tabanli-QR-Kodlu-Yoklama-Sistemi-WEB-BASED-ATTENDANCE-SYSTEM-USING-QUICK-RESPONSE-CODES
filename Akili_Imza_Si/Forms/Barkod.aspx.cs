using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ZXing;

namespace Akili_Imza_Si
{
    public partial class Barkod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"].ToString() != null)
            {


                if (Session["QR"].ToString() != null)
                {
                    string QR = Session["QR"].ToString();
                    GeneratCode(QR);
                }
                else
                {
                    Response.Redirect("imzaUret.aspx");
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            
        }

        private void GeneratCode(string name)
        {
            var write = new BarcodeWriter();
            write.Format = BarcodeFormat.QR_CODE;
            var result = write.Write(name);
            string path = Server.MapPath("~/Forms/images/QRImage.jpg");
            var barcodeBitmap = new Bitmap(result);


            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    barcodeBitmap.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);

                }
            }

            ImgQRCode.Visible = true;
            ImgQRCode.ImageUrl = "~/Forms/images/QRImage.jpg";
        }

        private void ReadCode()
        {
            var reader = new BarcodeReader();
            string filename = Path.Combine(Request.MapPath("~/Forms/images"), "QRImage.jpg");
            var result = reader.Decode(new Bitmap(filename));
            if (result != null)
            {
               // lblQRCode.Text = "QR KODU : " + result.Text;
            }
        }

    }
}