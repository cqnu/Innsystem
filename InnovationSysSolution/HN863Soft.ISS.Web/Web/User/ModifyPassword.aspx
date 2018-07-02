<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyPassword.aspx.cs" Inherits="HN863Soft.ISS.Web.Web.User.ModifyPassword" %>

<!DOCTYPE html>

<html>
<head>
    <title>找回密码</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">

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
                        <input type="text" disabled="disabled" value="30443229" maxlength="20" onkeyup="value = value.replace(/[\u4e00-\u9fa5]/g, '')" class="input-text-user noPic input-click" name="rname" id="rname">
                    </div>
                    <div class="row">
                        <label class="field" for="OldPwd">旧密码</label>
                        <input type="password" value="" class="input-text-password noPic input-click" name="OldPwd" id="OldPwd">
                    </div>
                    <div class="row">
                        <label class="field" for="NewPwd">新密码</label>
                        <input type="password" value="" class="input-text-password noPic input-click" name="NewPwd" id="NewPwd">
                    </div>
                    <div class="row">
                        <label class="field" for="NewpasswordAgain">确认密码</label>
                        <input type="password" value="" class="input-text-password noPic input-click" name="NewpasswordAgain" id="NewpasswordAgain">
                    </div>

                    <div class="row btnArea">
                        <button id="sub" class="login-btn" value="修改">修改</button>
                    </div>
                </form>
            </div>
        </div>

        <div id="footer">

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
                    email: {
                        required: true,
                        email: true,
                        remote: {
                            url: "/WebService/RetrievePassword.ashx?action=ValidationMail",

                            data: {
                                name: function () {
                                    return $("#email").val();
                                }

                            },

                        }

                    },
                    OldPwd: {
                        required: true,

                        remote: {
                            url: "/WebService/ModifyPassword.ashx?action=ValidationPwd",

                            data: {
                                name: function () {
                                    return $("#rname").val();

                                },
                                OldPwd: function () {

                                    return $("#OldPwd").val();
                                }

                            },

                        }

                    },

                    NewPwd: {
                        required: true,
                        minlength: 6,
                        maxlength: 12,

                        remote: {
                            url: "/WebService/ModifyPassword.ashx?action=NewVerification",

                            data: {
                                OldPwd: function () {
                                    return $("#OldPwd").val();

                                },
                                NewPwd: function () {

                                    return $("#NewPwd").val();
                                }

                            },

                        }

                    },


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
                    NewpasswordAgain: {
                        required: true,
                        minlength: 6,
                        maxlength: 12,
                        equalTo: "#NewPwd"
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
                    email: {
                        required: $.i18n.prop("请输入邮箱地址"),
                        email: $.i18n.prop("请输入邮箱地址"),
                        remote: '该邮箱已被注册'
                    },
                    remail: {
                        required: $.i18n.prop("请输入邮箱地址"),
                        email: $.i18n.prop("请输入邮箱地址")
                    },
                    password: {
                        required: $.i18n.prop("请输入密码"),
                        minlength: jQuery.format($.i18n.prop("长度不能少于6位")),
                        maxlength: jQuery.format($.i18n.prop("长度不能大于12位"))
                    },
                    NewPwd: {
                        required: $.i18n.prop("请输入密码"),
                        minlength: jQuery.format($.i18n.prop("长度不能少于6位")),
                        maxlength: jQuery.format($.i18n.prop("长度不能大于12位")),
                        remote: '新旧密码不能一致'
                    },
                    OldPwd: {
                        required: $.i18n.prop("请输入密码"),
                        minlength: jQuery.format($.i18n.prop("长度不能少于6位")),
                        maxlength: jQuery.format($.i18n.prop("长度不能大于12位")),
                        remote: '旧密码不正确'
                    },
                    passwordAgain: {
                        required: $.i18n.prop("请再次输入密码"),
                        minlength: jQuery.format($.i18n.prop("长度不能少于6位")),
                        maxlength: jQuery.format($.i18n.prop("长度不能大于12位")),
                        equalTo: jQuery.format($.i18n.prop("两次密码输入不一致！"))
                    },
                    NewpasswordAgain: {
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
                    url: "/WebService/ModifyPassword.ashx?action=UpdatePwd",
                    type: "post",
                    data: {
                        name: $("#rname").val(),
                        NewPwd: $("#NewPwd").val()
                    },
                    dataType: "json",
                    async: false,
                    //contentType: "application/json;charset=utf-8",
                    success: function (data) {
                        var a = data;
                        if (a == "0") {
                            alert("修改成功！请重新登录");



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
