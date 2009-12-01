using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Product.BLL;
using System.Data;
using NoName.NetShop.Product.Model;

namespace NoName.NetShop.BackFlat.Controls
{
    public partial class CategoryListBox1 : System.Web.UI.UserControl
    {
        public int InitialCategoryID
        {
            get { if (ViewState["InitialCategoryID"] != null)return Convert.ToInt32(ViewState["InitialCategoryID"]); else return -1; }
            set { ViewState["InitialCategoryID"] = value; }
        }
        public int SelectedCategoryID
        {
            get { if (ViewState["SelectedCategoryID"] != null)return Convert.ToInt32(ViewState["SelectedCategoryID"]); else return -1; }
            set { ViewState["SelectedCategoryID"] = value; }
        }
        private CategoryModelBll bll = new CategoryModelBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Intialize();
            }
        }

        private void Intialize()
        {
            CategoryModel model = InitialCategoryID == -1 ? null : bll.GetModel(InitialCategoryID);
            BindCategory(0, 1, model == null ? null : model.CatePath);
        }

        private void BindCategory(int ParentID, int Level, string CategoryPath)
        {
            ListBox box = null;

            switch (Level)
            {
                case 1:
                    box = ListBox1;
                    break;
                case 2:
                    box = ListBox2;
                    break;
                case 3:
                    box = ListBox3;
                    break;
                default:
                    break;
            }

            if (box != null)
            {
                DataTable dt = bll.GetList("parentid=" + ParentID).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    box.DataSource = dt;
                    box.DataTextField = "catename";
                    box.DataValueField = "cateid";
                    box.DataBind();
                    box.Visible = true;
                    if (CategoryPath == null)
                    {
                        box.Items[0].Selected = true;
                    }
                    else
                    {
                        box.SelectedValue = CategoryPath.Split('/')[Level - 1];
                    }
                    SelectedCategoryID = Convert.ToInt32(box.SelectedValue);
                    BindCategory(Convert.ToInt32(box.SelectedValue), Level + 1, CategoryPath);
                }
            }
        }

        protected void ListBox1_SelectChanged(object sender, EventArgs e)
        {
            int CategoryID = Convert.ToInt32(ListBox1.SelectedValue);
            BindCategory(CategoryID, 2,null);
        }

        protected void ListBox2_SelectChanged(object sender, EventArgs e)
        {
            int CategoryID = Convert.ToInt32(ListBox2.SelectedValue);
            BindCategory(CategoryID, 3,null);
        }

        protected void ListBox3_SelectChanged(object sender, EventArgs e)
        {
            int CategoryID = Convert.ToInt32(ListBox3.SelectedValue);
            SelectedCategoryID = CategoryID;
        }
    }
}