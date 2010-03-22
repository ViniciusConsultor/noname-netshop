using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.Security;
using NoName.NetShop.IMMessage;
using System.Web.Security;
using System.Threading;

namespace NoName.NetShop.BackFlat.message
{
    public partial class SendMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rblUserType.SelectedIndex = 0;
                ShowMsgType();
                ShowUsers();
            }
            else
            {
                Thread.Sleep(1000);
            }
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
                    model.MsgType = int.Parse(rblMsgType.SelectedValue);
                    model.UserId = item.Value;
                    model.SenderId = Context.User.Identity.Name;
                    model.Subject = subject;
                    model.Content = content;
                    model.UserType = int.Parse(rblUserType.SelectedValue);
                    mbll.Add(model);
                }
            }
            NoName.Utility.MessageBox.Show(this, "发送成功");
        }

        protected void rblMsgType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowUsers();
        }

        private void ShowMsgType()
        {
            switch (rblUserType.SelectedValue)
            {
                case "0": // 前台用户
                    foreach (ListItem item in rblMsgType.Items)
                    {
                        item.Selected = (item.Value == "1");
                        item.Enabled = false;
                    }
                    break;
                case "1": // 后台用户
                    foreach (ListItem item in rblMsgType.Items)
                    {
                        item.Enabled = true;
                    } 
                    break;
            }
            ShowUsers();
        }

        private void ShowUsers()
        {
            cblUsers.Items.Clear();
            switch (rblMsgType.SelectedValue)
            {
                case "0": // 用户消息
                    List<AspnetUserExtInfo> list = AspnetUserExt.GetAllUserExt();
                    cblUsers.DataSource = list;
                    cblUsers.DataTextField = "TrueName";
                    cblUsers.DataValueField = "UserName";
                    cblUsers.DataBind();
                    cblUsers.Enabled = true;
                    break;
                case "1": // 公告
                    cblUsers.Items.Add(new ListItem("所有用户", "alluser"));
                    cblUsers.SelectedIndex = 0;
                    cblUsers.Enabled = false;
                    break;
                case "2": // 组消息
                    string[] roles = Roles.GetAllRoles();
                    cblUsers.Items.Clear();
                    for (int i = 0; i < roles.Length; i++)
                    {
                        cblUsers.Items.Add(new ListItem(roles[i], roles[i]));
                    }
                    cblUsers.Enabled = true;
                    break;
            }
        }

        protected void rblUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowMsgType();
        }
    }
}
