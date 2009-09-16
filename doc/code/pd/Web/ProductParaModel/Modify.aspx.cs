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
namespace NoName.NetShop.Web.ProductParaModel
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
					//ShowInfo(ProductId,ParaId);
				}
			}
		}
			
	private void ShowInfo(int ProductId,int ParaId)
	{
		NoName.NetShop.BLL.ProductParaModelBll bll=new NoName.NetShop.BLL.ProductParaModelBll();
		NoName.NetShop.Model.ProductParaModel model=bll.GetModel(ProductId,ParaId);
		this.lblProductId.Text=model.ProductId.ToString();
		this.lblParaId.Text=model.ParaId.ToString();
		this.txtParaValue.Text=model.ParaValue;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(this.txtParaValue.Text =="")
	{
		strErr+="ParaValue不能为空！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	string ParaValue=this.txtParaValue.Text;


	NoName.NetShop.Model.ProductParaModel model=new NoName.NetShop.Model.ProductParaModel();
	model.ParaValue=ParaValue;

	NoName.NetShop.BLL.ProductParaModelBll bll=new NoName.NetShop.BLL.ProductParaModelBll();
	bll.Update(model);

		}

    }
}
