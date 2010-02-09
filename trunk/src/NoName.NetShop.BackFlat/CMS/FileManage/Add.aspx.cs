using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.CMS.Config;
using System.Configuration;
using NoName.NetShop.CMS.FileManage;
using NoName.Utility;

namespace NoName.NetShop.BackFlat.CMS.FileManage
{
    public partial class Add : System.Web.UI.Page
    {
        private FileManagementSection Config = (FileManagementSection)ConfigurationManager.GetSection("fileManagement");


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Panel_UploadedFileList.Visible = false;
            }
        }

        protected void Button_Upload_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(FileUpload_ImageFile.FileName))
            {
                List<FileSystemObject> TheUploadList = FileManager.Upload(FileUpload_ImageFile.PostedFile);

                GridView1.DataSource = TheUploadList;
                GridView1.DataBind();

                Panel_UploadedFileList.Visible = true;
            }
            else
            {
                MessageBox.Show(this,"请选择文件");
            }
        }

        public string GetFileLogo(string Suffix)
        {
            string LogoUrl = String.Empty;

            switch (Suffix.ToLower())
            {
                case "none":
                    LogoUrl = "/images/space.gif";
                    break;
                case "folder":
                    LogoUrl = "/images/folder-3.png";
                    break;
                case "gif":
                    LogoUrl = "/images/file-gif.gif";
                    break;
                case "bmp":
                    LogoUrl = "/images/file-bmp.gif";
                    break;
                case "jpg":
                    LogoUrl = "/images/file-jpg.gif";
                    break;
                case "jpeg":
                    LogoUrl = "/images/file-jpg.gif";
                    break;
                case "png":
                    LogoUrl = "/images/file-png.gif";
                    break;
                default:
                    LogoUrl = "/images/file-none.gif";
                    break;
            }

            return LogoUrl;
        }
    }
}
