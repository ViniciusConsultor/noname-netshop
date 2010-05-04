using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Solution.BLL;
using NoName.NetShop.Solution.Model;
using NoName.NetShop.Common;

namespace NoName.NetShop.BackFlat.Solution
{
    public partial class DemandDetail : System.Web.UI.Page
    {
        private int DemandID
        {
            get { if (ViewState["DemandID"] != null) return Convert.ToInt32(ViewState["DemandID"]); else return -1; }
            set { ViewState["DemandID"] = value; }
        }
        private SolutionDemandBll bll = new SolutionDemandBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["id"])) DemandID = Convert.ToInt32(Request.QueryString["id"]);
                BindData();
            }
        }

        private void BindData()
        {
            SolutionDemandModel model = bll.GetModel(DemandID);

            Literal_Demand.Text = model.DemandDetail;
            Literal_Field.Text = model.FieldSituation;
            Literal_Effect.Text = model.EffectSituation;
            Literal_Budget.Text = model.Budget.ToString("0.00");
            Literal_Contact.Text = model.Contactor;
            Literal_Phone.Text = model.ContactPhone;
            Literal_Postcode.Text = model.Postcode;
            Literal_Region.Text = model.Region;
            Literal_Address.Text = model.Address;
            Literal_CreateTime.Text = model.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
            Literal1_Status.Text = Enum.GetName(typeof(SolutionDemandStatus),model.Status);

            if (model.FieldPhotoes.Contains(","))
            {
                foreach (string s in model.FieldPhotoes.Split(','))
                {
                    fieldImages.InnerHtml += String.Format("<img src=\"{0}\"/>",CommonImageUpload.GetCommonImageFullUrl(s));
                }
            }
            else
            {
                fieldImages.InnerHtml += String.Format("<img src=\"{0}\"/>", CommonImageUpload.GetCommonImageFullUrl(model.FieldPhotoes));
            }
        }
    }
}
