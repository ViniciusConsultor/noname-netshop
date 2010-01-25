using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using NoName.NetShop.Solution.BLL;
using System.Data;
using System.Collections.Specialized;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Threading;

namespace NoName.NetShop.ForeFlat.Handler
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class SolutionHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Thread.Sleep(1000);
            context.Response.ContentType = "text/plain";
            HttpRequest req = context.Request;
            if (!String.IsNullOrEmpty(req["scenceid"]) && !String.IsNullOrEmpty(req["cateid"]))
            {
                int ScenceID = Convert.ToInt32(req["scenceid"]);
                int CategoryID = Convert.ToInt32(req["cateid"]);
                int BrandID = 0; if (!String.IsNullOrEmpty(req["brandid"])) BrandID = Convert.ToInt32(req["brandid"]);
                string ProdcutName = String.Empty; if (!String.IsNullOrEmpty(req["pdname"])) ProdcutName = req["pdname"];

                context.Response.Write(GetProductListJson(ScenceID, CategoryID, BrandID, ProdcutName));
            }
            else
            {
                context.Response.Write("[]");
            }
        }

        private String GetProductListJson(int ScenceID, int CategoryID, int BrandID, string ProductName)
        {
            DataTable dt = new CategoryConditionBll().GetCategoryProductList(CategoryID, ScenceID, BrandID, ProductName);

            StringBuilder result = new StringBuilder();
            StringWriter sw = new StringWriter(result);
            JsonWriter writer = new JsonWriter(sw);

            writer.Formatting = Formatting.Indented;

            writer.WriteStartArray();

            foreach (DataRow row in dt.Rows)
            {
                writer.WriteStartObject();
                WriteJsonKeyValue(writer, "productid", row["productid"].ToString());
                WriteJsonKeyValue(writer, "productname", row["productname"].ToString());
                WriteJsonKeyValue(writer, "image", row["smallimage"].ToString());
                WriteJsonKeyValue(writer, "price", row["merchantprice"].ToString());
                writer.WriteEndObject(); 
            }

            writer.WriteEndArray();
            writer.Close();

            return result.ToString();
        }


        private void WriteJsonKeyValue(JsonWriter writer, string key, string value)
        {
            writer.WritePropertyName(key);
            writer.WriteValue(value);
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
