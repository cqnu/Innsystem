<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrawlerKeyList.aspx.cs" Inherits="HN863Soft.ISS.Web.Manage.Crawler.CrawlerKeyList" %>
<%@ Import namespace="HN863Soft.ISS.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>关键字列表</title>
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
  <span>关键字列表</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div id="floatHead" class="toolbar-wrap">
  <div class="toolbar">
    <div class="box-wrap">
      <a class="menu-btn"></a>
      <div class="l-list">
        <ul class="icon-list">
          <li><a class="add" href="CrawlerKeyEdit.aspx?action=<%=EnumsHelper.ActionEnum.Add %>"><i></i><span>新增</span></a></li>
          <li><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','确定要删除吗？');" onclick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
        </ul>
      </div>
      <div class="r-list">
        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" onclick="btnSearch_Click">查询</asp:LinkButton>
      </div>
    </div>
  </div>
</div>
<!--/工具栏-->

<!--列表-->
<div class="table-container">
  <asp:Repeater ID="rptList" runat="server">
  <HeaderTemplate>
  <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
    <tr>
      <th width="6%">选择</th>
      <th align="left" width="28%">关键字</th>
      <th align="left" width="6%">类型</th>
      <th align="left" width="16">网站名称</th>
      <th align="left" width="28%">消息主目录</th>
      <th width="8%">操作</th>
    </tr>
  </HeaderTemplate>
  <ItemTemplate>
    <tr>
      <td align="center">
        <asp:CheckBox ID="chkId" onclick="checkReceive(this)" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
        <asp:HiddenField ID="hidId" Value='<%#Eval("ID")%>' runat="server" />
      </td>
      <td><%#Eval("Keys")%></td>
      <td><%#Eval("KeyType").ToString().Trim() == "0" ? "关键词" : Eval("KeyType").ToString().Trim() == "1" ?"网址":"关键词"%></td>
      <td><%#Eval("KeyName")%></td>
      <td><%#Eval("URLKey")%> </td>
      <td align="center">
          <a href="CrawlerKeyEdit.aspx?action=<%#EnumsHelper.ActionEnum.View %>&id=<%#Eval("ID")%>">查看</a>
          <a href="CrawlerKeyEdit.aspx?action=<%#EnumsHelper.ActionEnum.Edit %>&id=<%#Eval("ID")%>">修改</a>
      </td>
    </tr>
  </ItemTemplate>
  <FooterTemplate>
    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暂无记录</td></tr>" : ""%>
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
     <script>

         //只能单选
         function checkReceive(obj) {
             var inputName = $(obj).attr("name");
             //遍历所有的checkbox
             $("input[type=checkbox]").each(function () {
                 //如果不是当前的点击的 全部置为不选中
                 if (this != obj)
                     $(this).attr("checked", false);
                 else {
                     //已经选中 
                     if ($(this).prop("checked"))
                         $(this).attr("checked", true);
                         //再次点击时 取消选中
                     else
                         $(this).attr("checked", false);
                 }
             });
         }
    </script>
</body>
</html>