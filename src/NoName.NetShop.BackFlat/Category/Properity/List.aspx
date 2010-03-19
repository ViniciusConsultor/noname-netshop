<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="NoName.NetShop.BackFlat.Category.Properity.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .left{width:200px;}
        .iframe{width:500px;margin-left:10px;}
        .iframe iframe{width:500px;}
        .control a{display:block;padding:2px 5px;height:18px;line-height:18px;border:1px solid #eee;float:left;margin:2px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="left">
                <asp:TreeView ID="TreeView1" runat="server" ShowLines="True" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" SelectedNodeStyle-Font-Underline="True">
                    <SelectedNodeStyle Font-Underline="True" Font-Bold="True" ForeColor="#990033"/>
                    <NodeStyle Font-Underline="True" ForeColor="#003399" />
                </asp:TreeView>        
            </div>
            <div class="left iframe">
                <p><b>属性列表</b></p>
                <p class="control"><asp:LinkButton runat="server" ID="Button_AddPara" OnClick="Button_AddPara_Click" Text="添加属性" /></p>
                <p>
                    <asp:Label runat="server" ID="Label_Informer"></asp:Label>
                    <asp:GridView CssClass="GridView" runat="server" ID="GridView1" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="属性ID" DataField="ParaId" />
                            <asp:BoundField HeaderText="属性名称" DataField="ParaName" />
                            <asp:TemplateField HeaderText="状态">
                                <ItemTemplate>
                                    <%# Convert.ToInt32(Eval("status"))==1?"正常":"锁定" %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="类型">
                                <ItemTemplate>
                                    <%# Enum.GetName(typeof(NoName.NetShop.Product.Model.CategoryParameterType),Eval("paratype")) %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="属性值">
                                <ItemTemplate>
                                    <%# Convert.ToString(Eval("ParaValues")).Length > 10 ? Convert.ToString(Eval("ParaValues")).Substring(0, 10) : Convert.ToString(Eval("ParaValues"))%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <a href='<%# "Edit.aspx?pid=" + Eval("ParaId") + "&cid=" + Eval("cateid") %>'>编辑</a>
                                    <asp:LinkButton runat="server" ID="Button_Delete" Text="删除" CommandArgument='<%# Eval("ParaId") %>' CommandName="d" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>    
                </p>            
            </div>    
        </div>
    </form>
</body>
</html>
