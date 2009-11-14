using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using NoName.Utility;
using NoName.NetShop.Product.BLL;
using NoName.NetShop.Product.Model;
using NoName.NetShop.Common;

namespace NoName.NetShop.BackFlat.Category
{
    public partial class Add : System.Web.UI.Page
    {
        private CategoryModelBll bll = new CategoryModelBll();
        public int ParentID
        {
            get { if (ViewState["ParentID"] != null) return Convert.ToInt32(ViewState["ParentID"]); else return 0; }
            set { ViewState["ParentID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ParentID = Convert.ToInt32(Request.QueryString["parentid"]);
                BindData();
            }
        }

        private void BindData() 
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("code");
            dt.Columns.Add("status");

            foreach (int code in Enum.GetValues(typeof(CategoryStatus)))
            {
                DataRow row = dt.NewRow();
                row["code"] = code;
                row["status"] = Enum.GetName(typeof(CategoryStatus),code);
                dt.Rows.Add(row);
            }

            drpStatus.DataSource = dt;
            drpStatus.DataTextField = "status";
            drpStatus.DataValueField = "code";
            drpStatus.DataBind();
        }
        
        protected void Page_LoadComplete(object sender, EventArgs e)
		{
            //(Master.FindControl("lblTitle") as Label).Text = "��Ϣ���";
		}

		protected void btnAdd_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.txtCateName.Text == "")
            {
                strErr += "CateName����Ϊ�գ�\\n";
            }
            if (this.txtPriceRange.Text == "")
            {
                strErr += "PriceRange����Ϊ�գ�\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }


            string CateName = this.txtCateName.Text;
            int Status = Convert.ToInt32(drpStatus.SelectedValue);
            string PriceRange = this.txtPriceRange.Text;
            bool IsHide = this.chkIsHide.Checked;

            CategoryModel model = new CategoryModel();
            model.CateId = CommDataHelper.GetNewSerialNum("pd");
            model.CateName = CateName;
            model.Status = Status;
            model.PriceRange = PriceRange;
            model.IsHide = IsHide;
            model.ShowOrder = model.CateId;

            if (ParentID != 0)
            {
                CategoryModel ParentCategory = bll.GetModel(ParentID);

                model.ParentID = ParentID;
                model.CateLevel = ParentCategory.CateLevel + 1;
            }
            else
            {
                model.ParentID = 0;
                model.CateLevel = 1;
            }
            bll.Add(model);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type=\"text/javascript\">window.parent.location=window.parent.location+'?_=" + DateTime.Now.Ticks + "'</script>");

		}


    }
}
