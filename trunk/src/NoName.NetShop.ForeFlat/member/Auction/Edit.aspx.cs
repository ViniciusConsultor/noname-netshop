using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.Utility;
using NoName.NetShop.MagicWorld.BLL;
using NoName.NetShop.MagicWorld.Model;
using NoName.NetShop.MagicWorld.Facade;

namespace NoName.NetShop.ForeFlat.member.Auction
{
    public partial class Edit : System.Web.UI.Page
    {
        private int AuctionID
        {
            get { if (ViewState["AuctionID"] != null) return Convert.ToInt32(ViewState["AuctionID"]); else return -1; }
            set { ViewState["AuctionID"] = value; }
        }
        private AuctionProductBll bll = new AuctionProductBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["pid"])) AuctionID = Convert.ToInt32(Request.QueryString["pid"]);
                BindData();
            }
        }

        private void BindData()
        {
            AuctionProductModel model = bll.GetModel(AuctionID);

            TextBox_AuctionProductName.Text = model.ProductName;
            TextBox_StartPrice.Text = model.StartPrice.ToString();
            TextBox_AddPrice.Text = model.AddPrices.ToString();
            TextBox_StartTime.Text = model.StartTime.ToString("yyyy-MM-dd HH:mm:ss");
            TextBox_EndTime.Text = model.EndTime.ToString("yyyy-MM-dd HH:mm:ss");
            TextEditor_Brief.Value = model.Brief;
        }

        protected void Button_Edit_Click(object sender, EventArgs e)
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
            
            AuctionProductModel model = bll.GetModel(AuctionID);

            if (FileUpload_ProductImage.FileName != String.Empty)
            {
                string[] ProductImages;
                if (AuctionImageRule.SaveProductMainImage(AuctionID, FileUpload_ProductImage.PostedFile, out ProductImages))
                {
                    model.MediumImage = ProductImages[0];
                    model.SmallImage = ProductImages[1];
                }
                else
                {
                    MessageBox.Show(this,"图片上传失败！");
                    return;
                }
            }

            model.ProductName = TextBox_AuctionProductName.Text;
            model.StartPrice = Convert.ToDecimal(TextBox_StartPrice.Text);
            model.AddPrices = TextBox_AddPrice.Text;
            model.Brief = TextEditor_Brief.Value;
            model.StartTime = Convert.ToDateTime(TextBox_StartTime.Text);
            if (model.Status == (int)AuctionProductStatus.审核未通过) model.Status = (int)AuctionProductStatus.尚未审核;
            model.EndTime = Convert.ToDateTime(TextBox_EndTime.Text);


            bll.Update(model);
            MessageBox.Show(this, "更新成功");
        }
    }
}
