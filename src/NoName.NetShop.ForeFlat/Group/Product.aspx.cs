using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.GroupShopping.BLL;
using NoName.NetShop.GroupShopping.Model;
using NoName.NetShop.GroupShopping.Facade;
using NoName.NetShop.Common;
using NoName.Utility;

namespace NoName.NetShop.ForeFlat.Group
{
    public partial class Product : AuthBasePage
    {
        private int ProductID
        {
            get ;//{ if (Session["ProductID"] != null) return ProductID; else return 0; }
            set ;//{ Session["ProductID"] = value; }
        }
        private GroupProductBll bll = new GroupProductBll();
        private GroupApplyBll abll = new GroupApplyBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["productid"])) ProductID = Convert.ToInt32(Request.QueryString["productid"]);
                else throw new ArgumentNullException("productid");

                BindData();
            }
        }

        private void BindData()
        {
            if (ProductID != 0)
            {
                GroupProductModel model = bll.GetModel(ProductID);

                this.Title = model.ProductName + "-团购-鼎鼎商城";

                Literal_ProductName.Text = model.ProductName;
                Image_Small.ImageUrl = GroupShoppingImageRule.GetImageUrl(model.MediumImage);
                Image_Big.ImageUrl = GroupShoppingImageRule.GetImageUrl(model.LargeImage);
                Literal_Count.Text = model.SuccedLine.ToString();
                Literal_CurrentCount.Text = "";
                Literal_GroupPrice.Text = model.GroupPrice.ToString("0.00");
                Literal_MarketPrice.Text = model.MarketPrice.ToString("0.00");
                Literal_Time.Text = "";
                Literal_Brief.Text = model.Description;

                if (model.ProductType == (int)GroupShoppingProductType.解决方案)
                {
                    Literal_Detail.Text = String.Format("<div class=\"box7\" runat=\"server\"><div class=\"title\">解决方案明细</div><div class=\"content\"><p class=\"description\">{0}</p></div></div>", model.Detail);
                    Literal_Detail.Visible = true;
                }

                if (Session["group-product-apply"] != null)
                {
                    TextBox_Message.Text = Session["group-product-apply"].ToString();
                    TextBox_Message.Focus();
                }

                Repeater_ApplyList.DataSource = abll.GetList(ProductID);
                Repeater_ApplyList.DataBind();
            }
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            if (CurrentUser != null)
            {
                GroupApplyModel model = new GroupApplyModel();

                model.GroupApplyID = CommDataHelper.GetNewSerialNum(AppType.GroupShopping);
                model.ApplyBrief = TextBox_Message.Text;
                model.ApplyStatus = (int)GroupProductApplyStatus.申请中;
                model.ApplyTime = DateTime.Now;
                model.ConfirmTime = DateTime.Now;
                model.GroupProductID = Convert.ToInt32(Request.QueryString["productid"]);
                model.UserID = CurrentUser.UserId;

                abll.Add(model);


                if (Session["group-product-apply"] != null)
                {
                    Session.Remove("group-product-apply");
                }

                MessageBox.ShowAndRedirect(this, "申请成功，请等待管理员审批", Request.RawUrl);
            }
            else
            {
                Session["group-product-apply"] = TextBox_Message.Text;
                Response.Redirect("/Login.aspx?returnurl=" + Request.RawUrl);
            }
        }
    }
}
