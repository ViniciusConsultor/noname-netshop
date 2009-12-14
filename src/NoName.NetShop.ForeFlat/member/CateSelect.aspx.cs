using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoName.NetShop.ForeFlat.member
{
    public partial class CateSelect : System.Web.UI.Page
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
                if (IntialisedCategoryID != -1) MagicWorldCategorySelect1.InitialCategoryID = IntialisedCategoryID;
            }
        }

        protected void Button_OK_Click(object sender, EventArgs e)
        {
            string App = Request.QueryString["app"].ToLower();

            if (!String.IsNullOrEmpty(Request.QueryString["pid"]))
            {
                Response.Redirect(String.Format("{0}/edit.aspx?ProductID={1}&CategoryID={2}", App, Request.QueryString["pid"], MagicWorldCategorySelect1.SelectedCategoryID));
            }
            else
            {
                Response.Redirect(String.Format("{0}/add.aspx?CategoryID={1}", App, MagicWorldCategorySelect1.SelectedCategoryID));
            }
        }
    }
}
