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
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(prefix + result);
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

            if (context.User.Identity.IsAuthenticated)
            {
                ShopIdentity iden = context.User.Identity as ShopIdentity;

                if (iden != null)
                {
                    FavoriteBll fbll = new FavoriteBll();
                    FavoriteModel favModel = new FavoriteModel();

                    favModel.ContentId = int.Parse(nv["cid"]);
                    favModel.UserId = iden.UserId;
                    favModel.ContentType = (ContentType)int.Parse(nv["ctype"]);
                    favModel.FavoriteName = "";
                    favModel.FavoriteUrl = "";
                    fbll.Add(favModel);
                    result = true;
                    message = "收藏成功";
                }
                else
                {
                    result = false;
                    message = "您还没有登录，请先登录！";
                }
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
            string cartkey = String.IsNullOrEmpty(context.Request.QueryString["cartkey"])
                ? "commcart" : context.Request.QueryString["cartkey"].ToLower();
            return CartFactory.Instance().GetShopCart(cartkey);
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
