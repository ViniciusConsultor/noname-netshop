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
namespace NoName.NetShop.Web.CommendModel
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
					//ShowInfo(SchemeId,CateId,ProductId);
				}
			}
		}
			
	private void ShowInfo(int SchemeId,int CateId,int ProductId)
	{
		NoName.NetShop.BLL.CommendModelBll bll=new NoName.NetShop.BLL.CommendModelBll();
		NoName.NetShop.Model.CommendModel model=bll.GetModel(SchemeId,CateId,ProductId);
		this.lblSchemeId.Text=model.SchemeId.ToString();
		this.lblCateId.Text=model.CateId.ToString();
		this.lblProductId.Text=model.ProductId.ToString();
		this.txtQuantity.Text=model.Quantity.ToString();

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(!PageValidate.IsNumber(txtQuantity.Text))
	{
		strErr+="Quantity不是数字！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	int Quantity=int.Parse(this.txtQuantity.Text);


	NoName.NetShop.Model.CommendModel model=new NoName.NetShop.Model.CommendModel();
	model.Quantity=Quantity;

	NoName.NetShop.BLL.CommendModelBll bll=new NoName.NetShop.BLL.CommendModelBll();
	bll.Update(model);

		}

    }
}
