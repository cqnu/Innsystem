<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinkPatent_Show.aspx.cs" Inherits="HN863Soft.ISS.Web.Manage.LinkPatent.LinkPatent_Show" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>专利商标查询管理</title>
    <link href="../JS/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../JS/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <!--工具栏-->
        <div id="floatHead" class="toolbar-wrap">
            <div class="toolbar">
                <div class="box-wrap">
                    <a class="menu-btn"></a>

                    <div class="r-list">
                        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <!--/工具栏-->


        <div class="table-container" style="width: 100%; height: 100%; text-align: center">

            <asp:DataList Width="100%" Height="100%" ID="DataList1" runat="server" RepeatColumns="3">

                <ItemTemplate>
                    <div style="width: 100%; height: 100%">
                        <a href='<%#Eval("SiteUrl") %>' target="_blank">
                            <table style="width: 350px; height: 180px; text-align: center" bgcolor="#FFFFFF"
                                onmouseover="this.style.borderColor='#00FF00';this.style.backgroundColor='#F8F8FF';"
                                onmouseout="this.style.borderColor='#FF0000';this.style.backgroundColor='#FFFFFF';">
                                <tr>
                                    <td style="text-align: left; width: 50px">
                                        <asp:ImageButton ID="Image1" runat="server" Height="50px" Width="80px"
                                            ImageUrl='<%#Eval("LogUrl") %>' />
                                    </td>
                                    <td style="text-align: left">
                                        <table>
                                            <tr>
                                                <td style="text-align: center">
                                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("SiteName") %>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left" >
                                        <%#Eval("SiteDescription") %>
                                        <%--<%#Eval("SiteDescription").ToString().Length>23?Eval("SiteDescription").ToString().Substring(0,23)+"...":Eval("SiteDescription")%>--%>
                                    </td>
                                </tr>
                            </table>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <!--内容底部-->
        <div class="line20"></div>
        <div class="pagelist">
            <div class="l-btns">
                <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);"
                    OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
            </div>
            <div id="PageContent" runat="server" class="default"></div>
        </div>
        <!--/内容底部-->
    </form>
</body>
</html>
