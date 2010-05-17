using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Comment;

namespace NoName.NetShop.BackFlat.qa
{
    public partial class ShowQuestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int questionId;
                if (!int.TryParse(Request.QueryString["qid"], out questionId))
                {
                    Response.End();
                }
                ShowInfo(questionId);
            }
        }

        private void ShowInfo(int questionId)
        {
            QuestionBll qbll = new QuestionBll();
            QuestionModel qmodel = qbll.GetModel(questionId);
            if (qmodel == null)
            {
                throw new Exception("没有找到相应的问题");
            }
            else
            {
                this.lblQuestionId.Text = qmodel.QuestionId.ToString();
                this.lblUserId.Text = qmodel.UserId;
                this.lblQContent.Text = qmodel.Content;
                this.lblQTitle.Text = qmodel.Title;

                this.lblAnswerId.Text = String.Empty;
                this.txtAContent.Text = String.Empty;
                this.txtATitle.Text = String.Empty;

                BindAnswers();
            }
        }

        private void BindAnswers()
        {
            AnswerBll abll = new AnswerBll();
            this.rpAnswers.DataSource = abll.GetModelOfQuestion(int.Parse(this.lblQuestionId.Text));
            this.rpAnswers.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AnswerBll abll = new AnswerBll();
            AnswerModel amodel = null;
            if (this.lblAnswerId.Text == "")
            {
                amodel = new AnswerModel();
                amodel.QuestionId = int.Parse(this.lblQuestionId.Text);
            }
            else
            {
                amodel = abll.GetModel(int.Parse(this.lblAnswerId.Text));
            }
            amodel.Content = this.txtAContent.Text.Trim();
            amodel.Title = this.txtATitle.Text.Trim();
            txtAContent.Text = "";
            txtATitle.Text = "";

            abll.Save(amodel);
            BindAnswers();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            QuestionBll qbll = new QuestionBll();
            qbll.Delete(int.Parse(this.lblQuestionId.Text));
            Response.Redirect("QuestionList.aspx");
        }

        protected void rpAnswers_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            AnswerBll abll = new AnswerBll();
            int answerId = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "del")
            {
                abll.Delete(answerId);
                BindAnswers();
            }
            else if (e.CommandName == "edit")
            {
                AnswerModel amodel = abll.GetModel(answerId);
                this.lblAnswerId.Text = amodel.AnswerId.ToString();
                this.txtAContent.Text = amodel.Content;
                this.txtATitle.Text = amodel.Title;
            }
        }
    }
}
