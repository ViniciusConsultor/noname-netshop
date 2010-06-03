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
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NoName.NetShop.BackFlat.Category
{
    public partial class Add : System.Web.UI.Page
    {
        private CategoryModelBll bll = new CategoryModelBll();
        private CategoryParaModelBll pBll = new CategoryParaModelBll();
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
            //(Master.FindControl("lblTitle") as Label).Text = "信息添加";
		}

		protected void btnAdd_Click(object sender, EventArgs e)
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
            if (this.txtSearchPriceRange.Text.Trim() != "")
            {
                string validateString = txtSearchPriceRange.Text.Trim().Replace("，", ",").Replace("～", "~");

                if (validateString.Contains(","))
                {
                    foreach (string s in validateString.Split(','))
                    {
                        int r1 = 0, r2 = 0;
                        if (!s.Contains("~") || !int.TryParse(s.Split('~')[0], out r1) || !int.TryParse(s.Split('~')[1], out r2))
                        {
                            strErr += "价格区间填写有误！\\n";
                            break;
                        }
                    }
                }
                else
                {
                    int r1 = 0, r2 = 0;
                    if (!validateString.Contains("~") || !int.TryParse(validateString.Split('~')[0], out r1) || !int.TryParse(validateString.Split('~')[1], out r2))
                    {
                        strErr += "价格区间填写有误！\\n";
                    }
                }
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }


            string CateName = this.txtCateName.Text;
            int Status = Convert.ToInt32(drpStatus.SelectedValue);
            //string PriceRange = this.txtPriceRange.Text;
            bool IsHide = this.chkIsHide.Checked;

            CategoryModel model = new CategoryModel();
            model.CateId = CommDataHelper.GetNewSerialNum("pd");
            model.CateName = CateName;
            model.Status = Status;
            model.IsHide = IsHide;
            model.ShowOrder = model.CateId;
            model.SearchPriceRange = txtSearchPriceRange.Text.Trim().EndsWith(",") ? txtSearchPriceRange.Text.Trim().Substring(0, txtSearchPriceRange.Text.Trim().Length - 1) : txtSearchPriceRange.Text.Trim();

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

            //判断父类是否存在属性，存在则继承父类属性
            //if (pBll.ExistsCategoryParameter(model.ParentID))
            //{
            //    List<CategoryParaModel> ParentParaList = pBll.GetModelList(" cateid="+model.ParentID+" ");
            //    foreach (CategoryParaModel pModel in ParentParaList)
            //    {
            //        pModel.ParaId = CommDataHelper.GetNewSerialNum("pd");
            //        pModel.CateId = model.CateId;
            //        pBll.Add(pModel);
            //    }
 
            //}

            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type=\"text/javascript\">window.parent.location=window.parent.location+'?_=" + DateTime.Now.Ticks + "'</script>");

		}


    }
}
