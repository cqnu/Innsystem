<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnterpriseRegistrationAuditList.aspx.cs" Inherits="HN863Soft.ISS.Web.Manage.EnterpriseRegistration.EnterpriseRegistrationAuditList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>工商注册审核管理</title>
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
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../Center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>工商注册审核管理</span>
        </div>
        <!--/导航栏-->
        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>
                    <div class="l-list">
                        <ul class="icon-list">
                            <li id="liAu" runat="server">
                                <asp:LinkButton ID="btnAudit" Visible="true" runat="server" CssClass="lock" OnClientClick="return show('btnAudit');" OnClick="btnAudit_Click"><i></i><span>审核</span></asp:LinkButton></li>
                            <li id="li1" runat="server">
                                <asp:LinkButton ID="btnJurisdiction" runat="server" CssClass="lock" OnClientClick="return ExeJurisdiction('btnJurisdiction');" OnClick="btnJurisdiction_Click"><i></i><span>用户查看权限设置</span></asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                        </ul>
                        <div class="menu-list">
                            <div class="rule-single-select">
                                <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="r-list">
                        <asp:HiddenField runat="server" ID="hidState" />
                        <asp:HiddenField runat="server" ID="hidDescribe" />
                        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="lbtnSearch_Click">查询</asp:LinkButton>
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
                            <th width="25%">标题</th>
                            <th width="8%">发布人</th>
                            <th width="8%">状态</th>
                            <th width="8%">普通用户是否可查看</th>
                            <th width="8%">审核备注</th>
                            <th width="5%">操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:CheckBox ID="chkId" onclick="checkReceive(this)" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("ID")%>' runat="server" />
                            <asp:HiddenField ID="hids" Value='<%#Eval("State")%>' runat="server" />
                        </td>
                        <td align="center"><%#Eval("rowid")%></td>
                        <td align="center" title='<%#Eval("Title")%>'><%#Eval("Title").ToString().Length>20?Eval("Title").ToString().Substring(0,20)+"...":Eval("Title")%></td>
                        <td align="center"><%#Eval("UserName")%></td>
                        <td align="center"><%#Eval("StateInfo")%></td>
                        <td align="center"><%#Eval("Jurisdiction").ToString()=="0"?"是":"否"%></td>
                        <td align="center" title='<%#Eval("Describe")%>'><%#Eval("Describe").ToString().Trim().Length>6?Eval("Describe").ToString().Substring(0,6)+"...":Eval("Describe")%></td>
                        <td align="center" style="white-space: nowrap; word-break: break-all; overflow: hidden;">
                            <asp:LinkButton ID="LinkButton1" Text="查看" runat="server" PostBackUrl='<%#"EnterpriseRegistrationAuditShow.aspx?id="+Eval("ID")%>'></asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" Text="修改" runat="server" PostBackUrl='<%#"EnterpriseRegistrationAuditModify.aspx?id="+Eval("ID")%>' Visible='<%# Eval("State").ToString()=="1"? false:true %>'></asp:LinkButton>
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

        function show(objId, objmsg) {

            if ($(".checkall input:checked").size() < 1) {
                parent.dialog({
                    title: '提示',
                    content: '对不起，请选中您要操作的记录！',
                    okValue: '确定',
                    ok: function () { }
                }).showModal();
                return false;
            }

            //获取选中行的隐藏值
            var ipts = $(":checkbox:checked").parents("td").find("input:hidden");

            //取得审核状态
            var sta = ipts[1].value;

            //状态=1 说明已通过 无法再次进行审核
            if (sta == 1) {
                parent.dialog({
                    title: '提示',
                    content: '对不起，已审核通过的无法再次审核！',
                    okValue: '确定',
                    ok: function () { }
                }).showModal();
                return false;
            }

            parent.dialog({
                title: '审核通过后将不能进行删除与修改！',
                content: ' <script> ' +
                         '  function to_change() { ' +
                         ' var a = parent.document.getElementById("traDescribe").value;' +
                         '  var checklists = parent.document.getElementsByName("Fruit"); ' +
                         '    var i = 0; ' +
                         '   var a = ""; ' +
                         '  for (i = 0; i < checklists.length; i++) { ' +
                         '     if (checklists[i].checked) { ' +
                         '             a = checklists[i].value; ' +
                         '         } ' +
                         '     } ' +
                         '     if (a == "No") ' +
                         '   {  ' +
                         '  parent.document.getElementById("lblInfo").style.display = "block"; ' +
                         '   } ' +
                         ' else {   parent.document.getElementById("lblInfo").style.display = "none";  }  ' +
                         ' } ' +
                          ' </' + 'script> ' + '  批准：<input name="Fruit" type="radio" value="Yes" checked onclick="to_change()" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 拒绝:<input name="Fruit" type="radio" value="No" onclick="to_change()" /> </br>  <textarea id="traDescribe" value="" MaxLength="200" />  <asp:Label ID="lblInfo" Style="font-size: smaller; color: red; display: none" runat="server">*请填写原因</asp:Label>  ',
                okValue: '确定',
                widht: 500,
                heigth: 500,
                ok: function () {

                    //获取单选框
                    var checklists = parent.document.getElementsByName("Fruit");
                    var i = 0;
                    var a = "";
                    for (i = 0; i < checklists.length; i++) {
                        if (checklists[i].checked) {
                            a = checklists[i].value;
                        }
                    }
                    //如果点击的是拒绝 且未填写理由 直接返回
                    if (a == "No") {
                        if (parent.document.getElementById("traDescribe").value == "") {
                            return false;
                        }
                        else {
                            document.getElementById('hidDescribe').value = parent.document.getElementById("traDescribe").value;
                            document.getElementById('hidState').value = 2;
                            __doPostBack(objId, '');
                        }

                    }
                    else {
                        document.getElementById('hidDescribe').value = parent.document.getElementById("traDescribe").value;
                        document.getElementById('hidState').value = 1;
                        __doPostBack(objId, '');
                    }

                },
                cancelValue: '取消',
                cancel: function () { }
            }).showModal();

            return false;
        }

    </script>
</body>
</html>

