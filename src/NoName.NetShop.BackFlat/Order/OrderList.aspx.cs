﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Common;
using System.Data;
using NoName.NetShop.ShopFlow;

namespace NoName.NetShop.BackFlat.Order
{
    public partial class OrderList : System.Web.UI.Page
    {
        private SearchPageInfo SearPageInfo
        {
            get
            {
                if (ViewState["SearchPageInfo"] == null)
                {
                    SearchPageInfo spage = new SearchPageInfo();
                    ViewState["SearchPageInfo"] = spage;
                    spage.TableName = "spOrder";
                    spage.FieldNames = "UserId,OrderId,OrderStatus,PayMethod,ShipMethod,PayStatus,Paysum,ShipFee,ProductFee,DerateFee,RecieverName,ChangeTime,PayTime,CreateTime,OrderType";
                    spage.PriKeyName = "OrderId";
                    spage.StrJoin = "";
                    spage.PageSize = 20;
                    spage.PageIndex = 1;
                    spage.OrderType = "1";
                    spage.StrWhere = String.Empty;

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
            pageNav.CurrentPageIndex = SearPageInfo.PageIndex - 1;
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

            string orderId = NoName.Utility.input.Filter(txtOrderId.Text.Trim());
            if (orderId != "")
            {
                if (where != "")
                    where += " and ";
                where += "orderId='" + orderId + "'";
            }
            DateTime sdate;
            if (DateTime.TryParse(txtStartDate.Text,out sdate))
            {
                if (where != "")
                    where += " and ";
                where += "createtime>='" + sdate.ToShortDateString() +"'";
            }
            DateTime edate;
            if (DateTime.TryParse(txtEndDate.Text,out edate))
            {
                if (where != "")
                    where += " and ";
                where += "createtime<='" + edate.ToShortDateString() +"'";
            }

            if (ddlOrderStatus.SelectedValue != "")
            {
                if (where != "")
                    where += " and ";
                where += "orderstatus=" + ddlOrderStatus.SelectedValue;
            }
            if (ddlPayStatus.SelectedValue != "")
            {
                if (where != "")
                    where += " and ";
                where += "paystatus=" + ddlPayStatus.SelectedValue;
            }
            SearPageInfo.StrWhere = where;
            SearPageInfo.PageIndex = 1;
            BindList();
        }

    }
}
