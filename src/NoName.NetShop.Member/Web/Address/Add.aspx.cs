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
            Master.TabTitle="��Ϣ��ӣ�����ϸ��д������Ϣ";            
        }

        		protected void btnAdd_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtUserId.Text))
			{
				strErr+="UserId�������֣�\\n";	
			}
			if(!PageValidate.IsNumber(txtAddressId.Text))
			{
				strErr+="AddressId�������֣�\\n";	
			}
			if(this.txtProvince.Text =="")
			{
				strErr+="Province����Ϊ�գ�\\n";	
			}
			if(this.txtCity.Text =="")
			{
				strErr+="City����Ϊ�գ�\\n";	
			}
			if(this.txtAddressDetail.Text =="")
			{
				strErr+="AddressDetail����Ϊ�գ�\\n";	
			}
			if(this.txtRecieverName.Text =="")
			{
				strErr+="RecieverName����Ϊ�գ�\\n";	
			}
			if(this.txtMobile.Text =="")
			{
				strErr+="Mobile����Ϊ�գ�\\n";	
			}
			if(this.txtTelephone.Text =="")
			{
				strErr+="Telephone����Ϊ�գ�\\n";	
			}
			if(this.txtPostalcode.Text =="")
			{
				strErr+="Postalcode����Ϊ�գ�\\n";	
			}
			if(!PageValidate.IsDateTime(txtInsertTime.Text))
			{
				strErr+="InsertTime����ʱ���ʽ��\\n";	
			}
			if(!PageValidate.IsDateTime(txtModifyTime.Text))
			{
				strErr+="ModifyTime����ʱ���ʽ��\\n";	
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
