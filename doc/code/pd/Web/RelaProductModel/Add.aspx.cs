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
namespace NoName.NetShop.Web.RelaProductModel
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			(Master.FindControl("lblTitle") as Label).Text = "–≈œ¢ÃÌº”";
		}
		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}

	NoName.NetShop.Model.RelaProductModel model=new NoName.NetShop.Model.RelaProductModel();

	NoName.NetShop.BLL.RelaProductModelBll bll=new NoName.NetShop.BLL.RelaProductModelBll();
	bll.Add(model);

		}

    }
}
