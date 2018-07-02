<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnterpriseRegistration_Show.aspx.cs" Inherits="HN863Soft.ISS.Web.Web.EnterpriseRegistration.EnterpriseRegistration_Show" %>

<%@ Import Namespace="HN863Soft.ISS.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查看工商注册信息</title>
    <link href="../skin_v2/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../CSS/tutor.css" rel="stylesheet" />
    <link href="../CSS/Show/base.css" rel="stylesheet" />
    <link href="../CSS/font-awesome.min.css" rel="stylesheet" />
    <link href="../CSS/Heard/css.css" rel="stylesheet" />

    <script src="../skin_v2/js/jquery.js"></script>
    <script src="../skin_v2/js/bootstrap.min.js"></script>
    <script src="../Scripts/jquery-1.8.0.min.js"></script>
    <script src="../skin_v2/js/global.js"></script>
    <script src="../skin_v2/js/niuge.confirm.js"></script>
    <script src="../User/resources/js/jquery.cookie.js"></script>

    <link rel="stylesheet" type="text/css" href="../skin_v2/css/global.css" />
    <%-- <script src="../Scripts/jquery-1.8.0.min.js"></script>--%>
    <script type="text/javascript" src="../skin_v2/js/responsive.min.js"></script>
</head>
<body>
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
                <li class="active on"><a href="#s2" class="selected">工商财税</a>
                    <ul class="submenu">
                        <li><a href="../EnterpriseRegistration/EnterpriseRegistration_List.aspx">工商注册</a></li>
                        <li><a href="../Fiscal/Fiscal_List.aspx">财税服务</a></li>
                        <li><a href="../Intellectual/Intellectual_List.aspx">知识产权</a></li>
                    </ul>
                </li>
                <li><a href="#">专业技术服务</a>
                    <ul class="submenu">
                        <li><a href="../Ariticle/Ariticle_List.aspx">工业设计</a></li>
                        <li><a href='../SoftWareS/List.aspx?TypeName=<%=EnumsHelper.SoftType.SoftwareServiceType.ToString() %>'>软件服务</a></li>
                        <li><a href='../SoftWareS/List.aspx?TypeName=<%=EnumsHelper.SoftType.HSEConsulting.ToString() %>'><%#EnumsHelper.FetchDescription(EnumsHelper.SoftType.HSEConsulting) %>高企认定咨询</a></li>
                        <li><a href='../SoftWareS/List.aspx?TypeName=<%=EnumsHelper.SoftType.SoftConsulting.ToString() %>'><%#EnumsHelper.FetchDescription(EnumsHelper.SoftType.SoftConsulting) %>双软认定咨询</a></li>
                        <li><a href="../TalentService/TalentService_List.aspx">人才服务</a></li>
                    </ul>
                </li>
                <li><a href="../EnterIncubating/EIIndex.aspx">孵化器</a></li>
                <li><a href="../MeetingActivity/MeetingActiveList.aspx">难题吐槽 </a></li>
                <li><a href="../PolicyHall/PHList.aspx">政策大厅 </a></li>

            </ul>
            <div class="header-right" id="min-nav">
                <div class="login-register" id="min-zhuce" style="display: none">
                    <a class="nav-btn-login" href="javascript:">登录</a>
                    <a class="nav-btn-reg" href="/Web/User/NewRegister.html" target="_blank">注册</a>
                </div>
                <div class="login-register" style="display: none" id="web">

                    <div class="dropdown">

                        <a id="aName" href="" class="dropdown-toggle top-avatar" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" style="float: right; text-align: center">您好：
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
    <div class="row" style="margin-top: 70px; background: #e8e9ed;">
        <div class="user-info niui-w">
            <dl>
                <dd>
                    <img runat="server" id="img1"></dd>
                <dt>
                    <div id="jlxqtittext" style="width: 100%">
                        <br />
                        <h3 style="overflow: hidden; width: 500px; float: left; margin-top: 0px; white-space: nowrap" id="move"><%=model.Title %></h3>

                        <h3 style="width: 270px; float: left;white-space:nowrap;"><span class="hot-city" style="font-size: 14px; margin-left: 40px;">
                            <img src="../CSS/Show/bq.png" />
                            <%=model.KeyWord %>	</span></h3>


                    </div>
                    <br />
                    <br />
                    <br />
                    <p class="dt-div" style="width: 220px; text-align: left">
                        综合评分
								
                                    <span class="tutor-data1-stars">
                                        <i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i>
                                    </span>

                    </p>
                    <br />
                    <p style="word-wrap: break-word; word-break: normal; width: 760px" class="user-intro"><%=model.Introduce %> </p>

                </dt>
            </dl>
        </div>
        <div class="small-nav niui-w">
            <ul>
                <li class="active">详情</li>
                <div style="float: right; background: #e8e9ed">
                    <input id="btnComplaint" runat="server" type="button" onclick="EV_modeAlert('envon')" value="举报" style="background: #e8e9ed" />
                    <input id="btnHandle" visible="false" runat="server" type="button" onclick="EV_modeAlert('Handle')" value="  处理举报信息" style="background: #e8e9ed" />
                    <input id="btnAdd" visible="false" runat="server" type="button" onclick="JoinPromotion()" value="  添加推广" style="background: #e8e9ed" />
                    <input id="btnDel" visible="false" runat="server" type="button" onclick="CancelPromotion()" value="  取消推广" style="background: #e8e9ed" />
                </div>
            </ul>
        </div>
        <div id="envon" class="pop-space-co" style="width: 500px; display: none; background: #FFFFFF">
            <div class="pop-close pop-login-close" onclick="EV_closeAlert()">
                <img src="../skin_v2/image/close.png" style="width: 26px; height: 26px" />
            </div>
            <div style="text-align: center"></div>
            <br />
            <br />
            <br />
            <div style="text-align: center">
                <label class="label-s"><span>举报原因<b>＊</b></span><textarea name="reason" id="traReport" class="pop-space-txt" maxlength="250" style="width: 300px;"></textarea></label>
            </div>
            <div id="btnReport" class="pop-space-btn" style="width: 240px; margin-left: 120px">提交</div>
        </div>
        <div id="Handle" class="pop-space-co" style="width: 500px; display: none; background: #FFFFFF">
            <div class="pop-close pop-login-close" onclick="EV_closeAlert()">
                <img src="../skin_v2/image/close.png" style="width: 26px; height: 26px" />
            </div>
            <div style="text-align: center"></div>
            <br />
            <br />
            <br />
            <div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="radio" id="forever" name="myradio" value="1" />
                <span>此信息违反相关规定，打回重新编辑，再次审核</span>
                <br />
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="radio" id="casual" name="myradio" checked="checked" value="2" />
                <span>此信息正常，无效举报</span>
            </div>
            <br />
            <div id="btnProcessing" class="pop-space-btn" style="width: 240px; margin-left: 120px">提交</div>
        </div>
    </div>
    <div class="row" style="padding: 30px; background: #f8f8f8; height: auto">
        <div class="user-info niui-w" style="height: auto">
            <div style="width: auto; height: auto; background: #FFFFFF"><%=model.Content %></div>
        </div>
    </div>
    <div class="footer">
        <div class="footer-main niui-w">
            <div class="footer-main-left">
                <dl>
                    <dt>关于</dt>
                    <dd><a href="../About.html" target="_blank">公司简介</a></dd>
                    <dd><a href="../ServiceTerms.html" target="_blank">服务条款</a></dd>
                </dl>
                <dl>
                    <dt>专业技术服务</dt>
                    <dd><a href="../Ariticle/Ariticle_List.aspx">工业设计</a></dd>
                    <dd><a href="../SoftWareS/List.aspx?TypeName=SoftwareServiceType ">软件服务</a></dd>
                    <dd><a href="../SoftWareS/List.aspx?TypeName=HSEConsulting ">高企认定咨询</a></dd>
                    <dd><a href="../SoftWareS/List.aspx?TypeName=SoftConsulting ">双软认定咨询</a></dd>
                    <dd><a href="../TalentService/TalentService_List.aspx">人才服务</a></dd>
                </dl>
                <dl>
                    <dt>工商财税</dt>
                    <dd><a href="../EnterpriseRegistration/EnterpriseRegistration_List.aspx">工商注册</a></dd>
                    <dd><a href="../Fiscal/Fiscal_List.aspx">财税服务</a></dd>
                    <dd><a href="../Intellectual/Intellectual_List.aspx">知识产权</a></dd>
                </dl>
                <dl>
                    <dt>孵化器</dt>
                    <dd><a href="../EnterIncubating/EIIndex.aspx">孵化器</a></dd>
                </dl>
                <dl>
                    <dt>难题吐槽</dt>
                    <dd><a href="../MeetingActivity/MeetingActiveList.aspx">难题吐槽</a></dd>
                </dl>
                <dl>
                    <dt>政策大厅</dt>
                    <dd><a href="../PolicyHall/PHList.aspx">政策大厅</a></dd>
                </dl>
                <dl style="width: 28%;">
                    <dt>联系</dt>
                    <dd class="consult" style="border-bottom: 1px #eee solid; margin-right: 50px; margin-bottom: 10px;">
                        <span style="font-size: 14px; font-weight: 600; color: #464646;"><i class="glyphicon glyphicon-earphone" style="color: #717171; font-weight: 400;"></i>&nbsp;电话：</span>
                        <span style="font-size: 16px; font-weight: 600; color: #6eb92b;">0371-67579123</span>
                    </dd>
                    <dd class="consult"><span><i class="glyphicon glyphicon-print"></i>&nbsp;传真：</span><span style="">0371-67579123</span>

                    </dd>
                    <dd><span><i class="glyphicon glyphicon-envelope"></i>&nbsp;邮箱：</span><span class="">hnppc@163.com</span></dd>
                    <dd><span><i class="glyphicon glyphicon-map-marker"></i>&nbsp;地址：</span><span class="">郑州市高新技术开发区翠竹街6号国家863中部软件园</span></dd>
                </dl>
            </div>
        </div>
    </div>
    <!-- pop -->
    <div class="pop-layer"></div>
    <!-- login -->
    <div class="pop-login">
        <div class="pop-close pop-login-close">
            <img src="../skin_v2/image/close.png" style="width: 26px; height: 26px" />
        </div>
        <h3>登录</h3>
        <div class="pop-login-co">
            <form class="form-login" name="form3" method="post">
                <label><span>用户名</span><input type="text" id="username" name="username" value="" placeholder="用户名"></label>
                <label><span>密码</span><input type="password" id="password" name="password" value="" placeholder="密码"></label>
                <div class="login-check">
                    <label>
                        <input type="checkbox" name="checkr" id="checkr" style="width: 16px; font-size: 14px" />记住我
                    </label>
                    <a href="/Web/User/RetrievePassword.html" target="_blank">忘记密码</a>
                </div>
                <div class="login-btn">登录</div>
                <div class="logup-btn">还没有平台帐号 <a href="/Web/User/NewRegister.html" target="_blank">立即注册</a></div>
            </form>
        </div>
    </div>
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

        function JoinPromotion() {
            $.ajax({
                url: "../../WebService/Report.ashx?state=3",
                type: "post",
                data: {
                    url: window.location.href,
                    title: $("#move").text()
                },
                dataType: "text",
                async: false,
                success: function (data) {
                    var a = data;

                    if (a == "1") {
                        $.MsgBox.Alert('处理完成！');
                        setTimeout(function () { EV_closeAlert(); }, 2500);
                        location.reload();
                    }
                    else {
                        $.MsgBox.Alert('处理失败，请稍后再试！');
                        location.reload();
                    }


                }
            })
        }

        function CancelPromotion() {
            $.ajax({
                url: "../../WebService/Report.ashx?state=4",
                type: "post",
                data: {
                    url: window.location.href
                },
                dataType: "text",
                async: false,
                success: function (data) {
                    var a = data;

                    if (a == "1") {
                        $.MsgBox.Alert('处理完成！');
                        setTimeout(function () { EV_closeAlert(); }, 2500);
                        location.reload();
                    }
                    else {
                        $.MsgBox.Alert('处理失败，请稍后再试！');
                        location.reload();
                    }


                }
            })
        }
    </script>
    <script>
        (function (ns) {
            function Scroll(element) {

                var content = document.createElement("h3");
                var container = document.createElement("h3");

                //content.class = "jlxqTitle_h3";
                //container.class = "jlxqTitle_h3";

                var _this = this;
                var cssText = "position: absolute; visibility:hidden; left:0; white-space:nowrap;";
                this.element = element;
                this.contentWidth = 0;
                this.stop = false;

                content.innerHTML = element.innerHTML;

                //获取元素真实宽度  
                content.style.cssText = cssText;
                element.appendChild(content);
                this.contentWidth = content.offsetWidth;

                content.style.cssText = "float:left;";
                container.style.cssText = "width: " + (this.contentWidth * 2) + "px; overflow:hidden";
                //container.appendChild(content);
                container.appendChild(content.cloneNode(true));
                element.innerHTML = "";
                element.appendChild(container);

                container.onmouseover = function (e) {
                    clearInterval(_this.timer);

                };

                container.onmouseout = function (e) {
                    _this.timer = setInterval(function () {
                        _this.run();
                    }, 20);


                };
                _this.timer = setInterval(function () {
                    _this.run();
                }, 20);
            }

            Scroll.prototype = {

                run: function () {

                    var _this = this;
                    var element = _this.element;

                    element.scrollLeft = element.scrollLeft + 1;

                    if (element.scrollLeft >= this.contentWidth) {
                        element.scrollLeft = 0;
                    }
                }
            };
            ns.Scroll = Scroll;
        }(window));
        window.onload = function () {


            var divWidth = $("#move").width();//div的宽度


            var dwmc = document.getElementById("move");//js对象
            var dwmcWidth = dwmc.scrollWidth;//文本的宽度

            if (dwmcWidth > divWidth) {
                var sc = new Scroll(document.getElementById("move"));
            }


        }
    </script>

    <script>

        var EV_MsgBox_ID = ""; //重要

        //弹出对话窗口(msgID-要显示的div的id)
        function EV_modeAlert(msgID) {

            var sta = "";

            $.ajax({
                url: "../../WebService/JudgeSess.ashx?state=0",
                type: "post",

                dataType: "text",
                async: false,
                success: function (data) {
                    var a = data;

                    if (a == "") {
                        $('.pop-login').css("display", "block");
                        sta = "1";
                    }


                }
            })

            if (sta == "") {

                //创建大大的背景框
                var bgObj = document.createElement("div");
                bgObj.setAttribute('id', 'EV_bgModeAlertDiv');
                document.body.appendChild(bgObj);
                //背景框满窗口显示
                EV_Show_bgDiv();
                //把要显示的div居中显示
                EV_MsgBox_ID = msgID;
                EV_Show_msgDiv();
            }
        }

        //关闭对话窗口
        function EV_closeAlert() {
            var msgObj = document.getElementById(EV_MsgBox_ID);
            var bgObj = document.getElementById("EV_bgModeAlertDiv");
            msgObj.style.display = "none";
            document.body.removeChild(bgObj);
            EV_MsgBox_ID = "";
        }

        //窗口大小改变时更正显示大小和位置
        window.onresize = function () {
            if (EV_MsgBox_ID.length > 0) {
                EV_Show_bgDiv();
                EV_Show_msgDiv();
            }
        }

        //窗口滚动条拖动时更正显示大小和位置
        window.onscroll = function () {
            if (EV_MsgBox_ID.length > 0) {
                EV_Show_bgDiv();
                EV_Show_msgDiv();
            }
        }

        //把要显示的div居中显示
        function EV_Show_msgDiv() {
            var msgObj = document.getElementById(EV_MsgBox_ID);
            msgObj.style.display = "block";
            var msgWidth = msgObj.scrollWidth;
            var msgHeight = msgObj.scrollHeight;
            var bgTop = EV_myScrollTop();
            var bgLeft = EV_myScrollLeft();
            var bgWidth = EV_myClientWidth();
            var bgHeight = EV_myClientHeight();
            var msgTop = bgTop + Math.round((bgHeight - msgHeight) / 2);
            var msgLeft = bgLeft + Math.round((bgWidth - msgWidth) / 2);
            msgObj.style.position = "absolute";
            msgObj.style.top = msgTop + "px";
            msgObj.style.left = msgLeft + "px";
            msgObj.style.zIndex = "10001";

        }
        //背景框满窗口显示
        function EV_Show_bgDiv() {
            var bgObj = document.getElementById("EV_bgModeAlertDiv");
            var bgWidth = EV_myClientWidth();
            var bgHeight = EV_myClientHeight();
            var bgTop = EV_myScrollTop();
            var bgLeft = EV_myScrollLeft();
            bgObj.style.position = "absolute";
            bgObj.style.top = bgTop + "px";
            bgObj.style.left = bgLeft + "px";
            bgObj.style.width = bgWidth + "px";
            bgObj.style.height = bgHeight + "px";
            bgObj.style.zIndex = "10000";
            bgObj.style.background = "#777";
            bgObj.style.filter = "progid:DXImageTransform.Microsoft.Alpha(style=0,opacity=60,finishOpacity=60);";
            bgObj.style.opacity = "0.6";
        }
        //网页被卷去的上高度
        function EV_myScrollTop() {
            var n = window.pageYOffset
            || document.documentElement.scrollTop
            || document.body.scrollTop || 0;
            return n;
        }
        //网页被卷去的左宽度
        function EV_myScrollLeft() {
            var n = window.pageXOffset
            || document.documentElement.scrollLeft
            || document.body.scrollLeft || 0;
            return n;
        }
        //网页可见区域宽
        function EV_myClientWidth() {
            var n = document.documentElement.clientWidth
            || document.body.clientWidth || 0;
            return n;
        }
        //网页可见区域高
        function EV_myClientHeight() {
            var n = document.documentElement.clientHeight
            || document.body.clientHeight || 0;
            return n;
        }
    </script>

    <script>
        $(function () {

            //举报
            $('#btnReport').click(function () {
                var reason = $('#traReport').val();

                if (reason == "") { $.MsgBox.Alert('请填写举报原因'); return false; }

                $.ajax({
                    url: "../../WebService/Report.ashx?state=0",
                    type: "post",
                    data: {
                        reason: reason.trim(),
                        url: window.location.href,
                        title: $("#move").text()
                    },
                    dataType: "text",
                    async: false,
                    success: function (data) {
                        var a = data;

                        if (a == "1") {
                            $.MsgBox.Alert('您的举报已提交，请等待管理员审核！');
                            setTimeout(function () { EV_closeAlert(); }, 2500);
                            $('#traReport').val("");
                            $('#btnComplaint').attr("disabled", true);
                            $('#btnComplaint').val("已举报");
                        }


                    }
                })
            });

            //举报
            $('#btnProcessing').click(function () {

                var radio = $(":input[name='myradio']");

                var s = "";

                //获取选中值
                for (i = 0; i < radio.length; i++) {
                    if (radio[i].checked) {
                        s = radio[i].value;
                        break;
                    }
                }

                $.ajax({
                    url: "../../WebService/Report.ashx?state=1",
                    type: "post",
                    data: {
                        ustate: s,
                        table: "EnterpriseRegistration",
                        id: GetQueryString("id"),
                        url: window.location.href
                    },
                    dataType: "text",
                    async: false,
                    success: function (data) {
                        var a = data;

                        if (a == "1") {
                            $.MsgBox.Alert('处理完成！');
                            setTimeout(function () { EV_closeAlert(); }, 2500);
                            location.reload();
                        }
                        else {
                            $.MsgBox.Alert('处理失败，请稍后再试！');
                            setTimeout(function () { EV_closeAlert(); }, 2500);
                            location.reload();
                        }


                    }
                })

            });


            function GetQueryString(name) {
                var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
                var r = window.location.search.substr(1).match(reg);
                if (r != null) return unescape(r[2]); return null;
            }

        })
    </script>

</body>
</html>
