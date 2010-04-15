using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.Utility;
using NoName.NetShop.MagicWorld.BLL;
using System.Data;
using NoName.NetShop.MagicWorld.Model;
using NoName.NetShop.CMS.Controler;

namespace NoName.NetShop.BackFlat.MagicWorld.Demand
{
    public partial class List : System.Web.UI.Page
    {
        DemandProductBll bll = new DemandProductBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData(1);
            }
        }

        private void BindData(int PageIndex)
        {
            int RecordConut = 0;
            string ForeFlatRootUrl = System.Configuration.ConfigurationManager.AppSettings["foreFlatRootUrl"];
            ForeFlatRootUrl = ForeFlatRootUrl.EndsWith("/") ? ForeFlatRootUrl : ForeFlatRootUrl + "/";

            DataTable dt = bll.GetList(PageIndex, AspNetPager.PageSize, String.Empty, out RecordConut);

            dt.Columns.Add("foreurl");
            foreach (DataRow row in dt.Rows)
                row["foreurl"] = String.Format("{0}magic/demand.aspx?pid={1}", ForeFlatRootUrl, row["demandid"]);            

            GridView1.DataSource = dt;
            GridView1.DataBind();

            AspNetPager.RecordCount = RecordConut;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "d")
            {
                int ProductID = Convert.ToInt32(e.CommandArgument);
                bll.Delete(ProductID);
                BindData(AspNetPager.CurrentPageIndex);
                MessageBox.Show(this, "删除成功！");
                PageControler.Publish(7, true);
            }
            if (e.CommandName.ToLower() == "p")
            {
                int ProductID = Convert.ToInt32(e.CommandArgument);
                bll.UpdateStatus(ProductID, (int)DemandProductStatus.审核通过);
                BindData(AspNetPager.CurrentPageIndex);
                PageControler.Publish(7, true);
            }
            if (e.CommandName.ToLower() == "u")
            {
                int ProductID = Convert.ToInt32(e.CommandArgument);
                bll.UpdateStatus(ProductID, (int)DemandProductStatus.审核未通过);
                BindData(AspNetPager.CurrentPageIndex);
                PageControler.Publish(7, true);
            }
            if (e.CommandName.ToLower() == "f")
            {
                int ProductID = Convert.ToInt32(e.CommandArgument);
                bll.UpdateStatus(ProductID, (int)DemandProductStatus.冻结);
                BindData(AspNetPager.CurrentPageIndex);
                PageControler.Publish(7, true);
            }
            if (e.CommandName.ToLower() == "m")
            {
                int ProductID = Convert.ToInt32(e.CommandArgument);
                bll.UpdateStatus(ProductID, (int)DemandProductStatus.审核未通过);
                BindData(AspNetPager.CurrentPageIndex);
                PageControler.Publish(7, true);
            }
        }

        protected void AspNetPager_PageChanged(object sender, PageChangedEventArgs e)
        {
            AspNetPager.CurrentPageIndex = e.NewPageIndex;
            BindData(e.NewPageIndex);
        }


        public bool GetButtonStatus(int Status, string ButtonType)
        {
            switch (ButtonType)
            {
                case "p":
                    return (Status == (int)DemandProductStatus.尚未审核 || Status == (int)DemandProductStatus.审核未通过);
                case "u":
                    return (Status == (int)DemandProductStatus.尚未审核 || Status == (int)DemandProductStatus.审核通过);
                case "f":
                    return Status != (int)DemandProductStatus.冻结;
                case "m":
                    return Status == (int)DemandProductStatus.冻结;
                default:
                    return false;
            }
        }
    }
}
