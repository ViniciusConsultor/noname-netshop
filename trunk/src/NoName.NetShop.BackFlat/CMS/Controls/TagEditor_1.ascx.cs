using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.CMS.Model;

namespace NoName.NetShop.BackFlat.CMS.Controls
{
    public partial class TagEditor_1 : System.Web.UI.UserControl
    {
        private int _PageID;
        private string _ServerID;

        public int PageID
        {
            get { return _PageID; }
            set { _PageID = value; }
        }
        public string ServerID
        {
            get { return _ServerID; }
            set { _ServerID = value; }
        }
        public int TagID
        {
            get { return 1; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Control c = PageUtil.GetPostBackControl(this.Page);
            //if (c!=null && c.ID.Contains("chkItem")) 
            FillTagContent();
        }

        private void FillTagContent()
        {
            TagInfo tag = new TagInfo(TagID, ServerID);
            PageInfo page = PageInfo.GetPageInfo(PageID);

            FCKeditor1.Value = tag.GetContent(page);
        }
    }
}