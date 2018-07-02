//获取参数
function uget(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

$(document).ready(function () {
    var a = $(window);
    setRootFontSize = function () {
        var c = a.width();
        var b;
        if (c < 320) {
            b = 20
        } else {
            if (640 <= c && c < 1200) {
                b = c * 40 / 1200
            } else {
                if (1200 <= c) {
                    b = 40
                }
            }
        }
        $("html").css("font-size", b + "px")
    };
    a.resize(setRootFontSize).load(setRootFontSize).resize();




    //回车事件
    document.onkeydown = function (event) {

        var e = event || window.event || arguments.callee.caller.arguments[0];
        //console.log(e.path)
        if (e && e.keyCode == 13) { // enter 键

            if ($('.pop-login').css('display') != 'none') $('.login-btn').trigger('click');

            var str = e.target.name;

            if (str == 'keyword') initPagination();
            if (str == 'tutorkeyword') getTutors();
            if (str == 'msg') $('.message-new-btn').trigger('click');
        }

    };

    // 登录
    $('.nav-btn-login,.call-login').click(function (event) {

        $('.pop-layer').fadeIn('fast');
        $('.pop-login').fadeIn('fast');
    });
    // 退出登录
    $('.pop-login-close').click(function (event) {
        $('.pop-layer').fadeOut('fast');
        $('.pop-login').fadeOut('fast');
    });

    //记住否
    $('.form-login .login-check').click(function () {
        if ($(this).find('i.fa-check-square-o').length > 0) {
            $(this).find('i.fa').addClass('fa-square-o').removeClass('fa-check-square-o');
        } else {
            $(this).find('i.fa').addClass('fa-check-square-o').removeClass('fa-square-o');
        }
    })

    //登录表单提交
    $('.login-btn').click(function () {
        var username = $('.form-login input[name="username"]').val();
        var password = $('.form-login input[name="password"]').val();
        var holdme = 0;
        if ($('.form-login .login-check .fa-check-square-o').length > 0) {
            holdme = 1;
        }
        //var holdme   = $('.form-login input[name="holdme"]:checked').val();
        if (username == '' || password == '') {
            $.MsgBox.Alert('帐号和密码不能为空')
        }
        if (holdme != 1) holdme = 0;
        $.post('?c=login', { username: username, password: password, holdme: holdme }, function (msg) {
            if (msg == 'ok') {
                if (uget('c') == 'register') {
                    location.href = 'index.php?c=user';
                } else {
                    location.reload();
                }

            } else {
                $.MsgBox.Alert(msg);
                return false;
            }
        });
    })
});