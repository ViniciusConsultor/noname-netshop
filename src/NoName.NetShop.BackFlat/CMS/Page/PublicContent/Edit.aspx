<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="NoName.NetShop.BackFlat.CMS.Page.PublicContent.Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="/css/cms.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery.js"></script>
    <script type="text/javascript" src="/Controls/ckEditor/ckeditor.js"></script>
    <script type="text/javascript">
        $(function() {
            var editor = CKEDITOR.replace('<%= TextBox_Content.ClientID %>', {
                startupMode: 'source',
                toolbar: [
                        ['Source', '-', 'Save', 'NewPage', 'Preview', '-', 'Templates'],
                        ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Print', 'SpellChecker', 'Scayt'],
                        ['Undo', 'Redo', '-', 'Find', 'Replace', '-', 'SelectAll', 'RemoveFormat'],
                        ['Bold', 'Italic', 'Underline', 'Strike', '-', 'Subscript', 'Superscript'],
                        '/',
                        ['Outdent', 'Indent', 'Blockquote'],
                        ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'],
                        ['Flash', 'Table', 'HorizontalRule', 'SpecialChar', 'PageBreak'],
                        ['Styles', 'Format', 'Font', 'FontSize'],
                        ['TextColor', 'BGColor', 'Maximize']
                    ],
                height: '400px',
                toolbarStartupExpanded: false
            });
        });
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3 runat="server" id="ContentTitle"></h3>
            <asp:TextBox runat="server" ID="TextBox_Content" TextMode="MultiLine" />
            <asp:Button runat="server" ID="Button_Publish" Text="发布" OnClick="Button_Publish_Click" />        
        </div>
    </form>
</body>
</html>
