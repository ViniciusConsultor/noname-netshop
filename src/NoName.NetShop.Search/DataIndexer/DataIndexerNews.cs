using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Search.Config;
using NoName.NetShop.Search.Entities;
using Lucene.Net.Analysis;
using Lucene.Net.Index;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;

namespace NoName.NetShop.Search.DataIndexer
{
    public class DataIndexerNews : IDataIndexer
    {
        private SearchElement ConfigElement;
        public DataIndexerNews(SearchElement Element)
        {
            ConfigElement = Element;
        }
        
        public void CreateIndex(List<ISearchEntity> CreateEntities)
        {
            Analyzer analyzer = new StandardAnalyzer();
            IndexWriter writer = new IndexWriter(ConfigElement.IndexDirectory, analyzer, true);
            //第三个参数：是否重新创建索引，True 一律清空 重新建立 False 原有基础上增量添加索引

            foreach (ISearchEntity IndexEntity in CreateEntities)
            {
                NewsModel news = (NewsModel)IndexEntity;

                Document doc = new Document();

                doc.Add(new Field("newsid", Convert.ToString(news.EntityIdentity), Field.Store.YES, Field.Index.UN_TOKENIZED));
                doc.Add(new Field("title", Convert.ToString(news.Title), Field.Store.YES, Field.Index.UN_TOKENIZED));
                doc.Add(new Field("content", Convert.ToString(news.Content), Field.Store.YES, Field.Index.TOKENIZED));
                doc.Add(new Field("keywords", Convert.ToString(news.Keywords), Field.Store.YES, Field.Index.UN_TOKENIZED));

                writer.AddDocument(doc);
                Console.WriteLine("created index for {0}:{1}", news.EntityIdentity, news.Title);
            }

            writer.Optimize();
            writer.Close();
        }


        public void DeleteIndex(List<ISearchEntity> DeleteEntities)
        {
            throw new NotImplementedException();
        }
    }
}
