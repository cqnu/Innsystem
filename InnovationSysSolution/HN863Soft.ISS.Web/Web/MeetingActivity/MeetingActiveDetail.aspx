<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeetingActiveDetail.aspx.cs" Inherits="HN863Soft.ISS.Web.Web.MeetingActivity.MeetingActiveDetail" ValidateRequest="false" %>

<%@ Import Namespace="HN863Soft.ISS.Common" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>查看难题信息</title>
    <link rel="stylesheet" type="text/css" href="../skin_v2/CssF/css/responsive.min.css" />
    <link rel="stylesheet" type="text/css" href="../skin_v2/CssF/css/font-awesome.min.css">
    <%--    <link rel="stylesheet" type="text/css" href="../skin_v2/CssF/css/global.css" />--%>
    <link rel="stylesheet" type="text/css" href="../skin_v2/CssF/css/page.css" />
    <link rel="stylesheet" type="text/css" href="../skin_v2/CssF/css/topic.css" />

    <script src="../skin_v2/js/jquery.js"></script>
    <script src="../skin_v2/js/bootstrap.min.js"></script>

    <script src="../skin_v2/js/niuge.confirm.js"></script>
    <script src="../User/resources/js/jquery.cookie.js"></script>

    <link href="../skin_v2/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../CSS/tutor.css" rel="stylesheet" />
    <link href="../CSS/Show/base.css" rel="stylesheet" />
    <link href="../CSS/font-awesome.min.css" rel="stylesheet" />
    <link href="../CSS/Heard/css.css" rel="stylesheet" />
    <%--    <link href="../JS/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />--%>
    <%--    <script type="text/javascript" src="../../Scripts/jquery/jquery-1.11.2.min.js"></script>--%>
    <%-- <link href="../../JS/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />--%>
    <%--    <script type="text/javascript" src="../../JS/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../JS/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../JS/common.js"></scr--%>--%>
    <script src="../../Manage/JS/artDialog/artDialog.source.js" type="text/javascript"></script>
    <link href="../../Manage/JS/artDialog/skins/blue.css" rel="stylesheet" type="text/css" />
    <script src="../../Manage/JS/FunctionJS.js"></script>

    <script src="../../Ueditor/ueditor.config.js"></script>
    <script src="../../Ueditor/ueditor.all.min.js"></script>
    <script src="../../Ueditor/lang/zh-cn/zh-cn.js"></script>

    <script type="text/javascript" src="../skin_v2/js/responsive.min.js"></script>
    <script src="../skin_v2/js/global.js"></script>
    <link rel="stylesheet" type="text/css" href="../skin_v2/css/global.css" />
    <script type="text/javascript">
        $(function () {
            //$("#form1").initValidform();
            $(".niui-content").click(function () {
                $(this).addClass("blue");
                $(this).siblings().remove();
            })
        });

        //回复人
        function focuss(values) {
            var depremark = $(values).attr("Id")
            var name = $(values).attr("name");
            $("#txtContent").val(name);
            $("#txtId").val(depremark);//主键Id
            ue.setContent("@" + name);
        }
    </script>
    <style>
        .showDIV {
            display: block;
        }

        .hideDIV {
            display: none;
        }

        .content Img {
            width: 100%;
            height: auto;
        }

        .mainInnerBox {
            width: 1042px;
            margin: 0px auto;
            display: block;
            font-size: inherit;
        }

        .pagelist {
            clear: both;
            display: block;
            margin: 0 0 20px 1px;
        }

            .pagelist:after {
                clear: both;
                content: ".";
                display: block;
                height: 0;
                visibility: hidden;
            }

            .pagelist .l-btns {
                display: block;
                float: left;
                margin: 2px 5px 0 -1px;
                padding: 0 10px;
                border: 1px solid #dbdbdb;
                height: 28px;
                overflow: hidden;
            }

                .pagelist .l-btns span {
                    font-size: 12px;
                    color: #333;
                    line-height: 28px;
                }

                .pagelist .l-btns .pagenum {
                    display: inline-block;
                    margin: 0 5px;
                    padding: 0 5px;
                    border: 1px solid #dbdbdb;
                    border-top: 0;
                    border-bottom: 0;
                    width: 30px;
                    height: 28px;
                    line-height: 28px;
                    font-size: 12px;
                    color: #333;
                    text-align: center;
                    vertical-align: top;
                    overflow: hidden;
                }
        /*css default style pagination*/
        div.default {
            margin: 0;
            padding: 0;
            font-family: "Microsoft YaHei",Verdana;
            font-size: 12px;
        }

            div.default a, div.default span {
                display: block;
                float: left;
                margin: 2px 0 0 -1px;
                padding: 0px 12px;
                line-height: 28px;
                height: 28px;
                border: 1px solid #e1e1e1;
                background: #fff;
                color: #333;
                text-decoration: none;
            }

                div.default span:first-child {
                    border-left: 1px solid #e1e1e1;
                }

                div.default a:hover {
                    color: #666;
                    background: #eee;
                }

                div.default span.current {
                    color: #fff;
                    background: #488FCD;
                    border-color: #488FCD;
                }

                div.default span.disabled {
                    color: #999;
                    background: #fff;
                }

        .inputPoint {
            padding: 5px 4px;
            min-height: 32px;
            line-height: 20px;
            border: 1px solid #eee;
            background: #fff;
            vertical-align: middle;
            color: #333;
            font-size: 100%;
            box-sizing: border-box;
            -moz-box-sizing: border-box;
            -webkit-box-sizing: border-box;
            *min-height: 20px;
        }

        .btnOk {
            background: #16a0d3;
            border: none;
            color: #fff;
            cursor: pointer;
            display: inline-block;
            font-family: "Microsoft Yahei";
            font-size: 12px;
            height: 32px;
            line-height: 32px;
            margin: 0 1px 0 0;
            padding: 0 20px;
        }
    </style>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <div class="header">
            <div style="width: 1080px; margin: 0 auto;">
                <div style="float: left; margin: 6px 10px 0 0;">
                    <img src="../../Manage/skin/default/logo.png" style="width: 220px;" />
                </div>
                <ul class="menu" style="float: left;">
                    <li><a href="../index.html">主页</a></li>
                    <li><a href="#">投融资服务</a>
                        <ul class="submenu">
                            <li><a href="../ProjectFinancing/ProjectFinancing_List.aspx">众筹</a></li>

                            <li><a href="../Roadshow/Roadshow_List.aspx">路演</a></li>
                        </ul>
                    </li>
                    <li class="active on"><a href="#s2">工商财税</a>
                        <ul class="submenu">
                            <li><a href="../EnterpriseRegistration/EnterpriseRegistration_List.aspx">工商注册</a></li>
                            <li><a href="../Fiscal/Fiscal_List.aspx">财税服务</a></li>
                            <li><a href="../Intellectual/Intellectual_List.aspx">知识产权</a></li>
                        </ul>
                    </li>
                    <li><a href="#">专业技术服务</a>
                        <ul class="submenu">
                            <li><a href="../Ariticle/Ariticle_List.aspx">工业设计</a></li>
                            <li><a href='../SoftWareS/List.aspx?TypeName=<%=EnumsHelper.SoftType.SoftwareServiceType.ToString() %>'>软件服务</a></li>
                            <li><a href='../SoftWareS/List.aspx?TypeName=<%=EnumsHelper.SoftType.HSEConsulting.ToString() %>'><%#EnumsHelper.FetchDescription(EnumsHelper.SoftType.HSEConsulting) %>高企认定咨询</a></li>
                            <li><a href='../SoftWareS/List.aspx?TypeName=<%=EnumsHelper.SoftType.SoftConsulting.ToString() %>'><%#EnumsHelper.FetchDescription(EnumsHelper.SoftType.SoftConsulting) %>双软认定咨询</a></li>
                            <li><a href="../TalentService/TalentService_List.aspx">人才服务</a></li>
                        </ul>
                    </li>
                    <li><a href="../EnterIncubating/EIIndex.aspx">孵化器</a></li>
                    <li><a href="../MeetingActivity/MeetingActiveList.aspx" class="selected">难题吐槽 </a></li>
                    <li><a href="../PolicyHall/PHList.aspx">政策大厅 </a></li>

                </ul>
                <div class="header-right" id="min-nav">
                    <div class="login-register" id="min-zhuce" style="display: none">
                        <a class="nav-btn-login" href="javascript:">登录</a>
                        <a class="nav-btn-reg" href="/Web/User/NewRegister.html" target="_blank">注册</a>
                    </div>
                    <div class="login-register" style="display: none" id="web">

                        <div class="dropdown">

                            <a id="aName" href="" class="dropdown-toggle top-avatar" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" style="float: right; text-align: center;">您好：
                                &nbsp;&nbsp;	  	
			  </a>
                            <ul class="dropdown-menu" aria-labelledby="dropdownMenu1">
                                <li id="liManage" style="display: none"><a href="../../Manage/index.aspx">后台管理</a></li>
                                <li><a href="../User/ModifyPassword.html">修改密码</a></li>
                                <li><a href="javascript:void(0)" onclick='delCookie()'>注销登录</a></li>

                            </ul>
                        </div>
                        <script>
                            $.ajax({
                                url: "../../WebService/JudgeSess.ashx?state=0",
                                type: "post",

                                dataType: "text",
                                async: false,
                                success: function (data) {
                                    var a = data;

                                    if (a == "") {
                                        $("#min-zhuce").show();
                                        $("#web").hide();
                                    }
                                    else {
                                        $("#min-zhuce").hide();
                                        $("#web").show();
                                        $("#aName").text("欢迎您：" + a);
                                    }

                                }
                            })

                            $.ajax({
                                url: "../../WebService/JudgeSess.ashx?state=2",
                                type: "post",
                                dataType: "text",
                                async: false,
                                success: function (data) {
                                    var a = data;
                                    if (a == "") {

                                        $("#liManage").hide();
                                    }
                                    else {

                                        $("#liManage").show();

                                    }

                                }
                            })


                            function delCookie() {

                                var a = 0;

                                $.ajax({
                                    url: "../../WebService/JudgeSess.ashx?state=1",
                                    type: "post",

                                    dataType: "text",
                                    async: false,
                                    success: function (data) {
                                        var a = data;
                                        if (a == "0") {
                                            location.reload();
                                        }


                                    }
                                })

                            }

                        </script>
                    </div>
                </div>
            </div>
        </div>

        <div class="row niui-content-1" style="margin-top: 70px;">
            <div class="niui-w">
                <div class="art">
                    <div class="art-head">
                        <p id="pTitle" runat="server"></p>
                        <div class="art-head-tag">
                            <span id="sType" runat="server">其他</span>
                            <br />
                            <br />
                        </div>
                        <div class="art-head-tag">悬赏积分:<span id="SReward" runat="server"></span></div>
                    </div>
                    <div class="art-co">
                        <input type="hidden" name="" class="iszan" value="0">
                        <div class="art-img">
                            <img src="#" id="authorImg" alt="" runat="server">
                        </div>
                        <div class="art-txt">
                            <div class="art-title">
                                <div class="fl" style="width: 800px">
                                    <div class="art-time">
                                        <b>&nbsp;&nbsp;</b>
                                        发起话题于 &nbsp;&nbsp;<span id="sCreateTime" runat="server"></span>
                                    </div>
                                    <div class="art-author">
                                    </div>
                                </div>

                                <div class="fr" style="width: 100px;">
                                </div>

                            </div>
                            <div class="art-article" runat="server" id="DContent">
                            </div>
                        </div>
                    </div>

                </div>

                <div class="total-info">
                    <span id="total-comment">
                        <label runat="server" id="total"></label>
                    </span>个评论 
                </div>
                <asp:ScriptManager runat="server" />
                <asp:UpdatePanel ID="datalist" runat="server">
                    <ContentTemplate>
                        <!-- art list -->
                        <div class="art-list">
                            <ul id="Ul1">
                                <asp:Repeater ID="dlReplyInfo" runat="server" OnItemCommand="dlReplyInfo_ItemCommand">
                                    <ItemTemplate>
                                        <li class="art-lo art-lo-my">
                                            <table class="altrowstable" id="alternatecolor" style="width: 100%; height: 100%;">
                                                <tr style="width: 100%; height: 20px;">
                                                    <td rowspan="3" style="width: 20%;">
                                                        <div>
                                                            <ul style="list-style-type: none; padding-top: 10px; text-align: center; display: block;">
                                                                <li>
                                                                    <img src='<%#string.IsNullOrEmpty(Eval("Avatar").ToString().Replace("\\","/").Replace("~",".."))?"../CSS/avatar/239.png":Eval("Avatar").ToString().Replace("\\","/").Replace("~","..") %>' height="100px" width="100px " />
                                                                </li>
                                                                <li>用户名：<%#Eval("NickName") %>
                                                                </li>
                                                                <li>LV.<%#int.Parse(Eval("GroupID").ToString())+1 %>：<%#Enum.GetName(typeof(EnumsHelper.ForumLevel),int.Parse(Eval("GroupID").ToString())) %></li>
                                                            </ul>
                                                        </div>
                                                    </td>
                                                    <td style="width: 100%; height: 20px; display: block; margin-top: 10px;">
                                                        <div style="width: 100%; height: 100%; display: inline-block;">
                                                            回复于：<%# Eval("CreateTime")%>
                                                            <div style="display: inline-block; margin-right: 40px; float: right;">
                                                                #<%#Eval("Floor") %>&nbsp; 得分：<%#Eval("Score") %>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100%; display: inline-block; margin-top: 10px;">
                                                        <div style="width: 100%; display: inline-block; overflow-x: auto;" class="content">
                                                            <%# Convert.ToInt32(Eval("IsVis"))==0?"此评论已被删除！":Eval("Content") %>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr style="width: 100%; height: 20px;">
                                                    <td style="width: 100%; height: 20px;">
                                                        <div style="width: 100%; height: 100%; display: inline-block;">
                                                            <%#  Convert.ToString(Eval("FL"))==""? "":"引用第"+ Eval("FL")+"楼的回复！" %>
                                                            <div style="display: inline-block; margin-right: 40px; float: right;">
                                                                <% if (isCreator)
                                                                   { %>
                                                                <asp:Panel runat="server" ID="PReward" Style="float: left;" Visible="false">
                                                                    <asp:TextBox runat="server" Style="width: 60px;" CssClass="inputPoint" ID="txtReward" />
                                                                    &nbsp;&nbsp;
                                                            <asp:Button Text="确定" runat="server" CssClass="btnOk" ID="btnOk" CommandName="btnOk" CommandArgument='<%#Eval("Id")%>' />
                                                                    &nbsp;&nbsp;
                                                                </asp:Panel>
                                                                <asp:LinkButton Text="悬赏" ID="RewardBtn" CommandName="Reward" Visible='<%#(Convert.ToInt32(Eval("Score"))>0||Convert.ToInt32(Eval("IsVis"))==0)?false:true %>' runat="server" />
                                                                &nbsp;&nbsp;
                                                        <asp:LinkButton Text="删除" ID="DelBtn" CommandName="Del" CommandArgument='<%#Eval("Id")%>' Visible='<%#Convert.ToInt32(Eval("IsVis"))==0?false:true %>' runat="server" />
                                                                &nbsp;&nbsp;&nbsp;&nbsp;

                                                        <%} %>

                                                                <%if (isLogin)
                                                                  { %>
                                                                <a href="#txtContent" id='<%#Eval("Id")%>' style="text-decoration: underline;" name='<%#Eval("NickName") %>' onclick="focuss(this)">快速回复</a>
                                                                <%} %>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                            <!-- 分页 -->
                            <div class="pur-footer sw-mod-pagination" id="Pagination">
                            </div>
                        </div>

                        <div class="line20"></div>
                        <div style="text-align: center" class="mainInnerBox">
                            <div class="pagelist">
                                <div class="l-btns">
                                    <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);"
                                        OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
                                </div>
                                <div id="PageContent" runat="server" class="default"></div>
                            </div>
                        </div>

                        <div class="art-bo-relay">
                            <div class="art-lo art-lo-active" id="Dreply" runat="server">
                                <div class="art-img">
                                    <img src="#" alt="" id="userImg" runat="server">
                                    <div class="art-btn-zan btn-zan btn-zan-active">
                                    </div>
                                </div>

                                <div class="arc-list-co">
                                    <div class="art-author" id="DName" runat="server"></div>
                                    <div class="art-list-co2">
                                        <div class="art-list-value" style="border: 0; height: auto;">
                                            <a name="txtContent"></a>
                                            <textarea runat="server" id="txtContent" name="txtContent" style="height: 200px; width: 798px"></textarea>
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
                                        <div class="art-value-btn">
                                            <asp:Button Text="提交评论" CssClass="art-bo-save" ID="btnReply" OnClick="btnSubmit_Click" runat="server" />
                                        </div>
                                        <input type="text" id="txtId" hidden="hidden" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="footer">
            <div class="footer-main niui-w">
                <div class="footer-main-left">
                    <dl>
                        <dt>关于</dt>
                        <dd><a href="../About.html" target="_blank">公司简介</a></dd>
                        <dd><a href="../ServiceTerms.html" target="_blank">服务条款</a></dd>
                    </dl>
                    <dl>
                        <dt>专业技术服务</dt>
                        <dd><a href="../Ariticle/Ariticle_List.aspx">工业设计</a></dd>
                        <dd><a href="../SoftWareS/List.aspx?TypeName=SoftwareServiceType ">软件服务</a></dd>
                        <dd><a href="../SoftWareS/List.aspx?TypeName=HSEConsulting ">高企认定咨询</a></dd>
                        <dd><a href="../SoftWareS/List.aspx?TypeName=SoftConsulting ">双软认定咨询</a></dd>
                        <dd><a href="../TalentService/TalentService_List.aspx">人才服务</a></dd>
                    </dl>
                    <dl>
                        <dt>工商财税</dt>
                        <dd><a href="../EnterpriseRegistration/EnterpriseRegistration_List.aspx">工商注册</a></dd>
                        <dd><a href="../Fiscal/Fiscal_List.aspx">财税服务</a></dd>
                        <dd><a href="../Intellectual/Intellectual_List.aspx">知识产权</a></dd>
                    </dl>
                    <dl>
                        <dt>孵化器</dt>
                        <dd><a href="../EnterIncubating/EIIndex.aspx">孵化器</a></dd>
                    </dl>
                    <dl>
                        <dt>难题吐槽</dt>
                        <dd><a href="../MeetingActivity/MeetingActiveList.aspx">难题吐槽</a></dd>
                    </dl>
                    <dl>
                        <dt>政策大厅</dt>
                        <dd><a href="../PolicyHall/PHList.aspx">政策大厅</a></dd>
                    </dl>
                    <dl style="width: 28%;">
                        <dt>联系</dt>
                        <dd class="consult" style="border-bottom: 1px #eee solid; margin-right: 50px; margin-bottom: 10px;">
                            <span style="font-size: 14px; font-weight: 600; color: #464646;"><i class="glyphicon glyphicon-earphone" style="color: #717171; font-weight: 400;"></i>&nbsp;电话：</span>
                            <span style="font-size: 16px; font-weight: 600; color: #6eb92b;">0371-67579123</span>
                        </dd>
                        <dd class="consult"><span><i class="glyphicon glyphicon-print"></i>&nbsp;传真：</span><span style="">0371-67579123</span>

                        </dd>
                        <dd><span><i class="glyphicon glyphicon-envelope"></i>&nbsp;邮箱：</span><span class="">hnppc@163.com</span></dd>
                        <dd><span><i class="glyphicon glyphicon-map-marker"></i>&nbsp;地址：</span><span class="">郑州市高新技术开发区翠竹街6号国家863中部软件园</span></dd>
                    </dl>
                </div>
            </div>
        </div>
    </form>
    <!-- pop -->
    <div class="pop-layer"></div>
    <div class="pop-login">
        <div class="pop-close pop-login-close">
            <img src="../skin_v2/image/close.png" style="width: 26px; height: 26px" />
        </div>
        <h3>登录</h3>
        <div class="pop-login-co">
            <form class="form-login" name="form3" method="post">
                <label><span>用户名</span><input type="text" id="username" name="username" value="" placeholder="用户名"></label>
                <label><span>密码</span><input type="password" id="password" name="password" value="" placeholder="密码"></label>
                <div class="login-check">
                    <label>
                        <input type="checkbox" name="checkr" id="checkr" style="width: 16px; font-size: 14px" />记住我
                    </label>
                    <a href="/Web/User/RetrievePassword.html" target="_blank">忘记密码</a>
                </div>
                <div class="login-btn">登录</div>
                <div class="logup-btn">还没有平台帐号 <a href="/Web/User/NewRegister.html" target="_blank">立即注册</a></div>
            </form>
        </div>
    </div>
    <script src="../skin_v2/js/niuge.confirm.js"></script>
    <script>

        $().ready(function () {
            //获取cookie的值
            var username = $.cookie('username');
            var password = $.cookie('password');

            //将获取的值填充入输入框中
            $('#username').val(username);
            $('#password').val(password);
            if (username != null && username != '' && password != null && password != '') {//选中保存秘密的复选框
                $("#checkr").attr('checked', true);
            }
        })
    </script>
</body>
</html>
