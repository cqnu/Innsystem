<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EntShow.aspx.cs" Inherits="HN863Soft.ISS.Web.Web.Entrepreneurship.EntShow" %>
<%@ Import Namespace="HN863Soft.ISS.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="EntAdd.aspx">发布疑问</a>
            <div>
                <asp:DataList runat="server" ID="dlEntShow" RepeatColumns="5" DataKeyField="Id"  CellSpacing="10">
                    <ItemTemplate>
                        <%--<a href="ServiceDetail.aspx"></a>--%>
                        <div style="width: 200px; height: 200px; position: relative; background-color: #f2f2f2" onmouseover="this.style.backgroundColor='#f0fff0'" onmouseout="this.style.backgroundColor='#f2f2f2'">
                            <a href="EntDetail.aspx?Id=<%#Eval("Id") %>">
                                <div style="position: absolute; top: 40px; left: 5px" >
                                    <img src="#" /><%//图片 %>
                                </div>
                                <div id="header" style="position: absolute; overflow: hidden ; height:50%;width:50%; top: 60px; left: 95px;"><%#Eval("Title") %></div>
                            </a>
                        </div>

                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </form>
</body>
</html>