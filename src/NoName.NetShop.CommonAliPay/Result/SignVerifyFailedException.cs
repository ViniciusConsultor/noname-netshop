using System;
using System.Collections.Generic;
using System.Text;

namespace NoName.NetShop.CommonAliPay.Result
{
    public class SignVerifyFailedException:CommonAliPayBaseException
    {
        public SignVerifyFailedException(int errCode)
            : base(errCode)
        { }
        public SignVerifyFailedException(string message, int errCode)
            : base(message, errCode)
        { }
        public SignVerifyFailedException()
            : base()
        { }
    }
}
