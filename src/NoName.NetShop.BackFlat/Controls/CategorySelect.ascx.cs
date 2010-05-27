using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Product.BLL;
using System.Text;
using NoName.NetShop.Product.Model;

namespace NoName.NetShop.BackFlat.Controls
{
    public partial class CategorySelect : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public CategoryModel GetSelectedRegionInfo()
        {
            string regionPath = String.Empty;
            string country = Request.Form["category0"];
            string province = Request.Form["category1"];
            string city = Request.Form["category2"];
            string county = Request.Form["category3"];

            int curRegionId = 0;

            if (curRegionId == 0 && !String.IsNullOrEmpty(county))
                int.TryParse(county, out curRegionId);
            if (curRegionId == 0 && !String.IsNullOrEmpty(city))
                int.TryParse(city, out curRegionId);
            if (curRegionId == 0 && !String.IsNullOrEmpty(province))
                int.TryParse(province, out curRegionId);
            if (curRegionId == 0 && !String.IsNullOrEmpty(country))
                int.TryParse(country, out curRegionId);

            CategoryModel result = null;
            if (curRegionId > 0)
            {
                result = new CategoryModelBll().GetModel(curRegionId);
            }
            return result;
        }

        /// <summary>
        /// 用逗号分隔的regionid
        /// </summary>
        /// <param name="regionpath"></param>
        public void PresetRegionInfo(string regionpath)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type='text/javascript'>\n");
            sb.AppendFormat("var preset=[{0}];\n alert(preset); debugger; InitRegions();\n", regionpath.TrimEnd('/').Replace('/', ','));
            sb.Append("</script>");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myInitRegionInfo", sb.ToString());
        }
    }
}