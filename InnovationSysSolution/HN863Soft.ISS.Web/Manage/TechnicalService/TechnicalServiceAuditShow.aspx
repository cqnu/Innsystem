﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TechnicalServiceAuditShow.aspx.cs" Inherits="HN863Soft.ISS.Web.Manage.TechnicalService.TechnicalServiceAuditShow" %>
<!DOCTYPE html>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>查看技术服务审核信息</title>
    <link href="../JS/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>

    <script type="text/javascript" src="../JS/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/common.js"></script>
    <script src="../JS/artDialog/artDialog.source.js" type="text/javascript"></script>
    <link href="../JS/artDialog/skins/blue.css" rel="stylesheet" type="text/css" />
    <script src="../JS/FunctionJS.js"></script>

    <link href="../../../Scripts/kindeditor-4.1.7/themes/default/default.css" rel="stylesheet" />
    <script src="../../../Scripts/kindeditor-4.1.7/kindeditor-min.js"></script>
    <script src="../../../Scripts/kindeditor-4.1.7/lang/zh_CN.js"></script>
    <script src="../../Ueditor/ueditor.config.js"></script>
    <script src="../../Ueditor/ueditor.all.min.js"></script>
    <script src="../../Ueditor/lang/zh-cn/zh-cn.js"></script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="TechnicalServiceAuditList.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../Center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="TechnicalServiceAuditList.aspx"><span>技术服务审核列表</span></a>
            <i class="arrow"></i>
            <span>查看技术服务审核信息</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">技术服务信息</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>类型</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlType" runat="server" sucmsg=" "></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>标题</dt>
                <dd>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" sucmsg=" "></asp:TextBox>
                </dd>
            </dl>

            <dl>
                <dt>内容</dt>
                <dd>
                    <textarea runat="server" id="tarContent" name="tbOrgIntro" style="height: 200px; width: 80%"></textarea>
                    <script type="text/javascript">
                        var ue = UE.getEditor('tarContent', {
                            toolbars: [
                                ['fullscreen', 'simpleupload', 'insertimage', 'justifyleft', 'justifyright', 'justifycenter', 'forecolor', 'imagecenter']
                            ],
                            zIndex: ['0'],
                            autoHeightEnabled: true,
                            autoFloatEnabled: true
                        });
                    </script>
                </dd>
            </dl>
        </div>
        <div class="page-footer">
            <div class="btn-wrap">
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
