using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Product.BLL;
using System.Data;
using NoName.Utility;

namespace NoName.NetShop.BackFlat.Brand.Relation
{
    public partial class List : System.Web.UI.Page
    {
        private CategoryModelBll cBll = new CategoryModelBll();
        private BrandCategoryRelationBll bll = new BrandCategoryRelationBll();
        private int CurrentCategoryID
        {
            get { if (ViewState["CurrentCategoryID"] != null) return Convert.ToInt32(ViewState["CurrentCategoryID"]); else return -1; }
            set { ViewState["CurrentCategoryID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["cid"])) CurrentCategoryID = Convert.ToInt32(Request.QueryString["cid"]);
                BindCategoryList();
                BindData(CurrentCategoryID);
            }
        }
        private void BindCategoryList()
        {
            TreeView1.Nodes.Clear();
            PopulateNodes(TreeView1.Nodes, 0);
            TreeView1.ExpandAll();
        }

        private void BindData(int CategoryID)
        {
            if (CategoryID != -1)
            {
                DataTable dt = bll.GetCategoryBrandList(CategoryID);
                if (dt.Rows.Count > 0)
                {
                    Repeater_BrandList.DataSource = dt;
                    Repeater_BrandList.DataBind();
                    Label_Informer.Text = String.Empty;
                }
                else
                {
                    Repeater_BrandList.DataSource = new DataTable();
                    Repeater_BrandList.DataBind();
                    Label_Informer.Text = "该分类下暂无关联品牌";
                }
            }
        }

        private void PopulateNodes(TreeNodeCollection nodes, int ParentID)
        {
            DataTable dt = cBll.GetList("parentid=" + ParentID + " order by showorder").Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode tn = new TreeNode();
                tn.Text = dt.Rows[i]["catename"].ToString();
                tn.Value = dt.Rows[i]["cateid"].ToString();
                tn.ImageToolTip = dt.Rows[i]["catename"].ToString();
                tn.ToolTip = dt.Rows[i]["catename"].ToString();
                tn.SelectAction = TreeNodeSelectAction.Select;
                if (CurrentCategoryID != -1 && CurrentCategoryID == Convert.ToInt32(tn.Value))
                {
                    tn.Selected = true;
                    //Response.Write(tn.Selected);
                }
                nodes.Add(tn);

                PopulateNodes(tn.ChildNodes, Convert.ToInt32(dt.Rows[i]["cateid"]));
            }
        }

        protected void Button_AddBrand_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TreeView1.SelectedValue))
            {
                int CategoryID = Convert.ToInt32(TreeView1.SelectedValue);
                Response.Redirect("add.aspx?cid=" + CategoryID);
            }
            else
            {
                MessageBox.Show(this, "请选择分类");
            }
        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            int CategoryID = Convert.ToInt32(TreeView1.SelectedValue);
            BindData(CategoryID);
        }

        protected void Repeater_BrandList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "d")
            {
                int CategoryID = Convert.ToInt32(TreeView1.SelectedValue);
                int BrandID = Convert.ToInt32(e.CommandArgument);
                DeleteRelation(CategoryID, BrandID);
                BindData(CategoryID);
            }
        }

        private void DeleteRelation(int CateID,int BrandID)
        {
            bll.Delete(BrandID, CateID);

            DataTable sonCates=new CategoryModelBll().GetList(" parentid="+CateID).Tables[0];
            if (sonCates.Rows.Count > 0)
            {
                foreach (DataRow row in sonCates.Rows) DeleteRelation(Convert.ToInt32(row["cateid"]), BrandID);
            }
        }
    }
}
