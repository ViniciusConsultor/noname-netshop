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
namespace NoName.NetShop.Web.OrderChangeLogModel
{
    public partial class Modify : System.Web.UI.Page
    {       

        		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			(Master.FindControl("lblTitle") as Label).Text = "��Ϣ�޸�";
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
		this.txtOrderId.Text=model.OrderId.ToString();
		this.txtChangeTime.Text=model.ChangeTime.ToString();
		this.txtRemark.Text=model.Remark;
		this.txtOperator.Text=model.Operator;

	}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
	string strErr="";
	if(!PageValidate.IsNumber(txtOrderId.Text))
	{
		strErr+="OrderId�������֣�\\n";	
	}
	if(!PageValidate.IsDateTime(txtChangeTime.Text))
	{
		strErr+="ChangeTime����ʱ���ʽ��\\n";	
	}
	if(this.txtRemark.Text =="")
	{
		strErr+="Remark����Ϊ�գ�\\n";	
	}
	if(this.txtOperator.Text =="")
	{
		strErr+="Operator����Ϊ�գ�\\n";	
	}

	if(strErr!="")
	{
		MessageBox.Show(this,strErr);
		return;
	}
	int OrderId=int.Parse(this.txtOrderId.Text);
	DateTime ChangeTime=DateTime.Parse(this.txtChangeTime.Text);
	string Remark=this.txtRemark.Text;
	string Operator=this.txtOperator.Text;


	NoName.NetShop.Model.OrderChangeLogModel model=new NoName.NetShop.Model.OrderChangeLogModel();
	model.OrderId=OrderId;
	model.ChangeTime=ChangeTime;
	model.Remark=Remark;
	model.Operator=Operator;

	NoName.NetShop.BLL.OrderChangeLogModelBll bll=new NoName.NetShop.BLL.OrderChangeLogModelBll();
	bll.Update(model);

		}

    }
}
