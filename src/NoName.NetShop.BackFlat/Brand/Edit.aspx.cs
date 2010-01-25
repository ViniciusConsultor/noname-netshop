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
                BindDropDownList();
            }
        }

        private void BindData()
        {
            BrandModel brand = bll.GetModel(BrandID);

            if (brand != null)
            {
                txtBrandName.Text=brand.BrandName;
                drpCategory.SelectedValue = brand.CateId.ToString();
                imgBrandLogo.ImageUrl = brand.BrandLogo;
                txtBrief.Text = brand.Brief;
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

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            string strErr = "";
            if (this.txtBrandName.Text == "")
            {
                strErr += "BrandName不能为空！\\n";
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

            BrandModel brand = bll.GetModel(BrandID);
            CategoryModel cate = new CategoryModelBll().GetModel(Convert.ToInt32(drpCategory.SelectedValue));

            brand.BrandName = txtBrandName.Text;
            brand.CateId = cate.CateId;
            brand.CatePath = cate.CatePath;
            brand.Brief = txtBrief.Text;

            if (fulBrandLogo.FileName != String.Empty)
            {
                brand.BrandLogo = UploadBrandLogo(brand.BrandId, fulBrandLogo);
            }

            bll.Update(brand);
            MessageBox.ShowAndRedirect(this, "修改成功！", "List.aspx");
        }


        private string UploadBrandLogo(int BrandID, FileUpload fu)
        {
            string path = Server.MapPath(ConfigurationManager.AppSettings["brandLogoPath"]);
            string FileName = String.Format("logo-{0}{1}", BrandID, Path.GetExtension(fu.FileName));
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            fu.SaveAs(path + FileName);
            return FileName;
        }
    }
}
