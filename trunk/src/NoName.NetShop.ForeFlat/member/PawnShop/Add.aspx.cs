using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.PawnShop.Model;
using NoName.NetShop.PawnShop.BLL;
using NoName.Utility;
using NoName.NetShop.Common;
using NoName.NetShop.PawnShop.Facade;

namespace NoName.NetShop.ForeFlat.member.PawnShop
{
    public partial class Add : System.Web.UI.Page
    {
        private PawnProductModelBll bll = new PawnProductModelBll();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Add_Click(object sender, EventArgs e)
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
            if (FileUpload_ProductImage.FileName == "")
            {
                strErr += "图片为空！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }

            int PawnProductID = CommDataHelper.GetNewSerialNum("pw");

            string[] ProductImages;
            if (PawnProductImageRule.SaveProductMainImage(PawnProductID, FileUpload_ProductImage.PostedFile, out ProductImages))
            {
                PawnProductModel model = new PawnProductModel();

                model.PawnProductID = PawnProductID;
                model.PawnProductName = TextBox_ProductName.Text;
                model.UserID = GetUserID();
                model.Brief = TextBox_Brief.Text;
                model.CateID = 0;
                model.CatePath = "";
                model.Keywords = TextBox_Keyword.Text;
                model.SmallImage = ProductImages[0];
                model.MediumImage = ProductImages[1];
                model.LargeImage = ProductImages[2];
                model.PawnPrice = 0;
                model.SortValue = PawnProductID;
                model.Status = 1;
                model.Stock = Convert.ToInt32(TextBox_Count.Text);
                model.ChangeTime = DateTime.Now;
                model.InsertTime = DateTime.Now;

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
