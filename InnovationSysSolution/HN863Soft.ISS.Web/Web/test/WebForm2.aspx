<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="HN863Soft.ISS.Web.Web.test.WebForm2" %>
<%@ Import Namespace="HN863Soft.ISS.Common" %>
<!DOCTYPE html>

<html class="js" style="font-size: 40px;"><head><meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
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
		<link rel="shortcut icon" href="http://www.efuhua.cn/fav.ico" type="image/x-icon">
		<title>浦软孵化平台</title>
		<!--bootstrapcss-->
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=76bf80490799c76e393b84cb8da4c856"></script>
<link rel="stylesheet" type="text/css" href="bootstrap.min.css">
<%--<link rel="stylesheet" type="text/css" href="responsive.min.css">--%>
<link rel="stylesheet" type="text/css" href="font-awesome.min.css">
	
<link rel="stylesheet" type="text/css" href="global.css">
<link rel="stylesheet" type="text/css" href="base.css">
<link rel="stylesheet" type="text/css" href="page.css">		<link rel="stylesheet" type="text/css" href="foundation-datepicker.css">
		<link rel="stylesheet" type="text/css" href="space.css">
		<!--bootstrapjs-->
<script type="text/javascript" src="jquery.js"></script>
<script type="text/javascript" src="bootstrap.min.js"></script>
<%--<script type="text/javascript" src="responsive.min.js"></script>--%>
<%--<script type="text/javascript" src="base.js"></script>--%>
<script type="text/javascript" src="global.js"></script>
     <link href="../CSS/Heard/css.css" rel="stylesheet" />

    <style type="text/css">
*{padding:0; margin:0}
#mbOverlay { position:fixed; z-index:9998; top:0; left:0; width:100%; height:100%; background-color:#000; cursor:pointer; }
#mbOverlay.mbOverlayFF { background:transparent url(80.png) repeat; }
#mbOverlay.mbOverlayIE { position:absolute; }
#mbCenter { width:690px; height:557px; position:absolute; z-index:9999; left:50%; background-color:#fff; -moz-border-radius:10px; -webkit-border-radius:10px; -moz-box-shadow:0 10px 40px rgba(0, 0, 0, 0.70); -webkit-box-shadow:0 10px 40px rgba(0, 0, 0, 0.70); }
#mbCenter.mbLoading { background:#fff url(WhiteLoading.gif) no-repeat center; -moz-box-shadow:none; -webkit-box-shadow:none; }
#mbImage {  left:0; top:0; font-family:Myriad, Verdana, Arial, Helvetica, sans-serif; line-height:20px; font-size:12px; color:#fff; text-align:left; background-position:center center; background-repeat:no-repeat; padding:10px; }
#mbImage a, #mbImage a:link, #mbImage a:visited { color:#ddd; }
#mbImage a:hover, #mbImage a:active { color:#fff; }
#mbBottom { min-height:20px; font-family:Myriad, Verdana, Arial, Helvetica, sans-serif; line-height:20px; font-size:12px; color:#999; text-align:left; padding:0 10px 10px; }
#mbTitle { display:inline; color:#999; font-weight:bold; line-height:20px; font-size:12px; }
#mbNumber { background:url(mbNumber_bg.gif) no-repeat center; display:inline; color:#C00; line-height:26px; font-size:12px; position: absolute; bottom: 10px; right: 10px; text-align: center; width:65px; height:26px; }
#mbCaption { display:block; color:#999; line-height:14px; font-size:10px; }
#mbPrevLink, #mbNextLink, #mbCloseLink { display:block; float:right; height:20px; margin:0; outline:none; }
#mbPrevLink { width:32px; height:100px; background:transparent url(CustomBlackPrevious.gif) no-repeat center; position: absolute; top:38%; left:-32px; }
#mbNextLink { width:32px; height:100px; background:transparent url(CustomBlackNext.gif) no-repeat center; position: absolute; top:38%; right:-32px; }
#mbCloseLink { width:24px; background:transparent url(CustomBlackClose.gif) no-repeat center; position:absolute; top:10px; right:10px; }
#mbError { position:relative; font-family:Myriad, Verdana, Arial, Helvetica, sans-serif; line-height:20px; font-size:12px; color:#fff; text-align:center; border:10px solid #700; padding:10px 10px 10px; margin:20px; -moz-border-radius:5px; -webkit-border-radius:5px; }
#mbError a, #mbError a:link, #mbError a:visited, #mbError a:hover, #mbError a:active { color:#d00; font-weight:bold; text-decoration:underline; }
.layout_default{float:left; margin:5px}
.mod_gallerylist{width:665px; margin:0 auto}
.meta{font-size:12px; text-align:center;}
.image_container img{border:1px solid #CCC; padding:2px}
.meta a{color:#333; text-decoration:none}
</style>

<script src="mootools-core.js"></script>
<script src="mediabox.js"></script>
<script>
    var rolearr = [];
    rolearr[0] = '普通会员';
    rolearr[1] = '认证创业者';
    rolearr[2] = '创业导师';
    rolearr[3] = '服务机构';
    rolearr[4] = '辅导员';

    $(function () {
        $('#drop3').dropdown('toggle')
    })

</script>		<!--baidumap-->
		<script type="text/javascript" src="api"></script>
    <script type="text/javascript" src="getscript"></script>
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

	<body>

		<!--[if lte IE 7]>
		<style type="text/css">
		    * {
		        display: none;
		    }
		</style>
		<script>
		    alert("对不起，您的浏览器版本太低，建议使用IE8以上版本或chrome、firefox浏览器！");
		</script>
		<![endif]-->

		<div class="header" id="header">
            
            <ul class="menu">
                <li><a href="#">主页</a></li>
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
                <li><a href="#">孵化器</a></li>
                <li><a href="../MeetingActivity/MeetingActiveList.aspx">难题吐槽 </a></li>
                <li><a href="#">登录</a></li>
                <li><a href="#">注册</a></li>
            </ul>

<!--div id="user-nav">
   <a href="http://www.efuhua.cn/?c=user">个人中心</a>
   <a href="http://www.efuhua.cn/?c=user&m=logout" style="border-bottom:0;">退出</a>
</div-->		</div>
		<div class="row" style="margin-top:70px;">
			<div class="col-md-12 banner">


                <div id="carousel-example-generic" class="carousel slide" data-ride="carousel" data-interval="2000">
	        	
	          <!-- Indicators -->
	          <ol class="carousel-indicators">
	            <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
	            <li data-target="#carousel-example-generic" data-slide-to="1" class=""></li>
	            <li data-target="#carousel-example-generic" data-slide-to="2" class=""></li>
	            <li data-target="#carousel-example-generic" data-slide-to="3" class=""></li>
	          </ol> 
	          
	          <!-- Wrapper for slides -->
	          <div class="carousel-inner" role="listbox">
	          	
	            <div class="item active">
	            	<div class="carousel-bg"></div>
	              <img class="item-img" src="kv1.jpg" alt="" style="width:100%;">
	              <div class="carousel-caption">
	               
	        				<p style="text-align:left;"></p>
	              </div>
	            </div>
	            <div class="item">
	              <div class="carousel-bg"></div>
	              <img class="item-img" src="kv2.jpg" alt="" style="width:100%">
	              <div class="carousel-caption">
	              	
	        				<p style="text-align:left;"></p>
	              </div>
	            </div>
	            <div class="item">
	              <div class="carousel-bg"></div>
	              <img class="item-img" src="kv3.jpg" alt="" style="width:100%">
	              <div class="carousel-caption">
	              	
	        				<p style="text-align:left;"></p>
	              </div>
	            </div>
	            <div class="item">
	              <div class="carousel-bg"></div>
	              <img class="item-img" src="kv4.jpg" alt="" style="width:100%">
	              <div class="carousel-caption">
	              	
	        				<p style="text-align:left;"></p>
	              </div>
	            </div>
	           
	          </div>
	        
	          <!-- Controls -->
	          <a class="left carousel-control" href="http://www.efuhua.cn/index.php?c=space#carousel-example-generic" role="button" data-slide="prev">
	            <span class="fa fa-mc fa-angle-left" aria-hidden="true"></span>
	            <span class="sr-only">Previous</span>
	          </a>
	          <a class="right carousel-control" href="http://www.efuhua.cn/index.php?c=space#carousel-example-generic" role="button" data-slide="next">
	            <span class="fa fa-mc fa-angle-right" aria-hidden="true"></span>
	            <span class="sr-only">Next</span>
	          </a>
	        </div>
				<div class="banner-txt-co">
					<div class="banner-txt-co-title">
						<span><img src="icon_line_topleft.png"></span>
						<span>爱酷空间</span>
						<span><img src="icon_line_downright.png"></span>
                     
					</div>
               <br /><br />
					<a href="javascript:" class="online-yu2"><i class="iconfont icon-qianbi"></i>&nbsp;&nbsp;我要预约</a>
                    <a href="javascript:" class="online-yu2"><i class="iconfont icon-qianbi"></i>&nbsp;&nbsp;我要入孵</a>
				</div>
			</div>
			
		</div>
		<div class="row niui-content-1">
			<div class="niui-w show360">
				 <h2>
				 	<span style="width:160px;margin-left:-80px;">孵化器展示</span>
				 </h2>
				<div class="show360-list" id="box">
					<ul>
											<li>
							<a href="kv1.jpg"  rel="lightbox[ostec]" >
								<img src="kv1.jpg" class="pic"></a>
								
							
							
						</li>
											<li>
						<a href="1460302584541151.jpg" rel="lightbox[ostec]" >
								<img src="1460302584541151.jpg" class="pic">
								</a>
							
							
						</li>
											<li>
							<a href="1460302561433899.jpg" rel="lightbox[ostec]" >
								<img src="1460302561433899.jpg" class="pic">
								</a>
							
							
						</li>
											<li>
							<a href="1460302531807418.jpg" rel="lightbox[ostec]" >
								<img src="1460302531807418.jpg" class="pic">
							</a>
						
							
						</li>
										</ul>
				</div>

<%--                <div id="bg"></div>

<div id="bottom">
	<ul>
    	<li class="prev"></li>
        <li class="img"></li>
        <li class="next"></li>
        <li class="close"></li>
    </ul>
</div>--%>

<div id="frame"></div>
				
				<h2>
					<span style="width:160px;margin-left:-80px;">孵化器说明</span>
				</h2>

				<div class="bz-box">
					<div class="col-md-4 col-md-offset-5" style="margin-left:39.5%;">
						<h3><i class="iconfont icon-teseb"></i> 空间特色</h3>
						<div>
							<p style="white-space: normal;">1、位于张江核心区域，紧邻地铁2号线金科路站&nbsp;</p><p style="white-space: normal;">2、5000平米的办公空间&nbsp;</p><p style="white-space: normal;">3、可为创业团队提供多至10人的6个月免费办公&nbsp;</p><p style="white-space: normal;">4、会议室，报告厅，咖啡馆，茶歇室，打印机房</p>						</div>
					</div>
				</div>
				<div class="bz-box">
					<div class="col-md-4 col-md-offset-5" style="margin-left:39.5%;">
						<h3><i class="iconfont icon-dailiqukuanshenhe"></i> 入驻标准</h3>
						<div>
							<p>1、TMT领域的创新性项目</p><p>2、尚未成立公司，或成立公司不超过一年</p><p>3、创业团队优秀，人数不超过10人</p><p>4、项目技术先进，市场发展潜力大</p><p><br></p>						</div>
					</div>
				</div>
				
			</div>
		</div>
 
		<div class="row">
            <div class="niui-w show360">
                 <h2>
				 	<span style="width:160px;margin-left:-80px;">孵化器地址</span>
				 </h2>
                </div>

			<div class="col-md-12 map" style="height:280px;">
				<div style="width: 100%; height: 280px; overflow: hidden; position: relative; z-index: 0; color: rgb(0, 0, 0); text-align: left; background-color: rgb(243, 241, 236);" id="dituContent"><div style="overflow: visible; position: absolute; z-index: 0; left: 0px; top: 0px; cursor: url(&quot;http://api0.map.bdimg.com/images/openhand.cur&quot;) 8 8, default;"><div class="BMap_mask" style="position: absolute; left: 0px; top: 0px; z-index: 9; overflow: hidden; -webkit-user-select: none; width: 1349px; height: 280px;"></div><div style="position: absolute; height: 0px; width: 0px; left: 0px; top: 0px; z-index: 200;"><div style="position: absolute; height: 0px; width: 0px; left: 0px; top: 0px; z-index: 800;"></div><div style="position: absolute; height: 0px; width: 0px; left: 0px; top: 0px; z-index: 700;"><span class="BMap_Marker BMap_noprint" unselectable="on" "="" style="position: absolute; padding: 0px; margin: 0px; border: 0px; cursor: pointer; width: 19px; height: 25px; left: 665px; top: 115px; z-index: -6241770; background: url(&quot;http://api0.map.bdimg.com/images/blank.gif&quot;);" title=""></span></div><div style="position: absolute; height: 0px; width: 0px; left: 0px; top: 0px; z-index: 600;"></div><div style="position: absolute; height: 0px; width: 0px; left: 0px; top: 0px; z-index: 500;"><label class="BMapLabel" unselectable="on" style="position: absolute; display: none; cursor: inherit; border: 1px solid rgb(190, 190, 190); padding: 1px; white-space: nowrap; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 12px; line-height: normal; font-family: arial, sans-serif; z-index: -20000; color: rgb(190, 190, 190); background-color: rgb(190, 190, 190);">shadow</label></div><div style="position: absolute; height: 0px; width: 0px; left: 0px; top: 0px; z-index: 400;"><span class="BMap_Marker" unselectable="on" style="position: absolute; padding: 0px; margin: 0px; border: 0px; width: 0px; height: 0px; left: 665px; top: 115px; z-index: -6241770;"><div style="position: absolute; margin: 0px; padding: 0px; width: 19px; height: 25px; overflow: hidden; left: 0px; top: -10px;"><img src="marker_red_sprite.png" style="display: block; border:none;margin-left:0px; margin-top:0px; "></div></span></div><div style="position: absolute; height: 0px; width: 0px; left: 0px; top: 0px; z-index: 300;"><span unselectable="on" style="position: absolute; padding: 0px; margin: 0px; border: 0px; width: 20px; height: 11px; left: 669px; top: 129px;"><div style="position: absolute; margin: 0px; padding: 0px; width: 20px; height: 11px; overflow: hidden; left: 8px; top: -8px;"><img src="marker_red_sprite.png" style="display: block; border:none;margin-left:-19px; margin-top:-13px; "></div></span></div><div style="position: absolute; height: 0px; width: 0px; left: 0px; top: 0px; z-index: 201;"></div><div style="position: absolute; height: 0px; width: 0px; left: 0px; top: 0px; z-index: 200;"></div></div><div style="position: absolute; overflow: visible; top: 0px; left: 0px; z-index: 1;"><div style="position: absolute; overflow: visible; z-index: -100; left: 674px; top: 140px; display: block; transform: translate3d(0px, 0px, 0px);"><img src="saved_resource" style="position: absolute; border: none; width: 256px; height: 256px; left: -100px; top: -217px; max-width: none; opacity: 1;"><img src="saved_resource(1)" style="position: absolute; border: none; width: 256px; height: 256px; left: -356px; top: -217px; max-width: none; opacity: 1;"><img src="saved_resource(2)" style="position: absolute; border: none; width: 256px; height: 256px; left: 156px; top: -217px; max-width: none; opacity: 1;"><img src="saved_resource(3)" style="position: absolute; border: none; width: 256px; height: 256px; left: -100px; top: 39px; max-width: none; opacity: 1;"><img src="saved_resource(4)" style="position: absolute; border: none; width: 256px; height: 256px; left: 412px; top: -217px; max-width: none; opacity: 1;"><img src="saved_resource(5)" style="position: absolute; border: none; width: 256px; height: 256px; left: -612px; top: -217px; max-width: none; opacity: 1;"><img src="saved_resource(6)" style="position: absolute; border: none; width: 256px; height: 256px; left: -356px; top: 39px; max-width: none; opacity: 1;"><img src="saved_resource(7)" style="position: absolute; border: none; width: 256px; height: 256px; left: 156px; top: 39px; max-width: none; opacity: 1;"><img src="saved_resource(8)" style="position: absolute; border: none; width: 256px; height: 256px; left: -868px; top: -217px; max-width: none; opacity: 1;"><img src="saved_resource(9)" style="position: absolute; border: none; width: 256px; height: 256px; left: 412px; top: 39px; max-width: none; opacity: 1;"><img src="saved_resource(10)" style="position: absolute; border: none; width: 256px; height: 256px; left: -612px; top: 39px; max-width: none; opacity: 1;"><img src="saved_resource(11)" style="position: absolute; border: none; width: 256px; height: 256px; left: -868px; top: 39px; max-width: none; opacity: 1;"><img src="saved_resource(12)" style="position: absolute; border: none; width: 256px; height: 256px; left: 668px; top: -217px; max-width: none; opacity: 1;"><img src="saved_resource(13)" style="position: absolute; border: none; width: 256px; height: 256px; left: 668px; top: 39px; max-width: none; opacity: 1;"></div></div><div style="position: absolute; overflow: visible; top: 0px; left: 0px; z-index: 2; display: none;"><div style="position: absolute; overflow: visible; top: 0px; left: 0px; z-index: 0; display: none;"></div><div style="position: absolute; overflow: visible; top: 0px; left: 0px; z-index: 10; display: none;"></div></div><div style="position: absolute; overflow: visible; top: 0px; left: 0px; z-index: 3;"></div></div><div class="pano_close" title="退出全景" style="z-index: 1201; display: none;"></div><a class="pano_pc_indoor_exit" title="退出室内景" style="z-index: 1201; display: none;"><span style="float:right;margin-right:12px;">出口</span></a><div class=" anchorBL" style="height: 32px; position: absolute; z-index: 30; bottom: 20px; right: auto; top: auto; left: 1px;"><a title="到百度地图查看此区域" target="_blank" href="http://map.baidu.com/?sr=1" style="outline: none;"><img style="border:none;width:77px;height:32px" src="copyright_logo.png"></a></div><div id="zoomer" style="position:absolute;z-index:0;top:0px;left:0px;overflow:hidden;visibility:hidden;cursor:url(http://api0.map.bdimg.com/images/openhand.cur) 8 8,default"><div class="BMap_zoomer" style="top:0;left:0;"></div><div class="BMap_zoomer" style="top:0;right:0;"></div><div class="BMap_zoomer" style="bottom:0;left:0;"></div><div class="BMap_zoomer" style="bottom:0;right:0;"></div></div><div unselectable="on" class=" BMap_stdMpCtrl BMap_stdMpType0 BMap_noprint anchorTL" style="width: 62px; height: 192px; bottom: auto; right: auto; top: 10px; left: 10px; position: absolute; z-index: 1100;"><div class="BMap_stdMpPan"><div class="BMap_button BMap_panN" title="向上平移"></div><div class="BMap_button BMap_panW" title="向左平移"></div><div class="BMap_button BMap_panE" title="向右平移"></div><div class="BMap_button BMap_panS" title="向下平移"></div><div class="BMap_stdMpPanBg BMap_smcbg"></div></div><div class="BMap_stdMpZoom" style="height: 147px; width: 62px;"><div class="BMap_button BMap_stdMpZoomIn" title="放大一级"><div class="BMap_smcbg"></div></div><div class="BMap_button BMap_stdMpZoomOut" title="缩小一级" style="top: 126px;"><div class="BMap_smcbg"></div></div><div class="BMap_stdMpSlider" style="height: 108px;"><div class="BMap_stdMpSliderBgTop" style="height: 108px;"><div class="BMap_smcbg"></div></div><div class="BMap_stdMpSliderBgBot" style="top: 25px; height: 87px;"></div><div class="BMap_stdMpSliderMask" title="放置到此级别"></div><div class="BMap_stdMpSliderBar" title="拖动缩放" style="cursor: url(&quot;http://api0.map.bdimg.com/images/openhand.cur&quot;) 8 8, default; top: 25px;"><div class="BMap_smcbg"></div></div></div><div class="BMap_zlHolder"><div class="BMap_zlSt"><div class="BMap_smcbg"></div></div><div class="BMap_zlCity"><div class="BMap_smcbg"></div></div><div class="BMap_zlProv"><div class="BMap_smcbg"></div></div><div class="BMap_zlCountry"><div class="BMap_smcbg"></div></div></div></div><div class="BMap_stdMpGeolocation" style="position: initial; display: none; margin-top: 43px; margin-left: 10px;"><div class="BMap_geolocationContainer" style="position: initial; width: 24px; height: 24px; overflow: hidden; margin: 0px; box-sizing: border-box;"><div class="BMap_geolocationIconBackground" style="width: 24px; height: 24px; background-image: url(http://api0.map.bdimg.com/images/navigation-control/geolocation-control/pc/bg-20x20.png); background-size: 20px 20px; background-position: 3px 3px; background-repeat: no-repeat;"><div class="BMap_geolocationIcon" style="position: initial; width: 24px; height: 24px; cursor: pointer; background-image: url(&#39;http://api0.map.bdimg.com/images/navigation-control/geolocation-control/pc/success-10x10.png&#39;); background-size: 10px 10px; background-repeat: no-repeat; background-position: center;"></div></div></div></div></div><div unselectable="on" class=" BMap_cpyCtrl BMap_noprint anchorBL" style="cursor: default; white-space: nowrap; color: black; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 11px; line-height: 15px; font-family: arial, sans-serif; bottom: 2px; right: auto; top: auto; left: 2px; position: absolute; z-index: 10; background: none;"><span _cid="1" style="display: inline;"><span style="background: rgba(255, 255, 255, 0.701961);padding: 0px 1px;line-height: 16px;display: inline;height: 16px;">©&nbsp;2017 Baidu - GS(2015)2650号&nbsp;- Data © 长地万方</span></span></div></div>
			</div>
		</div>
		
		<div class="row niui-content-1">
			<div class="niui-w show360" style="padding:0 0 20px 0;">

				
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
		<div class="pop-layer"></div>
		<!-- login -->
		<!-- login -->
<div class="pop-login">
	<div class="pop-close pop-login-close"><i class="iconfont icon-cuo"></i></div>
	<h3>登录</h3>
	<div class="pop-login-co">
  <form class="form-login" action="http://www.efuhua.cn/index.php?c=space&amp;m=detail&amp;id=1" name="form3" method="post">
		<label><span>手机/邮箱</span><input type="text" name="username" value="" placeholder="手机/邮箱"></label>
		<label><span>密码</span><input type="password" name="password" value="" placeholder="密码"></label>
		<div class="login-check">
			<label>
				<i class="fa fa-check-square-o" style="width:16px;font-size:14px;"></i>记住我
			</label>
			<a href="http://www.efuhua.cn/index.php?c=login&amp;m=findpass_step1">忘记密码</a>
		</div>
		<div class="login-btn">登录</div>
		<div class="logup-btn">还没有平台帐号 <a href="http://www.efuhua.cn/index.php?c=register">立即注册</a></div>
  </form>
	</div>
</div>		
		<!-- space -->
		<div class="pop-space" style="margin-top:-300px;width:560px;margin-left:-280px;">
			<div class="file-upload-loading"><div class="spinner"><div class="bounce1"></div><div class="bounce2"></div><div class="bounce3"></div></div></div>
			<div class="pop-close pop-space-close"><i class="iconfont icon-cuo"></i></div>
			<h3>预约爱酷空间</h3>
		  <form id="form-add-appoinment" action="http://www.efuhua.cn/index.php?c=space&amp;m=detail&amp;id=1" name="" method="post">
			<div class="pop-space-co" style="width:500px;">
				<label><span>姓名<b>＊</b></span><input type="text" name="truename" value="" style="width:300px;"></label>
				<label><span>手机<b>＊</b></span><input type="text" name="mobile" value="" style="width:300px;"></label>
				<label><span>邮箱<b>＊</b></span><input type="text" name="email" value="" style="width:300px;"></label>
				<label class="label-s"><span>业务简介<b>＊</b></span><textarea name="content" class="pop-space-txt" style="width:300px;"></textarea></label>
				<label><span>人数<b>＊</b></span><input type="text" name="count" value="" style="width:300px;"></label>
				<label><span>期望入驻日期<b>＊</b></span><input type="text" name="thedate" value="" class="pop-space-time" id="date-one" style="width:300px;">
					<div class="ps-time-btn"><i class="fa fa-calendar"></i></div>
				</label>
								<label>
					<span>商业计划书<b>*</b></span>
					<input type="text" class="certi-input-txt" name="file" value="" placeholder="" style="border-right:0;width:240px" readonly="">						
					<div class="certi-play-btn">
						<input id="fileupload" type="file" name="filename" value="" placeholder="">
						浏览
        
					</div>
		            <p style="width:100%;float:left;margin:10px 0;padding-left:120px;font-size:12px;padding-right:70px;">支持 pptx,ppt/docx,doc/pdf 格式不超过50M的文件。<br><font color="#FF6E00">
特别说明：商业计划书仅用于帮助平台了解您的创业项目和团队，以便更好地为您提供帮助。我们承诺不会将商业计划书提供给第三方。</font></p>
				</label>
							</div>
						<div id="submit-btn" class="pop-space-btn" style="width:300px;">提交</div>
		  </form>
		</div>

		<script src="arttemplate.js"></script> 
		<script src="function.js"></script>
		<script src="niuge.confirm.js"></script>
		<script src="niuge.vform.js"></script>
		<script src="foundation-datepicker.js"></script>
		<script src="foundation-datepicker.zh-CN.js"></script>
		
		<!--file upload-->
		<script src="jquery.ui.widget.js"></script>
		<script src="jquery.iframe-transport.js"></script>
		<script src="jquery.fileupload.js"></script>
		
		<script>

		    var id = '1';
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
		        var url = 'index.php?c=space&m=upload_file';
		        $('#fileupload').fileupload({
		            url: url,
		            dataType: 'json',
		            done: function (e, data) {
		                if (data.result.status == 0) {
		                    $.MsgBox.Alert(data.result.msg);
		                } else if (data.result.status == 1) {
		                    $('#form-add-appoinment input[name="file"]').val(data.result.filename);
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

		        // 预约  space
		        $('.online-yu,.online-yu2').click(function (event) {
		            $('.pop-layer').fadeIn('fast');
		            $('.pop-space').fadeIn('fast');
		        });
		        // close space
		        $('.pop-space-close').click(function (event) {
		            $('.pop-layer').fadeOut('fast');
		            $('.pop-space').fadeOut('fast');
		        });


		        //提交预约
		        $('#submit-btn').click(function () {
		            var truename = $('#form-add-appoinment input[name="truename"]').val();
		            var mobile = $('#form-add-appoinment input[name="mobile"]').val();
		            var email = $('#form-add-appoinment input[name="email"]').val();
		            var content = $('#form-add-appoinment textarea[name="content"]').val();
		            var thedate = $('#form-add-appoinment input[name="thedate"]').val();
		            var count = $('#form-add-appoinment input[name="count"]').val();
		            var projectid = $('#form-add-appoinment input[name="projectid"]').val();
		            var filepath = $('#form-add-appoinment input[name="file"]').val();
		            if (truename == '') { $.MsgBox.Alert('姓名不能为空'); return false; }
		            if (mobile == '') { $.MsgBox.Alert('手机不能为空'); return false; }
		            if (!isMobile(mobile)) { $.MsgBox.Alert('手机格式错误'); return false; }
		            if (!isEmail(email)) { $.MsgBox.Alert('邮箱格式错误'); return false; }
		            if (content == '') { $.MsgBox.Alert('业务描述不能为空'); return false; }
		            if (count == '') { $.MsgBox.Alert('人数不能为空'); return false; }
		            if (thedate == '') { $.MsgBox.Alert('期望预约日期不能为空'); return false; }
		            if (filepath == '') { $.MsgBox.Alert('商业计划书不能为空'); return false; }
		            $.post('http://www.efuhua.cn/?c=space&m=add_appoinment', { spaceid: id, userid: userid, truename: truename, mobile: mobile, email: email, content: content, thedate: thedate, count: count, projectid: projectid, filepath: filepath }, function (msg) {
		                if (msg.indexOf('成功') > 0) {
		                    $.MsgBox.Alert('您的预约申请已提交，辅导员将在3工作日内联系您。请耐心等待！');
		                    setTimeout(function () { $('.pop-space-close').trigger('click'); }, 2000);
		                } else {
		                    $.MsgBox.Alert(msg);
		                }
		            });

		        });

		        $('.space-list ul li').mouseover(function () {

		            $(this).find('.space-list-d').hide();

		        });

		        $('.space-list ul li').mouseout(function () {

		            $(this).find('.space-list-d').show();

		        });
		        initMap();//创建和初始化地图
		    })


		    //创建和初始化地图函数：
		    function initMap() {
		        //createMap();//创建地图
		        // setMapEvent();//设置地图事件
		        //addMapControl();//向地图添加控件
		        // 百度地图API功能
		        var map = new BMap.Map("dituContent");
		        var point = new BMap.Point(121.613359, 31.208854);
		        map.centerAndZoom(point, 15);
		        var marker = new BMap.Marker(point);  // 创建标注
		        map.addOverlay(marker);              // 将标注添加到地图中
		        marker.setAnimation(BMAP_ANIMATION_BOUNCE); //跳动的动画
		        map.addControl(new BMap.NavigationControl());  //添加默认缩放平移控件

		    }

		    //创建地图函数：
		    function createMap() {

		        var map = new BMap.Map("dituContent");//在百度地图容器中创建一个地图
		        var point = new BMap.Point(121.613359, 31.208854);//定义一个中心点坐标
		        map.centerAndZoom(point, 14);//设定地图的中心点和坐标并将地图显示在地图容器中
		        var marker = new BMap.Marker(point);  // 创建标注
		        map.addOverlay(marker);              // 将标注添加到地图中
		        window.map = map;//将map变量存储在全局
		    }

		    //地图事件设置函数：
		    function setMapEvent() {
		        map.enableDragging();//启用地图拖拽事件，默认启用(可不写)
		        // map.enableScrollWheelZoom();//启用地图滚轮放大缩小

		        map.enableDoubleClickZoom();//启用鼠标双击放大，默认启用(可不写)
		        map.enableKeyboard();//启用键盘上下左右键移动地图
		    }

		    //地图控件添加函数：
		    function addMapControl() {
		        //向地图中添加缩放控件
		        var ctrl_nav = new BMap.NavigationControl({ anchor: BMAP_ANCHOR_TOP_LEFT, type: BMAP_NAVIGATION_CONTROL_LARGE });
		        map.addControl(ctrl_nav);
		        //向地图中添加比例尺控件
		        var ctrl_sca = new BMap.ScaleControl({ anchor: BMAP_ANCHOR_BOTTOM_LEFT });
		        map.addControl(ctrl_sca);
		    }



		</script>
	
<script type="text/javascript">
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
<div class="datepicker datepicker-dropdown dropdown-menu"><div class="datepicker-minutes" style="display: none;"><table class=" table-condensed"><thead><tr><th class="prev" style="visibility: visible;"><i class="fa fa-chevron-left fi-arrow-left"></i></th><th colspan="5" class="date-switch">28 三月 2017</th><th class="next" style="visibility: visible;"><i class="fa fa-chevron-right fi-arrow-right"></i></th></tr></thead><tbody><tr><td colspan="7"><span class="minute active">0:00</span><span class="minute">0:05</span><span class="minute">0:10</span><span class="minute">0:15</span><span class="minute">0:20</span><span class="minute">0:25</span><span class="minute">0:30</span><span class="minute">0:35</span><span class="minute">0:40</span><span class="minute">0:45</span><span class="minute">0:50</span><span class="minute">0:55</span></td></tr></tbody><tfoot><tr><th colspan="7" class="today" style="display: none;">今天</th></tr></tfoot></table></div><div class="datepicker-hours" style="display: none;"><table class=" table-condensed"><thead><tr><th class="prev" style="visibility: visible;"><i class="fa fa-chevron-left fi-arrow-left"></i></th><th colspan="5" class="date-switch">28 三月 2017</th><th class="next" style="visibility: visible;"><i class="fa fa-chevron-right fi-arrow-right"></i></th></tr></thead><tbody><tr><td colspan="7"><span class="hour active">0:00</span><span class="hour">1:00</span><span class="hour">2:00</span><span class="hour">3:00</span><span class="hour">4:00</span><span class="hour">5:00</span><span class="hour">6:00</span><span class="hour">7:00</span><span class="hour">8:00</span><span class="hour">9:00</span><span class="hour">10:00</span><span class="hour">11:00</span><span class="hour">12:00</span><span class="hour">13:00</span><span class="hour">14:00</span><span class="hour">15:00</span><span class="hour">16:00</span><span class="hour">17:00</span><span class="hour">18:00</span><span class="hour">19:00</span><span class="hour">20:00</span><span class="hour">21:00</span><span class="hour">22:00</span><span class="hour">23:00</span></td></tr></tbody><tfoot><tr><th colspan="7" class="today" style="display: none;">今天</th></tr></tfoot></table></div><div class="datepicker-days" style="display: block;"><table class=" table-condensed"><thead><tr><th class="prev" style="visibility: visible;"><i class="fa fa-chevron-left fi-arrow-left"></i></th><th colspan="5" class="date-switch">三月 2017</th><th class="next" style="visibility: visible;"><i class="fa fa-chevron-right fi-arrow-right"></i></th></tr><tr><th class="dow">日</th><th class="dow">一</th><th class="dow">二</th><th class="dow">三</th><th class="dow">四</th><th class="dow">五</th><th class="dow">六</th></tr></thead><tbody><tr><td class="day undefined  old">26</td><td class="day undefined  old">27</td><td class="day undefined  old">28</td><td class="day undefined ">1</td><td class="day undefined ">2</td><td class="day undefined ">3</td><td class="day undefined ">4</td></tr><tr><td class="day undefined ">5</td><td class="day undefined ">6</td><td class="day undefined ">7</td><td class="day undefined ">8</td><td class="day undefined ">9</td><td class="day undefined ">10</td><td class="day undefined ">11</td></tr><tr><td class="day undefined ">12</td><td class="day undefined ">13</td><td class="day undefined ">14</td><td class="day undefined ">15</td><td class="day undefined ">16</td><td class="day undefined ">17</td><td class="day undefined ">18</td></tr><tr><td class="day undefined ">19</td><td class="day undefined ">20</td><td class="day undefined ">21</td><td class="day undefined ">22</td><td class="day undefined ">23</td><td class="day undefined ">24</td><td class="day undefined ">25</td></tr><tr><td class="day undefined ">26</td><td class="day undefined ">27</td><td class="day undefined  active">28</td><td class="day undefined ">29</td><td class="day undefined ">30</td><td class="day undefined ">31</td><td class="day undefined  new">1</td></tr><tr><td class="day undefined  new">2</td><td class="day undefined  new">3</td><td class="day undefined  new">4</td><td class="day undefined  new">5</td><td class="day undefined  new">6</td><td class="day undefined  new">7</td><td class="day undefined  new">8</td></tr></tbody><tfoot><tr><th colspan="7" class="today" style="display: none;">今天</th></tr></tfoot></table></div><div class="datepicker-months" style="display: none;"><table class="table-condensed"><thead><tr><th class="prev" style="visibility: visible;"><i class="fa fa-chevron-left fi-arrow-left"></i></th><th colspan="5" class="date-switch">2017</th><th class="next" style="visibility: visible;"><i class="fa fa-chevron-right fi-arrow-right"></i></th></tr></thead><tbody><tr><td colspan="7"><span class="month">一</span><span class="month">二</span><span class="month active">三</span><span class="month">四</span><span class="month">五</span><span class="month">六</span><span class="month">七</span><span class="month">八</span><span class="month">九</span><span class="month">十</span><span class="month">十一</span><span class="month">十二</span></td></tr></tbody><tfoot><tr><th colspan="7" class="today" style="display: none;">今天</th></tr></tfoot></table></div><div class="datepicker-years" style="display: none;"><table class="table-condensed"><thead><tr><th class="prev" style="visibility: visible;"><i class="fa fa-chevron-left fi-arrow-left"></i></th><th colspan="5" class="date-switch">2010-2019</th><th class="next" style="visibility: visible;"><i class="fa fa-chevron-right fi-arrow-right"></i></th></tr></thead><tbody><tr><td colspan="7"><span class="year old">2009</span><span class="year">2010</span><span class="year">2011</span><span class="year">2012</span><span class="year">2013</span><span class="year">2014</span><span class="year">2015</span><span class="year">2016</span><span class="year active">2017</span><span class="year">2018</span><span class="year">2019</span><span class="year old">2020</span></td></tr></tbody><tfoot><tr><th colspan="7" class="today" style="display: none;">今天</th></tr></tfoot></table></div><a class="button datepicker-close tiny alert right" style="width: auto; display: none;"><i class="fa fa-remove fa-times fi-x"></i></a></div><div></div></body></html>
