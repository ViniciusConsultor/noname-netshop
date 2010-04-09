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

namespace NoName.NetShop.ForeFlat.member.PawnShop
{
    public partial class Edit : AuthBasePage
    {
        public int PawnProductID
        {
            get { if (ViewState["PawnProductID"] != null) return Convert.ToInt32(ViewState["PawnProductID"]); else return -1; }
            set { ViewState["PawnProductID"] = value; }
        }
        private int CategoryID
        {
            get { if (ViewState["CategoryID"] != null) return Convert.ToInt32(ViewState["CategoryID"]); else return -1; }
            set { ViewState["CategoryID"] = value; }
        }
        private PawnProductBll bll = new PawnProductBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (CurrentUser == null)
                {
                    Response.Redirect("/login.aspx");
                    return;
                }
                if (!String.IsNullOrEmpty(Request.QueryString["productid"])) PawnProductID = Convert.ToInt32(Request.QueryString["productid"]);
                BindData();
            }
        }

        private void BindData()
        {
            PawnProductModel model = bll.GetModel(PawnProductID);
            MagicCategoryBll cateBll = new MagicCategoryBll();

            CategoryID = model.CateID;
            if (!String.IsNullOrEmpty(Request.QueryString["categoryid"])) CategoryID = Convert.ToInt32(Request.QueryString["categoryid"]);

            TextBox_Category.Text = new MagicCategoryBll().GetModel(CategoryID).CategoryName;
            TextBox_ProductName.Text = model.PawnProductName;
            TextBox_EndTime.Text = model.DeadTime.ToString("yyyy-MM-dd");
            TextBox_Price.Text = model.PawnPrice.ToString("0.00");
            TextBox_Brief.Text = model.Brief;
            TextBox_TrueName.Text = model.TrueName;
            TextBox_Phone.Text = model.Phone;
            TextBox_CellPhone.Text = model.CellPhone;
            TextBox_PostCode.Text = model.PostCode;
            TextBox_Address.Text = model.Address;
            ucRegion.PresetRegionInfo(RegionInfo.GetRegionPathByName(model.Region.Split(' ')[model.Region.Split(' ').Length-1]));
        }

        protected void Button_Edit_Click(object sender, EventArgs e)
        {
            string ErrorMessage = String.Empty;

            if (String.IsNullOrEmpty(TextBox_ProductName.Text)) { ErrorMessage += "产品名称不能为空\\n"; }
            if (String.IsNullOrEmpty(TextBox_EndTime.Text/* validate */)) { ErrorMessage += "结束时间不能为空\\n"; }
            if (String.IsNullOrEmpty(TextBox_Price.Text) || !PageValidate.IsDecimal(TextBox_Price.Text)) { ErrorMessage += "典当价格不正确\\n"; }
            if (String.IsNullOrEmpty(TextBox_Brief.Text)) { ErrorMessage += "简要介绍不能为空\\n"; }
            if (String.IsNullOrEmpty(TextBox_TrueName.Text)) { ErrorMessage += "姓名不能为空\\n"; }
            if (String.IsNullOrEmpty(TextBox_Phone.Text) && String.IsNullOrEmpty(TextBox_CellPhone.Text)) { ErrorMessage += "请输入您的电话号码或者手机号码\\n"; }
            else { /* validate */}
            if (String.IsNullOrEmpty(TextBox_PostCode.Text) || !PageValidate.IsNumber(TextBox_PostCode.Text)) { ErrorMessage += "邮政编码不能为空\\n"; }
            if (String.IsNullOrEmpty(TextBox_Address.Text)) { ErrorMessage += "地址不能为空\\n"; }
            RegionInfo regionInfo = ucRegion.GetSelectedRegionInfo();
            if (String.IsNullOrEmpty(regionInfo.Province) || String.IsNullOrEmpty(regionInfo.City))
            {
                ErrorMessage += "所在地选择不完整\\n";
            }

            if (!String.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(this, ErrorMessage);
                return;
            }

            PawnProductModel model = bll.GetModel(PawnProductID);

            if (FileUpload_ProductImage.FileName != "")
            {
                string[] ProductImages;
                if (MagicWorldImageRule.SaveProductMainImage(PawnProductID, FileUpload_ProductImage.PostedFile, out ProductImages))
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

            model.PawnProductName = TextBox_ProductName.Text;
            model.CateID = CategoryID;
            model.CatePath = cate.CategoryPath;
            model.PawnPrice = Convert.ToDecimal(TextBox_Price.Text);
            model.Brief = TextBox_Brief.Text;
            model.DeadTime = Convert.ToDateTime(TextBox_EndTime.Text);
            model.ChangeTime = DateTime.Now;
            model.TrueName = TextBox_TrueName.Text;
            model.CellPhone = TextBox_CellPhone.Text;
            model.Phone = TextBox_Phone.Text;
            model.PostCode = TextBox_PostCode.Text;
            model.Region = String.Format("{0} {1} {2}", regionInfo.Province, regionInfo.City, regionInfo.County);
            model.Address = TextBox_Address.Text;

            bll.Update(model);
            Response.Redirect("../SubmitSucc.aspx");
        }
    }
}
