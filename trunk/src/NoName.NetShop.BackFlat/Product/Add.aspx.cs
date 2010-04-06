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
        private int ProductID
        {
            get
            {
                if (ViewState["ProductID"] != null)
                    return Convert.ToInt32(ViewState["ProductID"]);
                else 
                {
                    ViewState["ProductID"] = CommDataHelper.GetNewSerialNum(AppType.Product);
                    return Convert.ToInt32(ViewState["ProductID"]);
                }
            }
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
                BindSpecificationData();
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

            DropDown_Specification.DataSource = AddSelectRow(new ProductSpecificationBll().GetList(SpecificationType.规格参数));
            DropDown_Specification.DataTextField = "title";
            DropDown_Specification.DataValueField = "content";
            DropDown_Specification.DataBind();

            txtProductCode.Text = ProductID.ToString();
        }

        private void BindParameterData()
        {
            DataTable dt = pBll.GetList("cateid = " + CategoryID + " and paratype=" + (int)CategoryParameterType.检索属性).Tables[0];

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

        private void BindSpecificationData()
        {
            DataTable dt = pBll.GetList("cateid = " + CategoryID + " and paratype=" + (int)CategoryParameterType.规格参数).Tables[0];

            GridView_Specification.DataSource = dt;
            GridView_Specification.DataBind();

            for (int i = 0; i < GridView_Specification.Rows.Count; i++)
            {
                RadioButtonList ValueList = ((RadioButtonList)GridView_Specification.Rows[i].Cells[1].FindControl("RadioList_SpecificationValue"));

                string[] Values = dt.Rows[i]["paravalues"].ToString().Split(',');
                for (int j = 0; j < Values.Length; j++)
                {
                    ListItem item = new ListItem();

                    item.Text = Values[j];
                    item.Value = j.ToString();

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


        private void AddProduct()
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
            if (!PageValidate.IsNumber(txtScore.Text))
            {
                strErr += "商品积分输入有误！\\n";
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
            if (this.TextBox_Description.Text == "")
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

            if (bll.Exists(txtProductName.Text))
            {
                MessageBox.Show(this,"对不起，该商品名称已存在，无法添加同名商品");
                return;
            }

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
                product.BrandID = Convert.ToInt32(DropDown_Brand.SelectedValue);


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
                product.Stock = int.MaxValue;

                product.Specifications = TextBox_Specification.Text;
                product.PackingList = TextBox_Packing.Text;
                product.AfterSaleService = TextBox_Service.Text;
                product.OfferSet = TextBox_OfferSet.Text;

                product.Weight = Convert.ToDecimal(txtWeight.Text);

                product.StockTip = GetStockTip();
                product.RelateProducts = txtRelateProduct.Text.Replace("，",",");

                bll.Add(product);

                //添加产品检索属性
                foreach (GridViewRow row in GridView_Parameter.Rows)
                {
                    RadioButtonList ParameterValueList =((RadioButtonList)row.Cells[0].FindControl("RadioList_ParameterValue"));
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
                //添加产品基本属性
                foreach (GridViewRow row in GridView_Specification.Rows)
                {
                    RadioButtonList ParameterValueList = ((RadioButtonList)row.Cells[0].FindControl("RadioList_SpecificationValue"));
                    if (!String.IsNullOrEmpty(ParameterValueList.SelectedValue))
                    {
                        int ParameterID = Convert.ToInt32(((HiddenField)row.Cells[0].FindControl("Hidden_SpecificationID")).Value);
                        string ParameterValue = Convert.ToString(ParameterValueList.SelectedItem.Text);
                        ProductParaModel para = new ProductParaModel();

                        para.ParaId = ParameterID;
                        para.ProductId = product.ProductId;
                        para.ParaValue = ParameterValue;

                        pvBll.Add(para);
                    }
                }
                //添加商品多图
                foreach (string s in Request.Files.AllKeys)
                {
                    if (s.StartsWith("multiImageUpload") && Request.Files[s].ContentLength>0)
                    {
                        string[] FileNames;
                        ProductMultiImageRule.SaveProductMultiImage(ProductID, Request.Files[s], out FileNames);

                        if (FileNames != null)
                        {
                            ProductImageModel model = new ProductImageModel();
                            model.ImageId = CommDataHelper.GetNewSerialNum("pd");
                            model.ProductId = ProductID;
                            model.LargeImage = FileNames[1];
                            model.OriginImage = FileNames[2];
                            model.SmallImage = FileNames[0];
                            model.Title = String.Empty;

                            new ProductImageModelBll().Add(model);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "图片上传失败，请检查！");
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

        private string GetStockTip()
        {
            string StockTip = String.Empty;

            if (Convert.ToInt32(CheckBoxList_BJ.SelectedValue) == 1) StockTip += "北京有货, ";
            else StockTip += "北京无货, ";

            if (Convert.ToInt32(CheckBoxList_GZ.SelectedValue) == 1) StockTip += "广州有货, ";
            else StockTip += "广州无货, ";

            if (Convert.ToInt32(CheckBoxList_HH.SelectedValue) == 1) StockTip += "呼和浩特有货, ";
            else StockTip += "呼和浩特无货, ";

            if (Convert.ToInt32(CheckBoxList_SH.SelectedValue) == 1) StockTip += "上海有货, ";
            else StockTip += "上海无货, ";

            return StockTip.Substring(0, StockTip.Length - 1);
        }




        /*
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
         * */

    }
}
