using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.PawnShop.BLL;
using NoName.NetShop.PawnShop.Model;
using NoName.NetShop.PawnShop.Facade;
using NoName.Utility;
using NoName.NetShop.Common;

namespace NoName.NetShop.ForeFlat.member.PawnShop
{
    public partial class Edit : System.Web.UI.Page
    {
        private int PawnProductID
        {
            get { if (ViewState["PawnProductID"] != null) return Convert.ToInt32(ViewState["PawnProductID"]); else return -1; }
            set { ViewState["PawnProductID"] = value; }
        }
        private PawnProductModelBll bll = new PawnProductModelBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["pid"])) PawnProductID = Convert.ToInt32(Request.QueryString["pid"]);
                BindData();
            }
        }

        private void BindData()
        {
            PawnProductModel model = bll.GetModel(PawnProductID);

            TextBox_ProductName.Text = model.PawnProductName;
            TextBox_Brief.Text = model.Brief;
            TextBox_Count.Text = model.Stock.ToString();
            TextBox_Keyword.Text = model.Keywords;
            Image_ProductImage.ImageUrl = PawnProductImageRule.GetMainImageUrl(model.MediumImage);
        }

        protected void Button_Edit_Click(object sender, EventArgs e)
        {
            string strErr = "";

            if (TextBox_ProductName.Text == "")
            {
                strErr += "拍品名称为空！\\n";
            }
            if (TextBox_Count.Text == "" || !PageValidate.IsNumber(TextBox_Count.Text))
            {
                strErr += "拍品数量为空或者不是数字！\\n";
            }
            if (TextBox_Keyword.Text == "")
            {
                strErr += "关键字为空！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }

            PawnProductModel model = bll.GetModel(PawnProductID);

            if (FileUpload_ProductImage.FileName != "")
            {
                string[] ProductImages;
                if (PawnProductImageRule.SaveProductMainImage(PawnProductID, FileUpload_ProductImage.PostedFile, out ProductImages))
                {
                    model.SmallImage = ProductImages[0];
                    model.MediumImage = ProductImages[1];
                    model.LargeImage = ProductImages[2];
                }
                else
                {
                    MessageBox.Show(this, "图片上传失败");
                    return;
                }
            }


            model.PawnProductName = TextBox_ProductName.Text;
            model.Brief = TextBox_Brief.Text;
            model.Keywords = TextBox_Keyword.Text;
            model.Stock = Convert.ToInt32(TextBox_Count.Text);
            model.ChangeTime = DateTime.Now;

            bll.Update(model);
            MessageBox.Show(this, "修改成功！");

        }
    }
}
