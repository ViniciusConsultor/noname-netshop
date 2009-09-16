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
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			(Master.FindControl("lblTitle") as Label).Text = "��Ϣ���";
		}
		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(!PageValidate.IsNumber(txtNewsType.Text))
	{
		strErr+="NewsType�������֣�\\n";	
	}
	if(!PageValidate.IsNumber(txtStatus.Text))
	{
		strErr+="Status�������֣�\\n";	
	}
	if(this.txtTitle.Text =="")
	{
		strErr+="Title����Ϊ�գ�\\n";	
	}
	if(this.txtSubTitle.Text =="")
	{
		strErr+="SubTitle����Ϊ�գ�\\n";	
	}
	if(this.txtBrief.Text =="")
	{
		strErr+="Brief����Ϊ�գ�\\n";	
	}
	if(this.txtContent.Text =="")
	{
		strErr+="Content����Ϊ�գ�\\n";	
	}
	if(this.txtSmallImageUrl.Text =="")
	{
		strErr+="SmallImageUrl����Ϊ�գ�\\n";	
	}
	if(this.txtAuthor.Text =="")
	{
		strErr+="Author����Ϊ�գ�\\n";	
	}
	if(this.txtFrom.Text =="")
	{
		strErr+="From����Ϊ�գ�\\n";	
	}
	if(this.txtVideoUrl.Text =="")
	{
		strErr+="VideoUrl����Ϊ�գ�\\n";	
	}
	if(this.txtImageUrl.Text =="")
	{
		strErr+="ImageUrl����Ϊ�գ�\\n";	
	}
	if(this.txtProductId.Text =="")
	{
		strErr+="ProductId����Ϊ�գ�\\n";	
	}
	if(!PageValidate.IsDateTime(txtInsertTime.Text))
	{
	strErr+="InsertTime����ʱ���ʽ��\\n";	
	}
	if(!PageValidate.IsDateTime(txtModifyTime.Text))
	{
	strErr+="ModifyTime����ʱ���ʽ��\\n";	
	}
	if(this.txtTags.Text =="")
	{
		strErr+="Tags����Ϊ�գ�\\n";	
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
	bll.Add(model);

		}

    }
}
