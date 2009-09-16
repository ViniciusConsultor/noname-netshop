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
namespace NoName.NetShop.Web.NewsModel
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
					//ShowInfo(NewsId);
				}
			}
		}
		
	private void ShowInfo(int NewsId)
	{
		NoName.NetShop.BLL.NewsModelBll bll=new NoName.NetShop.BLL.NewsModelBll();
		NoName.NetShop.Model.NewsModel model=bll.GetModel(NewsId);
		this.lblNewsType.Text=model.NewsType.ToString();
		this.lblStatus.Text=model.Status.ToString();
		this.lblTitle.Text=model.Title;
		this.lblSubTitle.Text=model.SubTitle;
		this.lblBrief.Text=model.Brief;
		this.lblContent.Text=model.Content;
		this.lblSmallImageUrl.Text=model.SmallImageUrl;
		this.lblAuthor.Text=model.Author;
		this.lblFrom.Text=model.From;
		this.lblVideoUrl.Text=model.VideoUrl;
		this.lblImageUrl.Text=model.ImageUrl;
		this.lblProductId.Text=model.ProductId;
		this.lblInsertTime.Text=model.InsertTime.ToString();
		this.lblModifyTime.Text=model.ModifyTime.ToString();
		this.lblTags.Text=model.Tags;

	}


    }
}
