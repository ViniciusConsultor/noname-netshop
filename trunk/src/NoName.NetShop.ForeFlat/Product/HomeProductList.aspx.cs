using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.Utility;
using NoName.NetShop.Product.BLL;
using System.Data;
using NoName.NetShop.Product.Model;
using NoName.NetShop.Product.Facade;
using NoName.NetShop.CMS.Controler;
using System.Web.UI.HtmlControls;

namespace NoName.NetShop.ForeFlat.Product
{
    public partial class HomeProductList : System.Web.UI.Page
    {
        private SalesProductModelBll bll = new SalesProductModelBll();
        private SalesProductType SalesType
        {
            get { if (ViewState["SalesType"] != null) return (SalesProductType)Enum.Parse(typeof(SalesProductType), Convert.ToString(ViewState["SalesType"])); else return SalesProductType.热销商品; }
            set { ViewState["SalesType"] = (int)value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["type"])) SalesType = (SalesProductType)Enum.Parse(typeof(SalesProductType), Request.QueryString["type"]);
                BindData(1);
                DivLeft.InnerHtml = GetLeftHtmlCode();
            }
        }

        private void BindData(int PageIndex)
        {
            int RecordCount = 0;
            DataTable dt = bll.GetProductList(AspNetPager.PageSize, PageIndex, SalesType, out RecordCount);
            dt.Columns.Add("price");

            foreach(DataRow row in dt.Rows) 
            {
                row["smallimage"] = ProductMainImageRule.GetMainImageUrl(Convert.ToString(row["smallimage"]));
                row["mediumimage"] = ProductMainImageRule.GetMainImageUrl(Convert.ToString(row["mediumimage"]));
                row["largeimage"] = ProductMainImageRule.GetMainImageUrl(Convert.ToString(row["largeimage"]));
                row["price"] = Convert.ToString(Convert.ToDecimal(row["MerchantPrice"]) - Convert.ToDecimal(row["reduceprice"]));
            }

            Repeater_Product.DataSource = dt;
            Repeater_Product.DataBind();

            Literal_SalesName1.Text = SalesType.ToString();
            Literal_SalesName2.Text = SalesType.ToString();

            switch (SalesType)
            {
                case SalesProductType.热销商品:
                    HyperLink1.CssClass = "button_blue2";
                    break;
                case SalesProductType.直降特卖:
                    HyperLink2.CssClass = "button_blue2";
                    break;
                case SalesProductType.鼎鼎推荐:
                    HyperLink3.CssClass = "button_blue2";
                    break;
                default:
                    HyperLink1.CssClass = "button_blue2";
                    break;
            }
        }

        protected void AspNetPager_PageChanged(object sender, PageChangedEventArgs e)
        {
            AspNetPager.CurrentPageIndex = e.NewPageIndex;
            BindData(AspNetPager.CurrentPageIndex);
        }

        private string GetLeftHtmlCode() 
        {
            string HtmlCode = String.Empty;

            HtmlCode+=TagControler.TagContentGet(1, 1, "cmsTag3");
            HtmlCode+=TagControler.TagContentGet(1, 1, "cmsTag4");

            return HtmlCode;
        }
    }
}
