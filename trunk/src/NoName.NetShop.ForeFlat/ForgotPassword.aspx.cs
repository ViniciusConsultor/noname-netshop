using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Member;
using NoName.NetShop.Common;

namespace NoName.NetShop.ForeFlat
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divForgotPwd.Visible = true;
                divFail.Visible = false;
                divSucc.Visible = false;
                litOpName.Text = "找回密码";
                this.Title = "找回密码";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string vcode = txtValidCode.Text;
            ValidateHelper vhelper = new ValidateHelper();
            if (!vhelper.Validate(vcode, true))
            {
                lblPrompt.Text = "验证码错误";
                return;
            }

            divForgotPwd.Visible = false;
            divFail.Visible = false;
            divSucc.Visible = false;
            string userId = txtUserId.Text.Trim();
            string userEmail = txtEmail.Text.Trim();
            try
            {
                string password = MemberInfo.GetPassword(userId, userEmail);
                IMMessage.NotifyHelper.SendMail(userEmail, "鼎鼎通知：找回密码", "您的密码为：" + password + "，最好在下次登录时修改此密码!");
                divSucc.Visible = true;
                litOpName.Text = "提交成功";
                this.Title = "密码已发送";
            }
            catch
            {
                divFail.Visible = true;
                litOpName.Text = "提交失败";
                this.Title = "提交失败";
            }
        }
    }
}
