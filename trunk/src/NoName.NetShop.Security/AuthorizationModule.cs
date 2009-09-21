using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using NoName.Security;
using System.Security.Authentication;
using System.Security.Principal;

namespace NoName.Security
{
    class AuthorizationModule : System.Web.IHttpModule
    {
        #region IHttpModule 成员

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.AuthorizeRequest += new EventHandler(context_AuthorizeRequest);
        }

        void context_AuthorizeRequest(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;

            if (!ValidUserMenu(app))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<html>" + System.Environment.NewLine);
                sb.Append("<head>" + System.Environment.NewLine);
                sb.Append("<title>因为授权问题，访问被拒绝。</title>" + System.Environment.NewLine);
                sb.Append("</head>" + System.Environment.NewLine);
                sb.Append("<body>" + System.Environment.NewLine);
                sb.Append("<div>因为授权问题，访问被拒绝。点击<a href=\"#\" onclick='javascript:history.back();' style='font-color:red'>返回</a>。 </div>" + System.Environment.NewLine);
                sb.Append("</body></html>");

                app.Context.Response.Write(sb);
                app.Context.Response.End();
            }
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
        /// <param name="url"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        private bool ValidUserMenu(HttpApplication application)
        {
            bool result = false;

            string url = null;
            if (AspnetMenu.IsAppRootPath)
                url = application.Context.Request.AppRelativeCurrentExecutionFilePath.ToLower();
            else
                url = application.Context.Request.Url.AbsolutePath.ToLower();

            Dictionary<string, string> maps = AspnetMenu.GetAllMenuRoleMaps();
            IPrincipal user = application.Context.User;

            // 如果是超级管理员，允许访问
            if (user.Identity.Name == "admin")
            {
                return true;
            }

            // （1）没有被记录的url允许任何人访问；
            if (!maps.ContainsKey(url))
            {
                return true;
            }

            string menuroles = maps[url];
            // （2）url上的授权为null或者""时，拒绝任何用户访问；
            if (menuroles == null || menuroles == "")
            {
                return false;
            }

            // （3）url上的授权角色为问号 (?) ，表示该url可被任何用户访问；
            if (menuroles.Contains("?"))
            {
                return true;
            }
            // （4）url上的授权角色为问号 (*) ，表示该url可被任何通过授权验证的用户访问；
            if (user == null || !user.Identity.IsAuthenticated)
            {
                return false;
            }

            if (menuroles.Contains("*"))
            {
                return true;
            }

            string[] roles = Roles.GetRolesForUser(user.Identity.Name);
            menuroles = "," + menuroles + ",";
            for (int i = 0; i < roles.Length; i++)
            {
                if (menuroles.IndexOf("," + roles[i] + ",") != -1)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        #endregion



    }
}
