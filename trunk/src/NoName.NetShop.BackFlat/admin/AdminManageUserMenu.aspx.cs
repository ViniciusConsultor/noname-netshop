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


namespace NoName.NetShop.BackFlat.admin
{
    public partial class AdminManageUserMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRoleList();
                BindUserMenu();
            }

        }

        #region 针对角色的操作
         /// <summary>
        /// 绑定角色列表
        /// </summary>
        private void BindRoleList()
        {
            ddlRoles.DataSource = AspnetMenu.GetRolesOfAdmin(Context.User.Identity.Name);
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
        }

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

        private void GetAllCheckedNodeValueInTreeNode(TreeNode node, List<string> list)
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
        private TreeNode GetTreeNodeByValueInTreeView(TreeView tv, string value)
        {
            TreeNode result = null;
            foreach (TreeNode node in tv.Nodes)
            {
                result = GetTreeNodeByValueInTreeNode(node, value);
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
            foreach (TreeNode node in tv.Nodes)
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
