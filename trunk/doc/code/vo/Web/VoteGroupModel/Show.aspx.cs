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
namespace NoName.NetShop.Web.VoteGroupModel
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
					//ShowInfo(VoteGroupId);
				}
			}
		}
		
	private void ShowInfo(int VoteGroupId)
	{
		NoName.NetShop.BLL.VoteGroupModelBll bll=new NoName.NetShop.BLL.VoteGroupModelBll();
		NoName.NetShop.Model.VoteGroupModel model=bll.GetModel(VoteGroupId);
		this.lblVoteId.Text=model.VoteId.ToString();
		this.lblGroupType.Text=model.GroupType.ToString();
		this.lblSubject.Text=model.Subject;
		this.lblContent.Text=model.Content;

	}


    }
}
