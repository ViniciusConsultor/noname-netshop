<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VoteList.aspx.cs" Inherits="NoName.NetShop.BackFlat.vote.VoteList" %>
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
        投票ID：<asp:TextBox runat="server" ID="txtVoteId"></asp:TextBox>
        &nbsp; 
        <asp:Button runat="server" Text="· 查询 ·" ID="btnSearch"
         onclick="btnSearch_Click" />&nbsp; &nbsp; 
        <a href="ModifyTopic.aspx">· 添加新投票 ·</a> 
        </div>
           <asp:GridView runat="server" ID="gvList" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="VoteId" HeaderText="投票ID" />            
                    <asp:BoundField DataField="Topic" HeaderText="题目" />
                   <asp:BoundField DataField="IsRegUser" HeaderText="仅会员" />
                    <asp:BoundField DataField="status" HeaderText="启用" />
                    <asp:BoundField DataField="ismulti" HeaderText="选项多选" />
                    <asp:BoundField DataField="VoteUserNum" HeaderText="已参加人数" />
                    <asp:BoundField DataField="StartTime" HeaderText="开始时间" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
                    <asp:BoundField DataField="EndTime" HeaderText="截至时间" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="HyperLinkShow" Text="查看" NavigateUrl='<%# "ShowVoteInfo.aspx?voteId="+Eval("VoteId") %>' />
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
