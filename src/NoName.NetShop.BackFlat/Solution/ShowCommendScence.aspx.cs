using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Common;

namespace NoName.NetShop.BackFlat.Solution
{
    public partial class ShowCommendScence : System.Web.UI.Page
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
            NoName.NetShop.Solution.BLL.SuiteBll sbll = new NoName.NetShop.Solution.BLL.SuiteBll();
            gvList.DataSource = sbll.GetListArray(ScenceId);
            gvList.DataBind();
         }

        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int suiteId = Convert.ToInt32(e.CommandArgument);
            NoName.NetShop.Solution.BLL.SuiteBll sbll = new NoName.NetShop.Solution.BLL.SuiteBll();

            if (e.CommandName == "delete")
            {
                sbll.Delete(suiteId);
                this.BindList();
            }
        }


    }
}
