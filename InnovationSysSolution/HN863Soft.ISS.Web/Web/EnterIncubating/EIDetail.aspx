<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EIDetail.aspx.cs" ValidateRequest="false" Inherits="HN863Soft.ISS.Web.Web.EnterIncubating.EIDetail" %>

<%@ Import Namespace="HN863Soft.ISS.Common" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html>

<html class="js" style="font-size: 40px;">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width,initial-scale=1">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telphone=no, email=no">
    <meta name="renderer" content="webkit">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="HandheldFriendly" content="true">
    <meta name="MobileOptimized" content="320">
    <meta name="screen-orientation" content="portrait">
    <meta name="x5-orientation" content="portrait">
    <meta name="full-screen" content="yes">
    <meta name="x5-fullscreen" content="true">
    <meta name="browsermode" content="application">
    <meta name="x5-page-mode" content="app">
    <meta name="msapplication-tap-highlight" content="no">

    <meta content="initial-scale=1.0, minimum-scale=1.0, maximum-scale=2.0, user-scalable=no, width=device-width" name="viewport">
    <meta content="" name="keywords">
    <meta content="" name="description">

    <title>孵化器信息</title>

    <link rel="stylesheet" type="text/css" href="../CSS/ECss/font-awesome.min.css">
    <link href="../../video/video-js.css" rel="stylesheet" />
    <script src="../skin_v2/js/jquery.js"></script>
    <script src="../../video/video.js"></script>
    <script src="../skin_v2/js/bootstrap.min.js"></script>
    <script src="../skin_v2/js/global.js"></script>
    <script src="../skin_v2/js/niuge.confirm.js"></script>
    <script src="../User/resources/js/jquery.cookie.js"></script>

    <link rel="stylesheet" type="text/css" href="../CSS/ECss/page.css">
    <link rel="stylesheet" type="text/css" href="../CSS/ECss/foundation-datepicker.css">
    <link rel="stylesheet" type="text/css" href="../CSS/ECss/space.css">
    <!--bootstrapjs-->

    <link href="../CSS/Heard/css.css" rel="stylesheet" />

    <link href="../CSS/tutor.css" rel="stylesheet" />
    <link href="../skin_v2/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../CSS/Show/base.css" rel="stylesheet" />

    <link rel="stylesheet" type="text/css" href="../skin_v2/css/global.css" />
    <script type="text/javascript" src="../skin_v2/js/responsive.min.js"></script>

    <style type="text/css">
        * {
            padding: 0;
            margin: 0;
        }

        #mbOverlay {
            position: fixed;
            z-index: 9998;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: #000;
            cursor: pointer;
        }

            #mbOverlay.mbOverlayFF {
                background: transparent url(80.png) repeat;
            }

            #mbOverlay.mbOverlayIE {
                position: absolute;
            }

        #mbCenter {
            width: 690px;
            height: 557px;
            position: absolute;
            z-index: 9999;
            left: 50%;
            background-color: #fff;
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            -moz-box-shadow: 0 10px 40px rgba(0, 0, 0, 0.70);
            -webkit-box-shadow: 0 10px 40px rgba(0, 0, 0, 0.70);
        }

            #mbCenter.mbLoading {
                background: #fff url(WhiteLoading.gif) no-repeat center;
                -moz-box-shadow: none;
                -webkit-box-shadow: none;
            }

        #mbImage {
            left: 0;
            top: 0;
            font-family: Myriad, Verdana, Arial, Helvetica, sans-serif;
            line-height: 20px;
            font-size: 12px;
            color: #fff;
            text-align: left;
            background-position: center center;
            background-repeat: no-repeat;
            padding: 10px;
        }

            #mbImage img {
                width: 100%;
                height: 100%;
            }

            #mbImage a, #mbImage a:link, #mbImage a:visited {
                color: #ddd;
            }

                #mbImage a:hover, #mbImage a:active {
                    color: #fff;
                }

        #mbBottom {
            min-height: 20px;
            font-family: Myriad, Verdana, Arial, Helvetica, sans-serif;
            line-height: 20px;
            font-size: 12px;
            color: #999;
            text-align: left;
            padding: 0 10px 10px;
        }

        #mbTitle {
            display: inline;
            color: #999;
            font-weight: bold;
            line-height: 20px;
            font-size: 12px;
        }

        #mbNumber {
            background: url(mbNumber_bg.gif) no-repeat center;
            display: inline;
            color: #C00;
            line-height: 26px;
            font-size: 12px;
            position: absolute;
            bottom: 10px;
            right: 10px;
            text-align: center;
            width: 65px;
            height: 26px;
        }

        #mbCaption {
            display: block;
            color: #999;
            line-height: 14px;
            font-size: 10px;
        }

        #mbPrevLink, #mbNextLink, #mbCloseLink {
            display: block;
            float: right;
            height: 20px;
            margin: 0;
            outline: none;
        }

        #mbPrevLink {
            width: 32px;
            height: 100px;
            background: transparent url(../CSS/EImg/CustomBlackPrevious.gif) no-repeat center;
            position: absolute;
            top: 38%;
            left: -32px;
        }

        #mbNextLink {
            width: 32px;
            height: 100px;
            background: transparent url(../CSS/EImg/CustomBlackNext.gif) no-repeat center;
            position: absolute;
            top: 38%;
            right: -32px;
        }

        #mbCloseLink {
            width: 24px;
            background: transparent url(../CSS/EImg/CustomBlackClose.gif) no-repeat center;
            position: absolute;
            top: 10px;
            right: 10px;
        }

        #mbError {
            position: relative;
            font-family: Myriad, Verdana, Arial, Helvetica, sans-serif;
            line-height: 20px;
            font-size: 12px;
            color: #fff;
            text-align: center;
            border: 10px solid #700;
            padding: 10px 10px 10px;
            margin: 20px;
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
        }

            #mbError a, #mbError a:link, #mbError a:visited, #mbError a:hover, #mbError a:active {
                color: #d00;
                font-weight: bold;
                text-decoration: underline;
            }

        .layout_default {
            float: left;
            margin: 5px;
        }

        .mod_gallerylist {
            width: 665px;
            margin: 0 auto;
        }

        .meta {
            font-size: 12px;
            text-align: center;
        }

        .image_container img {
            border: 1px solid #CCC;
            padding: 2px;
        }

        .meta a {
            color: #333;
            text-decoration: none;
        }
    </style>

    <script src="../CSS/EJs/mootools-core.js"></script>
    <script src="../CSS/EJs/mediabox.js"></script>
    <script>
        $(function () {
            $('#drop3').dropdown('toggle')
        })
    </script>
    <!--baidumap-->
    <style>
        .certi-play-btn {
            width: 60px;
            height: 30px;
            line-height: 30px;
            overflow: hidden;
            position: relative;
            margin: 0;
            float: left;
            background: #679CD2;
            text-align: center;
            color: #fff;
            border-radius: 0 3px 3px 0;
            cursor: pointer;
            margin-left: -1px;
        }

            .certi-play-btn input {
                opacity: 0;
                position: absolute;
                width: 60px;
                height: 30px;
                display: block;
                left: 0;
                top: 0;
            }

        .file-upload-loading {
            position: absolute;
            width: 560px;
            height: 595px;
            left: 0;
            top: 0;
            z-index: 99999;
            padding-top: 310px;
            display: none;
        }
    </style>

    <style>
        @font-face {
            font-family: ucnexus-iconfont;
            src: url(chrome-extension://pogijhnlcfmcppgimcaccdkmbedjkmhi/res/font_9qmmi8b8jsxxbt9.woff) format('woff'),url(chrome-extension://pogijhnlcfmcppgimcaccdkmbedjkmhi/res/font_9qmmi8b8jsxxbt9.ttf) format('truetype');
        }
    </style>
</head>
<body style="background-color: #E8E9ED;">
    <form id="form1" runat="server">
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
                            <li><a href='../SoftWareS/List.aspx?TypeName=<%=EnumsHelper.SoftType.SoftwareServiceType.ToString() %>'>软件服务</a></li>
                            <li><a href='../SoftWareS/List.aspx?TypeName=<%=EnumsHelper.SoftType.HSEConsulting.ToString() %>'><%#EnumsHelper.FetchDescription(EnumsHelper.SoftType.HSEConsulting) %>高企认定咨询</a></li>
                            <li><a href='../SoftWareS/List.aspx?TypeName=<%=EnumsHelper.SoftType.SoftConsulting.ToString() %>'><%#EnumsHelper.FetchDescription(EnumsHelper.SoftType.SoftConsulting) %>双软认定咨询</a></li>
                            <li><a href="../TalentService/TalentService_List.aspx">人才服务</a></li>
                        </ul>
                    </li>
                    <li><a href="../EnterIncubating/EIIndex.aspx" class="selected">孵化器</a></li>
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
        <div class="row" style="margin-top: 10px;">
            <input type="text" hidden="hidden" name="name" id="txtId" value=" " runat="server" />
            <div class="col-md-12 banner">
                <div id="carousel-example-generic" class="carousel slide" data-ride="carousel" data-interval="3000">

                    <!-- Indicators -->
                    <ol class="carousel-indicators">
                        <% for (int i = 1; i <= numImg; i++)
                           { %>
                        <%if (i == 1)
                          {%>
                        <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                        <%}
                          else
                          {%>
                        <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                        <%}%>
                        <%} %>
                    </ol>
                    <!-- Wrapper for slides -->
                    <div class="carousel-inner" role="listbox" style="height: 70%;">
                        <asp:Repeater runat="server" ID="rptImg">
                            <ItemTemplate>
                                <div class='<%# Eval("num").ToString() == "1" ? "item active" : "item"%>'>
                                    <div class="carousel-bg"></div>
                                    <img class="item-img" src='<%#Eval("ImgUrl").ToString().Replace("~/","../../") %>' alt="" style="width: 100%; height: 500px;">
                                    <div class="carousel-caption">
                                        <p style="text-align: left;"></p>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <!-- Controls -->
                    <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                        <span class="fa fa-mc fa-angle-left" aria-hidden="true"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                        <span class="fa fa-mc fa-angle-right" aria-hidden="true"></span>
                        <span class="sr-only">Next</span>
                    </a>
                </div>
            </div>
        </div>
        <div class="row niui-content-1">
            <div class="niui-w show360">
                <h2>
                    <span style="width: 160px; margin-left: -80px;">联系我们</span>
                </h2>
                <br />
                <div style="text-align: center">
                    <a href="javascript:" id="Visit" class="online-show" style="font-size: large;">&nbsp;&nbsp;参观预约</a>
                    <a href="javascript:" id="Apply" class="online-show" style="font-size: large;">&nbsp;&nbsp;入孵申请</a>
                    <a href='<%=webUrl %>' target="_blank" id="weburl" class="online-show" style="font-size: large;">&nbsp;&nbsp;孵化器主页</a>
                    <a target="_blank" style="font-size: large;" href="http://wpa.qq.com/msgrd?v=3&uin=<%=qqUrl %>&site=QQ交谈&menu=yes">
                        <img border="0" src="http://wpa.qq.com/pa?p=1:<%=qqUrl %>:13" alt="欢迎咨询我" title="欢迎咨询我" /></a>
                    <input id="btnAdd" visible="false" runat="server" type="button" onclick="JoinPromotion()" value="  添加推广" style="background: #fff" />
                    <input id="btnDel" visible="false" runat="server" type="button" onclick="CancelPromotion()" value="  取消推广" style="background: #fff" />
                </div>
            </div>
        </div>
        <div class="row niui-content-1" runat="server" id="xVideo">
            <div class="niui-w show360">
                <h2>
                    <span style="width: 160px; margin-left: -80px;">宣传视频</span>
                </h2>
                <br />
                <div style="text-align: center">
                    <video src='<%=url %>' id="example_video_1" controls="metadata" class="video-js vjs-default-skin" width="100%" height="500">
                    </video>
                </div>
            </div>
        </div>

        <%--        <div class="banner-txt-co" style="color: blue; font-size: larger;">
                <div class="banner-txt-co-title">
                    <span id="sTitle" runat="server">孵化器</span>
                </div>
                <br />
                <br />
                <a href="javascript:" id="Visit" class="online-yu2" style="color: blue; font-size: large;">&nbsp;&nbsp;参观预约</a>
                <a href="javascript:" id="Apply" class="online-yu2" style="color: blue; font-size: large;">&nbsp;&nbsp;入孵申请</a>
                <a target="_blank" style ="color:blue;font-size:large;" href="http://wpa.qq.com/msgrd?v=3&uin=448356381&site=QQ交谈&menu=yes"><img border="0" src="http://wpa.qq.com/pa?p=1:448356381:1" alt="欢迎咨询我" title="欢迎咨询我"/></a>
            </div>--%>

        <div class="row niui-content-1">
            <div class="niui-w show360">
                <h2>
                    <span style="width: 160px; margin-left: -80px;">孵化器展示</span>
                </h2>
                <div class="show360-list" id="box">
                    <ul>
                        <!--图片列表-->
                        <asp:Repeater ID="rptList2" runat="server">
                            <ItemTemplate>
                                <li>
                                    <a href='<%#Eval("ImgUrl").ToString().Replace("\\","/").Replace("~","../..") %>' rel="lightbox[ostec]">
                                        <img src='<%#Eval("ImgUrl").ToString().Replace("\\","/").Replace("~","../..") %>' class="pic"></a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div id="frame"></div>
                <h2>
                    <span style="width: 160px; margin-left: -80px;">孵化器说明</span>
                </h2>
                <div class="bz-box">
                    <%--<div class="col-md-4 col-md-offset-5" style="margin-left: 39.5%;">--%>
                    <div>
                        <h3 style="font-size: large; font-weight: 400;">空间特色</h3>
                        <div id="Characteristic" runat="server">
                        </div>
                    </div>
                </div>
                <div class="bz-box">
                    <%--<div class="col-md-4 col-md-offset-5" style="margin-left: 39.5%;">--%>
                    <div>
                        <h3 style="font-size: large; font-weight: 400;">入驻标准</h3>
                        <div id="Standard" runat="server">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <div class="row" style="background-color: #f8f8f8;">
        <div class="niui-w show360">
            <h2>
                <span style="width: 160px; margin-left: -80px;">孵化器地址</span>
            </h2>
        </div>

        <div class="col-md-12 map" style="height: auto;" id="frame1" runat="server">
        </div>
    </div>
    <%--    <div class="row niui-content-1">
        <div class="niui-w show360" style="padding: 0 0 20px 0;">
        </div>
    </div>--%>
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

    <style>
        .wechat_text {
            margin-bottom: .1rem;
        }

        .wechat_text {
            margin-bottom: .1rem!important;
        }

        .wechat_small {
            font-size: 12px;
        }
    </style>

    <!-- pop -->
    <div class="pop-layer" id="applylayer"></div>
    <!-- login -->

    <div class="pop-space" id="applyspace" style="margin-top: -300px; width: 560px; margin-left: -280px;">
        <div class="file-upload-loading">
            <div class="spinner">
                <div class="bounce1"></div>
                <div class="bounce2"></div>
                <div class="bounce3"></div>
            </div>
        </div>
        <div class="pop-close pop-space-close" id="applyspaceclose">
            <%--<i class="iconfont icon-cuo"></i>--%>
            <img src="../skin_v2/image/close.png" style="width: 26px; height: 26px;" />
        </div>
        <h3>入孵申请</h3>
        <form id="form-add-appoinment" action="../../WebService/SubmitAjaxHandler.ashx?action=RepplySubmit" name="" method="post">
            <div class="pop-space-co" style="width: 500px;">
                <label><span>姓名<b>＊</b></span><input type="text" name="truename" value="" maxlength="20" style="width: 300px;"></label>
                <label><span>手机<b>＊</b></span><input type="text" name="mobile" value="" maxlength="20" style="width: 300px;"></label>
                <label><span>邮箱<b>＊</b></span><input type="text" name="email" value="" maxlength="50" style="width: 300px;"></label>
                <label class="label-s"><span>业务简介<b>＊</b></span><textarea name="content" class="pop-space-txt" maxlength="250" style="width: 300px;"></textarea></label>
                <label><span>人数<b>＊</b></span><input type="text" name="count" value="" maxlength="10" style="width: 300px;"></label>
                <label>
                    <span>期望入驻日期<b>＊</b></span><input type="text" name="thedate" value="" class="pop-space-time" id="date-one" style="width: 300px;">
                    <div class="ps-time-btn"></div>
                </label>
                <label>
                    <span>商业计划书<b>*</b></span>
                    <input type="text" class="certi-input-txt" name="file" id="filehref" value="" placeholder="" style="border-right: 0; width: 240px" readonly="">
                    <div class="certi-play-btn">
                        <%--onchange="show(this.value)"--%>
                        <input id="fileupload" type="file" name="fileupload" value="" placeholder="">
                        浏览
        
                    </div>
                    <p style="width: 100%; float: left; margin: 10px 0; padding-left: 120px; font-size: 12px; padding-right: 70px;">
                        支持 pptx,ppt/docx,doc/pdf 格式不超过50M的文件。<br>
                        <font color="#FF6E00">
特别说明：商业计划书仅用于帮助平台了解您的创业项目和团队，以便更好地为您提供帮助。我们承诺不会将商业计划书提供给第三方。</font>
                    </p>
                </label>
                <input type="text" name="txt" id="txtValue" hidden="hidden" value=" " />
            </div>
            <div id="submit-btn" class="pop-space-btn" style="width: 300px;">提交</div>
        </form>
    </div>

    <div class="pop-layer" id="visitlayer"></div>

    <div class="pop-space" id="visitspace" style="margin-top: -300px; width: 560px; margin-left: -280px;">
        <div class="file-upload-loading">
            <div class="spinner">
                <div class="bounce1"></div>
                <div class="bounce2"></div>
                <div class="bounce3"></div>
            </div>
        </div>
        <div class="pop-close pop-space-close" id="visitspaceclose">
            <%--<i class="iconfont icon-cuo"></i>--%>
            <img src="../skin_v2/image/close.png" style="width: 26px; height: 26px;" />
        </div>
        <h3>参观日期</h3>
        <form id="form-add-visit" name="">
            <div class="pop-space-co" style="width: 500px;">
                <label><span>姓名<b>＊</b></span><input type="text" name="truename" value="" maxlength="20" style="width: 300px;"></label>
                <label><span>手机<b>＊</b></span><input type="text" name="mobile" value="" maxlength="20" style="width: 300px;"></label>
                <label><span>邮箱<b>＊</b></span><input type="text" name="email" value="" maxlength="50" style="width: 300px;"></label>
                <label class="label-s"><span>业务简介<b>＊</b></span><textarea name="content" class="pop-space-txt" maxlength="250" style="width: 300px;"></textarea></label>
                <label><span>人数<b>＊</b></span><input type="text" name="count" value="" maxlength="10" style="width: 300px;"></label>
                <label>
                    <span>参观日期<b>＊</b></span><input type="text" name="thedate" value="" class="pop-space-time" id="date-two" style="width: 300px;">
                    <div class="ps-time-btn"></div>
                </label>
                <input type="text" name="txt" id="Text2" hidden="hidden" value=" " />
            </div>
            <div id="visitbtn" class="pop-space-btn" style="width: 300px;">提交</div>
        </form>
    </div>



    <script src="../CSS/EJs/arttemplate.js"></script>
    <script src="../CSS/EJs/function.js"></script>
    <script src="../CSS/EJs/niuge.confirm.js"></script>
    <script src="../CSS/EJs/niuge.vform.js"></script>
    <script src="../CSS/EJs/foundation-datepicker.js"></script>
    <script src="../CSS/EJs/foundation-datepicker.zh-CN.js"></script>

    <!--file upload-->
    <script src="../CSS/EJs/jquery.ui.widget.js"></script>
    <script src="../CSS/EJs/jquery.iframe-transport.js"></script>
    <script src="../CSS/EJs/jquery.fileupload.js"></script>

    <script>

        var id = $("#txtId").val();
        var userid = '0';
        //查询项目
        var getProject = function () {
            $.post('?c=user&m=get_project', { userid: userid }, function (json) {
                var str = '';
                $.each(json, function (i, v) {
                    str += '<span data-value="' + v.id + '">' + v.projectname + '</span>';
                });
                $('#project-select').html(str);
                //事件回调
                $('.pt-select-txt').click(function () {
                    $('.pt-select-co').fadeIn('fast');
                });
                //事件回调
                $('.pt-select-co span').click(function () {
                    $('.pt-select-co').fadeOut('fast');
                    $('.pt-select-txt span').text($(this).text());
                    $('#form-add-appoinment input[name="projectid"]').val($(this).attr('data-value'));
                });
            }, 'json');
        }

        //预加载
        $(function () {
            'use strict';
            // 上传开始
            var url = "../../WebService/SubmitAjaxHandler.ashx?action=RepplySubmit&Id=" + $("#txtId").val();
            $('#fileupload').fileupload({
                url: url,
                dataType: 'json',
                done: function (e, data) {
                    if (data.result.status == 0) {
                        $.MsgBox.Alert(data.result.msg);
                    } else if (data.result.status == 1) {
                        $('#form-add-appoinment input[name="file"]').val(data.result.filename);
                        //$('#txtValue').val();
                        $('#txtValue').val(data.result.filepath);
                    }
                    $('.file-upload-loading').hide();
                },
                progressall: function (e, data) {
                    $('.file-upload-loading').show();
                    /*
                    var progress = parseInt(data.loaded / data.total * 100, 10);
                    $('#progress .progress-bar').css(
                        'width',
                        progress + '%'
                    );
                    */
                }
            }).prop('disabled', !$.support.fileInput)
                .parent().addClass($.support.fileInput ? undefined : 'disabled');
            //上传结束

            if (userid > 0) {
                getProject();
            }

            var nowTemp = new Date();
            var now = new Date(nowTemp.getFullYear(), nowTemp.getMonth(), nowTemp.getDate(), 0, 0, 0, 0);
            var checkin2 = $('#date-one').fdatepicker({
                format: 'yyyy-mm-dd',
                onRender: function (date) {
                    //return date.valueOf() < now.valueOf() ? 'disabled' : '';
                }
            }).on('changeDate', function (ev) {
                checkin2.hide();
            }).data('datepicker');

            var checkin3 = $('#date-two').fdatepicker({
                format: 'yyyy-mm-dd',
                onRender: function (date) {
                    //return date.valueOf() < now.valueOf() ? 'disabled' : '';
                }
            }).on('changeDate', function (ev) {
                checkin3.hide();
            }).data('datepicker');

            // 入孵申请  space
            $('#Apply').click(function (event) {

                $.post('../../WebService/IsLoginAjax.aspx', function (e, data) {
                    var returnMsg = eval("(" + e + ")");
                    if (returnMsg.returnValue == "1") {
                        userid = returnMsg.UserId;
                        //pop - login
                        $('#applylayer').fadeIn('fast');
                        $('#applyspace').fadeIn('fast');
                    } else {
                        $('.pop-login').css("display", "block");
                    }
                });
            });
            // close space
            $('#applyspaceclose').click(function (event) {
                $('#applylayer').fadeOut('fast');
                $('.pop-space').fadeOut('fast');
            });

            // 参观预约  space
            $('#Visit').click(function (event) {
                $.post('../../WebService/IsLoginAjax.aspx', function (e, data) {
                    var returnMsg = eval("(" + e + ")");
                    if (returnMsg.returnValue == "1") {
                        userid = returnMsg.UserId;
                        //pop - login
                        $('#visitlayer').fadeIn('fast');
                        $('#visitspace').fadeIn('fast');
                    } else {
                        $('.pop-login').css("display", "block");
                    }
                });

            });
            // close space
            $('#visitspaceclose').click(function (event) {
                $('#visitlayer').fadeOut('fast');
                $('#visitspace').fadeOut('fast');
            });
            //参观预约内容清空
            function Clear() {
                $('#form-add-visit input[name="truename"]').val("");
                $('#form-add-visit input[name="mobile"]').val("");
                $('#form-add-visit input[name="email"]').val("");
                $('#form-add-visit textarea[name="content"]').val("");
                $('#form-add-visit input[name="thedate"]').val("");
                $('#form-add-visit input[name="count"]').val("");
                $('#form-add-visit input[name="projectid"]').val("");
            }
            //入孵申请内容清空
            function ClearF() {
                $('#form-add-appoinment input[name="truename"]').val("");
                $('#form-add-appoinment input[name="mobile"]').val("");
                $('#form-add-appoinment input[name="email"]').val("");
                $('#form-add-appoinment textarea[name="content"]').val("");
                $('#form-add-appoinment input[name="thedate"]').val("");
                $('#form-add-appoinment input[name="count"]').val("");
                $('#form-add-appoinment input[name="projectid"]').val("");
                $('#txtValue').val("");
                $('#fileupload').val("");
                $('#filehref').val("");
            }

            //参观预约
            $('#visitbtn').click(function () {
                var truename = $('#form-add-visit input[name="truename"]').val();
                var mobile = $('#form-add-visit input[name="mobile"]').val();
                var email = $('#form-add-visit input[name="email"]').val();
                var content = $('#form-add-visit textarea[name="content"]').val();
                var thedate = $('#form-add-visit input[name="thedate"]').val();
                var count = $('#form-add-visit input[name="count"]').val();
                var projectid = $('#form-add-visit input[name="projectid"]').val();
                //var filepath = $('#txtValue').val();
                if (truename == "") { $.MsgBox.Alert('姓名不能为空'); return false; }
                if (!isUsername(truename)) { $.MsgBox.Alert('姓名格式错误'); return false; }
                if (mobile == '') { $.MsgBox.Alert('手机不能为空'); return false; }
                if (!isMobile(mobile)) { $.MsgBox.Alert('手机格式错误'); return false; }
                if (!isEmail(email)) { $.MsgBox.Alert('邮箱格式错误'); return false; }
                if (content.trim() == '') { $.MsgBox.Alert('业务描述不能为空'); return false; }
                if (count == "") { $.MsgBox.Alert('人数不能为空'); return false; }
                if (!isInt(count)) { $.MsgBox.Alert('人数格式错误'); return false; }
                if (thedate == '') { $.MsgBox.Alert('期望预约日期不能为空'); return false; }
                //if (filepath == '') { $.MsgBox.Alert('商业计划书不能为空'); return false; }
                $.post('../../WebService/SubmitAjaxHandler.ashx?action=VisitBookingSubmit', { EId: id, Creator: userid, Name: truename, Phone: mobile, Email: email, Remark: content, VisitDate: thedate, VisitNum: count }, function (msg) {
                    if (msg.indexOf('成功') > 0) {
                        $.MsgBox.Alert('您的预约申请已提交，辅导员将在3工作日内联系您。请耐心等待！');
                        setTimeout(function () { $('#visitspaceclose').trigger('click'); }, 2000);
                        Clear();
                    } else {
                        $.MsgBox.Alert(msg);
                    }
                });

            });

            //入孵申请
            $('#submit-btn').click(function () {
                var truename = $('#form-add-appoinment input[name="truename"]').val();
                var mobile = $('#form-add-appoinment input[name="mobile"]').val();
                var email = $('#form-add-appoinment input[name="email"]').val();
                var content = $('#form-add-appoinment textarea[name="content"]').val();
                var thedate = $('#form-add-appoinment input[name="thedate"]').val();
                var count = $('#form-add-appoinment input[name="count"]').val();
                var projectid = $('#form-add-appoinment input[name="projectid"]').val();
                var filepath = $('#txtValue').val();
                if (truename == "") { $.MsgBox.Alert('姓名不能为空'); return false; }
                if (!isUsername(truename)) { $.MsgBox.Alert('姓名格式不正确'); return false; }
                if (mobile == '') { $.MsgBox.Alert('手机不能为空'); return false; }
                if (!isMobile(mobile)) { $.MsgBox.Alert('手机格式错误'); return false; }
                if (!isEmail(email)) { $.MsgBox.Alert('邮箱格式错误'); return false; }
                if (content.trim() == '') { $.MsgBox.Alert('业务描述不能为空'); return false; }
                if (count == "") { $.MsgBox.Alert('人数不能为空'); return false; }
                if (!isInt(count)) { $.MsgBox.Alert('人数格式错误'); return false; }
                if (thedate == '') { $.MsgBox.Alert('期望预约日期不能为空'); return false; }
                if (filepath.trim() == '') { $.MsgBox.Alert('商业计划书不能为空'); return false; }
                $.post('../../WebService/SubmitAjaxHandler.ashx?action=RepplySubmits', { OrId: id, Creator: userid, Name: truename, Phone: mobile, Email: email, Remark: content, VisitDate: thedate, VisitNum: count, filepath: filepath }, function (msg) {
                    if (msg.indexOf('成功') > 0) {
                        $.MsgBox.Alert('您的预约申请已提交，辅导员将在3工作日内联系您。请耐心等待！');
                        setTimeout(function () { $('#applyspaceclose').trigger('click'); }, 2000);
                        ClearF();
                    } else {
                        $.MsgBox.Alert(msg);
                    }
                });

            });
        })

    </script>

    <script type="text/javascript">

        function JoinPromotion() {
            $.ajax({
                url: "../../WebService/Report.ashx?state=3",
                type: "post",
                data: {
                    url: window.location.href,
                    title: '<%=title%>'
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

        Mediabox.scanPage = function () {
            var links = $$("a").filter(function (el) {
                return el.rel && el.rel.test(/^lightbox/i);
            });
            $$(links).mediabox({/* Put custom options here */ }, null, function (el) {
                var rel0 = this.rel.replace(/[[]|]/gi, " ");
                var relsize = rel0.split(" ");
                return (this == el) || ((this.rel.length > 8) && el.rel.match(relsize[1]));
            });
        };
        window.addEvent("domready", Mediabox.scanPage);
    </script>
    <div class="datepicker datepicker-dropdown dropdown-menu">
        <div class="datepicker-minutes" style="display: none;">
            <table class=" table-condensed">
                <thead>
                    <tr>
                        <th class="prev" style="visibility: visible;">
                            <i class="fa fa-chevron-left fi-arrow-left"></i>
                        </th>
                        <th colspan="5" class="date-switch">28 三月 2017</th>
                        <th class="next" style="visibility: visible;">
                            <i class="fa fa-chevron-right fi-arrow-right"></i>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td colspan="7">
                            <span class="minute active">0:00</span>
                            <span class="minute">0:05</span>
                            <span class="minute">0:10</span>
                            <span class="minute">0:15</span>
                            <span class="minute">0:20</span>
                            <span class="minute">0:25</span>
                            <span class="minute">0:30</span>
                            <span class="minute">0:35</span>
                            <span class="minute">0:40</span>
                            <span class="minute">0:45</span>
                            <span class="minute">0:50</span>
                            <span class="minute">0:55</span>
                        </td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <th colspan="7" class="today" style="display: none;">今天</th>
                    </tr>
                </tfoot>
            </table>
        </div>
        <div class="datepicker-hours" style="display: none;">
            <table class=" table-condensed">
                <thead>
                    <tr>
                        <th class="prev" style="visibility: visible;">
                            <i class="fa fa-chevron-left fi-arrow-left"></i>
                        </th>
                        <th colspan="5" class="date-switch">28 三月 2017</th>
                        <th class="next" style="visibility: visible;">
                            <i class="fa fa-chevron-right fi-arrow-right"></i>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td colspan="7">
                            <span class="hour active">0:00</span>
                            <span class="hour">1:00</span>
                            <span class="hour">2:00</span>
                            <span class="hour">3:00</span>
                            <span class="hour">4:00</span>
                            <span class="hour">5:00</span>
                            <span class="hour">6:00</span>
                            <span class="hour">7:00</span>
                            <span class="hour">8:00</span>
                            <span class="hour">9:00</span>
                            <span class="hour">10:00</span>
                            <span class="hour">11:00</span>
                            <span class="hour">12:00</span>
                            <span class="hour">13:00</span>
                            <span class="hour">14:00</span>
                            <span class="hour">15:00</span>
                            <span class="hour">16:00</span>
                            <span class="hour">17:00</span>
                            <span class="hour">18:00</span>
                            <span class="hour">19:00</span>
                            <span class="hour">20:00</span>
                            <span class="hour">21:00</span>
                            <span class="hour">22:00</span>
                            <span class="hour">23:00</span>
                        </td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <th colspan="7" class="today" style="display: none;">今天</th>
                    </tr>
                </tfoot>
            </table>
        </div>
        <div class="datepicker-days" style="display: block;">
            <table class=" table-condensed">
                <thead>
                    <tr>
                        <th class="prev" style="visibility: visible;">
                            <i class="fa fa-chevron-left fi-arrow-left"></i>

                        </th>
                        <th colspan="5" class="date-switch">三月 2017</th>
                        <th class="next" style="visibility: visible;">
                            <i class="fa fa-chevron-right fi-arrow-right"></i>
                        </th>
                    </tr>
                    <tr>
                        <th class="dow">日</th>
                        <th class="dow">一</th>
                        <th class="dow">二</th>
                        <th class="dow">三</th>
                        <th class="dow">四</th>
                        <th class="dow">五</th>
                        <th class="dow">六</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td class="day undefined  old">26</td>
                        <td class="day undefined  old">27</td>
                        <td class="day undefined  old">28</td>
                        <td class="day undefined ">1</td>
                        <td class="day undefined ">2</td>
                        <td class="day undefined ">3</td>
                        <td class="day undefined ">4</td>
                    </tr>
                    <tr>
                        <td class="day undefined ">5</td>
                        <td class="day undefined ">6</td>
                        <td class="day undefined ">7</td>
                        <td class="day undefined ">8</td>
                        <td class="day undefined ">9</td>
                        <td class="day undefined ">10</td>
                        <td class="day undefined ">11</td>
                    </tr>
                    <tr>
                        <td class="day undefined ">12</td>
                        <td class="day undefined ">13</td>
                        <td class="day undefined ">14</td>
                        <td class="day undefined ">15</td>
                        <td class="day undefined ">16</td>
                        <td class="day undefined ">17</td>
                        <td class="day undefined ">18</td>
                    </tr>
                    <tr>
                        <td class="day undefined ">19</td>
                        <td class="day undefined ">20</td>
                        <td class="day undefined ">21</td>
                        <td class="day undefined ">22</td>
                        <td class="day undefined ">23</td>
                        <td class="day undefined ">24</td>
                        <td class="day undefined ">25</td>
                    </tr>
                    <tr>
                        <td class="day undefined ">26</td>
                        <td class="day undefined ">27</td>
                        <td class="day undefined  active">28</td>
                        <td class="day undefined ">29</td>
                        <td class="day undefined ">30</td>
                        <td class="day undefined ">31</td>
                        <td class="day undefined  new">1</td>
                    </tr>
                    <tr>
                        <td class="day undefined  new">2</td>
                        <td class="day undefined  new">3</td>
                        <td class="day undefined  new">4</td>
                        <td class="day undefined  new">5</td>
                        <td class="day undefined  new">6</td>
                        <td class="day undefined  new">7</td>
                        <td class="day undefined  new">8</td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <th colspan="7" class="today" style="display: none;">今天</th>
                    </tr>
                </tfoot>
            </table>
        </div>
        <div class="datepicker-months" style="display: none;">
            <table class="table-condensed">
                <thead>
                    <tr>
                        <th class="prev" style="visibility: visible;">
                            <i class="fa fa-chevron-left fi-arrow-left"></i>
                        </th>
                        <th colspan="5" class="date-switch">2017</th>
                        <th class="next" style="visibility: visible;">
                            <i class="fa fa-chevron-right fi-arrow-right"></i>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td colspan="7">
                            <span class="month">一</span>
                            <span class="month">二</span>
                            <span class="month active">三</span>
                            <span class="month">四</span>
                            <span class="month">五</span>
                            <span class="month">六</span>
                            <span class="month">七</span>
                            <span class="month">八</span>
                            <span class="month">九</span>
                            <span class="month">十</span>
                            <span class="month">十一</span>
                            <span class="month">十二</span>
                        </td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <th colspan="7" class="today" style="display: none;">今天</th>
                    </tr>
                </tfoot>
            </table>
        </div>
        <div class="datepicker-years" style="display: none;">
            <table class="table-condensed">
                <thead>
                    <tr>
                        <th class="prev" style="visibility: visible;">
                            <i class="fa fa-chevron-left fi-arrow-left"></i>
                        </th>
                        <th colspan="5" class="date-switch">2010-2019</th>
                        <th class="next" style="visibility: visible;">
                            <i class="fa fa-chevron-right fi-arrow-right"></i>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td colspan="7">
                            <span class="year old">2009</span>
                            <span class="year">2010</span>
                            <span class="year">2011</span>
                            <span class="year">2012</span>
                            <span class="year">2013</span>
                            <span class="year">2014</span>
                            <span class="year">2015</span>
                            <span class="year">2016</span>
                            <span class="year active">2017</span>
                            <span class="year">2018</span>
                            <span class="year">2019</span>
                            <span class="year old">2020</span>
                        </td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <th colspan="7" class="today" style="display: none;">今天</th>
                    </tr>
                </tfoot>
            </table>
        </div>
        <a class="button datepicker-close tiny alert right" style="width: auto; display: none;">
            <i class="fa fa-remove fa-times fi-x"></i>
        </a>
    </div>
    <div>
    </div>
    <!-- pop -->
    <div class="pop-layer"></div>
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


        function show(obj) {

            var array = new Array('pptx', 'ppt', 'docx', 'doc', 'pdf '); //可以上传的文件类型 
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

                        }
                    }
                    if (isExists == false) {
                        $('#fileupload').val("");
                        $('#filehref').val("");
                        $.MsgBox.Alert('类型不正确'); return false;

                    }
                }
                catch (e) {

                }

                if (isExists == false) {
                    $('#fileupload').val("");
                    $('#filehref').val("");
                    $.MsgBox.Alert('类型不正确'); return false;
                }


            }
        }
    </script>
</body>
</html>
