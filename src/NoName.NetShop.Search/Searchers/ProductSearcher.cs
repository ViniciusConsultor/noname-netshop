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
using Lucene.Net.Index;

namespace NoName.NetShop.Search.Searchers
{
    public class ProductSearcher : Searcher
    {
        public ProductSearcher(SearchInfo info)
        {
            searchInfo = info;
        }

        public override List<ISearchEntity> GetSearchResult(out int MatchCount)
        {
            Analyzer analyzer = new StandardAnalyzer();

            IndexSearcher searcher = new IndexSearcher(searchInfo.ConfigElement.IndexDirectory);
            MultiFieldQueryParser parserName = new MultiFieldQueryParser(new string[] { "productname", "keywords", "description" }, analyzer);

            Query queryName = parserName.Parse(searchInfo.QueryString);
            Query queryCategory = new WildcardQuery(new Term("catepath", "*" + searchInfo.Category + "*"));

            BooleanQuery bQuery = new BooleanQuery();
            bQuery.Add(queryName, BooleanClause.Occur.MUST);
            if (searchInfo.Category != 0) bQuery.Add(queryCategory, BooleanClause.Occur.MUST);

            Hits hits = searcher.Search(bQuery);

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
                    UpdateTime = Convert.ToDateTime(doc.Get("updatetime")),
                    ProductImage = Convert.ToString(doc.Get("mainimage"))                    
                });
            }
            searcher.Close();

            MatchCount = hits.Length();
            return ResultList;
        }
    }
}
