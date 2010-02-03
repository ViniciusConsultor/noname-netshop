using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NoName.NetShop.Product.BLL;
using NoName.Utility;
using System.Web.UI.HtmlControls;
using System.Configuration;

namespace NoName.NetShop.BackFlat.Category
{
    public partial class List : System.Web.UI.Page
    {
        private CategoryModelBll bll = new CategoryModelBll();
        private string ForeFlatRootUrl = ConfigurationManager.AppSettings["foreFlatRootUrl"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategoryList();
            }
        }

        private void BindCategoryList()
        {
            TreeView1.Nodes.Clear();
            PopulateNodes(TreeView1.Nodes, 0);
            TreeView1.ExpandAll();
        }

        private void PopulateNodes(TreeNodeCollection nodes, int ParentID)
        {
            DataTable dt = bll.GetList("parentid=" + ParentID + " order by showorder").Tables[0] ;
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode tn = new TreeNode();
                tn.Text = String.Format("{0}({1})",dt.Rows[i]["catename"].ToString(),dt.Rows[i]["cateid"].ToString());
                tn.Value = dt.Rows[i]["cateid"].ToString();
                tn.ImageToolTip = dt.Rows[i]["catename"].ToString();
                tn.ToolTip = dt.Rows[i]["catename"].ToString();
                tn.SelectAction = TreeNodeSelectAction.Select;
                nodes.Add(tn);

                PopulateNodes(tn.ChildNodes, Convert.ToInt32(dt.Rows[i]["cateid"]));
            }
        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
        }

        protected void Button_MoveUp_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TreeView1.SelectedValue))
            {
                TreeNode TheNode = TreeView1.SelectedNode;
                TreeNodeCollection TheNodeBrothers = TheNode.Parent == null ? TreeView1.Nodes : TheNode.Parent.ChildNodes;

                int Position = TheNodeBrothers.IndexOf(TheNode);

                int OriginCateID = Convert.ToInt32(TheNode.Value);
                int SwitchCateID = Position == 0 ? Convert.ToInt32(TheNodeBrothers[TheNodeBrothers.Count - 1].Value) : Convert.ToInt32(TheNodeBrothers[Position - 1].Value);

                bll.SwitchOrder(OriginCateID, SwitchCateID);
                BindCategoryList();
            }
            else
            {
                MessageBox.Show(this, "请选择分类");
            }
        }

        protected void Button_MoveDown_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TreeView1.SelectedValue))
            {
                TreeNode TheNode = TreeView1.SelectedNode;
                TreeNodeCollection TheNodeBrothers = TheNode.Parent == null ? TreeView1.Nodes : TheNode.Parent.ChildNodes;

                int Position = TheNodeBrothers.IndexOf(TheNode);

                int OriginCateID = Convert.ToInt32(TheNode.Value);
                int SwitchCateID = (Position == TheNodeBrothers.Count - 1) ? 0 : Convert.ToInt32(TheNodeBrothers[Position + 1].Value);

                bll.SwitchOrder(OriginCateID, SwitchCateID);
                BindCategoryList();
            }
            else
            {
                MessageBox.Show(this,"请选择分类");
            }
        }

        protected void Button_New_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TreeView1.SelectedValue))
            {
                string js = "<script type=\"text/javascript\">document.getElementById('IFrame_Edit').src='Add.aspx?parentid=" + TreeView1.SelectedValue + "';</script>";
                ClientScript.RegisterStartupScript(this.GetType(), null, js); 
            }
            else
            {
                string js = "<script type=\"text/javascript\">document.getElementById('IFrame_Edit').src='Add.aspx?parentid=0';</script>";
                ClientScript.RegisterStartupScript(this.GetType(), null, js); 
            }
        }

        protected void Button_Edit_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TreeView1.SelectedValue))
            {
                string js = "<script type=\"text/javascript\">document.getElementById('IFrame_Edit').src='Edit.aspx?CategoryID=" + TreeView1.SelectedValue + "';</script>";
                ClientScript.RegisterStartupScript(this.GetType(),null,js);
            }
            else
            {
                MessageBox.Show(this, "请选择分类");
            }
        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TreeView1.SelectedValue))
            {
                //判断该分类下是否有商品，如果有，不允许删除
                //判断该分类是否已经关联了品牌，如果关联，不允许删除
                //判断该分类是否已经有产品属性，如果有，不允许删除

                int CateID = Convert.ToInt32(TreeView1.SelectedValue);

                if (new ProductModelBll().CategoryExistsProduct(CateID))
                {
                    MessageBox.Show(this, "该分类下存在商品，禁止删除！");
                }
                //else if (true)
                //{
                //    MessageBox.Show(this, "该分类下已经关联了品牌，禁止删除！");
                //}
                //else if (true)
                //{
                //    MessageBox.Show(this, "该分类下定义了产品属性，禁止删除！");
                //}
                else
                {
                    //如果有子类，删除子类
                    //判断，如果关联了品牌，先删除品牌关系
                    //判断，如果有产品属性，先删除产品属性

                    foreach (DataRow row in bll.GetOffsprings(CateID).Rows)
                    {
                        new BrandCategoryRelationBll().Delete(CateID);
                        new CategoryParaModelBll().DeleteCategoryPara(Convert.ToInt32(row["cateid"]));
                    }

                    bll.DeleteOffsprings(Convert.ToInt32(TreeView1.SelectedValue));
                    BindCategoryList();
                }
            }
            else
            {
                MessageBox.Show(this, "请选择分类");
            }
        }

        protected void Button_PreView_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TreeView1.SelectedValue))
            {
                string url = String.Format("{0}list-{1}.html", ForeFlatRootUrl, TreeView1.SelectedValue);
                MessageBox.ResponseScript(this, "window.open('" + url + "')");
            }
            else
            {
                MessageBox.Show(this, "请选择分类");
            }
        }
    }
}
