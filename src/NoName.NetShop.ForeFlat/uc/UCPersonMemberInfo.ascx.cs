using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Member;

namespace NoName.NetShop.ForeFlat.Member
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

        public void ShowInfo(MemberInfo userInfo)
        {
            PersonMemberInfo model = userInfo as PersonMemberInfo;
            if (model != null)
            {
                this.txtIdCard.Text = model.IdCard;
                this.txtMobile.Text = model.Mobile;
                this.txtTelephone.Text = model.Telephone;
            }
        }

        public void GetInputInfo(MemberInfo userInfo)
        {
            PersonMemberInfo model = userInfo as PersonMemberInfo;
            if (model != null)
            {
                model.IdCard = txtIdCard.Text.Trim();
                model.Telephone = txtTelephone.Text.Trim();
                model.Mobile = txtMobile.Text.Trim();
            }
        }

    }
}