using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.CMS.Controler;

namespace NoName.NetShop.BackFlat.CMS.Controls
{
    public partial class TagEditor_Static : TagEditorBase
    {
        private int _PageID;
        private string _ServerID;
        private int _TagID;
        private string _TagTitle;

        public override int PageID
        {
            get { return _PageID; }
            set { _PageID = value; }
        }
        public override string ServerID
        {
            get { return _ServerID; }
            set { _ServerID = value; }
        }
        public override int TagID
        {
            get { return _TagID; }
            set { _TagID = value; }
        }
        public override string TagTitle
        {
            get { return _TagTitle; }
            set { _TagTitle = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            EditorTitle.InnerHtml = TagTitle;

            TextBox_Content.Text = TagControler.TagContentGet(PageID, TagID, ServerID);
        }
    }
}