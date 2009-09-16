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
namespace NoName.NetShop.Web.MessageModel
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
					ShowInfo();
				}
			}
		}
		
	private void ShowInfo()
	{
		NoName.NetShop.BLL.MessageModelBll bll=new NoName.NetShop.BLL.MessageModelBll();
		NoName.NetShop.Model.MessageModel model=bll.GetModel();
		this.lblUserId.Text=model.UserId.ToString();
		this.lblMsgId.Text=model.MsgId.ToString();
		this.lblMsgType.Text=model.MsgType.ToString();
		this.lblSubject.Text=model.Subject;
		this.lblContent.Text=model.Content;
		this.lblSenderId.Text=model.SenderId.ToString();
		this.lblInsertTime.Text=model.InsertTime.ToString();
		this.lblReadTime.Text=model.ReadTime.ToString();
		this.lblStatus.Text=model.Status.ToString();

	}


    }
}
