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

namespace NoName.NetShop.ForeFlat.member.Secondhand
{
    public partial class Edit : System.Web.UI.Page
    {
        public int SecondhandProductID
        {
            get { if (ViewState["SecondhandProductID"] != null) return Convert.ToInt32(ViewState["SecondhandProductID"]); else return -1; }
            set { ViewState["SecondhandProductID"] = value; }
        }
        private int CategoryID
        {
            get { if (ViewState["CategoryID"] != null) return Convert.ToInt32(ViewState["CategoryID"]); else return -1; }
            set { ViewState["CategoryID"] = value; }
        }
        private SecondhandProductBll bll = new SecondhandProductBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["productid"])) SecondhandProductID = Convert.ToInt32(Request.QueryString["productid"]);
                BindData();
            }
        }

        private void BindData()
        {
            SecondhandProductModel model = bll.GetModel(SecondhandProductID);

            CategoryID = model.CateID;
            if (!String.IsNullOrEmpty(Request.QueryString["categoryid"])) CategoryID = Convert.ToInt32(Request.QueryString["categoryid"]);

            TextBox_Category.Text = new MagicCategoryBll().GetModel(CategoryID).CategoryName;
            TextBox_ProductName.Text = model.SecondhandProductName;
            TextBox_Price.Text = model.Price.ToString("0.00");
            TextBox_Count.Text = model.Stock.ToString();
            DropDown_Usage.SelectedValue = model.UsageCondition.ToString();
            TextBox_Brief.Text = model.Brief;
            TextBox_TrueName.Text = model.TrueName;
            TextBox_Phone.Text = model.Phone;
            TextBox_CellPhone.Text = model.CellPhone;
            TextBox_PostCode.Text = model.PostCode;
            TextBox_Address.Text = model.Address;
            ucRegion.PresetRegionInfo(RegionInfo.GetRegionPathByName(model.Region.Split(' ')[model.Region.Split(' ').Length]));
        }


        protected void Button_Edit_Click(object sender, EventArgs e)
        {
            string ErrorMessage = String.Empty;
            if (String.IsNullOrEmpty(TextBox_ProductName.Text)) { ErrorMessage += "产品名称不能为空\n"; }
            if (String.IsNullOrEmpty(FileUpload_ProductImage.FileName)) { ErrorMessage += "产品图片不能为空\n"; }
            if (String.IsNullOrEmpty(TextBox_Price.Text) || !PageValidate.IsDecimal(TextBox_Price.Text)) { ErrorMessage += "请输入正确的产品价格\n"; }
            if (String.IsNullOrEmpty(TextBox_Count.Text) || !PageValidate.IsNumber(TextBox_Count.Text)) { ErrorMessage += "请输入正确的产品数量\n"; }
            if (String.IsNullOrEmpty(TextBox_Brief.Text)) { ErrorMessage += "请输入产品简介\n"; }
            if (String.IsNullOrEmpty(TextBox_TrueName.Text)) { ErrorMessage += "请输入您的姓名\n"; }
            if (String.IsNullOrEmpty(TextBox_Phone.Text) && String.IsNullOrEmpty(TextBox_CellPhone.Text)) { ErrorMessage += "请输入您的电话号码或者手机号码\n"; }
            else { /* validate */}
            if (String.IsNullOrEmpty(TextBox_PostCode.Text)/* validate */) { ErrorMessage += "请输入正确的邮政编码\n"; }
            if (String.IsNullOrEmpty(TextBox_Address.Text)) { ErrorMessage += "请输入您的地址\n"; }

            RegionInfo regionInfo = ucRegion.GetSelectedRegionInfo();
            if (String.IsNullOrEmpty(regionInfo.Province) || String.IsNullOrEmpty(regionInfo.City) || String.IsNullOrEmpty(regionInfo.County))
            {
                ErrorMessage += "所在地选择不完整\n";
            }

            if (!String.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(this, ErrorMessage);
                return;
            }

            SecondhandProductModel model = bll.GetModel(SecondhandProductID);
            MagicCategoryModel cate = new MagicCategoryBll().GetModel(CategoryID);

            if (FileUpload_ProductImage.FileName != "")
            {
                string[] ProductImages;

                if (MagicWorldImageRule.SaveProductMainImage(SecondhandProductID, FileUpload_ProductImage.PostedFile, out ProductImages))
                {
                    model.SmallImage = ProductImages[0];
                    model.MediumImage = ProductImages[1];
                    //model.LargeImage = ProductImages[2];
                }
                else
                {
                    MessageBox.Show(this, "图片上传失败");
                    return;
                }
            }

            model.SecondhandProductName = TextBox_ProductName.Text;
            model.CateID = CategoryID;
            model.CatePath = cate.CategoryPath;
            model.Price = Convert.ToDecimal(TextBox_Price.Text);
            model.UsageCondition = Convert.ToInt32(DropDown_Usage.SelectedValue);
            model.Stock = Convert.ToInt32(TextBox_Count.Text);
            model.Brief = TextBox_Brief.Text;

            model.UpdateTime = DateTime.Now;

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
