using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.MagicWorld.BLL;
using NoName.NetShop.Comment.BLL;
using NoName.NetShop.MagicWorld.Model;
using NoName.NetShop.MagicWorld.Facade;
using NoName.NetShop.Common;

namespace NoName.NetShop.ForeFlat.Magic
{
    public partial class Demand : System.Web.UI.Page
    {
        public int DemandID
        {
            get { if (ViewState["DemandID"] != null) return Convert.ToInt32(ViewState["DemandID"]); else return -1; }
            set { ViewState["DemandID"] = value; }
        }
        private DemandProductBll bll = new DemandProductBll();
        private CommentBll CmtBll = new CommentBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["pid"])) DemandID = Convert.ToInt32(Request.QueryString["pid"]);
                if (DemandID != -1) BindData();
                else Response.End();
            }
        }

        private void BindData() 
        {
            DemandProductModel model = bll.GetModel(DemandID);

            Image_Small.ImageUrl = MagicWorldImageRule.GetMainImageUrl(model.SmallImage);
            Image_Medium.ImageUrl = MagicWorldImageRule.GetMainImageUrl(model.MediumImage);

            Literal_ProductName.Text = model.DemandName;
            Literal_Count.Text = model.Count.ToString();
            Literal_Price.Text = model.Price.ToString("0.00");
            Literal_UsageCondition.Text = Enum.GetName(typeof(SecondhandProductUsageCondition), model.UsageCondition);
            Literal_Brief.Text = model.Brief;

            Literal_UserID.Text = model.UserID;
            Literal_Phone.Text = String.IsNullOrEmpty(model.Phone) ? model.CellPhone : model.Phone ;
            Literal_Region.Text = String.IsNullOrEmpty(model.Region) ? String.Empty : model.Region.Split(' ')[0];

            Repeater_Comment.DataSource = CmtBll.GetList(AppType.MagicWorld, DemandID);
            Repeater_Comment.DataBind();
        }
    }
}
