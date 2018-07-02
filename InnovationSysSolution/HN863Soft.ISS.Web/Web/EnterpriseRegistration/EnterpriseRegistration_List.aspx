<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnterpriseRegistration_List.aspx.cs" Inherits="HN863Soft.ISS.Web.Web.EnterpriseRegistration.EnterpriseRegistration_List" %>

<%@ Import Namespace="HN863Soft.ISS.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>工商注册列表</title>
    <link href="../CSS/tutor.css" rel="stylesheet" />
    <link href="../CSS/075164029c450604c632bc43bf813389.css" rel="stylesheet" />
    <link href="../CSS/font-awesome.min.css" rel="stylesheet" />

    <link href="../../Manage/skin/default/style.css" rel="stylesheet" />

    <script src="../skin_v2/js/jquery.js"></script>
    <script src="../skin_v2/js/bootstrap.min.js"></script>
    <script src="../Scripts/jquery-1.8.0.min.js"></script>
    <script src="../skin_v2/js/global.js"></script>
    <script src="../skin_v2/js/niuge.confirm.js"></script>
    <script src="../User/resources/js/jquery.cookie.js"></script>


    <link href="../../Manage/css/pagination.css" rel="stylesheet" />
    <link href="../skin_v2/css/bootstrap.min.css" rel="stylesheet" />
    <%--    <script src="../Scripts/jquery-1.8.0.min.js"></script>--%>
    <script src="../../Manage/JS/FunctionJS.js"></script>
    <script src="../../Manage/JS/laymain.js"></script>
    <script src="../../Manage/JS/common.js"></script>
    <link href="../CSS/Show/base.css" rel="stylesheet" />
    <link href="../CSS/2e48e8de0c96d4c87c57f954eb4d94c6.css" rel="stylesheet" />

    <script src="../Scripts/jquery.SuperSlide.2.1.1.js"></script>
    <link href="../CSS/Heard/css.css" rel="stylesheet" />

    <link rel="stylesheet" type="text/css" href="../skin_v2/css/global.css" />
    <script type="text/javascript" src="../skin_v2/js/responsive.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <div style="width: 1100px; margin: 0 auto;">
                <div style="float: left; margin: 6px 40px 0 0;">
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
                    <li class="active on"><a href="#s2" class="selected">工商财税</a>
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
                    <li><a href="../MeetingActivity/MeetingActiveList.aspx">难题吐槽 </a></li>
                    <li><a href="../PolicyHall/PHList.aspx">政策大厅 </a></li>

                </ul>
                <div class="header-right" id="min-nav">
                    <div class="login-register" id="min-zhuce" style="display: none">
                        <a class="nav-btn-login" href="javascript:">登录</a>
                        <a class="nav-btn-reg" href="/Web/User/NewRegister.html" target="_blank">注册</a>
                    </div>
                    <div class="login-register" style="display: none" id="web">

                        <div class="dropdown">

                            <a id="aName" href="" class="dropdown-toggle top-avatar" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" style="float: right; text-align: center">您好：
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

        <div class="row niui-content-1">

            <div class="listFilterBox">
                <div class="mainInnerBox">
                    <div class="listFilterItemWrap">
                        <div class="listFilterItemBox clearfix">
                            <label>排序方式:</label>
                            <div class="listFilterItemABox siteIlB_box">
                                <asp:LinkButton ID="Default" runat="server" CssClass="cur btn_ALink siteIlB_item" OnClick="Default_Click">默认</asp:LinkButton>
                                <asp:LinkButton ID="Reverse" runat="server" CssClass="btn_ALink siteIlB_item" OnClick="Reverse_Click">时间排序</asp:LinkButton>
                            </div>
                        </div>
                        <div class="search-box">
                            <div class="input-group">
                                <asp:TextBox ID="txtKeywords" runat="server" CssClass="form-control" />
                                <span class="input-group-btn">

                                    <asp:ImageButton runat="server" BorderColor="#cccccc" BackColor="White" CssClass="btn"  ImageUrl="~/Web/CSS/search.png" OnClick="btnSearch_Click" />
                                    <%--    <asp:LinkButton ID="LinkButton1" runat="server" icon="/CSS/search.png" CssClass="btn btn-default" OnClick="btnSearch_Click">查询</asp:LinkButton>--%>
                                </span>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

            <div style="text-align: center" class="mainInnerBox">
                <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="3">

                    <ItemTemplate>
                        <div class="pt-list">
                            <dl>
                                <dd>
                                    <a target="_blank" href='EnterpriseRegistration_Show.aspx?id=<%#Eval("id") %>'>

                                        <img style="width: 90px; height: 90px" src='<%#Eval("Cover")%>' />
                                    </a>
                                </dd>
                                <dt>
                                    <a target="_blank" href='EnterpriseRegistration_Show.aspx?id=<%#Eval("id") %>'>
                                        <h3 style="text-align: left"><%#Eval("Title").ToString().Length>12?Eval("Title").ToString().Substring(0,12)+"...":Eval("Title")%></h3>
                                        <p class="dt-div" style="width: 180px; text-align: left">
                                            综合评分
								
                                    <span class="tutor-data1-stars">
                                        <i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i><i class="fa fa-star"></i>
                                    </span>

                                        </p>

                                    </a>

                                </dt>
                            </dl>
                            <div class="pt-intro" style="text-align: left"><%#Eval("Introduce") %> </div>
                            <div class="siteIlB_box" style="text-align: right">

                                <a class="site_ALink siteIlB_item">
                                    <img src="../CSS/gjc.png" />
                                    <%#Eval("KeyWord") %> &nbsp
                                </a>
                            </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%#DataList1.Items.Count == 0 ? "<div class=\"mainInnerBox\"  ><div class=\"col-md-12\" style=\"text-align:center;margin-top:10px;background:#fff;height:40px;line-height:40px;color:#999;\">已无更多数据</div></div>" : ""%>
                    </FooterTemplate>
                </asp:DataList>
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

