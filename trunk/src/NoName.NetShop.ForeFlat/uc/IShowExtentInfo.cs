using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Member;

namespace NoName.NetShop.ForeFlat.Member
{
    interface IShowExtentInfo
    {
        void SwitchReadOnly(bool isReadOnly);
        void ShowInfo(MemberInfo userInfo);
        void GetInputInfo(MemberInfo userInfo);
    }
}
