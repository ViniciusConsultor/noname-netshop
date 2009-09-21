using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Profile;
using NoName.Utility;
using NoName.Security;
using NoName.NetShop.Common;

namespace NoName.NetShop.BackFlat.Admin
{
    public partial class UserInfo : System.Web.UI.Page
    {
        private string UserName
        {
            get { return (string)ViewState["UserName"]; }
            set { ViewState["UserName"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string userName = Request.QueryString["UserName"];
                if (userName == null || userName.Length == 0)
                {
                    throw new ShopException("请提供用户ID", true);
                }
                else
                {
                    UserName = userName;
                }

                ShowUserInfo(userName);
            }
        }
        /// <summary>
        /// 显示用户相关信息
        /// </summary>
        /// <param name="userName"></param>
        private void ShowUserInfo(string userName)
        {
            ShowBaseInfo(userName);
            ShowRolesInfo(userName);
            ShowUserStatus(userName);
        }
        /// <summary>
        /// 显示用户基本信息
        /// </summary>
        /// <param name="userName"></param>
        private void ShowBaseInfo(string userName)
        {
            AspnetUserExtInfo user = AspnetUserExt.GetUserExt(userName);

            lblUserId.Text = user.UserName;
            txtTrueName.Text = user.TrueName;
            txtMSN.Text = user.MSN;
            txtQQ.Text = user.QQ;
            txtPhone.Text = user.TelePhone;
            txtEmail.Text = user.Email;
            txtIdCard.Text = user.IdCard;
            txtMobile.Text = user.Mobile;
        }
        /// <summary>
        /// 显示用户状态
        /// </summary>
        /// <param name="userName"></param>
        private void ShowUserStatus(string userName)
        {
            MembershipUser user = Membership.GetUser(userName);

            chkIsApproved.Checked = user.IsApproved;
            chkIsLocked.Checked = user.IsLockedOut;

            if (user.IsLockedOut)
            {
                chkIsLocked.Visible = true;
            }
            else
            {
                chkIsLocked.Visible = false;
            }
        }
        /// <summary>
        /// 显示用户角色信息
        /// </summary>
        /// <param name="userName"></param>
        private void ShowRolesInfo(string userName)
        {
            MembershipUser user = Membership.GetUser(userName);

            string[] userRoles = Roles.GetRolesForUser(userName);
            string[] allRoles = Roles.GetAllRoles();
            clsRoleList.DataSource = allRoles;
            clsRoleList.DataBind();

            foreach(string role in userRoles)
            {
                clsRoleList.Items.FindByValue(role).Selected = true;
            }
           
        }
        /// <summary>
        /// 保存用户基本信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveUserInfo_Click(object sender, EventArgs e)
        {
            AspnetUserExtInfo user = new AspnetUserExtInfo();

            user.UserName = lblUserId.Text;
            user.TrueName = txtTrueName.Text.Trim();
            user.Email = txtEmail.Text.Trim();
            user.QQ = txtQQ.Text.Trim();
            user.MSN = txtMSN.Text.Trim();
            user.Mobile = txtMobile.Text.Trim();
            user.IdCard = txtIdCard.Text.Trim();
            user.TelePhone = txtPhone.Text.Trim();

            if (AspnetUserExt.SaveUserExt(user))
            {
                lblSaveUserInfoResult.Text = "保存成功";
            }
            else
            {
                lblSaveUserInfoResult.Text = "保存失败";
            }
        }

        /// <summary>
        /// 给用户添加角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveRolesToUser_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListItem item in clsRoleList.Items)
                {
                    if (item.Selected)
                    {
                        if (!Roles.IsUserInRole(UserName, item.Text))
                            Roles.AddUserToRole(UserName, item.Text);
                    }
                    else
                    {
                        if (Roles.IsUserInRole(UserName, item.Text))
                            Roles.RemoveUserFromRole(UserName, item.Text);
                    }
                }
                lblSaveRolesResult.Text = "保存成功";
            }
            catch
            {
                lblSaveRolesResult.Text = "保存失败";
            }

        }

        /// <summary>
        /// 重新设置用户密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSavePwd_Click(object sender, EventArgs e)
        {
            string newPass = txtPassword.Text;
            MembershipUser user = Membership.GetUser(UserName);
            string p = user.ResetPassword();
            if (user.ChangePassword(p,newPass))
            {
                this.lblSavePwdResult.Text = "重置成功";
            }
            else
            {
                this.lblSavePwdResult.Text = "重置失败";
            }
        }

        /// <summary>
        /// 修改用户状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSetStatus_Click(object sender, EventArgs e)
        {
    
            MembershipUser user = Membership.GetUser(UserName);
            user.IsApproved = chkIsApproved.Checked;
            
            Membership.UpdateUser(user);

            if (user.IsLockedOut && !chkIsLocked.Checked)
                user.UnlockUser();

            string result = "修改后的用户状态，";
            if (user.IsApproved)
            {
                result += "启用状态：是";
            }
            else
            {
                result += "启用状态：否";
            }

            if (user.IsLockedOut)
            {
                result += " 锁定状态：是";
            }
            else
            {
                result += " 锁定状态：否";
            }

            this.lblSetStatusResult.Text = result;
        }

        protected void lbtnChangeBrands_Click(object sender, EventArgs e)
        {
            Response.Redirect("BrandsOfUser.aspx?UserName=" + UserName);
        }

    }
}
