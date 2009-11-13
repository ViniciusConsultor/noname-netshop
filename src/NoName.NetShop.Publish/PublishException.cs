using System;
using System.Collections.Generic;
using System.Text;

namespace NoName.NetShop.Publish
{
    [Serializable]
    public class PublishException : Exception
    {
        private bool _isShow;

        public bool IsShowToClient
        {
            get { return _isShow; }
        }


        public PublishException()
            : base()
        {
            _isShow = false;
        }

        public PublishException(string message)
            : base(message)
        {
            _isShow = false;
        }

        public PublishException(string message, bool isShowToClient)
            : base(message)
        {
            _isShow = isShowToClient;
        }

        public PublishException(string message, Exception innerException, bool isShowToClient)
            : base(message, innerException)
        {
            _isShow = isShowToClient;
        }
    }
}
