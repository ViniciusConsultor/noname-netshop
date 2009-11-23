using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Member;

namespace NoName.NetShop.BackFlat.Member
{
    public partial class UCSchoolMemberInfo : System.Web.UI.UserControl, IShowExtentInfo
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

        public void ShowInfo(string userid)
        {
            SchoolMemberInfo model = MemberInfo.GetFullInfo(userid, MemberType.School) as SchoolMemberInfo;
            this.txtduty.Text = model.Duty.ToString();
            this.txtschool.Text = model.School;
            this.txtprovince.Text = model.Province;
            this.txtcity.Text = model.City;
            this.txtcounty.Text = model.County;
            this.txtMobile.Text = model.Mobile;
            this.txtTelePhone.Text = model.Telephone;
            this.txtFax.Text = model.Fax;
            this.txtAddress.Text = model.Address;

        }
    }
}