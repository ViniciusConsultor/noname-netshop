using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using NoName.NetShop.News.BLL;

namespace NoName.NetShop.BackFlat.Controls
{
    public partial class NewsCategorySelect : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public int GetSelectedCategoryInfo(out bool IsEnd)
        {
            string regionPath = String.Empty;
            string category1 = Request.Form["category1"];
            string category2 = Request.Form["category2"];
            string category3 = Request.Form["category3"];

            int curCategoryId = 0;
            if(category1.Contains(",")) category1 = category1.Split(',')[1];

            if (curCategoryId == 0 && !String.IsNullOrEmpty(category3))
                int.TryParse(category3.Split('-')[0], out curCategoryId);
            if (curCategoryId == 0 && !String.IsNullOrEmpty(category2))
                int.TryParse(category2.Split('-')[0], out curCategoryId);
            if (curCategoryId == 0 && !String.IsNullOrEmpty(category1))
                int.TryParse(category1.Split('-')[0], out curCategoryId);

            NewsCategoryModelBll bll = new NewsCategoryModelBll();

            IsEnd = false;
            if (curCategoryId > 0)
            {
                IsEnd = !bll.HasChild(curCategoryId);
                return curCategoryId;
            }
            return -1;
        }

        /// <summary>
        /// 用逗号分隔的regionid
        /// </summary>
        /// <param name="regionpath"></param>
        public void PresetCategoryInfo(string categoryPath)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type='text/javascript'>\n");
            sb.AppendFormat("var preset=[{0}];\nInitRegions();\n", categoryPath.TrimEnd('/').Replace('/', ','));
            sb.Append("</script>");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myInitRegionInfo", sb.ToString());
        }
    }
}