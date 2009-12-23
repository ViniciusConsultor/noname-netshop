<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TagEditor_Static.ascx.cs" Inherits="NoName.NetShop.BackFlat.CMS.Controls.TagEditor_Static" %>

<script type="text/javascript">
    $(function() {
        CKEDITOR.replace('<%= TextBox_Content.ClientID %>', {
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
            toolbarStartupExpanded: false
        });
    });
</script>


<h5 runat="server" id="EditorTitle"></h5>

<asp:TextBox runat="server" ID="TextBox_Content" TextMode="MultiLine" />