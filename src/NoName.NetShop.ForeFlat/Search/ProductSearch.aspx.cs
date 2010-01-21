using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Search.Entities;
using NoName.NetShop.Search.Config;
using System.Configuration;
using NoName.NetShop.Search;
using NoName.NetShop.Search.Searchers;
using NoName.Utility;
using System.Text;

namespace NoName.NetShop.ForeFlat.Search
{
    public partial class ProductSearch : System.Web.UI.Page
    {
        private static SearchSection Config = (SearchSection)ConfigurationManager.GetSection("searches");

        protected void Page_Load(object sender, EventArgs e)
        {
            string word = Request.QueryString["w"];
            if (String.IsNullOrEmpty(word)) throw new ArgumentNullException();

            SearchInfo srh = new SearchInfo()
            {
                ConfigElement = Config.Searches["product"],
                PageIndex = 1,
                PageSize = 10,
                QueryString = word
            };

            int MatchCount = 0;

            Searcher s = new ProductSearcher(srh);

            List<ISearchEntity> SearchResult = s.GetSearchResult(out MatchCount);

            List<ProductModel> ProductSearchResult = new List<ProductModel>();
            Response.Write(String.Format("以{0}为检索词，共搜索到{1}条数据：<br/>", srh.QueryString, MatchCount));
            foreach (ISearchEntity entity in SearchResult)
            {
                ProductSearchResult.Add((ProductModel)entity);

                Response.Write(String.Format("{0}\t{1}<br/>", ((ProductModel)entity).EntityIdentity, ((ProductModel)entity).ProductName));
            }

            //GridView1.DataSource = ProductSearchResult;
            //GridView1.DataBind();
        }
    }
}
