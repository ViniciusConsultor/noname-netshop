using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoName.NetShop.ForeFlat.vote
{
    public partial class VoteResult : BasePage
    {
        private NetShop.Vote.Model.VoteTopic vmodel;
        protected void Page_Load(object sender, EventArgs e)
        {
            int voteId = int.Parse(ReqParas["voteId"]);

            ShowVote(voteId);
        }

        private void ShowVote(int voteId)
        {
            NetShop.Vote.BLL.VoteTopic vbll = new NoName.NetShop.Vote.BLL.VoteTopic();
            vmodel = vbll.GetModel(voteId);
            this.litContent.Text = vmodel.Remark;
            this.litTitle.Text = vmodel.Topic;

            NetShop.Vote.BLL.VoteItemGroup gbll= new NoName.NetShop.Vote.BLL.VoteItemGroup();

            rpList.DataSource = gbll.GetModelList(voteId);
            rpList.DataBind();
        }

        protected void rpList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            NetShop.Vote.BLL.VoteItem ibll = new NoName.NetShop.Vote.BLL.VoteItem();
            NetShop.Vote.Model.VoteItemGroup gmodel = e.Item.DataItem as NetShop.Vote.Model.VoteItemGroup;
            Repeater rpItem = e.Item.FindControl("rpItem") as Repeater;

            List<NetShop.Vote.Model.VoteItem> list = ibll.GetItemsOfGroup(gmodel.ItemGroupId);
            foreach (NetShop.Vote.Model.VoteItem item in list)
            {
                item.VoteTotalCount = vmodel.VoteUserNum;
            }
            rpItem.DataSource = list;
            rpItem.DataBind();
        }
    }
}
