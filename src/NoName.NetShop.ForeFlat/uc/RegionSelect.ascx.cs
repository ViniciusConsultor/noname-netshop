using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using NoName.NetShop.Member;

namespace NoName.NetShop.ForeFlat.UC
{
    public partial class RegionSelect : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public RegionInfo GetSelectedRegionInfo()
        {
            string regionPath = String.Empty;
            string country = Request.Form["country"];
            string province = Request.Form["province"];
            string city = Request.Form["city"];
            string county = Request.Form["county"];

            int curRegionId=0;

            if (curRegionId==0 && !String.IsNullOrEmpty(county))
                int.TryParse(county,out curRegionId);
            if (curRegionId == 0 && !String.IsNullOrEmpty(city))
                int.TryParse(city, out curRegionId);
            if (curRegionId == 0 && !String.IsNullOrEmpty(province))
                int.TryParse(province, out curRegionId);
            if (curRegionId == 0 && !String.IsNullOrEmpty(country))
                int.TryParse(country, out curRegionId);

            RegionInfo result = null;
            if (curRegionId >0)
            {
                result = new RegionInfo(curRegionId);
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
            sb.AppendFormat("var preset=[{0}];\nInitRegions();\n", regionpath.TrimEnd('/').Replace('/',','));
            sb.Append("</script>");
            Page.ClientScript.RegisterStartupScript(this.GetType(),"myInitRegionInfo",sb.ToString());
        }

    }
}