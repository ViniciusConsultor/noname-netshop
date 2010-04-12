using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;

namespace NoName.NetShop.ForeFlat.Solution
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            //string XmlPath = Server.MapPath("/flash/ComponentList.xml");

            //XmlDocument xdoc = new XmlDocument();
            //xdoc.Load(XmlPath);

            //DataTable dt = new DataTable();
            //dt.Columns.Add("scenceid");
            //dt.Columns.Add("scencename");
            //dt.Columns.Add("position");


        }
    }
}
