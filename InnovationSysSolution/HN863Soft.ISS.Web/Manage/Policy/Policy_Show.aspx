<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Policy_Show.aspx.cs" Inherits="HN863Soft.ISS.Web.Manage.Policy.Policy_Show" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>添加公告</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/common.js"></script>
    <script src="../JS/artDialog/artDialog.source.js" type="text/javascript"></script>
    <link href="../JS/artDialog/skins/blue.css" rel="stylesheet" type="text/css" />
    <script src="../JS/FunctionJS.js"></script>
    <link href="../css/pagination.css" rel="stylesheet" />
    <script src="../../Ueditor/ueditor.config.js"></script>
    <script src="../../Ueditor/ueditor.all.min.js"></script>
    <script src="../../Ueditor/lang/zh-cn/zh-cn.js"></script>
    <link href="../css/pagination.css" rel="stylesheet" />

<%--    <script>

        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
        });
    </script>--%>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">政策检索</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">

            <dl>
                <dt>标题：</dt>
                <dd><%=strTitle%></dd>
            </dl>
            <dl>
                <dt>内容：</dt>
                <dd><%=strContent %></dd>
            </dl>
            <dl>
                <dt>原文地址URL：</dt>
                <dd><a href='<%=strUrl %>'  target="_blank"><%=strUrl %></a>   </dd>
            </dl>

        </div>

    </form>
</body>
</html>
