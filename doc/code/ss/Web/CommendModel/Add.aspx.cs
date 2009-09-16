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
namespace NoName.NetShop.Web.CommendModel
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
	if(!PageValidate.IsNumber(txtQuantity.Text))
	{
		strErr+="Quantity不是数字！\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	int Quantity=int.Parse(this.txtQuantity.Text);

	NoName.NetShop.Model.CommendModel model=new NoName.NetShop.Model.CommendModel();
	model.Quantity=Quantity;

	NoName.NetShop.BLL.CommendModelBll bll=new NoName.NetShop.BLL.CommendModelBll();
	bll.Add(model);

		}

    }
}
