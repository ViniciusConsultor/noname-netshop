using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoName.NetShop.BackFlat.Member
{
    public partial class MemberSchoolInfo : System.Web.UI.UserControl, IShowExtentInfo
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        public void ShowInfo(int userid)
        {
            NoName.NetShop.UserManager.BLL.MemberSchool bll = new NoName.NetShop.UserManager.BLL.MemberSchool();
            NoName.NetShop.UserManager.Model.MemberSchool model = bll.GetModel(userid);
            this.txttruename.Text = model.truename;
            this.txtduty.Text = model.duty.ToString();
            this.txtschool.Text = model.school;
            this.txtprovince.Text = model.province;
            this.txtcity.Text = model.city;
            this.txtcounty.Text = model.county;
            this.txtMobile.Text = model.Mobile;
            this.txtTelePhone.Text = model.TelePhone;
            this.txtFax.Text = model.Fax;
            this.txtEmail.Text = model.Email;

        }
    }
}