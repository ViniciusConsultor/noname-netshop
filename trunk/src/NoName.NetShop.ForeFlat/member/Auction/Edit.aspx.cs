using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.Utility;
using NoName.NetShop.MagicWorld.BLL;
using NoName.NetShop.MagicWorld.Model;
using NoName.NetShop.MagicWorld.Facade;
using NoName.NetShop.Member;

namespace NoName.NetShop.ForeFlat.member.Auction
{
    public partial class Edit : AuthBasePage
    {
        public int AuctionID
        {
            get { if (ViewState["AuctionID"] != null) return Convert.ToInt32(ViewState["AuctionID"]); else return -1; }
            set { ViewState["AuctionID"] = value; }
        }
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
                if (!String.IsNullOrEmpty(Request.QueryString["productid"])) AuctionID = Convert.ToInt32(Request.QueryString["productid"]);
                BindData();
            }
        }

        private void BindData()
        {
            AuctionProductModel model = bll.GetModel(AuctionID);
            MagicCategoryBll cateBll = new MagicCategoryBll();

            if (model.Status != (int)AuctionProductStatus.尚未审核)
            {
                MessageBox.Show(this, "该商品已被审核，禁止编辑！");
                Response.Redirect("List.aspx");
                return;
            }

            CategoryID = model.CategoryID;
            if (!String.IsNullOrEmpty(Request.QueryString["categoryid"])) CategoryID = Convert.ToInt32(Request.QueryString["categoryid"]);

            TextBox_Category.Text = new MagicCategoryBll().GetModel(CategoryID).CategoryName;
            TextBox_ProductName.Text = model.ProductName;
            TextBox_StartPrice.Text=model.StartPrice.ToString("0.00");
            TextBox_AddPrices.Text = model.AddPrices;
            TextBox_StartTime.Text = model.StartTime.ToString("yyyy-MM-dd");
            TextBox_EndTime.Text = model.EndTime.ToString("yyyy-MM-dd");
            TextBox_Brief.Text = model.Brief;
            TextBox_TrueName.Text = model.TrueName;
            TextBox_Phone.Text = model.Phone;
            TextBox_CellPhone.Text = model.CellPhone;
            TextBox_PostCode.Text = model.PostCode;
            TextBox_Address.Text = model.Address;

            string[] LastRegion = model.Region.Split(' ');
            ucRegion.PresetRegionInfo(RegionInfo.GetRegionPathByName(LastRegion[String.IsNullOrEmpty(LastRegion[2]) ? 1 : 2]));
        }


        protected void Button_Edit_Click(object sender, EventArgs e)
        {
            string ErrorMessage = String.Empty;

            if (String.IsNullOrEmpty(TextBox_ProductName.Text)) { ErrorMessage += "产品名称不能为空\\n"; }
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

            AuctionProductModel model = bll.GetModel(AuctionID);

            if (FileUpload_ProductImage.FileName != String.Empty)
            {
                string[] ProductImages;

                if (MagicWorldImageRule.SaveProductMainImage(model.AuctionID, FileUpload_ProductImage.PostedFile, out ProductImages))
                {
                    model.SmallImage = ProductImages[0];
                    model.MediumImage = ProductImages[1];
                }
                else
                {
                    MessageBox.Show(this, "图片上传失败");
                    return;
                }
            }

            MagicCategoryModel cate = new MagicCategoryBll().GetModel(CategoryID);

            model.ProductName = TextBox_ProductName.Text;
            model.CategoryID = CategoryID;
            model.CategoryPath = cate.CategoryPath;
            model.StartPrice = Convert.ToDecimal(TextBox_StartPrice.Text);
            model.AddPrices = TextBox_AddPrices.Text.Replace('，', ',');
            model.StartTime = Convert.ToDateTime(TextBox_StartTime.Text);
            model.EndTime = Convert.ToDateTime(TextBox_EndTime.Text);
            model.Brief = TextBox_Brief.Text;
            model.UpdateTime = DateTime.Now;

            model.TrueName = TextBox_TrueName.Text;
            model.Phone = TextBox_Phone.Text;
            model.CellPhone = TextBox_CellPhone.Text;
            model.PostCode = TextBox_PostCode.Text;
            model.Region = String.Format("{0} {1} {2}", regionInfo.Province, regionInfo.City, regionInfo.County);
            model.Address = TextBox_Address.Text;

            bll.Update(model);
            Response.Redirect("../SubmitSucc.aspx");
        }
    }
}
