using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.MagicWorld.BLL;
using NoName.NetShop.MagicWorld.Model;
using NoName.Utility;
using NoName.NetShop.Common;
using NoName.NetShop.Member;

namespace NoName.NetShop.ForeFlat.Magic
{
    public partial class RentApply : AuthBasePage
    {
        private int RentID
        {
            get { if (ViewState["RentID"] != null) return Convert.ToInt32(ViewState["RentID"]); else return -1; }
            set { ViewState["RentID"] = value; }
        }
        private RentLogBll bll = new RentLogBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (CurrentUser == null)
                {
                    Response.Redirect("/login.aspx");
                    return;
                }
                if (!String.IsNullOrEmpty(Request.QueryString["rentid"])) RentID = Convert.ToInt32(Request.QueryString["rentid"]);
                BindData();
            }
        }

        private void BindData()
        {
            RentLogModel log = bll.GetModel(RentID, GetUserID());
            RentProductModel product = new RentProductBll().GetModel(RentID);

            for (int i = 1; i <= product.MaxRentTime; i++)
            {
                ListItem item = new ListItem();
                item.Text = i.ToString();
                item.Value = i.ToString();
                DropDown_RentTime.Items.Add(item);
            }

            if (log != null)
            {
                Div_ApplyContent.InnerHtml = "对不起，您已经申请过了，请返回用户中心查看。";
                Button_Add.Enabled = false;
            }
        }

        protected void Button_Add_Click(object sender, EventArgs e)
        {
            Rent();
            MessageBox.Show(this, "申请已提交，请到用户中心查看"); 
        }

        private void Rent()
        {
            string ErrorMessage = String.Empty;

            if (String.IsNullOrEmpty(TextBox_TrueName.Text)) { ErrorMessage += "姓名不能为空\\n"; }
            if (String.IsNullOrEmpty(TextBox_Phone.Text) && String.IsNullOrEmpty(TextBox_CellPhone.Text)) { ErrorMessage += "请输入您的电话号码或者手机号码\\n"; }
            else { /* validate */}
            if (String.IsNullOrEmpty(TextBox_PostCode.Text) || !PageValidate.IsNumber(TextBox_PostCode.Text)) { ErrorMessage += "邮政编码不能为空\\n"; }
            if (String.IsNullOrEmpty(TextBox_Address.Text)) { ErrorMessage += "地址不能为空\\n"; }
            RegionInfo regionInfo = ucRegion.GetSelectedRegionInfo();
            if (String.IsNullOrEmpty(regionInfo.Province) || String.IsNullOrEmpty(regionInfo.City) || String.IsNullOrEmpty(regionInfo.County))
            {
                ErrorMessage += "所在地选择不完整\\n";
            }

            if (!String.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(this, ErrorMessage);
                return;
            }

            RentLogModel log = new RentLogModel();
            RentProductModel product = new RentProductBll().GetModel(RentID);

            log.RentLogID = CommDataHelper.GetNewSerialNum(AppType.MagicWorld);
            log.ApplyInfo = String.Empty; //TextBox_RentInfo.Text;
            log.ApplyTime = DateTime.Now;
            log.RentMonths = Convert.ToInt32(DropDown_RentTime.SelectedValue);
            log.PaySum = product.RentPrice*log.RentMonths;
            log.RentID = RentID;
            log.Status = (int)RentLogStatus.等待确认;
            log.UserID = GetUserID();
            log.Truename = TextBox_TrueName.Text;
            log.Phone = TextBox_Phone.Text;
            log.Cellphone = TextBox_CellPhone.Text;
            log.Postcode = TextBox_PostCode.Text;
            log.Region = String.Format("{0} {1} {2}", regionInfo.Province, regionInfo.City, regionInfo.County); ;
            log.Address = TextBox_Address.Text;

            log.StartTime = DateTime.Now;
            log.EndTime = log.StartTime;

            bll.Add(log);
        }

        private string GetUserID()
        {
            return CurrentUser.UserId;
        }
    }
}
