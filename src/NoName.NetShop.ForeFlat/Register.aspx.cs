using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Common;
using System.Web.Security;

namespace NoName.NetShop.ForeFlat
{
    public partial class Register : BasePage
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
            string useremail = txtUserEmail.Text.Trim();
            string nickname = txtNickName.Text.Trim();
            string password1 = txtPassword1.Text;
            string password2 = txtPassword2.Text;
            string vcode = txtValidCode.Text;
            ValidateHelper vhelper = new ValidateHelper();
            if (!String.IsNullOrEmpty(password1) && (password1 == password2) && vhelper.Validate(vcode, true))
            {
                NoName.NetShop.Member.Model.MemberModel memberModel = new NoName.NetShop.Member.Model.MemberModel();
                NoName.NetShop.Member.BLL.Member mbll = new NoName.NetShop.Member.BLL.Member();

                if (!mbll.Exists(useremail))
                {
                    memberModel.UserEmail = useremail;
                    memberModel.userId = NoName.NetShop.Common.CommDataHelper.GetNewSerialNum(AppType.Member);
                    memberModel.UserType = NoName.NetShop.Member.Model.MemberType.Initiation;
                    memberModel.NickName = nickname;
                    memberModel.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(password1, "MD5");
                    memberModel.Status = NoName.NetShop.Member.Model.MemberStatus.Formal;
                    mbll.Add(memberModel);

                    panReg.Visible = false;
                    panRegOk.Visible = true;

                    lblResult.Text = "亲爱的" + nickname + "，您已成功注册鼎鼎会员，欢迎继续进行其他操作";

                    if (!String.IsNullOrEmpty(Request.QueryString["returnUrl"]))
                    {
                        Response.AddHeader("REFRESH", "3;URL='" + Request.QueryString["returnUrl"] +"'");
                    }
                }
            }
        }
    }
}
