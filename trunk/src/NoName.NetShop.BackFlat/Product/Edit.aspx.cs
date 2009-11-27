using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Product.BLL;
using NoName.NetShop.Product.Model;
using NoName.NetShop.Product.Facade;
using NoName.Utility;
using System.Web.UI.HtmlControls;
using System.Data;

namespace NoName.NetShop.BackFlat.Product
{
    public partial class Edit : System.Web.UI.Page
    {
        private int ProductID
        {
            get { if (ViewState["ProductID"] != null) return Convert.ToInt32(ViewState["ProductID"]); else return 0; }
            set { ViewState["ProductID"] = value; }
        }
        private int CategoryID
        {
            get { if (ViewState["CategoryID"] != null) return Convert.ToInt32(ViewState["CategoryID"]); else return -1; }
            set { ViewState["CategoryID"] = value; }
        }
        private ProductModelBll bll = new ProductModelBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["productid"])) ProductID = Convert.ToInt32(Request.QueryString["productid"]);
                if (!String.IsNullOrEmpty(Request.QueryString["categoryid"])) CategoryID = Convert.ToInt32(Request.QueryString["categoryid"]);
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

            ProductModel product = ProductMainImageRule.GetMainImageUr(bll.GetModel(ProductID));

            if (product != null)
            {
                txtProductName.Text = product.ProductName;
                txtProductCode.Text = product.ProductCode;
                txtTradePrice.Text = product.TradePrice.ToString();
                txtMerchantPrice.Text = product.MerchantPrice.ToString();
                txtReducePrice.Text = product.ReducePrice.ToString();
                txtStock.Text = product.Stock.ToString();
                drpStatus.SelectedValue = product.Status.ToString();
                txtKeywords.Text = product.Keywords;
                fckBrief.Value = product.Brief;
                imgProduct.ImageUrl = product.SmallImage;
                if (CategoryID != -1)
                {
                    Label_CategoryNamePath.Text = new CategoryModelBll().GetCategoryNamePath(CategoryID);
                    txtCategoryID.Value = CategoryID.ToString();
                }
                else
                {
                    txtCategoryID.Value = product.CateId.ToString();
                    Label_CategoryNamePath.Text = new CategoryModelBll().GetCategoryNamePath(product.CateId);
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            string strErr = "";
            if (this.txtProductName.Text == "")
            {
                strErr += "ProductName不能为空！\\n";
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

            ProductModel product = bll.GetModel(ProductID);

            product.ProductName = txtProductName.Text;
            product.ProductCode = txtProductCode.Text;
            product.CateId = Convert.ToInt32(txtCategoryID.Value);
            product.TradePrice = Convert.ToDecimal(txtTradePrice.Text);
            product.MerchantPrice = Convert.ToDecimal(txtMerchantPrice.Text);
            product.ReducePrice = Convert.ToDecimal(txtReducePrice.Text);
            product.Stock = Convert.ToInt32(txtStock.Text);
            product.Status = Convert.ToInt32(drpStatus.SelectedValue);
            product.Keywords = txtKeywords.Text;
            product.Brief = fckBrief.Value;

            if (fulImage.FileName != String.Empty)
            {
                string[] MainImages;
                ProductMainImageRule.SaveProductMainImage(ProductID, fulImage.PostedFile, out MainImages);
                product.SmallImage = MainImages[0];
                product.MediumImage = MainImages[1];
                product.LargeImage = MainImages[2];
            }

            bll.Update(product);

            MessageBox.Show(this,"更改成功");
        }
    }
}
