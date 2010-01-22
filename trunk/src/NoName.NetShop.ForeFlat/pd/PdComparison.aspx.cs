using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using NoName.NetShop.Common;
using NoName.NetShop.Product.Model;
using NoName.NetShop.Product.BLL;
using NoName.NetShop.ForeFlat.member.PawnShop;
using System.Web.UI.HtmlControls;

namespace NoName.NetShop.ForeFlat.pd
{
    public partial class PdComparison : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string pids = Request.QueryString["pid"];
                if (Regex.IsMatch(pids, @"(\d+,)+\d+"))
                {
                    ShowProducts(pids);
                }
                else
                {
                    throw new ShopException("传入的商品编号有误", true);
                }
            }
        }

        private void ShowProducts(string pids)
        {
            ProductModelBll pbll = new ProductModelBll();
            List<ProductModel> plist = pbll.GetModelList("productId in (" + pids + ")");

            string[] vals = (from p in plist select p.ProductName).ToArray();

            AddTH("<span>产品基本情况</span>",plist.Count +1);
            AddTR("商品名称", (from p in plist orderby p.ProductId select p.ProductName).ToArray(),true);
            AddTR("产品图片", (from p in plist orderby p.ProductId select "<img class='productPi' src='" + p.SmallImage + "'/>").ToArray(), false);
            AddTR("产品编号", (from p in plist orderby p.ProductId select p.ProductId.ToString()).ToArray(), false);
            AddTR("市场价", (from p in plist orderby p.ProductId select p.TradePrice.ToString("F2")).ToArray(), false);
            AddTR("鼎鼎价", (from p in plist orderby p.ProductId select p.MerchantPrice.ToString("F2")).ToArray(), false);
            AddTR("库存状态", (from p in plist orderby p.ProductId select p.Stock > 0 ? "现货" : "补货中").ToArray(), false);
            AddTH("<span>详细参数</span>", plist.Count + 1);

            int cateNum = (from p in plist select p.CateId).Distinct().ToArray().Length;
            if (cateNum > 1)
            {
                AddTR("商品不属于同一个分类，无法比较", plist.Count + 1);
            }
            else
            {
                int cateId = plist[0].CateId;

                CategoryParaModelBll pabll = new CategoryParaModelBll();
                List<CategoryParaModel> cplist = pabll.GetModelList("cateId=" + cateId);

                ProductParaModelBll ppabll = new ProductParaModelBll();
                List<ProductParaModel> ppalist = ppabll.GetModelList("productId in (" + pids + ")");

                foreach(CategoryParaModel cpmodel in cplist)
                {
                    string title = cpmodel.ParaName;
                    string[] pvals = (from p in ppalist where p.ParaId == cpmodel.ParaId orderby p.ProductId select p.ParaValue).ToArray();
                    AddTR(title, pvals, false);
                }
            }
        }

        
        private void AddTH(string title,int colspan)
        {
            HtmlTableRow tr = new HtmlTableRow();
            HtmlTableCell th = new HtmlTableCell("th");
            th.InnerHtml = title;
            th.ColSpan = colspan;
            tr.Cells.Add(th);
            tblProducts.Rows.Add(tr);
        }
        private void AddTR(string title, int colspan)
        {
            HtmlTableRow tr = new HtmlTableRow();
            HtmlTableCell td = new HtmlTableCell("td");
            td.InnerHtml = title;
            td.ColSpan = colspan;
            tr.Cells.Add(td);
            tblProducts.Rows.Add(tr);
        }

        private void AddTR(string cellname,string[] cellvals,bool isFirst)
        {
            HtmlTableRow tr = new HtmlTableRow();

            HtmlTableCell tdt = new HtmlTableCell();
            tdt.InnerHtml = cellname;
            if (isFirst)
                tdt.Attributes["class"] = "field";
            tr.Cells.Add(tdt);

            foreach (string val in cellvals)
            {
                HtmlTableCell td = new HtmlTableCell();
                td.InnerHtml = val;
                tr.Cells.Add(td);
            }
            tblProducts.Rows.Add(tr);
        }
    }
}
