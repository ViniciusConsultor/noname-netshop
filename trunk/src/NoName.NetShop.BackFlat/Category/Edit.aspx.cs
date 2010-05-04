using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Product.BLL;
using NoName.NetShop.Product.Model;
using System.Data;
using NoName.Utility;

namespace NoName.NetShop.BackFlat.Category
{
    public partial class Edit : System.Web.UI.Page
    {
        private int CategoryID
        {
            get { if (ViewState["CategoryID"] != null) return Convert.ToInt32(ViewState["CategoryID"]); else return 0; }
            set { ViewState["CategoryID"] = value; }
        }
        private CategoryModelBll bll = new CategoryModelBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["CategoryID"])) CategoryID = Convert.ToInt32(Request.QueryString["CategoryID"]);
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            CategoryModel model = bll.GetModel(CategoryID);

            txtCateName.Text = model.CateName;
            drpStatus.SelectedValue = model.Status.ToString();
            //txtPriceRange.Text = model.PriceRange;
            chkIsHide.Checked = model.IsHide;
            //CategorySelect1.InitialCategory = model.CateId;
            txtSearchPriceRange.Text = model.SearchPriceRange;


            DataTable dt = new DataTable();

            dt.Columns.Add("code");
            dt.Columns.Add("status");

            foreach (int code in Enum.GetValues(typeof(CategoryStatus)))
            {
                DataRow row = dt.NewRow();
                row["code"] = code;
                row["status"] = Enum.GetName(typeof(CategoryStatus), code);
                dt.Rows.Add(row);
            }

            drpStatus.DataSource = dt;
            drpStatus.DataTextField = "status";
            drpStatus.DataValueField = "code";
            drpStatus.DataBind();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.txtCateName.Text.Trim() == "")
            {
                strErr += "分类名称不能为空！\\n";
            }
            if (this.txtSearchPriceRange.Text.Trim() == "")
            {
                strErr += "分类搜索价格区间不能为空！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }

            CategoryModel model = bll.GetModel(CategoryID);

            model.CateName = txtCateName.Text;
            model.Status = int.Parse(drpStatus.SelectedValue);
            //model.PriceRange = txtPriceRange.Text;
            model.IsHide = chkIsHide.Checked;
            model.SearchPriceRange = txtSearchPriceRange.Text;

            bll.Update(model);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type=\"text/javascript\">window.parent.location=window.parent.location+'?_=" + DateTime.Now.Ticks + "'</script>");
        }

        private void SaveData()
        { 
        }
    }
}
