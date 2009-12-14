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
using LTP.Common;
namespace NoName.NetShop.Web.FavoriteModel
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			(Master.FindControl("lblTitle") as Label).Text = "��Ϣ����";
		}
		protected void btnAdd_Click(object sender, EventArgs e)
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

	NoName.NetShop.Model.FavoriteModel model=new NoName.NetShop.Model.FavoriteModel();
	model.UserId=UserId;
	model.FavoriteId=FavoriteId;
	model.FavoriteUrl=FavoriteUrl;
	model.FavoriteName=FavoriteName;
	model.InsertTime=InsertTime;
	model.ContentId=ContentId;
	model.ContentType=ContentType;

	NoName.NetShop.BLL.FavoriteModelBll bll=new NoName.NetShop.BLL.FavoriteModelBll();
	bll.Add(model);

		}

    }
}