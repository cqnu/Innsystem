<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Notice_Show.aspx.cs"
    Inherits="HN863Soft.ISS.Web.Notice.Show" Title="显示页" %>

<html>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link href="../JS/artDialog/skins/blue.css" rel="stylesheet" type="text/css" />
    <script src="../../Ueditor/ueditor.config.js"></script>
    <script src="../../Ueditor/ueditor.all.min.js"></script>
    <script src="../../Ueditor/lang/zh-cn/zh-cn.js"></script>
    <script src="../../Scripts/jquery/jquery-1.11.2.min.js"></script>
    <script src="../JS/artDialog/artDialog.source.js" type="text/javascript"></script>
    <script src="../JS/FunctionJS.js"></script>
    <link href="../../Manage/JS/artDialog/skins/blue.css" rel="stylesheet" />
    <link href="../../Manage/skin/default/style.css" rel="stylesheet" />
    <link href="../JS/artDialog/ui-dialog.css" rel="stylesheet" />
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="/Manage/Notice/Notice_List.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="/Manage/Center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="/Manage/Notice/Notice_List.aspx"><span>通知公告列表</span></a>
            <i class="arrow"></i>
            <span>查看通知公告</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">通告信息</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">


            <dl>
                <dt>发布时间</dt>
                <dd>
                    <asp:TextBox ID="txtTime" runat="server" Enabled="false" CssClass="input normal" datatype="*0-100" sucmsg=" " />
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>

            <dl>
                <dt>发布人</dt>
                <dd>
                    <asp:TextBox ID="txtName" Enabled="false" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " />
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>

            <dl>
                <dt>发布内容</dt>
                <dd>
                    <asp:TextBox ID="txtPublishContent" ReadOnly="true"  runat="server" CssClass="input" TextMode="MultiLine" MaxLength="500" datatype="*1-100" sucmsg=" " Width="70%" Height="40%"></asp:TextBox>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>备注</dt>
                <dd>
                    <asp:TextBox ID="txtRemarks" runat="server" ReadOnly="false" CssClass="input" TextMode="MultiLine" Height="20%" Width="70%"></asp:TextBox>
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
    </form>
</body>
</html>






