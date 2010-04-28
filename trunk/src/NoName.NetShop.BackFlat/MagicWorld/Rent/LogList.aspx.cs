using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.Utility;
using NoName.NetShop.MagicWorld.BLL;
using NoName.NetShop.MagicWorld.Model;
using System.Data;

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

                DataTable dt = bll.GetListOfProduct(PageIndex, AspNetPager.PageSize, RentID, out RecordCount);
                if (dt.Rows.Count > 0) Div_Notify.Visible = false;
                GridView1.DataSource = dt;
                GridView1.DataBind();

                AspNetPager.RecordCount = RecordCount;
            }
        }

        protected void GridView1_RowCommand(object sender,GridViewCommandEventArgs e)
        {
            if (e.CommandName == "p")
            {
                RentProductBll pBll = new RentProductBll();
                RentLogModel log = bll.GetModel(Convert.ToInt32(e.CommandArgument));
                               

                pBll.UpdateStatus(log.RentID, (int)RentProductStatus.已出租);
                bll.UpdateStatus(log.RentLogID, (int)RentLogStatus.已确认);
            }
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
