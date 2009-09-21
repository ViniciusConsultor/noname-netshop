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
    public partial class CacheReset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showWebCache();
            }

        }

        protected void btnResetMenuCache_Click(object sender, EventArgs e)
        {
            AspnetMenu.ResetCache();
            lblResult.Text = "����˲˵���ػ���";
        }

        protected void btnResetHttpCache_Click(object sender, EventArgs e)
        {
            IDictionaryEnumerator CacheEnum = Cache.GetEnumerator();
            ArrayList al = new ArrayList();
            while (CacheEnum.MoveNext())
            {
                al.Add(CacheEnum.Key);
            }

            foreach (string key in al)
            {
                Cache.Remove(key);
            }
            showWebCache();
        }

        void showWebCache()
        {
            string str = "";
            IDictionaryEnumerator CacheEnum = Cache.GetEnumerator();

            while (CacheEnum.MoveNext())
            {
                str += "������<b>[" + CacheEnum.Key + "]</b><br />";
            }
            this.lblHttpCache.Text = "��ǰ��վ�ܻ�����:" + Cache.Count + "<br />" + str;
        }

        protected void btnResetApp_Click(object sender, EventArgs e)
        {
            HttpRuntime.UnloadAppDomain();
        } 
    }
}
