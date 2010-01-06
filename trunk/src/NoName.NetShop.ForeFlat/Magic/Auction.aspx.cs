using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.MagicWorld.BLL;
using NoName.NetShop.MagicWorld.Model;
using NoName.NetShop.MagicWorld.Facade;
using System.Data;
using NoName.NetShop.Common;
using NoName.NetShop.Comment;

namespace NoName.NetShop.ForeFlat.Magic
{
    public partial class Auction : System.Web.UI.Page
    {
        public int AuctionID
        {
            get { if (ViewState["AuctionID"] != null) return Convert.ToInt32(ViewState["AuctionID"]); else return -1; }
            set { ViewState["AuctionID"] = value; }
        }
        private AuctionProductBll bll = new AuctionProductBll();
        private AuctionLogBll LogBll = new AuctionLogBll();
        private CommentBll CmtBll = new CommentBll();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["pid"])) AuctionID = Convert.ToInt32(Request.QueryString["pid"]);
                if (AuctionID != -1) BindData();
                else Response.End();
            }
        }

        private void BindData()
        {
            AuctionProductModel model = bll.GetModel(AuctionID);

            DataTable dt = new DataTable(); dt.Columns.Add("price");
            foreach (string s in model.AddPrices.Split(','))
            {
                DataRow row = dt.NewRow();
                row["price"] = decimal.Parse(s);
                dt.Rows.Add(row);
            }
            dt.DefaultView.Sort = "price asc";
            Repeater_AddPrices.DataSource = dt;
            Repeater_AddPrices.DataBind();

            Image_Large.ImageUrl = MagicWorldImageRule.GetMainImageUrl(model.MediumImage);
            Image_Medium.ImageUrl = MagicWorldImageRule.GetMainImageUrl(model.SmallImage);

            Literal_ProductName.Text = model.ProductName;
            Literal_StartPrice.Text = model.StartPrice.ToString("0.00");
            Literal_CurrentPrice.Text = model.CurPrice.ToString("0.00"); ;
            Literal_MinAddPrice.Text = dt.Rows[0]["price"].ToString();
            Literal_MaxAddPrice.Text = dt.Rows[dt.Rows.Count - 1]["price"].ToString();
            Literal_StartTime.Text = model.StartTime.ToString("yyyy-MM-dd");
            Literal_EndTime.Text = model.EndTime.ToString("yyyy-MM-dd");
            Literal_Description.Text = model.Brief;

            Repeater_BidList.DataSource = LogBll.GetList("auctionid=" + AuctionID+" order by auctiontime desc");
            Repeater_BidList.DataBind();

            Repeater_Comment.DataSource = CmtBll.GetList(AppType.MagicWorld, AuctionID);
            Repeater_Comment.DataBind();
        }

        protected void Repeater_AddPrices_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "b")
            {
                decimal BidPrice = Convert.ToInt32(e.CommandArgument);
                AuctionProductModel model = bll.GetModel(AuctionID);

                decimal CurrentPrice = model.CurPrice + BidPrice;

                AuctionLogModel LogModel = new AuctionLogModel();
                LogModel.LogID = CommDataHelper.GetNewSerialNum(AppType.MagicWorld);
                LogModel.AuctionID = AuctionID;
                LogModel.AuctionTime = DateTime.Now;
                LogModel.AutionPrice = CurrentPrice;
                LogModel.UserName = GetUserName();

                LogBll.Add(LogModel);

                model.CurPrice = CurrentPrice;
                bll.Update(model);

                Response.Redirect(Request.RawUrl);
            }
        }


        private string GetUserName()
        {
            return "zhangfeng";
        }


    }
}

