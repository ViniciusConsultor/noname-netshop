using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.Utility;
using NoName.NetShop.Common;
using NoName.NetShop.Product.Facade;

namespace NoName.NetShop.BackFlat.Gift
{
    public partial class ShowGiftProduct : System.Web.UI.Page
    {
        private NoName.NetShop.Product.BLL.GiftBll gbll = new NoName.NetShop.Product.BLL.GiftBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int productId = 0;
                if (!int.TryParse(Request.QueryString["productId"], out productId))
                {
                    productId = 0;
                }

                ShowInfo(productId);
            }
        }

         protected void btnAdd_Click(object sender, EventArgs e)
        {

            string strErr = "";

            if (this.txtProductName.Text == "")
            {
                strErr += "ProductName不能为空！\\n";
            }
            if (!PageValidate.IsNumber(txtStock.Text))
            {
                strErr += "Stock不是数字！\\n";
            }
            if (this.txtKeywords.Text == "")
            {
                strErr += "Keywords不能为空！\\n";
            }
            if (this.txtBrief.Text == "")
            {
                strErr += "Brief不能为空！\\n";
            }

            if (!PageValidate.IsNumber(txtScore.Text))
            {
                strErr += "Score不是数字！\\n";
            }
            if (this.txtDecription.Text == "")
            {
                strErr += "Decription不能为空！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            int ProductId;
            if (!int.TryParse(this.litProductId.Text, out ProductId))
            {
                ProductId = 0;
            }
            string ProductName = this.txtProductName.Text;
            int Stock = int.Parse(this.txtStock.Text);
            string Keywords = this.txtKeywords.Text;
            string Brief = this.txtBrief.Text;
            int Status = int.Parse(this.rblStatus.SelectedValue);
            int Score = int.Parse(this.txtScore.Text);
            string Decription = this.txtDecription.Text;

            NoName.NetShop.Product.Model.GiftModel model = new NoName.NetShop.Product.Model.GiftModel();
            model.ProductId = ProductId;
            if (ProductId == 0)
            {
                model.ProductId = NoName.NetShop.Common.CommDataHelper.GetNewSerialNum(AppType.Product);
            }
            model.ProductName = ProductName;
            model.Stock = Stock;

            if (fulImage.HasFile)
            {
                string[] MainImages;
                if (ProductMainImageRule.SaveProductMainImage(model.ProductId, "gift/", fulImage.PostedFile, out MainImages))
                {
                    model.SmallImage = MainImages[0];
                    model.MediumImage = MainImages[1];
                    model.LargeImage = MainImages[2];
                }
            }
            model.Keywords = Keywords;
            model.Brief = Brief;
            model.Status = Status;
            model.SortValue = 0;
            model.Score = Score;
            model.Decription = Decription;

            gbll.Save(model);
            Response.Redirect("GiftProductList.aspx");
        }


        private void ShowInfo(int productId)
        {
            if (productId != 0)
            {
                NoName.NetShop.Product.Model.GiftModel model = gbll.GetModel(productId);
                this.litProductId.Text = model.ProductId.ToString();
                this.txtProductName.Text = model.ProductName;
                this.txtStock.Text = model.Stock.ToString();
                this.txtKeywords.Text = model.Keywords;
                this.txtBrief.Text = model.Brief;
                this.litInsertTime.Text = model.InsertTime.ToString("yyyy-MM-dd HH:mm:ss");
                this.litChangeTime.Text = model.ChangeTime.ToString("yyyy-MM-dd HH:mm:ss");
                this.rblStatus.Items.FindByValue(model.Status.ToString()).Selected = true;
                this.txtScore.Text = model.Score.ToString();
                this.txtDecription.Text = model.Decription;
                if (!String.IsNullOrEmpty(model.SmallImage))
                {
                    this.imgProduct.Visible = true;
                    this.imgProduct.ImageUrl = ProductMainImageRule.GetMainImageUrl(model.SmallImage);
                }
                else
                {
                    this.imgProduct.Visible = false;
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            gbll.Delete(int.Parse(litProductId.Text));
            Response.Redirect("GiftProductList.aspx");
        }



    }
}
