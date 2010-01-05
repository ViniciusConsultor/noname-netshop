using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Comment;

namespace NoName.NetShop.BackFlat.qa
{
    public partial class ShowTopic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int topicId;
                if (!int.TryParse(Request.QueryString["tid"], out topicId))
                {
                    Response.End();
                }
                ShowInfo(topicId);
            }
        }

        private void ShowInfo(int topicId)
        {
            TopicBll qbll = new TopicBll();
            TopicModel qmodel = qbll.GetModel(topicId);
            if (qmodel == null)
            {
                throw new Exception("没有找到相应的问题");
            }
            else
            {
                this.lblTopicId.Text = qmodel.TopicId.ToString();
                this.lblUserId.Text = qmodel.UserId;
                this.lblTContent.Text = qmodel.Content;
                this.lblTTitle.Text = qmodel.Title;

                BindAnswers();
            }
        }

        private void BindAnswers()
        {
            ReplyBll abll = new ReplyBll();
            this.rpReplys.DataSource = abll.GetModelOfTopic(int.Parse(this.lblTopicId.Text));
            this.rpReplys.DataBind();
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            TopicBll qbll = new TopicBll();
            qbll.Delete(int.Parse(this.lblTopicId.Text));
            Response.Redirect("TopicList.aspx");
        }

        protected void rpReplys_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ReplyBll abll = new ReplyBll();
            int replyId = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "delete")
            {
                abll.Delete(replyId);
                BindAnswers();
            }
        }

        protected void btnToggle_Click(object sender, EventArgs e)
        {
            TopicBll abll = new TopicBll();
            int topicId = Convert.ToInt32(this.lblTopicId.Text);
            abll.ToggleStatus(topicId);
            Response.Redirect("TopicList.aspx");
        }
    }
}
