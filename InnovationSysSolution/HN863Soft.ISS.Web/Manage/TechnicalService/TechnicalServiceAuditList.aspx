<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TechnicalServiceAuditList.aspx.cs" Inherits="HN863Soft.ISS.Web.Manage.TechnicalService.TechnicalServiceAuditList" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>技术服务审核管理</title>
    <link href="../JS/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../JS/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/common.js"></script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../Center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>技术服务审核管理</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li>
                                <asp:LinkButton ID="btnAudit" runat="server" CssClass="lock" OnClientClick="return ExePostBack('btnAudit','审核后前台将显示该信息，确定继续吗？');"><i></i><span>审核</span></asp:LinkButton></li>
                            <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','如果该机构入驻下还存在内容则无法删除，是否继续？');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                        </ul>
                        <div class="menu-list">
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="r-list">
                        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
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
                            <th width="4%">选择</th>
                            <th width="2%">序号</th>
                            <th width="7%">浏览次数</th>
                            <th width="25%">标题</th>
                            <th width="8%">发布人</th>
                            <th width="8%">状态</th>
                            <th width="8%">审核备注</th>
                            <th width="5%">操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("ID")%>' runat="server" />
                            <asp:HiddenField ID="hids" Value='<%#Eval("State")%>' runat="server" />
                        </td>
                        <td align="center"><%#Eval("rowid")%></td>
                        <td align="center"><%#Eval("hits")%></td>
                        <td align="center" title='<%#Eval("Title")%>'><%#Eval("Title").ToString().Length>20?Eval("Title").ToString().Substring(0,20)+"...":Eval("Title")%></td>
                        <td align="center"><%#Eval("UserName")%></td>
                        <td align="center">
                            <asp:LinkButton OnClientClick="return showDlg(this)" name='<%#Eval("id")%>' runat="server" value='<%#Eval("Eject")%>' Enabled='<%# Eval("State").ToString()=="0"? true:false %>' ID="lik1" Text='<%#Eval("StateInfo")%>'></asp:LinkButton></td>
                        <td align="center" title='<%#Eval("Describe")%>'><%#Eval("Describe").ToString().Trim().Length>6?Eval("Describe").ToString().Substring(0,6)+"...":Eval("Describe")%></td>
                        <td align="center" style="white-space: nowrap; word-break: break-all; overflow: hidden;">
                            <a href="TechnicalServiceAuditShow.aspx?id=<%#Eval("ID")%>&category=1">查看</a>
                            <a href="TechnicalServiceAuditModify.aspx?id=<%#Eval("ID")%>&category=1">编辑</a>
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
</body>
</html>
