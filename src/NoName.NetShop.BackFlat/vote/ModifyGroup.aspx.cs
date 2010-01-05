using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.BackFlat.MagicWorld.Category;

namespace NoName.NetShop.BackFlat.vote
{
    public partial class ModifyGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int groupId;
                int voteId;
                if (!int.TryParse(Request["groupId"], out groupId))
                {
                    groupId = 0;
                }
                if (!int.TryParse(Request["voteId"],out voteId))
                {
                    Response.Write("必须提供有效的参数");
                    Response.End();
                }
                ShowVoteGroupInfo(groupId,voteId);

            }
        }

        private void ShowVoteGroupInfo(int groupId,int voteId)
        {
            NoName.NetShop.Vote.BLL.VoteItemGroup gbll = new NoName.NetShop.Vote.BLL.VoteItemGroup();
             NoName.NetShop.Vote.BLL.VoteItem ibll = new NoName.NetShop.Vote.BLL.VoteItem();
           NoName.NetShop.Vote.Model.VoteItemGroup gmodel = gbll.GetModel(groupId);

           if (gmodel != null)
           {
               this.txtContent.Text = gmodel.Content;
               this.txtSubject.Text = gmodel.Subject;
               this.lblGroupId.Text = gmodel.ItemGroupId.ToString();
               this.lblVoteId.Text = gmodel.VoteId.ToString();

               this.gvItems.DataSource = ibll.GetItemsOfGroup(groupId);
               this.gvItems.DataKeyNames = new string[] { "ItemId" };
               this.gvItems.DataBind();
           }
           else
           {
               this.lblVoteId.Text = voteId.ToString();
               this.lblGroupId.Text = "0";
           }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            NoName.NetShop.Vote.BLL.VoteItemGroup gbll = new NoName.NetShop.Vote.BLL.VoteItemGroup();
            NoName.NetShop.Vote.BLL.VoteItem ibll = new NoName.NetShop.Vote.BLL.VoteItem();

            NoName.NetShop.Vote.Model.VoteItemGroup gmodel = gbll.GetModel(int.Parse(lblGroupId.Text));
            if (gmodel == null)
            {
                gmodel = new NoName.NetShop.Vote.Model.VoteItemGroup();
                gmodel.ItemGroupId = 0;
                gmodel.VoteId = int.Parse(lblVoteId.Text);
                gmodel.Subject = txtSubject.Text.Trim();
                gmodel.Content = txtContent.Text.Trim();
                gbll.Save(gmodel);
                lblVoteId.Text = gmodel.VoteId.ToString();
                lblGroupId.Text = gmodel.ItemGroupId.ToString();
            }

            NoName.NetShop.Vote.Model.VoteItem imodel = new NoName.NetShop.Vote.Model.VoteItem();
            imodel.ItemContent = String.Empty;
            imodel.ItemGroupId = gmodel.ItemGroupId;
            imodel.VoteId = gmodel.VoteId;
            imodel.ItemId = 0;
            ibll.Save(imodel);

            List<NoName.NetShop.Vote.Model.VoteItem> list = ibll.GetItemsOfGroup(int.Parse(lblGroupId.Text));
            this.gvItems.DataSource = list;
            this.gvItems.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            NoName.NetShop.Vote.BLL.VoteItemGroup gbll = new NoName.NetShop.Vote.BLL.VoteItemGroup();
            NoName.NetShop.Vote.BLL.VoteItem ibll = new NoName.NetShop.Vote.BLL.VoteItem();
            NoName.NetShop.Vote.Model.VoteItemGroup gmodel= gbll.GetModel(int.Parse(this.lblGroupId.Text));

            if (gmodel == null)
            {
                gmodel = new NoName.NetShop.Vote.Model.VoteItemGroup();
                gmodel.ItemGroupId = 0;
                gmodel.VoteId = int.Parse(lblVoteId.Text);
            }
            gmodel.Subject = txtSubject.Text.Trim();
            gmodel.Content = txtContent.Text.Trim();
            gbll.Save(gmodel);

            foreach (GridViewRow row in gvItems.Rows)
            {
                int itemId = int.Parse(gvItems.DataKeys[row.RowIndex].Values["ItemId"].ToString());
                NoName.NetShop.Vote.Model.VoteItem imodel = ibll.GetModel(itemId);
                imodel.ItemContent = (row.FindControl("txtContent") as TextBox).Text.Trim();
                ibll.Save(imodel);
            }
            Response.Redirect("ShowVoteInfo.aspx?voteId=" + gmodel.VoteId);
        }


        protected void gvItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            NoName.NetShop.Vote.BLL.VoteItem ibll = new NoName.NetShop.Vote.BLL.VoteItem();
            int itemId = Convert.ToInt32(gvItems.DataKeys[e.RowIndex].Values["ItemId"]);
            ibll.Delete(itemId);
            ShowVoteGroupInfo(int.Parse(lblGroupId.Text), int.Parse(lblVoteId.Text));

        }
    }
}
