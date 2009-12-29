using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.Utility;
using NoName.NetShop.Common;
using NoName.NetShop.MagicWorld.BLL;
using NoName.NetShop.MagicWorld.Model;
using NoName.NetShop.MagicWorld.Facade;

namespace NoName.NetShop.ForeFlat.member.Auction
{
    public partial class Add : System.Web.UI.Page
    {
        private AuctionProductBll bll = new AuctionProductBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            MagicCategoryModel cate = new MagicCategoryBll().GetModel(Convert.ToInt32(Request.QueryString["categoryid"]));
            Label_Category.Text = cate.CategoryName;
            Hidden_CategoryID.Value = cate.CategoryID.ToString();
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
            if (TextBox_AddPrice.Text == "")
            {
                string test = TextBox_AddPrice.Text.Replace("，", ",");
                if (!test.Contains(",") && !PageValidate.IsDecimal(test))
                    strErr += "每次加价为空或者不是数字！\\n";
                else
                {
                    foreach (string s in test.Split(','))
                    {
                        if (!PageValidate.IsDecimal(s))
                            strErr += "每次加价为空或者不是数字！\\n";
                    }
                }
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

            int AuctionProductID = CommDataHelper.GetNewSerialNum(AppType.MagicWorld);

            string[] ProductImages;
            if (MagicWorldImageRule.SaveProductMainImage(AuctionProductID, FileUpload_ProductImage.PostedFile, out ProductImages))
            {
                AuctionProductModel model = new AuctionProductModel();
                MagicCategoryModel cate = new MagicCategoryBll().GetModel(Convert.ToInt32(Hidden_CategoryID.Value));

                model.AuctionID = AuctionProductID;
                model.ProductName = TextBox_AuctionProductName.Text;
                model.StartPrice = Convert.ToDecimal(TextBox_StartPrice.Text);
                model.AddPrices = TextBox_AddPrice.Text.Replace("，", ",");
                model.CurPrice = model.StartPrice;

                //model.CateID = cate.CategoryID;
                //model.CatePath = cate.CategoryPath;

                model.Brief = TextBox_Brief.Text;

                model.StartTime = Convert.ToDateTime(TextBox_StartTime.Text);
                model.EndTime = Convert.ToDateTime(TextBox_EndTime.Text);
                //model.UserName = GetUserName();

                model.MediumImage = ProductImages[0];
                model.SmallImage = ProductImages[1];

                model.OutLinkUrl = "";
                model.Status = 1;

                bll.Add(model);
                Response.Redirect("../SubmitSucc.aspx");
            }
            else
            {
                MessageBox.Show(this, "图片上传失败");
            }
        }

        private string GetUserName()
        {
            return "zhangfeng";
        }
    }
}

