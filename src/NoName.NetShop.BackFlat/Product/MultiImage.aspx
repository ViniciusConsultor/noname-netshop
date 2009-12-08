<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MultiImage.aspx.cs" Inherits="NoName.NetShop.BackFlat.Product.MultiImage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>图片描述：</td>
                    <td><asp:TextBox runat="server" ID="TextBox1"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>图片：</td>
                    <td><asp:FileUpload runat="server" ID="FileUpload1" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button runat="server" ID="Button1" Text="上传" OnClick="Button1_Click" /></td>
                </tr>
            </table>
        </div> 
        <div runat="server" id="EidtPanel">
            <table>
                <tr>
                    <td>图片描述：</td>
                    <td><asp:TextBox runat="server" ID="TextBox2"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>图片：</td>
                    <td><asp:FileUpload runat="server" ID="FileUpload2" /></td>
                </tr>
                <tr>
                    <td><input runat="server" id="imageID" type="hidden" /></td>
                    <td><asp:Button runat="server" ID="Button2" Text="确定" OnClick="Button2_Click" /></td>
                </tr>
            </table>
        </div>
        <div>
            <asp:GridView runat="server" ID="GridView1" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="imageid" HeaderText="图片ID" />
                    <asp:TemplateField HeaderText="图片">
                        <ItemTemplate>
                            <asp:Image Height="100" Width="100" ImageUrl='<%# Eval("smallimage") %>' runat="server" ID="ProductMultiImage" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="Button_MoveUp" CommandArgument='<%# Eval("imageid") %>' CommandName='u' Text="上移" />
                            <asp:LinkButton runat="server" ID="Button_MoveDown" CommandArgument='<%# Eval("imageid") %>' CommandName='d' Text="下移" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton id="EditButton" runat="server" Text="编辑" CommandArgument='<%# Eval("imageid") %>' CommandName="e" />
                            <asp:LinkButton id="DeleteButton" runat="server" Text="删除" CommandArgument='<%# Eval("imageid") %>' CommandName="d" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            
            </asp:GridView>
        </div>
    </form>
</body>
</html>
