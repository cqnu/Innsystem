<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TalentServiceAuditEdit.aspx.cs" Inherits="HN863Soft.ISS.Web.Manage.TalentService.TalentServiceAuditEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>编辑人才服务审核信息</title>
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
        function show(obj) {

            var array = new Array('gif', 'jpeg', 'png', 'jpg'); //可以上传的文件类型 
            if (obj.value == '') {
                alert("让选择要上传的图片!");
                return false;
            }
            else {
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
                if (isExists == false) {
                    obj.value = null;
                    alert("上传图片类型不正确!");
                    document.getElementById("Image1").src = "";
                    document.getElementById("FileUpload1").value = "";
                    return false;
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
            <a href="TalentServiceAuditList.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../Center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="TalentServiceAuditList.aspx"><span>人才服务审核列表</span></a>
            <i class="arrow"></i>
            <span>编辑人才服务审核信息</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">人才服务信息</a></li>
                    </ul>
                </div>
            </div>
        </div>


        <div class="tab-content">
            <dl>
                <dt>信息发布类型</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList runat="server" ID="ddlType">
                        </asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>标题</dt>
                <dd>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="*1-100" Height="5%" Width="70%"></asp:TextBox>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>Logo</dt>
                <dd>
                    <asp:FileUpload ID="FileUpload1" accept=".jpeg,.png,.jpg" CssClass="upload-box" nullmsg="请上传图片" runat="server" onchange="show(this.value)" />
                    <span class="Validform_checktip">*请上传图片(支持jpeg、 png、jpg格式)。</span>
                </dd>
            </dl>
            <dl>
                <dt></dt>
                <dd>
                    <asp:Image ID="Image1" runat="server" Height="200px" CssClass="photo-list" Width="300px" />
                </dd>
            </dl>
            <dl>
                <dt>关键词</dt>
                <dd>
                    <asp:TextBox ID="txtKeyWord" runat="server" CssClass="input normal" datatype="*1-16"></asp:TextBox>
                    <span class="Validform_checktip">*多个关键词请用空格隔开。</span>
                </dd>
            </dl>

            <dl>
                <dt>简介</dt>
                <dd>
                    <asp:TextBox ID="txtIntroduce" runat="server" CssClass="input" TextMode="MultiLine" MaxLength="500" datatype="*1-100" sucmsg=" " Height="15%"></asp:TextBox>

                </dd>
            </dl>
            <dl>
                <dt>内容</dt>
                <dd>
                    <asp:TextBox ID="container" name="content" TextMode="MultiLine" runat="server" datatype="*" sucmsg=" " Width="100%" Height="300px"></asp:TextBox>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
        </div>
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-wrap">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSave_Click" />
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

            function show(obj) {

                var array = new Array('jpeg', 'png', 'jpg'); //可以上传的文件类型 
                if (obj.value == '') {
                    alert("让选择要上传的图片!");
                    return false;
                }
                else {

                    try {

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
                        if (isExists == false) {
                            obj = "";
                            alert("上传图片类型不正确!");
                            //document.getElementById("Image1").src = "";
                            document.getElementById("FileUpload1").value = "";
                            return false;
                        }
                    }
                    catch (e) {

                    }

                    return false;
                }
            }
        </script>

    </form>
</body>
</html>
