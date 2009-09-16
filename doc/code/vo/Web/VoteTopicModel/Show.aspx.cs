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
namespace NoName.NetShop.Web.VoteTopicModel
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
					//ShowInfo(VoteId);
				}
			}
		}
		
	private void ShowInfo(int VoteId)
	{
		NoName.NetShop.BLL.VoteTopicModelBll bll=new NoName.NetShop.BLL.VoteTopicModelBll();
		NoName.NetShop.Model.VoteTopicModel model=bll.GetModel(VoteId);
		this.lblContentId.Text=model.ContentId.ToString();
		this.lblContentType.Text=model.ContentType.ToString();
		this.lblTopic.Text=model.Topic;
		this.lblRemark.Text=model.Remark;
		this.lblStartTime.Text=model.StartTime.ToString();
		this.lblEndTime.Text=model.EndTime.ToString();
		this.chkIsRegUser.Checked=model.IsRegUser;
		this.lblVoteUserNum.Text=model.VoteUserNum.ToString();

	}


    }
}
