using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Data;
using NoName.NetShop.Product.BLL;

namespace NoName.NetShop.BackFlat.Controls
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class CategoryProvider : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            int ParentID = String.IsNullOrEmpty(context.Request.QueryString["parentid"]) ? 0 : Convert.ToInt32(context.Request.QueryString["parentid"]);

            context.Response.Write(GetJsonResult(ParentID));





        }

        private string GetJsonResult(int ParentID)
        {
            StringBuilder result = new StringBuilder();
            StringWriter sw = new StringWriter(result);
            JsonWriter writer = new JsonWriter(sw);

            writer.Formatting = Formatting.None;

            writer.WriteStartArray();

            foreach (DataRow row in GetSubCategory(ParentID).Rows)
            {
                writer.WriteStartObject();
                WriteJsonKeyValue(writer, "catename", row["catename"].ToString());
                WriteJsonKeyValue(writer, "cateid", row["cateid"].ToString());
                writer.WriteEndObject(); 
            }

            writer.WriteEndArray();
            writer.Close();

            return result.ToString();
        }

        private DataTable GetSubCategory(int ParentID)
        {
            CategoryModelBll bll = new CategoryModelBll();

            return bll.GetList("parentid = " + ParentID).Tables[0];
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
