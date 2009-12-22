using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.Utility;
using NoName.NetShop.MagicWorld.BLL;

namespace NoName.NetShop.BackFlat.MagicWorld.Rent
{
    public partial class LogList : System.Web.UI.Page
    {
        private int RentID
        {
            get { if (ViewState["rentid"] != null) return Convert.ToInt32(ViewState["rentid"]); else return -1; }
            set { ViewState["rentid"] = value; }
        }
        private RentLogBll bll = new RentLogBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["rentid"])) RentID = Convert.ToInt32(Request.QueryString["rentid"]);
                BindData(1);
            }
        }

        protected void BindData(int PageIndex)
        {
            if (RentID != -1)
            {
                int RecordCount = 0;
                GridView1.DataSource = bll.GetListOfProduct(PageIndex, AspNetPager.PageSize, RentID, out RecordCount);
                GridView1.DataBind();

                AspNetPager.RecordCount = RecordCount;
            }
        }

        protected void GridView1_RowCommand(object sender,GridViewCommandEventArgs e)
        {

        }
        
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e) 
        {

        }
        
        protected void AspNetPager_PageChanged(object src, PageChangedEventArgs e)
        {
            AspNetPager.CurrentPageIndex = e.NewPageIndex;
            BindData(AspNetPager.CurrentPageIndex);
        }
    }
}
