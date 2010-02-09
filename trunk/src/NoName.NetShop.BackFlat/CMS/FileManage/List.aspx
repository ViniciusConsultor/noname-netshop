<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="NoName.NetShop.BackFlat.CMS.FileManage.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../../css/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">      
            
        table.GridView{width:700px;border:1px solid #eee;}
        table.GridView th{padding:.5em;height:24px;line-height:24px;border:1px solid #eee;}
        table.GridView td{padding:.3em;border:1px solid #eee;}
        table.GridView td a{color:#1e51a4;}
        table.GridView td a:hover{color:#b10103;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <a href="Add.aspx">添加文件</a>
        <asp:Label runat="server" ID="Label_ServerPhysicalPath" />
        <div>
            <asp:GridView CssClass="GridView" runat="server" ID="GridView1" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderStyle-Width="20">
                        <ItemTemplate>
                            <img src="<%# GetFileLogo(Eval("suffix").ToString()) %>" alt="<%# Eval("suffix") %>" style="width:18px;height:18px;"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="文件名" Visible="false">
                        <ItemTemplate>
                            <%# Eval("FileName") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="文件名" HeaderStyle-Width="440">
                        <ItemTemplate>
                            <asp:LinkButton Visible='<%# Convert.ToInt32(Eval("type"))==1?false:true %>' CommandArgument='<%# Eval("fullname") %>' CommandName="dir" runat="server" ID="Button_Dir" Text='<%# Eval("FileName") %>' />
                            <a target="_blank" href='<%# Eval("url") %>' style="display:<%# Convert.ToInt32(Eval("type"))==1?"inline":"none" %>"><%# Eval("FileName") %></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="大小(Kb)" DataField="Size" HeaderStyle-Width="80"/>
                    <asp:TemplateField HeaderText="最后修改日期" HeaderStyle-Width="140">
                        <ItemTemplate>
                            <%# Convert.ToInt32(Eval("type"))==3?"--":Convert.ToDateTime(Eval("LastWriteTime")).ToString("yyyy-MM-dd hh:mm:ss")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="" HeaderStyle-Width="20">
                        <ItemTemplate>
                            <asp:ImageButton Enabled='<%# Convert.ToInt32(Eval("type"))==3?false:true %>' Width="18" Height="18" runat="server" ID="Button_Delete" ImageUrl='<%# Convert.ToInt32(Eval("type"))==3?"/images/space.gif":"/images/delete.png" %>' CommandName="del" CommandArgument='<%# Eval("fullname") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>        
        </div>
    </form>
</body>
</html>
