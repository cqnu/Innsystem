<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActiveEdit.aspx.cs" ValidateRequest="false" Inherits="HN863Soft.ISS.Web.Manage.MeetingActivity.ActiveEdit" %>

<%@ Import Namespace="HN863Soft.ISS.Common" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>会议活动信息编辑</title>
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
        function show(obj) {

            var array = new Array('gif', 'jpeg', 'png', 'jpg'); //可以上传的文件类型 
            if (obj.value == '') {
                alert("让选择要上传的图片!");
                return false;
            }
            else {
                if (isExists == false) {
                    obj.value = null;
                    alert("上传图片类型不正确!");
                    document.getElementById("Image1").src = "";
                    document.getElementById("FileUpload1").value = "";
                    return false;
                }
                var fileContentType = obj.match(/^(.*)(\.)(.{1,8})$/)[3]; //文件类型正则
                var isExists = false;
                for (var i in array) {
                    if (fileContentType.toLowerCase() == array[i].toLowerCase()) {
                        isExists = true;
                        var docObj = document.getElementById("FileUpload1");

                        var imgObjPreview = document.getElementById("Image1");
                        if (docObj.files && docObj.files[0]) {

                            imgObjPreview.src = window.URL.createObjectURL(docObj.files[0]);
                            imgObjPreview.width = 300;
                            imgObjPreview.height = 200;

                        }
                            //360兼容模式下
                        else {

                            var imgObj = document.getElementById("Image1");
                            imgObj.src = obj;

                        }
                        return true;
                    }
                }

                return false;
            }
        }
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="ActiveList.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../Center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="ActiveList.aspx"><span>难题吐槽列表</span></a>
            <i class="arrow"></i>
            <span>编辑难题吐槽信息</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">吐槽信息</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">

            <dl>
                <dt>任务分类</dt>
                <dd>
                    <div class="menu-list">
                        <div class="rule-single-select">
                            <asp:DropDownList runat="server" ID="ddlType">
                            </asp:DropDownList>
                        </div>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>悬赏积分</dt>
                <dd>
                    <asp:TextBox runat="server" ID="txtReword" datatype="/^[0-9]{1,5}$/" nullmsg="请设置悬赏积分" errormsg="悬赏积分应在0~99999之间" sucmsg=" " CssClass="input normal"></asp:TextBox></dd>
            </dl>
            <dl>
                <dt>标题</dt>
                <dd>
                    <asp:TextBox runat="server" ID="txtTitle" TextMode="MultiLine" CssClass="input normal" datatype="*1-250" nullmsg="请填写标题信息" sucmsg=" "></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>关键词</dt>
                <dd>
                    <asp:TextBox ID="txtKeyWord" runat="server" CssClass="input normal" datatype="*1-16"></asp:TextBox>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>内容</dt>

                <dd>
                    <textarea runat="server" id="txtContent" name="content" cssclass="input normal" datatype="*" style="height: 200px; width: 80%"></textarea><span class="Validform_checktip">*内容</span>
                    <script type="text/javascript">
                        var ue = UE.getEditor('txtContent', {
                            toolbars: [
                                ['fullscreen', 'simpleupload', 'insertimage', 'justifyleft', 'justifyright', 'justifycenter', 'forecolor', 'imagecenter']
                            ],
                            autoHeightEnabled: true,
                            autoFloatEnabled: true
                        });
                    </script>
                </dd>
            </dl>
        </div>
        <div class="page-footer">
            <div class="btn-wrap">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
