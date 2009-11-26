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

namespace NoName.NetShop.BackFlat.Category.Properity
{
    public partial class Add : System.Web.UI.Page
    {
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
                if (Request.QueryString["cid"] != null) CategoryID = Convert.ToInt32(Request.QueryString["cid"]);
            }
        }
             

        protected void Button_Add_Click(object sender, EventArgs e)
        {
            string ErrorMessage = String.Empty;
            if (TextBox_ParaName.Text == String.Empty)
            {
                ErrorMessage += "属性名称不可为空\n";
            }
            if (TextBox_ParaValue.Text == String.Empty)
            {
                ErrorMessage += "属性值不可为空\n";
            }

            if (!String.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(this,ErrorMessage);
                return;
            }

            CategoryParaModel model = new CategoryParaModel();

            model.ParaId = CommDataHelper.GetNewSerialNum("pd"); ;
            model.ParaName = TextBox_ParaName.Text;
            model.CateId = CategoryID;
            model.DefaultValue = "";
            model.ParaGroupId = 0;
            model.ParaType = 0;
            model.ParaValues = TextBox_ParaValue.Text.Replace("，",",");
            model.Status = Convert.ToInt32(DropDownList_Status.SelectedValue) ;

            bll.Add(model);
            MessageBox.Show(this,"添加成功！");
        }
    }
}