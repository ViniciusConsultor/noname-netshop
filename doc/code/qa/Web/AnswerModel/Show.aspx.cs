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
namespace NoName.NetShop.Web.AnswerModel
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
					//ShowInfo(AnswerId);
				}
			}
		}
		
	private void ShowInfo(int AnswerId)
	{
		NoName.NetShop.BLL.AnswerModelBll bll=new NoName.NetShop.BLL.AnswerModelBll();
		NoName.NetShop.Model.AnswerModel model=bll.GetModel(AnswerId);
		this.lblQuestionId.Text=model.QuestionId.ToString();
		this.lblTitle.Text=model.Title;
		this.lblBrief.Text=model.Brief;
		this.lblContent.Text=model.Content;
		this.lblAnswerTime.Text=model.AnswerTime.ToString();

	}


    }
}
