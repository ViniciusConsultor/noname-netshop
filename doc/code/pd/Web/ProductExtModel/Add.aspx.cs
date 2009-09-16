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
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			(Master.FindControl("lblTitle") as Label).Text = "信息添加";
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
	bll.Add(model);

		}

    }
}
