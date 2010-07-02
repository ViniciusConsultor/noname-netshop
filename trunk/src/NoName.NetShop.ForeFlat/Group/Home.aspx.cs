using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.GroupShopping.Model;
using NoName.NetShop.GroupShopping.BLL;

namespace NoName.NetShop.ForeFlat.Group
{
    public partial class List : System.Web.UI.Page
    {
        private GroupShopping.BLL.GroupProductBll bll = new NoName.NetShop.GroupShopping.BLL.GroupProductBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            Repeater_Recommend.DataSource = bll.GetTopList(" and isrecommend=1", " order by changetime desc", 10);
            Repeater_Recommend.DataBind();

            Repeater_NewGroup.DataSource = bll.GetTopList(" and inserttime > '" + DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss") + "'", " order by productid desc", 6);
            Repeater_NewGroup.DataBind();

            Repeater_Grouping.DataSource = bll.GetTopList(" and status = " + (int)GroupShoppingProductStatus.正在团购, "", 6);
            Repeater_Grouping.DataBind();

            Repeater_Ending.DataSource = bll.GetTopList(" and (succedline - [dbo].[GetGroupProductApplyCount](productid)) < 5", "", 6);
            Repeater_Ending.DataBind();
        }
    }
}
