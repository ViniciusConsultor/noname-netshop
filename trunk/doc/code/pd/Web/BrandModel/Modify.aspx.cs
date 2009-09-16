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
namespace NoName.NetShop.Web.BrandModel
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
					//ShowInfo(BrandId);
				}
			}
		}
			
	private void ShowInfo(int BrandId)
	{
		NoName.NetShop.BLL.BrandModelBll bll=new NoName.NetShop.BLL.BrandModelBll();
		NoName.NetShop.Model.BrandModel model=bll.GetModel(BrandId);
		this.lblBrandId.Text=model.BrandId.ToString();
		this.txtBrandName.Text=model.BrandName;
		this.txtCateId.Text=model.CateId.ToString();
		this.txtCatePath.Text=model.CatePath;
		this.txtBrandLogo.Text=model.BrandLogo;
		this.txtBrief.Text=model.Brief;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtBrandName.Text =="")
	{
		strErr+="BrandName不能为空！\\n";	
	}
	if(!PageValidate.IsNumber(txtCateId.Text))
	{
		strErr+="CateId不是数字！\\n";	
	}
	if(this.txtCatePath.Text =="")
	{
		strErr+="CatePath不能为空！\\n";	
	}
	if(this.txtBrandLogo.Text =="")
	{
		strErr+="BrandLogo不能为空！\\n";	
	}
	if(this.txtBrief.Text =="")
	{
		strErr+="Brief不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string BrandName=this.txtBrandName.Text;
	int CateId=int.Parse(this.txtCateId.Text);
	string CatePath=this.txtCatePath.Text;
	string BrandLogo=this.txtBrandLogo.Text;
	string Brief=this.txtBrief.Text;


	NoName.NetShop.Model.BrandModel model=new NoName.NetShop.Model.BrandModel();
	model.BrandName=BrandName;
	model.CateId=CateId;
	model.CatePath=CatePath;
	model.BrandLogo=BrandLogo;
	model.Brief=Brief;

	NoName.NetShop.BLL.BrandModelBll bll=new NoName.NetShop.BLL.BrandModelBll();
	bll.Update(model);

		}

    }
}
