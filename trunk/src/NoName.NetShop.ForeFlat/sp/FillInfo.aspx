<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FillInfo.aspx.cs" Inherits="NoName.NetShop.ForeFlat.sp.FillInfo" %>
<%@ Register src="../uc/UserAddress.ascx" tagname="UserAddress" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">

    function check() {
        var $objs;
        var selval = -1;
        $objs = $("input[name$='rbtlPayMethod']");
        for (var i = 0; i < $objs.length; i++) {
            if ($objs[i].checked) {
                selval = $objs[i].value;
                break;
            }
        }
        if (selval == -1) {
            alert("请选择一个支付方式");
            return false;
        }
        selval = -1;
        $objs = $("input[name$='rbtlShipMethod']");
        for (var i = 0; i < $objs.length; i++) {
            if ($objs[i].checked) {
                selval = $objs[i].value;
                break;
            }
        }
        if (selval == -1) {
            alert("请选择一个配送方式");
            return false;
        }

       
        
         if (!ucaddress_checkAddr()) {
            return false;
        }
      
        
        return true;
    }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="#">首页</a> &gt;&gt; 填写信息
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="shoppingFillForm_mainbody clearfix newline">
    	<div class="box1">
            <ul class="title">
                <li class="left"></li>
                <li><span>填写信息</span></li>
                <li class="right"></li>
            </ul>
            <div class="content centerText">
            	<div class="shoppingNavigation3"></div>
				<div class="box6">
                    <div class="title">请填写收货人信息</div>
                    <div>
                    <uc1:UserAddress ID="ucAddress" runat="server" />
                    </div>
                    
                </div>
                <div class="box6 newline">
                    <div class="title">选择支付方式</div>
                    <div class="content">
                    <asp:RadioButtonList runat="server" ID="rbtlPayMethod" RepeatDirection="Horizontal" CssClass="form_h">
                    <asp:ListItem Text="在线支付" Value="1"></asp:ListItem>
                    <asp:ListItem Text="银行转账" Value="2"></asp:ListItem>
                    <asp:ListItem Text="邮局汇款" Value="3"></asp:ListItem>
                    <asp:ListItem Text="货到付款" Value="4"></asp:ListItem>
                    </asp:RadioButtonList>
                    </div>
                </div>
                <div class="box6 newline">
                    <div class="title">选择配送方式</div>
                    <div class="content">
                     <asp:RadioButtonList runat="server" ID="rbtlShipMethod" RepeatDirection="Horizontal" CssClass="form_h">
                    <asp:ListItem Text="EMS" Value="1"></asp:ListItem>
                    <asp:ListItem Text="快递" Value="2"></asp:ListItem>
                    <asp:ListItem Text="邮寄" Value="3"></asp:ListItem>
                    <asp:ListItem Text="上门安装" Value="4"></asp:ListItem>
                    </asp:RadioButtonList>

                    </div>
                </div>
                <div class="box6 newline">
                    <div class="title">发票</div>
                    <div class="content">
                    	<ul class="form_h">
                        	<li>
                                <input name="invoice"
                                 type="radio"
                                 class="radio"
                                 checked="checked"
                                 value="0"
                                 onclick="document.getElementById('invoiceTitle').disabled='disabled';document.getElementById('invoiceTitle').value='无'" 
                                />
                                <label>不需要</label>
                            </li>
                            <li class="autoWidth">
                                <input name="invoice"
                                 type="radio"
                                 class="radio"
                                 value="1"
                                 onclick="document.getElementById('invoiceTitle').disabled='';document.getElementById('invoiceTitle').value=document.getElementById('invoiceTitle').value=='无'?'':document.getElementById('invoiceTitle').value"
                                />
                                <label>需要</label>
                                <span class="field">发票抬头</span><input id="invoiceTitle" name="invoiceTitle" disabled="disabled" class="textField4" type="text" value="无" />
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="box6 newline">
                    <div class="title">特殊说明</div>
                    <div class="content">
                    	<ul class="form">
                        	<li>
                            	<div class="message">
                                    <span class="field">输入内容</span>
                                    <asp:TextBox runat="server" TextMode="MultiLine" ID="txtUserNotes" CssClass="textarea3"></asp:TextBox>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="centerText">
                    <div class="submitButtons">
                    <asp:LinkButton runat="server" ID="lbtnDoCreate" CssClass="button_blue3" 
                            onclick="lbtnDoCreate_Click" OnClientClick="javascript:return check();"><span class="left"></span>
                            <span class="text">提　交</span>
                            <span class="right"></span></asp:LinkButton>
                        <a class="button_blue3" href="ShowCart.aspx">
                            <span class="left"></span>
                            <span class="text">返　回</span>
                            <span class="right"></span>
                        </a>
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
