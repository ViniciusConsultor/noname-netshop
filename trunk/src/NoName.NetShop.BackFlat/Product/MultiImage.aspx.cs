using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Product.BLL;
using NoName.NetShop.Product.Facade;
using NoName.NetShop.Product.Model;
using NoName.NetShop.Common;
using NoName.Utility;
using System.Data;

namespace NoName.NetShop.BackFlat.Product
{
    public partial class MultiImage : System.Web.UI.Page
    {
        private int ProductID
        {
            get { if (ViewState["ProductID"] != null) return Convert.ToInt32(ViewState["ProductID"]); else return 0; }
            set { ViewState["ProductID"] = value; }
        }
        private ProductImageModelBll bll = new ProductImageModelBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["productid"])) ProductID = Convert.ToInt32(Request.QueryString["productid"]);
                BindData();
                EidtPanel.Visible = false;
            }
        }

        private void BindData()
        {
            DataTable dt = bll.GetList(ProductID).Tables[0];

            foreach(DataRow row in dt.Rows) 
            {
                row["smallimage"] = ProductMultiImageRule.GetMultiImageUrl(Convert.ToString(row["smallimage"]));
                row["largeimage"] = ProductMultiImageRule.GetMultiImageUrl(Convert.ToString(row["largeimage"]));
                row["originimage"] = ProductMultiImageRule.GetMultiImageUrl(Convert.ToString(row["originimage"]));
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            AddImage();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int ImageID = Convert.ToInt32(imageID.Value);
            EditImage(ImageID);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "d")
            {
                int ImageID = Convert.ToInt32(e.CommandArgument);

                ProductImageModel model = bll.GetModel(ImageID);

                ProductMultiImageRule.DeleteMultiImage(model.LargeImage);
                ProductMultiImageRule.DeleteMultiImage(model.OriginImage);
                ProductMultiImageRule.DeleteMultiImage(model.SmallImage);

                bll.Delete(ImageID);
                BindData();

                MessageBox.Show(this,"删除成功");
            }
        }


        private void AddImage()
        {
            if (!String.IsNullOrEmpty(TextBox1.Text) && !String.IsNullOrEmpty(FileUpload1.FileName))
            {
                string[] FileNames;
                ProductMultiImageRule.SaveProductMultiImage(ProductID, FileUpload1.PostedFile, out FileNames);

                if (FileNames != null)
                {
                    ProductImageModel model = new ProductImageModel();
                    model.ImageId = CommDataHelper.GetNewSerialNum("pd");
                    model.ProductId = ProductID;
                    model.LargeImage = FileNames[1];
                    model.OriginImage = FileNames[2];
                    model.SmallImage = FileNames[0];
                    model.Title = TextBox1.Text;

                    bll.Add(model);
                    BindData();

                    MessageBox.Show(this, "添加成功！");

                }
            }
            else
            {
                MessageBox.Show(this,"输入不完整");
            }
        }

        private void EditImage(int ImageID)
        {
            if (!String.IsNullOrEmpty(TextBox2.Text) && !String.IsNullOrEmpty(FileUpload2.FileName))
            {
                string[] FileNames;
                ProductMultiImageRule.SaveProductMultiImage(ProductID, FileUpload2.PostedFile, out FileNames);

                if (FileNames != null)
                {
                    ProductImageModel model = bll.GetModel(ImageID);

                    ProductMultiImageRule.DeleteMultiImage(model.LargeImage);
                    ProductMultiImageRule.DeleteMultiImage(model.OriginImage);
                    ProductMultiImageRule.DeleteMultiImage(model.SmallImage);

                    model.LargeImage = FileNames[1];
                    model.OriginImage = FileNames[2];
                    model.SmallImage = FileNames[0];
                    model.Title = TextBox1.Text;

                    bll.Update(model);
                    MessageBox.Show(this, "修改成功");
                }
            }
            else
            {
                MessageBox.Show(this, "输入不完整");
            }
            EidtPanel.Visible = false;
        }
    }
}
