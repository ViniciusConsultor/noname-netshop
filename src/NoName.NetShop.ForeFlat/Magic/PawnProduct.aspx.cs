using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.MagicWorld.BLL;
using NoName.NetShop.MagicWorld.Model;
using NoName.NetShop.MagicWorld.Facade;
using NoName.NetShop.Common;
using NoName.NetShop.Comment;
using NoName.NetShop.Member;

namespace NoName.NetShop.ForeFlat.Magic
{
    public partial class PawnProduct : System.Web.UI.Page
    {
        public int PawnProductID
        {
            get { if (ViewState["PawnProductID"] != null) return Convert.ToInt32(ViewState["PawnProductID"]); else return -1; }
            set { ViewState["PawnProductID"] = value; }
        }
        private PawnProductBll bll = new PawnProductBll();
        private CommentBll CmtBll = new CommentBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["pid"])) PawnProductID = Convert.ToInt32(Request.QueryString["pid"]);
                if (PawnProductID != -1) BindData(); else Response.End();
            }
        }

        private void BindData()
        {
            PawnProductModel model = bll.GetModel(PawnProductID);
            MemberInfo user = MemberInfo.GetFullInfo(model.UserID);

            Image_Medium.ImageUrl = MagicWorldImageRule.GetMainImageUrl(model.MediumImage);
            Image_Small.ImageUrl = MagicWorldImageRule.GetMainImageUrl(model.SmallImage); 

            Literal_ProductName.Text = model.PawnProductName;
            Literal_Price.Text = model.SellingPrice.ToString("0.00");
            Literal_UserID.Text = model.UserID;
            Literal_Brief.Text = model.Brief;

            Literal_UserID2.Text = user.UserId;
            string UserPhone = String.Empty,Address = String.Empty;
            switch (user.UserType)
            {
                case MemberType.Personal:
                    PersonMemberInfo puser = (PersonMemberInfo)user;
                    UserPhone = puser.Mobile == String.Empty? puser.Telephone : puser.Mobile;
                    Address = String.Empty;
                    break;
                case MemberType.Famly:
                    FamlyMemberInfo fuser = (FamlyMemberInfo)user;
                    UserPhone = fuser.Mobile == String.Empty? fuser.Telephone : fuser.Mobile;
                    Address = fuser.Address;
                    break;
                case MemberType.Company:
                    CompanyMemberInfo cuser = (CompanyMemberInfo)user;
                    UserPhone = cuser.Mobile == String.Empty? cuser.Telephone : cuser.Mobile;
                    Address = cuser.Address;
                    break;
                case MemberType.School:
                    SchoolMemberInfo suser = (SchoolMemberInfo)user;
                    UserPhone = suser.Mobile == String.Empty? suser.Telephone : suser.Mobile;
                    Address = suser.Address;
                    break;
                default:
                    UserPhone = String.Empty;
                    Address = String.Empty;
                    break;
            }

            Literal_Phone.Text = UserPhone;
            Literal_Address.Text = Address;

            Repeater_Comment.DataSource = CmtBll.GetList(AppType.MagicWorld, PawnProductID);
            Repeater_Comment.DataBind();
        }
    }
}