<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="EntAdd.aspx.cs" Inherits="HN863Soft.ISS.Web.Web.Entrepreneurship.EntAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <script src="../../../Scripts/jquery-3.1.1.min.js"></script>
    <link href="../../../Scripts/kindeditor-4.1.7/themes/default/default.css" rel="stylesheet" />
    <script type="text/javascript" src="../../../Scripts/kindeditor-4.1.7/kindeditor-min.js"></>
    <script type="text/javascript"   src="../../../Scripts/kindeditor-4.1.7/lang/zh_CN.js"></script>

    <script type="text/javascript">
        var editor;
        KindEditor.ready(function (K) {
            editor = K.create('textarea[id="txtContent"]', {
                //themeType : 'qq',
                resizeType: 1,
                allowPreviewEmoticons: false,
                allowImageUpload: false,
                items: [
                    'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
                    'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
                    'insertunorderedlist', '|', 'emoticons']
                //, 'link','image',
            })
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            问题发布：  
            <div style=" width: 80%">
                <a name="txtContent"></a>
                <textarea runat="server" name="txtContent" id="txtContent" style="width: 100%; height: 100px; visibility: hidden;">来说两句吧。。。</textarea>
            </div><br />
            指导专家：<asp:DropDownList runat="server" ID="ddlConductor"></asp:DropDownList><br />
            <asp:Button Text="发布" ID="btnRelease" runat="server" OnClick="btnRelease_Click" />
        </div>
    </form>
</body>
</html>
