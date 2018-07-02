﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinkPatent_List.aspx.cs" Inherits="HN863Soft.ISS.Web.Manage.LinkPatent.LinkPatent_List" %>

<!DOCTYPE html>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>专利商标查询管理</title>
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
            <span>专利商标查询管理</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li><a class="add" href="LinkPatent_Add.aspx"><i></i><span>新增</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnAudit" runat="server" CssClass="lock" ><i></i><span></span></asp:LinkButton></li>
                            <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del"  OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                        </ul>
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
                            <th width="15%">网站名称</th>
                            <th width="30%">网址</th>
                            <th width="15%">网站描述</th>
                            <th width="5%">操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("ID")%>' runat="server" />

                        </td>
                        <td align="center"><%#Eval("rowid")%></td>
                        <td align="center"><%#Eval("hits")%></td>
                        <td align="center" title='<%#Eval("SiteName")%>'><%#Eval("SiteName").ToString().Length>20?Eval("SiteName").ToString().Substring(0,20)+"...":Eval("SiteName")%></td>
                        <td align="center" style="white-space: nowrap; word-break: break-all; overflow: hidden;">
                            <a href='<%#Eval("SiteUrl")%>' target="_blank"><%#Eval("SiteUrl")%></a>

                        </td>
                        <td align="center" title='<%#Eval("SiteDescription")%>'><%#Eval("SiteDescription").ToString().Length>20?Eval("SiteDescription").ToString().Substring(0,20)+"...":Eval("SiteDescription")%></td>
                        
                        <td align="center" style="white-space: nowrap; word-break: break-all; overflow: hidden;">
                            <a href="TechnicalService_Show.aspx?id=<%#Eval("ID")%>&category=1">查看</a>
                            <a href="LinkPatent_Modify.aspx?id=<%#Eval("ID")%>&category=1">编辑</a>
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
