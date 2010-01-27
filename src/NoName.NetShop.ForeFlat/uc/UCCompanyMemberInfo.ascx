<%@ Register src="~/uc/RegionSelect.ascx" tagname="RegionSelect" tagprefix="uc1" %>
<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="true" CodeBehind="UCCompanyMemberInfo.ascx.cs" Inherits="NoName.NetShop.ForeFlat.Member.UCCompanyMemberInfo" %>
<li><span class="field">公司名称：</span>
    <asp:TextBox ID="txtCompanyName" runat="server" CssClass="textField1"></asp:TextBox>
    <span class="tip"></span> </li>
<li><span class="field">所在地区：</span>
<uc1:RegionSelect ID="ucRegion" runat="server" />
&nbsp;</li>
<li><span class="field">详细地址：</span>
    <asp:TextBox ID="txtAddress" runat="server" CssClass="textField1"></asp:TextBox>
    <span class="tip"></span> </li>
<li><span class="field">电话号码：</span>
    <asp:TextBox ID="txtTelephone" runat="server" CssClass="textField1"></asp:TextBox>
    <span class="tip"></span> </li>
<li><span class="field">手机：</span>
    <asp:TextBox ID="txtMobile" runat="server" CssClass="textField1"></asp:TextBox>
    <span class="tip"></span> </li>
<li><span class="field">传真：</span>
    <asp:TextBox ID="txtFax" runat="server" CssClass="textField1"></asp:TextBox>
    <span class="tip"></span> </li>
<li><span class="field">身份证：</span>
    <asp:TextBox ID="txtIdCard" runat="server" CssClass="textField1"></asp:TextBox>
    <span class="tip"></span> </li>
