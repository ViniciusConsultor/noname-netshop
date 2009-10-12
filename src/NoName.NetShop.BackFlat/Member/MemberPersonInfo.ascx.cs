using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoName.NetShop.BackFlat.Member
{
    public partial class MemberPersonInfo : System.Web.UI.UserControl, IShowExtentInfo
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
            NoName.NetShop.UserManager.BLL.MemberPerson bll = new NoName.NetShop.UserManager.BLL.MemberPerson();
            NoName.NetShop.UserManager.Model.MemberPerson model = bll.GetModel(userid);
            this.txttruename.Text = model.truename;
            this.txtIdCard.Text = model.IdCard;
            this.txtMobile.Text = model.Mobile;
            this.txtTelePhone.Text = model.TelePhone;
            this.txtEmail.Text = model.Email;
            this.txtUserLevel.Text = model.UserLevel.ToString();

        }
    }
}