using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Solution.BLL;
using NoName.NetShop.Solution.Model;
using NoName.NetShop.Product.Model;
using NoName.NetShop.Product.BLL;
using System.Data;
using System.Text.RegularExpressions;
using NoName.NetShop.Common;

namespace NoName.NetShop.BackFlat.Solution
{
    public partial class ShowClassicalDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int cateId = int.Parse(Request.QueryString["cid"]);
                int scenceId = int.Parse(Request.QueryString["sid"]);
                ShowInfo(scenceId,cateId);
            }
        }

        private void ShowInfo( int scenceId,int cateId)
        {
            SolutionCategoryBll scbll = new SolutionCategoryBll();
            SolutionCategoryModel scmodel = scbll.GetModel(scenceId, cateId);
            CategoryModelBll cbll = new CategoryModelBll();
            CategoryModel cmodel = cbll.GetModel(cateId);
            if (cmodel == null)
            {
                throw new NoName.NetShop.Common.ShopException("分类不存在", true);
            }

            InitConditionItems(cateId);

            if (scmodel != null)
            {
                lblCateId.Text = scmodel.CateId.ToString();
                lblSenceId.Text = scmodel.SenceId.ToString();
                chkIsShow.Checked = scmodel.IsShow;
                txtRemark.Text = scmodel.Remark;
                txtPosition.Text = scmodel.Position;

                if (!String.IsNullOrEmpty(scmodel.CateImage))
                {
                    this.imgCate.Visible = true;
                    this.imgCate.ImageUrl = Common.CommonImageUpload.GetCommonImageFullUrl(scmodel.CateImage);
                }
                else
                {
                    this.imgCate.Visible = false;
                }
                PresetConditionItems(scenceId, cateId);
            }
            else
            {
                lblCateId.Text = cmodel.CateId.ToString();
                lblSenceId.Text = scenceId.ToString();
                txtRemark.Text = cmodel.CateName;
            }

            
        }

        private void PresetConditionItems(int scenceId, int cateId)
        {
            CategoryConditionBll ccbll = new CategoryConditionBll();
            List<CategoryConditionModel> cclist = ccbll.GetModelList(scenceId, cateId);
            foreach (CategoryConditionModel ccmodel in cclist)
            {
                if (ccmodel.IsPrice) // 如果是价格：between 0 and 100
                {
                    string regPrice = @"between (?<min>\d+) and (?<max>\d+)";
                    Match match = Regex.Match(ccmodel.RuleValue, regPrice, RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        if (match.Groups["min"].Success)
                            txtMinPrice.Text = match.Groups["min"].Value;
                        if (match.Groups["max"].Success)
                            txtMaxPrice.Text = match.Groups["max"].Value;
                    }
                }
                else if (ccmodel.IsBrand) // 如果是品牌: in (0,2,3,4)
                {
                    string[] sels = ccmodel.RuleValue.Substring(3).TrimEnd(')').Split(',');
                    foreach (string str in sels)
                    {
                        ListItem item = cblBrands.Items.FindByValue(str);
                        if (item != null)
                        {
                            item.Selected = true;
                        }
                    }
                }
                else if (ccmodel.IsSubCategory) // 如果是子分类（最终分类）：in (2,3,4)
                {
                    string[] sels = ccmodel.RuleValue.Substring(3).TrimEnd(')').Split(',');
                    foreach (string str in sels)
                    {
                        ListItem item = cblSubCate.Items.FindByValue(str);
                        if (item != null)
                        {
                            item.Selected = true;
                        }
                    }
                }
                else if (ccmodel.IsParameter)
                {
                    string paraidreg = @"paraid=(?<paraid>\d+)";
                    Match match = Regex.Match(ccmodel.RuleName, paraidreg, RegexOptions.IgnoreCase);
                    if (match.Success && match.Groups["paraid"].Success)
                    {
                        string paraid = match.Groups["paraid"].Value;
                        foreach (RepeaterItem item in rpItems.Items)
                        {
                            Label lblPropName = item.FindControl("lblPropName") as Label;
                            CheckBoxList cblPara = item.FindControl("cblPara") as CheckBoxList;
                            if (lblPropName.ToolTip == paraid)
                            {
                                foreach (ListItem citem in cblPara.Items)
                                {
                                    citem.Selected = ccmodel.RuleValue.IndexOf("'" + citem.Value + "'") >= 0;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void InitConditionItems(int cateId)
        {
            BrandCategoryRelationBll bcrbll = new BrandCategoryRelationBll();
            
            this.cblBrands.DataSource =  bcrbll.GetCategoryBrandList(cateId);
            this.cblBrands.DataTextField = "BrandName";
            this.cblBrands.DataValueField = "BrandId";
            this.cblBrands.DataBind();

            NoName.NetShop.Product.BLL.CategoryModelBll cbll = new CategoryModelBll();
            this.cblSubCate.DataSource = cbll.GetSubCategory(cateId);
            this.cblSubCate.DataTextField = "CateName";
            this.cblSubCate.DataValueField = "CateId";
            this.cblSubCate.DataBind();


            CategoryParaModelBll cpbll = new CategoryParaModelBll();
            List<CategoryParaModel> plist = cpbll.GetModelList("status=1 and paratype=1 and cateid=" + cateId);
            rpItems.DataSource = plist;
            rpItems.DataBind();
        }

        protected void rpItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblPropName = e.Item.FindControl("lblPropName") as Label;
                CheckBoxList cblPara = e.Item.FindControl("cblPara") as CheckBoxList;
                CategoryParaModel cpmodel = e.Item.DataItem as CategoryParaModel;
                lblPropName.Text = cpmodel.ParaName;
                lblPropName.ToolTip = cpmodel.ParaId.ToString();
                cblPara.DataSource = cpmodel.ParaValues.Split(',');
                cblPara.DataBind();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SolutionCategoryBll scbll = new SolutionCategoryBll();
            int scenceId = int.Parse(lblSenceId.Text);
            int cateId = int.Parse(lblCateId.Text);
            SolutionCategoryModel scmodel = scbll.GetModel(scenceId, cateId);
            if (scmodel == null)
            {
                scmodel = new SolutionCategoryModel();
                scmodel.CateId = cateId;
                scmodel.SenceId = scenceId;
            }
            scmodel.IsShow = chkIsShow.Checked;
            scmodel.Remark = txtRemark.Text.Trim();
            scmodel.Position = txtPosition.Text.Trim();
            string fullurl, shorturl, message;
            if (CommonImageUpload.Upload(this.fulImage, out fullurl, out shorturl, out message))
            {
                scmodel.CateImage = shorturl;
            }

            scbll.Save(scmodel);
            SaveCateConditions();
            Response.Redirect("ShowClassicalScence.aspx?id=" + scenceId,true);
                               
        }

        private void SaveCateConditions()
        {
            CategoryConditionBll ccbll = new CategoryConditionBll();
            CategoryConditionModel pmodel =null;
            int scenceId = int.Parse(lblSenceId.Text);
            int cateId = int.Parse(lblCateId.Text);
            pmodel = GetPriceCondition(scenceId, cateId);
            if (pmodel != null)
            {
                ccbll.Save(pmodel);
            }
            pmodel = GetBrandCondition(scenceId, cateId);
            if (pmodel != null)
            {
                ccbll.Save(pmodel);
            }
            pmodel = GetSubCondition(scenceId, cateId);
            if (pmodel != null)
            {
                ccbll.Save(pmodel);
            }

            foreach (RepeaterItem item in rpItems.Items)
            {
                pmodel = GetParaCondition(scenceId, cateId, item);
                if (pmodel != null)
                {
                    ccbll.Save(pmodel);
                }
            }
   
        }

        private CategoryConditionModel GetPriceCondition(int scenceId,int cateId)
        {
            CategoryConditionModel ccmodel = null;
             int maxprice, minprice;
            if (!int.TryParse(txtMaxPrice.Text, out maxprice))
            {
                maxprice = int.MaxValue;
            }
            if (!int.TryParse(txtMinPrice.Text, out minprice))
            {
                minprice = 0;
            }

            if (minprice > 0 || maxprice < int.MaxValue)
            {
                ccmodel = new CategoryConditionModel(scenceId, cateId, maxprice, minprice);
            }
            return ccmodel;
       }

        private CategoryConditionModel GetBrandCondition(int scenceId, int cateId)
        {
            CategoryConditionModel ccmodel = null;
            List<string> selvals = new List<string>();
            foreach(ListItem item in cblBrands.Items)
            {
                if (item.Selected)
                    selvals.Add(item.Value);
            }
            if (selvals.Count > 0)
            {
                string selbrans = String.Join(",",selvals.ToArray());
                ccmodel = new CategoryConditionModel(scenceId, cateId,"brandid",selbrans );
            }
            return ccmodel;
        }

        private CategoryConditionModel GetSubCondition(int scenceId, int cateId)
        {
            CategoryConditionModel ccmodel = null;
            List<string> selvals = new List<string>();
            foreach (ListItem item in cblSubCate.Items)
            {
                if (item.Selected)
                    selvals.Add(item.Value);
            }
            if (selvals.Count > 0)
            {
                string selsubids = String.Join(",", selvals.ToArray());
                ccmodel = new CategoryConditionModel(scenceId, cateId, "cateid" ,selsubids);
            }
            return ccmodel;
        }

        private CategoryConditionModel GetParaCondition(int scenceId, int cateId, RepeaterItem item)
        {
            CategoryConditionModel ccmodel = null;
            Label lblPropName = item.FindControl("lblPropName") as Label;
            CheckBoxList cblPara = item.FindControl("cblPara") as CheckBoxList;
            List<string> selvals = new List<string>();
            foreach (ListItem sitem in cblPara.Items)
            {
                if (sitem.Selected)
                    selvals.Add("'" + sitem.Value + "'");
            }
            if (selvals.Count > 0)
            {
                string rulvals = String.Join(",", selvals.ToArray());
                ccmodel = new CategoryConditionModel(scenceId, cateId, int.Parse(lblPropName.ToolTip), rulvals);
            } 
            return ccmodel;
        }
    }
}
