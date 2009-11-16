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
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(prefix + result);
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
                ? "" : context.Request.QueryString["cartkey"].ToLower();
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
