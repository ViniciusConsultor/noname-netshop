using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.News.DAL;
using NoName.NetShop.News.Model;
using System.Data;

namespace NoName.NetShop.News.BLL
{
    public class NewsEvaluationModelBll
    {
        private NewsEvaluationModelDal dal = new NewsEvaluationModelDal();

        public void Add(NewsEvaluationModel model)
        {
            dal.Add(model);
        }

        public void Update(NewsEvaluationModel model)
        {
            dal.Update(model);
        }

        public void Delete(int NewsID,string UserID)
        {
            dal.Delete(NewsID,UserID);
        }

        public NewsEvaluationModel GetModel(int NewsID,string UserID)
        {
            return dal.GetModel(NewsID,UserID);
        }

        public DataTable StatisticList(int NewsID)
        {
            Dictionary<int, int> List = new Dictionary<int, int>();
            DataTable StatisticTable = new DataTable();
            StatisticTable.Columns.Add("newsid");
            StatisticTable.Columns.Add("evaluation");
            StatisticTable.Columns.Add("evaluationcount");

            DataTable dt =GetListOfNews(NewsID);

            for (int i = 1; i <= 4; i++)
            {                
                DataRow StatisticRow = StatisticTable.NewRow();
                StatisticRow["newsid"] = NewsID;
                StatisticRow["evaluation"] = i;

                if (dt.Select("evaluation = " + i).Length > 0)
                    StatisticRow["evaluationcount"] = dt.Select("evaluation = " + i).Length;
                else
                    StatisticRow["evaluationcount"] = 0;


                StatisticTable.Rows.Add(StatisticRow);
            }

            return StatisticTable;
        }

        public bool Exists(int NewsID, string UserID)
        {
            return dal.Exists(NewsID, UserID);
        }

        public DataTable GetListOfNews(int NewsID)
        {
            return dal.GetListOfNews(NewsID);
        }

    }
}
