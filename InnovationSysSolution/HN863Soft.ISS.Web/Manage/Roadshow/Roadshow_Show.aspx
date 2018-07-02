<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Roadshow_Show.aspx.cs" Inherits="HN863Soft.ISS.Web.Manage.Roadshow.Roadshow_Show" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>

    <script src="../../My97DatePicker/WdatePicker.js"></script>

    <link href="../../Uploadify/uploadify.css" rel="stylesheet" />
    <script src="../../Uploadify/jquery.uploadify.v2.1.4.js"></script>
    <script src="../../Uploadify/jquery.uploadify.v2.1.4.min.js"></script>
    <script src="../../Uploadify/swfobject.js"></script>

    <link href="../JS/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />

    <script src="../../Ueditor/ueditor.config.js"></script>
    <script src="../../Ueditor/ueditor.all.min.js"></script>
    <script src="../../Ueditor/lang/zh-cn/zh-cn.js"></script>

    <link href="../../video/video-js.css" rel="stylesheet" />
    <script src="../../video/video.js"></script>
    <script>
        videojs.options.flash.swf = "../../video/video-js.swf";
    </script>

    <script type="text/javascript" charset="utf-8" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/uploader.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/common.js"></script>
    <script src="../JS/artDialog/artDialog.source.js" type="text/javascript"></script>
    <link href="../JS/artDialog/skins/blue.css" rel="stylesheet" type="text/css" />
    <script src="../JS/FunctionJS.js"></script>
    <%--        <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
            //初始化上传控件
          
        });
    </script>--%>
    <script type="text/javascript">

    </script>

</head>
<body class="mainbody">
    <form id="form1" runat="server">

        <!--导航栏-->
        <div class="location">
            <a href="Roadshow_List.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../Center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="Roadshow_List.aspx"><span>路演发布管理</span></a>
            <i class="arrow"></i>
            <span>查看路演发布信息</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->
        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">路演基本信息</a></li>
                        <li><a href="javascript:;">路演详细信息</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content" style="height: 100%">
<%--            <dl>
                <dt>权限资源</dt>
                <dd>
                    <div class="rule-multi-porp">
                        <asp:CheckBoxList ID="cblActionType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
                    </div>
                    <span class="Validform_checktip">（全选或全不选都默认为全部可看）。</span>

                </dd>
            </dl>--%>
            <dl>
                <dt>路演封面</dt>
                <dd>
                    <asp:Image ID="Image1" runat="server" Height="200px" Width="300px" />
            </dl>
            <dl>
                <dt>路演主题</dt>
                <dd>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="*1-100" sucmsg=" "></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>机构名称</dt>
                <dd>
                    <asp:TextBox ID="txtOrganizationName" runat="server" CssClass="input normal" datatype="*1-100" sucmsg=" "></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>路演关键词</dt>
                <dd>
                    <asp:TextBox ID="txtKeyWord" runat="server" CssClass="input normal" datatype="*1-16" sucmsg=" "></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>主讲人</dt>
                <dd>
                    <asp:TextBox ID="txtSpeaker" runat="server" CssClass="input normal" datatype="*1-50" sucmsg=" "></asp:TextBox>
                </dd>
            </dl>

            <dl>
                <dt>路演时间</dt>
                <dd>
                    <input id="startDate" runat="server" readonly="disabled" class="Wdate" datatype="*" type="text" onfocus="var endDate=$dp.$('endDate');WdatePicker({dateFmt:'yyyy-MM-dd HH:mm',onpicked:function(){endDate.focus();},maxDate:'#F{$dp.$D(\'endDate\')}'})" />
                    至
                    <input id="endDate" runat="server" readonly="disabled" class="Wdate" datatype="*" type="text" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm',minDate:'#F{$dp.$D(\'startDate\')}'})" />
                </dd>
            </dl>
            <dl>
                <dt>项目地点</dt>
                <dd>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlProvince" Width="100px"  runat="server" datatype="*" errormsg="请选择所属类型！" sucmsg=" "></asp:DropDownList>
                            <asp:DropDownList ID="ddlCity" Width="200px" runat="server" datatype="*" errormsg="请选择所属类型！" sucmsg=" "></asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </dd>
            </dl>

            <dl>
                <dt>路演简介</dt>
                <dd>
                    <asp:TextBox ID="txtObjective" runat="server" CssClass="input" TextMode="MultiLine" MaxLength="500" datatype="*1-500" sucmsg=" " Height="100px"></asp:TextBox>
                </dd>
            </dl>
        </div>

        <div class="tab-content" style="display: none;">

            <dl>
                <dt>项目宣传视频</dt>
                <dd>
                    <asp:HiddenField runat="server" ID="hid" />
                    <video controls="metadata" src='<%= strSrc%>' id="example_video_1" class="video-js vjs-default-skin" width="800" height="500">
                    </video>
                </dd>
                <dd style="color: red">*为确保视频正确加载，如果是IE浏览器，请使用IE9以上版本。如果是其他浏览器，请用兼容性模式打开本站。</dd>

            </dl>
            <dl>
            </dl>
            <dl>
            </dl>
            <dl>
            </dl>
            <dl>
            </dl>
            <dl>
            </dl>
            <dl>
                <dt>项目详情</dt>
                <dd>

                    <div id="content" style="width: auto; height: auto"><%=strContent %></div>
                </dd>
            </dl>
        </div>
        <!--/内容-->
        <div class="page-footer">
            <div class="btn-wrap">
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>

    </form>
</body>
</html>

