using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoName.NetShop.BackFlat.Member
{
    public partial class MemberCompanyInfo : System.Web.UI.UserControl, IShowExtentInfo
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ShowInfo(int userId)
        {
            NoName.NetShop.UserManager.BLL.MemberCompany bll = new NoName.NetShop.UserManager.BLL.MemberCompany();
            NoName.NetShop.UserManager.Model.MemberCompany model = bll.GetModel(userId);
            this.txttruename.Text = model.truename;
            this.txtidcard.Text = model.idcard;
            this.txtcompanyname.Text = model.companyname;
            this.txtprovince.Text = model.province;
            this.txtcity.Text = model.city;
            this.txtcounty.Text = model.county;
            this.txtMobile.Text = model.Mobile;
            this.txtTelePhone.Text = model.TelePhone;
            this.txtFax.Text = model.Fax;
            this.txtEmail.Text = model.Email;
        }

        public void SwitchReadOnly(bool isReadOnly)
        {
            foreach (Control cont in Controls)
            {
                if (cont is TextBox)
                {
                    ((TextBox)cont).ReadOnly = isReadOnly;
                }
            }
        }
    }
}