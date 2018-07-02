<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="LinkPatent_Add.aspx.cs" Inherits="HN863Soft.ISS.Web.Manage.LinkPatent.LinkPatent_Add" %>

<!DOCTYPE html>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>技术服务</title>
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
    <script>

        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
        });
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="TechnicalService_List.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../Center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="TechnicalService_List.aspx"><span>专利商标查询管理列表</span></a>
            <i class="arrow"></i>
            <span>添加专利商标查询</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">专利商标查询信息</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>网站名称</dt>
                <dd>
                    <asp:TextBox ID="txtSiteName" runat="server" CssClass="input normal" datatype="*1-100" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*网站名称必填</span>
                </dd>
            </dl>

            <dl>
                <dt>网站链接</dt>
                <dd>
                    <asp:TextBox ID="txtSiteUrl" runat="server" CssClass="input normal" datatype="*1-100" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*网站链接必填</span></dd>
            </dl>

            <dl>
                <dt>网站描述</dt>
                <dd>
                    <asp:TextBox ID="txtSiteDescription" runat="server" CssClass="input normal" datatype="*1-100" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*网站描述必填</span></dd>
            </dl>
            <dl>
                <dt>网站log</dt>
                <dd>
                    <asp:FileUpload ID="FileUpload1" runat="server" onchange="show(this.value)" />
            </dl>
            <dl>
                <dd>
                    <asp:Image BorderStyle="Outset" ID="Image1" runat="server" />
                </dd>
            </dl>

        </div>
        <div class="page-footer">
            <div class="btn-wrap">
                <asp:Button ID="btnSave" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSave_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>
        <!--/工具栏-->
    </form>
    <script type="text/javascript">
        function show(id) {
            var imgObj = document.getElementById("Image1");
            imgObj.src = id;
            imgObj.width = 80;
            imgObj.height = 50;
            //document.getElementById("Image1").src.width = 100;
            //document.getElementById("Image1").src.height = 100;
        }
    </script>

</body>
</html>
