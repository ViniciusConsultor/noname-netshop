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
using NoName.NetShop.Product.BLL;
using NoName.NetShop.Product.Model;

namespace NoName.NetShop.BackFlat.Category
{
    public partial class Show : System.Web.UI.Page
    {      
        protected void Page_LoadComplete(object sender, EventArgs e)
		{
            //(Master.FindControl("lblTitle") as Label).Text = "œÍœ∏–≈œ¢";
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null || Request.Params["id"].Trim() != "")
				{
					string id = Request.Params["id"];
					//ShowInfo(CateId);
				}
			}
		}
		
	    private void ShowInfo(int CateId)
	    {
		    CategoryModelBll bll=new CategoryModelBll();
		    CategoryModel model=bll.GetModel(CateId);

		    this.lblCateName.Text=model.CateName;
		    this.lblCatePath.Text=model.CatePath;
		    this.lblStatus.Text=model.Status.ToString();
		    this.lblPriceRange.Text=model.PriceRange;
		    this.chkIsHide.Checked=model.IsHide;
		    this.lblCateLevel.Text=model.CateLevel.ToString();
	    }


    }
}
