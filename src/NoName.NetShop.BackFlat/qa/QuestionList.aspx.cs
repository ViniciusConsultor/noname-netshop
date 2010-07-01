using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NoName.NetShop.Common;
using NoName.NetShop.Product.Model;
using NoName.NetShop.News.Model;

namespace NoName.NetShop.BackFlat.qa
{
    public partial class QuestionList : System.Web.UI.Page
    {
        private SearchPageInfo SearPageInfo
        {
            get
            {
                if (ViewState["SearchPageInfo"] == null)
                {
                    SearchPageInfo spage = new SearchPageInfo();
                    ViewState["SearchPageInfo"] = spage;
                    spage.TableName = "qaQuestion";
                    spage.FieldNames = "QuestionId,UserId,ContentType,ContentId,Title,InsertTime,LastAnswerTime,LastAnswerId,AnswerNum";
                    spage.PriKeyName = "QuestionId";
                    spage.StrJoin = "";
                    spage.PageSize = 20;
                    spage.PageIndex = 1;
                    spage.OrderType = "1";
                    spage.StrWhere = "";
                }
                return ViewState["SearchPageInfo"] as SearchPageInfo;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }
        }



        private void BindList()
        {
            DataSet ds = NoName.NetShop.Common.CommDataHelper.GetDataFromMultiTablesByPage(SearPageInfo);
            gvList.DataSource = ds.Tables[0];
            gvList.DataBind();
            pageNav.CurrentPageIndex = SearPageInfo.PageIndex;
            pageNav.PageSize = SearPageInfo.PageSize;
            pageNav.RecordCount = SearPageInfo.TotalItem;
        }

        protected void pageNav_PageChanged(object src, NoName.Utility.PageChangedEventArgs e)
        {
            SearPageInfo.PageIndex = e.NewPageIndex;
            BindList();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string where = String.Empty;

            string userId = NoName.Utility.input.Filter(txtUserId.Text.Trim());
            if (!String.IsNullOrEmpty(userId))
            {
                if (!String.IsNullOrEmpty(where))
                    where += " and ";
                where += "userId='" + userId + "'";
            }
            if (!String.IsNullOrEmpty(ddlQuestionType.SelectedValue))
            {
                if (!String.IsNullOrEmpty(where))
                    where += " and ";
                where += "ContentType=" + ddlQuestionType.SelectedValue;
            }
            SearPageInfo.StrWhere = where;
            SearPageInfo.PageIndex = 1;
            BindList();
        }

        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal litContentType = e.Row.FindControl("litContentType") as Literal;
                DataRowView row = e.Row.DataItem as DataRowView;
                switch (Convert.ToInt32(row["ContentType"]))
                {
                    case 1: // product
                        litContentType.Text = "商品提问";
                        break;
                    case 2: // news
                        litContentType.Text = "资讯提问";
                        break;
                    case 3: // Complaint
                        litContentType.Text = "投诉";
                        break;
                    case 4:
                        litContentType.Text = "维修申请";
                        break;
                }
            }
        }

        public string GetQuestionTargetTitle(int QuestionType,int TargetID)
        {
            /*
                <asp:ListItem Text="商品提问" Value="1"></asp:ListItem>
                <asp:ListItem Text="资讯提问" Value="2"></asp:ListItem>
                <asp:ListItem Text="投诉" Value="3"></asp:ListItem>
                <asp:ListItem Text="维修申请" Value="4"></asp:ListItem>
             * */


            switch (QuestionType)
            {
                case 1:
                    ProductModel p = new NoName.NetShop.Product.BLL.ProductModelBll().GetModel(TargetID);
                    return p==null?String.Empty:p.ProductName;
                case 2:
                    NewsModel n = new NoName.NetShop.News.BLL.NewsModelBll().GetModel(TargetID);
                    return n == null ? String.Empty : n.Title;
                default:
                    return String.Empty;
            }

        }



    }
}
