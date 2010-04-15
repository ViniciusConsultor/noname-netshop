using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.Utility;
using NoName.NetShop.MagicWorld.BLL;
using NoName.NetShop.CMS.Controler;
using System.Data;

namespace NoName.NetShop.BackFlat.MagicWorld.Rent
{
    public partial class List : System.Web.UI.Page
    {
        private RentProductBll bll = new RentProductBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData(1);
            }
        }

        private void BindData(int PageIndex) 
        {
            int RecordCount = 0;
            string ForeFlatRootUrl = System.Configuration.ConfigurationManager.AppSettings["foreFlatRootUrl"];
            ForeFlatRootUrl = ForeFlatRootUrl.EndsWith("/") ? ForeFlatRootUrl : ForeFlatRootUrl + "/";

            DataTable dt = bll.GetList(PageIndex, AspNetPager.PageSize, "","", out RecordCount);

            dt.Columns.Add("foreurl");
            foreach (DataRow row in dt.Rows)
                row["foreurl"] = String.Format("{0}magic/rent.aspx?pid={1}", ForeFlatRootUrl, row["rentid"]);        
            
            GridView1.DataSource = dt;
            GridView1.DataBind();

            AspNetPager.RecordCount = RecordCount;
        }


        protected void AspNetPager_PageChanged(object src, PageChangedEventArgs e)
        {
            AspNetPager.CurrentPageIndex = e.NewPageIndex;
            BindData(AspNetPager.CurrentPageIndex);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "d")
            {
                int RentID = Convert.ToInt32(e.CommandArgument);
                bll.Delete(RentID);
                PageControler.Publish(7, true);
            }
 
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    LinkButton DeleteButton = (LinkButton)e.Row.Cells[5].FindControl("Button_Delete");
                    string ScriptString = "javascript:return confirm('确认删除?')";
                    DeleteButton.Attributes.Add("onclick", ScriptString);
                }
            }
        }
    }
}
