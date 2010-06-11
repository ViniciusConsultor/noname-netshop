using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Web.Security;
using NoName.Security;

namespace NoName.NetShop.BackFlat.admin
{
    public partial class AddRolesToAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAdmins();
                BindRoles();
                SetRolesState();
            }
        }

        private void SetRolesState()
        {
            string userID = ddlAdmins.SelectedValue;

            string[] roles = AspnetMenu.GetRolesOfAdmin(userID);
            foreach (ListItem item in chkRolesList.Items)
            {
                item.Selected = false;
            }
            if (roles != null)
            {
                foreach (string role in roles)
                {
                    ListItem item = chkRolesList.Items.FindByValue(role);
                    if (item != null)
                        item.Selected = true;
                }
            }
        }

        protected void btnSaveUsersToRole_Click(object sender, EventArgs e)
        {
            string username = ddlAdmins.SelectedValue;
            if (!String.IsNullOrEmpty(username))
            {
                List<string> selroles = new List<string>();
                foreach (ListItem item in chkRolesList.Items)
                {
                    if (item.Selected) selroles.Add(item.Value);
                }
                AspnetMenu.ChangeRolesOfAdmin(username, String.Join(",", selroles.ToArray()));
                SetRolesState();
            }
        }

        /// <summary>
        /// 绑定所有管理员
        /// </summary>
        private void BindAdmins()
        {
            string rolename = WebConfigurationManager.AppSettings["admin"];
            this.ddlAdmins.DataSource = Roles.GetUsersInRole(rolename);
            ddlAdmins.DataBind();
        }

        private void BindRoles()
        {
            this.chkRolesList.DataSource = Roles.GetAllRoles();
            this.chkRolesList.DataBind();
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            SetRolesState();

        }

    }
}
