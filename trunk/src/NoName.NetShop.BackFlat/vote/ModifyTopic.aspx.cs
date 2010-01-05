using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoName.NetShop.BackFlat.vote
{
    public partial class Modify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int voteId;
                if (!int.TryParse(Request["voteId"],out voteId))
                {
                    voteId =0;
                }
                ShowVoteTopicInfo(voteId);
            }
        }

        private void ShowVoteTopicInfo(int voteId)
        {
            NoName.NetShop.Vote.BLL.VoteTopic bll = new NoName.NetShop.Vote.BLL.VoteTopic();
            NoName.NetShop.Vote.Model.VoteTopic model = bll.GetModel(voteId);
            if (model != null)
            {
                this.txtStartDate.Text = model.StartTime == null ? "" : (model.StartTime ?? DateTime.MinValue).ToShortDateString();
                this.txtEndDate.Text = model.EndTime == null ? "" : (model.EndTime ?? DateTime.MinValue).ToShortDateString();
                this.lblVoteUserNum.Text = model.VoteUserNum.ToString();
                this.txtTopic.Text = model.Topic;
                this.txtRemark.Text = model.Remark;
                this.chkIsMulti.Checked = model.IsMulti;
                this.chkIsRegUser.Checked = model.IsRegUser;
                this.chkStatus.Checked = model.Status;
                this.lblVoteId.Text = model.VoteId.ToString();
            }
            else
            {
                this.lblVoteId.Text = "0";
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            NoName.NetShop.Vote.BLL.VoteTopic bll = new NoName.NetShop.Vote.BLL.VoteTopic();
            int voteId = int.Parse(this.lblVoteId.Text);

            NoName.NetShop.Vote.Model.VoteTopic model = null;
            if (voteId != 0)
                model = bll.GetModel(voteId);
            if (model == null)
                model = new NoName.NetShop.Vote.Model.VoteTopic();

            model.Topic = txtTopic.Text.Trim();
            model.Remark = txtRemark.Text.Trim();
            try
            {
                model.StartTime = DateTime.Parse(txtStartDate.Text);
            }
            catch { }
            try
            {
                model.EndTime = DateTime.Parse(txtEndDate.Text);
            }
            catch { }
            model.IsRegUser = chkIsRegUser.Checked;
            model.IsMulti = chkIsMulti.Checked;
            model.Status = chkStatus.Checked;
            bll.Save(model);
            Response.Redirect("ShowVoteInfo.aspx?voteId=" + model.VoteId);
        }

   }
}
