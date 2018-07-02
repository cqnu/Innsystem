<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HN863Soft.ISS.Web.Manage.Login" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no">
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>三原色创孵平台后台登录</title>
    <link href="skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../scripts/jquery/jquery-1.11.2.min.js"></script>
    <link href="JS/artDialog/skins/blue.css" rel="stylesheet" type="text/css" />
    <script src="JS/artDialog/artDialog.source.js" type="text/javascript"></script>
    <script src="JS/FunctionJS.js"></script>

    <script type="text/javascript">
        $(function () {
            //检测IE
            if ('undefined' == typeof (document.body.style.maxHeight)) {
                window.location.href = 'ie6update.html';
            }
        });
    </script>
</head>

<body class="loginbody">
    <form id="form1" runat="server">
        <div style="width: 100%; height: 100%; min-width: 300px; min-height: 260px;"></div>
        <div class="login-wrap">
            <div></div>
            <div class="login-form">
                <div class="col">
                    <asp:TextBox ID="tbUserName" runat="server" CssClass="login-input" placeholder="用户账号" title="用户账号"></asp:TextBox>
                    <label class="icon user" for="txtUserName"></label>
                </div>
                <div class="col">
                    <asp:TextBox ID="tbPassword" runat="server" CssClass="login-input" TextMode="Password" placeholder="用户密码" title="用户密码"></asp:TextBox>
                    <label class="icon pwd" for="txtPassword"></label>
                </div>
                <div class="col">
                    <asp:TextBox id="tbCode" runat ="server" class="login-input" maxlength="4" type="text" placeholder="验证码" title="验证码" style="width: 130px; float: left;"></asp:TextBox>
                    <label class="icon pwd" for="txtUserName"></label>
                     <a id="A1"  href="javascript:changeYZM()" style="text-decoration: none;"> <img id="imgCode" class="authcode" src="ImageCodePage.aspx" width="100" height="42" /></a>
                </div>
                <div class="col">
                    <asp:Button ID="btnSubmit" runat="server" Text="登 录" CssClass="login-btn" OnClick="btnLogin_Click"/>
                </div>
            </div>
        </div>

        <div class="copy-right">
            <p>版权所有 河南省生产力促进中心 Copyright © 2017 Corporation, All Rights Reserved</p>
        </div>
    </form>
    <script type="text/javascript">
        $("#tbUserName").focus();

        function changeYZM() {
            $("#tbCode").val("");
            var t = new Date().getTime();
            $("#imgCode").attr("src", "ImageCodePage.aspx?t=" + t)
        }
    </script>
</body>
</html>


