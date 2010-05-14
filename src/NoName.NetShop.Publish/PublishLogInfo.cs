using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.Publish
{
    public class PublishLogInfo
    {
        public string IP { get; set; }
        public DateTime RequestStartTime { get; set; }
        public string RequtstUrl { get; set; }
        public string RemoteName { get; set; }//
        public string UserAgent { get; set; }
        public string Referer { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsRedirect { get; set; }
        public string RedirectUrl { get; set; }
        public string PageFile { get; set; }
        public bool IsPageFileValidate { get; set; }
        public DateTime RequestEndTime { get; set; }
        public TimeSpan ProcessTime { get; set; }
        public string Server { get; set; }
        public string Extend { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(String.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13}\t{14}",
                String.IsNullOrEmpty(this.IP) ? " " : this.IP,
                this.RequestStartTime.ToString("yyyy-MM-dd hh:mm:ss"),
                String.IsNullOrEmpty(this.RequtstUrl) ? "--" : this.RequtstUrl,
                String.IsNullOrEmpty(this.UserAgent) ? "--" : this.UserAgent,
                String.IsNullOrEmpty(this.Referer) ? "--" : this.Referer,
                this.IsSuccess,
                String.IsNullOrEmpty(this.ErrorMessage) ? "--" : this.ErrorMessage,
                this.IsRedirect,
                String.IsNullOrEmpty(this.RedirectUrl) ? "--" : this.RedirectUrl,
                String.IsNullOrEmpty(this.PageFile) ? "--" : this.PageFile,
                this.IsPageFileValidate,
                this.RequestEndTime.ToString("yyyy-MM-dd hh:mm:ss"),
                this.ProcessTime,
                String.IsNullOrEmpty(this.Server) ? "--" : this.Server,
                String.IsNullOrEmpty(this.Extend) ? "--" : this.Extend
                ));

            return sb.ToString();
        }
    }
}
