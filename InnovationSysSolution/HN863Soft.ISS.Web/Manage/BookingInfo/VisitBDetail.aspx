<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisitBDetail.aspx.cs" Inherits="HN863Soft.ISS.Web.Manage.BookingInfo.VisitBDetail" %>

<%@ Import Namespace="HN863Soft.ISS.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>预约申请管理</title>
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
    <link href="../JS/WebUpload/css/style.css" rel="stylesheet" />
    <link href="../JS/WebUpload/css/webuploader.css" rel="stylesheet" />
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="VisitBList.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../Center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="VisitBList.aspx"><span>预约参观列表</span></a>
            <i class="arrow"></i>
            <span>预约详细</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">预约信息</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>姓名</dt>
                <dd>
                    <asp:TextBox ID="txtName" runat="server" ReadOnly="true" CssClass="input normal" MaxLength="50"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>手机</dt>
                <dd>
                    <asp:TextBox CssClass="input normal" ID="txtPhone" ReadOnly="true" TextMode="Number" nullmsg="请输入联系电话" sucmsg=" " runat="server"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>邮箱</dt>
                <dd>
                    <asp:TextBox ID="txtEmail" runat="server" ReadOnly="true" CssClass="input normal" TextMode="Email"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>业务简介</dt>
                <dd>
                    <asp:TextBox ID="txtExp" runat="server" ReadOnly="true" TextMode="MultiLine" CssClass="input normal"></asp:TextBox></dd>
            </dl>
            <dl>
                <dt>人数</dt>
                <dd>
                    <asp:TextBox ID="txtNum" runat="server" ReadOnly="true" TextMode="Number" CssClass="input normal"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>期望参观日期</dt>
                <dd>
                    <asp:TextBox runat="server" ID="txtVisDate" CssClass="input normal" ReadOnly="true" />  
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
    </form>
</body>
</html>
