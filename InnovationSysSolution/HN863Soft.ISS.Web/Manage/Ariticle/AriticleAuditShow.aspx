﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AriticleAuditShow.aspx.cs" Inherits="HN863Soft.ISS.Web.Manage.AriticleAuditShow" %>

<html>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>查看工业设计审核信息</title>
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

    <script src="../../Ueditor/ueditor.config.js"></script>
    <script src="../../Ueditor/ueditor.all.min.js"></script>
    <script src="../../Ueditor/lang/zh-cn/zh-cn.js"></script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="AriticleAuditList.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../Center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="AriticleAuditList.aspx"><span>工业设计审核列表</span></a>
            <i class="arrow"></i>
            <span>查看工业设计审核信息</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">工业设计信息</a></li>
                    </ul>
                </div>
            </div>
        </div>


        <div class="tab-content">
            <dl>
                <dt>工业类型</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlType" Enabled="false" runat="server"></asp:DropDownList>
                    </div>
                </dd>
            </dl>

            <dl>
                <dt>标题</dt>
                <dd>
                    <asp:TextBox ID="txtTitle" runat="server" ReadOnly="true" CssClass="input normal" Height="5%" Width="70%"></asp:TextBox>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>Logo</dt>
                <dd> <asp:Image ID="Image1" runat="server" Height="200px" CssClass="photo-list" Width="300px" /></dd>
            </dl>

            <dl>
                <dt>关键词</dt>
                <dd>
                    <asp:TextBox ID="txtKeyWord"  runat="server" CssClass="input normal" ReadOnly="true" datatype="*1-100"></asp:TextBox>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>

            <dl>
                <dt>简介</dt>
                <dd>
                    <asp:TextBox ID="txtIntroduce"  runat="server" CssClass="input" ReadOnly="true" TextMode="MultiLine" MaxLength="500" datatype="*1-100" sucmsg=" " Height="15%"></asp:TextBox>

                </dd>
            </dl>
            <dl>
                <dt>内容</dt>
                <dd>
                    <%-- <textarea id="container" runat="server" name="content"></textarea>--%>
                    <asp:TextBox ID="container" ReadOnly="true" name="content" TextMode="MultiLine" runat="server"  sucmsg=" " Width="100%" Height="40%"></asp:TextBox>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
        </div>
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-wrap">
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>
        <!--/工具栏-->

        <script type="text/javascript">
            var ue = UE.getEditor('container', {
                toolbars: [
                    ['simpleupload', 'insertimage', 'justifyleft', 'justifyright', 'justifycenter', 'bold', 'underline ', 'forecolor', 'paragraph', 'fontfamily', 'fontsize', 'forecolor', 'imagecenter', 'spechars', 'emotion', 'insertvideo ', 'snapscreen', 'map']
                ],
                autoHeightEnabled: true,
                autoFloatEnabled: true
            });
        </script>

    </form>
</body>
</html>
