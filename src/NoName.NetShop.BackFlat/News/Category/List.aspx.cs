using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using NoName.NetShop.News.BLL;
using NoName.NetShop.News.Model;
using NoName.Utility;

namespace NoName.NetShop.BackFlat.News.Category
{
    public partial class List : System.Web.UI.Page
    {
        private NewsCategoryModelBll bll = new NewsCategoryModelBll();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateNodes(TreeView1.Nodes, 0);
                BindParentCategoryData();
            }
        }

        public void PopulateNodes(TreeNodeCollection nodes, int ParentID)
        {
            DataTable dt = bll.GetList(ParentID);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode tn = new TreeNode();
                tn.Text = dt.Rows[i]["catename"].ToString();
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
            int SelectedID = Convert.ToInt32(TreeView1.SelectedValue);

            NewsCategoryModel model = bll.GetModel(SelectedID);

            TextBox_CategoryName.Text = model.CateName;
            
            DropDownList_IsHide.SelectedValue = model.IsHide ? "1" : "0";

            NewsCategoryModel parentModel = bll.GetModel(model.ParentID);

            Label_ParentCategory.Text = parentModel == null ? "无从属父类" : parentModel.CateName;
        }

        private void BindParentCategoryData()
        {
            DataTable dt = bll.GetList(0);
        }


        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TreeView1.SelectedValue))
            {
                int SelectedID = Convert.ToInt32(TreeView1.SelectedValue);

                NewsCategoryModel model = bll.GetModel(SelectedID);

                model.CateName = TextBox_CategoryName.Text;
                model.IsHide = DropDownList_IsHide.SelectedValue == "1" ? true : false;

                bll.Update(model);

                MessageBox.Show(this, "修改成功！");
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                MessageBox.Show(this, "请选择分类！");
            }
        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TreeView1.SelectedValue))
            {
                int SelectedID = Convert.ToInt32(TreeView1.SelectedValue);
                bll.Delete(SelectedID);
                Response.Redirect(Request.RawUrl);
            }
        }

    }
}
