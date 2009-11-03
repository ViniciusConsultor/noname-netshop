using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace NoName.NetShop.Common
{
    public class ValidateHelper
    {
        private static readonly string key = "ValidateCode";
        public string Code
        {
            get { return HttpContext.Current.Session[key] as string; }
            set { HttpContext.Current.Session[key] = value; }
        }

        public bool Validate(string vcode, bool ignoreCase)
        {
            if (String.IsNullOrEmpty(vcode) || String.IsNullOrEmpty(Code))
                return false;

            if (ignoreCase)
            {
                return vcode.ToLower() == Code.ToLower();
            }
            else
            {
                return vcode == Code;
            }
        }

        /*产生验证码*/
        public string CreateCode(int codeLength)
        {
            string so = "2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,m,n,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,Y,Z";
            string[] strArr = so.Split(',');
            string code = "";
            Random rand = new Random();
            for (int i = 0; i < codeLength; i++)
            {
                code += strArr[rand.Next(0, strArr.Length)];
            }
            Code = code;
            return code;
        }

    }

}
