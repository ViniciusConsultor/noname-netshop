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

namespace NoName.NetShop.BackFlat.Controls
{
    public partial class NewsCategoryTree : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateNodes(TreeView1.Nodes, 0);
            }
        }


        public void PopulateNodes(TreeNodeCollection nodes, int ParentID)
        {
            NewsCategoryModelBll bll = new NewsCategoryModelBll();

            DataTable dt = bll.GetList(ParentID);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode tn = new TreeNode();
                tn.Text = dt.Rows[i]["catename"].ToString();
                tn.Value = dt.Rows[i]["cateid"].ToString();
                tn.ImageToolTip = dt.Rows[i]["catename"].ToString();
                tn.ToolTip = dt.Rows[i]["catename"].ToString();
                tn.Target = "NewsCategoryContent";
                tn.NavigateUrl = "/news/category/Edit.aspx?cateid=" + dt.Rows[i]["cateid"].ToString();
                nodes.Add(tn);

                PopulateNodes(tn.ChildNodes, Convert.ToInt32(dt.Rows[i]["cateid"]));
            }
        } 
    }
}