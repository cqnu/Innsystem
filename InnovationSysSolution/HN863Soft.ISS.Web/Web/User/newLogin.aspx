<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newLogin.aspx.cs" Inherits="HN863Soft.ISS.Web.Web.User.newLogin" %>

<!DOCTYPE html>

<html>
<head>
    <title>注册</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <link rel="shortcut icon" href="resources/images/favicon.ico" />
    <link href="resources/style/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="resources/js/jquery.js"></script>
    <script type="text/javascript" src="resources/js/jquery.i18n.properties-1.0.9.js"></script>
    <script type="text/javascript" src="resources/js/jquery-ui-1.10.3.custom.js"></script>
    <script type="text/javascript" src="resources/js/jquery.validate.js"></script>
    <script type="text/javascript" src="resources/js/md5.js"></script>
    <script type="text/javascript" src="resources/js/page_regist.js?lang=zh"></script>
</head>
<body class="loginbody">
    <div class="dataEye">
        <div class="loginbox registbox">
            <div class="logo-a">
               <%-- <a href="login.jsp" title="js代码网">
                    <img src="resources/images/logo-a.png">
                </a>--%>
            </div>
            <div class="login-content reg-content">
                <div class="loginbox-title">
                    <h3>注册</h3>
                </div>
                <form id="signupForm">
                    <div class="login-error"></div>
                    <div class="row">
                        <!--  <label class="field" for="contact">类型</label>-->
                        <input type="checkbox" id="ch1" name="vehicle" value="0" checked="checked" onclick='chooseOne(this)'  />个人
                        <input type="checkbox" id="ch2" name="vehicle" value="1" onclick='chooseOne(this)' />组织
                      
                    </div>
  
                    <div class="row">
                        <label class="field" for="name">用户名</label>
                        <input type="text" value="" maxlength="20" onkeyup="value = value.replace(/[\u4e00-\u9fa5]/g, '')" class="input-text-user noPic input-click" name="name" id="name">
                    </div>
                    <div class="row">
                        <label class="field" for="password">密码</label>
                        <input type="password" value="" class="input-text-password noPic input-click" name="password" id="password">
                    </div>
                    <div class="row">
                        <label class="field" for="passwordAgain">确认密码</label>
                        <input type="password" value="" class="input-text-password noPic input-click" name="passwordAgain" id="passwordAgain">
                    </div>
                    <div class="row">
                        <label class="field" for="email">邮箱</label>
                        <input type="text" value="" maxlength="50" class="input-text-user noPic input-click" name="email" id="email">
                    </div>
                    <div class="row">
                        <label class="field" for="company">昵称</label>
                        <input type="text" value="" maxlength="20" class="input-text-user noPic input-click" name="company" id="company">
                    </div>



                    <div class="row tips">
                        <input type="checkbox" id="checkBox">
                        <label>
                            我已阅读并同意
				<a href="#" target="_blank">隐私政策、服务条款</a>
                        </label>
                    </div>
                    <div class="row btnArea">
                        <a class="login-btn"  id="submit">注册</a>
                    </div>
                </form>
            </div>
<%--            <div class="go-regist">
                已有帐号,请<a href="#" class="link">登录</a>
            </div>--%>
        </div>

        <div id="footer">
<%--            <div class="dblock">
                <div class="inline-block">
                    <img src="resources/images/logo-gray.png">
                </div>
                <div class="inline-block copyright">
                    <p><a href="#">关于我们</a> | <a href="#">微博</a> | <a href="#">隐私政策</a> | <a href="#">人员招聘</a></p>
                    <p>Copyright © 2013 JS代码网</p>
                </div>
            </div>--%>
        </div>
    </div>
    <div class="loading">
        <div class="mask">
            <div class="loading-img">
                <img src="resources/images/loading.gif" width="31" height="31">
            </div>
        </div>
    </div>
    <script>



        function chooseOne(chk) {
            //先取得同name的chekcBox的集合物件 
            var obj = document.getElementsByName("vehicle");
            for (i = 0; i < obj.length; i++) {
                //判斷obj集合中的i元素是否為cb，若否則表示未被點選 
                if (obj[i] != chk) obj[i].checked = false;
                    //若要至少勾選一個的話，則把上面那行else拿掉，換用下面那行 
                else obj[i].checked = true;
              
            }
        }
  

    </script>
</body>
</html>