using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoName.NetShop.ForeFlat.vote
{
    public partial class DoVote : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            NoName.NetShop.Vote.BLL.VoteTopic vbll = new NoName.NetShop.Vote.BLL.VoteTopic();
            NoName.NetShop.Vote.BLL.VoteRemark rbll = new NoName.NetShop.Vote.BLL.VoteRemark();
            NoName.NetShop.Vote.Model.VoteRemark rmodel = new NoName.NetShop.Vote.Model.VoteRemark();

            int voteId = int.Parse(ReqParas["voteId"]);
            NoName.NetShop.Vote.Model.VoteTopic vmodel = vbll.GetModel(voteId);
            string voteIp = Request.UserHostAddress;
            string remark = ReqParas["remark"];
            string items = ReqParas["itemId"];
            string userId = String.Empty;
            if (vmodel.IsRegUser)
            {
                if (!this.User.Identity.IsAuthenticated)
                {
                    Response.Write("请先登陆，然后再投票！");
                    Response.End();
                }
                else
                {
                    userId = this.User.Identity.Name;
                }
            }
           
           rmodel.VoteId = voteId;
            rmodel.ItemIds = items;
            rmodel.LogId =0;
            rmodel.Remark = remark;
            rmodel.UserId = userId;
            rmodel.VoteIP = voteIp;
            rbll.Add(rmodel);

            Response.Redirect("VoteResult.aspx?voteId="+voteId);

        }
    }
}
