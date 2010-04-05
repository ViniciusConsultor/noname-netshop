using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace NoName.Utility
{
    public class StringUtility
    {
        /// <summary>
        /// 替换掉字符串中的 ',",\,<,>
        /// </summary>
        /// <param name="instr">输入的字符串</param>
        /// <returns></returns>
        public static string HtmlReplaceLimitedChar(string instr)
        {
            StringBuilder tempStr = new StringBuilder(instr);
            tempStr.Replace("'", "&#39;");
            tempStr.Replace("\"", "&#34;");
            tempStr.Replace("\\", "&#92;");
            tempStr.Replace("<", "&lt;");
            tempStr.Replace(">", "&gt;");
            tempStr.Replace("&", "&amp;");
            return tempStr.ToString();
        }

        /// <summary>
        /// 格式化数据为JSON
        /// </summary>
        /// <param name="sIn"></param>
        /// <returns></returns>
        public static string SafeJSON(string sIn)
        {
            StringBuilder sbOut = new StringBuilder(sIn.Length);
            foreach (char ch in sIn)
            {
                if (Char.IsControl(ch) || ch == '\'')
                {
                    int ich = (int)ch;
                    sbOut.Append(@"\u" + ich.ToString("x4"));
                    continue;
                }
                else if (ch == '\"' || ch == '\\' || ch == '/')
                {
                    sbOut.Append('\\');
                }
                sbOut.Append(ch);
            }
            return sbOut.ToString();
        }

        /// <summary>
        /// 剔除输入
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string FilterScript(string content)
        {
            string regexstr=@"<script[^>]*>([\s\S](?!<script))*?</script>";
            return Regex.Replace(content,regexstr,string.Empty,RegexOptions.IgnoreCase);
        }
        public static string FilterStyle(string content)
        {
            string regexstr = @"<style[^>]*>([\s\S](?!<style))*?</style>";
            return Regex.Replace(content, regexstr, string.Empty, RegexOptions.IgnoreCase);
        }
        public static string FilterLink(string content)
        {
            string regexstr = @"<link[^>]*>([\s\S](?!<link))*?</link>";
            return Regex.Replace(content, regexstr, string.Empty, RegexOptions.IgnoreCase);
        }


        /// <summary>
        /// 验证输入的字符串是否为邮件格式
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool ValidEmailFormat(string instr)
        {
            string regstr = @"^[\w\.-]+@([\w-]+\.)+[a-zA-Z]{2,4}$";
            return Regex.IsMatch(instr,regstr,RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 验证输入的字符串是否为手机号
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool ValidMobileFormat(string instr)
        {
            string regstr = @"^1\d{10}$";
            return Regex.IsMatch(instr, regstr, RegexOptions.IgnoreCase);
        }

         /// <summary>
        /// 验证输入的字符串是否为手机号
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool ValidPostalCodeFormat(string instr)
        {
            string regstr = @"^\d{6}$";
            return Regex.IsMatch(instr, regstr, RegexOptions.IgnoreCase);
        }
        
        /// <summary>
        /// 验证输入的字符串是否为电话格式，区号-号码-分机
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool ValidPhoneFormat(string instr)
        {
            string regstr = @"^\d{3,5}-\d{7,8}(-\d{1,5})?$";
            return Regex.IsMatch(instr, regstr, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 比较md5签名
        /// </summary>
        /// <param name="inputstr"></param>
        /// <param name="signstr"></param>
        /// <returns></returns>
        public static bool ValidateMd5Sign(string inputstr, string signstr)
        {
            byte[] data = System.Text.Encoding.Default.GetBytes(inputstr);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(data);
            string resultCode = System.BitConverter.ToString(result).Replace("-", "").ToLower();
            return (signstr.ToLower() == resultCode);
        }

        /// <summary>
        /// 获得输入字符串的md5签名，去除“-”，并转为小写格式
        /// </summary>
        /// <param name="inputstr"></param>
        /// <returns></returns>
        public static string GetMd5Sign(string inputstr)
        {
            byte[] data = System.Text.Encoding.Default.GetBytes(inputstr);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(data);
            string resultCode = System.BitConverter.ToString(result).Replace("-", "").ToLower();
            return resultCode;
        }

        /// <summary>
        /// 比较md5签名
        /// </summary>
        /// <param name="inputstr"></param>
        /// <param name="signstr"></param>
        /// <returns></returns>
        public static bool ValidateMd5Sign(string inputstr, string signstr,Encoding encode)
        {
            byte[] data = encode.GetBytes(inputstr);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(data);
            string resultCode = System.BitConverter.ToString(result).Replace("-", "").ToLower();
            return (signstr.ToLower() == resultCode);
        }

        /// <summary>
        /// 获得输入字符串的md5签名，去除“-”，并转为小写格式
        /// </summary>
        /// <param name="inputstr"></param>
        /// <returns></returns>
        public static string GetMd5Sign(string inputstr,Encoding encode)
        {
            byte[] data = encode.GetBytes(inputstr);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(data);
            string resultCode = System.BitConverter.ToString(result).Replace("-", "").ToLower();
            return resultCode;
        }

        public static string RemoveHtmlTags(string HTMLStr)
        {
            return System.Text.RegularExpressions.Regex.Replace(HTMLStr, "<[^>]*>", "");
        }


    }
}
