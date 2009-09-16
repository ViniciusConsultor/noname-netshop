using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
namespace NoName.NetShop.Web.QuestionModel
{
    public partial class Show : System.Web.UI.Page
    {        
        		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			(Master.FindControl("lblTitle") as Label).Text = "œÍœ∏–≈œ¢";
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null || Request.Params["id"].Trim() != "")
				{
					string id = Request.Params["id"];
					//ShowInfo(QuestionId);
				}
			}
		}
		
	private void ShowInfo(int QuestionId)
	{
		NoName.NetShop.BLL.QuestionModelBll bll=new NoName.NetShop.BLL.QuestionModelBll();
		NoName.NetShop.Model.QuestionModel model=bll.GetModel(QuestionId);
		this.lblUserId.Text=model.UserId.ToString();
		this.lblContentType.Text=model.ContentType.ToString();
		this.lblContentId.Text=model.ContentId;
		this.lblTitle.Text=model.Title;
		this.lblContent.Text=model.Content;
		this.lblBrief.Text=model.Brief;
		this.lblInsertTime.Text=model.InsertTime.ToString();
		this.lblLastAnswerTime.Text=model.LastAnswerTime.ToString();
		this.lblLastAnswerId.Text=model.LastAnswerId;
		this.lblAnswerNum.Text=model.AnswerNum.ToString();

	}


    }
}
