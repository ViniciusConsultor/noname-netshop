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
using NoName.NetShop.Product.BLL;
using NoName.NetShop.Product.Model;




namespace NoName.NetShop.BackFlat.Brand
{
    public partial class Show : System.Web.UI.Page
    {        
        		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			(Master.FindControl("lblTitle") as Label).Text = "œÍœ∏–≈œ¢";
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
		BrandModelBll bll=new BrandModelBll();
        BrandModel model = bll.GetModel(BrandId);
		this.lblBrandName.Text=model.BrandName;
		this.lblCateId.Text=model.CateId.ToString();
		this.lblCatePath.Text=model.CatePath;
		this.lblBrandLogo.Text=model.BrandLogo;
		this.lblBrief.Text=model.Brief;

	}


    }
}
