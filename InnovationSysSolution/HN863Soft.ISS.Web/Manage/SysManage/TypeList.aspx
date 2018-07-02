<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TypeList.aspx.cs" Inherits="HN863Soft.ISS.Web.Manage.SysManage.TypeList" %>

<!DOCTYPE html>

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>角色类型列表</title>
<link href="../JS/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<link href="../css/pagination.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
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
  <a href="ManagerList.aspx"><span>用户列表</span></a>
  <i class="arrow"></i>
  <span>角色类型列表</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div id="floatHead" class="toolbar-wrap">
  <div class="toolbar">
    <div class="box-wrap">
      <a class="menu-btn"></a>
      <div class="l-list">
        <ul class="icon-list">
          <li><a class="add" href="TypeAdd.aspx"><i></i><span>新增</span></a></li>
    
        
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

      <th width="50%" align="center">角色类型名称</th>

      <th width="12%">操作</th>
    </tr>
  </HeaderTemplate>
  <ItemTemplate>
    <tr>
      <td align="center"><a href="TypeEdit.aspx?id=<%#Eval("ID")%>"><%#Eval("TypeName")%></a></td>
      <td align="center">


           <asp:LinkButton ID="LinkButton1" Text="修改" runat="server" PostBackUrl='<%#"TypeEdit.aspx?id="+Eval("ID") %>' Visible ='<%#bool.Parse((Convert.ToInt32(Eval("IsSys"))==0 ).ToString())%>'></asp:LinkButton>

      </td>
    </tr>
  </ItemTemplate>
  <FooterTemplate>
    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"4\">暂无记录</td></tr>" : ""%>
  </table>
  </FooterTemplate>
  </asp:Repeater>
</div>
<!--/列表-->

</form>
</body>
</html>

