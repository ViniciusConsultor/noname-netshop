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
using System.Text;

namespace NoName.NetShop.BackFlat
{
    public partial class Left : System.Web.UI.Page
    {
        protected StringBuilder menu;
        private string[] userRoles;
        private static string DivMenuFormat = "<div class=head><a target='mainFrame' href='{0}' Title='{1}'>{2}</a></div>";
        private static string LiMenuFormat = "<li><a target='mainFrame' href='{0}' Title='{1}'>{2}</a></li>";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindUserMenu();
                BindUserMenuOnRepeater();
            }

        }

        private void BindUserMenuOnRepeater()
        {
            menu = new StringBuilder();

            SiteMapNode root = SiteMap.RootNode;

            if (Context.User.Identity.IsAuthenticated)
            {
                if (Context.User.Identity.Name == "admin")
                {
                    foreach (SiteMapNode snode in root.ChildNodes)
                    {
                        menu.Append("<div class='TopMenu'>");
                        menu.Append(BuiderHrefString(DivMenuFormat, snode));
                        BuilderSonMenus(snode);
                        menu.Append("</div>");
                    }
                }
                else
                {
                    userRoles = Roles.GetRolesForUser(Context.User.Identity.Name);
                    foreach (SiteMapNode snode in root.ChildNodes)
                    {
                        if (IsMatch(userRoles, snode.Roles))
                        {
                            menu.Append("<div class='TopMenu'>");
                            menu.Append(BuiderHrefString(DivMenuFormat, snode));
                            BuilderSonMenus(snode);
                            menu.Append("</div>");

                        }
                    }
                }
            }


        }

        private void BuilderSonMenus(SiteMapNode snode)
        {
            if (snode.HasChildNodes)
            {
                menu.Append("<ul>");
                foreach (SiteMapNode ssnode in snode.ChildNodes)
                {
                    if (IsMatch(userRoles, ssnode.Roles))
                    {
                        menu.Append(BuiderHrefString(LiMenuFormat, ssnode));
                        BuilderSonMenus(ssnode);
                    }
                }
                menu.Append("</ul>");
            }
        }

        private string BuiderHrefString(string format,SiteMapNode node)
        {
            return String.Format(format,String.IsNullOrEmpty(node.Url)?"javascript:return false;":
                this.ResolveUrl(node.Url),node.Description,node.Title);
        }

        /// <summary>
        /// 验证用户授权：
        /// 验证规则：
        /// （1）没有被记录的url允许任何人访问；
        /// （2）url上的授权为null或者""时，拒绝任何用户访问；
        /// （3）url上的授权角色为问号 (?) ，表示该url可被任何用户访问；
        /// （4）url上的授权角色为问号 (*) ，表示该url可被任何通过授权验证的用户访问；
        /// （5）url上的授权为角色列表时，验证用户是不是同时属于该角色
        /// </summary>
        /// <param name="userRoles"></param>
        /// <param name="menuRoles"></param>
        /// <returns></returns>
        public bool IsMatch(string[] userRoles, IList menuRoles)
        {
            bool result = false;

            // 菜单上没有任何授权
            if (menuRoles == null || menuRoles.Count == 0)
                return false;

            // 菜单授权给匿名用户
            if (menuRoles.Contains("?"))
                return true;

            // 菜单授权给登录的用户
            if (menuRoles.Contains("*") && Context.User.Identity.IsAuthenticated)
                return true;

            // 用户没有任何角色，同时不满足上述条件
            if (userRoles == null)
                return false;
            // 检查用户角色和菜单角色的匹配
            foreach (string role in userRoles)
            {
                if (menuRoles.Contains(role))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        protected void LoginStatus1_LoggedOut(object sender, EventArgs e)
        {

            string script = "<script language=javascript>window.top.location.href='Login.aspx';</script>";
            Response.Write(script);
            Response.End();
        }



    }
}
