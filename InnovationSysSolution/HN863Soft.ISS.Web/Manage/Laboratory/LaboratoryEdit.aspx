<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LaboratoryEdit.aspx.cs" ValidateRequest ="false" Inherits="HN863Soft.ISS.Web.Manage.Laboratory.LaboratoryEdit" %>

<!DOCTYPE html>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>机构入驻编辑</title>
    <link href="../JS/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>

    <script type="text/javascript" src="../JS/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/common.js"></script>
    <script src="../JS/artDialog/artDialog.source.js" type="text/javascript"></script>
    <link href="../JS/artDialog/skins/blue.css" rel="stylesheet" type="text/css" />
    <script src="../JS/FunctionJS.js"></script>

    <link href="../../../Scripts/kindeditor-4.1.7/themes/default/default.css" rel="stylesheet" />
    <script src="../../../Scripts/kindeditor-4.1.7/kindeditor-min.js"></script>
    <script src="../../../Scripts/kindeditor-4.1.7/lang/zh_CN.js"></script>
    <script src="../../Ueditor/ueditor.config.js"></script>
    <script src="../../Ueditor/ueditor.all.min.js"></script>
    <script src="../../Ueditor/lang/zh-cn/zh-cn.js"></script>
    <script>
        var editor;
        KindEditor.ready(function (K) {
            editor = K.create('textarea[id="txtContent"]', {
                resizeType: 2,
                allowPreviewEmoticons: false,
                allowImageUpload: false,
                items: [
                    'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
                    'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
                    'insertunorderedlist', '|', 'emoticons', 'link']
                //'image',
            });
        });

        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
        });
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="LaboratoryList.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../Center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="LaboratoryList.aspx"><span>重点实验室管理列表</span></a>
            <i class="arrow"></i>
            <span>重点实验室信息</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">重点实验室信息</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
<%--               <dl>
                <dt>类型</dt>
                <dd>
                  <div class="rule-single-select">
                    <asp:DropDownList id="ddlLabType" runat="server" datatype="*" errormsg="请选择所属类型！" sucmsg=" "></asp:DropDownList>
                  </div>
                </dd>
              </dl>--%>
              <dl>
                <dt>名称</dt>
                <dd><asp:TextBox ID="labName" runat="server"  CssClass="input normal" datatype="*2-100" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*实验室名称必填</span></dd>
              </dl>
              <dl>
                <dt>位置</dt>
                <dd><asp:TextBox ID="labLocation" runat="server"  CssClass="input normal" datatype="*2-100" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*实验室位置必填</span></dd>
              </dl>
              <dl>
                <dt>拥有者</dt>
                <dd><asp:TextBox ID="tbUserName" runat="server"  CssClass="input normal" datatype="*2-100" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*拥有者必填</span></dd>
              </dl>
              <dl>
                <dt>收费标准</dt>
                <dd><asp:TextBox ID="tbChargingStandard" runat="server"  CssClass="input normal" datatype="*2-100" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*收费标准必填</span></dd>
              </dl>
              <dl>
                <dt>联系人</dt>
                <dd><asp:TextBox ID="linkMan" runat="server"  CssClass="input normal" datatype="*2-100" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*联系人必填</span></dd>
              </dl>
             <dl>
                <dt>联系电话</dt>
                <dd><asp:TextBox ID="tbMobile" runat="server"  CssClass="input normal" datatype="*2-100" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*联系电话必填</span></dd>
              </dl>
             <dl>
                <dt>邮箱</dt>
                <dd><asp:TextBox ID="tbUserEmail" runat="server"  CssClass="input normal" datatype="*2-100" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*邮箱必填</span></dd>
              </dl>
            <dl>
                <dt>微信</dt>
                <dd><asp:TextBox ID="tbLabWeiXin" runat="server"  CssClass="input normal" datatype="*2-100" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">微信</span></dd>
              </dl>
              <dl>
                <dt>证明文件</dt>
                <dd>
                    <textarea runat="server" id="Evidence" name="Evidence" style="height: 200px; width: 80%"></textarea><span class="Validform_checktip">*实验室证明文件必填</span>
                     <script type="text/javascript">
                         var ue = UE.getEditor('Evidence', {
                             toolbars: [
                                 ['fullscreen', 'simpleupload', 'insertimage', 'justifyleft', 'justifyright', 'justifycenter', 'forecolor', 'imagecenter']
                             ],
                             autoHeightEnabled: true,
                             autoFloatEnabled: true
                         });
                        </script>
                </dd>
              </dl>
             <dl>
                <dt>展示</dt>
                <dd>
                    <textarea runat="server" id="tbLabShow" name="tbLabShow" style="height: 200px; width: 80%"></textarea><span class="Validform_checktip">实验室展示</span>
                     <script type="text/javascript">
                         window.onload = function () {
                             var ue = UE.getEditor('tbLabShow', {
                                 toolbars: [
                                     ['fullscreen', 'simpleupload', 'insertimage', 'justifyleft', 'justifyright', 'justifycenter', 'forecolor', 'imagecenter']
                                 ],
                                 autoHeightEnabled: true,
                                 autoFloatEnabled: true
                             });

                         }
                        </script>
                </dd>
              </dl>
              <dl>
                <dt>简介</dt>
                <dd>
                    <textarea runat="server" id="tbLabIntro" name="tbLabIntro" style="height: 200px; width: 80%"></textarea><span class="Validform_checktip">实验室简介</span>
                     <script type="text/javascript">
                         var ue = UE.getEditor('tbLabIntro', {
                             toolbars: [
                                 ['fullscreen', 'simpleupload', 'insertimage', 'justifyleft', 'justifyright', 'justifycenter', 'forecolor', 'imagecenter']
                             ],
                             autoHeightEnabled: true,
                             autoFloatEnabled: true
                         });
                        </script>
                </dd>
            </dl>
            <dl>
                <dt>审核不通过原因</dt>
                <dd>
                    <textarea runat="server" name="content" id="txtContent" style="width: 800px; height: 200px; visibility: hidden;"></textarea><span class="Validform_checktip"><font color="red">由审核人员填写</font></span>
                </dd>
            </dl>
            </div>
        <div class="page-footer">
            <div class="btn-wrap">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>