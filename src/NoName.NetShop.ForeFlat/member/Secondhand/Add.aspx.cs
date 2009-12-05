using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.Utility;
using NoName.NetShop.Common;
using NoName.NetShop.MagicWorld.BLL;
using NoName.NetShop.MagicWorld.Facade;
using NoName.NetShop.MagicWorld.Model;

namespace NoName.NetShop.ForeFlat.member.Secondhand
{
    public partial class Add : System.Web.UI.Page
    {
        private SecondhandProductBll bll = new SecondhandProductBll();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Add_Click(object sender, EventArgs e)
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
            if (FileUpload_ProductImage.FileName == "")
            {
                strErr += "图片为空！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }

            int SecondhandProductID = CommDataHelper.GetNewSerialNum("se");

            string[] ProductImages;

            if (SecondhandImageRule.SaveProductMainImage(SecondhandProductID, FileUpload_ProductImage.PostedFile, out ProductImages))
            {
                SecondhandProductModel model = new SecondhandProductModel();

                model.SecondhandProductID = SecondhandProductID;
                model.SecondhandProductName = TextBox_ProductName.Text;
                model.UserID = GetUserID();
                model.Keywords = TextBox_Keyword.Text;

                model.Brief = TextBox_Brief.Text;
                model.CateID = 0;
                model.CatePath = "";
                model.SmallImage = ProductImages[0];
                model.MediumImage = ProductImages[1];
                model.LargeImage = ProductImages[2];
                model.Price = Convert.ToDecimal(TextBox_Price.Text);
                model.Status = 1;
                model.Stock = Convert.ToInt32(TextBox_Count.Text);
                model.InsertTime = DateTime.Now;
                model.UpdateTime = DateTime.Now;
                model.SortValue = SecondhandProductID;

                bll.Add(model);

                MessageBox.Show(this, "添加成功！");
            }
            else
            {
                MessageBox.Show(this,"图片上传失败");
            }
        }

        private int GetUserID()
        {
            return 11;
        }
    }
}
