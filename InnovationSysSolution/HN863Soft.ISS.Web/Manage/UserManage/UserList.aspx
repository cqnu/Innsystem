<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="HN863Soft.ISS.Web.Manage.Settings.UserList" %>

<%@ Import namespace="HN863Soft.ISS.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>用户列表</title>
<link href="../JS/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<link href="../css/pagination.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../JS/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../JS/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../JS/common.js"></script>
<script src="../JS/artDialog/artDialog.source.js" type="text/javascript"></script>
<link href="../JS/artDialog/skins/blue.css" rel="stylesheet" type="text/css" />
<script src="../JS/FunctionJS.js"></script>

</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../Center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>用户信息</span>
</div>
<!--/导航栏-->

<!--列表-->
<div class="table-container">
  <asp:Repeater ID="rptList" runat="server">
  <HeaderTemplate>
  <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
    <tr>
      <th width="8%"></th>
      <th align="left" width="12%">用户名</th>
      <th align="left" width="12%">姓名</th>
      <th align="left" width="12%">角色</th>
      <th align="left" width="12%">电话</th>
      <th align="left" width="12%">积分</th>
      <th width="12%">状态</th>
      <th width="12%">操作</th>
    </tr>
  </HeaderTemplate>
  <ItemTemplate>
    <tr>
      <td align="center">
      </td>
      <td><a href="UserEdit.aspx?action=<%#EnumsHelper.ActionEnum.Edit %>&id=<%#Eval("ID")%>"><%# Eval("UserName") %></a></td>
      <td><%# Eval("RealName") %></td>
      <td><%#new HN863Soft.ISS.BLL.ManagerRole().GetTitle(Convert.ToInt32(Eval("RoleID")))%></td>
      <td><%# Eval("Telephone") %></td>
      <td><%#string.Format("{0:g}",Eval("Point"))%></td>
      <td align="center"><%#Eval("IsLock").ToString().Trim() == "0" ? "正常" : "禁用"%></td>
      <td align="center"><a href="UserEdit.aspx?action=<%#EnumsHelper.ActionEnum.Edit %>&id=<%#Eval("ID")%>">修改</a></td>
    </tr>
  </ItemTemplate>
  <FooterTemplate>
    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\">暂无记录</td></tr>" : ""%>
  </table>
  </FooterTemplate>
  </asp:Repeater>
</div>
<!--/列表-->

<!--内容底部-->
<div class="line20"></div>
<div class="pagelist">
  <div class="l-btns">
    <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);"
                OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
  </div>
  <div id="PageContent" runat="server" class="default"></div>
</div>
<!--/内容底部-->
</form>
</body>
</html>