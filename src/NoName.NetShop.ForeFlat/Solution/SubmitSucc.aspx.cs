using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Solution.Model;
using NoName.NetShop.Solution.BLL;

namespace NoName.NetShop.ForeFlat.Solution
{
    public partial class SubmitSucc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int DemandID = Convert.ToInt32(Request["o"]);
                SolutionDemandModel model = new SolutionDemandBll().GetModel(DemandID);

                if (model != null)
                {
                    orderid.InnerText = DemandID.ToString();
                }
                else
                {
                    throw new Exception("订单ID不存在");
                }
            }
        }
    }
}
