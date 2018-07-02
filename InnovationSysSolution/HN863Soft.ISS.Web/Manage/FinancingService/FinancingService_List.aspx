<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinancingService_List.aspx.cs" Inherits="HN863Soft.ISS.Web.Manage.FinancingService.FinancingService_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>投融资服务管理</title>
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
    <script src="../../Ueditor/ueditor.config.js"></script>
    <script src="../../Ueditor/ueditor.all.min.js"></script>
    <script src="../../Ueditor/lang/zh-cn/zh-cn.js"></script>
    <link href="../css/pagination.css" rel="stylesheet" />
    <style type="text/css">
        .hideDlg {
            height: 129px;
            width: 368px;
            display: none;
        }

        .showDlg {
            background-color: #ffffdd;
            border-width: 3px;
            border-style: solid;
            height: 129px;
            width: 368px;
            position: absolute;
            display: block;
            z-index: 5;
        }

        .showDeck {
            display: block;
            top: 0px;
            left: 0px;
            margin: 0px;
            padding: 0px;
            width: 100%;
            height: 100%;
            position: absolute;
            z-index: 3;
            background: #cccccc;
        }

        .hideDeck {
            display: none;
        }
    </style>

    <script type="text/javascript">

        function showDlg(id) {

            var strid = id;
            //如果不是管理员 直接返回
            if (strid.getAttribute("value") == "N") {
                return;
            }
            //如果文章已审核完 直接返回
            if (strid.innerText != "未审核") {
                return;
            }
            //储存主键id
            document.getElementById('hid1').value = strid.getAttribute("name");
            //显示遮盖的层
            var objDeck = document.getElementById("deck");
            if (!objDeck) {
                objDeck = document.createElement("div");
                objDeck.id = "deck";
                document.body.appendChild(objDeck);
            }
            objDeck.className = "showDeck";
            objDeck.style.filter = "alpha(opacity=50)";
            objDeck.style.opacity = 40 / 100;
            objDeck.style.MozOpacity = 40 / 100;
            //显示遮盖的层end

            //禁用select
            hideOrShowSelect(true);

            //改变样式
            document.getElementById('divBox').className = 'showDlg';

            //调整位置至居中
            adjustLocation();

            return false;

        }

        function cancel() {
            document.getElementById('divBox').className = 'hideDlg';
            document.getElementById("deck").className = "hideDeck";
            hideOrShowSelect(false);
        }

        function hideOrShowSelect(v) {
            var allselect = document.getElementsByTagName("select");
            for (var i = 0; i < allselect.length; i++) {
                //allselect[i].style.visibility = (v==true)?"hidden":"visible";
                allselect[i].disabled = (v == true) ? "disabled" : "";
            }
        }

        function adjustLocation() {
            var obox = document.getElementById('divBox');
            if (obox != null && obox.style.display != "none") {
                var w = 368;
                var h = 129;
                var oLeft, oTop;

                if (window.innerWidth) {
                    oLeft = window.pageXOffset + (window.innerWidth - w) / 2 + "px";
                    oTop = window.pageYOffset + (window.innerHeight - h) / 2 + "px";
                }
                else {
                    var dde = document.documentElement;
                    oLeft = dde.scrollLeft + (dde.offsetWidth - w) / 2 + "px";
                    oTop = dde.scrollTop + (dde.offsetHeight - h) / 2 + "px";
                }

                obox.style.left = oLeft;
                obox.style.top = oTop;
            }
        }

    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../Center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>投融资服务管理</span>
        </div>
        <!--/导航栏-->
        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li><a class="add" href="FinancingService_Add.aspx"><i></i><span>新增</span></a></li>
                            <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                            <li>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
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

                        </td>
                        <td align="center"><%#Eval("rowid")%></td>
                        <td align="center"><%#Eval("hits")%></td>
                        <td align="center" title='<%#Eval("Title")%>'><%#Eval("Title").ToString().Length>20?Eval("Title").ToString().Substring(0,20)+"...":Eval("Title")%></td>
                        <td align="center"><%#Eval("UserName")%></td>
                        <td align="center">

                            <asp:LinkButton OnClientClick="return showDlg(this)" name='<%#Eval("id")%>' runat="server" value='<%#Eval("Eject")%>' Enabled='<%# Eval("State").ToString()=="0"? true:false %>' ID="lik1" Text='<%#Eval("StateInfo")%>'></asp:LinkButton></td>
                        <td align="center" title='<%#Eval("Describe")%>'><%#Eval("Describe").ToString().Trim().Length>6?Eval("Describe").ToString().Substring(0,6)+"...":Eval("Describe")%></td>
                        <td align="center" style="white-space: nowrap; word-break: break-all; overflow: hidden;">
                            <a href="FinancingService_Show.aspx?id=<%#Eval("ID")%>&category=1">查看</a>
                            <a href="FinancingService_Modify.aspx?id=<%#Eval("ID")%>&category=1">编辑</a>
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
        <div id="divBox" class="hideDlg" style="">
            <table width="100%" style="height: 100%; width: 100%;" id="table1">
                <tr>
                    <td style="height: 20px; text-align: center;" colspan="3">
                        <asp:RadioButtonList RepeatDirection="Horizontal" ID="RadioButtonList1" runat="server" Width="239px">
                            <asp:ListItem Text="批准" Value="Yes" Selected="True">
                            </asp:ListItem>
                            <asp:ListItem Text="拒绝" Value="No"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>原因:</td>
                    <td>
                        <asp:HiddenField runat="server" ID="hid1" />
                        <asp:TextBox runat="server" ID="txtDescribe" CssClass="input normal" MaxLength="200"></asp:TextBox></br>
                 
                        <asp:Label ID="lblInfo" Style="font-size: smaller; color: red; display: none" runat="server">*请填写原因</asp:Label>
                        <%--<input name="TextBox1" type="text" id="TextBox1" />--%>
                    </td>
                    <td></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <input type="button" name="Button1" value="确定" id="Button1" size="10" onclick="update()" />
                        &nbsp;&nbsp;
                            <input type="button" name="Button2" value="取消" id="Button2" size="10" onclick="cancel();" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
    <script>
        function update() {
            var checklists = document.getElementsByName("RadioButtonList1");
            var i = 0;
            var a = "";
            for (i = 0; i < checklists.length; i++) {
                if (checklists[i].checked) {
                    a = checklists[i].value;
                }
            }
            //如果点击的是拒绝 切未填写理由 直接返回
            if (a == "No") {
                if ($('#txtDescribe').val().trim().toString() == "") {
                    document.getElementById("lblInfo").style.display = "block";
                    return;
                }
                else {
                    $.ajax({
                        type: "POST",
                        url: "../../WebService/UpdateHandler.ashx",
                        data: { id: $('#hid1').val(), state: 2, Describe: $('#txtDescribe').val(), TableName: "Financing", PageName: "投融资服务" },
                        success: function (msg) {
                            //window.alert(data);
                            //alert(msg);

                        }
                    });
                }
            }
            else {
                $.ajax({
                    type: "POST",
                    url: "../../WebService/UpdateHandler.ashx",
                    data: { id: $('#hid1').val(), state: 1, Describe: $('#txtDescribe').val(), TableName: "Financing", PageName: "投融资服务" },
                    success: function (msg) {
                        //alert(msg);

                    }
                });

            }
            document.getElementById("lblInfo").style.display = "none";
            var checklists = document.getElementsByName("RadioButtonList1");
            var i = 0;
            var a = "";
            for (i = 0; i < checklists.length; i++) {
                if (checklists[i].checked) {
                    if (checklists[i].value == "Yes") {
                        checklists[i].Selected = true;
                    }
                }
            }
            window.location.reload();
            //location = location;

        }

    </script>
</body>
</html>
