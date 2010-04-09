<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExpressShipFee.aspx.cs" Inherits="NoName.NetShop.BackFlat.Order.ExpressShipFee" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>快递费用设置</title>
</head>
<body>
    <form id="form1" runat="server">

    <div>
        <div id="data-list">
     配送区域：
    <asp:DropDownList ID="ddlShipRegion" runat="server">
    <asp:ListItem Text="全部区域" Value=""></asp:ListItem>
    <asp:ListItem Text="一区" Value="1"></asp:ListItem>
    <asp:ListItem Text="二区" Value="2"></asp:ListItem>
    <asp:ListItem Text="三区" Value="3"></asp:ListItem>
    </asp:DropDownList>
      &nbsp;用户类型：
    <asp:DropDownList ID="ddlUserType" runat="server">
    <asp:ListItem Text="全部会员" Value=""></asp:ListItem>
    <asp:ListItem Text="个人会员" Value="1"></asp:ListItem>
    <asp:ListItem Text="企业会员" Value="2"></asp:ListItem>
    <asp:ListItem Text="家庭会员" Value="3"></asp:ListItem>
    <asp:ListItem Text="学校会员" Value="4"></asp:ListItem>
    </asp:DropDownList>
    &nbsp;用户级别：
    <asp:DropDownList ID="ddlUserLevel" runat="server">
    <asp:ListItem Text="全部级别" Value=""></asp:ListItem>
    <asp:ListItem Text="登鼎会员" Value="0"></asp:ListItem>
    <asp:ListItem Text="铁鼎会员" Value="1"></asp:ListItem>
    <asp:ListItem Text="铜鼎会员" Value="2"></asp:ListItem>
    <asp:ListItem Text="银鼎会员" Value="3"></asp:ListItem>
    <asp:ListItem Text="金鼎会员" Value="4"></asp:ListItem>
    <asp:ListItem Text="宝鼎会员" Value="5"></asp:ListItem>
    </asp:DropDownList>
    &nbsp;<asp:Button ID="doSearch" runat="server" Text="查找" onclick="doSearch_Click" />
      &nbsp;<asp:Button runat="server" ID="btnSave" Text="保存" onclick="btnSave_Click" />
      <div>
           <asp:GridView runat="server" ID="gvList" AutoGenerateColumns="false" 
                onrowdatabound="gvList_RowDataBound" DataKeyNames="RuleId">
                <Columns>
                    <asp:BoundField DataField="RuleId" HeaderText="规则ID" />            
                    <asp:BoundField DataField="ShipRegion" HeaderText="配送区域分区" />
                    <asp:TemplateField HeaderText="会员类型">
                    <ItemTemplate>
                    <asp:Label runat="server" ID="lblUserType"></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="金额阈值">
                        <ItemTemplate>
                            <asp:TextBox ID="txtMarkMoney" runat="server" Text='<%#Eval("MarkMoney") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>                    
                    <asp:TemplateField HeaderText="小于时运费">
                        <ItemTemplate>
                            <asp:TextBox ID="txtLShipFee" runat="server" Text='<%#Eval("LShipFee") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>                    
                    <asp:TemplateField HeaderText="大于等于时运费">
                        <ItemTemplate>
                            <asp:TextBox ID="txtGShipFee" runat="server" Text='<%#Eval("GShipFee") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField> 
                </Columns>
            </asp:GridView>
        </div>
        </div>
    </form>
</body></html>
