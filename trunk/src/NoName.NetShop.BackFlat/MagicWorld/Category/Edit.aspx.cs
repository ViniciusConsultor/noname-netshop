using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.MagicWorld.BLL;
using NoName.Utility;
using NoName.NetShop.MagicWorld.Model;
using NoName.NetShop.Common;

namespace NoName.NetShop.BackFlat.MagicWorld.Category
{
    public partial class Edit : System.Web.UI.Page
    {
        private int CategoryID
        {
            get { if (ViewState["CategoryID"] != null) return Convert.ToInt32(ViewState["CategoryID"]); else return -1; }
            set { ViewState["CategoryID"] = value; }
        }
        private MagicCategoryBll bll = new MagicCategoryBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["CategoryID"])) CategoryID = Convert.ToInt32(Request.QueryString["CategoryID"]);
                BindData();
            }
        }

        private void BindData()
        {
            MagicCategoryModel model = bll.GetModel(CategoryID);

            txtCateName.Text = model.CategoryName;
            chkIsHide.Checked = model.IsHide;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string ErrorMessage = String.Empty;
            if (String.IsNullOrEmpty(txtCateName.Text))
            {
                ErrorMessage += "分类名称不可为空";
            }
            if (!String.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(this, ErrorMessage);
                return;
            }

            MagicCategoryModel model = bll.GetModel(CategoryID);

            model.CategoryName = txtCateName.Text;
            model.IsHide = chkIsHide.Checked;

            bll.Update(model);

            MessageBox.Show(this, "修改成功！");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type=\"text/javascript\">window.parent.location=window.parent.location+'?_=" + DateTime.Now.Ticks + "'</script>");

        }
    }
}
