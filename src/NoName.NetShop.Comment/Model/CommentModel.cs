using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.Comment.Model
{
    public class CommentModel
    {
        private int _CommentID;
        private int _AppType;
        private int _TargetID;
        private string _UserID;
        private string _Content;
        private DateTime _CreateTime;

        public int CommentID
        {
            get { return _CommentID; }
            set { _CommentID = value; }
        }
        public int AppType
        {
            get { return _AppType; }
            set { _AppType = value; }
        }
        public int TargetID
        {
            get { return _TargetID; }
            set { _TargetID = value; }
        }
        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }
        public DateTime CreateTime
        {
            get { return _CreateTime; }
            set { _CreateTime = value; }
        }
    }
}
