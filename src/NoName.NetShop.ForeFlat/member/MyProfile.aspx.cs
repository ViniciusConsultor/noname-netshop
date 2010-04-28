using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Member;
using NoName.NetShop.ForeFlat.Member;

namespace NoName.NetShop.ForeFlat.member
{

    
    public partial class MyProfile : AuthBasePage
    {
        protected void Page_Init()
        {
            LoadUc(CurrentUser.UserType);
        } 
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowUserInfo();
            }
        }

        private void ShowUserInfo()
        {
            MemberInfo model = MemberInfo.GetFullInfo(CurrentUser.UserId);

            this.lbluserId.Text = model.UserId.ToString();
            this.lblUserEmail.Text = model.UserEmail;
            this.txtUserName.Text = model.UserName;
            this.lblCurScore.Text = model.CurScore.ToString();
            this.lblRegTime.Text = model.RegisterTime.ToString("yyyy-MM-dd HH:mm");
            switch (model.Status)
            {
                case MemberStatus.Initiation:
                    lblStatus.Text = "初始注册";
                    break;
                case MemberStatus.Deleted:
                    lblStatus.Text = "已删除";
                    break;
                case MemberStatus.Formal:
                    lblStatus.Text = "正式";
                    break;
                case MemberStatus.Locked:
                    lblStatus.Text = "锁定";
                    break;
            }

            IShowExtentInfo con = phExtentInfo.FindControl("uccon") as IShowExtentInfo;
            if (con != null)
            {
                con.ShowInfo(model);
            } 
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            MemberInfo model = MemberInfo.GetFullInfo(CurrentUser.UserId, CurrentUser.UserType);
            model.UserName = this.txtUserName.Text.Trim();

            IShowExtentInfo con = phExtentInfo.FindControl("uccon") as IShowExtentInfo;
            if (con != null )
            {
                con.GetInputInfo(model);
            }
            model.Save();
            ShowUserInfo();
        }

        private void LoadUc(MemberType usertype)
        {
            Control con = null;

           //0 未设定 1 个人会员 2 家庭会员 3 学校会员 4 企业会员 ：
            switch (usertype)
            {
                case MemberType.Initiation:
                    lblUserType.Text = "初始注册会员";
                    break;
                case MemberType.Company:
                    lblUserType.Text = "企业会员";
                    con = (Control)Page.LoadControl("~/uc/UCCompanyMemberInfo.ascx");
                    break;
                case MemberType.Famly:
                    lblUserType.Text = "家庭会员";
                    con = (Control)Page.LoadControl("~/uc/UCFamlyMemberInfo.ascx");
                    break;
                case MemberType.Personal:
                    lblUserType.Text = "个人会员";
                    con = (Control)Page.LoadControl("~/uc/UCPersonMemberInfo.ascx");
                    break;
                case MemberType.School:
                    lblUserType.Text = "学校会员";
                    con = (Control)Page.LoadControl("~/uc/UCSchoolMemberInfo.ascx");
                    break;
            }
            con.ID = "uccon";
            phExtentInfo.Controls.Add(con);
        }

    }
}
