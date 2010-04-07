using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Product.BLL;
using NoName.NetShop.Product.Model;
using System.Configuration;
using System.IO;
using NoName.Utility;
using NoName.NetShop.Common;

namespace NoName.NetShop.BackFlat.Brand
{
    public partial class Edit : System.Web.UI.Page
    {
        private int BrandID
        {
            get { if (ViewState["BrandID"] != null) return Convert.ToInt32(ViewState["BrandID"]); else return 0; }
            set { ViewState["BrandID"] = value; }
        }
        private BrandModelBll bll = new BrandModelBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["brandid"])) BrandID = Convert.ToInt32(Request.QueryString["brandid"]);
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            BrandModel brand = bll.GetModel(BrandID);

            if (brand != null)
            {
                txtBrandName.Text=brand.BrandName;
                imgBrandLogo.ImageUrl = CommonImageUpload.GetCommonImageFullUrl(brand.BrandLogo);
                txtBrief.Text = brand.Brief;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            string strErr = "";
            if (this.txtBrandName.Text == "")
            {
                strErr += "品牌名称不能为空！\\n";
            }
            if (this.txtBrief.Text == "")
            {
                strErr += "简要描述不能为空！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }

            BrandModel brand = bll.GetModel(BrandID);

            try // delete old brand logo file
            {
                File.Delete(CommonImageUpload.GetCommonImagePhysicalPath(brand.BrandLogo));
            }
            catch { }

            brand.BrandName = txtBrandName.Text;
            brand.Brief = txtBrief.Text;

            if (fulBrandLogo.FileName != String.Empty)
            {
                brand.BrandLogo = UploadBrandLogo(brand.BrandId, fulBrandLogo);
            }

            bll.Update(brand);
            Response.Redirect("List.aspx");
        }


        private string UploadBrandLogo(int BrandID, FileUpload fu)
        {
            string ImageUrl, ImageShortUrl, Message;
            CommonImageUpload.Upload(fu, out ImageUrl, out ImageShortUrl, out Message);

            return ImageShortUrl;
        }
    }
}
