using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.CMS.Config;
using System.Configuration;
using NoName.NetShop.CMS.FileManage;

namespace NoName.NetShop.BackFlat.CMS.FileManage
{
    public partial class List : System.Web.UI.Page
    {
        private FileManagementSection Config = (FileManagementSection)ConfigurationManager.GetSection("fileManagement");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData(Config.FileCategories[0].PathRoot);
            }
        }

        private void BindData(string RootPath)
        {
            Label_ServerPhysicalPath.Text = RootPath;

            GridView1.DataSource = FileManager.GetList(Config.FileCategories[0],RootPath);
            GridView1.DataBind();
        }


        protected void GridView1_RowCommand(object Sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName.ToLower() == "dir")
            {
                BindData(e.CommandArgument.ToString());
            }

            if (e.CommandName.ToLower() == "del")
            {
                string msg = String.Empty;
                FileSystemObject fso = new FileSystemObject()
                {
                    FullName = e.CommandArgument.ToString()
                };
                FileManager.Delete(fso, out msg);
                BindData(Label_ServerPhysicalPath.Text);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //如果是绑定数据行 
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    ((ImageButton)e.Row.Cells[4].FindControl("Button_Delete")).Attributes.Add("onclick", "javascript:return confirm('即将删除" + e.Row.Cells[1].Text.Trim() + "，确认？')");
                }
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
