using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Member;

namespace NoName.NetShop.ForeFlat.Member
{
    public partial class UCCompanyMemberInfo : System.Web.UI.UserControl, IShowExtentInfo
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ShowInfo(MemberInfo userInfo)
        {
            CompanyMemberInfo model = userInfo as CompanyMemberInfo;
            if (model != null)
            {
                this.txtIdCard.Text = model.IdCard;
                this.txtCompanyName.Text = model.CompanyName;
                this.ucRegion.PresetRegionInfo(model.RegionPath);
                this.txtMobile.Text = model.Mobile;
                this.txtTelephone.Text = model.Telephone;
                this.txtFax.Text = model.Fax;
                this.txtAddress.Text = model.Address;
            }
        }

        public void SwitchReadOnly(bool isReadOnly)
        {
            foreach (Control cont in Controls)
            {
                if (cont is TextBox)
                {
                    ((TextBox)cont).ReadOnly = isReadOnly;
                }
            }
        }


        public void GetInputInfo(MemberInfo userInfo)
        {
            CompanyMemberInfo model = userInfo as CompanyMemberInfo;
            if (model != null)
            {
                model.CompanyName = txtCompanyName.Text.Trim();
                model.IdCard = txtIdCard.Text.Trim();
                model.Telephone = txtTelephone.Text.Trim();
                model.Mobile = txtMobile.Text.Trim();
                model.Fax = txtFax.Text.Trim();

                RegionInfo regionInfo = ucRegion.GetSelectedRegionInfo();
                model.RegionPath = regionInfo.RegionPath;
                model.Country = regionInfo.Country;
                model.Province = regionInfo.Province;
                model.City = regionInfo.City;
                model.County = regionInfo.County;
                model.Address = txtAddress.Text.Trim();
            }
        }

    }
}