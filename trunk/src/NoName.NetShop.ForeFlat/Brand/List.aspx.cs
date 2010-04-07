using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.Utility;
using NoName.NetShop.Product.BLL;
using System.Data;
using NoName.NetShop.Common;

namespace NoName.NetShop.ForeFlat.Brand
{
    public partial class List : System.Web.UI.Page
    {
        private BrandModelBll bll = new BrandModelBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData(1);
            }
        }

        private void BindData(int PageIndex)
        {
            int RecordCount = 0;
            DataTable dt = bll.GetList(PageIndex, AspNetPager.PageSize, String.Empty,out RecordCount).Tables[0];

            foreach (DataRow row in dt.Rows)
                row["brandlogo"] = CommonImageUpload.GetCommonImageFullUrl(Convert.ToString(row["brandlogo"]));


            Repeater_Brand.DataSource = dt;
            Repeater_Brand.DataBind();

            AspNetPager.RecordCount = RecordCount;
        }

        protected void AspNetPager_PageChanged(object sender,PageChangedEventArgs e)
        {
            AspNetPager.CurrentPageIndex = e.NewPageIndex;
            BindData(AspNetPager.CurrentPageIndex);
        }
    }
}
