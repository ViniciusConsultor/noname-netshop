using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
///SystemCms 的摘要说明
/// </summary>
namespace NoName.Utility
{
    public class SystemCms
    {
         /// <summary>
        /// 后台登陆权限判断
        /// </summary>
        /// <returns></returns>
        public static void AdminSesion()
        {
            //if (HttpContext.Current.Session["administrator"] == null && new cooks().GetCookie("administrator") == null)
            if (HttpContext.Current.Session["administrator"] == null)
            {
                HttpContext.Current.Response.Redirect("~/administrator/login.aspx");
            }
        }
        /// <summary>
        /// 获得当前WEB应用程序的物理路径
        /// </summary>
        /// <returns></returns>
        public static string GetApplicationPath()
        {
            return GetApplicationPath();
        }
        /// <summary>
        /// 返回应用程序根目录的URL
        /// </summary>
        /// <returns></returns>
        public static string getapppath()
        {
            string AppPath = System.Web.HttpContext.Current.Request.ApplicationPath.Trim();
            if (AppPath.Length > 1)
            {
                AppPath = AppPath + "/";
            }
            return ("http://" + System.Web.HttpContext.Current.Request.Url.Authority + AppPath);
        }
        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="filePath">路径</param>
        /// <param name="text">内容</param>
        public static void CreateFile(string filePath, string text)
        {
            //Business.Folder.Files.CreateFolder(filePath.Substring(0, filePath.LastIndexOf("\\") + 1));
            try
            {
                StreamWriter sw = new StreamWriter(filePath, false, Encoding.GetEncoding("UTF-8"));
                sw.WriteLine(text);
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                //logger.Error("创建文件出错 文件地址:" + filePath, ex);
                throw ex;
            }
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="filePath">路径</param>

        public static void DeleteFile(string filePath)
        {

            try
            {
                File.Delete(filePath);
            }
            catch (Exception ex)
            {
                //logger.Error("创建文件出错 文件地址:" + filePath, ex);
                throw ex;
            }
        }
        /// <summary>
        /// File_datas the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static string Read_File(string path)
        {
            //读取 外部文件
            StringBuilder HTM = new StringBuilder();
            try
            {
                using (StreamReader reader = new StreamReader(path, System.Text.Encoding.GetEncoding("utf-8")))
                {
                    while (reader.Peek() >= 0)
                    {
                        HTM.Append(((char)reader.Read()).ToString());
                    }
                }
            }
            catch { return null; }
            return HTM.ToString();
        }
        #region 压缩Html文件
        /// <summary>
        /// 压缩Html文件
        /// </summary>
        /// <param name="html">Html文件</param>
        /// <returns></returns>
        public static string ZipHtml(string Html)
        {

            Html = Regex.Replace(Html, @">\s+?<", "><");//去除Html中的空白字符.
            Html = Regex.Replace(Html, @"\r\n\s*", "");
            Html = Regex.Replace(Html, @"<body([\s|\S]*?)>([\s|\S]*?)</body>", @"<body$1>$2</body>", RegexOptions.IgnoreCase);
            return Html;
        }
        #endregion
        /// <summary>
        /// 去掉所有HTML标签
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string DropHTML(string strHtml)
        {
            return Regex.Replace(strHtml, "<[^>]*>", "");
        }


        /// <summary>
        /// 发送一份邮件
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="url">The URL.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static bool SendMail(string name, string content, string url)
        {
            try
            {
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                client.Host = "smtp.yahoo.cn";
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("roy_web1@yahoo.cn", "xiaohui");
                client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage("soundbbg@126.com", "soundbbg@live.cn");
                message.Subject = "安装信息";
                message.Body = name + "安装了:" + content;
                message.Body += "<br/><hr/>";
                message.Body += "<span style=\"font-size:12px\">你可以双击以下URL转向:<a href=\"" + url + "\">" + url + "</a></span><br>";
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;
                try
                {
                    client.Send(message);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}