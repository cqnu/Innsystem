<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChannelEdit.aspx.cs" Inherits="_863soft.ISS.Web.Manage.Channel.ChannelEdit" %>

<%@ Import namespace="HN863Soft.ISS.Common" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<title>编辑频道</title>
<link href="../JS/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
<script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../JS/artdialog/dialog-plus-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../JS/laymain.js"></script>
<script type="text/javascript" charset="utf-8" src="../JS/common.js"></script>
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
        //添加按钮(点击绑定)
        $("#itemAddButton").click(function () {
            showChannelDialog();
        });
        //关联规格相关字段
        var objMarketPrice;
        var objSellPrice;
        var objStockQuantity; //声明对象
        $("#cblAttributeField input").each(function () {
            var fieldArr = $(this).val().split(',');
            var fieldIndex = $("#cblAttributeField input").index($(this));
            if (fieldArr[0] == 'market_price') {
                objMarketPrice = $("#cblAttributeField").siblings("ul").children("li").eq(fieldIndex).children("a");
            }
            if (fieldArr[0] == 'sell_price') {
                objSellPrice = $("#cblAttributeField").siblings("ul").children("li").eq(fieldIndex).children("a");
            }
            if (fieldArr[0] == 'stock_quantity') {
                objStockQuantity = $("#cblAttributeField").siblings("ul").children("li").eq(fieldIndex).children("a");
            }
        });
        $("#cbIsSpec").on("click", function () {
            if ($(this).prop("checked") == true) {
                if (!objMarketPrice.parent().hasClass("selected")) {
                    objMarketPrice.trigger("click");
                }
                if (!objSellPrice.parent().hasClass("selected")) {
                    objSellPrice.trigger("click");
                }
                if (!objStockQuantity.parent().hasClass("selected")) {
                    objStockQuantity.trigger("click");
                }
            }
        });
        objMarketPrice.on("click", function () {
            if (!$(this).parent().hasClass("selected") && $("#cbIsSpec").prop("checked") == true) {
                $("#cbIsSpec").trigger("click");
            }
        });
        objSellPrice.on("click", function () {
            if (!$(this).parent().hasClass("selected") && $("#cbIsSpec").prop("checked") == true) {
                $("#cbIsSpec").trigger("click");
            }
        });
        objStockQuantity.on("click", function () {
            if (!$(this).parent().hasClass("selected") && $("#cbIsSpec").prop("checked") == true) {
                $("#cbIsSpec").trigger("click");
            }
        });
    });

    //创建窗口
    function showChannelDialog(obj) {
        var objNum = arguments.length;
        var d = top.dialog({
            id: 'dialogChannel',
            title: 'URL配置信息',
            url: 'dialog/DialogChannel.aspx'
        }).showModal();
        //检查是否修改状态
        if (objNum == 1) {
            d.data = obj;  // 给窗体传入对象
        }
    }

    //删除一行
    function delItemTr(obj) {
        top.dialog({
            title: '提示',
            content: '您确定要删除这个页面吗？',
            okValue: '确定',
            ok: function () {
                $(obj).parent().parent().remove(); //删除节点
            },
            cancelValue: '取消',
            cancel: function () { }
        }).showModal();
    }
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="ChannelList.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../Center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="ChannelList.aspx"><span>频道管理</span></a>
  <i class="arrow"></i>
  <span>编辑频道</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div id="floatHead" class="content-tab-wrap">
  <div class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a class="selected" href="javascript:;">基本信息</a></li>
        <li><a href="javascript:;">URL配置</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>调用名称</dt>
    <dd>
      <asp:TextBox ID="txtName" runat="server" CssClass="input normal" datatype="/^[a-zA-Z0-9\-\_]{2,50}$/" errormsg="请填写正确的名称！" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">*调用名称，只允许使用英文、数字或下划线。</span>
    </dd>
  </dl>
  <dl>
    <dt>频道标题</dt>
    <dd><asp:TextBox ID="txtTitle" runat="server"  CssClass="input normal" datatype="*2-100" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*标题备注，允许中文。</span></dd>
  </dl>
  <dl>
    <dt>所属站点</dt>
    <dd>
      <div class="rule-single-select">
        <asp:DropDownList id="ddlSiteId" runat="server" datatype="*" errormsg="请选择所属站点！" sucmsg=" "></asp:DropDownList>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>排序数字</dt>
    <dd>
      <asp:TextBox ID="txtSortId" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
      <span class="Validform_checktip">*数字，越小越向前</span>
    </dd>
  </dl>
  <dl>
    <dt>选择字段</dt>
    <dd>
      <div class="rule-multi-porp">
          <asp:CheckBoxList ID="cblAttributeField" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
      </div>
    </dd>
  </dl>
</div>

<div class="tab-content" style="display:none;">
  <dl>
    <dt>URL生成配置</dt>
    <dd><a id="itemAddButton" class="icon-btn add"><i></i><span>添加页面</span></a></dd>
  </dl>
  <dl>
    <dt></dt>
    <dd>
      <div class="table-container">
          <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="100%">
            <thead>
              <tr>
                <th width="12%">类型</th>
                <th width="16%">调用名称</th>
                <th width="25%">生成文件名</th>
                <th width="25%">模板文件名</th>
                <th width="12%">分页大小</th>
                <th width="10%">操作</th>
              </tr>
            </thead>
            <tbody id="item_box">
              <asp:Repeater ID="rptList" runat="server">
              <ItemTemplate>
              <tr class="td_c">
                <td>
                  <input type="hidden" name="item_rewrite" value="<%#Eval("UrlRewriteStr") %>" />
                  <input type="hidden" name="item_type" value="<%#Eval("Type")%>" />
                  <span class="item_type"><%#GetPageTypeTxt(Eval("Type").ToString())%></span>
                </td>
                <td>
                  <input type="hidden" name="old_item_name" value="<%#Eval("Name")%>" />
                  <input type="hidden" name="item_name" value="<%#Eval("Name")%>" />
                  <span class="item_name"><%#Eval("Name")%></span>
                </td>
                <td>
                  <input type="hidden" name="item_page" value="<%#Eval("Page")%>" />
                  <span class="item_page"><%#Eval("Page")%></span>
                </td>
                <td>
                  <input type="hidden" name="item_templet" value="<%#Eval("Templet")%>" />
                  <span class="item_templet"><%#Eval("Templet")%></span>
                </td>
                <td>
                  <input type="hidden" name="item_pagesize" value="<%#Eval("PageSize")%>" />
                  <span class="item_pagesize"><%#Eval("PageSize").ToString() != "" ? Eval("PageSize") : "-"%></span>
                </td>
                <td>
                  <a title="编辑" class="img-btn edit operator" onclick="showChannelDialog(this);">编辑</a>
                  <a title="删除" class="img-btn del operator" onclick="delItemTr(this);">删除</a>
                </td>
              </tr>
              </ItemTemplate>
              </asp:Repeater>
            </tbody>
          </table>
      </div>
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