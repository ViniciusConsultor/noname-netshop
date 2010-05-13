using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Search.Entities;
using NoName.NetShop.Search.Config;
using System.Configuration;
using NoName.NetShop.Search;
using NoName.NetShop.Search.Searchers;
using NoName.Utility;
using System.Text;
using NoName.NetShop.CMS.Controler;

namespace NoName.NetShop.ForeFlat.Search
{
    public partial class ProductSearch : System.Web.UI.Page
    {
        private static SearchSection Config = (SearchSection)ConfigurationManager.GetSection("searches");
        private string SearchWord
        {
            get { if (ViewState["SearchWord"] != null) return Convert.ToString(ViewState["SearchWord"]); else return String.Empty; }
            set { ViewState["SearchWord"] = value; }
        }
        private int SearchCategory 
        {
            get { if (ViewState["SearchCategory"] != null) return Convert.ToInt32(ViewState["SearchCategory"]); else return 0; }
            set { ViewState["SearchCategory"] = value; }
        }
        private int PageIndex
        {
            get { if (ViewState["PageIndex"] != null) return Convert.ToInt32(ViewState["PageIndex"]); else return 1; }
            set { ViewState["PageIndex"] = value; }
        }
        private int SortValue
        {
            get { if (ViewState["SortValue"] != null) return Convert.ToInt32(ViewState["SortValue"]); else return 1; }
            set { ViewState["SortValue"] = value; }
        }
        private int PageSize
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["w"])) SearchWord = Request.QueryString["w"];
            if (!String.IsNullOrEmpty(Request.QueryString["c"])) SearchCategory = Convert.ToInt32(Request.QueryString["c"]);
            if (!String.IsNullOrEmpty(Request.QueryString["p"])) PageIndex = Convert.ToInt32(Request.QueryString["p"]);
            if (!String.IsNullOrEmpty(Request.QueryString["o"])) SortValue = Convert.ToInt32(Request.QueryString["o"]);

            if (String.IsNullOrEmpty(SearchWord)) throw new ArgumentNullException();

            BindData();
            DivLeft.InnerHtml = GetLeftHtmlCode();
        }

        private void BindData()
        {
            int MatchCount = 0,PageCount = 0;

            List<ProductModel> SearchResult = GetSearchResult(out MatchCount, out PageCount);

            Literal_SearchInfo.Text = String.Format("以\"{0}\"为检索词，共搜索到{1}条数据，共{2}页", SearchWord, MatchCount, PageCount);

            Repeater_ProductList.DataSource = SearchResult;
            Repeater_ProductList.DataBind();

            

            Pagination.InnerHtml = GetPaginateHtml(PageCount);
        }

        private List<ProductModel> GetSearchResult(out int MatchCount, out int PageCount)
        {
            SearchInfo InputInfo = new SearchInfo()
            {
                ConfigElement = Config.Searches["product"],
                PageIndex = PageIndex,
                PageSize = PageSize,
                QueryString = SearchWord,
                Category = SearchCategory,
                sortType = GetSortType()
            };

            Searcher s = new ProductSearcher(InputInfo);
            List<ISearchEntity> RawResult = s.GetSearchResult(out MatchCount);

            //在这里排序
            if (IsOrderDesc()) RawResult.Reverse();

            List<ProductModel> SearchResult = new List<ProductModel>();
            int PageLowerBound = (InputInfo.PageIndex - 1) * PageSize;
            int PageUpperBound = PageLowerBound + PageSize;
            PageCount = (int)(MatchCount / PageSize) + 1;

            for (int i = 0; i < RawResult.Count; i++)
            {
                if (i >= PageLowerBound && i <= PageUpperBound)
                {
                    SearchResult.Add((ProductModel)RawResult[i]);
                }
            }

            return SearchResult; 
        }

        private string GetPaginateHtml(int PageCount)
        {
            string HtmlCode = String.Empty;

            if (PageIndex == 1)
                HtmlCode+="<a class=\"prev\"></a>";
            else
                HtmlCode += "<a class=\"prev\" style=\"cursor:pointer\" page=\"" + (PageIndex-1) + "\"></a>";
            
            int i = 0;
            HtmlCode += "<div class=\"pageNum\">";
            for (i = PageIndex - 5; i <= PageIndex + 5; i++)
            {
                if (i > 0 && i <= PageCount)
                {
                    if (i == PageIndex)//当前页
                    {
                        HtmlCode += "<a class=\"on\" style=\"cursor:pointer\">" + i + "</a>";
                    }
                    else
                    {
                        HtmlCode += "<a style=\"cursor:pointer\" page=\"" + i + "\">" + i + "</a>";
                    }
                }
            }
            HtmlCode += "</div>";

            if (PageIndex == PageCount)
                HtmlCode+="<a class=\"next\"></a>";
            else
                HtmlCode += "<a class=\"next\" style=\"cursor:pointer\" page=\"" + (PageIndex + 1) + "\"></a>";

            return HtmlCode;
        }


        private string GetLeftHtmlCode()
        {
            string HtmlCode = String.Empty;

            HtmlCode += TagControler.TagContentGet(1, 1, "cmsTag3");
            HtmlCode += TagControler.TagContentGet(1, 1, "cmsTag4");

            return HtmlCode;
        }

        private SortType GetSortType()
        {
            switch (SortValue)
            {
                case 0:
                    return SortType.None;
                case 1:
                    return SortType.UpdateTime;
                case 3:
                    return SortType.Sales;
                case 5:
                    return SortType.Price;
                case 7:
                    return SortType.Views;
                default:
                    return SortType.None;
            }
        }

        private bool IsOrderDesc()
        {
            return SortValue > 0 && SortValue % 2 == 0;
        }
    }
}
