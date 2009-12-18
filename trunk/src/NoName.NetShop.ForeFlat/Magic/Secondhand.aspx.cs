using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.MagicWorld.BLL;
using NoName.NetShop.MagicWorld.Model;
using NoName.NetShop.MagicWorld.Facade;
using NoName.NetShop.Comment.BLL;
using NoName.NetShop.Common;

namespace NoName.NetShop.ForeFlat.Magic
{
    public partial class Secondhand : System.Web.UI.Page
    {
        public int SecondhandProductID
        {
            get { if (ViewState["SecondhandProductID"] != null) return Convert.ToInt32(ViewState["SecondhandProductID"]); else return -1; }
            set { ViewState["SecondhandProductID"] = value; }
        }
        private SecondhandProductBll bll = new SecondhandProductBll();
        private CommentBll CmtBll = new CommentBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["s"])) SecondhandProductID = Convert.ToInt32(Request.QueryString["s"]);
                if (SecondhandProductID != -1) BindData();
                else Response.End();
            }
        }


        private void BindData() 
        {
            SecondhandProductModel model = bll.GetModel(SecondhandProductID);

            Image_Small.ImageUrl = SecondhandImageRule.GetMainImageUrl(model.SmallImage);
            Image_Large.ImageUrl = SecondhandImageRule.GetMainImageUrl(model.LargeImage);

            Literal_ProductName.Text = model.SecondhandProductName;
            Literal_Price.Text = model.Price.ToString("0.00");
            Literal_Stock.Text = model.Stock.ToString();
            Literal_CategoryName.Text = model.CateID.ToString();
            Literal_Condition.Text = "";
            Literal_Description.Text = model.Brief;

            Repeater_Comment.DataSource = CmtBll.GetList(AppType.MagicWorld, SecondhandProductID);
            Repeater_Comment.DataBind();
        }

    }
}
