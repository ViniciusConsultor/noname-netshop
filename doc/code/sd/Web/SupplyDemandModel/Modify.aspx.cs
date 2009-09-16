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
namespace NoName.NetShop.Web.SupplyDemandModel
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
					//ShowInfo(sdId);
				}
			}
		}
			
	private void ShowInfo(int sdId)
	{
		NoName.NetShop.BLL.SupplyDemandModelBll bll=new NoName.NetShop.BLL.SupplyDemandModelBll();
		NoName.NetShop.Model.SupplyDemandModel model=bll.GetModel(sdId);
		this.lblsdId.Text=model.sdId.ToString();
		this.txtsdType.Text=model.sdType.ToString();
		this.txtuserId.Text=model.userId.ToString();
		this.txtTitle.Text=model.Title;
		this.txtContent.Text=model.Content;
		this.txtInsertTime.Text=model.InsertTime.ToString();
		this.txtModifyTime.Text=model.ModifyTime.ToString();
		this.txtStatus.Text=model.Status.ToString();

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(!PageValidate.IsNumber(txtsdType.Text))
	{
		strErr+="sdType不是数字！\\n";	
	}
	if(!PageValidate.IsNumber(txtuserId.Text))
	{
		strErr+="userId不是数字！\\n";	
	}
	if(this.txtTitle.Text =="")
	{
		strErr+="Title不能为空！\\n";	
	}
	if(this.txtContent.Text =="")
	{
		strErr+="Content不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtInsertTime.Text))
	{
		strErr+="InsertTime不是时间格式！\\n";	
	}
	if(!PageValidate.IsDateTime(txtModifyTime.Text))
	{
		strErr+="ModifyTime不是时间格式！\\n";	
	}
	if(!PageValidate.IsNumber(txtStatus.Text))
	{
		strErr+="Status不是数字！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	int sdType=int.Parse(this.txtsdType.Text);
	int userId=int.Parse(this.txtuserId.Text);
	string Title=this.txtTitle.Text;
	string Content=this.txtContent.Text;
	DateTime InsertTime=DateTime.Parse(this.txtInsertTime.Text);
	DateTime ModifyTime=DateTime.Parse(this.txtModifyTime.Text);
	int Status=int.Parse(this.txtStatus.Text);


	NoName.NetShop.Model.SupplyDemandModel model=new NoName.NetShop.Model.SupplyDemandModel();
	model.sdType=sdType;
	model.userId=userId;
	model.Title=Title;
	model.Content=Content;
	model.InsertTime=InsertTime;
	model.ModifyTime=ModifyTime;
	model.Status=Status;

	NoName.NetShop.BLL.SupplyDemandModelBll bll=new NoName.NetShop.BLL.SupplyDemandModelBll();
	bll.Update(model);

		}

    }
}
