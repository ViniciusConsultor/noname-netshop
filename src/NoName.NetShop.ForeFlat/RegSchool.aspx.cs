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
    public partial class RegSchool : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                panReg.Visible = true;
                ucRegion.PresetRegionInfo(String.Empty);
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
                    SchoolMemberInfo memberModel = new SchoolMemberInfo();
                    memberModel.UserEmail = useremail;
                    memberModel.UserId = userId;
                    memberModel.UserType = MemberType.School;
                    memberModel.UserName = userName;

                    memberModel.Password = password1;
                    memberModel.Status = MemberStatus.Initiation;
                    memberModel.LoginIp = Request.UserHostAddress;

                    memberModel.School = txtSchoolName.Text.Trim();
                    memberModel.Duty = txtDuty.Text.Trim();
                    memberModel.Telephone = txtTelephone.Text.Trim();
                    memberModel.Mobile = txtMobile.Text.Trim();
                    memberModel.Fax = txtFax.Text.Trim();

                    RegionInfo regionInfo = ucRegion.GetSelectedRegionInfo();
                    memberModel.RegionPath = regionInfo.RegionPath;
                    memberModel.Country = regionInfo.Country;
                    memberModel.Province = regionInfo.Province;
                    memberModel.City = regionInfo.City;
                    memberModel.County = regionInfo.County;
                    memberModel.Address = txtAddress.Text.Trim();

                    memberModel.Save();
                    //mbll.Add(memberModel);

                    panReg.Visible = false;
                    panRegOk.Visible = true;

                    ClientAlert("亲爱的" + userName + "，您已成功注册鼎鼎会员，欢迎继续进行其他操作");
                    IMMessage.NotifyHelper.SendMessage(userId, "欢迎您注册为鼎鼎会员", "欢迎您注册为鼎鼎会员");

                    string userData = String.Format("{0}:{1}:{2}:{3}:{4}", memberModel.UserEmail, memberModel.UserName, (int)memberModel.Status, (int)memberModel.UserType, (int)memberModel.UserLevel);
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                      userId,
                      DateTime.Now,
                      DateTime.Now.AddMinutes(30), true,
                      userData,
                      FormsAuthentication.FormsCookiePath);

                    string encTicket = FormsAuthentication.Encrypt(ticket);

                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                    if (!String.IsNullOrEmpty(Request.QueryString["returnUrl"]))
                    {
                        //Response.AddHeader("REFRESH", "3;URL='" + Request.QueryString["returnUrl"] + "'");
                        Response.Redirect(Request.QueryString["returnUrl"], true);
                    }
                    else
                    {
                        Response.Redirect("~/member/myProfile.aspx", true);
                    }
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
