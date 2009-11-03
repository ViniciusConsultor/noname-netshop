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

namespace NoName.NetShop.UserManager.Web.Address
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.TabTitle="信息添加，请详细填写下列信息";            
        }

        		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtUserId.Text))
			{
				strErr+="UserId不是数字！\\n";	
			}
			if(!PageValidate.IsNumber(txtAddressId.Text))
			{
				strErr+="AddressId不是数字！\\n";	
			}
			if(this.txtProvince.Text =="")
			{
				strErr+="Province不能为空！\\n";	
			}
			if(this.txtCity.Text =="")
			{
				strErr+="City不能为空！\\n";	
			}
			if(this.txtAddressDetail.Text =="")
			{
				strErr+="AddressDetail不能为空！\\n";	
			}
			if(this.txtRecieverName.Text =="")
			{
				strErr+="RecieverName不能为空！\\n";	
			}
			if(this.txtMobile.Text =="")
			{
				strErr+="Mobile不能为空！\\n";	
			}
			if(this.txtTelephone.Text =="")
			{
				strErr+="Telephone不能为空！\\n";	
			}
			if(this.txtPostalcode.Text =="")
			{
				strErr+="Postalcode不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtInsertTime.Text))
			{
				strErr+="InsertTime不是时间格式！\\n";	
			}
			if(!PageValidate.IsDateTime(txtModifyTime.Text))
			{
				strErr+="ModifyTime不是时间格式！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int UserId=int.Parse(this.txtUserId.Text);
			int AddressId=int.Parse(this.txtAddressId.Text);
			string Province=this.txtProvince.Text;
			string City=this.txtCity.Text;
			string AddressDetail=this.txtAddressDetail.Text;
			string RecieverName=this.txtRecieverName.Text;
			string Mobile=this.txtMobile.Text;
			string Telephone=this.txtTelephone.Text;
			string Postalcode=this.txtPostalcode.Text;
			bool IsDefault=this.chkIsDefault.Checked;
			DateTime InsertTime=DateTime.Parse(this.txtInsertTime.Text);
			DateTime ModifyTime=DateTime.Parse(this.txtModifyTime.Text);

			NoName.NetShop.UserManager.Model.Address model=new NoName.NetShop.UserManager.Model.Address();
			model.UserId=UserId;
			model.AddressId=AddressId;
			model.Province=Province;
			model.City=City;
			model.AddressDetail=AddressDetail;
			model.RecieverName=RecieverName;
			model.Mobile=Mobile;
			model.Telephone=Telephone;
			model.Postalcode=Postalcode;
			model.IsDefault=IsDefault;
			model.InsertTime=InsertTime;
			model.ModifyTime=ModifyTime;

			NoName.NetShop.UserManager.BLL.Address bll=new NoName.NetShop.UserManager.BLL.Address();
			bll.Add(model);

		}

    }
}
