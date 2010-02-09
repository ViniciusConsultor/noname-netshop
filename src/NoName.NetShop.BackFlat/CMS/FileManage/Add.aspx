<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="NoName.NetShop.BackFlat.CMS.FileManage.Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script src="../../js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {
            $('.list-image').hover(function() {
                var image = new Image();
                image.src = $(this).attr('href');
                var height = image.height;
                var width = image.width;

                var obj = $('<img class="sub-image-ge" src="' + image.src + '" />').css({
                    'position': 'absolute',
                    'width': (width / 2) + 'px',
                    'height': (height / 2) + 'px',
                    'border': '1px solid #ccc',
                    'padding': '3px'
                });

                $(this).parent().append(obj);
                obj.show(300);
            }, function() {
                $('.sub-image-ge').hide('fast').remove();
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload runat="server" ID="FileUpload_ImageFile" />
            <asp:Button runat="server" ID="Button_Upload" OnClick="Button_Upload_Click" Text="上传" />
        </div>
        <div runat="server" id="Panel_UploadedFileList">
            <asp:GridView CssClass="GridView" runat="server" ID="GridView1" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderStyle-Width="20">
                        <ItemTemplate>
                            <img src="<%# GetFileLogo(Eval("suffix").ToString()) %>" alt="<%# Eval("suffix") %>" style="width:18px;height:18px;"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="文件名" Visible="false">
                        <ItemTemplate>
                            <%# Eval("FileName") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="文件名" HeaderStyle-Width="440">
                        <ItemTemplate>
                            <asp:LinkButton Visible='<%# Convert.ToInt32(Eval("type"))==1?false:true %>' CommandArgument='<%# Eval("fullname") %>' CommandName="dir" runat="server" ID="Button_Dir" Text='<%# Eval("FileName") %>' />
                            <a target="_blank" href='<%# Eval("url") %>' class='<%# Convert.ToInt32(Eval("type"))==1?"list-image":"" %>' style="display:<%# Convert.ToInt32(Eval("type"))==1?"inline":"none" %>"><%# Eval("FileName") %></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="大小(Kb)" DataField="Size" HeaderStyle-Width="80"/>
                </Columns>
            </asp:GridView>     
        </div>
    </form>
</body>
</html>
