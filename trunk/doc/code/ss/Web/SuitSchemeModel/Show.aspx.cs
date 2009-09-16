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
namespace NoName.NetShop.Web.SuitSchemeModel
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
					//ShowInfo(SchemeId);
				}
			}
		}
		
	private void ShowInfo(int SchemeId)
	{
		NoName.NetShop.BLL.SuitSchemeModelBll bll=new NoName.NetShop.BLL.SuitSchemeModelBll();
		NoName.NetShop.Model.SuitSchemeModel model=bll.GetModel(SchemeId);
		this.lblSchemeName.Text=model.SchemeName;
		this.lblCreateTime.Text=model.CreateTime.ToString();
		this.lblStatus.Text=model.Status.ToString();
		this.lblSchemeDesc.Text=model.SchemeDesc;

	}


    }
}
