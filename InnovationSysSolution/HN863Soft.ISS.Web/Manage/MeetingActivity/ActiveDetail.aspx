<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="ActiveDetail.aspx.cs" Inherits="HN863Soft.ISS.Web.Manage.MeetingActivity.ActiveDetail" %>

<%@ Import Namespace="HN863Soft.ISS.Common" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <script src="../../../Scripts/jquery-3.1.1.min.js"></script>
    <link href="../../../Scripts/kindeditor-4.1.7/themes/default/default.css" rel="stylesheet" />
    <script type="text/javascript" src="../../../Scripts/kindeditor-4.1.7/kindeditor-min.js"></>
    <script type="text/javascript"   src="../../../Scripts/kindeditor-4.1.7/lang/zh_CN.js"></script>

    <title></title>
    <style type="text/css">
        DIV {
            FONT-FAMILY: 宋体;
        }

        TD {
            FONT-FAMILY: 宋体;
        }

        TD {
            FONT-SIZE: 12px;
            LINE-HEIGHT: 18px;
        }

        .red {
            COLOR: #ff0000;
        }

        .fB {
            FONT-WEIGHT: bold;
        }

        .pad10L {
            PADDING-LEFT: 10px;
        }

        .g {
            COLOR: #666666;
        }

        .i {
            FONT-SIZE: 16px;
            FONT-FAMILY: arial;
        }

        A.top {
            FONT-FAMILY: arial;
        }

            A.top:link {
                COLOR: #0000cc;
                TEXT-DECORATION: underline;
            }

            A.top:visited {
                COLOR: #800080;
                TEXT-DECORATION: underline;
            }

            A.top:active {
                COLOR: #0000cc;
                TEXT-DECORATION: underline;
            }

        .c {
            COLOR: #7777cc;
        }

        A.c {
            COLOR: #7777cc;
        }

            A.c:visited {
                COLOR: #7777cc;
            }

        .ntb {
            WIDTH: 100%;
            LINE-HEIGHT: 20px;
            HEIGHT: 20px;
            BACKGROUND-COLOR: #0000cc;
        }

        .pg {
            FONT-SIZE: 14px;
            WORD-SPACING: 4px;
            WIDTH: 80%;
            LINE-HEIGHT: 30px;
            FONT-FAMILY: arial;
            HEIGHT: 30px;
            TEXT-ALIGN: center;
        }

        .pg {
            FONT-FAMILY: arial;
        }

            .pg FONT {
                FONT-SIZE: 16px;
            }

        .d {
            PADDING-LEFT: 10px;
        }

        .s {
            TABLE-LAYOUT: fixed;
            PADDING-LEFT: 10px;
            FONT-SIZE: 14px;
            WORD-BREAK: break-all;
        }

        .u {
            TABLE-LAYOUT: fixed;
            PADDING-LEFT: 10px;
            WORD-BREAK: break-all;
        }

        .BG3 {
            BORDER-RIGHT: #cccccc 1px solid;
            BORDER-TOP: #cccccc 1px solid;
            MARGIN-TOP: 10px;
            BORDER-LEFT: #cccccc 1px solid;
            BORDER-BOTTOM: #cccccc 1px solid;
        }

        .bgr3 {
            LINE-HEIGHT: 24px;
            HEIGHT: 24px;
            BACKGROUND-COLOR: #eeeeee;
        }

        .pad5L {
            PADDING-LEFT: 5px;
        }

        BODY {
            MARGIN: 0px;
        }

        FORM {
            MARGIN: 0px;
        }

        .usrbar {
            PADDING-RIGHT: 10px;
            MARGIN-TOP: 4px;
            FONT-SIZE: 12px;
            LINE-HEIGHT: 19px;
            FONT-FAMILY: Arial;
            HEIGHT: 19px;
            TEXT-ALIGN: right;
        }

        .hdch {
            MARGIN-TOP: 3px;
            FONT-SIZE: 14px;
            FONT-FAMILY: arial;
            HEIGHT: 21px;
        }

        .wlk {
            COLOR: #ffffff;
        }

        A.wlk {
            COLOR: #ffffff;
        }

            A.wlk:visited {
                COLOR: #ffffff;
            }

        .style3 {
            COLOR: #ffffff;
        }

        .gr {
            COLOR: #009933;
        }

        .stytle4 {
            color: #0000FF;
            font-size: 14px;
        }

        .stytle5 {
            font-size: 14px;
        }

        textarea {
            display: block;
        }

        .content Img {
            width: 100%;
            height: auto;
        }

        table.altrowstable {
            font-family: verdana,arial,sans-serif;
            font-size: 11px;
            color: #333333;
            border-width: 1px;
            background-color: #d4e3e5;
            border-color: #a9c6c9;
            border-collapse: collapse;
        }

            /*table.altrowstable th {
                border-width: 1px;
                padding: 8px;
                border-style: solid;
                border-color: #a9c6c9;
            }*/

            table.altrowstable td {
                border-width: 1px;
                /*padding: 8px;*/
                border-style: solid;
                border-color: #a9c6c9;
            }
    </style>
    <link href="../JS/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../JS/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/common.js"></script>
    <script src="../JS/artDialog/artDialog.source.js" type="text/javascript"></script>
    <link href="../JS/artDialog/skins/blue.css" rel="stylesheet" type="text/css" />
    <script src="../JS/FunctionJS.js"></script>
    <script src="../../Ueditor/ueditor.config.js"></script>
    <script src="../../Ueditor/ueditor.all.min.js"></script>
    <script src="../../Ueditor/lang/zh-cn/zh-cn.js"></script>
    <script type="text/javascript">

        //回复人
        function focuss(values) {
            var depremark = $(values).attr("Id")
            var name = $(values).attr("name");
            $("#txtContent").val(name);
            $("#txtId").val(depremark);//主键Id
            ue.setContent("@" + name);
        }
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <!--导航栏-->
        <div class="location">
            <a href="ActiveList.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../Center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="ActiveList.aspx"><span>难题吐槽列表</span></a>
            <i class="arrow"></i>
            <span>查看难题吐槽信息</span>
        </div>
        <div class="line10"></div>

        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">吐槽信息</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <!--/导航栏-->
        <div class="tab-content">
            <div>
                <dl>
                    <dt>悬赏</dt>
                    <dd>
                        <label runat="server" id="lblPoint"></label>
                        积分</dd>
                </dl>
                <dl>
                    <dt>标题</dt>
                    <dd>
                        <label runat="server" id="lblTitle"></label>
                    </dd>
                </dl>
                <dl>
                    <dt>内容</dt>
                    <dd>
                        <div runat="server" id="Dcontent"></div>
                    </dd>
                </dl>
            </div>
            <dl>
                <dt>最新评论:</dt>
            </dl>
            <dl>
                <dt></dt>
                <dd>
                    <div class="menu-list" style="position: absolute; bottom: 0px; right: 10px">
                        <div class="rule-single-select">
                            <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                </dd>
            </dl>


            <div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DataList runat="server" ID="dlReplyInfo" RepeatColumns="1" DataKeyField="Id" OnItemCommand="dlReplyInfo_ItemCommand" CellSpacing="10" Width="100%">
                            <ItemTemplate>

                                <table style="width: 100%; height: auto" class="altrowstable" id="alternatecolor">
                                    <tr>
                                        <td rowspan="3" style="width: 200px">
                                            <div style="width: 100%; height: 100%">
                                                <ul style="list-style-type: none; padding-left: 0px; margin-left: 5px; margin-top: 5px">
                                                    <li>
                                                        <img src='<%#string.IsNullOrEmpty(Eval("Avatar").ToString().Replace("\\","/").Replace("~",".."))?"../../Web/CSS/avatar/239.png":Eval("Avatar").ToString().Replace("\\","/").Replace("~","..") %>' height="100px" width="100px " />
                                                    </li>
                                                    <li>用户名：<%#Eval("NickName") %></li>
                                                    <li>LV.<%#int.Parse(Eval("GroupID").ToString())+1  %>：<%#Enum.GetName(typeof(EnumsHelper.ForumLevel),int.Parse(Eval("GroupID").ToString())) %></li>
                                                </ul>
                                            </div>
                                        </td>
                                        <td style="height: 20px">
                                            <div style="position: relative">
                                                回复于：<%# Eval("CreateTime")%>
                                                <div style="position: absolute; right: 10px; top: 1px">
                                                    #<%#Eval("Floor") %>&nbsp; 得分：<%#Eval("Score") %>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-top: 5px">
                                            <div class="content">
                                                <%# Convert.ToInt32(Eval("IsVis"))==0?"此评论已被删除！":Eval("Content") %>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 40px">
                                            <div style="position: relative; height: 100%">
                                                <%#  Convert.ToString(Eval("FL"))==""? "":"引用第"+ Eval("FL")+"楼的回复！" %>
                                                <div style="position: absolute; bottom: 0px; height: auto; right: 0px;">
                                                    <asp:Button Text="删除" ID="lbtnDel" CssClass="btn" CommandName="Delete" Visible='<%#(Convert.ToInt32(Eval("IsVis"))==0?false:true) %>' OnClientClick="return confirm('确认删除？');" runat="server" />
                                                    <asp:Button Text="悬赏" CssClass="btn" Visible='<%#(Convert.ToInt32(Eval("Score"))==0?true:false) %>' ID="lbtnReward" CommandName="Reward" runat="server" />
                                                    <asp:TextBox runat="server" ID="txtReward" CssClass="input normal" Visible="false" />
                                                    <asp:Button Text="确定" ID="btnOk" CommandName="btnOk" CssClass="btn" Visible="false" runat="server" />
                                                    <asp:Button Text="取消" ID="btnCancel" CommandName="btnCancel" CssClass="btn" Visible="false" runat="server" />
                                                </div>
                                                <div style="position: absolute; bottom: 0px; height: auto; left: 0px;">
                                                    <a href="#txtContent" id='<%#Eval("Id")%>' name="<%#Eval("NickName") %>" onclick="focuss(this)">快速回复</a>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>

                                <br />
                            </ItemTemplate>
                            <FooterTemplate>
                                <%#dlReplyInfo.Items.Count == 0 ? "<table><tr><td align=\"center\" colspan=\"8\">暂无记录</td></tr></table>" : ""%>
                            </FooterTemplate>
                        </asp:DataList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="line20"></div>
            <div class="pagelist">
                <div class="l-btns">
                    <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);"
                        OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
                </div>
                <div id="PageContent" runat="server" class="default"></div>
            </div>

            <div style="width: 100%; position: relative;">
                <div class="Img" style="float: left; display: inline; width: 10%">
                    <img style="height: 100px; width: 100px;" id="UserAvator" runat="server" />
                </div>
                <div style="float: left; width: 80%">
                    <a name="txtContent"></a>
                    <%--<textarea runat="server" name="txtContent" id="txtContent" style="width: 100%; height: 100px; visibility: hidden;">来说两句吧。。。</textarea>--%>
                    <textarea runat="server" id="txtContent" name="txtContent" cssclass="input normal" datatype="*" style="height: 200px; width: 100%">来说点什么吧</textarea><span class="">*发表</span>
                    <script type="text/javascript">
                        var ue = UE.getEditor('txtContent', {
                            toolbars: [
                                ['fullscreen', 'simpleupload', 'insertimage', 'justifyleft', 'justifyright', 'justifycenter', 'forecolor', 'imagecenter']
                            ],
                            autoHeightEnabled: true,
                            autoFloatEnabled: true
                        });
                    </script>
                </div>
                <div style="float: left; width: 9%; position: absolute; right: 0px">
                    <input type="text" id="txtId" hidden="hidden" runat="server" />
                    <asp:Button Text="发表" runat="server" ID="btnReply" CssClass="btn" OnClick="btnSubmit_Click" />
                </div>
            </div>
        </div>
        <!--内容底部-->
    </form>
</body>
</html>
