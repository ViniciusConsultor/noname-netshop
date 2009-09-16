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
namespace NoName.NetShop.Web.SuitSchemeModel
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
					//ShowInfo(SchemeId);
				}
			}
		}
			
	private void ShowInfo(int SchemeId)
	{
		NoName.NetShop.BLL.SuitSchemeModelBll bll=new NoName.NetShop.BLL.SuitSchemeModelBll();
		NoName.NetShop.Model.SuitSchemeModel model=bll.GetModel(SchemeId);
		this.lblSchemeId.Text=model.SchemeId.ToString();
		this.txtSchemeName.Text=model.SchemeName;
		this.txtCreateTime.Text=model.CreateTime.ToString();
		this.txtStatus.Text=model.Status.ToString();
		this.txtSchemeDesc.Text=model.SchemeDesc;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtSchemeName.Text =="")
	{
		strErr+="SchemeName不能为空！\\n";	
	}
	if(!PageValidate.IsDateTime(txtCreateTime.Text))
	{
		strErr+="CreateTime不是时间格式！\\n";	
	}
	if(!PageValidate.IsNumber(txtStatus.Text))
	{
		strErr+="Status不是数字！\\n";	
	}
	if(this.txtSchemeDesc.Text =="")
	{
		strErr+="SchemeDesc不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string SchemeName=this.txtSchemeName.Text;
	DateTime CreateTime=DateTime.Parse(this.txtCreateTime.Text);
	int Status=int.Parse(this.txtStatus.Text);
	string SchemeDesc=this.txtSchemeDesc.Text;


	NoName.NetShop.Model.SuitSchemeModel model=new NoName.NetShop.Model.SuitSchemeModel();
	model.SchemeName=SchemeName;
	model.CreateTime=CreateTime;
	model.Status=Status;
	model.SchemeDesc=SchemeDesc;

	NoName.NetShop.BLL.SuitSchemeModelBll bll=new NoName.NetShop.BLL.SuitSchemeModelBll();
	bll.Update(model);

		}

    }
}
