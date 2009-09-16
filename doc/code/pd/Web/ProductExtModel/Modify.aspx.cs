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
namespace NoName.NetShop.Web.ProductExtModel
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
					//ShowInfo(ProductId);
				}
			}
		}
			
	private void ShowInfo(int ProductId)
	{
		NoName.NetShop.BLL.ProductExtModelBll bll=new NoName.NetShop.BLL.ProductExtModelBll();
		NoName.NetShop.Model.ProductExtModel model=bll.GetModel(ProductId);
		this.lblProductId.Text=model.ProductId.ToString();
		this.txtProductDesc.Text=model.ProductDesc;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtProductDesc.Text =="")
	{
		strErr+="ProductDesc不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string ProductDesc=this.txtProductDesc.Text;


	NoName.NetShop.Model.ProductExtModel model=new NoName.NetShop.Model.ProductExtModel();
	model.ProductDesc=ProductDesc;

	NoName.NetShop.BLL.ProductExtModelBll bll=new NoName.NetShop.BLL.ProductExtModelBll();
	bll.Update(model);

		}

    }
}
