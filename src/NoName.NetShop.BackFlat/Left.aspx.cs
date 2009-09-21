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
        /// ��֤�û���Ȩ��
        /// ��֤����
        /// ��1��û�б���¼��url�����κ��˷��ʣ�
        /// ��2��url�ϵ���ȨΪnull����""ʱ���ܾ��κ��û����ʣ�
        /// ��3��url�ϵ���Ȩ��ɫΪ�ʺ� (?) ����ʾ��url�ɱ��κ��û����ʣ�
        /// ��4��url�ϵ���Ȩ��ɫΪ�ʺ� (*) ����ʾ��url�ɱ��κ�ͨ����Ȩ��֤���û����ʣ�
        /// ��5��url�ϵ���ȨΪ��ɫ�б�ʱ����֤�û��ǲ���ͬʱ���ڸý�ɫ
        /// </summary>
        /// <param name="userRoles"></param>
        /// <param name="menuRoles"></param>
        /// <returns></returns>
        public bool IsMatch(string[] userRoles, IList menuRoles)
        {
            bool result = false;

            // �˵���û���κ���Ȩ
            if (menuRoles == null || menuRoles.Count == 0)
                return false;

            // �˵���Ȩ�������û�
            if (menuRoles.Contains("?"))
                return true;

            // �˵���Ȩ����¼���û�
            if (menuRoles.Contains("*") && Context.User.Identity.IsAuthenticated)
                return true;

            // �û�û���κν�ɫ��ͬʱ��������������
            if (userRoles == null)
                return false;
            // ����û���ɫ�Ͳ˵���ɫ��ƥ��
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
