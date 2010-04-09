using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Member;

namespace NoName.NetShop.ForeFlat.member
{
    public partial class MyLevel : AuthBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowUserInfo();
            }
        }

        public void ShowUserInfo()
        {
            switch (CurrentUser.UserType)
            {
                case MemberType.Personal:
                    this.litUserLevel.Text = CurrentUser.UserLevel.ToString();
                    lbtnUpLevel.Visible = true;
                    break;
                case MemberType.Company:
                    this.litUserLevel.Text = "鼎企会员";
                    lbtnUpLevel.Visible = false;
                    break;
                case MemberType.Famly:
                    this.litUserLevel.Text = "鼎宅会员";
                    lbtnUpLevel.Visible = false;
                    break;
                case MemberType.School:
                    this.litUserLevel.Text = "鼎校会员";
                    lbtnUpLevel.Visible = false;
                    break;
            }
        }

        protected void lbtnChangeType_Click(object sender, EventArgs e)
        {
            MemberType userType = (MemberType)(Convert.ToInt32(ddlUserType.SelectedValue));
            if (CurrentUser.UserType != userType)
            {
                MemberInfo.ChangeUserType(CurrentUser.UserId, userType);
                ClientAlert("申请成功，等待管理员审核");
            }
            ClientAlert("用户类型不匹配");
        }

        protected void lbtnUpLevel_Click(object sender, EventArgs e)
        {
            UserLevel userLevel = (UserLevel)(Convert.ToInt32(ddlUserLevel.SelectedValue));
            if (userLevel > CurrentUser.UserLevel)
            {
                MemberInfo.ChangeUserLevel(CurrentUser.UserId, userLevel);
                ClientAlert("申请成功，等待管理员审核");
            }
            ClientAlert("选择的用户级别有问题");
        }
    }
}
