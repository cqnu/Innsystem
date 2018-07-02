<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrawlerEdit.aspx.cs" ValidateRequest ="false" Inherits="HN863Soft.ISS.Web.Manage.Crawler.CrawlerEdit" %>
<%@ Import namespace="HN863Soft.ISS.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>内容编辑</title>
<link href="../JS/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<link href="../css/pagination.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script src="../../Scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../JS/artdialog/dialog-plus-min.js"></script>
<script src="../../Scripts/kindeditor-4.1.7/kindeditor-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../JS/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../JS/common.js"></script>
<script src="../JS/artDialog/artDialog.source.js" type="text/javascript"></script>
<link href="../JS/artDialog/skins/blue.css" rel="stylesheet" type="text/css" />
<script src="../JS/FunctionJS.js"></script>

<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
        //初始化编辑器
        var editorMini = KindEditor.create('#txtContent', {
            width: '100%',
            height: '250px',
            resizeType: 1,
            uploadJson: '../../WebService/UploadAjaxHandler.ashx?action=EditorFile&IsWater=1',
            items: [
				'source', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
				'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
				'insertunorderedlist', '|', 'image', 'link', 'fullscreen']
        });
    });
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="CrawlerList.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../Center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>内容编辑</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">编辑内容</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>标题</dt>
    <dd>
      <asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="*1-100" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">*标题必填</span>
    </dd>
  </dl>
  <dl>
    <dt>时间</dt>
    <dd>
      <asp:TextBox ID="txtCrawDate" ReadOnly="true" runat="server" CssClass="input normal" datatype="*1-100" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">*时间必填</span>
    </dd>
  </dl>
  <dl>
    <dt>原地址</dt>
    <dd>
      <asp:TextBox ID="txtCrawURL" runat="server" CssClass="input normal" datatype="*1-100" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">*原地址必填</span>
    </dd>
  </dl>
  <dl>
    <dt>来源</dt>
    <dd>
      <asp:TextBox ID="txtCrawSource" runat="server" CssClass="input normal"></asp:TextBox>
    </dd>
  </dl>
  <dl>
    <dt>内容</dt>
    <dd>
      <textarea id="txtContent" class="editor" style="visibility:hidden;" runat="server"></textarea>
    </dd>
  </dl>
</div>
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
