using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Auction.Facade;
using NoName.NetShop.Auction.BLL;
using NoName.NetShop.Auction.Model;
using NoName.Utility;

namespace NoName.NetShop.BackFlat.Auction
{
    public partial class Edit : System.Web.UI.Page
    {
        private int AuctionID
        {
            get { if(ViewState["AuctionID"]!=null) return Convert.ToInt32(ViewState["AuctionID"]); else return -1;}
            set { ViewState["AuctionID"] = value; }
        }
        private AuctionProductModelBll bll = new AuctionProductModelBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["auctionid"])) AuctionID = Convert.ToInt32(Request.QueryString["auctionid"]);
                BindData();
            }
        }

        private void BindData()
        {
            AuctionProductModel model = bll.GetModel(AuctionID);

            TextBox_AuctionProductName.Text = model.ProductName;
            TextBox_StartPrice.Text = model.StartPrice.ToString();
            TextBox_AddPrice.Text = model.AddPrices.ToString();
            TextBox_StartTime.Text = model.StartTime.ToString("yyyy-MM-dd hh:mm:ss") ;
            TextBox_EndTime.Text = model.EndTime.ToString("yyyy-MM-dd hh:mm:ss");
            TextEditor_Brief.Value = model.Brief;
            Image_MainImage.ImageUrl = AuctionProductImageRule.GetMainImageUrl(model.SmallImage);
        }


        protected void Button_Eidt_Click(object sender, EventArgs e)
        {
            AuctionProductModel model = bll.GetModel(AuctionID);

            if (FileUpload_ProductImage.FileName != String.Empty)
            {
                string[] ProductImages;

                if (AuctionProductImageRule.SaveProductMainImage(model.AuctionId, FileUpload_ProductImage.PostedFile, out ProductImages))
                {
                    model.MediumImage = ProductImages[0];
                    model.SmallImage = ProductImages[1];
                }
                else
                {
                    MessageBox.Show(this, "图片上传失败");
                    return;
                }
            }

            model.ProductName = TextBox_AuctionProductName.Text;
            model.StartPrice = Convert.ToDecimal(TextBox_StartPrice.Text);
            model.AddPrices = Convert.ToDecimal(TextBox_AddPrice.Text);
            model.Brief = TextEditor_Brief.Value;
            model.StartTime = Convert.ToDateTime(TextBox_StartTime.Text);
            model.EndTime = Convert.ToDateTime(TextBox_EndTime.Text);

            
            bll.Update(model);

            MessageBox.Show(this, "修改成功");
        }
    }
}
