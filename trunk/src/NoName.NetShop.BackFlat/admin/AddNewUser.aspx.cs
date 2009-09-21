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
                lblResult.Text = "�û��Ѵ��ڣ�����������һ���û��ʺš�";
            }
            else
            {
                lblResult.Text = "���ʺſ���ʹ��";
            }

        }

        protected void btnSaveUserInfo_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtUserPassword.Text;
            string email = txtEmail.Text.Trim();
            bool status = chkSetActive.Checked;

            // �����û�
            MembershipUser user = null;
            try
            {
                user = Membership.CreateUser(userName, password, email);
            }
            catch(Exception ex)
            {
                lblResult.Text = "�����û�ʧ�ܣ�" + ex.Message;
                return;
            }

            // �����û�״̬
            user.IsApproved = status;
            user.Email = email;
            Membership.UpdateUser(user);

            // �����û���չ��Ϣ
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

            // �޸��û�������ɫ
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

            lblResult.Text = "�û������ɹ�";
        }


    }
}
