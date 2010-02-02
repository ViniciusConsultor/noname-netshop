﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.Utility;
using NoName.NetShop.MagicWorld.BLL;

namespace NoName.NetShop.ForeFlat.member.Auction
{
    public partial class List : System.Web.UI.Page
    {
        private AuctionProductBll bll = new AuctionProductBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData(1);
            }
        }

        private void BindData(int PageIndex)
        {
            int RecordCount = 0;
            Repeater_AuctionList.DataSource = bll.GetList(AspNetPager.PageSize, PageIndex, " and userid = '" + GetUserID() + "'", out RecordCount);
            Repeater_AuctionList.DataBind();

            AspNetPager.RecordCount = RecordCount;
        }


        protected void AspNetPager_PageChanged(object src, PageChangedEventArgs e)
        {
            AspNetPager.CurrentPageIndex = e.NewPageIndex;
            BindData(AspNetPager.CurrentPageIndex);
        }


        private string GetUserID()
        {
            return "zhangfeng";
        }
    }
}
