<%@ Page Title="" Language="C#" MasterPageFile="~/MemberCenter.master" AutoEventWireup="true" CodeBehind="Complaint.aspx.cs" Inherits="NoName.NetShop.ForeFlat.member.Complaint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContent" runat="server">
        	<div class="rightColumnContainer">
            	<div class="box1 noPadding">
                <ul class="title">
                    <li class="left"></li>
                    <li><span>我的投诉</span></li>
                    <li class="right"></li>
                </ul>
                <div class="content">
                	<div class="section padding">
                        <div class="table1">
                            <table>
                              <tr>
                                <th><span>投诉主题</span></th>
                                <th><span>投诉对象</span></th>
                                <th><span>涉及订单</span></th>
                                <th><span>投诉时间</span></th>
                                <th><span>鼎鼎回复</span></th>
                              </tr>
                              <tr>
                                <td>text</td>
                                <td>text</td>
                                <td>text</td>
                                <td>text</td>
                                <td>text</td>
                              </tr>
                              <tr>
                                <td>text</td>
                                <td>text</td>
                                <td>text</td>
                                <td>text</td>
                                <td>text</td>
                              </tr>
                            </table>
                        </div>
                    </div>
                    <div class="section noPadding">
                        <div class="titleBar1">提交我的投诉</div>
                    </div>
                    <div class="section padding">
                    	<ul class="form">
                        	<li>
                            	<span class="field">投诉对象</span>
                                <div class="component">
									<script type="text/javascript">
                                        var complaintObj=new RainySelectBox();
                                        complaintObj.boxName="complaintObj";
                                        complaintObj.fire="click";
                                        complaintObj.name="complaintObj";
                                        complaintObj.id="complaintObj";
                                        complaintObj.width=120;
                                        complaintObj.listMaxHeight=300;
                                        complaintObj.selectedClass="commonSelectBox_currentOption";
                                        complaintObj.listClass="commonSelectBox_list";
                                        complaintObj.addOption("选择对象","0","Selected");
                                        complaintObj.addOption("客服002","1");
                                        complaintObj.addOption("客服003","2");
                                        complaintObj.show();
                                    </script>
                                </div>

                            	<span class="field">投诉类别</span>
                                <div class="component">
									<script type="text/javascript">
                                        var complaintType=new RainySelectBox();
                                        complaintType.boxName="complaintType";
                                        complaintType.fire="click";
                                        complaintType.name="complaintType";
                                        complaintType.id="complaintType";
                                        complaintType.width=120;
                                        complaintType.listMaxHeight=300;
                                        complaintType.selectedClass="commonSelectBox_currentOption";
                                        complaintType.listClass="commonSelectBox_list";
                                        complaintType.addOption("选择类别","0","Selected");
                                        complaintType.addOption("客服态度","1");
                                        complaintType.addOption("售后服务","2");
                                        complaintType.show();
                                    </script>
                                </div>

                            	<span class="field">涉及订单</span>
                                <div class="component">
									<script type="text/javascript">
                                        var relatedSheet=new RainySelectBox();
                                        relatedSheet.boxName="relatedSheet";
                                        relatedSheet.fire="click";
                                        relatedSheet.name="relatedSheet";
                                        relatedSheet.id="relatedSheet";
                                        relatedSheet.width=120;
                                        relatedSheet.listMaxHeight=300;
                                        relatedSheet.selectedClass="commonSelectBox_currentOption";
                                        relatedSheet.listClass="commonSelectBox_list";
                                        relatedSheet.addOption("选择订单","0","Selected");
                                        relatedSheet.addOption("订单002","1");
                                        relatedSheet.addOption("订单003","2");
                                        relatedSheet.show();
                                    </script>
                                </div>
                            </li>
                            <li>
                            	<span class="field">投诉主题</span>
                                <input class="textField3" />
                            </li>
                            <li>
                            	<span class="field">投诉内容</span>
                                <textarea class="textarea3"></textarea>
                            </li>
                            <li class="submit">
                            	<a class="button_blue" href="#">提交投诉</a>
                            </li>
                        </ul>
                    </div>
                </div>
                <ul class="bottom">
                   <li class="left"></li>
                   <li class="right"></li>
                </ul>
            </div>
            
            </div></asp:Content>
