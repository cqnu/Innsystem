<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="ServiceModify.aspx.cs" Inherits="_863soft.ISS.Web.Service.ServiceMange.ServiceModify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <style>
        form {
            margin: 0;
        }

        textarea {
            display: block;
        }
    </style>
    <link href="../../../Scripts/kindeditor-4.1.7/themes/default/default.css" rel="stylesheet" />
    <script src="../../../Scripts/kindeditor-4.1.7/kindeditor-min.js"></script>
    <script src="../../../Scripts/kindeditor-4.1.7/lang/zh_CN.js"></script>
    <script>
        var editor;
        KindEditor.ready(function (K) {
            editor = K.create('textarea[id="txtContent"]', {
                resizeType: 2,
                allowPreviewEmoticons: false,
                allowImageUpload: false,
                items: [
                    'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
                    'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
                    'insertunorderedlist', '|', 'emoticons', 'link']
                //'image',
            });
        });
    </script>
</head>
<body>
    <form id="Form1" runat="server">
    <lable id="lbl">标题：</lable>
    <textarea runat="server" id="txtTitle" cols="20" name="S1" rows="1"></textarea>
    <lable id="Lable1">服务内容：</lable>
        <textarea runat="server" name="content" id="txtContent" style="width: 800px; height: 200px; visibility: hidden;"></textarea>
        <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" />
    </form>

</body>
</html>
