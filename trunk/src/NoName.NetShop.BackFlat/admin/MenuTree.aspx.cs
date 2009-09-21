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
using System.Collections.Generic;

namespace NoName.NetShop.BackFlat.Admin
{
    public partial class MenuTree : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMenuTreeView();
                BindRolesList();
            }

        }

        #region 绑定树节点
        private void BindMenuTreeView()
        {
                DataTable table = AspnetMenu.GetMenusForManager();
            tvMenu.Nodes.Clear();
            
            string filter = "fatherId=0";
            DataRow[] rows = table.Select(filter,"path");
            foreach (DataRow row in rows)
            {
                TreeNode node = new TreeNode();
                node.Text = row["Title"].ToString();
                node.Value = row["MenuId"].ToString();
                node.ToolTip = row["Description"].ToString();
                BuidTreeNode(node, table);
                tvMenu.Nodes.Add(node);
            }
            tvMenu.ExpandAll();
        }

        private void BuidTreeNode(TreeNode fatherNode, DataTable source)
        {
            string filter = "fatherId=" + fatherNode.Value;
            DataRow[] rows = source.Select(filter,"path");
            foreach (DataRow row in rows)
            {
                TreeNode node = new TreeNode();
                node.Text = row["Title"].ToString();
                node.Value = row["MenuId"].ToString();
                node.ToolTip = row["Description"].ToString();
                fatherNode.ChildNodes.Add(node);
                BuidTreeNode(node, source);
            }
        }
        #endregion

        /// <summary>
        /// 添加新菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            TreeNode node = tvMenu.SelectedNode;

            lblMenuId.Text = "";
            lblFatherId.Text = (node == null ? "0" : node.Value);
            txtMenuName.Text = "";
            rblItemType.SelectedIndex = 0;
            txtdescription.Text = "";
            txtMenuKeys.Text = "";
            txtUrl.Text = "";
            foreach (ListItem item in chkRoles.Items)
            {
                item.Selected = false;
            }
        }

        protected void btnInserRootMenu_Click(object sender, EventArgs e)
        {
            lblMenuId.Text = "";
            lblFatherId.Text = "";
            txtMenuName.Text = "";
            rblItemType.SelectedIndex = 0;
            txtdescription.Text = "";
            txtMenuKeys.Text = "";
            txtUrl.Text = "";
            foreach (ListItem item in chkRoles.Items)
            {
                item.Selected = false;
            }
        }

        /// <summary>
        /// 菜单节点改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tvMenu_SelectedNodeChanged(object sender, EventArgs e)
        {
            TreeNode node = tvMenu.SelectedNode;
             int menuId = int.Parse(node.Value);

             if (menuId != 0)
             {
                 AspnetMenuItem item = AspnetMenu.GetMenuItem(menuId);

                 lblMenuId.Text = item.MenuId.ToString();
                 lblFatherId.Text = item.FatherId.ToString();
                 txtMenuName.Text = item.Title;
                 txtdescription.Text = item.Description;
                 txtMenuKeys.Text = item.Keywords;
                 rblItemType.SelectedIndex = item.ItemType;
                 txtUrl.Text = item.Url;

                 foreach (ListItem authitem in rblAuthType.Items)
                 {
                     if (authitem.Value == item.AuthType.ToString())
                     {
                         authitem.Selected = true;
                     }
                     else
                     {
                         authitem.Selected = false;
                     }
                 }

                 if (item.AuthType == 3)
                 {
                     chkRoles.Enabled = true;
                 }
                 else
                 {
                     chkRoles.Enabled = false;
                 }

                 btnDelete.Enabled = true;
                 btnSave.Enabled = true;

                 foreach (ListItem ritem in chkRoles.Items)
                 {
                     bool ischeck = false;
                     for(int i=0;i<item.Roles.Length;i++)
                     {
                         if (item.Roles[i] == ritem.Text)
                         {
                             ischeck = true;
                             break;
                         }
                     }
                     ritem.Selected = ischeck;
                 }
             }
             else
             {
                 lblMenuId.Text = node.Value;
                 txtMenuName.Text = node.Text;
                 btnDelete.Enabled = false;
                 btnSave.Enabled = false;
             }
         }

        /// <summary>
        /// 删除菜单节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int menuId = int.Parse(lblMenuId.Text);
            bool isForced = chkIsForced.Checked;
            bool result = AspnetMenu.DeleteMenuItem(menuId, isForced);
            if (result)
                lblResult.Text = "菜单删除成功";
            else
                lblResult.Text = "菜单删除失败";

            BindMenuTreeView();


        }

        /// <summary>
        /// 保存菜单节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int result = -1;
            bool isForced = chkIsForced.Checked;
            
            AspnetMenuItem item = new AspnetMenuItem();
            if (lblMenuId.Text != "")
            {
                item.MenuId = int.Parse(lblMenuId.Text);
            }

            if (lblFatherId.Text == "")
                item.FatherId = 0;
            else
                item.FatherId = int.Parse(lblFatherId.Text);

            item.Title = txtMenuName.Text;
            item.Description = txtdescription.Text.Trim();
            item.Keywords = txtMenuKeys.Text.Trim();
            item.Url = txtUrl.Text.Trim();
            item.ItemType = int.Parse(rblItemType.SelectedValue);
            item.AuthType = int.Parse(rblAuthType.SelectedValue);

            if (item.AuthType == 3)
            {
                List<string> roles = new List<string>();
                foreach (ListItem ritem in chkRoles.Items)
                {
                    if (ritem.Selected)
                        roles.Add(ritem.Text);
                }
                item.Roles = roles.ToArray();
            }
            else
            {
                item.Roles = new string[0];
            }

            if (item.MenuId > 0)
            {
                result = AspnetMenu.UpdateMenuItem(item, isForced);
            }
            else
            {
                result = AspnetMenu.AddMenuItem(item, isForced);
            }

                /*
                    0： 正常操作
                    1： 当前应用的父分类不存在
                    2： 当前应用中的URL已经被添加
                    3：  授权冲突，已存在相应基本URL的授权
                    4： 授权类型不正确
                    5： 输入的URL有错误
                    6：  当前应用不存在 
                 * */
            switch (result)
            {
                case 0:
                    lblResult.Text = "操作成功";
                    break;
                case 1:
                    lblResult.Text = "当前应用的父分类不存在";
                    break;
                case 2:
                    lblResult.Text = "当前应用中的URL已经被添加，可以通过添加参数来保证url不冲突";
                    break;
                case 3:
                    lblResult.Text = "授权冲突，已存在相应基本URL的授权";
                    break;
                case 4:
                    lblResult.Text = "授权类型不正确";
                    break;
                case 5:
                    lblResult.Text = "输入的URL有错误";
                    break;
                case 6:
                    lblResult.Text = "当前应用不存在";
                    break;
                default:
                    lblResult.Text = "发生不确定错误";
                    break;
            }
            BindMenuTreeView();
        }

        /// <summary>
        /// 更新菜单树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRenewTree_Click(object sender, EventArgs e)
        {
            BindMenuTreeView();
        }

        /// <summary>
        /// 绑定角色列表
        /// </summary>
        private void BindRolesList()
        {
            string[] roles = Roles.GetAllRoles();
            chkRoles.Items.Clear();
            for (int i = 0; i < roles.Length; i++)
            {
                chkRoles.Items.Add(new ListItem(roles[i], roles[i]));
            }
        }

        protected void rblAuthType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblAuthType.SelectedValue == "3")
                chkRoles.Enabled = true;
            else
                chkRoles.Enabled = false;
        }


    }
}
