using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;
using NoName.NetShop.ShopFlow.Config;

namespace NoName.NetShop.ShopFlow
{
    [Serializable]
    public class BaseCart
    {
        private string _key;
        private int _serial;

        public void SetSteps(string key)
        {
            _key = key;
            ShopStepSection section = ConfigurationManager.GetSection("shopping/steps") as ShopStepSection;
            _steps = new LinkedList<ShopStepInfoElement>();

            foreach (ShopStepInfoElement step in section.Steps[key].StepInfos)
            {
                _steps.AddLast(step);
            }
        }

        public int GetSerial()
        {
            return _serial++;
        }



        public string Key
        {
            get { return _key; }
        }

        #region 流程控制
        internal LinkedList<ShopStepInfoElement> _steps;
        internal LinkedListNode<ShopStepInfoElement> currentStep;

        /// <summary>
        /// 购物车所处的当前流程位置
        /// </summary>
        public ShopStepInfoElement CurrentShopStep
        {
            get { return currentStep.Value; }
        }

        /// <summary>
        /// 转至下一步
        /// </summary>
        public void GoNext()
        {
            currentStep = currentStep.Next;
            HttpContext.Current.Response.Redirect(currentStep.Value.Url);
        }
        /// <summary>
        /// 转至上一步
        /// </summary>
        public void GoPrev()
        {
            currentStep = currentStep.Previous;
            HttpContext.Current.Response.Redirect(currentStep.Value.Url);
        }
        /// <summary>
        /// 转至开始位置
        /// </summary>
        public void GoFirst()
        {
            currentStep = _steps.First;
            HttpContext.Current.Response.Redirect(currentStep.Value.Url);
        }

        /// <summary>
        /// 设置为下一步，但不跳转
        /// </summary>
        public void SetNext()
        {
            currentStep = currentStep.Next;
        }

        /// <summary>
        /// 设置为下一步，但不跳转
        /// </summary>
        public void SetPrev()
        {
            currentStep = currentStep.Previous;
        }        
        

        // 检查是否允许进入当前步骤，如果当前页面地址跟订单所处步骤地址不一致时，则返回false
        public bool ValidStep()
        {
            return HttpContext.Current.Request.RawUrl.ToLower().EndsWith(currentStep.Value.Url.ToLower());
        }

        /// <summary>
        /// 复位流程
        /// </summary>
        public void Reset()
        {
            currentStep = _steps.First;
        }

        #endregion 


    }
}
