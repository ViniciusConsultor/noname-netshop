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
namespace NoName.NetShop.Web.OrderChangeLogModel
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
					ShowInfo();
				}
			}
		}
		
	private void ShowInfo()
	{
		NoName.NetShop.BLL.OrderChangeLogModelBll bll=new NoName.NetShop.BLL.OrderChangeLogModelBll();
		NoName.NetShop.Model.OrderChangeLogModel model=bll.GetModel();
		this.lblOrderId.Text=model.OrderId.ToString();
		this.lblChangeTime.Text=model.ChangeTime.ToString();
		this.lblRemark.Text=model.Remark;
		this.lblOperator.Text=model.Operator;

	}


    }
}
