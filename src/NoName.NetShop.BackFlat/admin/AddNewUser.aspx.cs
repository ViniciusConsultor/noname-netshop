using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NoName.Security;

namespace NoName.NetShop.BackFlat.Admin
{
    public partial class AddNewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRolesList();
            }

        }

        private void BindRolesList()
        {
            string[] roles = Roles.GetAllRoles();
            chkRoles.DataSource = roles;
            chkRoles.DataBind();
        }


        protected void lbtnCheckExists_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            if (Membership.GetUser(userName) != null)
            {
                lblResult.Text = "用户已存在，请重新输入一个用户帐号。";
            }
            else
            {
                lblResult.Text = "此帐号可以使用";
            }

        }

        protected void btnSaveUserInfo_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtUserPassword.Text;
            string email = txtEmail.Text.Trim();
            bool status = chkSetActive.Checked;

            // 创建用户
            MembershipUser user = null;
            try
            {
                user = Membership.CreateUser(userName, password, email);
            }
            catch(Exception ex)
            {
                lblResult.Text = "创建用户失败：" + ex.Message;
                return;
            }

            // 修养用户状态
            user.IsApproved = status;
            user.Email = email;
            Membership.UpdateUser(user);

            // 保存用户扩展信息
            AspnetUserExtInfo profile = new AspnetUserExtInfo();
            profile.UserName = user.UserName;
            profile.TrueName = txtTrueName.Text.Trim();
            profile.Email = txtEmail.Text.Trim();
            profile.QQ = txtQQ.Text.Trim();
            profile.MSN = txtMSN.Text.Trim();
            profile.Mobile = txtMobile.Text.Trim();
            profile.IdCard = txtIdCard.Text.Trim();
            profile.TelePhone = txtPhone.Text.Trim();
            AspnetUserExt.SaveUserExt(profile);

            // 修改用户所属角色
            foreach (ListItem item in chkRoles.Items)
            {
                if (item.Selected)
                {
                    if (!Roles.IsUserInRole(user.UserName, item.Text))
                        Roles.AddUserToRole(user.UserName, item.Text);
                }
                else
                {
                    if (Roles.IsUserInRole(user.UserName, item.Text))
                        Roles.RemoveUserFromRole(user.UserName, item.Text);
                }
            }

            lblResult.Text = "用户创建成功";
        }


    }
}
