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
namespace NoName.NetShop.Web.RuleModel
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
					//ShowInfo(SchemeId,CateId);
				}
			}
		}
			
	private void ShowInfo(int SchemeId,int CateId)
	{
		NoName.NetShop.BLL.RuleModelBll bll=new NoName.NetShop.BLL.RuleModelBll();
		NoName.NetShop.Model.RuleModel model=bll.GetModel(SchemeId,CateId);
		this.lblSchemeId.Text=model.SchemeId.ToString();
		this.lblCateId.Text=model.CateId.ToString();
		this.txtRule.Text=model.Rule;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtRule.Text =="")
	{
		strErr+="Rule不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string Rule=this.txtRule.Text;


	NoName.NetShop.Model.RuleModel model=new NoName.NetShop.Model.RuleModel();
	model.Rule=Rule;

	NoName.NetShop.BLL.RuleModelBll bll=new NoName.NetShop.BLL.RuleModelBll();
	bll.Update(model);

		}

    }
}
