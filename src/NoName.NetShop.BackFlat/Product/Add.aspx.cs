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
                if (!String.IsNullOrEmpty(Request.QueryString["CategoryID"])) CategoryID = Convert.ToInt32(Request.QueryString["CategoryID"]);
                else Response.End();
                BindData();
                BindParameterData();
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

            DropDown_Brand.DataSource = new BrandCategoryRelationBll().GetCategoryBrandList(CategoryID);
            DropDown_Brand.DataTextField = "brandname";
            DropDown_Brand.DataValueField = "brandid";
            DropDown_Brand.DataBind();

            Label_CategoryNamePath.Text = new CategoryModelBll().GetCategoryNamePath(CategoryID);
            txtCategoryID.Value = CategoryID.ToString();
        }

        private void BindParameterData()
        {
            DataTable dt = pBll.GetList("cateid = "+CategoryID).Tables[0];

            GridView_Parameter.DataSource = dt;
            GridView_Parameter.DataBind();

            for (int i = 0; i < GridView_Parameter.Rows.Count; i++)
            {
                RadioButtonList ValueList = ((RadioButtonList)GridView_Parameter.Rows[i].Cells[1].FindControl("RadioList_ParameterValue"));
                string[] Values =dt.Rows[i]["paravalues"].ToString().Split(',');
                for(int j = 0; j<Values.Length;j++ )
                {
                    ListItem item = new ListItem();

                    item.Text=Values[j];
                    item.Value=j.ToString();

                    ValueList.Items.Add(item);
                }
            }
        }
        
        protected void btnAddGoOn_Click(object sender, EventArgs e)
        {
            AddProduct();
            Response.Redirect(Request.RawUrl);
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddProduct();
            MessageBox.Show(this,"添加成功！");
        }
        protected void btnAddGoList_Click(object sender, EventArgs e)
        {
            AddProduct();
            Response.Redirect("List.aspx");
        }

        protected void Button_Exists_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtProductName.Text))
            {
                MessageBox.Show(this, bll.Exists(this.txtProductName.Text) ? "该商品已经存在" : "不存在该商品");
            }
            else
            {
                MessageBox.Show(this, "请输入商品名称");
            }
        }

        protected void AddProduct()
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
            if (this.fulImage.FileName == "")
            {
                strErr += "SmallImage不能为空！\\n";
            }
            if (this.txtKeywords.Text == "")
            {
                strErr += "Keywords不能为空！\\n";
            }
            if (this.TextBox_Description.Text == "")
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

            if (bll.Exists(txtProductName.Text))
            {
                MessageBox.Show(this,"对不起，该商品名称已存在，无法添加同名商品");
                return;
            }

            int ProductID = CommDataHelper.GetNewSerialNum(AppType.Product);

            string[] MainImages;

            if (ProductMainImageRule.SaveProductMainImage(ProductID, fulImage.PostedFile, out MainImages))
            {
                ProductModel product = new ProductModel();

                product.ProductId = ProductID;
                product.ProductCode = String.IsNullOrEmpty(txtProductCode.Text) ? ProductID.ToString() : txtProductCode.Text;
                product.ProductName = txtProductName.Text;

                CategoryModel cate = new CategoryModelBll().GetModel(Convert.ToInt32(txtCategoryID.Value));

                product.CateId = cate.CateId;
                product.CatePath = cate.CatePath;
                product.InsertTime = DateTime.Now;
                product.ChangeTime = DateTime.Now;
                product.Keywords = txtKeywords.Text;
                product.Brief = TextBox_Description.Text;


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

                product.Specifications = TextBox_Spe.Text;
                product.PackingList = TextBox_Packing.Text;
                product.AfterSaleService = TextBox_Service.Text;

                bll.Add(product);

                //添加产品属性
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

                        pvBll.Add(para);
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "图片上传失败，请检查！");
            }
        }
    }
}
