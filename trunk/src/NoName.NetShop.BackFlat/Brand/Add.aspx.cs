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
using NoName.NetShop.Common;
using System.IO;

namespace NoName.NetShop.BackFlat.Brand
{
    public partial class Add : System.Web.UI.Page
    {
        private BrandModelBll bll = new BrandModelBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }            
        }



        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.txtBrandName.Text == "")
            {
                strErr += "BrandName不能为空！\\n";
            }
            if (this.fulBrandLogo.FileName == "")
            {
                strErr += "BrandLogo不能为空！\\n";
            }
            if (this.txtBrief.Text == "")
            {
                strErr += "Brief不能为空！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }

            if (bll.Exists(txtBrandName.Text)) 
            {
                MessageBox.Show(this,"该品牌已存在");
                return;
            }


            BrandModel model = new BrandModel();

            model.BrandId = CommDataHelper.GetNewSerialNum("pd");
            model.BrandName = txtBrandName.Text;
            model.BrandLogo = UploadBrandLogo(model.BrandId, fulBrandLogo);
            model.Brief = txtBrief.Text;
            model.ShowOrder = model.BrandId;

            bll.Add(model);
            Response.Redirect("List.aspx");
        }

        private string UploadBrandLogo(int BrandID,FileUpload fu)
        {
            string ImageUrl, ImageShortUrl, Message;
            CommonImageUpload.Upload(fu, out ImageUrl, out ImageShortUrl, out Message);

            return ImageShortUrl;
        }

    }
}
