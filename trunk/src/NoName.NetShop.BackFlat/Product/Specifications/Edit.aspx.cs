using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Product.BLL;
using NoName.NetShop.Product.Model;
using NoName.Utility;

namespace NoName.NetShop.BackFlat.Product.Specifications
{
    public partial class Edit : System.Web.UI.Page
    {
        private int SpecificationID
        {
            get { if (ViewState["SpecificationID"] != null)return Convert.ToInt32(ViewState["SpecificationID"]); else return -1; }
            set { ViewState["SpecificationID"] = value; }
        }
        private ProductSpecificationBll bll = new ProductSpecificationBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["id"])) SpecificationID = Convert.ToInt32(Request.QueryString["id"]);
                BindData();
            }
        }

        private void BindData()
        {
            ProductSpecificationModel model = bll.GetModel(SpecificationID);

            TextBox_Title.Text = model.Title;
            TextBox_Content.Text = model.Content;

            DropDown_Type.DataSource = DataTableUtil.GetEnumKeyValue(typeof(SpecificationType));
            DropDown_Type.DataTextField = "key";
            DropDown_Type.DataValueField = "value";
            DropDown_Type.DataBind();

            DropDown_Type.SelectedValue = model.Type.ToString();
        }

        protected void Button_Edit_Click(object sender, EventArgs e)
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

            ProductSpecificationModel model = bll.GetModel(SpecificationID);

            model.Title = TextBox_Title.Text;
            model.Content = TextBox_Content.Text;
            model.Type = Convert.ToInt16(DropDown_Type.SelectedValue);

            bll.Update(model);

            Response.Redirect("List.aspx?type=" + DropDown_Type.SelectedValue);
        }

        protected void Button_Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx?type=" + DropDown_Type.SelectedValue);
        }
    }
}
