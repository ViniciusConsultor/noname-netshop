using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NoName.NetShop.MagicWorld.Model;
using NoName.NetShop.MagicWorld.BLL;

namespace NoName.NetShop.ForeFlat.Controls
{
    public partial class MagicWorldCategorySelect : System.Web.UI.UserControl
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
        private MagicCategoryBll bll = new MagicCategoryBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Intialize();
            }
        }

        private void Intialize()
        {
            MagicCategoryModel model = InitialCategoryID == -1 ? null : bll.GetModel(InitialCategoryID);
            BindCategory(0, 1, model == null ? null : model.CategoryPath);
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
                DataTable dt = bll.GetList(ParentID);
                if (dt.Rows.Count > 0)
                {
                    box.DataSource = dt;
                    box.DataTextField = "categoryname";
                    box.DataValueField = "categoryid";
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
                else
                {
                    switch (Level)
                    {
                        case 1:
                            ListBox1.Visible = false;
                            ListBox2.Visible = false;
                            ListBox3.Visible = false;
                            break;
                        case 2:
                            ListBox2.Visible = false;
                            ListBox3.Visible = false;
                            break;
                        case 3:
                            ListBox3.Visible = false;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        protected void ListBox1_SelectChanged(object sender, EventArgs e)
        {
            int CategoryID = Convert.ToInt32(ListBox1.SelectedValue);
            SelectedCategoryID = CategoryID;
            BindCategory(CategoryID, 2, null);
        }

        protected void ListBox2_SelectChanged(object sender, EventArgs e)
        {
            int CategoryID = Convert.ToInt32(ListBox2.SelectedValue);
            SelectedCategoryID = CategoryID;
            BindCategory(CategoryID, 3, null);
        }

        protected void ListBox3_SelectChanged(object sender, EventArgs e)
        {
            int CategoryID = Convert.ToInt32(ListBox3.SelectedValue);
            SelectedCategoryID = CategoryID;
        }
    }
}