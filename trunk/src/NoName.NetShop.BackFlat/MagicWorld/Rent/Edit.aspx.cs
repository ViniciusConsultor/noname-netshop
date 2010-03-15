using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.MagicWorld.BLL;
using NoName.NetShop.MagicWorld.Model;
using NoName.Utility;
using NoName.NetShop.MagicWorld.Facade;

namespace NoName.NetShop.BackFlat.MagicWorld.Rent
{
    public partial class Edit : System.Web.UI.Page
    {
        private int CategoryID
        {
            get { if (ViewState["CategoryID"] != null) return Convert.ToInt32(ViewState["CategoryID"]); else return -1; }
            set { ViewState["CategoryID"] = value; }
        }
        public int RentID
        {
            get { if (ViewState["RentID"] != null) return Convert.ToInt32(ViewState["RentID"]); else return -1; }
            set { ViewState["RentID"] = value; }
        }
        private RentProductBll bll = new RentProductBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["productid"])) RentID = Convert.ToInt32(Request.QueryString["productid"]);
                if (!String.IsNullOrEmpty(Request.QueryString["rentid"])) RentID = Convert.ToInt32(Request.QueryString["rentid"]);
                if (!String.IsNullOrEmpty(Request.QueryString["CategoryID"])) CategoryID = Convert.ToInt32(Request.QueryString["CategoryID"]);
                BindData();
            }
        }

        private void BindData()
        {
            RentProductModel rent = bll.GetModel(RentID);
            if (CategoryID == -1) CategoryID =rent.CategoryID;
            MagicCategoryModel Cate = new MagicCategoryBll().GetModel(CategoryID);

            Label_Category.Text = Cate.CategoryName;
            Hidden_CategoryPath.Value = Cate.CategoryPath;

            TextBox_RentName.Text=rent.RentName;
            TextBox_RentPrice.Text = rent.RentPrice.ToString();
            TextBox_MaxRentDays.Text = rent.MaxRentTime.ToString();
            TextBox_Stock.Text=rent.Stock.ToString();
            TextBox_Keywords.Text=rent.Keywords;
            TextBox_Brief.Text=rent.Brief;
            Image_MainImage.ImageUrl = MagicWorldImageRule.GetMainImageUrl(rent.SmallImage);
        }

        protected void Button_Edit_Click(object sender, EventArgs e)
        {
            string ErrorMessage = String.Empty;
            if (String.IsNullOrEmpty(TextBox_RentName.Text)) ErrorMessage += "商品名称不能为空\\n";
            if (String.IsNullOrEmpty(TextBox_Stock.Text) || !PageValidate.IsNumber(TextBox_Stock.Text)) ErrorMessage += "商品数量不正确\\n";
            if (String.IsNullOrEmpty(TextBox_Keywords.Text)) ErrorMessage += "关键词不能为空\\n";
            if (String.IsNullOrEmpty(TextBox_RentPrice.Text) || !PageValidate.IsDecimal(TextBox_RentPrice.Text)) ErrorMessage += "出租价格不正确\\n";
            if (String.IsNullOrEmpty(TextBox_MaxRentDays.Text) || !PageValidate.IsNumber(TextBox_MaxRentDays.Text)) ErrorMessage += "最大出租天数不正确\\n";
            if (String.IsNullOrEmpty(TextBox_Brief.Text)) ErrorMessage += "商品简介不能为空\\n";

            if (!String.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(this, ErrorMessage);
                return;
            }

            RentProductModel rent = bll.GetModel(RentID);

            if (!String.IsNullOrEmpty(FileUpload_MainImage.FileName))
            {
                string[] ProductImages;

                if (MagicWorldImageRule.SaveProductMainImage(rent.RentID, FileUpload_MainImage.PostedFile, out ProductImages))
                {
                    rent.SmallImage = ProductImages[0];
                    rent.MediumImage = ProductImages[1];
                }
                else
                {
                    MessageBox.Show(this, "图片上传失败");
                    return;
                }
            }

            rent.RentName = TextBox_RentName.Text;
            rent.RentPrice = Convert.ToDecimal(TextBox_RentPrice.Text);
            rent.MaxRentTime = Convert.ToInt32(TextBox_MaxRentDays.Text);
            rent.Stock = Convert.ToInt32(TextBox_Stock.Text);
            rent.Keywords = TextBox_Keywords.Text;
            rent.Brief = TextBox_Brief.Text;

            bll.Update(rent);

            MessageBox.Show(this,"更新成功！");
        }
    }
}
