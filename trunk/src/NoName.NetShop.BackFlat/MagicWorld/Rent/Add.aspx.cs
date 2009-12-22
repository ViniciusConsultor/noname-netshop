using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.MagicWorld.Model;
using NoName.NetShop.MagicWorld.BLL;
using NoName.Utility;
using NoName.NetShop.Common;
using NoName.NetShop.MagicWorld.Facade;

namespace NoName.NetShop.BackFlat.MagicWorld.Rent
{
    public partial class Add : System.Web.UI.Page
    {
        private int CategoryID
        {
            get { if (ViewState["CategoryID"] != null) return Convert.ToInt32(ViewState["CategoryID"]); else return -1; }
            set { ViewState["CategoryID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["CategoryID"])) CategoryID = Convert.ToInt32(Request.QueryString["CategoryID"]);
                BindData();
            }
        }

        private void BindData()
        {
            MagicCategoryModel Cate = new MagicCategoryBll().GetModel(CategoryID);

            Label_Category.Text = Cate.CategoryName;
            Hidden_CategoryPath.Value = Cate.CategoryPath;
        }


        protected void Button_Add_Click(object sender, EventArgs e)
        {
            string ErrorMessage = String.Empty;
            if(String.IsNullOrEmpty(TextBox_RentName.Text)) ErrorMessage+="商品名称不能为空\n";
            if (String.IsNullOrEmpty(TextBox_Stock.Text) || !PageValidate.IsNumber(TextBox_Stock.Text)) ErrorMessage += "商品数量不正确\n";
            if (String.IsNullOrEmpty(TextBox_Keywords.Text)) ErrorMessage += "关键词不能为空\n";
            if (String.IsNullOrEmpty(TextBox_RentPrice.Text) || !PageValidate.IsDecimal(TextBox_RentPrice.Text)) ErrorMessage += "出租价格不正确\n";
            if (String.IsNullOrEmpty(TextBox_CashPledge.Text) || !PageValidate.IsDecimal(TextBox_CashPledge.Text)) ErrorMessage += "出租押金不正确\n";            
            if (String.IsNullOrEmpty(TextBox_MaxRentDays.Text) || !PageValidate.IsNumber(TextBox_MaxRentDays.Text)) ErrorMessage += "最大出租时间不正确\n";
            if (String.IsNullOrEmpty(TextBox_Brief.Text)) ErrorMessage += "商品简介不能为空\n";
            if (String.IsNullOrEmpty(FileUpload_MainImage.FileName)) ErrorMessage += "商品图片不能为空\n";

            if(!String.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(this,ErrorMessage);
                return;
            }

            int RentID = CommDataHelper.GetNewSerialNum(AppType.MagicWorld);

            string[] ProductImages;
            if (MagicWorldImageRule.SaveProductMainImage(RentID, FileUpload_MainImage.PostedFile, out ProductImages))
            {
                RentProductModel model = new RentProductModel();

                model.RentID = RentID;
                model.RentName = TextBox_RentName.Text;
                model.Stock = Convert.ToInt32(TextBox_Stock.Text);
                model.Keywords = TextBox_Keywords.Text.Replace("，",",");
                model.CashPledge = Convert.ToDecimal(TextBox_CashPledge.Text);
                model.RentPrice = Convert.ToDecimal(TextBox_RentPrice.Text);
                model.MaxRentTime = Convert.ToInt32(TextBox_MaxRentDays.Text);
                model.Brief = TextBox_Brief.Text;
                model.SmallImage = ProductImages[0];
                model.MediumImage = ProductImages[1];

                model.CategoryID = CategoryID;
                model.CategoryPath = Hidden_CategoryPath.Value;
                model.CreateTime = DateTime.Now;
                model.UpdateTime = DateTime.Now;
                model.Status = 0;

                new RentProductBll().Add(model);

                MessageBox.Show(this, "添加成功！");
            }
            else
            {
                MessageBox.Show(this, "图片上传失败！");
            } 
        }


    }
}
