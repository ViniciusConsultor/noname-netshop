using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.Utility;
using System.Web.UI.HtmlControls;

namespace NoName.NetShop.BackFlat.Product
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int SelectedParentCategoryID = Convert.ToInt32(((HtmlInputHidden)CategorySelect1.FindControl("selectedCategory")).Value);

            string strErr = "";
            if (this.txtProductName.Text == "")
            {
                strErr += "ProductName不能为空！\\n";
            }
            if (this.txtProductCode.Text == "")
            {
                strErr += "ProductCode不能为空！\\n";
            }
            if (SelectedParentCategoryID == 0)
            {
                strErr += "CatePath不能为空！\\n";
            }
            if (!PageValidate.IsDecimal(txtTradePrice.Text))
            {
                strErr += "TradePrice不是数字！\\n";
            }
            if (!PageValidate.IsDecimal(txtMerchantPrice.Text))
            {
                strErr += "MerchantPrice不是数字！\\n";
            }
            if (!PageValidate.IsDecimal(txtReducePrice.Text))
            {
                strErr += "ReducePrice不是数字！\\n";
            }
            if (!PageValidate.IsNumber(txtStock.Text))
            {
                strErr += "Stock不是数字！\\n";
            }
            if (this.fulImage.FileName == "")
            {
                strErr += "SmallImage不能为空！\\n";
            }
            if (this.txtKeywords.Text == "")
            {
                strErr += "Keywords不能为空！\\n";
            }
            if (this.fckBrief.Value == "")
            {
                strErr += "Brief不能为空！\\n";
            }
            if (!PageValidate.IsNumber(drpStatus.SelectedValue))
            {
                strErr += "Status不是数字！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
        }
    }
}
