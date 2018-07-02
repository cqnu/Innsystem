<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SSEdit.aspx.cs" ValidateRequest="false" Inherits="HN863Soft.ISS.Web.Manage.SoftwareService.SSEdit" %>

<!DOCTYPE html>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>编辑软件服务发布信息</title>
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
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="SSList.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../Center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="SSList.aspx"><span>软件服务发布列表</span></a>
            <i class="arrow"></i>
            <span>编辑软件服务发布信息</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">软件服务信息</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">
            <dl>
                <dt>服务类型</dt>
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
                <dt>服务名称</dt>
                <dd>
                    <asp:TextBox runat="server" ID="txtTitle" TextMode="MultiLine" datatype="*1-100" CssClass="input normal" nullmsg="请填写服务名称信息" sucmsg=" "></asp:TextBox>
                </dd>
            </dl>

              <dl>
                <dt>软件Logo</dt>
                <dd>
                    <asp:FileUpload ID="FileUpload1" accept=".jpeg,.png,.jpg" CssClass="upload-box" datatype="*" nullmsg="请上传图片" runat="server" onchange="show(this.value)" />
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
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>

            <dl>
                <dt>简介</dt>
                <dd>
                    <asp:TextBox ID="txtIntroduce" runat="server" CssClass="input" TextMode="MultiLine" MaxLength="500" datatype="*1-100" sucmsg=" " Height="70px" Width="600px"></asp:TextBox>
                   
                </dd>
            </dl>

            <dl>
                <dt>服务介绍</dt>
                <dd>
                       <textarea runat="server" id="txtContent" name="txtContent" CssClass="input normal" datatype="*" style="height: 200px; width: 80%"></textarea><span class="Validform_checktip">*服务介绍必填</span>
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
            <dl>
                <dt>团队介绍</dt>
                <dd>
                    <textarea runat="server" id="txaIntroduction" name="txaIntroduction" CssClass="input normal" datatype="*" style="height: 200px; width: 80%"></textarea><span class="Validform_checktip">*团队介绍必填</span>
                    <script type="text/javascript">
                        var ue = UE.getEditor('txaIntroduction', {
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
                <dt>成功案例</dt>
                <dd>
                     <textarea runat="server" id="txaExample" name="txaExample" CssClass="input normal" datatype="*" style="height: 200px; width: 80%"></textarea><span class="Validform_checktip">*成功案例</span>
                    <script type="text/javascript">
                        var ue = UE.getEditor('txaExample', {
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
                <dt>服务咨询电话</dt>
                <dd>
                    <asp:TextBox runat="server" ID="txtPhone" CssClass="input normal" datatype="/^[0-9]{6,12}$/" nullmsg="请输入咨询电话" errormsg="长度为6~12位数字" sucmsg=" " />
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
