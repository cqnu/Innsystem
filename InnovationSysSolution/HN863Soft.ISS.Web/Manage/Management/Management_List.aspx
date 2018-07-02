<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Management_List.aspx.cs" Inherits="HN863Soft.ISS.Web.Manage.Management.Management_List" %>

<!DOCTYPE html>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>管理制度管理</title>
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/common.js"></script>
    <script src="../JS/artDialog/artDialog.source.js" type="text/javascript"></script>
    <link href="../JS/artDialog/skins/blue.css" rel="stylesheet" type="text/css" />
    <script src="../JS/FunctionJS.js"></script>
    <link href="../css/pagination.css" rel="stylesheet" />
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../Center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>管理制度管理</span>
        </div>
        <!--/导航栏-->
        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li runat="server" id="liAdd"><a class="add" href="Management_Add.aspx"><i></i><span>新增</span></a></li>
                            <li runat="server" id="lidel">
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                        </ul>
                    </div>
                    <div class="r-list">
                        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                        <asp:HiddenField runat="server" ID="ych" />
                        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <!--/工具栏-->
        <!--列表-->
        <div class="table-container">
            <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr>
                            <th id="xzth" width="4%">选择</th>
                            <th width="2%">序号</th>
                            <th width="12%">发布时间</th>
                            <th width="5%">发布人</th>
                            <th width="10%">标题</th>
                            <th width="12%">备注</th>
                            <th width="5%">操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td id="tdid" runat="server" align="center">
                            <asp:CheckBox ID="chkId" onclick="checkReceive(this)" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("ID")%>' runat="server" />
                        </td>
                        <td align="center"><%#Eval("rowid")%></td>
                        <td align="center"><%#Eval("Time")%></td>
                        <td align="center"><%#Eval("UserName")%></td>
                        <td align="center" title='<%#Eval("Title")%>'><%#Eval("Title").ToString().Length>15?Eval("Title").ToString().Substring(0,15)+"...":Eval("Title")%></td>
                        <td align="center" title='<%#Eval("Remarks")%>'><%#Eval("Remarks").ToString().Length>15?Eval("Remarks").ToString().Substring(0,15)+"...":Eval("Remarks")%></td>
                        <td align="center" style="white-space: nowrap; word-break: break-all; overflow: hidden;">
                           <asp:LinkButton ID="LinkButton1" Text="查看" runat="server" PostBackUrl='<%#"Management_Show.aspx?id="+Eval("ID")%>'></asp:LinkButton>
                           <asp:LinkButton ID="LinkButton2"  Text="修改" runat="server" PostBackUrl='<%#"Management_Modify.aspx?id="+Eval("ID")+"&category=1" %>' Visible='<%# Eval("Eject").ToString()=="1"? false:true %>'></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\">暂无记录</td></tr>" : ""%>
  </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
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
        window.onload = function () {
            if (document.getElementById('ych').value == "n") {
                document.getElementById('xzth').style.display = 'none';
            }
        }

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

