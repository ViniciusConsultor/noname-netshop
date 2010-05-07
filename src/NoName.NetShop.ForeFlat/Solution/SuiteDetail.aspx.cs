using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Solution.Model;
using NoName.NetShop.Solution.BLL;
using System.Data;
using NoName.NetShop.Product.Facade;
using NoName.Utility;

namespace NoName.NetShop.ForeFlat.Solution
{
    public partial class SuiteDetail : System.Web.UI.Page
    {
        private int SuiteID
        {
            get { if (ViewState["SuiteID"] != null) return Convert.ToInt32(ViewState["SuiteID"]); else return -1; }
            set { ViewState["SuiteID"] = value; }
        }
        private SolutionProductBll bll = new SolutionProductBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["suite"])) SuiteID = Convert.ToInt32(Request.QueryString["suite"]);
                else throw new ArgumentNullException();
                BindScenceList();
                BindData();
            }
        }

        private void BindScenceList()
        {
            Repeater_Sence.DataSource = new ScenceBll().GetModelList("sencetype = 0");
            Repeater_Sence.DataBind();
        }

        private void BindData()
        {
            SuiteModel suite = new SuiteBll().GetModel(SuiteID);
            DataTable dt = bll.GetList(SuiteID);

            decimal sumPrice = 0, sumMarketPrice = 0;

            foreach (DataRow row in dt.Rows)
            {
                row["mediumimage"] = ProductMainImageRule.GetMainImageUrl(row["mediumimage"].ToString());
                sumPrice += Convert.ToDecimal(row["price"]);
                sumMarketPrice += Convert.ToDecimal(row["tradeprice"]);
            }

            Repeater_Products.DataSource = dt;
            Repeater_Products.DataBind();

            Literal_SuiteSum.Text = suite.Price.ToString("0.00");
            Literal_SaveValue.Text = (sumMarketPrice - suite.Price).ToString("0.00");
        }

        protected void Button_Buy_Click(object sender, EventArgs e)
        {
            DataTable dt = bll.GetList(SuiteID);

            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show(this,"该套装下尚无商品，暂时无法购买！");
                return;
            }

            string productIDs = String.Empty;
            foreach (DataRow row in dt.Rows) productIDs += row["productid"].ToString() + ",";

            Response.Redirect("/sp/AddToCart.aspx?pid=" + productIDs.Substring(0, productIDs.Length - 1));
        }
    }
}
