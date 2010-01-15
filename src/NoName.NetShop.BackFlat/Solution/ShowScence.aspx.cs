using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using NoName.Utility;
using NoName.NetShop.Common;

namespace NoName.NetShop.BackFlat.Solution
{
    
    public partial class ShowScence : System.Web.UI.Page
    {
        private NoName.NetShop.Solution.BLL.ScenceBll sbll = new NoName.NetShop.Solution.BLL.ScenceBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int scenceId = 0;
                if (!int.TryParse(Request.QueryString["id"], out scenceId))
                {
                    scenceId = 0;
                }

                ShowInfo(scenceId);
            }
        }


        private void ShowInfo(int scenceId)
        {
            if (scenceId != 0)
            {
                NoName.NetShop.Solution.Model.ScenceModel model = sbll.GetModel(scenceId);
                this.lblScenceId.Text = model.ScenceId.ToString();
                this.txtRemark.Text = model.Remark;
                this.txtScenceName.Text = model.ScenceName;

                this.rblScenceType.SelectedIndex = model.SenceType;
                this.chkIsActive.Checked = model.IsActive;

                if (!String.IsNullOrEmpty(model.SenceImg))
                {
                    this.imgScence.Visible = true;
                    this.imgScence.ImageUrl = model.SenceImg;
                }
                else
                {
                    this.imgScence.Visible = false;
                }
            }
        }



        protected void btnAdd_Click(object sender, EventArgs e)
		{
			
			string strErr="";

			if(this.txtScenceName.Text =="")
			{
				strErr+="ScenceName²»ÄÜÎª¿Õ£¡\\n";	
			}
			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}


			int scenceId;
            if (!int.TryParse(lblScenceId.Text,out scenceId))
            {
                scenceId =0;
            }


            int SenceType = int.Parse(this.rblScenceType.SelectedValue);
			bool IsActive=this.chkIsActive.Checked;

			NoName.NetShop.Solution.Model.ScenceModel model = sbll.GetModel(scenceId);
            if (model == null)
            {
                model = new NoName.NetShop.Solution.Model.ScenceModel();
            }
            
			model.ScenceName=txtScenceName.Text.Trim();
			model.Remark=txtRemark.Text.Trim();
			model.SenceType=SenceType;
			model.IsActive=IsActive;
            string fullurl,shorturl,message;
            if (CommonImageUpload.Upload(this.fulImage,out fullurl,out shorturl,out message))
            {
                model.SenceImg = fullurl;
            }
            sbll.Save(model);
            Response.Redirect("ScenceList.aspx");
		}

    }
}
