using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Solution.BLL;
using NoName.NetShop.Solution.Model;
using NoName.NetShop.Product.Facade;
using NoName.NetShop.Common;

namespace NoName.NetShop.BackFlat.Solution
{
    public partial class ShowCommendDetail : System.Web.UI.Page
    {

        private int ScenceId
        {
            get
            {
                if (ViewState["scenceId"] == null)
                    ViewState["scenceId"] = 0;
                return (int)ViewState["scenceId"];
            }
            set
            {
                ViewState["scenceId"] = value;
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int suiteId,scenceId;
                if (!int.TryParse(Request.QueryString["id"], out suiteId))
                {
                    suiteId = 0;
                }

                if (!int.TryParse(Request.QueryString["sid"], out scenceId))
                {
                    scenceId = 0;
                }
                ScenceId = scenceId;

                ShowInfo(suiteId);
            }
        }

        private void ShowInfo(int suiteId)
        {
            SuiteBll sbll = new SuiteBll();
            SolutionProductBll spbll = new SolutionProductBll();
            SuiteModel smodel = sbll.GetModel(suiteId);
            if (smodel == null)
            {
                btnAddProduct.Visible = false;
                txtProductId.Visible = false;
                lblScenceId.Text = ScenceId.ToString();
            }
            else
            {
                btnAddProduct.Visible = true;
                txtProductId.Visible = true;
                lblSuiteId.Text = smodel.SuiteId.ToString();
                txtRemark.Text = smodel.Remark;
                txtScore.Text = smodel.Score.ToString();
                txtScore.ReadOnly = true;
                txtSuiteName.Text = smodel.SuiteName;
                lblScenceId.Text = smodel.ScenceId.ToString();

                lblPrice.Text = smodel.ProductFee.ToString("F2");
                txtDerate.Text = smodel.DerateFee.ToString("F2");

                if (!String.IsNullOrEmpty(smodel.SmallImage))
                {
                    this.imgSuite.Visible = true;
                    this.imgSuite.ImageUrl = Common.CommonImageUpload.GetCommonImageFullUrl(smodel.SmallImage);
                }
                else
                {
                    this.imgSuite.Visible = false;
                }

                gvItems.DataSource = spbll.GetModelList(suiteId);
                gvItems.DataBind();                
            }
        }


        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            int productId = int.Parse(txtProductId.Text);
            int quantity = int.Parse(txtQuantity.Text);
            int suiteId = int.Parse(lblSuiteId.Text);

            NoName.NetShop.Product.BLL.ProductModelBll pbll = new NoName.NetShop.Product.BLL.ProductModelBll();
            SolutionProductBll spbll = new SolutionProductBll();
            NoName.NetShop.Product.Model.ProductModel pmodel = pbll.GetModel(productId);

            SuiteBll sbll = new SuiteBll();
            if (pmodel != null)
            {
                NoName.NetShop.Solution.Model.SolutionProductModel spmodel = new SolutionProductModel();
                spmodel.Price = pmodel.MerchantPrice;
                spmodel.ProductId = pmodel.ProductId;
                spmodel.Quantity = quantity;
                spmodel.SuiteId = suiteId;
                spbll.Save(spmodel);
                sbll.SetPriceFromRefrence(suiteId);
            }
            ShowInfo(suiteId);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SuiteBll sbll = new SuiteBll();
            int suiteId = String.IsNullOrEmpty(lblSuiteId.Text) ? 0 : int.Parse(lblSuiteId.Text);

            SuiteModel smodel = sbll.GetModel(suiteId);
            if (smodel == null)
            {
                smodel = new SuiteModel();
                smodel.Price =0m;
                smodel.Score =0;
                smodel.SuiteId = NoName.NetShop.Common.CommDataHelper.GetNewSerialNum(AppType.Product);
                smodel.ScenceId = ScenceId;
            }
            smodel.ProductFee = decimal.Parse(lblPrice.Text);
            smodel.DerateFee = decimal.Parse(txtDerate.Text);
            smodel.Price = smodel.ProductFee - smodel.DerateFee;
            smodel.Remark = txtRemark.Text.Trim();
            smodel.SuiteName = txtSuiteName.Text.Trim();
            if (!String.IsNullOrEmpty(fulImage.FileName))
            {
                string[] MainImages;
                if (ProductMainImageRule.SaveProductMainImage(smodel.SuiteId, fulImage.PostedFile, out MainImages))
                {
                    smodel.SmallImage = MainImages[0];
                    smodel.MediumImage = MainImages[1];
                    smodel.LargeImage = MainImages[2];
                }
            }
            sbll.Save(smodel);
            this.ShowInfo(smodel.SuiteId);
        }

        protected void gvItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SolutionProductBll spbll = new SolutionProductBll();
            int productId = Convert.ToInt32(gvItems.DataKeys[e.RowIndex].Values["ProductId"]);
            int suitId = int.Parse(lblSuiteId.Text);
            spbll.Delete(suitId, productId);
            SuiteBll sbll = new SuiteBll();
            sbll.SetPriceFromRefrence(suitId);

            ShowInfo(suitId);
        }
    }
}
