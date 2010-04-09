using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using NoName.NetShop.CMS.Config;
using System.Configuration;

namespace NoName.NetShop.BackFlat.CMS.Page.PublicContent
{
    public partial class Edit : System.Web.UI.Page
    {
        private string Key
        {
            get { if (ViewState["key"] != null) return ViewState["key"].ToString(); else return String.Empty; }
            set { ViewState["key"] = value; }
        }
        private PublicContentSection config = (PublicContentSection)ConfigurationManager.GetSection("publicContent");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["k"])) Key = Request.QueryString["k"];
                BindData();
            }
        }

        private void BindData()
        {
            PublicContentElement element = config.PublicPages[Key];

            ContentTitle.InnerText = element.Name;
            TextBox_Content.Text = ReadFile(element.FileName);
        }

        protected void Button_Publish_Click(object sender, EventArgs e)
        {
            PublicContentElement element = config.PublicPages[Key];

            WriteFile(element.FileName, TextBox_Content.Text);

            Response.Redirect("List.aspx");
        }


        private string ReadFile(string FileName)
        {
            FileInfo f = new FileInfo(FileName);
            if (!f.Exists) return String.Empty;
            StreamReader sr = new StreamReader(FileName, Encoding.UTF8);
            string temp = sr.ReadToEnd();
            sr.Close();

            return temp;
        }
        private void WriteFile(string FileName, string Content)
        {
            FileInfo f = new FileInfo(FileName);
            if (!f.Directory.Exists) f.Directory.Create();
            StreamWriter sw = new StreamWriter(FileName, false, Encoding.UTF8);
            sw.Write(Content);
            sw.Flush();
            sw.Close();
        }
    }
}
