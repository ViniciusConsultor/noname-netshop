using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Member;

namespace NoName.NetShop.BackFlat.Order
{
    public partial class ScoreTypeSetting : System.Web.UI.Page
    {
        private ScoreRuleBll sbll = new ScoreRuleBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }
        }

        private void BindList()
        {
            gvList.DataSource = sbll.GetModelList(String.Empty);
            gvList.DataBind();
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            ScoreRuleModel smodel = new ScoreRuleModel();
            smodel.ActionType = NoName.Utility.input.Filter(txtActionType.Text.Trim());
            smodel.Score = int.Parse(txtScore.Text.Trim());
            smodel.Remark = NoName.Utility.input.Filter(txtRemark.Text.Trim());
            sbll.Save(smodel);
            txtRemark.Text = "";
            txtActionType.Text = "";
            txtScore.Text = "";
            BindList();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvList.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    string actiontype  = gvList.DataKeys[row.RowIndex].Value.ToString();
                    ScoreRuleModel model = sbll.GetModel(actiontype);
                    model.Remark = ((TextBox)row.FindControl("txtRemark")).Text.Trim();
                    model.Score = int.Parse(((TextBox)row.FindControl("txtScore")).Text);
                    sbll.Save(model);
                }
            }
            BindList();
        }

        protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string actiontype = gvList.DataKeys[e.RowIndex].Value.ToString();
            sbll.Delete(actiontype);
            BindList();
        }

    }
}
