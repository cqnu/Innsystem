<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeetingActiveAdd.aspx.cs" Inherits="HN863Soft.ISS.Web.Web.MeetingActivity.MeetingActiveAdd" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>添加难题吐槽信息</title>
    <link href="../CSS/tutor.css" rel="stylesheet" />
    <link href="../CSS/075164029c450604c632bc43bf813389.css" rel="stylesheet" />
    <link href="../CSS/8c06a6ae51572b94394358b86d29a185.css" rel="stylesheet" />
    <link href="../CSS/2e48e8de0c96d4c87c57f954eb4d94c6.css" rel="stylesheet" />
    <link href="../CSS/Show/base.css" rel="stylesheet" />
    <link href="../CSS/Heard/css.css" rel="stylesheet" />
    <link href="../../Manage/skin/default/style.css" rel="stylesheet" />
    <link href="../../Manage/css/pagination.css" rel="stylesheet" />
    <link href="../skin_v2/css/bootstrap.min.css" rel="stylesheet" />

    <script src="../skin_v2/js/jquery.js"></script>
    <script src="../skin_v2/js/bootstrap.min.js"></script>
    <%--    <script src="../Scripts/jquery-1.8.0.min.js"></script>--%>
    <script src="../skin_v2/js/global.js"></script>
    <script src="../skin_v2/js/niuge.confirm.js"></script>
    <script src="../User/resources/js/jquery.cookie.js"></script>

    <script src="../../Manage/JS/FunctionJS.js"></script>
    <script src="../../Manage/JS/laymain.js"></script>
    <script src="../../Manage/JS/common.js"></script>

    <link rel="stylesheet" type="text/css" href="../skin_v2/css/global.css" />
    <script type="text/javascript" src="../skin_v2/js/responsive.min.js"></script>

    <link href="../../Scripts/artDialog/ui-dialog.css" rel="stylesheet" />
    <%--    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>--%>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>

    <script src="../../Scripts/artDialog/dialog-plus-min.js"></script>
    <script src="../../Scripts/laymain.js"></script>
    <script src="../../Scripts/common.js"></script>

    <script src="../../Scripts/artDialog/artDialog.source.js"></script>
    <link href="../../Scripts/artDialog/skins/blue.css" rel="stylesheet" />
    <script src="../../Scripts/FunctionJS.js"></script>

    <link href="../../Scripts/kindeditor-4.1.7/themes/default/default.css" rel="stylesheet" />
    <script src="../../Scripts/kindeditor-4.1.7/kindeditor-min.js"></script>
    <script src="../../Scripts/kindeditor-4.1.7/lang/zh_CN.js"></script>
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
    <form action="/WebService/MeetingActiveAddHandler.ashx" runat="server">
        <div class="header">
            <div style="width: 1080px; margin: 0 auto;">
                <div style="float: left; margin: 6px 10px 0 0;">
                    <img src="../../Manage/skin/default/logo.png" style="width: 220px;" />
                </div>
                <ul class="menu" style="float: left;">
                    <li><a href="../index.html">主页</a></li>
                    <li><a href="#">投融资服务</a>
                        <ul class="submenu">
                            <li><a href="../ProjectFinancing/ProjectFinancing_List.aspx">众筹</a></li>

                            <li><a href="../Roadshow/Roadshow_List.aspx">路演</a></li>
                        </ul>
                    </li>
                    <li class="active on"><a href="#s2">工商财税</a>
                        <ul class="submenu">
                            <li><a href="../EnterpriseRegistration/EnterpriseRegistration_List.aspx">工商注册</a></li>
                            <li><a href="../Fiscal/Fiscal_List.aspx">财税服务</a></li>
                            <li><a href="../Intellectual/Intellectual_List.aspx">知识产权</a></li>
                        </ul>
                    </li>
                    <li><a href="#">专业技术服务</a>
                        <ul class="submenu">
                            <li><a href="../Ariticle/Ariticle_List.aspx">工业设计</a></li>
                            <li><a href='../SoftWareS/List.aspx?TypeName=SoftwareServiceType'>软件服务</a></li>
                            <li><a href='../SoftWareS/List.aspx?TypeName=HSEConsulting'>高企认定咨询</a></li>
                            <li><a href='../SoftWareS/List.aspx?TypeName=SoftConsulting'>双软认定咨询</a></li>
                            <li><a href="../TalentService/TalentService_List.aspx">人才服务</a></li>
                        </ul>
                    </li>
                    <li><a href="../EnterIncubating/EIIndex.aspx">孵化器</a></li>
                    <li><a href="../MeetingActivity/MeetingActiveList.aspx" class="selected">难题吐槽 </a></li>
                    <li><a href="../PolicyHall/PHList.aspx">政策大厅 </a></li>

                </ul>
                <div class="header-right" id="min-nav">
                    <div class="login-register" id="min-zhuce" style="display: none">
                        <a class="nav-btn-login" href="javascript:">登录</a>
                        <a class="nav-btn-reg" href="/Web/User/NewRegister.html" target="_blank">注册</a>
                    </div>
                    <div class="login-register" style="display: none" id="web">

                        <div class="dropdown">

                            <a id="aName" href="" class="dropdown-toggle top-avatar" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" style="float: right; text-align: center;">您好：
                                &nbsp;&nbsp;	  	
			  </a>
                            <ul class="dropdown-menu" aria-labelledby="dropdownMenu1">
                                <li id="liManage" style="display: none"><a href="../../Manage/index.aspx">后台管理</a></li>
                                <li><a href="../User/ModifyPassword.html">修改密码</a></li>
                                <li><a href="javascript:void(0)" onclick='delCookie()'>注销登录</a></li>

                            </ul>
                        </div>
                        <script>
                            $.ajax({
                                url: "../../WebService/JudgeSess.ashx?state=0",
                                type: "post",

                                dataType: "text",
                                async: false,
                                success: function (data) {
                                    var a = data;

                                    if (a == "") {
                                        $("#min-zhuce").show();
                                        $("#web").hide();
                                    }
                                    else {
                                        $("#min-zhuce").hide();
                                        $("#web").show();
                                        $("#aName").text("欢迎您：" + a);
                                    }

                                }
                            })

                            $.ajax({
                                url: "../../WebService/JudgeSess.ashx?state=2",
                                type: "post",
                                dataType: "text",
                                async: false,
                                success: function (data) {
                                    var a = data;
                                    if (a == "") {

                                        $("#liManage").hide();
                                    }
                                    else {

                                        $("#liManage").show();

                                    }

                                }
                            })


                            function delCookie() {

                                var a = 0;

                                $.ajax({
                                    url: "../../WebService/JudgeSess.ashx?state=1",
                                    type: "post",

                                    dataType: "text",
                                    async: false,
                                    success: function (data) {
                                        var a = data;
                                        if (a == "0") {
                                            location.reload();
                                        }


                                    }
                                })

                            }

                        </script>
                    </div>
                </div>
            </div>
        </div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap" style="margin-top: 100px;">
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
                    <select id="ddlType" name="ddlType" runat="server" style="border-color: #eee; border-width: 1px; border-style: solid; height: 30px; width: 90px; margin-top: -10px;"></select>
                </dd>
            </dl>
            <dl>
                <dt>悬赏积分</dt>
                <dd>
                    <input type="text" id="txtReword" name="txtReword" class="input normal" value="0" />
                </dd>
            </dl>
            <dl>
                <dt>标题</dt>
                <dd>
                    <input type="text" id="txtTitle" name="txtTitle" class="input normal" />
                </dd>
            </dl>
            <dl>
                <dt>关键词</dt>
                <dd>
                    <input type="text" id="txtKeyWord" name="txtKeyWord" class="input normal" />
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>内容</dt>

                <dd>
                    <textarea id="txtContent" name="txtContent" class="input normal" style="height: 200px; width: 80%"></textarea><span class="Validform_checktip">*内容</span>
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
            <div>
                <input name="btnSubmit" type="submit" onclick="return CheckValue()" value="保存" class="btn" style="width: 90px; height: 40px;" />
                <input name="btnReturn" type="button" value="返回" class="btn" style="width: 90px; height: 40px;" onclick="javascript: history.back(-1);" />
            </div>
        </div>
        <!--/工具栏-->
    </form>
    <script src="../skin_v2/js/niuge.confirm.js"></script>
    <script>

        $().ready(function () {
            //获取cookie的值
            var username = $.cookie('username');
            var password = $.cookie('password');

            //将获取的值填充入输入框中
            $('#username').val(username);
            $('#password').val(password);
            if (username != null && username != '' && password != null && password != '') {//选中保存秘密的复选框
                $("#checkr").attr('checked', true);
            }
        })

        function CheckValue() {
            var record = $('#txtReword').val();
            if ((record == null || record.trim() == "")) {
                alert("悬赏积分不能为空");
                $('#txtReword').focus();
                return false;
            }
            else {
                if(isNaN(parseInt(record.trim()))){
                    alert('悬赏积分不是数字！请重新输入');
                    $('#txtReword').focus();
                    return false;
                }
            }

            var point = <%= model.Point.ToString()%>;
            
            if(point < record){
                alert('悬赏积分不足，请重新输入！');
                $('#txtReword').focus();
                return false;
            }

            if ($('#txtTitle').val() == null || $('#txtTitle').val().trim() == "") {
                alert('标题不能为空！');
                return false;
            }

            var ue = UE.getEditor('txtContent');
            var s = ue.getContentTxt();//s编辑器带格式内容
            if (s == null || s.trim() == "") {
                alert('内容不能为空！');
                return false;
            }
            return true;
        }
    </script>
</body>
</html>
