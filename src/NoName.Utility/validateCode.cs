using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Drawing;
namespace NoName.Utility
{
    public class validateCode : System.Web.UI.Page
    {

        /// <returns>����һ��������ַ���</returns>
        public string RandNum(int VcodeNum)
        {
            string Vchar = "0,1,2,3,4,5,6,7,8,9";
            string[] VcArray = Vchar.Split(',');//��ֳ�����
            string VNum = "";
            int temp = -1;//��¼�ϴ������ֵ�������ܱ�����������һ���������
            Random rand = new Random();
            //����һ���򵥵��㷨�Ա�֤����������Ĳ�ͬ
            for (int i = 0; i < VcodeNum; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(VcArray.Length - 1);
                if (temp != -1 && temp == t)
                {
                    return RandNum(VcodeNum);
                }
                temp = t;
                VNum += VcArray[t];
            }
            return VNum;
        }
        /// ����ͼƬ��д���ַ�
        public void ValidateCode(string VNum, int w, int h, string font, int fontSize, string bgColor)
        {
            Bitmap Img = new Bitmap(w, h);//����ͼ���ʵ��
            Graphics g = Graphics.FromImage(Img);//��Img���������µ�Graphics����
            g.Clear(ColorTranslator.FromHtml(bgColor));//������ɫ
            Font f = new Font(font, fontSize);//����Font���ʵ��
            SolidBrush s = new SolidBrush(Color.Black);//���ɱ�ˢ���ʵ��
            g.DrawString(VNum, f, s, 3, 3);//��VNumд��ͼƬ��
            Img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);//����ͼ����Jpegͼ���ļ��ĸ�ʽ���浽����
            Response.ContentType = "image/Jpeg";
            //������Դ
            g.Dispose();
            Img.Dispose();
            Response.End();
        }
    }
    //���÷���
    //Session["code"] = RandNum(4);
    //ValidateCode(Session["code"].ToString(), 40, 20, "����", 10, "#FFFFFF");

}