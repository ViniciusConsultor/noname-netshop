using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Common;
using System.Data;
using NoName.NetShop.Member;
using System.Text;

namespace NoName.NetShop.BackFlat.Order
{
    public partial class ExpressShipFee : System.Web.UI.Page
    {
        NoName.NetShop.ShopFlow.ExpressInfoBll ebll = new NoName.NetShop.ShopFlow.ExpressInfoBll(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }
        }

        private void BindList()
        {
            string condition = GetSearchCondition();
            gvList.DataSource = ebll.GetModelList(condition);
            gvList.DataBind();
         }

        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblUserType = e.Row.FindControl("lblUserType") as Label;
                NoName.NetShop.ShopFlow.ExpressInfoModel model = e.Row.DataItem as NoName.NetShop.ShopFlow.ExpressInfoModel;
                MemberType userType = (MemberType)model.UserType;
                UserLevel userLevel = (UserLevel)model.UserLevel;
                switch (userType)
                {
                    case MemberType.Personal:
                        lblUserType.Text = userLevel.ToString();
                        break;
                    case MemberType.Company:
                        lblUserType.Text = "鼎企会员";
                        break;
                    case MemberType.Famly:
                        lblUserType.Text = "鼎宅会员";
                        break;
                    case MemberType.School:
                        lblUserType.Text = "鼎校会员";
                        break;
                    default:
                        lblUserType.Text = userLevel.ToString(); 
                        break;
                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvList.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    int ruleId = int.Parse(row.Cells[0].Text);
                    NoName.NetShop.ShopFlow.ExpressInfoModel model = ebll.GetModel(ruleId);
                    model.MarkMoney = decimal.Parse(((TextBox)row.FindControl("txtMarkMoney")).Text);
                    model.LShipFee = decimal.Parse(((TextBox)row.FindControl("txtLShipFee")).Text);
                    model.GShipFee = decimal.Parse(((TextBox)row.FindControl("txtGShipFee")).Text);
                    ebll.Update(model);
                }
            }
            BindList();
        }

        protected void doSearch_Click(object sender, EventArgs e)
        {
            BindList();
        }

        private string GetSearchCondition()
        {
            string shipRegion = ddlShipRegion.SelectedValue;
            string usertype = ddlUserType.SelectedValue;
            string userlevel = ddlUserLevel.SelectedValue;
            StringBuilder strWhere = new StringBuilder();
            if (!String.IsNullOrEmpty(shipRegion))
            {
                strWhere.Append(strWhere.Length==0 ? "" : " and ");
                strWhere.Append(" shipRegion='" + shipRegion + "'");
            }
            if (!String.IsNullOrEmpty(usertype))
            {
                strWhere.Append(strWhere.Length == 0 ? "" : " and ");
                strWhere.Append(" UserType=" + usertype);
            }
            if (!String.IsNullOrEmpty(userlevel))
            {
                strWhere.Append(strWhere.Length ==0 ? "" : " and ");
                strWhere.Append(" UserLevel='" + userlevel + "'");
            }
            return strWhere.ToString();
        }

    }
}
