using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NoName.NetShop.Member.Model;
using NoName.NetShop.Member.BLL;
using NoName.NetShop.Member;

namespace NoName.NetShop.ForeFlat.UC
{
    public partial class UserAddress : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

         public void ShowAddressList(string userId)
        {
            AddressBll bll = new AddressBll();

            List<AddressModel> list = bll.GetModelList(userId);
            if (list.Count == 0)
            {
                panAddrList.Visible = false;
                panNewAddr.Style.Add(HtmlTextWriterStyle.Display, "block");
                this.Page.ClientScript.RegisterStartupScript(this.GetType(),"shownewaddress","showNewAddr();",true);
            }
            else
            {
                panAddrList.Visible = true;
                panNewAddr.Style.Add(HtmlTextWriterStyle.Display, "none");

                this.rpAddrList.DataSource = list;
                rpAddrList.DataBind();
            }
        }

         public AddressModel GetSelectedAddressInfo(string userId)
         {
             AddressBll bll = new AddressBll();
             AddressModel model = null;
             int addrId = String.IsNullOrEmpty(Request.Form["addrId"]) ? 0 : int.Parse(Request.Form["addrId"]);
             if (addrId == 0)
             {
                 model = this.AddAddressInfo(userId);
             }
             else
             {
                 model = bll.GetModel(addrId);
             }
             return model;
         }

         public AddressModel AddAddressInfo(string userId)
         {
             AddressModel info = new AddressModel();
             info.AddressId = 0;
             info.UserId = userId;
             info.RecieverName = Request.Form["ucaddress_username"].Trim();
             info.Postalcode =Request.Form["ucaddress_postalcode"].Trim();
             info.Email = Request.Form["ucaddress_email"].Trim();
             info.AddressDetail =  Request.Form["ucaddress_address"].Trim();

             RegionInfo regionInfo = ucRegion.GetSelectedRegionInfo();
             info.RegionPath = regionInfo.RegionPath;
             info.Country = regionInfo.Country;
             info.Province = regionInfo.Province;
             info.City = regionInfo.City;
             info.County = regionInfo.County;

             info.Telephone = Request.Form["ucaddress_phone"].Trim();
             info.Mobile = Request.Form["ucaddress_mobile"].Trim();

             if (String.IsNullOrEmpty(info.AddressDetail) || String.IsNullOrEmpty(info.RecieverName)
                 || String.IsNullOrEmpty(info.Country) || String.IsNullOrEmpty(info.Province) || String.IsNullOrEmpty(info.City)
                 || String.IsNullOrEmpty(info.Postalcode) || String.IsNullOrEmpty(info.UserId) || String.IsNullOrEmpty(info.Email) ||
                 (String.IsNullOrEmpty(info.Telephone) && String.IsNullOrEmpty(info.Mobile)))
             {
                 // throw new Exception("地址信息不全");
                 return null;
             }

             AddressBll bll = new AddressBll();
             bll.Save(info);
             return info;
         }

    }
}