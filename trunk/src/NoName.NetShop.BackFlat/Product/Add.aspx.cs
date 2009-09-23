using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.Utility;
using System.Web.UI.HtmlControls;
using NoName.NetShop.Product.Model;
using NoName.NetShop.Product.Facade;
using NoName.NetShop.Common;
using System.Data;
using NoName.NetShop.Product.BLL;

namespace NoName.NetShop.BackFlat.Product
{
    public partial class Add : System.Web.UI.Page
    {
        private ProductModelBll bll = new ProductModelBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("code");
            dt.Columns.Add("status");

            foreach (int code in Enum.GetValues(typeof(ProductStatus)))
            {
                DataRow row = dt.NewRow();
                row["code"] = code;
                row["status"] = Enum.GetName(typeof(ProductStatus), code);
                dt.Rows.Add(row);
            }

            drpStatus.DataSource = dt;
            drpStatus.DataTextField = "status";
            drpStatus.DataValueField = "code";
            drpStatus.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int SelectedParentCategoryID = Convert.ToInt32(((HtmlInputHidden)CategorySelect1.FindControl("selectedCategory")).Value);

            string strErr = "";
            if (this.txtProductName.Text == "")
            {
                strErr += "ProductName不能为空！\\n";
            }
            if (SelectedParentCategoryID == 0)
            {
                strErr += "CatePath不能为空！\\n";
            }
            if (!PageValidate.IsDecimal(txtTradePrice.Text))
            {
                strErr += "TradePrice不是数字！\\n";
            }
            if (!PageValidate.IsDecimal(txtMerchantPrice.Text))
            {
                strErr += "MerchantPrice不是数字！\\n";
            }
            if (!PageValidate.IsDecimal(txtReducePrice.Text))
            {
                strErr += "ReducePrice不是数字！\\n";
            }
            if (!PageValidate.IsNumber(txtStock.Text))
            {
                strErr += "Stock不是数字！\\n";
            }
            if (this.fulImage.FileName == "")
            {
                strErr += "SmallImage不能为空！\\n";
            }
            if (this.txtKeywords.Text == "")
            {
                strErr += "Keywords不能为空！\\n";
            }
            if (this.fckBrief.Value == "")
            {
                strErr += "Brief不能为空！\\n";
            }
            if (!PageValidate.IsNumber(drpStatus.SelectedValue))
            {
                strErr += "Status不是数字！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }

            int ProductID = CommDataHelper.GetNewSerialNum("pd");

            string[] MainImages;

            if (ProductMainImageRule.SaveProductMainImage(ProductID, fulImage.PostedFile, out MainImages))
            {
                ProductModel product = new ProductModel();

                product.ProductId = ProductID;
                product.ProductCode = String.IsNullOrEmpty(txtProductCode.Text) ? ProductID.ToString() : txtProductCode.Text;
                product.ProductName = txtProductName.Text;

                CategoryModel cate = new CategoryModelBll().GetModel(SelectedParentCategoryID);

                product.CateId = cate.CateId;
                product.CatePath = cate.CatePath;
                product.InsertTime = DateTime.Now;
                product.ChangeTime = DateTime.Now;
                product.Keywords = txtKeywords.Text;
                product.Brief = fckBrief.Value;


                product.SmallImage = MainImages[0];
                product.MediumImage = MainImages[1];
                product.LargeImage = MainImages[2];

                product.MerchantPrice = Convert.ToDecimal(txtMerchantPrice.Text);
                product.ReducePrice = Convert.ToDecimal(txtReducePrice.Text);
                product.TradePrice = Convert.ToDecimal(txtTradePrice.Text);
                product.PageView = 0;
                product.Score = 0;
                //product.SortValue = "";
                product.Status = Convert.ToInt32(drpStatus.SelectedValue);
                product.Stock = Convert.ToInt32(txtStock.Text);

                bll.Add(product);
            }
            else
            {
                //图片上传失败
            }

        }
    }
}
