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
namespace NoName.NetShop.Web.SalesProductModel
{
    public partial class Modify : System.Web.UI.Page
    {       

        		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			(Master.FindControl("lblTitle") as Label).Text = "ÐÅÏ¢ÐÞ¸Ä";
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null || Request.Params["id"].Trim() != "")
				{
					string id = Request.Params["id"];
					//ShowInfo(ProductId,SaleType,SiteId);
				}
			}
		}
			
	private void ShowInfo(int ProductId,int SaleType,int SiteId)
	{
		NoName.NetShop.BLL.SalesProductModelBll bll=new NoName.NetShop.BLL.SalesProductModelBll();
		NoName.NetShop.Model.SalesProductModel model=bll.GetModel(ProductId,SaleType,SiteId);
		this.lblProductId.Text=model.ProductId.ToString();
		this.lblSaleType.Text=model.SaleType.ToString();
		this.lblSiteId.Text=model.SiteId.ToString();

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}


	NoName.NetShop.Model.SalesProductModel model=new NoName.NetShop.Model.SalesProductModel();

	NoName.NetShop.BLL.SalesProductModelBll bll=new NoName.NetShop.BLL.SalesProductModelBll();
	bll.Update(model);

		}

    }
}
