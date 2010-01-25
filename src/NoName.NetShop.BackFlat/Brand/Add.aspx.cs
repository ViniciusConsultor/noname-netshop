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


        //private void BindDropDownList()
        //{
        //    CategoryModelBll CategoryBll = new CategoryModelBll();

        //    drpCategory.DataSource = CategoryBll.GetList("CateLevel = 1");
        //    drpCategory.DataTextField = "catename";
        //    drpCategory.DataValueField = "cateid";
        //    drpCategory.DataBind();
        //}


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.txtBrandName.Text == "")
            {
                strErr += "BrandName����Ϊ�գ�\\n";
            }
            if (this.fulBrandLogo.FileName == "")
            {
                strErr += "BrandLogo����Ϊ�գ�\\n";
            }
            if (this.txtBrief.Text == "")
            {
                strErr += "Brief����Ϊ�գ�\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }

            if (bll.Exists(txtBrandName.Text)) 
            {
                MessageBox.Show(this,"��Ʒ���Ѵ���");
                return;
            }


            BrandModel model = new BrandModel();

            model.BrandId = CommDataHelper.GetNewSerialNum("pd");
            model.BrandName = txtBrandName.Text;
            model.CateId = 0;
            model.CatePath = String.Empty;
            model.BrandLogo = UploadBrandLogo(model.BrandId, fulBrandLogo);
            model.Brief = txtBrief.Text;
            model.ShowOrder = model.BrandId;

            bll.Add(model);
            MessageBox.ShowAndRedirect(this, "��ӳɹ���", "List.aspx");
        }

        private string UploadBrandLogo(int BrandID,FileUpload fu)
        {
            string path = Server.MapPath(ConfigurationManager.AppSettings["brandLogoPath"]);
            string FileName = String.Format("logo-{0}{1}", BrandID, Path.GetExtension(fu.FileName));
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            fu.SaveAs(path + FileName);
            return FileName;
        }

    }
}
