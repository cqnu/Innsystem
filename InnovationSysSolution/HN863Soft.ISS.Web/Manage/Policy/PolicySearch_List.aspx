<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PolicySearch_List.aspx.cs" Inherits="HN863Soft.ISS.Web.Manage.Policy.PolicySearch_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>添加公告</title>
    <link href="../JS/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>

    <script type="text/javascript" src="../JS/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/common.js"></script>

    <script src="../JS/FunctionJS.js"></script>
    <link href="../css/pagination.css" rel="stylesheet" />

</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">政策检索</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">

            <dl>
                <dt>关键词：</dt>
                <dd>
                    <asp:TextBox ID="txtKeywords" Width="100%" Height="25px" runat="server" CssClass="keyword" />

                </dd>
            </dl>
            <dl>
                <dt></dt>
                <dd>
                    <div style="text-align: center">
                        <asp:Button runat="server" CssClass="btn-search" OnClick="btnSearch_Click" Text="开始检索" Width="134px" />
                    </div>
                </dd>
            </dl>
        </div>
        <div style="width: 100%; text-align: left">

            <asp:DataList ID="DataList1" runat="server" RepeatColumns="1" CellSpacing="10" Width="100%">

                <ItemTemplate>
                    <a target="_blank" href='Policy_Show.aspx?id=<%#Eval("id") %>' style="width: 100%; font-size: x-large"><%#wsp(Eval("Title").ToString())%></a>
                    <div style="height: 10px"></div>
                    <div><%#Eval("CrawContent").ToString().Length>180?Eval("CrawContent").ToString().Substring(0,180)+"...":Eval("CrawContent")%></div>
                    <div style="height: 5px"></div>
                    <div style="color: #008000"><%#Eval("Date") %></div>
                    <div style="height: 5px"></div>
                </ItemTemplate>
                <FooterTemplate>
                    <%#DataList1.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\">暂无记录</td></tr>" : ""%>
                </FooterTemplate>
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
