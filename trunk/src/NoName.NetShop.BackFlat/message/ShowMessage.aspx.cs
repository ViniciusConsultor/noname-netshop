using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.IMMessage;

namespace NoName.NetShop.BackFlat.message
{
    public partial class ShowMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int msgId;
                if (!int.TryParse(Request.QueryString["msgId"], out msgId))
                {
                    msgId = 0;
                }
                ShowMsg(msgId);
            }
        }

        private void ShowMsg(int msgId)
        {
            MessageBll mbll = new MessageBll();
            MessageModel model = mbll.GetModel(msgId);
            if (model != null && model.UserId == Context.User.Identity.Name)
            {
                lblContent.Text = model.Content;
                lblMsgId.Text = model.MsgId.ToString();
                lblSender.Text = model.SenderId;
                lblSendTime.Text = model.InsertTime.ToString("yyyy-MM-dd HH:mm");
                lblSubject.Text = model.Subject;
                mbll.SetIsReaded(model.MsgId);
            }
            else
            {
                    Response.Write("消息不存在");
                    Response.End();
            }
        }
    }
}
