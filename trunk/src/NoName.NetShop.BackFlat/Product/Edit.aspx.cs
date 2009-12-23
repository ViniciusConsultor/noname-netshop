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
using System.Collections;

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
        private CategoryParaModelBll pBll = new CategoryParaModelBll();
        private ProductParaModelBll pvBll = new ProductParaModelBll();

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
                TextBox_Brief.Text = product.Brief;
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

                BindParameterData(product.CateId);

                ReselectCategory.HRef = String.Format("CategorySelect.aspx?cid={0}&pid={1}",product.CateId,product.ProductId);
            }
        }


        private void BindParameterData(int cateid)
        {
            DataTable dt = pBll.GetList("cateid = " + cateid).Tables[0];
            DataTable ValueTable = pvBll.GetList(" productid = " + ProductID).Tables[0];

            Hashtable vtable = new Hashtable();
            foreach(DataRow row in ValueTable.Rows)
            {
                vtable.Add(Convert.ToInt32(row["paraid"]),row["paravalue"]);
            }

            GridView_Parameter.DataSource = dt;
            GridView_Parameter.DataBind();

            for (int i = 0; i < GridView_Parameter.Rows.Count; i++)
            {
                RadioButtonList ValueList = ((RadioButtonList)GridView_Parameter.Rows[i].Cells[1].FindControl("RadioList_ParameterValue"));
                string SelectedValue = String.Empty;

                if (vtable[Convert.ToInt32(dt.Rows[i]["paraid"])] != null) SelectedValue = vtable[Convert.ToInt32(dt.Rows[i]["paraid"])].ToString();
                string[] Values = dt.Rows[i]["paravalues"].ToString().Split(',');

                for (int j = 0; j < Values.Length; j++)
                {
                    ListItem item = new ListItem();

                    item.Text = Values[j];
                    item.Value = j.ToString();

                    if (item.Text == SelectedValue) item.Selected = true;

                    ValueList.Items.Add(item);
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
            if (this.TextBox_Brief.Text == "")
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
            product.Brief = TextBox_Brief.Text;

            if (fulImage.FileName != String.Empty)
            {
                string[] MainImages;
                ProductMainImageRule.SaveProductMainImage(ProductID, fulImage.PostedFile, out MainImages);
                product.SmallImage = MainImages[0];
                product.MediumImage = MainImages[1];
                product.LargeImage = MainImages[2];
            }

            foreach (GridViewRow row in GridView_Parameter.Rows)
            {
                RadioButtonList ParameterValueList = ((RadioButtonList)row.Cells[0].FindControl("RadioList_ParameterValue"));
                if (!String.IsNullOrEmpty(ParameterValueList.SelectedValue))
                {
                    int ParameterID = Convert.ToInt32(((HiddenField)row.Cells[0].FindControl("Hidden_ParameterID")).Value);
                    string ParameterValue = Convert.ToString(ParameterValueList.SelectedItem.Text);
                    ProductParaModel para = new ProductParaModel();

                    para.ParaId = ParameterID;
                    para.ProductId = product.ProductId;
                    para.ParaValue = ParameterValue;

                    pvBll.Update(para);
                }
            }

            bll.Update(product);

            MessageBox.Show(this,"更改成功");
        }
    }
}
