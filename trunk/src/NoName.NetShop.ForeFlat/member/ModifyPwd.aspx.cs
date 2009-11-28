using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using NoName.NetShop.Member;

namespace NoName.NetShop.ForeFlat.member
{
    public partial class ModifyPwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnDoChange_Click(object sender, EventArgs e)
        {
            string userId = Context.User.Identity.Name;
            string oldpass = txtOldPass.Text;
            string newpass1 = txtNewPass1.Text;
            string newpass2 = txtNewPass2.Text;
            if (newpass1 != "" && newpass1 == newpass2)
            {
                if (MemberInfo.ChangePassword(userId, oldpass, newpass1))
                {
                    lblResult.Text = "密码修改成功，下次登录请使用新密码";
                }
                else
                {
                    lblResult.Text = "密码修改失败";
                }
            }
        }
    }
}
