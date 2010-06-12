using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.GroupShopping.BLL;
using NoName.Utility;
using NoName.NetShop.GroupShopping.Model;

namespace NoName.NetShop.BackFlat.Group
{
    public partial class Applies : System.Web.UI.Page
    {
        private int ProductID
        {
            get { if (ViewState["ProductID"] != null) return Convert.ToInt32(ViewState["ProductID"]); else return -1; }
            set { ViewState["ProductID"]=value; }
        }
        private GroupApplyBll bll = new GroupApplyBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["productid"])) ProductID = Convert.ToInt32(Request.QueryString["productid"]);
            else throw new ArgumentNullException("productid");
            if (!IsPostBack)
            {
                BindData(1);
            }
        }

        private void BindData(int PageIndex)
        {
            GroupProductModel model = new GroupProductBll().GetModel(ProductID);

            Literal_ProductName.Text = model.ProductName;

            int RecordCount = 0;
            GridView1.DataSource = bll.GetList(PageIndex, AspNetPager.PageSize, " and groupproductid = " + ProductID, out RecordCount);
            GridView1.DataBind();

            AspNetPager.RecordCount = RecordCount;
        }

        protected void AspNetPager_PageChanged(object sender, PageChangedEventArgs e)
        {
            AspNetPager.CurrentPageIndex = e.NewPageIndex;
            BindData(e.NewPageIndex);
        }

        protected void GridView1_RowCommand(object sender,GridViewCommandEventArgs e)
        {
            if(e.CommandName.ToLower()=="a")
            {
                int ApplyID = Convert.ToInt32(e.CommandArgument);
                bll.UpdateStatus(ApplyID, (int)GroupProductApplyStatus.已批准);
                BindData(AspNetPager.CurrentPageIndex);
            }

            if (e.CommandName.ToLower() == "r")
            {
                int ApplyID = Convert.ToInt32(e.CommandArgument);
                bll.UpdateStatus(ApplyID, (int)GroupProductApplyStatus.已驳回);
                BindData(AspNetPager.CurrentPageIndex);
            }
        }
    }
}
