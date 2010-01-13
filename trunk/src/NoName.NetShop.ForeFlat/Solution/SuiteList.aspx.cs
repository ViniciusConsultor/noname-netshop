using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.Utility;
using NoName.NetShop.Solution.Model;
using NoName.NetShop.Solution.BLL;
using System.Data;

namespace NoName.NetShop.ForeFlat.Solution
{
    public partial class SuiteList : System.Web.UI.Page
    {
        public int ScenceID
        {
            get { if (ViewState["ScenceID"] != null) return Convert.ToInt32(ViewState["ScenceID"]); else return 0; }
            set { ViewState["ScenceID"] = value; }
        }
        private SuiteBll bll = new SuiteBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["s"])) ScenceID = Convert.ToInt32(Request.QueryString["s"]);
                BindSenceData();
                BindData(1);
            }
        }

        private void BindSenceData()
        {
            if (ScenceID != 0)
            {
                ScenceModel CurrentSence = new ScenceBll().GetModel(ScenceID);
                Literal_SenceName.Text = CurrentSence.ScenceName;
            }
            else
            {
                Literal_SenceName.Text = "所有套装";
            }

            Repeater_Sence.DataSource = new ScenceBll().GetModelList("sencetype = 2");
            Repeater_Sence.DataBind();
        }
           

        private void BindData(int PageIndex)
        {
            DataTable SuiteList = new DataTable();
            int RecordCount = 0;
            if (ScenceID != 0)
            {
                SuiteList = bll.GetList(PageIndex, AspNetPager.PageSize, " and scenceid = " + ScenceID,"", out RecordCount);
            }
            else
            {
                SuiteList = bll.GetList(PageIndex, AspNetPager.PageSize, "", "", out RecordCount);
            }

            Repeater_Suites.DataSource = SuiteList;
            Repeater_Suites.DataBind();
        }



        protected void AspNetPager_PageChanged(object src, PageChangedEventArgs e)
        {
            AspNetPager.CurrentPageIndex = e.NewPageIndex;
            BindData(AspNetPager.CurrentPageIndex);
        }
    }
}
