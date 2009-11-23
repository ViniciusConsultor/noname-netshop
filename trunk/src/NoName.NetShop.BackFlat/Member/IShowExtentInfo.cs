using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.BackFlat.Member
{
    interface IShowExtentInfo
    {
        void SwitchReadOnly(bool isReadOnly);
        void ShowInfo(string userid);
    }
}
