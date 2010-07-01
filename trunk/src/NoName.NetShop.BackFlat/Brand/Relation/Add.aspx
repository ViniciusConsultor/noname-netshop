<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="NoName.NetShop.BackFlat.Brand.Relation.Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
    #list{width:100%;}
    #list li{width:200px;height:20px;float:left;margin:2px;}
    
    #select{width:100%;}
    #select li{width:200px;height:20px;float:left;background:#eee;border:1px solid #ccc;margin:2px;}
    </style>
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {
            $('#list li input').click(function() {
                if ($(this).attr('checked')) {
                    addBrand($(this).attr('brandid'), $(this).next().html());
                }
                else {
                    removeBrand($(this).attr('brandid'), $(this).next().html());
                }
            });

            function addBrand(brandid, brandname) {
                $('#select').append($('<li><input type="hidden" id="brand' + brandid + '" name="brand' + brandid + '" value=' + brandid + ' />' + brandname + '</li>'));
            }
            function removeBrand(brandid) {
                $('#brand' + brandid).parent().remove();
            }
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="list">
            <asp:Repeater runat="server" ID="Repeater_Brand">
                <ItemTemplate>
                    <li><input type="checkbox" brandid='<%# Eval("brandid") %>' /><span><%# Eval("BrandName") %></span></li>                    
                </ItemTemplate>
            </asp:Repeater>
            <div style="clear:both;"></div>
        </div>
        <hr />
        <div id="select"></div>
            <asp:Button runat="server" ID="Button_Submit" OnClick="Button_Submit_Click" Text="提交" />
    </form>
</body>
</html>
