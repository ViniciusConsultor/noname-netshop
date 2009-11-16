<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserAddress.ascx.cs" Inherits="SinaEC.Shopping.WebUI.UC.UserAddress" %>
		<%@ Register src="RegionSelect.ascx" tagname="RegionSelect" tagprefix="uc1" %>
		<script type="text/javascript">
function showNewAddr() {
    $('.shipaddr').show();
    InitRegions();
}

function hideNewAddr() {
    $('.shipaddr').hide();
}

function ucaddress_checkAddr() {
    if ($("input[name='addrId']").length > 0 && $("input[name='addrId']:checked").length == 0) {
        alert("请选择一个送货地址或者添加一个新的送货地址");
        return false;
    }
    
    if ($("input[name='addrId']").length==0 || $("input[name='addrId']:checked").val() == "0") {
        var regpostal = /^\d{6}$/
        var regmobile = /^1\d{10}$/
        var regemail = /^[\w\.-]+@([\w-]+\.)+[a-zA-Z]{2,4}$/
        var regphone = /^\d{3,5}-\d{7,8}(-\d{1,5})?$/
        
        if ($("#ucaddress_username").val() == "") {
            $("ucaddress_username_tip").text("收货人姓名不能为空");
            $("#ucaddress_username").focus();
            alert("收货人姓名不能为空");
            return false;
        }


        if ($("#ucaddress_phone").val() == "" && $("#ucaddress_mobile").val() == "") {
            $("#ucaddress_mobile_tip").text("手机和电话至少输入一个");
            $("#ucaddress_phone").focus();
            alert("手机和电话至少输入一个");
            return false;
        }

        if ($("#ucaddress_phone").val() != "") {
            if (!regphone.test($("#ucaddress_phone").val())) {
                $("#ucaddress_phone_tip").text("电话输入有误，格式要求为：区号-电话号码-分机号");
                $("#ucaddress_phone").focus();
                alert("电话号码输入有误，格式要求为：区号-电话号码-分机号");
                return false;
            }
        }

        if ($("#ucaddress_mobile").val() != "") {
            if (!regmobile.test($("#ucaddress_mobile").val())) {
                $("#ucaddress_mobile_tip").text("手机号码输入有误");
                $("#ucaddress_mibile").focus();
                alert("手机号码输入有误");
                return false;
            }
        }

        if ($("#ucaddress_postalcode").val() == "") {
            $("#ucaddress_postalcode_tip").text("邮编不能为空");
            $("#ucaddress_postalcode").focus();
            alert("邮编不能为空");
            return false;
        } 
        if (regpostal.test($("#ucaddress_postalcode").val()) == false) {
            $("#ucaddress_postalcode_tip").text("邮编需要为6位数字");
            $("#ucaddress_postalcode").focus();
            alert("邮编需要为6位数字");
            return false;
        }
        if ($("#ucaddress_email").val() == "") {
            $("ucaddress_email_tip").text("收货人邮箱地址不可以为空");
            $("#ucaddress_email").focus();
            alert("收货人邮箱地址不可以为空");
            return false;
        }
        
        if (regemail.test($("#ucaddress_email").val()) == false) {
            $("#ucaddress_email_tip").text("需要为有效的邮箱地址");
            $("#ucaddress_email").focus();
            alert("需要为有效的邮箱地址");
            return false;
        }
        
        if (!regionValideSelect()) {
            alert("必须选择地域");
            return false;
        }

        if ($("#ucaddress_address").val() == "") {
            $("#ucaddress_address_tip").text("地址不能为空");
            $("#ucaddress_address").focus();
            alert("地址不能为空");
            return false;
        }
        
        

    }
    return true;
}

</script>
	<div class="pd10" runat="server" id="panAddrList">
	<asp:Repeater runat="server" id="rpAddrList">
	<ItemTemplate>
		<p class="pd5">
		<input type="radio"name="addrId" value="<%# Eval("AddressId") %>"  onclick="hideNewAddr()" /><%# Eval("FullAddress") %></p>

	</ItemTemplate>
	<FooterTemplate>
		<p class="pd5"><input type="radio" name="addrId" value="0" onclick="showNewAddr()" />新建地址</p>
	</FooterTemplate>
	</asp:Repeater>
	</div>
	
	<div class="plr30 shipaddr" id="panNewAddr" runat="server">
                    <div class="content">
                    	<ul class="form">
                        	<li>
                            	<span class="field">姓名</span>
                            	<input id="ucaddress_username" name="ucaddress_username" type="text" class="textField1" maxlength="20" />
		<span class="tip" id="ucaddress_username_tip">请填写您的真实姓名</span>
                            </li>
                            <li>
                            	<span class="field">电话</span>
                            	<input id="ucaddress_phone" name="ucaddress_phone"  type="text"  class="textField1" maxlength="30"/>
	  <span class="tip" id="ucaddress_phone_tip">格式：区号-电话号码-分机号</span>
                            </li>
                            <li>
                            	<span class="field">手机</span>
                                <input id="ucaddress_mobile" name="ucaddress_mobile" type="text" class="textField1" maxlength="11" />
	  <span class="tip" id="ucaddress_mobile_tip">电话和手机二选一</span>
                            </li>
                            <li>
                            	<span class="field">邮政编码</span>
                                <input id="ucaddress_postalcode" name="ucaddress_postalcode"  type="text" maxlength="6" class="textField1" />
                                <span class="tip" id="ucaddress_postalcode_tip"></span>
                            </li>
                            <li>
                            	<span class="field">邮箱地址</span>
                                <input id="ucaddress_email" name="ucaddress_email" type="text" class="textField1" maxlength="50" />
                                <span class="tip" id="ucaddress_email_tip"></span>
                            </li>                            
                            <li>
                            	<span class="field">所在地区</span>
                            	<uc1:RegionSelect ID="ucRegion" runat="server" />
                            </li>
                            <li>
                            	<span class="field">详细地址</span>
                                <input id="ucaddress_address" name="ucaddress_address" class="textField2" type="text" maxlength="60" />
                                <span class="tip" id ="ucaddress_address_tip">送货详细地址</span>
                            </li>

                        </ul>
                    </div>
	</div>
