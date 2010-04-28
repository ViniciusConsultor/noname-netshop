using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Common;
using System.Web.Security;
using NoName.NetShop.Member;

namespace NoName.NetShop.ForeFlat
{
    public partial class RegPerson : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                panReg.Visible = true;
                panRegOk.Visible = false;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string userId = txtUserId.Text.Trim();
            string useremail = txtUserEmail.Text.Trim();
            string userName = txtUserName.Text.Trim();
            string password1 = txtPassword1.Text;
            string password2 = txtPassword2.Text;
            string vcode = txtValidCode.Text;
            ValidateHelper vhelper = new ValidateHelper();
            if (!String.IsNullOrEmpty(password1) && (password1 == password2) && vhelper.Validate(vcode, true))
            {

                if (!MemberInfo.Exists(userId, useremail))
                {
                    PersonMemberInfo memberModel = new PersonMemberInfo();
                    memberModel.UserEmail = useremail;
                    memberModel.UserId = userId;
                    memberModel.UserType = MemberType.Personal;
                    memberModel.UserName = userName;

                    memberModel.Password = password1;
                    memberModel.Status = MemberStatus.Formal;
                    memberModel.LoginIp = Request.UserHostAddress;

                    memberModel.IdCard = txtIdCard.Text.Trim();
                    memberModel.Telephone = txtTelephone.Text.Trim();
                    memberModel.Mobile = txtMobile.Text.Trim();
                    memberModel.Save();
                    //mbll.Add(memberModel);

                    panReg.Visible = false;
                    panRegOk.Visible = true;

                    ClientAlert("亲爱的" + userName + "，您已成功注册鼎鼎会员，欢迎继续进行其他操作");
                    FormsAuthentication.RedirectToLoginPage();

                    //if (!String.IsNullOrEmpty(Request.QueryString["returnUrl"]))
                    //{
                    //    Response.AddHeader("REFRESH", "3;URL='" + Request.QueryString["returnUrl"] + "'");
                    //}
                }
                else
                {
                    lblPrompt.Text = "用户已存在！";
                }
            }
            else
            {
                lblPrompt.Text = "验证失败，请检查你的密码是否一致！";
            }
        }
    }
}
