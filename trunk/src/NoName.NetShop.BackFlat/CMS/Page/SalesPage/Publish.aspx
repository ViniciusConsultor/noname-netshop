<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Publish.aspx.cs" Inherits="NoName.NetShop.BackFlat.CMS.Page.SalesPage.Publish" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="/css/cms.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jq.js"></script>
    <script type="text/javascript" src="/js/jq.msgbox.js"></script>
    <script type="text/javascript" src="/Controls/ckEditor/ckeditor.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <h4 runat="server" id="Label_PageTitle"></h4>
        [ <asp:HyperLink runat="server" ID="HyperLink1" Text="返回列表" NavigateUrl="~/Page/SalesPage/List.aspx" /> | 
        <asp:HyperLink runat="server" ID="Link_Preview" Text="预览地址" Target="_blank" /> | 
        <asp:HyperLink runat="server" ID="Link_Formal" Text="正式地址" Target="_blank" /> ]
        <br/>
        <div>
            <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false" CssClass="taglist">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox id="chkItem" disabled="true" runat="server" AutoPostBack="true" CssClass='<%# Convert.ToBoolean(Eval("ispublic"))?"invisible":"" %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="标签名称">
                        <ItemTemplate>
                            <a class="tag-name" style="cursor:pointer"><%# Eval("tagname")%></a>
                            <div style="display:none;"><img src='<%# Eval("examplepicture") %>' /></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="serverid" HeaderText="控件ID" />
                    <asp:BoundField DataField="tagid" HeaderText="标签ID" />
                </Columns>
            </asp:GridView>
        </div>
        <div runat="server" id="editWrap">
            
        </div>
        <asp:Button runat="server" ID="Button_Save" OnClick="Button_Save_Click" Text="保存" />
        <asp:Button runat="server" ID="Button_Publish" OnClick="Button_Publish_Click" Text="发布" />
    </form>
</body>
</html>
