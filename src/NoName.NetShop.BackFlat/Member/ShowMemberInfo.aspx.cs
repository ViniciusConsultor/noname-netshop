using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Member.Model;
using NoName.NetShop.Member;

namespace NoName.NetShop.BackFlat.Member
{
    public partial class ShowMemberInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["userId"]))
            {
                string userId = Request.QueryString["userId"];
                ShowInfo(userId);
            }
        }
        public void SwitchReadOnly(bool isReadOnly)
        {
            foreach (Control cont in Controls)
            {
                if (cont is TextBox)
                {
                    ((TextBox)cont).ReadOnly = isReadOnly;
                }
            }
        }


        private void ShowInfo(string userId)
        {
            MemberInfo model = MemberInfo.GetBaseInfo(userId);

            this.lbluserId.Text = model.UserId.ToString();
            this.txtUserEmail.Text = model.UserEmail;
            this.txtUserName.Text = model.UserName;
            this.txtAllScore.Text = model.AllScore.ToString();
            this.txtCurScore.Text = model.CurScore.ToString();
            this.txtLoginIP.Text = model.LoginIp;

            //0 未设定 1 个人会员 2 家庭会员 3 学校会员 4 企业会员 ：
            Control con = null;

            switch (model.UserType)
            {
                case MemberType.Initiation:
                    txtUserType.Text = "初始注册会员";
                    break;
                case MemberType.Company:
                    txtUserType.Text = "企业会员";
                    con = (Control)Page.LoadControl("UCCompanyMemberInfo.ascx");
                    break;
                case MemberType.Famly:
                    txtUserType.Text = "家庭会员";
                    con = (Control)Page.LoadControl("UCFamlyMemberInfo.ascx");
                    break;
                case MemberType.Personal:
                    txtUserType.Text = "个人会员";
                    con = (Control)Page.LoadControl("UCPersonMemberInfo.ascx");
                    break;
                case MemberType.School:
                    txtUserType.Text = "学校会员";
                    con = (Control)Page.LoadControl("UCSchoolMemberInfo.ascx");
                    break;
            }

            if (con != null && con is IShowExtentInfo)
            {
                IShowExtentInfo iext = con as IShowExtentInfo;
                iext.ShowInfo(userId);
                iext.SwitchReadOnly(true);
            }

            phExtentInfo.Controls.Clear();
            phExtentInfo.Controls.Add(con);

            switch (model.Status)
            {
                case MemberStatus.Initiation:
                    txtstatus.Text = "初始注册";
                    break;
                case MemberStatus.Deleted:
                    txtstatus.Text = "已删除";
                    break;
                case MemberStatus.Formal:
                    txtstatus.Text = "正式";
                    break;
                case MemberStatus.Locked:
                    txtstatus.Text = "锁定";
                    break;
            }

            this.txtLastLogin.Text = model.LastLogin.ToString("yyyy-MM-dd HH:mm");
            this.txtRegisterTime.Text = model.RegisterTime.ToString("yyyy-MM-dd HH:mm");
        }
    }
}
