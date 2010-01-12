using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Lucene.Net.Search;
using NoName.NetShop.Search.Config;
using Lucene.Net.QueryParsers;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using NoName.NetShop.Search.Entities;

namespace NoName.NetShop.Search.Searchers
{
    public class ProductSearcher : Searcher
    {
        public ProductSearcher(string qString, SearchElement element)
        {
            QueryString = qString;
            ConfigElement = element;
        }

        public override List<ISearchEntity> GetSearchResult()
        {
            Analyzer analyzer = new StandardAnalyzer();

            IndexSearcher searcher = new IndexSearcher(ConfigElement.IndexDirectory);
            MultiFieldQueryParser parser = new MultiFieldQueryParser(new string[] { "productname", "keywords", "description" }, analyzer);
            Query query = parser.Parse(QueryString);

            Hits hits = searcher.Search(query);

            List<ISearchEntity> ResultList = new List<ISearchEntity>();

            for (int i = 0; i < hits.Length(); i++)
            {
                Document doc = hits.Doc(i);

                ResultList.Add((ISearchEntity)new ProductModel()
                {
                    EntityIdentity = Convert.ToInt32(doc.Get("productid")),
                    ProductName = doc.Get("productname"),
                    CategoryID = Convert.ToInt32(doc.Get("cateid")),
                    CategoryPath = doc.Get("catepath"),
                    Keywords = doc.Get("keywords"),
                    Description = doc.Get("description"),
                    Price = Convert.ToDecimal(doc.Get("price")),
                    CreateTime = Convert.ToDateTime(doc.Get("createtime")),
                    UpdateTime = Convert.ToDateTime(doc.Get("updatetime"))
                });
            }
            searcher.Close();

            return ResultList;
        }
    }
}
