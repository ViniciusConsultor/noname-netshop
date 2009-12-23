using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NoName.NetShop.CMS.Config;
using System.Configuration;

namespace NoName.NetShop.BackFlat.CMS.Page.PublicContent
{
    public partial class List : System.Web.UI.Page
    {
        private PublicContentSection config = (PublicContentSection)ConfigurationManager.GetSection("publicContent");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            GridView1.DataSource = GetPublicContentList();
            GridView1.DataBind();
        }

        private DataTable GetPublicContentList()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("key");
            dt.Columns.Add("name");
            dt.Columns.Add("path");

            foreach (PublicContentElement element in config.PublicPages)
            {
                DataRow row = dt.NewRow();

                row["key"] = element.Key;
                row["name"] = element.Name;
                row["path"] = element.FileName;

                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
