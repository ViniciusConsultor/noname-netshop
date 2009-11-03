using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.Common
{
    public class ShopException:Exception
    {
            private bool _isShow;

    public bool IsShowToClient
    {
        get { return _isShow; }
    }


    public ShopException()
        : base()
    {
        _isShow = false;
    }

    public ShopException(string message)
        : base(message)
    {
        _isShow = false;
    }

    public ShopException(string message, bool isShowToClient)
        : base(message)
    {
        _isShow = isShowToClient;
    }

    public ShopException(string message, Exception innerException, bool isShowToClient)
        : base(message, innerException)
    {
        _isShow = isShowToClient;
    }

    }
}
