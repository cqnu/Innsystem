<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Examine.aspx.cs" Inherits="HN863Soft.ISS.Web.Manage.TechnicalInformation.Examine" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:RadioButtonList RepeatDirection="Horizontal" ID="RadioButtonList1" runat="server" Width="239px" >
                <asp:ListItem Text="批准" Value="Yes">
                </asp:ListItem>
                <asp:ListItem Text="拒绝" Value="No"></asp:ListItem>
            </asp:RadioButtonList>
            <textarea id="traDescribe" maxlength="200" runat="server"></textarea>
        
        </div>
        <div>
            <asp:Button OnClick="Unnamed_Click"   runat="server" Text="确认"/>
        </div>
    </form>
</body>
</html>
