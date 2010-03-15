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
using NoName.NetShop.Common;

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
                BindMultiImageData();
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

            ProductModel product = ProductMainImageRule.GetMainImageUrl(bll.GetModel(ProductID));

            drpStatus.DataSource = dt;
            drpStatus.DataTextField = "status";
            drpStatus.DataValueField = "code";
            drpStatus.DataBind();

            DropDown_Brand.DataSource = new BrandCategoryRelationBll().GetCategoryBrandList(CategoryID == -1 ? product.CateId : CategoryID);
            DropDown_Brand.DataTextField = "brandname";
            DropDown_Brand.DataValueField = "brandid";
            DropDown_Brand.DataBind();

            DropDown_Packing.DataSource = AddSelectRow(new ProductSpecificationBll().GetList(SpecificationType.包装清单));
            DropDown_Packing.DataTextField = "title";
            DropDown_Packing.DataValueField = "content";
            DropDown_Packing.DataBind();

            DropDown_Service.DataSource = AddSelectRow(new ProductSpecificationBll().GetList(SpecificationType.售后服务));
            DropDown_Service.DataTextField = "title";
            DropDown_Service.DataValueField = "content";
            DropDown_Service.DataBind();

            DropDown_OfferSet.DataSource = AddSelectRow(new ProductSpecificationBll().GetList(SpecificationType.优惠套装));
            DropDown_OfferSet.DataTextField = "title";
            DropDown_OfferSet.DataValueField = "content";
            DropDown_OfferSet.DataBind();

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


                TextBox_Packing.Text = product.PackingList;
                TextBox_Service.Text = product.AfterSaleService;
                TextBox_OfferSet.Text = product.OfferSet;
                txtWeight.Text = product.Weight.ToString("0.00");

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
                DropDown_Brand.SelectedValue = product.BrandID.ToString();

                BindParameterData(product.CateId);

                ReselectCategory.HRef = String.Format("CategorySelect.aspx?cid={0}&pid={1}",product.CateId,product.ProductId);
            }
        }


        private void BindParameterData(int cateid)
        {
            DataTable dt = pBll.GetList("cateid = " + CategoryID + " and paratype=" + (int)CategoryParameterType.检索参数).Tables[0];
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

        private void BindMultiImageData()
        {
            DataTable multiImageDataTable = new ProductImageModelBll().GetList(ProductID).Tables[0];

            foreach (DataRow row in multiImageDataTable.Rows)
            {
                row["smallimage"] = ProductMultiImageRule.GetMultiImageUrl(Convert.ToString(row["smallimage"]));
                row["largeimage"] = ProductMultiImageRule.GetMultiImageUrl(Convert.ToString(row["largeimage"]));
                row["originimage"] = ProductMultiImageRule.GetMultiImageUrl(Convert.ToString(row["originimage"]));
            }

            GridView_MultiImage.DataSource = multiImageDataTable;
            GridView_MultiImage.DataBind();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        protected void Button_MultiImageUpload_Click(object sender, EventArgs e)
        {
            AddMultiImage();
        }

        protected void GridView_MultiImage_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "d")
            {
                int ImageID = Convert.ToInt32(e.CommandArgument);

                ProductImageModel model = new ProductImageModelBll().GetModel(ImageID);

                ProductMultiImageRule.DeleteMultiImage(model.LargeImage);
                ProductMultiImageRule.DeleteMultiImage(model.OriginImage);
                ProductMultiImageRule.DeleteMultiImage(model.SmallImage);

                new ProductImageModelBll().Delete(ImageID);
                BindMultiImageData();
            }
            if (e.CommandName.ToLower() == "u")
            {
                int ImageID = Convert.ToInt32(e.CommandArgument);
                int ImageCount = GridView_MultiImage.Rows.Count;
                int Position = 0;
                for (int i = 0; i < ImageCount; i++)
                {
                    if (ImageID == Convert.ToInt32(GridView_MultiImage.Rows[i].Cells[0].Text))
                    {
                        Position = i;
                        break;
                    }
                }

                if (Position != 0)
                {
                    new ProductImageModelBll().SwitchOrder(ImageID, Convert.ToInt32(GridView_MultiImage.Rows[Position - 1].Cells[0].Text));
                }

                BindMultiImageData();
            }
            if (e.CommandName.ToLower() == "l")
            {
                int ImageID = Convert.ToInt32(e.CommandArgument);
                int ImageCount = GridView_MultiImage.Rows.Count;
                int Position = 0;
                for (int i = 0; i < ImageCount; i++)
                {
                    if (ImageID == Convert.ToInt32(GridView_MultiImage.Rows[i].Cells[0].Text))
                    {
                        Position = i;
                        break;
                    }
                }

                if (Position != ImageCount)
                {
                    new ProductImageModelBll().SwitchOrder(ImageID, Convert.ToInt32(GridView_MultiImage.Rows[Position + 1].Cells[0].Text));
                }

                BindMultiImageData();
            }
        }


        private void SaveData()
        {
            string strErr = "";
            if (this.txtProductName.Text == "")
            {
                strErr += "产品名称不能为空！\\n";
            }
            if (!PageValidate.IsDecimal(txtTradePrice.Text))
            {
                strErr += "市场价输入有误！\\n";
            }
            if (!PageValidate.IsDecimal(txtMerchantPrice.Text))
            {
                strErr += "销售价输入有误！\\n";
            }
            if (!PageValidate.IsDecimal(txtReducePrice.Text))
            {
                strErr += "直降价输入有误！\\n";
            }
            if (!PageValidate.IsNumber(txtStock.Text))
            {
                strErr += "商品库存输入有误！\\n";
            }
            if (!PageValidate.IsDecimal(txtWeight.Text))
            {
                strErr += "商品重量输入有误！\\n";
            }
            if (this.fulImage.FileName == "")
            {
                strErr += "产品图片不能为空！\\n";
            }
            if (this.txtKeywords.Text == "")
            {
                strErr += "关键词不能为空！\\n";
            }
            if (this.TextBox_Brief.Text == "")
            {
                strErr += "商品简介不能为空！\\n";
            }
            if (!PageValidate.IsNumber(drpStatus.SelectedValue))
            {
                strErr += "商品状态选择有误！\\n";
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
            product.BrandID = Convert.ToInt32(DropDown_Brand.SelectedValue);

            product.OfferSet = TextBox_OfferSet.Text;
            product.PackingList = TextBox_Packing.Text;
            product.AfterSaleService = TextBox_Service.Text;

            product.Weight = Convert.ToDecimal(txtWeight.Text);

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

            Response.Redirect("List.aspx");
        }

        private void AddMultiImage()
        {
            if (!String.IsNullOrEmpty(TextBox_MiltiImageDescription.Text) && !String.IsNullOrEmpty(FileUpload_MultiImage.FileName))
            {
                string[] FileNames;
                ProductMultiImageRule.SaveProductMultiImage(ProductID, FileUpload_MultiImage.PostedFile, out FileNames);

                if (FileNames != null)
                {
                    ProductImageModel model = new ProductImageModel();
                    model.ImageId = CommDataHelper.GetNewSerialNum(AppType.Product);
                    model.ProductId = ProductID;
                    model.LargeImage = FileNames[1];
                    model.OriginImage = FileNames[2];
                    model.SmallImage = FileNames[0];
                    model.Title = TextBox_MiltiImageDescription.Text;

                    new ProductImageModelBll().Add(model);
                    BindMultiImageData();

                    MessageBox.Show(this, "添加成功！");
                }
            }
            else
            {
                MessageBox.Show(this, "输入不完整");
            }
        }

        private DataTable AddSelectRow(DataTable InputTable)
        {
            DataTable newTable = InputTable.Clone();

            DataRow row = newTable.NewRow();

            row["title"] = "请选择...";
            row["content"] = String.Empty;

            newTable.Rows.Add(row);

            foreach (DataRow nrow in InputTable.Rows) newTable.ImportRow(nrow);

            return newTable;
        }
    }
}
