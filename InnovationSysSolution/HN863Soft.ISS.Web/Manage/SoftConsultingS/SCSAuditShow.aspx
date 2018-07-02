<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SCSAuditShow.aspx.cs" Inherits="HN863Soft.ISS.Web.Manage.SoftConsultingS.SCSAuditShow" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>查看双软认定咨询审核信息</title>
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

     <script src="../../Ueditor/ueditor.config.js"></script>
    <script src="../../Ueditor/ueditor.all.min.js"></script>
    <script src="../../Ueditor/lang/zh-cn/zh-cn.js"></script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="SCSAuditList.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../Center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="SCSAuditList.aspx"><span>双软认定咨询审核列表</span></a>
            <i class="arrow"></i>
            <span>查看双软认定咨询审核信息</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">双软认定咨询信息</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">
            <dl>
                <dt>服务类型</dt>
                <dd>
                    <asp:DropDownList runat="server" ID="ddlType">
                    </asp:DropDownList>
                </dd>
            </dl>
            <dl>
                <dt>服务名称</dt>
                <dd>
                    <asp:TextBox runat="server" ID="txtTitle" TextMode="MultiLine" CssClass="input normal" nullmsg="请填写服务名称信息" sucmsg=" "></asp:TextBox>
                </dd>
            </dl>
              <dl>
                <dt>双软Logo</dt>
                <dd>
                </dd>
            </dl>
              <dl>
                <dt></dt>
                <dd>
                    <asp:Image ID="Image1" runat="server" Height="200px" CssClass="photo-list" Width="300px" />
                </dd>
            </dl>
            <dl>
                <dt>关键词</dt>
                <dd>
                    <asp:TextBox ID="txtKeyWord" runat="server" CssClass="input normal" ReadOnly="true" datatype="*1-100"></asp:TextBox>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>

            <dl>
                <dt>简介</dt>
                <dd>
                    <asp:TextBox ID="txtIntroduce" runat="server" CssClass="input" ReadOnly="true" TextMode="MultiLine" MaxLength="500" datatype="*1-100" sucmsg=" " Height="70px" Width="600px"></asp:TextBox>
                   
                </dd>
            </dl>
            <dl>
                <dt>服务介绍</dt>
                <dd>
                    <textarea runat="server" id="txtContent" name="txtContent" style="height: 200px; width: 80%"></textarea>
                    <script type="text/javascript">
                        var ue = UE.getEditor('txtContent', {
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
                <dt>团队介绍</dt>
                <dd>
                    <textarea runat="server" id="txaIntroduction" name="txaIntroduction" style="height: 200px; width: 80%"></textarea>
                    <script type="text/javascript">
                        var ue = UE.getEditor('txaIntroduction', {
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
                <dt>成功案例</dt>
                <dd>
                    <textarea runat="server" id="txaExample" name="txaExample" style="height: 200px; width: 80%"></textarea>
                    <script type="text/javascript">
                        var ue = UE.getEditor('txaExample', {
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
                <dt>服务咨询电话</dt>
                <dd>
                    <asp:TextBox runat="server" ID="txtPhone" CssClass="input normal" nullmsg="请输入咨询电话" sucmsg=" " />
                </dd>
            </dl>
        </div>
        <div class="page-footer">
            <div class="btn-wrap">
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
