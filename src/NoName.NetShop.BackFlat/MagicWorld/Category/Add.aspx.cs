using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.MagicWorld.Model;
using NoName.NetShop.MagicWorld.BLL;
using NoName.Utility;
using NoName.NetShop.Common;

namespace NoName.NetShop.BackFlat.MagicWorld.Category
{
    public partial class Add : System.Web.UI.Page
    {
        private int ParentID
        {
            get { if (ViewState["ParentID"] != null) return Convert.ToInt32(ViewState["ParentID"]); else return -1; }
            set { ViewState["ParentID"] = value; }
        }
        private MagicCategoryBll bll = new MagicCategoryBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ParentID = Convert.ToInt32(Request.QueryString["parentid"]);
                BindData();
            }
        }

        private void BindData()
        {
            MagicCategoryModel model = bll.GetModel(ParentID);

            txtParentCate.Text = model==null?"无从属父类":model.CategoryName;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string ErrorMessage = String.Empty;
            if (String.IsNullOrEmpty(txtCateName.Text))
            {
                ErrorMessage += "分类名称不可为空";
            }
            if (!String.IsNullOrEmpty(ErrorMessage))
            {
                MessageBox.Show(this,ErrorMessage);
                return;
            }

            MagicCategoryModel model = new MagicCategoryModel();
            MagicCategoryModel ParentModel = bll.GetModel(ParentID);

            model.CategoryID = CommDataHelper.GetNewSerialNum(AppType.MagicWorld) ;
            model.CategoryLevel = ParentModel==null?0:ParentModel.CategoryLevel+1;
            model.CategoryName = txtCateName.Text;
            model.CategoryPath = ParentModel==null?model.CategoryID.ToString():ParentModel.CategoryPath+"/"+model.CategoryID;
            model.IsHide = chkIsHide.Checked;
            model.ParentID = ParentID;
            model.ShowOrder = model.CategoryID;
            model.Status = 0;

            bll.Add(model);

            MessageBox.Show(this,"添加成功！");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script type=\"text/javascript\">window.parent.location=window.parent.location+'?_=" + DateTime.Now.Ticks + "'</script>");

        }
    }
}

