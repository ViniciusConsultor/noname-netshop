<%@ Page Title="" Language="C#" MasterPageFile="~/MemberCenter.master" AutoEventWireup="true" CodeBehind="MyLevel.aspx.cs" Inherits="NoName.NetShop.ForeFlat.member.MyLevel" %>
<%@ Import Namespace="NoName.NetShop.Member" %>


<asp:Content runat="server" ID="Content3" ContentPlaceHolderID="topContent">    
    	您现在的位置: <a href="/">首页</a> &gt;&gt; 
    	<a href="/member/myorders.aspx">我的鼎鼎</a> &gt;&gt; 
    	<a href="#">我的级别</a>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContent" runat="server">
            <div class="rightColumnContainer">
            	<div class="box1">
                <ul class="title">
                    <li class="left"></li>
                    <li><span>我的级别</span></li>
                    <li class="right"></li>
                </ul>
                <div class="content">
                  <p>我的级别:<strong>
                  <asp:Literal runat="server" ID="litUserLevel"></asp:Literal>
                  </strong>&nbsp;&nbsp;</p>
                  <div class="sheet1">
                    <p><strong>会员介绍</strong><br />
                    <asp:Panel runat="server" ID="panPersonLevel1" Visible='<%# CurrentUser.UserType == MemberType.Personal %>'>
                      享有优先购物权 —— 对国内少见的优秀产品或者其它比较紧俏的产品具有优先购买权。 <br />
                      运费优惠政策(单张订单重量在10公斤（含）以上，不适用于本规则，将按实际运费收取) 地区 金牌会员 <br />
                      一区 北京（含郊县）、上海（包括外环以外的郊区，除三岛地区）、广州市 单张订单金额满200元（含）以上的快递运输运费全免；单张订单金额不足200元的，收取快递运输费5元 <br />
                      二区 江苏、浙江、安徽、天津、山东、广西、湖南、江西、海南、河南、广东（除广州外）、河北、福建、辽宁、山西、黑龙江、吉林 单张订单金额满200元（含）以上的，快递运输运费全免；单张订单金额不足200元的，收取快递运输运费6元 <br />
                      三区 甘肃、湖北、四川、重庆、新疆、陕西、云南、内蒙、贵州、宁夏、西藏、青海 单张订单金额满800（含）以上快递运输运费全免；单张订单金额不足800元收取快递运输运费15元 </p>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="Panel1" Visible='<%# CurrentUser.UserType == MemberType.Company %>'>
                      享有优先购物权 —— 对国内少见的优秀产品或者其它比较紧俏的产品具有优先购买权。 <br />
                      运费优惠政策(单张订单重量在10公斤（含）以上，不适用于本规则，将按实际运费收取) 地区 金牌会员 <br />
                      一区 北京（含郊县）、上海（包括外环以外的郊区，除三岛地区）、广州市 单张订单金额满200元（含）以上的快递运输运费全免；单张订单金额不足200元的，收取快递运输费5元 <br />
                      二区 江苏、浙江、安徽、天津、山东、广西、湖南、江西、海南、河南、广东（除广州外）、河北、福建、辽宁、山西、黑龙江、吉林 单张订单金额满200元（含）以上的，快递运输运费全免；单张订单金额不足200元的，收取快递运输运费6元 <br />
                      三区 甘肃、湖北、四川、重庆、新疆、陕西、云南、内蒙、贵州、宁夏、西藏、青海 单张订单金额满800（含）以上快递运输运费全免；单张订单金额不足800元收取快递运输运费15元 </p>
                    </asp:Panel>
                    
                    
                    <p>享有一年两次的特别针对金牌会员抽奖的权利（时间大致为每年的 6月18日和年终) <br />
                      不定期举办个别产品针对金牌会员的优惠活动。 <br />
                      享有支付66元DIY装机服务费的权利。</p>
                      
                      <div >
                      <asp:DropDownList runat="server" ID="ddlUserType">
                      <asp:ListItem Text="个人会员" Value="1"></asp:ListItem>
                      <asp:ListItem Text="鼎企会员" Value="2"></asp:ListItem>
                      <asp:ListItem Text="鼎宅会员" Value="3"></asp:ListItem>
                      <asp:ListItem Text="鼎校会员" Value="4"></asp:ListItem>
                     </asp:DropDownList>
                     
                      <asp:LinkButton runat="server" ID="lbtnChangeType" CssClass="button_blue2" 
                              onclick="lbtnChangeType_Click">我要转换</asp:LinkButton>
                      <asp:DropDownList runat="server" ID="ddlUserLevel">
                      <asp:ListItem Text="登鼎会员" Value="0"></asp:ListItem>
                      <asp:ListItem Text="铁鼎会员" Value="1"></asp:ListItem>
                      <asp:ListItem Text="铜鼎会员" Value="2"></asp:ListItem>
                      <asp:ListItem Text="银鼎会员" Value="3"></asp:ListItem>
                      <asp:ListItem Text="金鼎会员" Value="4"></asp:ListItem>
                      <asp:ListItem Text="宝鼎会员" Value="5"></asp:ListItem>
                     </asp:DropDownList>                      
                     <asp:LinkButton runat="server" ID="lbtnUpLevel" CssClass="button_blue2" 
                              onclick="lbtnUpLevel_Click">我要升级</asp:LinkButton>
                      </div>
                  </div>
                </div>
                <ul class="bottom">
                   <li class="left"></li>
                   <li class="right"></li>
                </ul>
            </div>
            </div>
</asp:Content>
