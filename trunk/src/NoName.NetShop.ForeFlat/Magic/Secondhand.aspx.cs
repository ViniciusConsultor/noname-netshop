using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.MagicWorld.BLL;
using NoName.NetShop.MagicWorld.Model;
using NoName.NetShop.MagicWorld.Facade;
using NoName.NetShop.Comment;
using NoName.NetShop.Common;
using NoName.NetShop.Member;

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
                if (!String.IsNullOrEmpty(Request.QueryString["pid"])) SecondhandProductID = Convert.ToInt32(Request.QueryString["pid"]);
                if (SecondhandProductID != -1) BindData();
                else Response.End();
            }
        }


        private void BindData() 
        {
            SecondhandProductModel model = bll.GetModel(SecondhandProductID);
            MemberInfo user = MemberInfo.GetFullInfo(model.UserID);

            Image_Small.ImageUrl = MagicWorldImageRule.GetMainImageUrl(model.SmallImage);
            Image_Large.ImageUrl = MagicWorldImageRule.GetMainImageUrl(model.MediumImage);

            Literal_ProductName.Text = model.SecondhandProductName;
            Literal_Price.Text = model.Price.ToString("0.00");
            Literal_Stock.Text = model.Stock.ToString();
            Literal_CategoryName.Text = model.CateID.ToString();
            Literal_Condition.Text = Enum.GetName(typeof(SecondhandProductUsageCondition), model.UsageCondition);
            Literal_Description.Text = model.Brief;

            Literal_Nick.Text = user.UserId;
            Literal_Level.Text = user.UserLevel.ToString();
            Literal_Phone.Text = String.IsNullOrEmpty(model.Phone) ? model.CellPhone : model.Phone;
            Literal_Province.Text = String.IsNullOrEmpty(model.Region) ? String.Empty : model.Region.Split(' ')[0];

            Repeater_Comment.DataSource = CmtBll.GetList(AppType.MagicWorld, SecondhandProductID);
            Repeater_Comment.DataBind();
        }

    }
}
