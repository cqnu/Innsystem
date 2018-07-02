$(document).ready(function () {

    //获取JS传递的语言参数
    var utils = new Utils();
    var args = utils.getScriptArgs();


    //隐藏Loading/注册失败 DIV
    $(".loading").hide();
    $(".login-error").hide();
    registError = $("<label class='error repeated'></label>");

    //加载国际化语言包资源
    utils.loadProperties(args.lang);

    //输入框激活焦点、移除焦点
    jQuery.focusblur = function (focusid) {
        var focusblurid = $(focusid);
        var defval = focusblurid.val();
        focusblurid.focus(function () {
            var thisval = $(this).val();
            if (thisval == defval) {
                $(this).val("");
            }
        });
        focusblurid.blur(function () {
            var thisval = $(this).val();
            if (thisval == "") {
                $(this).val(defval);
            }
        });

    };
    /*下面是调用方法*/
    $.focusblur("#email");

    //获取表单验证对象[填写验证规则]
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


    //输入框激活焦点、溢出焦点的渐变特效
    if ($("#email").val()) {
        $("#email").prev().fadeOut();
    };
    $("#email").focus(function () {
        $(this).prev().fadeOut();
    });
    $("#email").blur(function () {
        if (!$("#email").val()) {
            $(this).prev().fadeIn();
        };
    });

    if ($("#remail").val()) {
        $("#remail").prev().fadeOut();
    };
    $("#remail").focus(function () {
        $(this).prev().fadeOut();
    });
    $("#remail").blur(function () {
        if (!$("#remail").val()) {
            $(this).prev().fadeIn();
        };
    });

    if ($("#OldPwd").val()) {
        $("#OldPwd").prev().fadeOut();
    };
    $("#OldPwd").focus(function () {
        $(this).prev().fadeOut();
    });
    $("#OldPwd").blur(function () {
        if (!$("#OldPwd").val()) {
            $(this).prev().fadeIn();
        };
    });


    if ($("#NewPwd").val()) {
        $("#NewPwd").prev().fadeOut();
    };
    $("#NewPwd").focus(function () {
        $(this).prev().fadeOut();
    });
    $("#NewPwd").blur(function () {
        if (!$("#NewPwd").val()) {
            $(this).prev().fadeIn();
        };
    });

    if ($("#password").val()) {
        $("#password").prev().fadeOut();
    };
    $("#password").focus(function () {
        $(this).prev().fadeOut();
    });
    $("#password").blur(function () {
        if (!$("#password").val()) {
            $(this).prev().fadeIn();
        };
    });


    if ($("#passwordAgain").val()) {
        $("#passwordAgain").prev().fadeOut();
    };
    $("#passwordAgain").focus(function () {
        $(this).prev().fadeOut();
    });
    $("#passwordAgain").blur(function () {
        if (!$("#passwordAgain").val()) {
            $(this).prev().fadeIn();
        };
    });

    if ($("#NewpasswordAgain").val()) {
        $("#NewpasswordAgain").prev().fadeOut();
    };
    $("#NewpasswordAgain").focus(function () {
        $(this).prev().fadeOut();
    });
    $("#NewpasswordAgain").blur(function () {
        if (!$("#NewpasswordAgain").val()) {
            $(this).prev().fadeIn();
        };
    });

    if ($("#name").val()) {
        $("#name").prev().fadeOut();
    };
    $("#name").focus(function () {
        $(this).prev().fadeOut();
    });
    $("#name").blur(function () {
        if (!$("#name").val()) {
            $(this).prev().fadeIn();
        };
    });


    if ($("#rname").val()) {
        $("#rname").prev().fadeOut();
    };
    $("#rname").focus(function () {
        $(this).prev().fadeOut();
    });
    $("#rname").blur(function () {
        if (!$("#rname").val()) {
            $(this).prev().fadeIn();
        };
    });

    if ($("#company").val()) {
        $("#company").prev().fadeOut();
    };
    $("#company").focus(function () {
        $(this).prev().fadeOut();
    });
    $("#company").blur(function () {
        if (!$("#company").val()) {
            $(this).prev().fadeIn();
        };
    });
    if ($("#tel").val()) {
        $("#tel").prev().fadeOut();
    };
    $("#tel").focus(function () {
        $(this).prev().fadeOut();
    });
    $("#tel").blur(function () {
        if (!$("#tel").val()) {
            $(this).prev().fadeIn();
        };
    });
    if ($("#qq").val()) {
        $("#qq").prev().fadeOut();
    };
    $("#qq").focus(function () {
        $(this).prev().fadeOut();
    });
    $("#qq").blur(function () {
        if (!$("#qq").val()) {
            $(this).prev().fadeIn();
        };
    });

    //ajax提交注册信息
    $("#submit").bind("click", function () {
        regist(validate);
    });

    $("body").each(function () {
        $(this).keydown(function () {
            if (event.keyCode == 13) {
                regist(validate);
            }
        });
    });

});

function regist(validate) {
    //校验Email, password，校验如果失败的话不提交
    if (validate.form()) {
        if ($("#checkBox").attr("checked")) {
            //var md5 = new MD5();



            $.ajax({
                url: "/WebService/Regist.ashx",
                type: "post",
                async: false,
                data: {
                    name: $("#name").val(),
                    password: ($("#password").val()),
                    email: $("#email").val(),
                    company: $("#company").val(),
                    type: $("#ch1").attr("checked") ? $("#ch1").val() : $("#ch2").val()


                },
                dataType: "json",
                //beforeSend: function () {
                //    $('.loading').show();
                //},
                success: function (data) {
                    var a = data;
                    if (a > 0) {
                        alert("注册成功！请到邮箱进行验证！");
                        window.location.reload();
                    }

                    //$('.loading').hide();

                    //if (data > 0) {

                    //}
                    //else {
                    //    $(".login-error").html($.i18n.prop("Error.SysError"));
                    //}
                }

                //success: function (data) {
                //    $('.loading').hide();
                //    if (data.hasOwnProperty("code")) {
                //        if (data.code == 0) {
                //            //注册成功
                //            window.location.href = "registOk.jsp?email=" + $('#email').val();
                //        } else if (data.code == 1) {
                //            //数据库链接失败
                //            $(".login-error").html($.i18n.prop("Error.Exception"));
                //        } else if (data.code == 2) {
                //            //参数传递失败
                //            $(".login-error").show();
                //            $(".login-error").html($.i18n.prop("Error.ParameterError"));
                //        } else if (data.code == 3) {
                //            //公司已经被注册
                //            $("#company").addClass("error");
                //            $("#company").after(registError);
                //            $("#company").next("label.repeated").text($.i18n.prop("Error.CompaniesAlreadyExists"));
                //            registError.show();
                //        } else if (data.code == 4) {
                //            //邮箱已经被注册
                //            $("#email").addClass("error");
                //            $("#email").after(registError);
                //            $("#email").next("label.repeated").text($.i18n.prop("Error.EmailAlreadyExists"));
                //            registError.show();
                //        } else {
                //            //系统错误
                //            $(".login-error").html($.i18n.prop("Error.SysError"));
                //        }
                //    }
                //}
            });
        } else {
            //勾选隐私政策和服务条款
            $(".login-error").show();
            $(".login-error").html($.i18n.prop("请阅读并同意相关条款"));
        }
    }
}

var Utils = function () { };

Utils.prototype.loadProperties = function (lang) {
    jQuery.i18n.properties({// 加载资浏览器语言对应的资源文件
        name: 'ApplicationResources',
        language: lang,
        path: 'resources/i18n/',
        mode: 'map',
        callback: function () {// 加载成功后设置显示内容
        }
    });
};

Utils.prototype.getScriptArgs = function () {//获取多个参数
    var scripts = document.getElementsByTagName("script"),
    //因为当前dom加载时后面的script标签还未加载，所以最后一个就是当前的script
    script = scripts[scripts.length - 1],
    src = script.src,
    reg = /(?:\?|&)(.*?)=(.*?)(?=&|$)/g,
    temp, res = {};
    while ((temp = reg.exec(src)) != null) res[temp[1]] = decodeURIComponent(temp[2]);
    return res;
};
