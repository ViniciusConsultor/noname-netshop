<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductSearch.aspx.cs" Inherits="NoName.NetShop.ForeFlat.Search.ProductSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView runat="server" ID="GridView1">
            <Columns>
                <asp:BoundField DataField="entryidentity" />
                <asp:BoundField DataField="productname" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
