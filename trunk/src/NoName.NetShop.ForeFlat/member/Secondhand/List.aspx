<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" MasterPageFile="~/MemberCenter.master" Inherits="NoName.NetShop.ForeFlat.member.Secondhand.List" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>



<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="headerContent">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContent" runat="server">
            	<div class="box1">
                <ul class="title">
                    <li class="left"></li>
                    <li><span>我添加的二手商品</span></li>
                    <li class="right"></li>
                </ul>
                <div class="content">
                    <div class="table1">
                        <table>
                          <tr>
                            <th><span>商品ID</span></th>
                            <th><span>商品名称</span></th>
                            <th><span>价格</span></th>
                            <th><span>数量</span></th>
                            <th><span>状态</span></th>
                            <th><span>操作</span></th>
                          </tr>
                          <asp:Repeater runat="server" ID="Repeater_SecondhandList">
                            <ItemTemplate>
                                  <tr>
                                    <td><%# Eval("SeProductID")%></td>
                                    <td><%# Eval("SeProductName")%></td>
                                    <td><%# Convert.ToDecimal(Eval("Price")).ToString("0.00") %></td>
                                    <td><%# Eval("Stock")%></td>
                                    <td><%# Enum.GetName(typeof(NoName.NetShop.MagicWorld.Model.SecondhandProductStatus), Eval("status"))%></td>
                                    <td>
                            	        <div class="inlineIconButton">
                            	        <a title="编辑" class="iconButton edit" href='<%# ((NoName.NetShop.MagicWorld.Model.SecondhandProductStatus)Enum.Parse(typeof(NoName.NetShop.MagicWorld.Model.SecondhandProductStatus), Eval("status").ToString())) == NoName.NetShop.MagicWorld.Model.SecondhandProductStatus.尚未审核 ? "Edit.aspx?productid="+Eval("AuctionId") : "javascript:alert(\"该二手信息已通过审核，禁止编辑\")" %>'></a>
                            	        </div>
                                    </td>
                                  </tr>
                            </ItemTemplate>
                          </asp:Repeater>
                          <tr>
                            <td colspan="6">
                            	<div class="floatLeft">
                                	<a class="button_blue3 inlineBlock" href="../CateSelect.aspx?app=Secondhand">
                                        <span class="left"></span>
                                        <span class="text">添加二手商品</span>
                                        <span class="right"></span>
                                    </a>
                                </div>
                                <div class="pagination floatRight">
                                    <cc1:AspNetPager CssClass="pagerclass" ID="AspNetPager" runat="server" PageSize="12"
                                        UrlPageIndexName="" AlwaysShow="true" ImagePath="/" FirstPageText='首页'
                                        LastPageText='末页' NextPageText='下一页'
                                        PrevPageText='上一页' ShowBoxThreshold="16" NumericButtonCount="8"
                                        ShowPrevNext="True" SubmitButtonClass="buttom" 
                                        NumericButtonTextFormatString=''>
                                    </cc1:AspNetPager>
                                </div>
                            </td>
                          </tr>
                        </table>
                    </div>
                </div>
                <ul class="bottom">
                   <li class="left"></li>
                   <li class="right"></li>
                </ul>
            </div>





<%--
    <a href="../CateSelect.aspx?app=Secondhand">添加二手商品</a>
    <div>
        <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="商品ID" DataField="SeProductID" />
                <asp:TemplateField  HeaderText="商品名称">
                    <ItemTemplate>
                        <%# Eval("SeProductName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="价格">
                    <ItemTemplate>
                        <%# Convert.ToDecimal(Eval("Price")).ToString("0.00") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="数量" DataField="Stock" />                
                <asp:TemplateField  HeaderText="状态">
                    <ItemTemplate>
                        <%# Eval("status")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href='<%# "Edit.aspx?pid="+Eval("SeProductID") %>'>编辑</a>
                        <asp:LinkButton runat="server" ID="Button_Delete" CommandArgument='<%# Eval("SeProductID") %>' CommandName="d" Text="删除" />
                    </ItemTemplate>
                </asp:TemplateField>
            
            </Columns>        
        </asp:GridView>
    </div>
    <div>
        <cc1:AspNetPager CssClass="pagerclass" ID="AspNetPager" runat="server" PageSize="12"
            UrlPageIndexName="" AlwaysShow="true" ImagePath="/" FirstPageText='首页'
            LastPageText='末页' NextPageText='下一页'
            PrevPageText='上一页' ShowBoxThreshold="16" NumericButtonCount="8"
            ShowPrevNext="True" SubmitButtonClass="buttom" 
            NumericButtonTextFormatString=''>
        </cc1:AspNetPager>
    </div>
--%>
</asp:Content>