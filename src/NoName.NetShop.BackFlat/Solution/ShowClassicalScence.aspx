<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowClassicalScence.aspx.cs" Inherits="NoName.NetShop.BackFlat.Solution.ShowClassicalScence" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <div id="data-list">
       <asp:TextBox ID="txtCateId" runat="server"></asp:TextBox>
       <asp:Button ID="btnAddNewCateId" runat="server" Text="向套装添加分类" 
               onclick="btnAddNewCateId_Click" />
           <asp:GridView runat="server" ID="gvList" AutoGenerateColumns="false" 
               onrowcommand="gvList_RowCommand">
                <Columns>
                    <asp:BoundField DataField="CateId" HeaderText="分类Id" />
                    <asp:BoundField DataField="catename" HeaderText="分类名称" />
                   <asp:BoundField DataField="IsShow"  HeaderText="显示于场景" />
                    <asp:TemplateField HeaderText="维护">
                        <ItemTemplate>
                             <asp:HyperLink runat="server" ID="HyperLinkShow" Text="查看" NavigateUrl='<%# "ShowClassicalDetail.aspx?cid=" + Eval("CateId") +"&sid=" + Eval("SenceId") %>' />
                            <asp:LinkButton runat="server" ID="lbtnDelete" Text='删除' CommandName="delete" CommandArgument='<%#Eval("CateId")%>' ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
	 
    </div>
    </form>
</body>
</html>
