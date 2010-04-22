using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.Member
{
    /// <summary>
    /// 实体类umScoreRule 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class ScoreRuleModel
    {
        public ScoreRuleModel()
        { }
        #region Model
        private string _actiontype;
        private int _score;
        private string _remark;
        private DateTime _inserttime;
        private DateTime _updatetime;
        /// <summary>
        /// 
        /// </summary>
        public string ActionType
        {
            set { _actiontype = value; }
            get { return _actiontype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Score
        {
            set { _score = value; }
            get { return _score; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime InsertTime
        {
            set { _inserttime = value; }
            get { return _inserttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        #endregion Model
    }
}