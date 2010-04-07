using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.Utility;
using NoName.NetShop.Common;
using NoName.NetShop.MagicWorld.BLL;
using NoName.NetShop.MagicWorld.Model;
using NoName.NetShop.MagicWorld.Facade;
using NoName.NetShop.Member;

namespace NoName.NetShop.ForeFlat.member.Auction
{
    public partial class Add : AuthBasePage
    {
        private int CategoryID
        {
            get { if (ViewState["CategoryID"] != null) return Convert.ToInt32(ViewState["CategoryID"]); else return -1; }
            set { ViewState["CategoryID"] = value; }
        }
        private AuctionProductBll bll = new AuctionProductBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (CurrentUser == null)
                {
                    Response.Redirect("/login.aspx");
                    return;
                }
                if (!String.IsNullOrEmpty(Request.QueryString["categoryid"])) CategoryID = Convert.ToInt32(Request.QueryString["categoryid"]);
                BindData();
            }
        }

        protected void BindData()
        {
            if (CategoryID != -1)
            {
                MagicCategoryBll CategoryBll = new MagicCategoryBll();
                MagicCategoryModel Category = CategoryBll.GetModel(CategoryID);

                TextBox_Category.Text = Category.CategoryName;
            }
            else
            {
                throw new Exception("未选择分类");
            }
        }

        protected void Button_Add_Click(object sender, EventArgs e)
        {
            string ErrorMessage = String.Empty;

            if (String.IsNullOrEmpty(TextBox_ProductName.Text)) { ErrorMessage += "产品名称不能为空\\n"; }
            if (String.IsNullOrEmpty(FileUpload_ProductImage.FileName)) { ErrorMessage += "产品图片不能为空\\n"; }
            if (String.IsNullOrEmpty(TextBox_StartPrice.Text) || !PageValidate.IsDecimal(TextBox_StartPrice.Text)) { ErrorMessage += "起始价格不正确\\n"; }
            if (String.IsNullOrEmpty(TextBox_AddPrices.Text)) { ErrorMessage += "每次加价不能为空\\n"; }
            if (String.IsNullOrEmpty(TextBox_StartTime.Text)/* validate */) { ErrorMessage += "开始时间不能为空\\n"; }
            if (String.IsNullOrEmpty(TextBox_EndTime.Text)/* validate */) { ErrorMessage += "结束时间不能为空\\n"; }
            if (String.IsNullOrEmpty(TextBox_Brief.Text)) { ErrorMessage += "简要介绍不能为空\\n"; }
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

            int AuctionID = CommDataHelper.GetNewSerialNum(AppType.MagicWorld);

            string[] ProductImages;
            if (MagicWorldImageRule.SaveProductMainImage(AuctionID, FileUpload_ProductImage.PostedFile, out ProductImages))
            {
                AuctionProductModel model = new AuctionProductModel();
                MagicCategoryModel cate = new MagicCategoryBll().GetModel(CategoryID);

                model.AuctionID = AuctionID;
                model.ProductName = TextBox_ProductName.Text;
                model.CategoryID = CategoryID;
                model.CategoryPath = cate.CategoryPath;
                model.SmallImage = ProductImages[0];
                model.MediumImage = ProductImages[1];
                model.StartPrice = Convert.ToDecimal(TextBox_StartPrice.Text);
                model.CurPrice = model.StartPrice;
                model.AddPrices = TextBox_AddPrices.Text.Replace('，',',');
                model.StartTime = Convert.ToDateTime(TextBox_StartTime.Text);
                model.EndTime = Convert.ToDateTime(TextBox_EndTime.Text);
                model.Brief = TextBox_Brief.Text;
                model.InsertTime = DateTime.Now;
                model.UpdateTime = DateTime.Now;

                model.UserID = GetUserID();
                model.TrueName = TextBox_TrueName.Text;
                model.Phone = TextBox_Phone.Text;
                model.CellPhone = TextBox_CellPhone.Text;
                model.PostCode = TextBox_PostCode.Text;
                model.Region = String.Format("{0} {1} {2}", regionInfo.Province, regionInfo.City, regionInfo.County);
                model.Address = TextBox_Address.Text;

                model.Status = (int)AuctionProductStatus.尚未审核;
                model.OutLinkUrl = "";

                bll.Add(model);
                Response.Redirect("../SubmitSucc.aspx");
            }
            else
            {
                MessageBox.Show(this, "图片上传失败");
            }
        }

        private string GetUserID()
        {
            return CurrentUser.UserId;
        }
    }
}

