using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Globalization;

namespace NoName.Utility
{
    /// <summary>
    /// 中华人民共和国居民身份证
    /// </summary>
    public sealed class Idcard
    {
        [Flags]
        public enum VerifyMode { None = 0, CheckNumber = 1, Date = 2, Full = CheckNumber | Date }
        public static readonly Idcard None = new Idcard(VerifyMode.None);
        public static readonly Idcard CheckNumber = new Idcard(VerifyMode.CheckNumber);
        public static readonly Idcard Date = new Idcard(VerifyMode.Date);
        public static readonly Idcard Full = new Idcard(VerifyMode.Full);
        public VerifyMode Mode { get; private set; }
        public DateTime MaxDate { get; private set; }
        static readonly DateTime MinDate = new DateTime(1800, 1, 1);
        static readonly byte[] weight = { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
        static readonly string checkNumbers = "10X98765432";

        Idcard(VerifyMode mode) : this(mode, DateTime.MaxValue) { }

        public Idcard(VerifyMode mode, DateTime maxDate)
        {
            Mode = mode;
            MaxDate = maxDate;
        }

        public long String2Number(string s)
        {
            long n;
            string msg;
            if (!TryString2Number(s, out n, out msg)) throw new ArgumentOutOfRangeException(msg, (Exception)null);
            return n;
        }

        public string Number2String(long n)
        {
            return (n == 0) ? "" : (Math.Abs(n).ToString() + ((n < 0) ? "X" : ""));
        }

        public bool TryString2Number(string s, out long n, out string msg)
        {
            if ((msg = TryString2Number(s, out n)) == null) return true;
            msg = "身份证号(" + s + ")" + msg;
            return false;
        }

        string TryString2Number(string s, out long n)
        {
            n = 0;
            string msg;
            if ((msg = VerifyBase(s)) != null) return msg;
            if (Has(VerifyMode.CheckNumber) && (msg = VerifyCheckNumber(s)) != null) return msg;
            if (Has(VerifyMode.Date) && (msg = VerifyDate(s)) != null) return msg;
            Debug.Assert(s.Length == 15 || s.Length == 18);
            if (s.Length == 18 && !char.IsDigit(s, 17)) s = "-" + s.Substring(0, 17);
            n = long.Parse(s);
            return msg;
        }

        string VerifyBase(string s)
        {
            if (s.Length != 15 && s.Length != 18) return "必须是(15)或者(18)位";
            if (s[0] == '0') return "不能以零开头";
            for (int i = 0; i < s.Length; i++)
                if (i == 17 && !char.IsDigit(s, i) && s[i] != 'x' && s[i] != 'X') return "第(18)位必须是数字或者(x)或者(X)";
                else if (i != 17 && !char.IsDigit(s, i)) return "除第(18)位外必须是数字";
            return null;
        }

        string VerifyCheckNumber(string s)
        {
            Debug.Assert(s.Length == 15 || s.Length == 18);
            if (s.Length != 18 || char.ToUpper(s[17]) == GetCheckNumber(s)) return null;
            return "校验码错";
        }

        string VerifyDate(string s)
        {
            Debug.Assert(s.Length == 15 || s.Length == 18);
            var dateStr = (s.Length == 18) ? "" : ((int.Parse(s.Substring(12, 3)) > 995) ? "18" : "19");
            dateStr += s.Substring(6, 6 + ((s.Length == 18) ? 2 : 0));
            DateTime date;
            if (!DateTime.TryParseExact(dateStr, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date)) return "日期不合法";
            if (date < MinDate) return "日期太小";
            if (date > MaxDate) return "日期太大";
            return null;
        }

        char GetCheckNumber(string s)
        {
            Debug.Assert(s.Length == 18);
            var sum = 0;
            for (var i = 0; i < weight.Length; i++) sum += weight[i] * (s[i] - '0');
            return checkNumbers[sum % 11];
        }

        bool Has(VerifyMode mode)
        {
            return (Mode & mode) == mode;
        }
    }
}
