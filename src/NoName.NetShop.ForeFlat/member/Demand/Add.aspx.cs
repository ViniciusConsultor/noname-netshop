using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.MagicWorld.BLL;
using NoName.NetShop.MagicWorld.Model;
using NoName.NetShop.Member;
using NoName.Utility;
using NoName.NetShop.Common;
using NoName.NetShop.MagicWorld.Facade;

namespace NoName.NetShop.ForeFlat.member.Demand
{
    public partial class Add : AuthBasePage
    {
        private int CategoryID
        {
            get { if (ViewState["CategoryID"] != null) return Convert.ToInt32(ViewState["CategoryID"]); else return -1; }
            set { ViewState["CategoryID"] = value; }
        }
        private DemandProductBll bll = new DemandProductBll();

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

        private void BindData()
        {
            if (CategoryID != -1)
            {
                MagicCategoryBll CategoryBll = new MagicCategoryBll();
                MagicCategoryModel Category = CategoryBll.GetModel(CategoryID);

                TextBox_Category.Text = Category.CategoryName;

                DropDown_Usage.DataSource = DataTableUtil.GetEnumKeyValue(typeof(SecondhandProductUsageCondition));
                DropDown_Usage.DataTextField="key";
                DropDown_Usage.DataValueField="value";
                DropDown_Usage.DataBind();
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
            if (String.IsNullOrEmpty(TextBox_Price.Text) || !PageValidate.IsDecimal(TextBox_Price.Text)) { ErrorMessage += "请输入正确的产品价格\\n"; }
            if (String.IsNullOrEmpty(TextBox_Count.Text) || !PageValidate.IsNumber(TextBox_Count.Text)) { ErrorMessage += "请输入正确的产品数量\\n"; }
            if (String.IsNullOrEmpty(TextBox_ExpireTime.Text) || !PageValidate.IsDate(TextBox_ExpireTime.Text)) { ErrorMessage += "请输入正确的有效时间\\n"; }
            if (String.IsNullOrEmpty(TextBox_Brief.Text)) { ErrorMessage += "请输入产品简介\\n"; }
            if (String.IsNullOrEmpty(TextBox_TrueName.Text)) { ErrorMessage += "请输入您的姓名\\n"; }
            if (String.IsNullOrEmpty(TextBox_Phone.Text) && String.IsNullOrEmpty(TextBox_CellPhone.Text)) { ErrorMessage += "请输入您的电话号码或者手机号码\\n"; }
            else{/* validate */}
            if (String.IsNullOrEmpty(TextBox_PostCode.Text)/* validate */) { ErrorMessage += "请输入正确的邮政编码\\n"; }
            if (String.IsNullOrEmpty(TextBox_Address.Text)) { ErrorMessage += "请输入您的地址\\n"; }

            RegionInfo regionInfo = ucRegion.GetSelectedRegionInfo();
            if (String.IsNullOrEmpty(regionInfo.Province) || String.IsNullOrEmpty(regionInfo.City) || String.IsNullOrEmpty(regionInfo.County))
            {
                ErrorMessage += "所在地选择不完整\\n";
            }

            if (!String.IsNullOrEmpty(ErrorMessage)) {
                MessageBox.Show(this,ErrorMessage);
                return;
            }

            DemandProductModel model = new DemandProductModel();
            MagicCategoryModel cate = new MagicCategoryBll().GetModel(CategoryID);
            int DemandID = CommDataHelper.GetNewSerialNum(AppType.MagicWorld);
            string[] ProductImages;
            if (MagicWorldImageRule.SaveProductMainImage(DemandID, FileUpload_ProductImage.PostedFile, out ProductImages))
            {
                model.DemandID = DemandID;
                model.DemandName = TextBox_ProductName.Text;
                model.Address = TextBox_Address.Text;
                model.Brief = TextBox_Brief.Text ;
                model.CategoryID = CategoryID;
                model.CategoryPath = cate.CategoryPath;
                model.CellPhone = TextBox_CellPhone.Text;
                model.Count = Convert.ToInt32(TextBox_Count.Text);
                model.ExpirationTime = Convert.ToDateTime(TextBox_ExpireTime.Text);
                model.InsertTime = DateTime.Now;
                model.SmallImage = ProductImages[0];
                model.MediumImage = ProductImages[1];
                model.Phone = TextBox_Phone.Text;
                model.PostCode = TextBox_PostCode.Text;
                model.Price = Convert.ToDecimal(TextBox_Price.Text);
                model.Region = String.Format("{0} {1} {2}", regionInfo.Province, regionInfo.City, regionInfo.County);
                model.Status = (int)DemandProductStatus.尚未审核;
                model.TrueName = TextBox_TrueName.Text;
                model.UpdateTime = DateTime.Now;
                model.UsageCondition = Convert.ToInt32(DropDown_Usage.SelectedValue);
                model.UserID = GetUserID();

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
