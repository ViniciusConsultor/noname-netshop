<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" ValidateRequest="false" Inherits="NoName.NetShop.BackFlat.CMS.Publish.Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script src="/js/cms.edit.js" type="text/javascript"></script>
    <link href="/css/cms.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView CssClass="tagGrid" runat="server" ID="GridView1" AutoGenerateColumns="false">
                <Columns>                
                    <asp:TemplateField>
                        <ItemTemplate>
    	                    <asp:CheckBox id="chkItem" runat="server" AutoPostBack="true"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="serverid" HeaderText="控件ID" />
                    <asp:BoundField DataField="tagid" HeaderText="控件类型" />
                    <asp:BoundField DataField="Description" HeaderText="控件描述" />
                </Columns>
            </asp:GridView>
        </div>
        <div id="editWrap" runat="server">
        </div>
        <asp:Button Height="30" style="font-size:14px;" Width="100" ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
        <asp:Button Height="30" style="font-size:14px;" Width="100" ID="Button2" runat="server" Text="发布" onclick="Button2_Click" />
        <a runat="server" target="_blank" id="previewLink">预览</a>
    </form>
</body>
</html>
