<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowCommendScence.aspx.cs" Inherits="NoName.NetShop.BackFlat.Solution.ShowCommendScence" %>

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
       <asp:Button runat="server" ID="btnAddNew" Text="添加新的推荐套装商品组合" 
               onclick="btnAddNew_Click" />
           <br />
       </div>
           <asp:GridView runat="server" ID="gvList" AutoGenerateColumns="false" 
               onrowcommand="gvList_RowCommand">
                <Columns>
                    <asp:BoundField DataField="SuiteId" HeaderText="ID" />
                    <asp:BoundField DataField="SuiteName" HeaderText="套装名称" />
                    <asp:ImageField DataImageUrlField="SmallImage" HeaderText="图片" />
                   <asp:BoundField DataField="Price"  HeaderText="价格" />
                   <asp:BoundField DataField="Score"  HeaderText="积分" />
                    <asp:TemplateField HeaderText="维护">
                        <ItemTemplate>
                             <asp:HyperLink runat="server" ID="HyperLinkShow" Text="查看" NavigateUrl='<%# "ShowCommendDetail.aspx?id=" + Eval("SuiteId") %>' />
                            <asp:LinkButton runat="server" ID="lbtnDelete" Text='删除' CommandName="delete" CommandArgument='<%#Eval("SuiteId")%>' ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                
            </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
