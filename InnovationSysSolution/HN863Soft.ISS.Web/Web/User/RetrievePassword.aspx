<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RetrievePassword.aspx.cs" Inherits="HN863Soft.ISS.Web.Web.User.RetrievePassword" %>

<!DOCTYPE html>

<html>
<head>
    <title>找回密码</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
    <meta name="keywords">
    <meta name="description">
    <link rel="shortcut icon" href="resources/images/favicon.ico" />
    <link href="resources/style/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="resources/js/jquery.js"></script>
    <script type="text/javascript" src="resources/js/jquery.i18n.properties-1.0.9.js"></script>
    <script type="text/javascript" src="resources/js/jquery-ui-1.10.3.custom.js"></script>
    <script type="text/javascript" src="resources/js/jquery.validate.js"></script>
    <script type="text/javascript" src="resources/js/md5.js"></script>
    <script type="text/javascript" src="resources/js/page_regist.js?lang=zh"></script>
</head>
<body class="loginbody">
    <div class="dataEye">
        <div class="loginbox registbox">
            <div class="logo-a">

            </div>
            <div class="login-content reg-content">
                <div class="loginbox-title">
                    <h3>找回密码</h3>
                </div>
                <form id="signupForm">
                    <div class="login-error"></div>

                    <div class="row">
                        <label class="field" for="rname">用户名</label>
                        <input type="text" value="" maxlength="20" onkeyup="value = value.replace(/[\u4e00-\u9fa5]/g, '')" class="input-text-user noPic input-click" name="rname" id="rname">
                    </div>
                    <div class="row">
                        <label class="field" for="remail">邮箱</label>
                        <input type="text" value="" maxlength="50" class="input-text-user noPic input-click" name="remail" id="remail">
                    </div>
                    <div class="row">
                        <label class="field" for="password">新密码</label>
                        <input type="password" value="" maxlength="12" class="input-text-password noPic input-click" name="password" id="password">
                    </div>

                    <div class="row btnArea">
                        <button id="sub" class="login-btn" value="发送邮件">发送邮件</button>
                    </div>
                </form>
            </div>
        </div>

        <div id="footer">
            <div class="dblock">
<%--                <div class="inline-block">
                    <img src="resources/images/logo-gray.png">
                </div>
                <div class="inline-block copyright">
                    <p><a href="#">关于我们</a> | <a href="#">微博</a> | <a href="#">隐私政策</a> | <a href="#">人员招聘</a></p>
                    <p>Copyright © 2013 JS代码网</p>
                </div>--%>
            </div>
        </div>
    </div>
    <div class="loading">
        <div class="mask">
            <div class="loading-img">
                <img src="resources/images/loading.gif" width="31" height="31">
            </div>
        </div>
    </div>
    <script>

        $("#sub").bind("click", function () {
            regist();
        });

        function regist() {

            var validate = $("#signupForm").validate({
                rules: {
                    remail: {
                        required: true,
                        email: true
                    },
                    password: {
                        required: true,
                        minlength: 6,
                        maxlength: 12
                    },
                    passwordAgain: {
                        required: true,
                        minlength: 6,
                        maxlength: 12,
                        equalTo: "#password"
                    },
                    rname: {
                        required: true,
                        minlength: 8,

                    },
                    name: {
                        minlength: 8,

                        required: true,
                        remote: {
                            url: "/WebService/VerifyUsername.ashx",

                            data: {
                                name: function () {
                                    return $("#name").val();
                                }

                            },
                            //dataFilter: function (data, type) {//判断控制器返回的内容
                            //    if (data == "0") {
                            //        alert(12312121);
                            //        return false;
                            //    }
                            //    else if (data == "1") {

                            //        return false;
                            //    }
                            //}



                        }
                    },
                    company: {
                        required: true,
                        maxlength: 10
                    },
                    tel: {
                        required: true,
                        digits: true
                    },
                    qq: {
                        required: true,
                        digits: true
                    }
                },
                messages: {
                    remail: {
                        required: $.i18n.prop("请输入邮箱地址"),
                        email: $.i18n.prop("请输入邮箱地址")
                    },
                    password: {
                        required: $.i18n.prop("请输入密码"),
                        minlength: jQuery.format($.i18n.prop("长度不能少于6位")),
                        maxlength: jQuery.format($.i18n.prop("长度不能大于12位"))
                    },
                    passwordAgain: {
                        required: $.i18n.prop("请再次输入密码"),
                        minlength: jQuery.format($.i18n.prop("长度不能少于6位")),
                        maxlength: jQuery.format($.i18n.prop("长度不能大于12位")),
                        equalTo: jQuery.format($.i18n.prop("两次密码输入不一致！"))
                    },
                    name: {
                        minlength: jQuery.format($.i18n.prop("用户名长度不能少于8位")),

                        required: $.i18n.prop("请输入用户名"),
                        remote: '用户名已被注册'
                    },
                    rname: {
                        minlength: jQuery.format($.i18n.prop("用户名长度不能少于8位")),

                        required: $.i18n.prop("请输入用户名")

                    },
                    company: {
                        required: $.i18n.prop("请输入昵称"),

                    },
                    tel: {
                        required: $.i18n.prop("Form.PleaseInputTel"),
                        digits: $.i18n.prop("Form.IncorrectFormatTel")
                    },
                    qq: {
                        required: $.i18n.prop("Form.PleaseInputQQ"),
                        digits: $.i18n.prop("Form.IncorrectFormatQQ")
                    }
                }
            });




            if (validate.form()) {




                $.ajax({
                    url: "/WebService/RetrievePassword.ashx?action=ValidationInformation",
                    type: "post",
                    data: {
                        rname: $("#rname").val(),
                        email: $("#remail").val(),
                        password: $("#password").val()
                    },
                    dataType: "json",
                    async: false,
                    //contentType: "application/json;charset=utf-8",
                    success: function (data) {
                        var a = data;
                        if (a == "0") {
                            alert("邮件发送成功！请到邮箱进行验证");
                            //$.ajax({

                            //    url: "/WebService/RetrievePassword.ashx?action=SendMail",
                            //    type: "post",
                            //    data: {
                            //        rname: $("#rname").val(),
                            //        password: ($("#password").val()),
                            //        email: $("#remail").val(),
                            //    },
                            //    success: function (data) {
                            //        var reust = data;
                            //        if (a == "0") {
                            //            alert("邮件发送成功！请到邮箱进行验证");
                            //        }
                            //        else {
                            //            alert("发送失败！请稍后重试！");
                            //        }

                            //    }
                            //})


                        }
                        else if (a == "-1") {
                            alert("发送失败！请稍后重试！");
                        }

                        else {
                            alert("用户名或邮箱不正确");
                        }
                    }
                })
            }
        }


    </script>
</body>
</html>
