using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Search.Config;
using System.Configuration;
using NoName.NetShop.Search.Entities;
using NoName.NetShop.Search;
using NoName.NetShop.Search.Searchers;

namespace NoName.NetShop.ForeFlat.Search
{
    public partial class NewsSearch : System.Web.UI.Page
    {
        private static SearchSection Config = (SearchSection)ConfigurationManager.GetSection("searches");
        private string SearchWord
        {
            get { if (ViewState["SearchWord"] != null) return Convert.ToString(ViewState["SearchWord"]); else return String.Empty; }
            set { ViewState["SearchWord"] = value; }
        }
        private int PageIndex
        {
            get { if (ViewState["PageIndex"] != null) return Convert.ToInt32(ViewState["PageIndex"]); else return 1; }
            set { ViewState["PageIndex"] = value; }
        }
        private int PageSize
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["w"])) SearchWord = Request.QueryString["w"];
            if (!String.IsNullOrEmpty(Request.QueryString["p"])) PageIndex = Convert.ToInt32(Request.QueryString["p"]);

            if (String.IsNullOrEmpty(SearchWord)) throw new ArgumentNullException();

            BindData();
        }


        private void BindData()
        {
            int MatchCount = 0, PageCount = 0;

            List<NewsModel> SearchResult = GetSearchResult(out MatchCount, out PageCount);

            //Literal_SearchInfo.Text = String.Format("以{0}为检索词，共搜索到{1}条数据，共{2}页", SearchWord, MatchCount, PageCount);

            Repeater_NewsList.DataSource = SearchResult;
            Repeater_NewsList.DataBind();

            Pagination.InnerHtml = GetPaginateHtml(PageCount);
        }

        private List<NewsModel> GetSearchResult(out int MatchCount, out int PageCount)
        {
            SearchInfo InputInfo = new SearchInfo()
            {
                ConfigElement = Config.Searches["news"],
                PageIndex = PageIndex,
                PageSize = PageSize,
                QueryString = SearchWord
            };

            Searcher s = new NewsSearcher(InputInfo);
            List<ISearchEntity> RawResult = s.GetSearchResult(out MatchCount);


            //在这里排序



            List<NewsModel> SearchResult = new List<NewsModel>();
            int PageLowerBound = (InputInfo.PageIndex - 1) * PageSize;
            int PageUpperBound = PageLowerBound + PageSize;
            PageCount = (int)(MatchCount / PageSize) + 1;

            for (int i = 0; i < RawResult.Count; i++)
            {
                if (i > PageLowerBound && i <= PageUpperBound)
                {
                    SearchResult.Add((NewsModel)RawResult[i]);
                }
            }

            return SearchResult;
        }

        private string GetPaginateHtml(int PageCount)
        {
            string HtmlCode = String.Empty;

            if (PageIndex == 1)
                HtmlCode += "<a class=\"prev\"></a>";
            else
                HtmlCode += "<a class=\"prev\" style=\"cursor:pointer\" page=\"" + (PageIndex - 1) + "\"></a>";

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
                HtmlCode += "<a class=\"next\"></a>";
            else
                HtmlCode += "<a class=\"next\" style=\"cursor:pointer\" page=\"" + (PageIndex + 1) + "\"></a>";

            return HtmlCode;
        }
    }
}
