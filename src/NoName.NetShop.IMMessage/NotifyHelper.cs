using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Collections;
using System.Net;

namespace NoName.NetShop.IMMessage
{
    public class NotifyHelper
    {
        public static void SendMail(string to, string subject, string content)
        {
            Hashtable smtpcfg = (Hashtable)System.Configuration.ConfigurationManager.GetSection("shopping/smtp");

            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress(to));
            msg.CC.Add((string)smtpcfg["cc"]);
            msg.From = new MailAddress((string)smtpcfg["from"], (string)smtpcfg["fromname"]);
            msg.Body = content;
            msg.IsBodyHtml = true;
            msg.Subject = subject;
            msg.ReplyTo = new MailAddress((string)smtpcfg["reply"]);

            SmtpClient sc = new SmtpClient();
            sc.Host = smtpcfg["domain"].ToString();
            sc.Port = int.Parse(smtpcfg["port"].ToString());
            sc.Credentials = new NetworkCredential((string)smtpcfg["username"], (string)smtpcfg["password"]);
            sc.Send(msg);

        }

        public static void SendMessage(string to, string subject, string content)
        {
            MessageBll mbll = new MessageBll();
            MessageModel model = new MessageModel();
            model.MsgId = 0;
            model.MsgType = 0;
            model.UserId = to;
            model.SenderId = "鼎鼎商城";
            model.Subject = subject;
            model.Content = content;
            model.UserType = 0; // 默认为前台用户
            mbll.Add(model);

        }

    }
}
