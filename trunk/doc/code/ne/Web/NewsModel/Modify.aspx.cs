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
using LTP.Common;
namespace NoName.NetShop.Web.NewsModel
{
    public partial class Modify : System.Web.UI.Page
    {       

        		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			(Master.FindControl("lblTitle") as Label).Text = "信息修改";
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
		this.lblNewsId.Text=model.NewsId.ToString();
		this.txtNewsType.Text=model.NewsType.ToString();
		this.txtStatus.Text=model.Status.ToString();
		this.txtTitle.Text=model.Title;
		this.txtSubTitle.Text=model.SubTitle;
		this.txtBrief.Text=model.Brief;
		this.txtContent.Text=model.Content;
		this.txtSmallImageUrl.Text=model.SmallImageUrl;
		this.txtAuthor.Text=model.Author;
		this.txtFrom.Text=model.From;
		this.txtVideoUrl.Text=model.VideoUrl;
		this.txtImageUrl.Text=model.ImageUrl;
		this.txtProductId.Text=model.ProductId;
		this.txtInsertTime.Text=model.InsertTime.ToString();
		this.txtModifyTime.Text=model.ModifyTime.ToString();
		this.txtTags.Text=model.Tags;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(!PageValidate.IsNumber(txtNewsType.Text))
	{
		strErr+="NewsType不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtStatus.Text))
	{
		strErr+="Status不是数字！\\n";	
	}
	if(this.txtTitle.Text =="")
	{
		strErr+="Title不能为空！\\n";	
	}
	if(this.txtSubTitle.Text =="")
	{
		strErr+="SubTitle不能为空！\\n";	
	}
	if(this.txtBrief.Text =="")
	{
		strErr+="Brief不能为空！\\n";	
	}
	if(this.txtContent.Text =="")
	{
		strErr+="Content不能为空！\\n";	
	}
	if(this.txtSmallImageUrl.Text =="")
	{
		strErr+="SmallImageUrl不能为空！\\n";	
	}
	if(this.txtAuthor.Text =="")
	{
		strErr+="Author不能为空！\\n";	
	}
	if(this.txtFrom.Text =="")
	{
		strErr+="From不能为空！\\n";	
	}
	if(this.txtVideoUrl.Text =="")
	{
		strErr+="VideoUrl不能为空！\\n";	
	}
	if(this.txtImageUrl.Text =="")
	{
		strErr+="ImageUrl不能为空！\\n";	
	}
	if(this.txtProductId.Text =="")
	{
		strErr+="ProductId不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtInsertTime.Text))
	{
		strErr+="InsertTime不是时间格式！\\n";	
	}
	if(!PageValidate.IsDateTime(txtModifyTime.Text))
	{
		strErr+="ModifyTime不是时间格式！\\n";	
	}
	if(this.txtTags.Text =="")
	{
		strErr+="Tags不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	int NewsType=int.Parse(this.txtNewsType.Text);
	int Status=int.Parse(this.txtStatus.Text);
	string Title=this.txtTitle.Text;
	string SubTitle=this.txtSubTitle.Text;
	string Brief=this.txtBrief.Text;
	string Content=this.txtContent.Text;
	string SmallImageUrl=this.txtSmallImageUrl.Text;
	string Author=this.txtAuthor.Text;
	string From=this.txtFrom.Text;
	string VideoUrl=this.txtVideoUrl.Text;
	string ImageUrl=this.txtImageUrl.Text;
	string ProductId=this.txtProductId.Text;
	DateTime InsertTime=DateTime.Parse(this.txtInsertTime.Text);
	DateTime ModifyTime=DateTime.Parse(this.txtModifyTime.Text);
	string Tags=this.txtTags.Text;


	NoName.NetShop.Model.NewsModel model=new NoName.NetShop.Model.NewsModel();
	model.NewsType=NewsType;
	model.Status=Status;
	model.Title=Title;
	model.SubTitle=SubTitle;
	model.Brief=Brief;
	model.Content=Content;
	model.SmallImageUrl=SmallImageUrl;
	model.Author=Author;
	model.From=From;
	model.VideoUrl=VideoUrl;
	model.ImageUrl=ImageUrl;
	model.ProductId=ProductId;
	model.InsertTime=InsertTime;
	model.ModifyTime=ModifyTime;
	model.Tags=Tags;

	NoName.NetShop.BLL.NewsModelBll bll=new NoName.NetShop.BLL.NewsModelBll();
	bll.Update(model);

		}

    }
}
