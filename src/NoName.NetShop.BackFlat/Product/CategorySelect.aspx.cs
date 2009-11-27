using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoName.NetShop.BackFlat.Product
{
    public partial class CategorySelect : System.Web.UI.Page
    {
        public int IntialisedCategoryID
        {
            get { if (ViewState["IntialisedCategoryID"] != null) return Convert.ToInt32(ViewState["IntialisedCategoryID"]); else return -1; }
            set { ViewState["IntialisedCategoryID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["cid"])) IntialisedCategoryID = Convert.ToInt32(Request.QueryString["cid"]);
                if (IntialisedCategoryID != -1) CategoryListBox1.InitialCategoryID = IntialisedCategoryID;
            }
        }

        protected void Button_OK_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["pid"]))
            {
                Response.Redirect(String.Format("edit.aspx?ProductID={0}&CategoryID={1}", Request.QueryString["pid"], CategoryListBox1.SelectedCategoryID));
            }
            else
            {
                Response.Redirect(String.Format("add.aspx?CategoryID={0}",CategoryListBox1.SelectedCategoryID));
            }
        }
    }
}
