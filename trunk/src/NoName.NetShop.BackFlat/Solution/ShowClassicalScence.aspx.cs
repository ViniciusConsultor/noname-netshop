using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoName.NetShop.BackFlat.Solution
{
    public partial class ShowClassicalScence : System.Web.UI.Page
    {
        private int ScenceId
        {
            get
            {
                if (ViewState["scenceId"] == null)
                    ViewState["scenceId"] = 0;
                return (int)ViewState["scenceId"];
            }
            set
            {
                ViewState["scenceId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ScenceId = int.Parse(Request.QueryString["id"]);
                BindList();
            }
        }

        private void BindList()
        {
            NoName.NetShop.Solution.BLL.SolutionCategoryBll sbll = new NoName.NetShop.Solution.BLL.SolutionCategoryBll();
            gvList.DataSource = sbll.GetModelList(ScenceId);
            gvList.DataBind();
        }

        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int cateId = Convert.ToInt32(e.CommandArgument);
            NoName.NetShop.Solution.BLL.SolutionCategoryBll sbll = new NoName.NetShop.Solution.BLL.SolutionCategoryBll();

            if (e.CommandName == "delete")
            {
                sbll.Delete(ScenceId, cateId);
                this.BindList();
            }
        }

        protected void btnAddNewCateId_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowClassicalDetail.aspx?cid=" + txtCateId.Text +"&sid=" + ScenceId);
        }

    }
}
