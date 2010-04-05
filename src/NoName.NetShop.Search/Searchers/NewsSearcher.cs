using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Search.Entities;
using NoName.NetShop.Search.Config;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Analysis;
using Lucene.Net.Search;
using Lucene.Net.QueryParsers;
using Lucene.Net.Documents;

namespace NoName.NetShop.Search.Searchers
{
    public class NewsSearcher : Searcher
    {
        public NewsSearcher(SearchInfo info)
        {
            searchInfo = info;
        }

        public override List<ISearchEntity> GetSearchResult(out int MatchCount)
        {
            Analyzer analyzer = new StandardAnalyzer();

            IndexSearcher searcher = new IndexSearcher(searchInfo.ConfigElement.IndexDirectory);
            MultiFieldQueryParser parserName = new MultiFieldQueryParser(new string[] { "title", "content", "keywords" }, analyzer);

            Query queryName = parserName.Parse(searchInfo.QueryString);

            Hits hits = searcher.Search(queryName);

            List<ISearchEntity> ResultList = new List<ISearchEntity>();

            for (int i = 0; i < hits.Length(); i++)
            {
                Document doc = hits.Doc(i);

                ResultList.Add((ISearchEntity)new NewsModel()
                {
                    EntityIdentity = Convert.ToInt32(doc.Get("newsid")),
                    Title = Convert.ToString(doc.Get("title")),
                    Content = Convert.ToString(doc.Get("content")),
                    Keywords = doc.Get("keywords")
                });
            }
            searcher.Close();

            MatchCount = hits.Length();
            return ResultList;
        }
    }
}
