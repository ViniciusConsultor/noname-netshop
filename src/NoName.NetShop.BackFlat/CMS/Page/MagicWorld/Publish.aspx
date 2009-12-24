<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Publish.aspx.cs" Inherits="NoName.NetShop.BackFlat.CMS.Page.MagicWorld.Publish" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="/css/cms.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery.js"></script>
    <script type="text/javascript" src="/js/jquery.msgbox.js"></script>
    <script type="text/javascript" src="/Controls/ckEditor/ckeditor.js"></script>
    <script type="text/javascript">
        var msgEditor = null;
        $(function() {
            setTimeout(function() {
            $('.listGrid input[type="checkbox"]').each(function() {
                    $(this).removeAttr('disabled').parent().removeAttr('disabled');
                });
            }, 1000);

            $('a.tag-name').hover(function() {
                var image = new Image();
                image.src = $(this).next().children('img').attr('src');
                var height = image.height;
                var width = image.width;

                var obj = $('<img class="tag-image-ge" src="' + image.src + '" />').css({
                    'position': 'absolute',
                    'width': (width / 2) + 'px',
                    'height': (height / 2) + 'px',
                    'border': '1px solid #ccc',
                    'padding': '3px'
                });

                $(this).parent().append(obj);
                obj.show(300);
            }, function() {
                $('.tag-image-ge').hide('fast').remove();
            });
        });

        function showGeneratedCode(code, editor) {
            $.messageBox({
                title: '<b>生成代码</b>',
                content: '<textarea id="generated_code_content">' + code + '</textarea>',
                buttons: [{
                    text: '复制到编辑区',
                    css: '',
                    style: 'border:1px solid #ccc;border-left:3px solid #ccc;background:#fff;',
                    click: function() {
                        editor.setData(CKEDITOR.instances.generated_code_content.getData(), messageBoxClose);
                    }
                }, {
                    text: '复制到粘贴板',
                    css: '',
                    style: 'border:1px solid #ccc;border-left:3px solid #ccc;background:#fff;',
                    click: function() {
                        $.copyToClipboard(CKEDITOR.instances.generated_code_content.getData());
                    }
                }],
                height: 'auto',
                width: '500px',
                top: '300px',
                onClose: messageBoxClose
                });

                msgEditor = CKEDITOR.replace('generated_code_content', {
                    startupMode: 'source',
                    toolbar: [
                    ['Source', 'Maximize']
                ],
                    toolbarStartupExpanded: false
                });
            }

            function messageBoxClose() {
                CKEDITOR.instances.generated_code_content.destroy();
                $('#message-box-layer').hide('fast');
                $('#message-box-layer').remove();
                $('#message-box-background').remove();
            }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <h4 runat="server" id="Label_PageTitle"></h4>
        [ <asp:HyperLink runat="server" ID="HyperLink1" Text="返回列表" NavigateUrl="List.aspx" /> | 
        <asp:HyperLink runat="server" ID="Link_Preview" Text="预览地址" Target="_blank" /> | 
        <asp:HyperLink runat="server" ID="Link_Formal" Text="正式地址" Target="_blank" /> ]
        <br/>
        <div>
            <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false" CssClass="listGrid">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox id="chkItem" disabled="true" runat="server" AutoPostBack="true" CssClass='<%# Convert.ToBoolean(Eval("ispublic"))?"invisible":"" %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="标签名称">
                        <ItemTemplate>
                            <a class="tag-name" style="cursor:pointer"><%# Eval("description")%></a>
                            <div style="display:none;"><img src='<%# Eval("examplepicture") %>' /></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="serverid" HeaderText="控件ID" />
                    <asp:BoundField DataField="tagid" HeaderText="标签ID" />
                </Columns>
            </asp:GridView>
        </div>
        <div runat="server" id="editWrap">
            
        </div>
        <asp:Button runat="server" ID="Button_Save" OnClick="Button_Save_Click" Text="保存" />
        <asp:Button runat="server" ID="Button_Publish" OnClick="Button_Publish_Click" Text="发布" />
    </form>
</body>
</html>
