<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="NoName.NetShop.BackFlat.News.Detail.Add" %>
<%@ Register src="../../Controls/NewsCategorySelect.ascx" tagname="NewsCategorySelect" tagprefix="uc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
    <script src="/js/validate.js" type="text/javascript"></script>
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
    var categoryInfo = [{ "name": "category1", "title": "", "required": "true" },
    { "name": "category2", "title": "", "required": "true" },
    { "name": "category3", "title": "", "required": "false"}];

    $(function() {


    });
    
    function validate() {
        $('table td span[type=inform]').html('');

        var result = true;

        if ($('#<%=TextBox_Title.ClientID %>').val() == '') {
            result = false;
            inform($('#<%=TextBox_Title.ClientID %>'), '请输入资讯标题');
        }
        if ($('#<%=TextBox_Author.ClientID %>').val() == '') {
            result = false;
            inform($('#<%=TextBox_Author.ClientID %>'), '请输入作者');
        }
        if ($('#<%=TextBox_Tags.ClientID %>').val() == '') {
            result = false;
            inform($('#<%=TextBox_Tags.ClientID %>'), '请输入新闻标签');
        }       
        
        
        return result;
    }
    
    function inform(o, message) {
        o.parent().children('span[type=inform]').html(message);
        o.focus();
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>标题：<span class="red">*</span></td>
                <td><asp:TextBox runat="server" ID="TextBox_Title" Width="400" /><span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>副标题：</td>
                <td><asp:TextBox runat="server" ID="TextBox_SubTitle" Width="400" /><span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>作者：<span class="red">*</span></td>
                <td><asp:TextBox runat="server" ID="TextBox_Author" Width="400" /><span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>来源：</td>
                <td><asp:TextBox runat="server" ID="TextBox_NewsFrom" Width="400" /><span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>关联产品ID：</td>
                <td><asp:TextBox runat="server" ID="TextBox_ProductID" Width="400" /><span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>分类：</td>
                <td><uc1:NewsCategorySelect ID="NewsCategorySelect1" runat="server" /><span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>标签：<span class="red">*</span></td>
                <td><asp:TextBox runat="server" ID="TextBox_Tags" Width="400" /><span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>摘要：</td>
                <td><asp:TextBox runat="server" ID="TextBox_Brief" Width="400" Height="160" TextMode="MultiLine" /><span type="inform" class="red"></span></td>
            </tr>
            <tr>
                <td>内容：<span class="red">*</span></td>
                <td>
                    <asp:TextBox runat="server" ID="TextBox_Content" TextMode="MultiLine" />
                    <span type="inform" class="red"></span>
                </td>
            </tr>
            <tr>
                <td>上传图片：</td>
                <td>
                    <asp:FileUpload ID="FileUpload_Image" runat="server" />
                    <%--<asp:Button ID="Button_ImageUpload" runat="server" Text="上传" OnClick="Button_ImageUpload_Click" />--%>
                </td>
            </tr>
            <tr>
                <td>上传视频：</td>
                <td>
                    <asp:FileUpload ID="FileUpload_Video" runat="server" />
                    <%--<asp:Button ID="Button_VideoUpload" runat="server" Text="上传" OnClick="Button_VideoUpload_Click" />--%>
                </td>
            </tr>
        </table>
        <asp:Button ID="Button_Submit" runat="server" Text="添加" OnClientClick="return validate()"  OnClick="Button_Submit_Click" />
    </div>
    </form>
</body>
</html>
