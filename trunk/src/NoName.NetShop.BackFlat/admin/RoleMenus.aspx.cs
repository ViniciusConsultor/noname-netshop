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
using NoName.Utility;
 using System.Xml;
using System.Text;
using System.Web.Services;
using System.Collections.Generic;


namespace NoName.NetShop.BackFlat.Admin
{
    public partial class RoleMenus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRoleList();
                BindUserList();
                BindUserMenu();
            }

        }

        #region 针对角色的操作
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            bool result = Roles.DeleteRole(ddlRoles.SelectedValue);
            BindRoleList();            
            if (result)
                lblResult.Text = "删除成功";
            else
                lblResult.Text = "删除失败";
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Roles.CreateRole(txtRoleName.Text.Trim());
            BindRoleList();
        }
        /// <summary>
        /// 绑定角色列表
        /// </summary>
        private void BindRoleList()
        {
            ddlRoles.DataSource = Roles.GetAllRoles();
            ddlRoles.DataBind();
            ddlRoles.SelectedIndex = 0;
        }

        /// <summary>
        /// 角色列表变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetMenuTreeViewState();
            SetUserListState();
        }

        #endregion


        #region 针对用户列表的操作
        #region 用户绑定的操作，按商户分组

        // 设置用户的选中状态
        private void SetUserListState()
        {
            string rolename = ddlRoles.SelectedValue;

            foreach (ListItem uitem in chkUserList.Items)
            {
                string username = uitem.Value;
                uitem.Selected = Roles.IsUserInRole(username, rolename);
            }
        }


        private void BindUserList()
        {
            AspnetUserExtInfo user = new AspnetUserExtInfo();

            List<AspnetUserExtInfo> users = AspnetUserExt.GetAllUserExt();
            chkUserList.DataSource = users;
            chkUserList.DataTextField = "TrueName";
            chkUserList.DataValueField = "Username";
            chkUserList.DataBind();
            SetUserListState();
        }

        #endregion

        #region 保存用户到角色中
        protected void btnSaveUsersToRole_Click(object sender, EventArgs e)
        {
            List<string> userlist = new List<string>();

            foreach (ListItem citem in chkUserList.Items)
            {
                if (citem.Selected)
                    userlist.Add(citem.Value);
            }

            string rolename = ddlRoles.SelectedValue;
            string[] oldUsers = Roles.GetUsersInRole(rolename);
            string[] newUsers = userlist.ToArray();
            string[] addUsers = GetAddUsers(oldUsers, newUsers);
            string[] removeUsers = GetRemoveUsers(oldUsers, newUsers);
            if (removeUsers.Length > 0)
                Roles.RemoveUsersFromRole(removeUsers, rolename);
            if (addUsers.Length > 0)
                Roles.AddUsersToRole(addUsers, rolename);

        }

        /// <summary>
        /// 获得要移除的用户名单
        /// </summary>
        /// <param name="oldUsers"></param>
        /// <param name="newUsers"></param>
        /// <returns></returns>
        private string[] GetRemoveUsers(string[] oldUsers, string[] newUsers)
        {
            List<string> removeUsers = new List<string>();
            foreach (string olduser in oldUsers)
            {
                bool isRemove = true;
                foreach (string newuser in newUsers)
                {
                    if (olduser == newuser)
                    {
                        isRemove = false;
                        break;
                    }
                }
                if (isRemove)
                {
                    removeUsers.Add(olduser);
                }
            }
            return removeUsers.ToArray();
        }
        /// <summary>
        /// 获得要增加的用户名单
        /// </summary>
        /// <param name="oldUsers"></param>
        /// <param name="newUsers"></param>
        /// <returns></returns>
        private string[] GetAddUsers(string[] oldUsers, string[] newUsers)
        {
            List<string> addUsers = new List<string>();

            foreach (string newuser in newUsers)
            {
                bool isAdd = true;
                foreach (string olduser in oldUsers)
                {
                    if (newuser == olduser)
                    {
                        isAdd = false;
                        break;
                    }
                }
                if (isAdd)
                {
                    addUsers.Add(newuser);
                }
            }
            return addUsers.ToArray();
        }

        #endregion

        #endregion



        #region 针对菜单的操作


        private void SetMenuTreeViewState()
        {
             SetTreeViewChecked(tvMenus, false);
             string role = ddlRoles.SelectedValue;
            if (role != "")
            {
                string[] menus = AspnetMenu.GetMenusOfRole(role);
                if (menus != null)
                {
                    for (int i = 0; i < menus.Length; i++)
                    {
                        TreeNode node = GetTreeNodeByValueInTreeView(tvMenus, menus[i]);
                        if (node != null)
                        {
                            node.Checked = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 保存用户的角色菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveMenusOfRole_Click(object sender, EventArgs e)
        {
            string rolename = ddlRoles.SelectedValue;
            List<string> list = GetAllCheckedValueInTreeView(tvMenus);
            if (list.Count > 0)
            {
                string menus = String.Join(",", list.ToArray());
                AspnetMenu.ChangeMenusOfRole(rolename, menus);
            }
        }       
        

        #region 针对TreeView的操作

        private void BindUserMenu()
        {
            DataTable table = AspnetMenu.GetMenusForSitemap();
            string filter = "fatherid=0";
            DataRow[] rows = table.Select(filter);

            foreach (DataRow row in rows)
            {
                TreeNode tnode = new TreeNode();
                tnode.Text = row["Title"].ToString();
                tnode.ToolTip = row["Description"].ToString();
                tnode.NavigateUrl = row["Url"].ToString();
                tnode.Value = row["MenuId"].ToString();

                int authtype = Convert.ToInt16(row["AuthType"]);

                //tnode.Checked = (authtype == 1 || authtype == 2);

                tnode.ShowCheckBox = (authtype == 3);
 
                BindTreeNode(tnode, table);
                tvMenus.Nodes.Add(tnode);
            }
        }

        private void BindTreeNode(TreeNode tnode, DataTable table)
        {
            string filter = "fatherid=" + tnode.Value;
            DataRow[] rows = table.Select(filter);
            foreach (DataRow row in rows)
            {
                TreeNode tsnode = new TreeNode();
                tsnode.Text = row["Title"].ToString();
                tsnode.ToolTip = row["Description"].ToString();
                tsnode.NavigateUrl = row["Url"].ToString();
                tsnode.Value = row["MenuId"].ToString();

                int authtype = Convert.ToInt16(row["AuthType"]);

                //tnode.Checked = (authtype == 1 || authtype == 2);

                tsnode.ShowCheckBox = (authtype == 3);
                BindTreeNode(tsnode, table);
                tnode.ChildNodes.Add(tsnode);
            }
        }



        /// <summary>
        /// 获得节点树中的所有选中值
        /// </summary>
        /// <param name="tv"></param>
        /// <returns></returns>
        private List<string> GetAllCheckedValueInTreeView(TreeView tv)
        {
            List<string> list = new List<string>();
            foreach (TreeNode node in tv.Nodes)
            {
                GetAllCheckedNodeValueInTreeNode(node, list);
            }
            return list;
        }

        private void GetAllCheckedNodeValueInTreeNode(TreeNode node,List<string> list)
        {
            if (node.Checked)
                list.Add(node.Value);
            foreach (TreeNode sonnode in node.ChildNodes)
            {
                GetAllCheckedNodeValueInTreeNode(sonnode, list);
            }
        }

        /// <summary>
        /// 根据指定值查找节点，查找到一个即退出
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private TreeNode GetTreeNodeByValueInTreeView(TreeView tv,string value)
        {
            TreeNode result = null;
            foreach(TreeNode node in tv.Nodes)
            {
                result = GetTreeNodeByValueInTreeNode(node,value);
                if (result != null)
                {
                    break;
                }
            }
            return result;
        }

        private TreeNode GetTreeNodeByValueInTreeNode(TreeNode node, string value)
        {
            TreeNode result = null;
            if (node.Value == value)
                result = node;
            else
            {
                foreach (TreeNode sonnode in node.ChildNodes)
                {
                    result = GetTreeNodeByValueInTreeNode(sonnode, value);
                    if (result != null)
                        break;
                }
            }
            return result;
        }

        /// <summary>
        /// 设置所有的TreeNode的选中状态
        /// </summary>
        /// <param name="tv"></param>
        /// <param name="status"></param>
        private void SetTreeViewChecked(TreeView tv, bool status)
        {
            foreach(TreeNode node in tv.Nodes)
            {
                 SetTreeNodeChecked(node, status);
            }
        }

        private void SetTreeNodeChecked(TreeNode node, bool status)
        {
            node.Checked = status;
            foreach (TreeNode sonnode in node.ChildNodes)
            {
                SetTreeNodeChecked(sonnode, status);
            }
        }

        #endregion

        protected void tvMenus_PreRender(object sender, EventArgs e)
        {
            SetMenuTreeViewState();
        }


        #endregion

        protected void btnApp_Click(object sender, EventArgs e)
        {
            AspnetMenu.ResetCache();
        }


    }
}
