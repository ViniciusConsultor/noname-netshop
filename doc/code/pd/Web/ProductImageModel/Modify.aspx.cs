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
namespace NoName.NetShop.Web.ProductImageModel
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
					//ShowInfo(ImageId);
				}
			}
		}
			
	private void ShowInfo(int ImageId)
	{
		NoName.NetShop.BLL.ProductImageModelBll bll=new NoName.NetShop.BLL.ProductImageModelBll();
		NoName.NetShop.Model.ProductImageModel model=bll.GetModel(ImageId);
		this.lblImageId.Text=model.ImageId.ToString();
		this.txtProductId.Text=model.ProductId.ToString();
		this.txtSmallImage.Text=model.SmallImage;
		this.txtLargeImage.Text=model.LargeImage;
		this.txtOriginImage.Text=model.OriginImage;
		this.txtTitle.Text=model.Title;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(!PageValidate.IsNumber(txtProductId.Text))
	{
		strErr+="ProductId不是数字！\\n";	
	}
	if(this.txtSmallImage.Text =="")
	{
		strErr+="SmallImage不能为空！\\n";	
	}
	if(this.txtLargeImage.Text =="")
	{
		strErr+="LargeImage不能为空！\\n";	
	}
	if(this.txtOriginImage.Text =="")
	{
		strErr+="OriginImage不能为空！\\n";	
	}
	if(this.txtTitle.Text =="")
	{
		strErr+="Title不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	int ProductId=int.Parse(this.txtProductId.Text);
	string SmallImage=this.txtSmallImage.Text;
	string LargeImage=this.txtLargeImage.Text;
	string OriginImage=this.txtOriginImage.Text;
	string Title=this.txtTitle.Text;


	NoName.NetShop.Model.ProductImageModel model=new NoName.NetShop.Model.ProductImageModel();
	model.ProductId=ProductId;
	model.SmallImage=SmallImage;
	model.LargeImage=LargeImage;
	model.OriginImage=OriginImage;
	model.Title=Title;

	NoName.NetShop.BLL.ProductImageModelBll bll=new NoName.NetShop.BLL.ProductImageModelBll();
	bll.Update(model);

		}

    }
}
