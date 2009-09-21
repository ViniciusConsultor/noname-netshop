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
using System.Web.UI.MobileControls;
using System.Collections.Generic;

namespace NoName.NetShop.BackFlat.Admin
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUserList();
            }

        }

        private void BindUserList()
        {
            List<AspnetUserExtInfo> list = AspnetUserExt.GetAllUserExt();
            List<AspnetUserExtInfo> slist = list.FindAll(HasString);
            gvUserList.DataSource = slist;
            gvUserList.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindUserList();
        }

        private bool HasString(AspnetUserExtInfo user)
        {
            bool result = true;
            string key = txtKeyword.Text.Trim();
            if ( key != "")
            {
                result = (user.TrueName.IndexOf(key) >= 0 || user.UserName.IndexOf(key) >= 0);
            }
            return result;

        }

        protected void gvUserList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUserList.PageIndex = e.NewPageIndex;
            BindUserList();
        }

    }
}
