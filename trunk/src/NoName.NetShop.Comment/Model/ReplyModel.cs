using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.Comment
{
    [Serializable]
    public class ReplyModel
    {
        public ReplyModel()
        { }
        #region Model
        private int _topicid;
        private int _replyid;
        private string _title;
        private string _content;
        private DateTime _replytime;
        private string _userid;
        /// <summary>
        /// 
        /// </summary>
        public int TopicId
        {
            set { _topicid = value; }
            get { return _topicid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ReplyId
        {
            set { _replyid = value; }
            get { return _replyid; }
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
        public DateTime ReplyTime
        {
            set { _replytime = value; }
            get { return _replytime; }
        }

        public string UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        #endregion Model

    }
}
