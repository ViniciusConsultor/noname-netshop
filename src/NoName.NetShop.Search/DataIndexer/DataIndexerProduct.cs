using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Search.Entities;
using NoName.NetShop.Search.Config;
using Lucene.Net.Index;
using Lucene.Net.Documents;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Analysis;

namespace NoName.NetShop.Search.DataIndexer
{
    public class DataIndexerProduct : IDataIndexer
    {
        private SearchElement ConfigElement;
        public DataIndexerProduct(SearchElement Element)
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
                ProductModel product = (ProductModel)IndexEntity;

                Document doc = new Document();

                doc.Add(new Field("productid", Convert.ToString(product.EntityIdentity), Field.Store.YES, Field.Index.UN_TOKENIZED));
                doc.Add(new Field("productname", Convert.ToString(product.ProductName), Field.Store.YES, Field.Index.TOKENIZED));
                doc.Add(new Field("cateid", Convert.ToString(product.CategoryID), Field.Store.YES, Field.Index.UN_TOKENIZED));
                doc.Add(new Field("catepath", Convert.ToString(product.CategoryPath), Field.Store.YES, Field.Index.UN_TOKENIZED));
                doc.Add(new Field("keywords", Convert.ToString(product.Keywords), Field.Store.YES, Field.Index.TOKENIZED));
                doc.Add(new Field("description", Convert.ToString(product.Description), Field.Store.YES, Field.Index.TOKENIZED));
                doc.Add(new Field("price", Convert.ToString(product.Price), Field.Store.YES, Field.Index.UN_TOKENIZED));
                doc.Add(new Field("createtime", Convert.ToString(product.CreateTime), Field.Store.YES, Field.Index.UN_TOKENIZED));
                doc.Add(new Field("updatetime", Convert.ToString(product.UpdateTime), Field.Store.YES, Field.Index.UN_TOKENIZED));
                doc.Add(new Field("mainimage", Convert.ToString(product.ProductImage), Field.Store.YES, Field.Index.UN_TOKENIZED));

                writer.AddDocument(doc);
                Console.WriteLine("created index for {0}:{1}", product.EntityIdentity, product.ProductName);
            }

            writer.Optimize();
            writer.Close();
        }

        public void DeleteIndex(List<ISearchEntity> DeleteEntities)
        {
            IndexReader reader = IndexReader.Open(ConfigElement.IndexDirectory);

            foreach (ISearchEntity IndexEntity in DeleteEntities)
            {
                int Count = reader.DeleteDocuments(new Term("productid", IndexEntity.EntityIdentity.ToString()));
                Console.WriteLine("doc count:{0}, deleted document:{1}", reader.NumDocs(), Count);
            }

            reader.Close();
        }

        public void CreateSingleIndex(ISearchEntity IndexEntity)
        {
            Analyzer analyzer = new StandardAnalyzer();
            IndexWriter writer = new IndexWriter(ConfigElement.IndexDirectory, analyzer, false);

            ProductModel product = (ProductModel)IndexEntity;

            Document doc = new Document();

            doc.Add(new Field("productid", Convert.ToString(product.EntityIdentity), Field.Store.YES, Field.Index.UN_TOKENIZED));
            doc.Add(new Field("productname", Convert.ToString(product.ProductName), Field.Store.YES, Field.Index.TOKENIZED));
            doc.Add(new Field("cateid", Convert.ToString(product.CategoryID), Field.Store.YES, Field.Index.UN_TOKENIZED));
            doc.Add(new Field("catepath", Convert.ToString(product.CategoryPath), Field.Store.YES, Field.Index.UN_TOKENIZED));
            doc.Add(new Field("keywords", Convert.ToString(product.Keywords), Field.Store.YES, Field.Index.TOKENIZED));
            doc.Add(new Field("description", Convert.ToString(product.Description), Field.Store.YES, Field.Index.TOKENIZED));
            doc.Add(new Field("price", Convert.ToString(product.Price), Field.Store.YES, Field.Index.UN_TOKENIZED));
            doc.Add(new Field("createtime", Convert.ToString(product.CreateTime), Field.Store.YES, Field.Index.UN_TOKENIZED));
            doc.Add(new Field("updatetime", Convert.ToString(product.UpdateTime), Field.Store.YES, Field.Index.UN_TOKENIZED));
            doc.Add(new Field("mainimage", Convert.ToString(product.ProductImage), Field.Store.YES, Field.Index.UN_TOKENIZED));

            writer.AddDocument(doc);
            writer.Optimize();
            writer.Close(); 
        }

        public void DeleteSingleIndex(int ProductID)
        {
            IndexReader reader = IndexReader.Open(ConfigElement.IndexDirectory);
            int Count = reader.DeleteDocuments(new Term("productid", ProductID.ToString()));
            Console.WriteLine("deleted single document:{1}", reader.NumDocs(), Count);

            reader.Close();
        }
    }
}
