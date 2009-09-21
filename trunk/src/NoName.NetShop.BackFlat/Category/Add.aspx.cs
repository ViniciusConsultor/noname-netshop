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
        private int SelectedParentCategoryID
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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

            DataTable cateList = bll.GetList("catelevel = 1").Tables[0];
            DataTable cateListNew = new DataTable();
            cateListNew.Columns.Add("catename");
            cateListNew.Columns.Add("cateid");

            DataRow fRow = cateListNew.NewRow();
            fRow["catename"] = "不从属父类";
            fRow["cateid"] = 0;
            cateListNew.Rows.Add(fRow);

            foreach(DataRow row in cateList.Rows)
            {
                DataRow newRow = cateListNew.NewRow();
                newRow["catename"] = row["catename"];
                newRow["cateid"] = row["cateid"];
                cateListNew.Rows.Add(newRow);
            }

            lbxCategory1.DataSource = cateListNew;
            lbxCategory1.DataTextField = "catename";
            lbxCategory1.DataValueField = "cateid";
            lbxCategory1.DataBind();
            lbxCategory1.Items[0].Selected = true;
            SelectedParentCategoryID = 0;
        }
        
        protected void Page_LoadComplete(object sender, EventArgs e)
		{
            //(Master.FindControl("lblTitle") as Label).Text = "信息添加";
		}

		protected void btnAdd_Click(object sender, EventArgs e)
		{			
	        string strErr="";
	        if(this.txtCateName.Text =="")
	        {
		        strErr+="CateName不能为空！\\n";	
	        }
	        if(this.txtPriceRange.Text =="")
	        {
		        strErr+="PriceRange不能为空！\\n";	
	        }

	        if(strErr!="")
	        {
		        MessageBox.Show(this,strErr);
		        return;
	        }


	        string CateName=this.txtCateName.Text;
            int Status = Convert.ToInt32(drpStatus.SelectedValue);
	        string PriceRange=this.txtPriceRange.Text;
            bool IsHide = this.chkIsHide.Checked;

            CategoryModel model = new CategoryModel();
            model.CateId = CommDataHelper.GetNewSerialNum("pd");
            model.CateName = CateName;
            model.Status = Status;
            model.PriceRange = PriceRange;
            model.IsHide = IsHide;

            if (SelectedParentCategoryID != 0)
            {
                CategoryModel ParentCategory = bll.GetModel(SelectedParentCategoryID);

                model.CateLevel = ParentCategory.CateLevel + 1;
                model.CatePath = ParentCategory.CatePath + "/" + model.CateId;
            }
            else
            {
                model.CateLevel = 1;
                model.CatePath = model.CateId.ToString();
            }
            bll.Add(model);

		}

        protected void lbxCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ParentCategoryID = Convert.ToInt32(lbxCategory1.SelectedValue);
            SelectedParentCategoryID = ParentCategoryID;

            if (ParentCategoryID != 0)
            {
                DataTable cateList = bll.GetList("parentid = " + ParentCategoryID).Tables[0];

                if (cateList.Rows.Count > 0)
                {
                    lbxCategory2.DataSource = cateList;
                    lbxCategory2.DataTextField = "catename";
                    lbxCategory2.DataValueField = "cateid";
                    lbxCategory2.DataBind();

                    lbxCategory2.Visible = true;
                }
            }
        }

    }
}
