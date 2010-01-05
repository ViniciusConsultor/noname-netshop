using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoName.NetShop.BackFlat.vote
{
    public partial class ShowVoteInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int voteId;
                if (!int.TryParse(Request.QueryString["voteId"],out voteId))
                {
                    Response.Write("没有找到相关投票信息");
                    Response.End();
                }
                ShowInfo(voteId);
            }
        }

        private void ShowInfo(int voteId)
        {
            Vote.BLL.VoteTopic vbll = new NoName.NetShop.Vote.BLL.VoteTopic();
            Vote.BLL.VoteItemGroup gbll = new NoName.NetShop.Vote.BLL.VoteItemGroup();
            Vote.BLL.VoteItem ibll = new NoName.NetShop.Vote.BLL.VoteItem();
            Vote.Model.VoteTopic vmodel = vbll.GetModel(voteId);
            if (vmodel != null)
            {
                this.lblEndDate.Text = vmodel.EndTime == null ? "" : (vmodel.EndTime ?? DateTime.MaxValue).ToShortDateString();
                this.lblStartDate.Text = vmodel.StartTime == null ? "" : (vmodel.StartTime ?? DateTime.MaxValue).ToShortDateString();
                this.chkIsMulti.Checked = vmodel.IsMulti;
                this.chkIsRegUser.Checked = vmodel.IsRegUser;
                this.chkStatus.Checked = vmodel.Status;
                this.lblRemark.Text = vmodel.Remark;
                this.lblTopic.Text = vmodel.Topic;
                this.lblVoteId.Text = vmodel.VoteId.ToString();
                this.lblVoteUserNum.Text = vmodel.VoteUserNum.ToString();
            }
            rpGroups.DataSource = gbll.GetModelList(voteId);
            rpGroups.DataBind();
        }

        protected void rpGroups_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Vote.Model.VoteItemGroup gmodel = e.Item.DataItem as Vote.Model.VoteItemGroup;
                Vote.BLL.VoteItem ibll = new NoName.NetShop.Vote.BLL.VoteItem();

                GridView gvItems = e.Item.FindControl("gvItems") as GridView;
                gvItems.DataSource = ibll.GetItemsOfGroup(gmodel.ItemGroupId);
                gvItems.DataBind();
            }
        }

        protected void btnAddGroup_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModifyGroup.aspx?voteId="+lblVoteId.Text);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModifyTopic.aspx?voteId=" + lblVoteId.Text);
        }
    }
}
