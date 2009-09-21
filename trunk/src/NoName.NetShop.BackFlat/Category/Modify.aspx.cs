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
using NoName.NetShop.Product.Model;
using NoName.NetShop.Product.BLL;
using NoName.Utility;

namespace NoName.NetShop.BackFlat.Category
{
    public partial class Modify : System.Web.UI.Page
    {       
        protected void Page_LoadComplete(object sender, EventArgs e)
		{
            //(Master.FindControl("lblTitle") as Label).Text = "信息修改";
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null || Request.Params["id"].Trim() != "")
				{
					string id = Request.Params["id"];
					//ShowInfo(CateId);
				}
			}
		}
			
	    private void ShowInfo(int CateId)
	    {
		    CategoryModelBll bll=new CategoryModelBll();
		    CategoryModel model=bll.GetModel(CateId);

		    this.lblCateId.Text=model.CateId.ToString();
		    this.txtCateName.Text=model.CateName;
		    this.txtCatePath.Text=model.CatePath;
		    this.txtStatus.Text=model.Status.ToString();
		    this.txtPriceRange.Text=model.PriceRange;
		    this.chkIsHide.Checked=model.IsHide;
		    this.txtCateLevel.Text=model.CateLevel.ToString();

	    }

		protected void btnAdd_Click(object sender, EventArgs e)
		{
        			
	        string strErr="";
	        if(this.txtCateName.Text =="")
	        {
		        strErr+="CateName不能为空！\\n";	
	        }
	        if(this.txtCatePath.Text =="")
	        {
		        strErr+="CatePath不能为空！\\n";	
	        }
	        if(!PageValidate.IsNumber(txtStatus.Text))
	        {
		        strErr+="Status不是数字！\\n";	
	        }
	        if(this.txtPriceRange.Text =="")
	        {
		        strErr+="PriceRange不能为空！\\n";	
	        }
	        if(!PageValidate.IsNumber(txtCateLevel.Text))
	        {
		        strErr+="CateLevel不是数字！\\n";	
	        }

	        if(strErr!="")
	        {
		        MessageBox.Show(this,strErr);
		        return;
	        }
	        string CateName=this.txtCateName.Text;
	        string CatePath=this.txtCatePath.Text;
	        int Status=int.Parse(this.txtStatus.Text);
	        string PriceRange=this.txtPriceRange.Text;
	        bool IsHide=this.chkIsHide.Checked;
	        int CateLevel=int.Parse(this.txtCateLevel.Text);


	        CategoryModel model=new CategoryModel();
	        model.CateName=CateName;
	        model.CatePath=CatePath;
	        model.Status=Status;
	        model.PriceRange=PriceRange;
	        model.IsHide=IsHide;
	        model.CateLevel=CateLevel;

	        CategoryModelBll bll=new CategoryModelBll();
	        bll.Update(model);

		}

    }
}
