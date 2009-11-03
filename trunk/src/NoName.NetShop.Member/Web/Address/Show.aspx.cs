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
namespace NoName.NetShop.UserManager.Web.Address
{
    public partial class Show : System.Web.UI.Page
    {        
        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					string id = Request.Params["id"];
					//ShowInfo(AddressId);
				}
			}
		}
		
	private void ShowInfo(int AddressId)
	{
		NoName.NetShop.UserManager.BLL.Address bll=new NoName.NetShop.UserManager.BLL.Address();
		NoName.NetShop.UserManager.Model.Address model=bll.GetModel(AddressId);
		this.lblUserId.Text=model.UserId.ToString();
		this.lblProvince.Text=model.Province;
		this.lblCity.Text=model.City;
		this.lblAddressDetail.Text=model.AddressDetail;
		this.lblRecieverName.Text=model.RecieverName;
		this.lblMobile.Text=model.Mobile;
		this.lblTelephone.Text=model.Telephone;
		this.lblPostalcode.Text=model.Postalcode;
		this.chkIsDefault.Checked=model.IsDefault;
		this.lblInsertTime.Text=model.InsertTime.ToString();
		this.lblModifyTime.Text=model.ModifyTime.ToString();

	}


    }
}
