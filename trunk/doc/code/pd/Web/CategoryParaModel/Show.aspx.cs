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
namespace NoName.NetShop.Web.CategoryParaModel
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
					//ShowInfo(ParaId);
				}
			}
		}
		
	private void ShowInfo(int ParaId)
	{
		NoName.NetShop.BLL.CategoryParaModelBll bll=new NoName.NetShop.BLL.CategoryParaModelBll();
		NoName.NetShop.Model.CategoryParaModel model=bll.GetModel(ParaId);
		this.lblCateId.Text=model.CateId.ToString();
		this.lblParaName.Text=model.ParaName;
		this.lblParaType.Text=model.ParaType.ToString();
		this.lblStatus.Text=model.Status.ToString();
		this.lblParaGroupId.Text=model.ParaGroupId.ToString();
		this.lblParaValues.Text=model.ParaValues;
		this.lblDefaultValue.Text=model.DefaultValue;

	}


    }
}
