using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Member;

namespace NoName.NetShop.BackFlat.Member
{
    public partial class UCPersonMemberInfo : System.Web.UI.UserControl, IShowExtentInfo
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
            PersonMemberInfo model = MemberInfo.GetFullInfo(userid, MemberType.Famly) as PersonMemberInfo;
            this.txtIdCard.Text = model.IdCard;
            this.txtMobile.Text = model.Mobile;
            this.txtTelePhone.Text = model.Telephone;
            this.txtUserLevel.Text = model.UserLevel.ToString();
        }
    }
}