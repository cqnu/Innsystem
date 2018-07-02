<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceMange.aspx.cs" Inherits="HN863Soft.ISS.Web.Service.ServiceMange.ServiceMange" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--<asp:Button runat="server" Text="新增服务" ID="btnAdd" OnClick="btnAdd_Click" />--%>

            <div>
                <asp:DataList runat="server" ID="dlService" RepeatColumns="5" DataKeyField="Id" OnItemCommand="dlService_DeleteCommand" CellSpacing="10">
                    <ItemTemplate>
                        <%--<a href="ServiceDetail.aspx"></a>--%>
                        <div style="width: 200px; height: 200px; position: relative; background-color: #f2f2f2" onmouseover="this.style.backgroundColor='#f0fff0'" onmouseout="this.style.backgroundColor='#f2f2f2'">
                            <div style="position: absolute; right: 0px; top: 0px">
                                <%--<img src="../../Css/Button%20Delete.png" height="20px" style="background-color: transparent" />--%>
                                <%--<asp:ImageButton ImageUrl="../../../Css/Button%20Delete.png" height="20px" CommandName="delete" OnClientClick="return confirm('确定删除？')" runat="server" />--%>
                            </div>
                            <a href="ServiceDetail.aspx?Id=<%#Eval("Id") %>">
                                <div style="position: absolute; top: 40px; left: 5px" >
                                    <img src="../../../Css/valid_icons.png" /><%//图片 %>
                                </div>
                                <div id="header" style="position: absolute; top: 60px; left: 95px;"><%#Eval("Title") %></div>
                            </a>
                        </div>

                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </form>
</body>
</html>
