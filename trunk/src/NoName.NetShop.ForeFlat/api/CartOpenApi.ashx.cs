using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Collections.Specialized;
using System.Web.SessionState;
using System.Text;
using NoName.NetShop.Member;
using NoName.NetShop.Common;
using NoName.NetShop.ShopFlow;
using Newtonsoft.Json;
using System.IO;
using NoName.NetShop.IMMessage;
using System.Web.Script.Serialization;
using NoName.NetShop.Search.Entities;
using System.Configuration;

namespace NoName.NetShop.ForeFlat
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class CartOpenApi : IHttpHandler, IRequiresSessionState 
    {
        public void ProcessRequest(HttpContext context)
        {
            string result = String.Empty;

            NameValueCollection nv = GetParas(context);

            string action = String.IsNullOrEmpty(nv["action"]) ? "" : nv["action"].ToLower();
            string prefix = String.IsNullOrEmpty(nv["varname"]) ? "" : nv["varname"] + "=";

            switch (action)
            {
                case "getregion":
                    result = GetRegion(context);
                    break;

                case "validatecode": // 验证防刷新验证码
                    result = ValidateSign(context);
                    break;

                case "changequantity":
                    result = ChangeQuantity(context);
                    break;

                case "regexistemail": // 注册时检查邮件地址是不是已经存在
                    result = RegExistUserEmail(context);
                    break;
                case "regexistuserid": // 注册是检查UserId是不是已经存在
                    result = RegExistUserId(context);
                    break;
                case "addfavorite": // 添加收藏
                    result = AddFavorite(context);
                    break;
                case "addtocart": // 添加商品入购物车
                    result =AddToCart(context);
                    break;
                case "getcartinfo": // 获得购物车信息，数量，金额
                    result = GetCartInfo(context);
                    break;
                case "getmessage":
                    result = GetMessage(context);
                    break;
                case "getshipfee":
                    result = GetShipFee(context);
                    break;
                case "getindentity":
                    result = GetIdentity(context);
                    break;
                case "getvote": // 获得投票信息
                    result = GetVoteInfo(context);
                    break;
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(prefix + result);
        }

        private string GetVoteInfo(HttpContext context)
        {
            NameValueCollection nv = GetParas(context);
            int voiteId = int.Parse(nv["voteid"]);
            Vote.BLL.VoteTopic vtbll = new NoName.NetShop.Vote.BLL.VoteTopic();
            Vote.BLL.VoteItemGroup vgbll = new NoName.NetShop.Vote.BLL.VoteItemGroup();
            Vote.BLL.VoteItem vibll = new NoName.NetShop.Vote.BLL.VoteItem();

            StringBuilder sb = new StringBuilder(200);
            JsonWriter jw = new JsonWriter(new StringWriter(sb));

            Vote.Model.VoteTopic vtmodel = vtbll.GetModel(voiteId);
            List<Vote.Model.VoteItemGroup> vgmodels = vgbll.GetModelList(voiteId);
            List<Vote.Model.VoteItem> vimodels = vibll.GetItemsOfVote(voiteId);

            if (vtmodel != null && vtmodel.StartTime < DateTime.Now && vtmodel.EndTime > DateTime.Now
                && vtmodel.Status == true)
            {
                jw.WriteStartObject();
                jw.WritePropertyName("voteid");
                jw.WriteValue(vtmodel.VoteId);
                jw.WritePropertyName("topic");
                jw.WriteValue(vtmodel.Topic);
                jw.WritePropertyName("votenum");
                jw.WriteValue(vtmodel.VoteUserNum);
                jw.WritePropertyName("ismulti");
                jw.WriteValue(vtmodel.IsMulti);
                jw.WritePropertyName("groupcount");
                jw.WriteValue(vgmodels.Count);
                if (vgmodels.Count > 0)
                {
                    jw.WritePropertyName("groups");
                    jw.WriteStartArray();
                    foreach(Vote.Model.VoteItemGroup vgmodel in vgmodels)
                    {
                        jw.WriteStartObject();
                        jw.WritePropertyName("subject");
                        jw.WriteValue(vgmodel.Subject);
                        jw.WritePropertyName("groupid");
                        jw.WriteValue(vgmodel.ItemGroupId);
                        jw.WritePropertyName("items");
                        jw.WriteStartArray();
                        foreach (Vote.Model.VoteItem vitem in vimodels.Where(s => s.ItemGroupId == vgmodel.ItemGroupId))
                        {
                            jw.WriteStartObject();
                            jw.WritePropertyName("itemid");
                            jw.WriteValue(vitem.ItemId);
                            jw.WritePropertyName("subject");
                            jw.WriteValue(vitem.ItemContent);
                            jw.WritePropertyName("count");
                            jw.WriteValue(vitem.VoteCount);
                            jw.WritePropertyName("percent");
                            jw.WriteValue(vitem.Percent);
                            jw.WriteEndObject();
                        }

                        jw.WriteEndArray();

                        jw.WriteEndObject();
                    }
                    jw.WriteEndArray();
                }
                jw.WriteEndObject();
                jw.Close();
            }
            return sb.ToString();
        }
        
        /// <summary>
        /// 获取用户身份
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetIdentity(HttpContext context)
        {
            NameValueCollection nv = GetParas(context);
            string result = String.Empty;
            StringBuilder sb = new StringBuilder(200);
            JsonWriter jw = new JsonWriter(new StringWriter(sb));

            jw.WriteStartObject();
            if (context.User.Identity.IsAuthenticated)
            {
                ShopIdentity iden = context.User.Identity as ShopIdentity;
                if (iden != null)
                {
                    //JavaScriptSerializer jss = new JavaScriptSerializer();
                    //result = jss.Serialize(iden);
                    jw.WritePropertyName("result");
                    jw.WriteValue("true");
                    jw.WritePropertyName("userId");
                    jw.WriteValue(iden.UserId);
                    jw.WritePropertyName("userName");
                    jw.WriteValue(iden.UserName);
                    jw.WritePropertyName("userEmail");
                    jw.WriteValue(iden.UserEmail);
                    jw.WritePropertyName("userType");
                    jw.WriteValue(iden.UserType.ToString());
                    jw.WritePropertyName("userLevel");
                    jw.WriteValue(iden.UserLevel.ToString());
                }
                else
                {
                    jw.WritePropertyName("result");
                    jw.WriteValue("false");
                }
            }
            else
            {
                jw.WritePropertyName("result");
                jw.WriteValue("false");
            }
            jw.WriteEndObject();
            return sb.ToString();
        }

        private string GetShipFee(HttpContext context)
        {
            ShopCart cart = GetCart(context);
            string result = String.Empty;
            if (cart != null)
            {
                int shipId, regionId;

                if (!int.TryParse(context.Request["shipId"], out shipId))
                {
                    shipId = 0;
                }
                if (!int.TryParse(context.Request["regionId"], out regionId))
                {
                    regionId = 0;
                }
                decimal shipFee= cart.CaculateShipFee(shipId, regionId);
                cart.ShipFee = shipFee;

                result = String.Format("订单金额：商品费用：￥{0:0.00} + 配送费：￥{1:0.00} - 优惠费用：￥{2:0.00} = ￥{3:0.00}",
                cart.ProductSum, cart.ShipFee, cart.DerateFee, cart.TotalSum);
            }
            return result;
        }

        private string GetMessage(HttpContext context)
        {
            int msgId;
            string result = String.Empty;
            if (!int.TryParse(context.Request["msgId"], out msgId))
            {
                msgId = 0;
            }
            MessageBll mbll = new MessageBll();
            MessageModel model = mbll.GetModel(msgId);
            if (model != null && (model.UserId == context.User.Identity.Name || model.MsgType==1) && model.UserType==0)
            {
                if (model.MsgType == 0)
                    mbll.SetIsReaded(msgId);

                JavaScriptSerializer jss = new JavaScriptSerializer();
                result = jss.Serialize(model);
            }
            return result;
        }

        private string GetCartInfo(HttpContext context)
        {
            ShopCart cart = GetCart(context);
            StringBuilder sb = new StringBuilder(200);
            JsonWriter jw = new JsonWriter(new StringWriter(sb));

            jw.WriteStartObject();
            jw.WritePropertyName("qua");
            jw.WriteValue(cart.ProductQuantity);
            jw.WritePropertyName("pfee");
            jw.WriteValue(cart.ProductSum);
            jw.WriteEndObject();
            jw.Close();
            return sb.ToString();

        }

        private string AddToCart(HttpContext context)
        {
            ShopCart cart = GetCart(context);
            string result = "false";
            int opt, pid;

            if (!int.TryParse(context.Request["opt"], out opt))
            {
                opt = 0;
            }
            OrderType opType = (OrderType)opt;

            if (!int.TryParse(context.Request["pid"], out pid))
            {
                pid = -1;
            }

            OrderProduct op = cart.AddToCart(opType, pid, 1, context.Request.QueryString);
            if (op != null)
            {
                cart.ContinueShopUrl = op.ProductUrl;
                cart.SaveCartToCookie();
                result = "true";
            }
            return result;
        }

        private string AddFavorite(HttpContext context)
        {
            NameValueCollection nv = GetParas(context);
            bool result = false;
            string code = "";
            string message = "";

            if (context.User.Identity.IsAuthenticated && ((ShopIdentity)context.User.Identity) != null)
            {
                FavoriteBll fbll = new FavoriteBll();
                FavoriteModel favModel = new FavoriteModel();

                favModel.ContentId = int.Parse(nv["cid"]);
                favModel.UserId = ((ShopIdentity)context.User.Identity).UserId;
                favModel.ContentType = (ContentType)int.Parse(nv["ctype"]);

                switch (favModel.ContentType)
                {
                    case ContentType.Product:
                        NoName.NetShop.Product.BLL.ProductModelBll pbll = new NoName.NetShop.Product.BLL.ProductModelBll();
                        NoName.NetShop.Product.Model.ProductModel pmodel = pbll.GetModel(favModel.ContentId);
                        favModel.FavoriteName = pmodel.ProductName;
                        favModel.FavoriteUrl = pmodel.ProductUrl;
                        break;
                    case ContentType.Solution:
                        NoName.NetShop.Solution.BLL.SuiteBll sbll = new NoName.NetShop.Solution.BLL.SuiteBll();
                        NoName.NetShop.Solution.Model.SuiteModel smodel = sbll.GetModel(favModel.ContentId);
                        favModel.FavoriteName = smodel.SuiteName;
                        favModel.FavoriteUrl = ConfigurationManager.AppSettings["siteurl"] + "/solution/suitedetail.aspx?suite=" + smodel.SuiteId;
                        break;
                }
                fbll.Add(favModel);
                result = true;
                message = "收藏成功";
            }
            else
            {
                result = false;
                message = "您还没有登录，请先登录！";
            }
            return GetJsonResult(result, code, message);
        }

        private string RegExistUserId(HttpContext context)
        {
            NameValueCollection nv = GetParas(context);
            string userId = nv["userId"];
            return MemberInfo.UserIdExists(userId) ? "true" : "false";
        }

        private string RegExistUserEmail(HttpContext context)
        {
            NameValueCollection nv = GetParas(context);
            string email = nv["email"];
            return MemberInfo.UserEmailExists(email) ? "true" : "false";
        }
         
        private string ValidateSign(HttpContext context)
        {
            string result = String.Empty;
            NameValueCollection nv = GetParas(context);
            string sign = nv["sign"];
            ValidateHelper vhelper = new ValidateHelper();
            return vhelper.Validate(sign, true)?"true":"false";
        }

        private string GetRegion(HttpContext context)
        {
            NameValueCollection nv = GetParas(context);
            int regionId = int.Parse(nv["regionid"]);
            return RegionInfo.GetSubRegionByJson(regionId);
        }

        private string ChangeQuantity(HttpContext context)
        {
            // data: "action=changeQuantity&opkey=" + opkey + "&quantity=" + quantity,
            NameValueCollection nv = GetParas(context);
            string opKey = nv["opKey"];
            int quantity = int.Parse(nv["quantity"]);

            SpCartKeyHelper helper = new SpCartKeyHelper(opKey);
            if (helper.SpOrderProduct != null)
            {
                helper.SpOrderProduct.SetQuantiy(quantity);
                helper.SpCart.SaveCartToCookie();
            }
            return helper.GetJsonData();
        }

        private ShopCart GetCart(HttpContext context)
        {
            ShopCart cart = context.Session["CurrentShopCart"] as ShopCart;
            if (cart == null)
            {
                string cartkey = String.IsNullOrEmpty(context.Request.QueryString["cartkey"])
                    ? "commcart" : context.Request.QueryString["cartkey"].ToLower();
                cart = CartFactory.Instance().GetShopCart(cartkey);
            }
            return cart;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        #region 辅助方法

        private NameValueCollection GetParas(HttpContext context)
        {
            NameValueCollection nv = null;
            if (context.Request.RequestType == "GET")
            {
                nv = context.Request.QueryString;
            }
            else
            {
                nv = context.Request.Form;
            }
            return nv;
        }

        /// <summary>
        /// 获取部分command执行结果的json数据
        /// 格式为：{'result':'true','code':'001','msg':'false'}
        /// </summary>
        /// <param name="result"></param>
        /// <param name="errorcode"></param>
        /// <param name="errormessage"></param>
        /// <returns></returns>
        private string GetJsonResult(bool result, string code, string message)
        {
            ActionResult retval = new ActionResult();
            retval.Result = result;
            retval.Code = code;
            retval.Message = message;
            return retval.ToJson();
        }
        #endregion
    }
}
