using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Common;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace NoName.NetShop.ForeFlat
{
    public partial class ValiateCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Random ran = new Random();
            //int seed = ran.Next(1000);
            //string text = GenerateRandomString(4, RandomStringMode.Mix);
            //Session["ValidateCode"] = text;

            //ShowValidationCode(ref seed, text, 12, Color.Black, Color.White);
            ValidateHelper vhelper = new ValidateHelper();
            string checkCode = vhelper.CreateCode(4);
            Response.Clear();
            Response.ContentType = "image/jpeg";
            CreateImages(checkCode);
            Response.End();
        }

        /*产生验证图片*/
        public void CreateImages(string code)
        {
            int fontsize = 20;

            int width = code.Length * fontsize;
            int height = fontsize + 8;

            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(bmp);
            HatchBrush b = new HatchBrush(HatchStyle.DiagonalCross, Color.LightGray, Color.WhiteSmoke);
            g.FillRectangle(b, 0, 0, width, height);

            Random random = new Random();
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
            new Rectangle(0, 0, bmp.Width, bmp.Height), Color.Black, Color.FromArgb(120, 120, 120), 20.0f, true);

            g.DrawString(code, new Font("Courier New", fontsize, FontStyle.Bold), brush, 2.0F, 1.0F);

            //画图片的前景噪音点 
            for (int i = 0; i < 50; i++)
            {
                int x = random.Next(bmp.Width);
                int y = random.Next(bmp.Height);
                bmp.SetPixel(x, y, Color.Green);
            }

            bmp.Save(Response.OutputStream, ImageFormat.Jpeg);
            b.Dispose();
            g.Dispose();
            bmp.Dispose();
        }

    }
}
