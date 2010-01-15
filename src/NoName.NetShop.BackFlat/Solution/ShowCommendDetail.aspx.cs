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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int suiteId;
                if (!int.TryParse(Request.QueryString["id"], out suiteId))
                {
                    suiteId = 0;
                }
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
            }
            else
            {
                btnAddProduct.Visible = true;
                lblSuiteId.Text = smodel.SuiteId.ToString();
                txtRemark.Text = smodel.Remark;
                txtScore.Text = smodel.Score.ToString();
                txtScore.ReadOnly = true;
                txtSuiteName.Text = smodel.SuiteName;

                if (!String.IsNullOrEmpty(smodel.SmallImage))
                {
                    this.imgSuite.Visible = true;
                    this.imgSuite.ImageUrl = smodel.SmallImage;
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
                spmodel.Quantity = 1;
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
            }
            smodel.Remark = txtRemark.Text.Trim();
            smodel.SuiteName = txtRemark.Text.Trim();

            string[] MainImages;

            if (ProductMainImageRule.SaveProductMainImage(smodel.SuiteId, fulImage.PostedFile, out MainImages))
            {
                smodel.SmallImage = MainImages[0];
                smodel.MediumImage = MainImages[1];
                smodel.LargeImage = MainImages[2];
            }
            sbll.Save(smodel);
            this.ShowInfo(smodel.SuiteId);
        }
    }
}
