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

namespace NoName.NetShop.UserManager.Web.Favorite
{
    public partial class Modify : System.Web.UI.Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					string id = Request.Params["id"];
					ShowInfo();
				}
			}
		}
			
	private void ShowInfo()
	{
		NoName.NetShop.UserManager.BLL.Favorite bll=new NoName.NetShop.UserManager.BLL.Favorite();
		NoName.NetShop.UserManager.Model.Favorite model=bll.GetModel();
		this.txtUserId.Text=model.UserId.ToString();
		this.txtFavoriteId.Text=model.FavoriteId.ToString();
		this.txtFavoriteUrl.Text=model.FavoriteUrl;
		this.txtFavoriteName.Text=model.FavoriteName;
		this.txtInsertTime.Text=model.InsertTime.ToString();
		this.txtContentId.Text=model.ContentId.ToString();
		this.txtContentType.Text=model.ContentType.ToString();

	}

		public void btnUpdate_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtUserId.Text))
			{
				strErr+="UserId�������֣�\\n";	
			}
			if(!PageValidate.IsNumber(txtFavoriteId.Text))
			{
				strErr+="FavoriteId�������֣�\\n";	
			}
			if(this.txtFavoriteUrl.Text =="")
			{
				strErr+="FavoriteUrl����Ϊ�գ�\\n";	
			}
			if(this.txtFavoriteName.Text =="")
			{
				strErr+="FavoriteName����Ϊ�գ�\\n";	
			}
			if(!PageValidate.IsDateTime(txtInsertTime.Text))
			{
				strErr+="InsertTime����ʱ���ʽ��\\n";	
			}
			if(!PageValidate.IsNumber(txtContentId.Text))
			{
				strErr+="ContentId�������֣�\\n";	
			}
			if(!PageValidate.IsNumber(txtContentType.Text))
			{
				strErr+="ContentType�������֣�\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int UserId=int.Parse(this.txtUserId.Text);
			int FavoriteId=int.Parse(this.txtFavoriteId.Text);
			string FavoriteUrl=this.txtFavoriteUrl.Text;
			string FavoriteName=this.txtFavoriteName.Text;
			DateTime InsertTime=DateTime.Parse(this.txtInsertTime.Text);
			int ContentId=int.Parse(this.txtContentId.Text);
			int ContentType=int.Parse(this.txtContentType.Text);


			NoName.NetShop.UserManager.Model.Favorite model=new NoName.NetShop.UserManager.Model.Favorite();
			model.UserId=UserId;
			model.FavoriteId=FavoriteId;
			model.FavoriteUrl=FavoriteUrl;
			model.FavoriteName=FavoriteName;
			model.InsertTime=InsertTime;
			model.ContentId=ContentId;
			model.ContentType=ContentType;

			NoName.NetShop.UserManager.BLL.Favorite bll=new NoName.NetShop.UserManager.BLL.Favorite();
			bll.Update(model);

		}

    }
}
