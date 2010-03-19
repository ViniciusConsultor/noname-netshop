using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using NoName.NetShop.Solution.BLL;
using NoName.NetShop.Solution.Model;
using NoName.Utility;
using System.Data;
using NoName.NetShop.Product.Facade;

namespace NoName.NetShop.ForeFlat.Solution
{
    public partial class DIY : System.Web.UI.Page
    {
        public int ScenceID
        {
            get { if (ViewState["ScenceID"] != null) return Convert.ToInt32(ViewState["ScenceID"]); else return -1; }
            set { ViewState["ScenceID"] = value; }
        }
        private ArrayList CategoryIDs
        {
            get { if (ViewState["CategoryIDs"] != null) return (ArrayList)ViewState["CategoryIDs"]; else return null; }
            set { ViewState["CategoryIDs"] = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["ids"])) ScenceID = Convert.ToInt32(Request.QueryString["ids"]);

                if (ScenceID!=-1)
                {
                    BindCategoryData();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        private void BindCategoryData()
        {
            List<SolutionCategoryModel> Categories =  new SolutionCategoryBll().GetModelList("senceid = "+ScenceID);

            //Repeater_ConfigCategory.DataSource = Categories;
            //Repeater_ConfigCategory.DataBind();
            //Repeater_Category.DataSource = Categories;
            //Repeater_Category.DataBind();
        }

        //private void BindData(int PageIndex)
        //{
        //    CategoryConditionBll bll = new CategoryConditionBll();
        //    int RecordCount = 0;
        //    DataTable dt = new DataTable();//bll.GetCategoryProductList(PageIndex, AspNetPager.PageSize, CurrentCategoryID, out RecordCount);
        //    foreach(DataRow row in dt.Rows)
        //    {
        //        row["smallimage"] = ProductMainImageRule.GetMainImageUrl(Convert.ToString(row["smallimage"]));
        //        row["mediumimage"] = ProductMainImageRule.GetMainImageUrl(Convert.ToString(row["mediumimage"]));
        //        row["largeimage"] = ProductMainImageRule.GetMainImageUrl(Convert.ToString(row["largeimage"]));
        //    }

        //    Repeater_Product.DataSource = dt;
        //    Repeater_Product.DataBind();
        //}


        //protected void AspNetPager_PageChanged(object src, PageChangedEventArgs e)
        //{
        //    AspNetPager.CurrentPageIndex = e.NewPageIndex;
        //    BindData(AspNetPager.CurrentPageIndex);
        //}
    }
}
