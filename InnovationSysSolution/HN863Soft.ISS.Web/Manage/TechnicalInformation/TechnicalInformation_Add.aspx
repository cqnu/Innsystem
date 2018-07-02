<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false"
    CodeBehind="TechnicalInformation_Add.aspx.cs" Inherits="HN863Soft.ISS.Web.TechnicalInformation.Add" Title="增加页" %>

<html>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>添加技术信息资源</title>
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
    <script>

        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
        });
    </script>

</head>


<body class="mainbody">
    <!--导航栏-->
    <div class="location">
        <a href="TechnicalInformation_List.aspx" class="back"><i></i><span>返回列表页</span></a>
        <a href="../Center.aspx" class="home"><i></i><span>首页</span></a>
        <i class="arrow"></i>
        <a href="TechnicalInformation_List.aspx"><span>技术信息资源列表</span></a>
        <i class="arrow"></i>
        <span>添加技术信息资源</span>
    </div>
    <!--/导航栏-->
    <form id="form1" runat="server">

        <div id="Div1" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">技术信息资源</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>产品名称</dt>
                <dd>
                    <asp:TextBox ID="txtEntryName" runat="server" CssClass="input normal" datatype="*1-100" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip"></span></dd>
            </dl>
            <dl>
                <dt>产品关键字</dt>
                <dd>
                    <asp:TextBox ID="txtKeyword" runat="server" CssClass="input normal" datatype="*1-100" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip"></span></dd>
            </dl>

            <dl>
                <dt>服务范围</dt>
                <dd>
                    <textarea runat="server" id="container" name="content" datatype="*1-5000" style="height: 200px; width: 80%"></textarea>
                    <script type="text/javascript">
                        var ue = UE.getEditor('container', {
                            toolbars: [
                                ['fullscreen', 'simpleupload', 'insertimage', 'justifyleft', 'justifyright', 'justifycenter', 'forecolor', 'imagecenter']
                            ],
                            autoHeightEnabled: true,
                            autoFloatEnabled: true
                        });
                    </script>
                </dd>
            </dl>
            <dl>
                <dt>机构展示</dt>
                <dd>
                    <textarea runat="server" id="container2" name="container2"  style="height: 200px; width: 80%"></textarea>
                    <script type="text/javascript">
                        window.onload = function () {
                            var ue = UE.getEditor('container', {
                                toolbars: [
                                    ['fullscreen', 'justifyleft', 'justifyright', 'justifycenter', 'forecolor', 'imagecenter']
                                ],
                                autoHeightEnabled: true,
                                autoFloatEnabled: true
                            });

                            var ue = UE.getEditor('container2', {
                                toolbars: [
                                    ['fullscreen', 'simpleupload', 'insertimage', 'justifyleft', 'justifyright', 'justifycenter', 'forecolor', 'imagecenter']
                                ],
                                autoHeightEnabled: true,
                                autoFloatEnabled: true
                            });

                        }


                    </script>
                </dd>
            </dl>

        </div>
        <div class="page-footer">
            <div class="btn-wrap">
                <asp:Button ID="Button1" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSave_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>

    </form>
</body>

</html>

