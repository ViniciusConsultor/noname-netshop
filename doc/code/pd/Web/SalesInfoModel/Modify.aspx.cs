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
namespace NoName.NetShop.Web.SalesInfoModel
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
					//ShowInfo(SalesType,ProductId,RuleType);
				}
			}
		}
			
	private void ShowInfo(int SalesType,int ProductId,int RuleType)
	{
		NoName.NetShop.BLL.SalesInfoModelBll bll=new NoName.NetShop.BLL.SalesInfoModelBll();
		NoName.NetShop.Model.SalesInfoModel model=bll.GetModel(SalesType,ProductId,RuleType);
		this.lblSalesType.Text=model.SalesType.ToString();
		this.lblProductId.Text=model.ProductId.ToString();
		this.lblRuleType.Text=model.RuleType.ToString();
		this.txtSortValue.Text=model.SortValue.ToString();

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(!PageValidate.IsNumber(txtSortValue.Text))
	{
		strErr+="SortValue不是数字！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	int SortValue=int.Parse(this.txtSortValue.Text);


	NoName.NetShop.Model.SalesInfoModel model=new NoName.NetShop.Model.SalesInfoModel();
	model.SortValue=SortValue;

	NoName.NetShop.BLL.SalesInfoModelBll bll=new NoName.NetShop.BLL.SalesInfoModelBll();
	bll.Update(model);

		}

    }
}
