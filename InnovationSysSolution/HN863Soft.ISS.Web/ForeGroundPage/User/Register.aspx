<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="HN863Soft.ISS.Web.ForeGroundPage.User.Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户注册</title>
    <style type="text/css">
        .lbl {
            text-align: right;
        }
        td {
            padding:4px 7px 2px 4px;
        }
        table {
            margin:auto 20%;
        }

        .btn {
            text-align: center;
        }
    </style>
</head>
<body style="align-content: center">
    <form id="form1" runat="server">
        <table >
            <tr>
                <td class="lbl">用户名：</td>
                <td>
                    
                    <asp:TextBox runat="server" ID="txtUserName" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="*" ControlToValidate="txtUserName"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="regx" ControlToValidate="txtUserName" runat="server" ValidationExpression="[a-zA-Z0-9]{6,12}" ErrorMessage="6~12位字母、数字组成的字符串"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="lbl">密码：</td>
                <td>
                    <asp:TextBox runat="server" ID="txtPassWordChar" TextMode="Password" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtPassWordChar"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="lbl">确认密码：</td>
                <td>
                    <asp:TextBox runat="server" ID="txtPassWordCharRe" TextMode="Password" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv" runat="server" ErrorMessage="*" ControlToValidate="txtPassWordCharRe"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvPassValidate" runat="server" ControlToValidate="txtPassWordCharRe" ControlToCompare="txtPassWordChar" ErrorMessage="密码不匹配"></asp:CompareValidator></td>
            </tr>
            <tr>
                <td class="lbl">联系电话：</td>
                <td>
                    <asp:TextBox runat="server" ID="txtPhone" Width="150px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="lbl">邮箱：</td>
                <td>
                    <asp:TextBox runat="server" ID="txtEMail" Width="150px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="lbl">账户类型：</td>
                <td>
                    <asp:RadioButtonList runat="server" ID="rblUserType" BorderStyle="None" OnSelectedIndexChanged="rblUserType_SelectedIndexChanged" AutoPostBack="true" RepeatLayout="Flow" Height="41px" Width="58px">
                        <asp:ListItem Selected="true" Value="0">组织</asp:ListItem>
                        <asp:ListItem Value="1">个人</asp:ListItem>
                    </asp:RadioButtonList></td>
                <% if (rblUserType.SelectedValue == "0")
                   {%>
            </tr>
            <%--组织--%>
            <tr>
                <td class="lbl">真实姓名：</td>
                <td>
                    <asp:TextBox runat="server" ID="txtRealName" Width="150px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="lbl">角色类型：</td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlRoleType"></asp:DropDownList></td>
            </tr>
            <%}
                   else
                   { %>
            <%--非组织--%>
            <tr>
                <td class="lbl">昵称：</td>
                <td>
                    <asp:TextBox runat="server" ID="txtNickName" Width="150px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="lbl">性别：</td>
                <td>
                    <asp:RadioButtonList runat="server" ID="rblSex" BorderStyle="None" RepeatLayout="Table">
                        <asp:ListItem Selected="True" Value="0">男</asp:ListItem>
                        <asp:ListItem Value="1">女</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="lbl">出生日期：</td>
                <td></td>
            </tr>
            <tr>
                <td class="lbl">区域：</td>
                <td>
                    <asp:TextBox runat="server" ID="txtArea" Width="150px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="lbl">住址：</td>
                <td>
                    <asp:TextBox runat="server" ID="txtAddress" Width="150px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="lbl">QQ：</td>
                <td>
                    <asp:TextBox runat="server" ID="txtQQ" Width="150px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="lbl">MSN：</td>
                <td>
                    <asp:TextBox runat="server" ID="txtMSN" Width="150px"></asp:TextBox></td>
            </tr>
            <%} %>
            <tr>
                <td></td>
                <td  class="btn" style="text-align:left">
                    <asp:Button ID="btnSubmit" runat="server" Text="立即注册" OnClick="btnSubmit_Click" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
