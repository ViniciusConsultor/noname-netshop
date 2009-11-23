using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Member;

namespace NoName.NetShop.BackFlat.Member
{
    public partial class UCFamlyMemberInfo : System.Web.UI.UserControl, IShowExtentInfo
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

        public void ShowInfo(string userId)
        {
            FamlyMemberInfo model = MemberInfo.GetFullInfo(userId, MemberType.Famly) as FamlyMemberInfo;
            this.txtidcard.Text = model.IdCard;
            this.txtAddress.Text = model.Address;
            this.txtprovince.Text = model.Province;
            this.txtcity.Text = model.City;
            this.txtcounty.Text = model.County;
            this.txtMobile.Text = model.Mobile;
            this.txtTelePhone.Text = model.Telephone;
        }
    }
}