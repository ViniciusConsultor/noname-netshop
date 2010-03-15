using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Product.BLL;
using NoName.NetShop.Product.Model;
using NoName.Utility;

namespace NoName.NetShop.BackFlat.Category.Properity
{
    public partial class Edit : System.Web.UI.Page
    {
        private int CategoryParaID
        {
            get { if (ViewState["CategoryParaID"] != null) return Convert.ToInt32(ViewState["CategoryParaID"]); else return -1; }
            set { ViewState["CategoryParaID"] = value; }
        }
        private int CategoryID
        {
            get { if (ViewState["CategoryID"] != null) return Convert.ToInt32(ViewState["CategoryID"]); else return -1; }
            set { ViewState["CategoryID"] = value; }
        }
        private CategoryParaModelBll bll = new CategoryParaModelBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["pid"])) CategoryParaID = Convert.ToInt32(Request.QueryString["pid"]);
                if (!String.IsNullOrEmpty(Request.QueryString["cid"])) CategoryID = Convert.ToInt32(Request.QueryString["cid"]);
                BindData();
            }
        }

        private void BindData() 
        {
            CategoryParaModel model = bll.GetModel(CategoryParaID,CategoryID);

            TextBox_ParaName.Text=model.ParaName;
            TextBox_ParaValue.Text=model.ParaValues;
            DropDownList_Status.SelectedValue = model.Status.ToString();

            DropDown_ParaType.DataSource = DataTableUtil.GetEnumKeyValue(typeof(CategoryParameterType));
            DropDown_ParaType.DataTextField = "key";
            DropDown_ParaType.DataValueField = "value";
            DropDown_ParaType.DataBind();
        }

        protected void Button_Eidt_Click(object sender, EventArgs e)
        {
            string ErrorMessage = String.Empty;
            if (TextBox_ParaName.Text == String.Empty)
            {
                ErrorMessage += "属性名称不可为空\\n";
            }
            if (TextBox_ParaValue.Text == String.Empty)
            {
                ErrorMessage += "属性值不可为空\\n";
            }

            if (!String.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(this, ErrorMessage);
                return;
            }

            CategoryParaModel model = bll.GetModel(CategoryParaID,CategoryID);

            model.ParaName = TextBox_ParaName.Text;
            model.ParaValues = TextBox_ParaValue.Text.Replace("，", ",");
            model.Status = Convert.ToInt32(DropDownList_Status.SelectedValue);
            model.ParaType = Convert.ToInt32(DropDown_ParaType.SelectedValue);

            bll.Update(model);
            MessageBox.Show(this,"修改成功！");
        }
    }
}
