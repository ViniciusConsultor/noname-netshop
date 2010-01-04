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

namespace NoName.NetShop.ForeFlat.Magic
{
    public partial class RentApply : Page
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
                Literal_Message.Text = "对不起，您已经申请过了，请返回用户中心查看。";
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
            RentLogModel log = new RentLogModel();
            RentProductModel product = new RentProductBll().GetModel(RentID);

            log.RentLogID = CommDataHelper.GetNewSerialNum(AppType.MagicWorld);
            log.ApplyInfo = TextBox_RentInfo.Text;
            log.ApplyTime = DateTime.Now;
            log.RentMonths = Convert.ToInt32(DropDown_RentTime.SelectedValue);
            log.PaySum = product.RentPrice*log.RentMonths;
            log.RentID = RentID;
            log.Status = (int)RentLogStatus.等待确认;
            log.UserID = GetUserID();

            log.StartTime = DateTime.Now;
            log.EndTime = log.StartTime;

            bll.Add(log);

        }

        private string GetUserID()
        {
            //return CurrentUser.UserId;
            return "zhangfeng";
        }
    }
}
