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
namespace NoName.NetShop.Web.PartProductModel
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
					//ShowInfo(ProductId,PartProductId);
				}
			}
		}
			
	private void ShowInfo(int ProductId,int PartProductId)
	{
		NoName.NetShop.BLL.PartProductModelBll bll=new NoName.NetShop.BLL.PartProductModelBll();
		NoName.NetShop.Model.PartProductModel model=bll.GetModel(ProductId,PartProductId);
		this.lblProductId.Text=model.ProductId.ToString();
		this.lblPartProductId.Text=model.PartProductId.ToString();

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}


	NoName.NetShop.Model.PartProductModel model=new NoName.NetShop.Model.PartProductModel();

	NoName.NetShop.BLL.PartProductModelBll bll=new NoName.NetShop.BLL.PartProductModelBll();
	bll.Update(model);

		}

    }
}
