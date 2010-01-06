using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Common;

namespace NoName.NetShop.Comment
{
    [Serializable]
    public class QuestionModel
    {
        public QuestionModel()
        { }
        #region Model
        private int _questionid;
        private string _userid;
        private int _contentid;
        private string _title;
        private string _content;
        private DateTime _inserttime;
        private DateTime? _lastanswertime;
        private int _lastanswerid;
        private int _answernum;

        public ContentType ContentType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int QuestionId
        {
            set { _questionid = value; }
            get { return _questionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ContentId
        {
            set { _contentid = value; }
            get { return _contentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
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
        public DateTime? LastAnswerTime
        {
            set { _lastanswertime = value; }
            get { return _lastanswertime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int LastAnswerId
        {
            set { _lastanswerid = value; }
            get { return _lastanswerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AnswerNum
        {
            set { _answernum = value; }
            get { return _answernum; }
        }
        #endregion Model

    }
}
