<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HN863Soft.ISS.Web.User.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>登录页面</title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>
                    用户名：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtUserId" MaxLength="20" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUserValidate" runat="server" ControlToValidate="txtUserId" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    密码：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPassWord" MaxLength="16" TextMode="Password" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="rfvPassWordValidate" ControlToValidate="txtPassWord" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td> <asp:Button runat="server" ID="btnLogin" Text="登录" OnClick="btnLogin_Click" /></td>
                <td> <a href="Register.aspx">注册</a></td>
                <%--<asp:Button runat="server" ID="btnRegister" Text="注册" OnClick="btnRegister_Click" />--%>
            </tr>
     
        </table>
    </form>
</body>
</html>

