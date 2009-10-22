﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MemberCenter.master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="NoName.NetShop.ForeFlat.member.MyProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContent" runat="server">
        	<div class="rightColumnContainer">
            	<div class="box1">
                <ul class="title">
                    <li class="left"></li>
                    <li><span>个人资料</span></li>
                    <li class="right"></li>
                </ul>
                <div class="content">
                    <ul class="form">
                        <li>
							<span class="field">用 户 名：</span>
                            <span>Rainy</span>
                        </li>
                        <li>
							<span class="field">用户姓名：</span>
                            <input type="text" class="textField1" />
                            <span class="tip">请填写您的真实姓名</span>
                        </li>
                        <li>
							<span class="field">用户类型：</span>
                            <div class="component">
								<script type="text/javascript">
                                    var userTypeBox=new RainySelectBox();
                                    userTypeBox.boxName="userTypeBox";
                                    userTypeBox.fire="click";
                                    userTypeBox.name="userType";
                                    userTypeBox.id="userType";
                                    userTypeBox.width=100;
                                    userTypeBox.listMaxHeight=300;
                                    userTypeBox.selectedClass="commonSelectBox_currentOption";
                                    userTypeBox.listClass="commonSelectBox_list";
                                    userTypeBox.addOption("普通用户","0","Selected");
                                    userTypeBox.addOption("VIP用户","1");
                                    userTypeBox.addOption("钻石代理","2");
                                    userTypeBox.show();
                                </script>
                            </div>
                        </li>
                        <li>
							<span class="field">电子邮箱：</span>
                            <input type="text" class="textField1" />
                        </li>
                        <li>
							<span class="field">固定电话：</span>
                            <input type="text" class="textField1" />
                            <span class="tip">格式：区号 - 电话号码 - 分机号</span>
                        </li>
                        <li>
							<span class="field">手机号码：</span>
                            <input type="text" class="textField1" />
                        </li>
                        <li>
							<span class="field">备 用 号：</span>
                            <input type="text" class="textField1" />
                        </li>
                        <li>
							<span class="field">具体地址：</span>
                            <input type="text" class="textField2" />
                        </li>
                        <li>
							<span class="field">身份证号：</span>
                            <input type="text" class="textField1" />
                        </li>
                        <li>
							<span class="field">收货地址：</span>
                            <input type="text" class="textField2" />
                            <span class="tip">收货详细地址</span>
                        </li>
                        <li>
							<span class="field">邮政编码：</span>
                            <input type="text" class="textField1" />
                        </li>
                        <li>
							<span class="field">个人说明：</span>
                            <textarea></textarea>
                        </li>
                        <li class="submit">
                        	<a class="button_blue" href="#">保　存</a>
                        </li>
                    </ul>
                </div>
                <ul class="bottom">
                   <li class="left"></li>
                   <li class="right"></li>
                </ul>
            </div>
            </div>
</asp:Content>
