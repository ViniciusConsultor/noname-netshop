using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Auction.BLL;
using NoName.Utility;
using NoName.NetShop.Common;
using NoName.NetShop.Auction.Facade;
using NoName.NetShop.Auction.Model;

namespace NoName.NetShop.ForeFlat.member.Auction
{
    public partial class Add : System.Web.UI.Page
    {
        private AuctionProductModelBll bll = new AuctionProductModelBll();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button_Add_Click(object sender, EventArgs e)
        {
            string strErr = "";

            if (TextBox_AuctionProductName.Text == "")
            {
                strErr += "产品名称为空！\\n";
            }
            if (TextBox_StartPrice.Text == "" || !PageValidate.IsDecimal(TextBox_StartPrice.Text))
            {
                strErr += "起拍价为空或者不是数字！\\n";
            }
            if (TextBox_AddPrice.Text == "" || !PageValidate.IsDecimal(TextBox_AddPrice.Text))
            {
                strErr += "每次加价为空或者不是数字！\\n";
            }
            if (TextBox_StartTime.Text == "" || !PageValidate.IsDate(TextBox_StartTime.Text))
            {
                strErr += "开始时间为空或者格式错误！\\n";
            }
            if (TextBox_EndTime.Text == "" || !PageValidate.IsDate(TextBox_EndTime.Text))
            {
                strErr += "结束时间为空或者格式错误！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }

            int AuctionProductID = CommDataHelper.GetNewSerialNum("au");

            string[] ProductImages;
            if (AuctionProductImageRule.SaveProductMainImage(AuctionProductID, FileUpload_ProductImage.PostedFile, out ProductImages))
            {
                AuctionProductModel model = new AuctionProductModel();

                model.AuctionId = AuctionProductID;
                model.ProductName = TextBox_AuctionProductName.Text;
                model.StartPrice = Convert.ToDecimal(TextBox_StartPrice.Text);
                model.AddPrices = Convert.ToDecimal(TextBox_AddPrice.Text);
                model.CurPrice = model.StartPrice;

                model.Brief = TextEditor_Brief.Value;

                model.StartTime = Convert.ToDateTime(TextBox_StartTime.Text);
                model.EndTime = Convert.ToDateTime(TextBox_EndTime.Text);

                model.MediumImage = ProductImages[0];
                model.SmallImage = ProductImages[1];

                model.OutLinkUrl = "";
                model.Status = 1;

                bll.Add(model);
                MessageBox.Show(this, "添加成功");
            }
            else
            {
                MessageBox.Show(this, "图片上传失败");
            }
        }
    }
}
