<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RentApply.aspx.cs" MasterPageFile="~/Site.Master" Inherits="NoName.NetShop.ForeFlat.Magic.RentApply" %>
<%@ Register src="/uc/RegionSelect.ascx" tagname="RegionSelect" tagprefix="uc1" %>

<asp:Content ID="ContentHeader" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="/css/magic.css" />
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="cpMain" runat="server">
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="/">首页</a> &gt;&gt; <a href="/channel/magic">魔力世界</a> &gt;&gt; <a href="/Magic/RentHome.aspx">视听租赁</a> &gt;&gt; <a href="#">提交租赁</a>
        <div class="magicSubNav">
            <div class="magicButtonTab">
                <a class="button_blue2" href="/Magic/RentHome.aspx">视听租赁</a>
                <a class="button_blue" href="/Magic/DealHome.aspx">二手交易</a>
                <a class="button_blue" href="/Magic/PawnShop.aspx">视听当铺</a>
                <a class="button_blue" href="/Magic/AuctionHome.aspx">视听拍卖</a>
            </div>
        </div>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="magicRentSubmit_mainbody clearfix newline">
        <div class="box1">
            <div class="content">
                <div class="box7">
                    <div class="title">请认真填写个人信息</div>
                        <div class="content" id="Div_ApplyContent" runat="server">
                    	    <ul class="form">
                                <li>
                            	    <span class="field">租赁时间</span>
                            	    <asp:DropDownList runat="server" ID="DropDown_RentTime"></asp:DropDownList>月
                                    <span class="tip"></span>
                                </li>
                                <li>
                            	    <span class="field">姓名</span>
                                    <asp:TextBox runat="server" ID="TextBox_TrueName" CssClass="textField1" />
                                    <span class="tip">请填写您的真实姓名</span>
                                </li>
                                <li>
                            	    <span class="field">电话</span>
                                    <asp:TextBox runat="server" ID="TextBox_Phone" CssClass="textField1" />
                                    <span class="tip">格式：区号 - 电话号码 - 分机号</span>
                                </li>
                                <li>
                            	    <span class="field">手机</span>
                                    <asp:TextBox runat="server" ID="TextBox_CellPhone" CssClass="textField1" />
                                </li>
                                <li>
                            	    <span class="field">邮政编码</span>
                                    <asp:TextBox runat="server" ID="TextBox_PostCode" CssClass="textField1" />
                                </li>
                                <li>
                            	    <span class="field">所在地区</span>
                            	    <uc1:RegionSelect ID="ucRegion" runat="server" />
                                    <span class="tip">请选择所在地区</span>
                                </li>
                                <li>
                            	    <span class="field">详细地址</span>
                                    <asp:TextBox runat="server" ID="TextBox_Address" CssClass="textField1" />
                                </li>
                                <li class="submit">
                                    <asp:LinkButton runat="server" ID="Button_Add" Text="提　交" OnClick="Button_Add_Click" CssClass="button_blue" />
                                </li>
                            </ul>
                        </div>
                    </div>                
            </div>
            <ul class="bottom">
               <li class="left"></li>
               <li class="right"></li>
            </ul>
        </div>                
    </div>
    <!--MainBody End-->
</asp:Content>