using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using NoName.NetShop.Search;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Search;
using Lucene.Net.QueryParsers;
using NoName.NetShop.Search.Config;
using System.Configuration;
using Lucene.Net.Documents;
using Lucene.Net.Index;

namespace NoName.NetShop.SearchIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            SearchSection Config = (SearchSection)ConfigurationManager.GetSection("searches");
            string action = Console.ReadLine();

            if (action != String.Empty)
            {
                Analyzer analyzer = new StandardAnalyzer();

                IndexSearcher searcher = new IndexSearcher(Config.Searches["product"].IndexDirectory);

                MultiFieldQueryParser parserName = new MultiFieldQueryParser(new string[] { "productname", "keywords", "description" }, analyzer);

                Query queryName = parserName.Parse("三星");
                Query queryCategory = new WildcardQuery(new Term("catepath", "*82*"));

                //Query queryCategory = parserCategory.Parse("82");

                BooleanQuery bQuery = new BooleanQuery();
                bQuery.Add(queryName, BooleanClause.Occur.MUST);
                bQuery.Add(queryCategory, BooleanClause.Occur.MUST);

                Hits hits = searcher.Search(bQuery);

                for (int i = 0; i < hits.Length(); i++)
                {
                    Document d = hits.Doc(i);
                    Console.WriteLine(d.Get("productname"));

                }
            }
            else
            {
                DataProcessor.Process("product");
                Console.Read();
            }

        }
    }
}
