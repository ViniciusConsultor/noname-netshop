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
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            DropDown_Type.DataSource = DataTableUtil.GetEnumKeyValue(typeof(SpecificationType));
            DropDown_Type.DataTextField = "key";
            DropDown_Type.DataValueField = "value";
            DropDown_Type.DataBind();
        }

        protected void Button_AddReturn_Click(object sender, EventArgs e)
        {
            Insert();
            Response.Redirect("List.aspx?type=" + DropDown_Type.SelectedValue);
        }
        protected void Button_AddGo_Click(object sender, EventArgs e)
        {
            Insert();
            TextBox_Title.Text = String.Empty;
            TextBox_Content.Text = String.Empty;
            MessageBox.Show(this, "添加成功！");
        }

        private void Insert()
        {
            string ErrorMessage = String.Empty;

            if (String.IsNullOrEmpty(TextBox_Title.Text))
            {
                ErrorMessage += "请输入标题！";
            }
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

            model.SpecificationID = CommDataHelper.GetNewSerialNum(AppType.Product);
            model.CategoryID = 0;
            model.CategoryPath = "";
            model.Content = TextBox_Content.Text;
            model.CreateTime = DateTime.Now;
            model.Title = TextBox_Title.Text;
            model.Type = Convert.ToInt16(DropDown_Type.SelectedValue);

            bll.Insert(model);
        }

        protected void Button_Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
