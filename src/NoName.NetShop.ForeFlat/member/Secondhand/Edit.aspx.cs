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

namespace NoName.NetShop.ForeFlat.member.Secondhand
{
    public partial class Edit : System.Web.UI.Page
    {
        private int SecondhandProductID
        {
            get { if (ViewState["SecondhandProductID"] != null) return Convert.ToInt32(ViewState["SecondhandProductID"]); else return -1; }
            set { ViewState["SecondhandProductID"] = value; }
        }
        private SecondhandProductBll bll = new SecondhandProductBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["pid"])) SecondhandProductID = Convert.ToInt32(Request.QueryString["pid"]);
                BindData();
            }
        }

        private void BindData()
        {
            SecondhandProductModel model = bll.GetModel(SecondhandProductID);

            TextBox_Brief.Text = model.Brief;
            TextBox_Count.Text = model.Stock.ToString();
            TextBox_Keyword.Text = model.Keywords;
            TextBox_Price.Text = model.Price.ToString();
            TextBox_ProductName.Text = model.SecondhandProductName;
            Image_ProductImage.ImageUrl = MagicWorldImageRule.GetMainImageUrl(model.MediumImage); 
        }


        protected void Button_Edit_Click(object sender, EventArgs e)
        {
            string strErr = "";

            if (TextBox_ProductName.Text == "")
            {
                strErr += "名称为空！\\n";
            }
            if (TextBox_Count.Text == "" || !PageValidate.IsNumber(TextBox_Count.Text))
            {
                strErr += "数量为空或者不是数字！\\n";
            }
            if (TextBox_Price.Text == "" || !PageValidate.IsDecimal(TextBox_Price.Text))
            {
                strErr += "价格为空或者不是数字！\\n";
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

            SecondhandProductModel model = bll.GetModel(SecondhandProductID);

            if (FileUpload_ProductImage.FileName != "")
            {
                string[] ProductImages;

                if (MagicWorldImageRule.SaveProductMainImage(SecondhandProductID, FileUpload_ProductImage.PostedFile, out ProductImages))
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

            model.SecondhandProductName = TextBox_ProductName.Text;
            model.Keywords = TextBox_Keyword.Text;

            model.Brief = TextBox_Brief.Text;
            model.Price = Convert.ToDecimal(TextBox_Price.Text);
            model.Stock = Convert.ToInt32(TextBox_Count.Text);
            model.UpdateTime = DateTime.Now;

            bll.Update(model);

            MessageBox.Show(this, "修改成功！");
        }
    }
}
