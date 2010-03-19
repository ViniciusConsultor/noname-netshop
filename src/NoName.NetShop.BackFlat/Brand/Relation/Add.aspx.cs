using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Product.BLL;
using System.Data;
using System.Collections.Specialized;
using NoName.Utility;
using System.Text;
using NoName.NetShop.Product.Model;

namespace NoName.NetShop.BackFlat.Brand.Relation
{
    public partial class Add : System.Web.UI.Page
    {
        private int CategoryID
        {
            get { if (ViewState["CategoryID"] != null) return Convert.ToInt32(ViewState["CategoryID"]); else return -1; }
            set { ViewState["CategoryID"] = value; }
        }
        private BrandModelBll bbll = new BrandModelBll();
        private BrandCategoryRelationBll rbll = new BrandCategoryRelationBll();
        private CategoryModelBll cbll = new CategoryModelBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["cid"])) CategoryID = Convert.ToInt32(Request.QueryString["cid"]);
                BindData();
            }
        }

        private void BindData()
        {
            DataTable dt = bbll.GetList(" brandid not in (SELECT distinct brandid FROM pdbrandcategoryrelation where cateid=" + CategoryID + ")").Tables[0];
            Repeater_Brand.DataSource = dt;
            Repeater_Brand.DataBind();
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            NameValueCollection nv = Request.Form;            

            for (int i = 0; i < nv.Count; i++)
            {
                if (nv.Keys[i].Contains("brand"))
                {
                    int BrandID = Convert.ToInt32(nv[i]);
                    AddRelation(CategoryID, BrandID);
                }
            }
            //MessageBox.ShowAndRedirect(this, "添加成功！", Request.RawUrl);

            Response.Redirect("List.aspx?cid="+CategoryID);
        }

        private void AddRelation(int CateID, int BrandID)
        {
            CategoryModel cate = cbll.GetModel(CateID);

            BrandCategoryRelationModel Relation = new BrandCategoryRelationModel()
            {
                BrandID = BrandID,
                CategoryID = CateID,
                CategoryPath = cate.CatePath
            };

            rbll.Add(Relation);

            DataTable sonCates=cbll.GetList(" parentid="+CateID).Tables[0];
            if(sonCates.Rows.Count>0)
            {
                foreach (DataRow row in sonCates.Rows) AddRelation(Convert.ToInt32(row["cateid"]), BrandID);
            } 
        }
    }
}
