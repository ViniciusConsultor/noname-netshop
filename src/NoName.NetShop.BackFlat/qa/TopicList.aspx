<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TopicList.aspx.cs" Inherits="NoName.NetShop.BackFlat.qa.TopicList" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <div id="data-list">
        <div>
        问题ID：<asp:TextBox runat="server" ID="txtUserId"></asp:TextBox>
        &nbsp; 
        <asp:Button runat="server" Text="· 查询 ·" ID="btnSearch"
         onclick="btnSearch_Click" />&nbsp; &nbsp; 
        </div>
           <asp:GridView runat="server" ID="gvList" AutoGenerateColumns="false" 
               onrowcommand="gvList_RowCommand">
                <Columns>
                    <asp:BoundField DataField="TopicId" HeaderText="ID" />            
                    <asp:BoundField DataField="UserId" HeaderText="发起人" />
                   <asp:BoundField DataField="Title" HeaderText="标题" />
                    <asp:BoundField DataField="InsertTime" HeaderText="发起时间"  DataFormatString="{0:yyyy-MM-dd HH:mm}"/>
                    <asp:BoundField DataField="ReplyNum" HeaderText="回复数" />
                    <asp:BoundField DataField="LastReplyTime" HeaderText="最近回复时间" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="HyperLinkShow" Text="查看" NavigateUrl='<%# "ShowTopic.aspx?tid="+Eval("TopicId") %>' />
                            <asp:LinkButton runat="server" ID="lbtnDelete" Text="删除" CommandName="del" CommandArgument='<%#Eval("TopicId") %>'></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="LinkButton1" Text='<%# Convert.ToBoolean(Eval("status"))?"禁止":"允许" %>' CommandName="toggle" CommandArgument='<%#Eval("TopicId")%>' ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div id="page">
            <cc1:AspNetPager  ID="pageNav" runat="server" PageSize="12"
                UrlPageIndexName="" AlwaysShow="true" ImagePath="/" FirstPageText='首页'
                LastPageText='末页' NextPageText='下一页'
                PrevPageText='上一页' ShowBoxThreshold="16" NumericButtonCount="8"
                ShowPrevNext="True" SubmitButtonClass="buttom" 
                NumericButtonTextFormatString='' onpagechanged="pageNav_PageChanged">
            </cc1:AspNetPager>
        </div>
    </div>
    </form>
</body>
</html>
