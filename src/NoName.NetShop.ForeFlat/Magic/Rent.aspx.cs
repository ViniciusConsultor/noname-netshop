using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.MagicWorld.Model;
using NoName.NetShop.MagicWorld.BLL;
using NoName.NetShop.MagicWorld.Facade;
using NoName.NetShop.Comment.BLL;
using NoName.NetShop.Common;

namespace NoName.NetShop.ForeFlat.Magic
{
    public partial class Rent : AuthBasePage
    {
        public int RentID
        {
            get { if (ViewState["RentID"] != null) return Convert.ToInt32(ViewState["RentID"]); else return -1; }
            set { ViewState["RentID"] = value; }
        }
        private RentProductBll bll = new RentProductBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["rentid"])) RentID = Convert.ToInt32(Request.QueryString["rentid"]);
                else Response.End();
                BindData();
            }
        }

        private void BindData() 
        {
            RentProductModel model = bll.GetModel(RentID);
            if (model == null) Response.End();
            MagicCategoryModel cate = new MagicCategoryBll().GetModel(model.CategoryID);

            Image_Big.ImageUrl = MagicWorldImageRule.GetMainImageUrl(model.MediumImage);
            Image_Small.ImageUrl = MagicWorldImageRule.GetMainImageUrl(model.SmallImage);

            Literal_ProductName.Text = model.RentName;
            Literal_Category.Text = cate.CategoryName;
            Literal_RentPrice.Text = model.RentPrice.ToString("0.00");
            Literal_Pledge.Text = model.CashPledge.ToString("0.00");
            Literal_Brief.Text = model.Brief;

            Repeater_Comment.DataSource = new CommentBll().GetList(AppType.MagicWorld, RentID);
            Repeater_Comment.DataBind();
        }

        protected void Button_Rent_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("RentApply.aspx?RentID={0}",RentID));
        }
    }
}
