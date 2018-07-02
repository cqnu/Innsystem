<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysConfig.aspx.cs" ValidateRequest="false" Inherits="_863soft.ISS.Web.Manage.Settings.SysConfig" %>
<%@ Import namespace="HN863Soft.ISS.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>系统参数设置</title>
<link href="../JS/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" charset="utf-8" src="../../Scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../Scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" charset="utf-8" src="../JS/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../JS/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../JS/common.js"></script>
<script src="../JS/artDialog/artDialog.source.js" type="text/javascript"></script>
<link href="../JS/artDialog/skins/blue.css" rel="stylesheet" type="text/css" />
<script src="../JS/FunctionJS.js"></script>

<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
    });
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../Center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>系统参数设置</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">系统基本信息</a></li>
        <li><a href="javascript:;">功能权限设置</a></li>
<%--        <li><a href="javascript:;">短信平台设置</a></li>--%>
        <li><a href="javascript:;">邮件发送设置</a></li>
      </ul>
    </div>
  </div>
</div>

<!--主站基本信息-->
<div class="tab-content">
  <dl>
    <dt>主站名称</dt>
    <dd>
      <asp:TextBox ID="webname" runat="server" CssClass="input normal" datatype="*2-255" sucmsg=" " />
      <span class="Validform_checktip">*任意字符，控制在255个字符内</span>
    </dd>
  </dl>
  <dl>
    <dt>主站域名</dt>
    <dd>
      <asp:TextBox ID="weburl" runat="server" CssClass="input normal" datatype="url" sucmsg=" " />
      <span class="Validform_checktip">*以“http://”开头，不能绑定到频道分类</span>
    </dd>
  </dl>
  <dl>
    <dt>公司名称</dt>
    <dd>
      <asp:TextBox ID="webcompany" runat="server" CssClass="input normal" />
    </dd>
  </dl>
  <dl>
    <dt>通讯地址</dt>
    <dd>
      <asp:TextBox ID="webaddress" runat="server" CssClass="input normal" />
    </dd>
  </dl>
  <dl>
    <dt>客服电话</dt>
    <dd>
      <asp:TextBox ID="webtel" runat="server" CssClass="input normal" />
      <span class="Validform_checktip">*非必填，区号+电话号码</span>
    </dd>
  </dl>
  <dl>
    <dt>传真号码</dt>
    <dd>
      <asp:TextBox ID="webfax" runat="server" CssClass="input normal" />
      <span class="Validform_checktip">*非必填，区号+传真号码</span>
    </dd>
  </dl>
  <dl>
    <dt>管理员邮箱</dt>
    <dd>
      <asp:TextBox ID="webmail" runat="server" CssClass="input normal" />
    </dd>
  </dl>
  <dl>
    <dt>主站备案号</dt>
    <dd>
      <asp:TextBox ID="webcrod" runat="server" CssClass="input normal" />
    </dd>
  </dl>
</div>
<!--/网站基本信息-->


<!--功能权限设置-->
<div class="tab-content" style="display:none">
  <dl>
    <dt>网站安装目录</dt>
    <dd>
      <asp:TextBox ID="webpath" runat="server" CssClass="input txt" datatype="*1-100" sucmsg=" " />
      <span class="Validform_checktip">*根目录输入“/”，其它输入“/目录名/”</span>
    </dd>
  </dl>
  <dl>
    <dt>后台管理目录</dt>
    <dd>
      <asp:TextBox ID="webmanagepath" runat="server" CssClass="input txt" datatype="*1-100" sucmsg=" " />
      <span class="Validform_checktip">*默认web，其它请输入目录名，否则无法进入后台</span>
    </dd>
  </dl>
  <dl>
    <dt>开启会员功能</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="memberstatus" runat="server" />
      </div>
      <span class="Validform_checktip">*关闭后关联会员的内容将失效</span>
    </dd>
  </dl>
  <dl>
    <dt>开启管理日志</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="logstatus" runat="server" />
      </div>
      <span class="Validform_checktip">*开启后将会记录管理员在后台的操作日志</span>
    </dd>
  </dl>
</div>
<!--/功能权限设置-->

<!--邮件发送设置-->
<div class="tab-content" style="display:none">
  <dl>
    <dt>SMTP服务器</dt>
    <dd>
      <asp:TextBox ID="emailsmtp" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " />
      <span class="Validform_checktip">*发送邮件的SMTP服务器地址</span>
    </dd>
  </dl>
  <dl>
    <dt>SSL加密连接</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="emailssl" runat="server" />
      </div>
      <span class="Validform_checktip">*是否启用SSL加密连接</span>
    </dd>
  </dl>
  <dl>
    <dt>SMTP端口</dt>
    <dd>
      <asp:TextBox ID="emailport" runat="server" CssClass="input small" datatype="n" sucmsg=" " />
      <span class="Validform_checktip">*SMTP服务器的端口，大部分服务商都支持25端口</span>
    </dd>
  </dl>
  <dl>
    <dt>发件人地址</dt>
    <dd>
      <asp:TextBox ID="emailfrom" runat="server" CssClass="input normal" datatype="e" sucmsg=" " />
      <span class="Validform_checktip">*发件人的邮箱地址</span>
    </dd>
  </dl>
  <dl>
    <dt>邮箱账号</dt>
    <dd>
      <asp:TextBox ID="emailusername" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " />
      <span class="Validform_checktip">*</span>
    </dd>
  </dl>
  <dl>
    <dt>邮箱密码</dt>
    <dd>
      <asp:TextBox ID="emailpassword" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " TextMode="Password" />
      <span class="Validform_checktip">*</span>
    </dd>
  </dl>
  <dl>
    <dt>发件人昵称</dt>
    <dd>
      <asp:TextBox ID="emailnickname" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" " />
      <span class="Validform_checktip">*对方收到邮件时显示的昵称</span>
    </dd>
  </dl>
</div>
<!--/邮件发送设置-->

<!--/内容-->

<!--工具栏-->
<div class="page-footer">
  <div class="btn-wrap">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
  </div>
</div>
<!--/工具栏-->
</form>
</body>
</html>
