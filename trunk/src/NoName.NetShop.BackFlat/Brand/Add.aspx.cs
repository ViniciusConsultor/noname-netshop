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
using NoName.NetShop.Product.BLL;
using NoName.NetShop.Product.Model;

namespace NoName.NetShop.BackFlat.Brand
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDownList();
            }            
        }


        private void BindDropDownList()
        {
            CategoryModelBll CategoryBll = new CategoryModelBll();

            drpCategory.DataSource = CategoryBll.GetList("CateLevel = 1");
            drpCategory.DataTextField = "catename";
            drpCategory.DataValueField = "cateid";
            drpCategory.DataBind();
        }
        		
        protected void Page_LoadComplete(object sender, EventArgs e)
		{
            //(Master.FindControl("lblTitle") as Label).Text = "信息添加";
		}

		protected void btnAdd_Click(object sender, EventArgs e)
		{        			
	        string strErr="";
	        if(this.txtBrandName.Text =="")
	        {
		        strErr+="BrandName不能为空！\\n";	
	        }
	        if(this.fulBrandLogo.FileName =="")
	        {
		        strErr+="BrandLogo不能为空！\\n";	
	        }
	        if(this.txtBrief.Text =="")
	        {
		        strErr+="Brief不能为空！\\n";	
	        }

	        if(strErr!="")
	        {
		        MessageBox.Show(this,strErr);
		        return;
	        }
	        string BrandName=this.txtBrandName.Text;
	        int CateId=int.Parse(this.drpCategory.SelectedValue);
            //string CatePath=this.txtCatePath.Text;
            //string BrandLogo=this.txtBrandLogo.Text;
	        string Brief=this.txtBrief.Text;

	        BrandModel model=new BrandModel();
	        model.BrandName=BrandName;
	        model.CateId=CateId;
            //model.CatePath=CatePath;
            //model.BrandLogo=BrandLogo;
	        model.Brief=Brief;

	        BrandModelBll bll=new BrandModelBll();
	        bll.Add(model);

		}

    }
}
