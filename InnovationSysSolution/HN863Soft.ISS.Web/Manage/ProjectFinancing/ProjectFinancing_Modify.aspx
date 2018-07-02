<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="ProjectFinancing_Modify.aspx.cs" Inherits="HN863Soft.ISS.Web.Manage.ProjectFinancing.ProjectFinancing_Modify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>

    <script src="../../My97DatePicker/WdatePicker.js"></script>

    <link href="../../Uploadify/uploadify.css" rel="stylesheet" />
    <script src="../../Uploadify/jquery.uploadify.v2.1.4.js"></script>
    <script src="../../Uploadify/jquery.uploadify.v2.1.4.min.js"></script>
    <script src="../../Uploadify/swfobject.js"></script>

    <link href="../JS/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />

    <script src="../../Ueditor/ueditor.config.js"></script>
    <script src="../../Ueditor/ueditor.all.min.js"></script>
    <script src="../../Ueditor/lang/zh-cn/zh-cn.js"></script>

    <link href="../../video/video-js.css" rel="stylesheet" />
    <script src="../../video/video.js"></script>
    <script>
        videojs.options.flash.swf = "../../video/video-js.swf";
    </script>

    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/uploader.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/common.js"></script>
    <script src="../JS/artDialog/artDialog.source.js" type="text/javascript"></script>
    <link href="../JS/artDialog/skins/blue.css" rel="stylesheet" type="text/css" />
    <script src="../JS/FunctionJS.js"></script>
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
            //初始化上传控件

        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#uploadify').uploadify({
                'uploader': '../../Uploadify/uploadify.swf',
                'script': '../../WebService/Uploadify.ashx',
                'cancelImg': '../../Uploadify/cancel.png',
                'buttonText': '浏览视频',
                'folder': '/uploads',
                'auto': true,
                'sizeLimit': '209715200',
                'buttonText': '',
                'fileDesc': 'mp4.',
                'fileExt': '*.mp4',
                'buttonImg': '../../Uploadify/browse.jpg',
                'scriptData': { 'methed': 'uploadFile', 'arg1': 'value1' },
                'onComplete': function (event, queueID, file, serverData, data) {

                    //清除div
                    $('#uploadify').uploadifyClearQueue();

                    //设置后台数据保存路径
                    document.getElementById("hid").value = '/uploads/' + serverData;

                    alert("上传成功！点击播放按钮可播放视频");

                    playClicked(document.getElementById("hid").value);
                },

            });
        });
        function playClicked(element) {

            //设置路径
            document.getElementById("example_video_1").src = element;

            //播放按钮可用
            document.getElementById("example_video_1").controls = "metadata";

            ////设置自动加载
            //document.getElementById("example_video_1").autoplay = "autoplay";
            ////视频文件开始播放
            //document.getElementById("example_video_1").play();
        }
    </script>

</head>
<body class="mainbody">
    <form id="form1" runat="server">

        <!--导航栏-->
        <div class="location">
            <a href="ProjectFinancing_List.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../Center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="ProjectFinancing_List.aspx"><span>众筹审核管理</span></a>
            <i class="arrow"></i>
            <span>修改众筹审核信息</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->
        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">项目基本信息</a></li>
                        <li><a href="javascript:;">项目详细信息</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content" style="height: 100%">
<%--            <dl>
                <dt>权限资源</dt>
                <dd>
                    <div class="rule-multi-porp">
                        <asp:CheckBoxList ID="cblActionType" runat="server" errormsg="请选择权限！" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
                    </div>
                    <span class="Validform_checktip">*请选择可查看的用户（全选或全不选都默认为全部可看）。</span>
                </dd>
            </dl>--%>
            <dl>
                <dt>项目类型</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlType" runat="server" datatype="*" errormsg="请选择所属类型！" sucmsg=" "></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>项目封面</dt>
                <dd>
                    <asp:FileUpload ID="FileUpload1" accept=".jpeg,.png,.jpg" CssClass="upload-box" runat="server" onchange="show(this.value)" />
                    <span class="Validform_checktip">*请上传图片(支持jpeg、 png、jpg格式)。</span>
                </dd>
            </dl>
            <dl>
                <dt></dt>
                <dd>
                    <asp:Image ID="Image1" CssClass="photo-list" runat="server" Height="200px" Width="300px" />
                </dd>
            </dl>
            <dl>
                <dt>项目名称名称</dt>
                <dd>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="*1-50" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*请填写项目名称。</span>
                </dd>
            </dl>
            <dl>
                <dt>项目关键词</dt>
                <dd>
                    <asp:TextBox ID="txtKeyWord" runat="server" CssClass="input normal" datatype="*1-16" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*多个关键词请用空格隔开。</span>
                </dd>
            </dl>


            <dl>
                <dt>项目时间</dt>
                <dd>
                    <input id="startDate" runat="server" class="Wdate" datatype="*" type="text" onfocus="var endDate=$dp.$('endDate');WdatePicker({onpicked:function(){endDate.focus();},maxDate:'#F{$dp.$D(\'endDate\')}'})" />
                    至
                    <input id="endDate" runat="server" class="Wdate" datatype="*" type="text" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'startDate\')}'})" />
                    <span class="Validform_checktip">*项目周期。</span>
                </dd>
            </dl>
            <dl>
                <dt>项目地点</dt>
                <dd>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlProvince" Width="100px" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged" AutoPostBack="true" runat="server" datatype="*" errormsg="请选择所属类型！" sucmsg=" "></asp:DropDownList>
                            <asp:DropDownList ID="ddlCity" Width="200px" runat="server" datatype="*" errormsg="请选择所属类型！" sucmsg=" "></asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </dd>
            </dl>
            <dl>
                <dt>众筹简介</dt>
                <dd>
                    <asp:TextBox ID="txtObjective" runat="server" CssClass="input" TextMode="MultiLine" MaxLength="200" datatype="*1-200" sucmsg=" " Height="100px"></asp:TextBox>
                    <span class="Validform_checktip">*请填写对项目的描述。</span>
                </dd>
            </dl>
        </div>

        <div class="tab-content" style="display: none;">
            <dl>
                <dt>项目宣传视频</dt>
                <dd>
                    <input type="file" name="uploadify" id="uploadify" />
                    <span class="Validform_checktip">*最大支持200M的视频文件。</span>
                </dd>
            </dl>
            <dl>
                <dd>
                    <asp:HiddenField runat="server" ID="hid" />
                    <video id="example_video_1" src='<%=strSrc%>' class="video-js vjs-default-skin" width="800" height="500">
                    </video>
                </dd>
                <dd style="color: red">*为确保视频正确加载，如果是IE浏览器，请使用IE9以上版本。如果是其他浏览器，请用兼容性模式打开本站。</dd>

            </dl>
            <dl>
            </dl>
            <dl>
            </dl>
            <dl>
            </dl>
            <dl>
            </dl>
            <dl>
            </dl>
            <dl>
                <dd>注:该模版可根据自己需求进行添加更改</dd>
            </dl>
            <dl>
                <dt>项目详情</dt>
                <dd>
                    <textarea runat="server" id="traContent" datatype="*" name="traContent" style="height: 1500px; width: 100%"></textarea>
                    <script type="text/javascript">
                        var ue = UE.getEditor('traContent', {
                            toolbars: [
                                 ['simpleupload', 'insertimage', 'justifyleft', 'justifyright', 'justifycenter', 'bold', 'underline ', 'forecolor', 'fontfamily', 'fontsize', 'forecolor', 'imagecenter', 'spechars', 'emotion', 'insertvideo ', 'snapscreen', 'map']
                            ],
                            autoHeightEnabled: true,
                            autoFloatEnabled: true

                        });
                    </script>
                </dd>
            </dl>
        </div>
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-wrap">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>
        <!--/工具栏-->
    </form>
    <script type="text/javascript">

        window.onload = function () {
            var video = document.getElementById("example_video_1");
            if (video.src != "") {
                video.controls = "metadata";
            }
        }

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
</body>
</html>
