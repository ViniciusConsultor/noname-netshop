using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using NoName.NetShop.News.BLL;
using NoName.NetShop.News.Model;
using NoName.Utility;
using NoName.NetShop.Common;

namespace NoName.NetShop.BackFlat.News.Category
{
    public partial class Add : System.Web.UI.Page
    {
        private NewsCategoryModelBll bll = new NewsCategoryModelBll();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton_SelectParentCategory_Click(object sender, EventArgs e)
        {
            int SelectedID = Convert.ToInt32(((HtmlInputHidden)NewsCategoryTree1.FindControl("Input_Value")).Value);
            NewsCategoryModel model = bll.GetModel(SelectedID);
            this.Label_ParentCategory.Text = model == null ? "无从属父类" : model.CateName;
            this.Input_ParentCategoryID.Value = SelectedID.ToString(); 
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            if (TextBox_CategoryName.Text != String.Empty)
            {
                NewsCategoryModel model = new NewsCategoryModel();

                int ParentID = Convert.ToInt32(Input_ParentCategoryID.Value);

                NewsCategoryModel pModel = bll.GetModel(ParentID);

                model.CateID =  CommDataHelper.GetNewSerialNum("ne");
                model.CateLevel = pModel==null?0:pModel.CateLevel+1;
                model.CateName = TextBox_CategoryName.Text;
                model.IsHide = Convert.ToInt32(DropDownList_IsHide.SelectedValue)==1?true:false;
                model.ParentID = ParentID;
                model.ShowOrder = model.CateID;
                model.Status = 1;

                bll.Add(model);

                MessageBox.Show(this,"添加成功！");

                Response.Redirect("list.aspx");
            }
            else
            {
                MessageBox.Show(this,"请输入分类名称");
            }
        }
        
    }
}
