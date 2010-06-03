using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.Utility;
using NoName.NetShop.GroupShopping.Model;
using NoName.NetShop.GroupShopping.Facade;
using NoName.NetShop.Common;
using NoName.NetShop.GroupShopping.BLL;

namespace NoName.NetShop.BackFlat.Group
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }


        private void BindData()
        {
            DropDown_ProductType.DataSource = DataTableUtil.GetEnumKeyValue(typeof(GroupShoppingProductType));
            DropDown_ProductType.DataTextField = "key";
            DropDown_ProductType.DataValueField = "value";
            DropDown_ProductType.DataBind();
        }


        protected void Button_Add_Click(object sender, EventArgs e)
        {
            string ErrorMessage = String.Empty;

            if (String.IsNullOrEmpty(TextBox_ProductName.Text.Trim())) ErrorMessage += "产品名称不能为空\\n";
            if (String.IsNullOrEmpty(TextBox_MarketPrice.Text.Trim()) || !PageValidate.IsDecimal(TextBox_MarketPrice.Text.Trim())) ErrorMessage += "市场价输入有误\\n";
            if (String.IsNullOrEmpty(TextBox_GroupPrice.Text.Trim()) || !PageValidate.IsDecimal(TextBox_GroupPrice.Text.Trim())) ErrorMessage += "团购价输入有误\\n";
            if (String.IsNullOrEmpty(TextBox_PrePaidPrice.Text.Trim()) || !PageValidate.IsDecimal(TextBox_PrePaidPrice.Text.Trim())) ErrorMessage += "预付金额输入有误\\n";
            if (String.IsNullOrEmpty(TextBox_SuccedLine.Text.Trim()) || !PageValidate.IsNumber(TextBox_SuccedLine.Text.Trim())) ErrorMessage += "成团人数输入有误";
            if (String.IsNullOrEmpty(TextBox_Brief.Text.Trim())) ErrorMessage += "产品简介不能为空\\n";
            if (String.IsNullOrEmpty(FileUpload_Image.FileName.Trim())) ErrorMessage += "产品图片不能为空\\n";

            if (!String.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(this, ErrorMessage);
                return;
            }

            int GroupProductID = CommDataHelper.GetNewSerialNum(AppType.GroupShopping);
            string[] FileNames = new string[3];

            if (GroupShoppingImageRule.SaveImage(GroupProductID, FileUpload_Image.PostedFile, out FileNames))
            {
                GroupProductModel model = new GroupProductModel();

                model.ProductID = GroupProductID;
                model.ProductName = TextBox_ProductName.Text.Trim();
                model.ProductType = Convert.ToInt32(DropDown_ProductType.SelectedValue);
                model.ProductCode = TextBox_ProductCode.Text.Trim();
                model.MarketPrice = Convert.ToDecimal(TextBox_MarketPrice.Text.Trim());
                model.GroupPrice = Convert.ToDecimal(TextBox_GroupPrice.Text.Trim());
                model.PrePaidPrice = Convert.ToDecimal(TextBox_PrePaidPrice.Text.Trim());
                model.SuccedLine = Convert.ToInt32(TextBox_SuccedLine.Text.Trim());
                model.IsRecommend = CheclBox_Recommend.Checked;

                model.Detail = TextBox_Detail.Text.Trim();
                model.Description = TextBox_Brief.Text;

                model.SmallImage = FileNames[0];
                model.MediumImage = FileNames[1];
                model.LargeImage = FileNames[2];

                model.InsertTime = DateTime.Now;
                model.ChangeTime = DateTime.Now;

                model.Status = (int)GroupShoppingProductStatus.正在团购;

                new GroupProductBll().Add(model);

                Response.Redirect("List.aspx");
            }
            else
            {
                MessageBox.Show(this, "图片上传失败，请检查后重新选择！");
                return;
            }


        }
    }
}
