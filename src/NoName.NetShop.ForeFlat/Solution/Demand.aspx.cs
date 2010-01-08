using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Member;
using NoName.Utility;
using NoName.NetShop.Solution.Model;
using NoName.NetShop.Common;
using NoName.NetShop.Solution.BLL;

namespace NoName.NetShop.ForeFlat.Solution
{
    public partial class Demand : System.Web.UI.Page
    {
        private SolutionDemandBll bll = new SolutionDemandBll();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Add_Click(object sender, EventArgs e)
        {
            string ErrorMessage = String.Empty;
            if (String.IsNullOrEmpty(TextBox_DemandDetail.Text)) { ErrorMessage += "请填写需求信息\n"; }
            if (String.IsNullOrEmpty(FileUpload_FieldImage.FileName)) { ErrorMessage += "场地图片不能为空\n"; }
            if (String.IsNullOrEmpty(TextBox_Field.Text)) { ErrorMessage += "请填写场地信息\n"; }
            if (String.IsNullOrEmpty(TextBox_Effect.Text)) { ErrorMessage += "请填写效果要求\n"; }
            if (String.IsNullOrEmpty(TextBox_Budget.Text)) { ErrorMessage += "请填写正确的预算金额\n"; }
            if (String.IsNullOrEmpty(TextBox_Contactor.Text)) { ErrorMessage += "请填写联系人姓名\n"; }
            if (String.IsNullOrEmpty(TextBox_Phone.Text)) { ErrorMessage += "请填写联系人电话\n"; }
            if (String.IsNullOrEmpty(TextBox_PostCode.Text)) { ErrorMessage += "请填写邮政编码\n"; }
            if (String.IsNullOrEmpty(TextBox_Address.Text)) { ErrorMessage += "请填写通信地址\n"; }

            RegionInfo regionInfo = ucRegion.GetSelectedRegionInfo();
            if (String.IsNullOrEmpty(regionInfo.Province) || String.IsNullOrEmpty(regionInfo.City) || String.IsNullOrEmpty(regionInfo.County))
            {
                ErrorMessage += "所在地选择不完整\n";
            }
            
            if (!String.IsNullOrEmpty(ErrorMessage)) {
                MessageBox.Show(this,ErrorMessage);
                return;
            }

            SolutionDemandModel model = new SolutionDemandModel();
            int DemandID = CommDataHelper.GetNewSerialNum(AppType.Solution);
            string ImageUrl,ImageShorUrl,UploadMessage;
            if (CommonImageUpload.Upload(FileUpload_FieldImage, out ImageUrl, out ImageShorUrl, out UploadMessage))
            {
                model.DemandID = DemandID;
                model.DemandDetail = TextBox_DemandDetail.Text;
                model.FieldPhotoes = ImageUrl ;
                model.FieldSituation = TextBox_Field.Text;
                model.EffectSituation = TextBox_Effect.Text;
                model.Budget = Convert.ToDecimal(TextBox_Budget.Text);
                model.Contactor = TextBox_Contactor.Text;
                model.ContactPhone = TextBox_Phone.Text;
                model.Postcode = TextBox_PostCode.Text;
                model.Region = String.Format("{0} {1} {2}", regionInfo.Province, regionInfo.City, regionInfo.County);
                model.Address = TextBox_Address.Text;

                model.UserID = GetUserID();

                model.CreateTime = DateTime.Now;
                model.UpdateTime = DateTime.Now;
                model.Status = (int)SolutionDemandStatus.尚未处理;

                bll.Add(model);


                Response.Redirect("SubmitSucc.aspx?o="+DemandID);
            }
            else
            {
                MessageBox.Show(this,"图片上传失败");
            }



        }

        private string GetUserID() 
        {
            return "zhangfeng";
        }
    }
}
