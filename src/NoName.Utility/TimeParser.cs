using System;
using System.Collections.Generic;
using System.Text;

namespace NoName.Utility
{
    public class TimeParser
    {
        /// <summary>
        /// ����ת���ɷ���
        /// </summary>
        /// <returns></returns>
        public static int SecondToMinute(int Second)
        {
            decimal mm = (decimal)((decimal)Second / (decimal)60);
            return Convert.ToInt32(Math.Ceiling(mm));           
        }
    }
}
