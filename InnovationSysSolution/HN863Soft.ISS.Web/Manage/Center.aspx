<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Center.aspx.cs" Inherits="HN863Soft.ISS.Web.Manage.Center" %>

<%@ Import namespace="HN863Soft.ISS.Common" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>管理首页</title>
<link href="skin/default/style.css" rel="stylesheet" type="text/css" />
<link href="JS/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="JS/layindex.js"></script>
<script type="text/javascript" charset="utf-8" src="JS/common.js"></script>
<script src="JS/artDialog/artDialog.source.js" type="text/javascript"></script>
<link href="JS/artDialog/skins/blue.css" rel="stylesheet" type="text/css" />
<script src="JS/FunctionJS.js"></script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>管理中心</span>
</div>
<!--/导航栏-->

<!--内容-->
<div class="line10"></div>
<div class="nlist-1">
  <ul>
<%--    <li>本次登录IP：<asp:Literal ID="litIP" runat="server" Text="-" /></li>
    <li>上次登录IP：<asp:Literal ID="litBackIP" runat="server" Text="-" /></li>
    <li>上次登录时间：<asp:Literal ID="litBackTime" runat="server" Text="-" /></li>--%>
  </ul>
</div>
<div class="line10"></div>

<div class="nlist-2">
  <h3><i></i>提示信息</h3>
  <ul id="div_showinfo" runat ="server"></ul>
</div>
<div class="line20"></div>

<div id="div_function_manage" class="nlist-3" style ="width:100%" runat ="server">
  <span style ="white-space: nowrap;background-repeat: no-repeat;zoom: 1;display: inline-block;color:blue">功能管理</span>
  <hr style="color:blue;height:1px;"/>
  <br />
  <ul id="div_firstfunctionlist" runat ="server" style ="width:100%"></ul>
</div>

<div class="line20"></div>
<div id="div_system_manage" class="nlist-3" style ="width:100%" runat ="server">
  <span style ="white-space: nowrap;background-repeat: no-repeat;zoom: 1;display: inline-block;color:blue">系统管理</span>
  <hr style="color:blue;height:1px;"/>
  <br />
  <ul id="div_secondfunctionlist" runat ="server" style ="width:100%"></ul>
</div>

<div class="line20"></div>
<div id="div_person" class="nlist-3" style ="width:100%" runat="server">
  <span style ="white-space: nowrap;background-repeat: no-repeat;zoom: 1;display: inline-block;color:blue">个人中心</span>
  <hr style="color:blue;height:1px;"/>
  <br />
  <ul id="div_threedfunctionlist" runat ="server" style ="width:100%"></ul>
</div>
</form>
</body>
</html>