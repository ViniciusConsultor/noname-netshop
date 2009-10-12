using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Member.Model;

namespace NoName.NetShop.BackFlat.Member
{
    public partial class MemberInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["userId"]))
            {
                int userId = int.Parse(Request.QueryString["userId"]);
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


        private void ShowInfo(int userId)
        {
            NoName.NetShop.UserManager.BLL.Member bll = new NoName.NetShop.UserManager.BLL.Member();
            NoName.NetShop.UserManager.Model.MemberModel model = bll.GetModel(userId);
            this.lbluserId.Text = model.userId.ToString();
            this.txtUserEmail.Text = model.UserEmail;
            this.txtNickName.Text = model.NickName;
            this.txtAllScore.Text = model.AllScore.ToString();
            this.txtCurScore.Text = model.CurScore.ToString();
            this.txtLoginIP.Text = model.LoginIP;

            //0 未设定 1 个人会员 2 家庭会员 3 学校会员 4 企业会员 ：
            Control con = null;

            switch (model.UserType)
            {
                case MemberType.Initiation:
                    txtUserType.Text = "初始注册会员";
                    break;
                case MemberType.Company:
                    txtUserType.Text = "企业会员";
                    con = (Control)Page.LoadControl("MemberCompanyInfo.ascx");
                    break;
                case MemberType.Famly:
                    txtUserType.Text = "家庭会员";
                    con = (Control)Page.LoadControl("MemberFamlyInfo.ascx");
                    break;
                case MemberType.Personal:
                    txtUserType.Text = "个人会员";
                    con = (Control)Page.LoadControl("MemberPersonInfo.ascx");
                    break;
                case MemberType.School:
                    txtUserType.Text = "学校会员";
                    con = (Control)Page.LoadControl("MemberSchoolInfo.ascx");
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
