using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using NoName.NetShop.Solution.BLL;
using NoName.NetShop.Solution.Model;

namespace NoName.NetShop.ForeFlat.Solution
{
    public partial class DIY : System.Web.UI.Page
    {
        private string CategoriesString
        {
            get { if (ViewState["CategoriesString"] != null) return ViewState["CategoriesString"].ToString(); else return String.Empty; }
            set { ViewState["CategoriesString"] = value; }
        }
        private ArrayList CategoryIDs
        {
            get { if (ViewState["CategoryIDs"] != null) return (ArrayList)ViewState["CategoryIDs"]; else return null; }
            set { ViewState["CategoryIDs"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoriesString = Request.QueryString["ids"];

                if (CategoriesString.Contains(","))
                    foreach (string c in CategoriesString.Split(','))
                        CategoryIDs.Add(int.Parse(c));
                else
                    CategoryIDs.Add(int.Parse(CategoriesString));


                BindData();
            }
        }

        private void BindCategoryData()
        {
            List<SolutionCategoryModel> Categories =  new SolutionCategoryBll().GetModelList("cateid in (" + CategoriesString + ")");


        }

        private void BindData()
        {
 
        }
    }
}
