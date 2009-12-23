using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using NoName.NetShop.CMS.Model;
using NoName.NetShop.CMS.Controler;

namespace NoName.NetShop.BackFlat.CMS.Template
{
    public class Template : System.Web.UI.Page
    {
        private int PageID
        {
            get { if (ViewState["pageid"] == null) return -1; else return int.Parse(ViewState["pageid"].ToString()); }
            set { ViewState["pageid"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            PageID = int.Parse(Request.QueryString["pageid"]);
            if (!IsPostBack)
            {
                Stream PageStream = new ResponseFilter(Response.Filter);

                Response.Filter = PageStream;

                PageModel page = PageControler.GetModel(PageID);

                this.Title = page.PageTitle;
            }
        }
    }

    public class ResponseFilter : Stream
    {
        #region properties
        Stream responseStream;
        long position;
        public StringBuilder html = new StringBuilder();
        #endregion

        #region constructor
        public ResponseFilter(Stream inputStream)
        {
            responseStream = inputStream;
        }
        #endregion

        #region implemented abstract members

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return true; }
        }

        public override void Close()
        {
            responseStream.Close();
        }

        public override void Flush()
        {
            responseStream.Flush();
        }

        public override long Length
        {
            get { return 0; }
        }

        public override long Position
        {
            get { return position; }
            set { position = value; }
        }

        public override long Seek(long offset, System.IO.SeekOrigin direction)
        {
            return responseStream.Seek(offset, direction);
        }

        public override void SetLength(long length)
        {
            responseStream.SetLength(length);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return responseStream.Read(buffer, offset, count);
        }

        #endregion

        #region write method

        public override void Write(byte[] buffer, int offset, int count)
        {
            string sBuffer = System.Text.UTF8Encoding.UTF8.GetString(buffer, offset, count);

            string pattern = @"<form.+> </form> <input.+__VIEWSTATE.+/> <div>(\s|\n|\r)+</div> ^(\n|\r)";

            string[] s = pattern.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string s1 in s)
            {
                sBuffer = Regex.Replace(sBuffer, s1, "");
            }

            byte[] data = System.Text.UTF8Encoding.UTF8.GetBytes(sBuffer);
            responseStream.Write(data, 0, data.Length);
        }

        #endregion
    }
}
