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
        #region IHttpModule ��Ա

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
                sb.Append("<title>��Ϊ��Ȩ���⣬���ʱ��ܾ���</title>" + System.Environment.NewLine);
                sb.Append("</head>" + System.Environment.NewLine);
                sb.Append("<body>" + System.Environment.NewLine);
                sb.Append("<div>��Ϊ��Ȩ���⣬���ʱ��ܾ������<a href=\"#\" onclick='javascript:history.back();' style='font-color:red'>����</a>�� </div>" + System.Environment.NewLine);
                sb.Append("</body></html>");

                app.Context.Response.Write(sb);
                app.Context.Response.End();
            }
        }

        /// <summary>
        /// ��֤�û���Ȩ��
        /// ��֤����
        /// ��1��û�б���¼��url�����κ��˷��ʣ�
        /// ��2��url�ϵ���ȨΪnull����""ʱ���ܾ��κ��û����ʣ�
        /// ��3��url�ϵ���Ȩ��ɫΪ�ʺ� (?) ����ʾ��url�ɱ��κ��û����ʣ�
        /// ��4��url�ϵ���Ȩ��ɫΪ�ʺ� (*) ����ʾ��url�ɱ��κ�ͨ����Ȩ��֤���û����ʣ�
        /// ��5��url�ϵ���ȨΪ��ɫ�б�ʱ����֤�û��ǲ���ͬʱ���ڸý�ɫ
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

            // ����ǳ�������Ա���������
            if (user.Identity.Name == "admin")
            {
                return true;
            }

            // ��1��û�б���¼��url�����κ��˷��ʣ�
            if (!maps.ContainsKey(url))
            {
                return true;
            }

            string menuroles = maps[url];
            // ��2��url�ϵ���ȨΪnull����""ʱ���ܾ��κ��û����ʣ�
            if (menuroles == null || menuroles == "")
            {
                return false;
            }

            // ��3��url�ϵ���Ȩ��ɫΪ�ʺ� (?) ����ʾ��url�ɱ��κ��û����ʣ�
            if (menuroles.Contains("?"))
            {
                return true;
            }
            // ��4��url�ϵ���Ȩ��ɫΪ�ʺ� (*) ����ʾ��url�ɱ��κ�ͨ����Ȩ��֤���û����ʣ�
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
