using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Product.BLL;
using System.Data;
using NoName.Utility;

namespace NoName.NetShop.BackFlat.Category.Properity
{
    public partial class List : System.Web.UI.Page
    {
        private CategoryModelBll cBll = new CategoryModelBll();
        private CategoryParaModelBll bll = new CategoryParaModelBll();
        private int CurrentCategoryID
        {
            get { if (ViewState["CurrentCategoryID"] != null) return Convert.ToInt32(ViewState["CurrentCategoryID"]); else return -1; }
            set { ViewState["CurrentCategoryID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["cid"]))
                {
                    CurrentCategoryID = Convert.ToInt32(Request.QueryString["cid"]);
                }
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
            DataTable dt = bll.GetList("cateid=" + (CategoryID==-1?0:CategoryID)).Tables[0];
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                Label_Informer.Text = String.Empty;
            }
            else
            {
                GridView1.DataSource = new DataTable();
                GridView1.DataBind();
                Label_Informer.Text = "该分类暂无属性";
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


        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            int CategoryID = Convert.ToInt32(TreeView1.SelectedValue);
            BindData(CategoryID);
        }

        protected void Button_AddPara_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TreeView1.SelectedValue))
            {
                int CategoryID = Convert.ToInt32(TreeView1.SelectedValue);
                Response.Redirect("add.aspx?cid="+CategoryID);
            }
            else
            {
                MessageBox.Show(this,"请选择分类");
            }
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "d")
            {
                int ParaID = Convert.ToInt32(e.CommandArgument);
                bll.Delete(ParaID);
                int CategoryID = Convert.ToInt32(TreeView1.SelectedValue);
                BindData(CategoryID);
                MessageBox.Show(this, "删除成功！");
            }
        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //如果是绑定数据行 
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    ((LinkButton)e.Row.Cells[5].FindControl("Button_Delete")).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：\"" + e.Row.Cells[1].Text.Trim() + "\"吗?')");
                }
            }
        }
    }
}
