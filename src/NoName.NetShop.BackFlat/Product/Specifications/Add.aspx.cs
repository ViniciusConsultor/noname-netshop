using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.Utility;
using NoName.NetShop.Product.Model;
using NoName.NetShop.Product.BLL;
using NoName.NetShop.Common;

namespace NoName.NetShop.BackFlat.Product.Specifications
{
    public partial class Add : System.Web.UI.Page
    {
        private ProductSpecificationBll bll = new ProductSpecificationBll();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Add_Click(object sender, EventArgs e)
        {
            string ErrorMessage = String.Empty;

            if (String.IsNullOrEmpty(TextBox_Content.Text))
            {
                ErrorMessage += "请输入内容！";
            }

            if (!String.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(this, ErrorMessage);
                return;
            }

            ProductSpecificationModel model = new ProductSpecificationModel();

            model.SpecificationID = CommDataHelper.GetNewSerialNum(AppType.Product); ;
            model.CategoryID = 0;
            model.CategoryPath = "";
            model.Content = TextBox_Content.Text;
            model.CreateTime = DateTime.Now;

            bll.Insert(model);

            MessageBox.Show(this, "添加成功！");
        }

        protected void Button_Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
