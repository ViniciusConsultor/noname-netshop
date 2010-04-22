using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.News.Model
{
    public class NewsEvaluationModel
    {
        private int _NewsID;
        private string _UserID;
        private int _Evaluation;
        private DateTime _InsertTime;


        public int NewsID
        {
            get { return _NewsID; }
            set { _NewsID = value; }
        }
        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        public int Evaluation
        {
            get { return _Evaluation; }
            set { _Evaluation = value; }
        }
        public DateTime InsertTime
        {
            get { return _InsertTime; }
            set { _InsertTime = value; }
        }
    }
}
