using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.Security;
using NoName.NetShop.IMMessage;

namespace NoName.NetShop.BackFlat.message
{
    public partial class SendMessage : System.Web.UI.Page
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

            cblUsers.DataSource = list;
            cblUsers.DataTextField = "TrueName";
            cblUsers.DataValueField = "UserName";
            cblUsers.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            NoName.NetShop.IMMessage.MessageBll mbll = new NoName.NetShop.IMMessage.MessageBll();
            List<string> users = new List<string>();
            string content = txtContent.Text.Trim();
            string subject = txtSubject.Text.Trim();
            foreach (ListItem item in cblUsers.Items)
            {
                if (item.Selected)
                {
                    MessageModel model = new MessageModel();
                    model.MsgId = 0;
                    model.MsgType = 3;
                    model.UserId = item.Value;
                    model.SenderId = Context.User.Identity.Name;
                    model.Subject = subject;
                    model.Content = content;
                    model.UserType = 1;
                    mbll.Add(model);
                }
            }
            NoName.Utility.MessageBox.Show(this, "发送成功");
        }
    }
}
