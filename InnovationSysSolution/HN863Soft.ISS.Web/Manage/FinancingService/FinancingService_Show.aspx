<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="FinancingService_Show.aspx.cs" Inherits="HN863Soft.ISS.Web.Manage.FinancingService.FinancingService_Show" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <link href="../../scripts/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/common.js"></script>
    <script src="../JS/artDialog/artDialog.source.js" type="text/javascript"></script>
    <link href="../JS/artDialog/skins/blue.css" rel="stylesheet" type="text/css" />
    <script src="../JS/FunctionJS.js"></script>
    <link href="../css/pagination.css" rel="stylesheet" />
    <script src="../../Ueditor/ueditor.config.js"></script>
    <script src="../../Ueditor/ueditor.all.min.js"></script>
    <script src="../../Ueditor/lang/zh-cn/zh-cn.js"></script>
    <link href="../css/pagination.css" rel="stylesheet" />
    <style type="text/css">
        DIV {
            FONT-FAMILY: 宋体;
        }

        TD {
            FONT-FAMILY: 宋体;
        }

        TD {
            FONT-SIZE: 12px;
            LINE-HEIGHT: 18px;
        }

        .red {
            COLOR: #ff0000;
        }

        .fB {
            FONT-WEIGHT: bold;
        }

        .pad10L {
            PADDING-LEFT: 10px;
        }

        .g {
            COLOR: #666666;
        }

        .i {
            FONT-SIZE: 16px;
            FONT-FAMILY: arial;
        }

        A.top {
            FONT-FAMILY: arial;
        }

            A.top:link {
                COLOR: #0000cc;
                TEXT-DECORATION: underline;
            }

            A.top:visited {
                COLOR: #800080;
                TEXT-DECORATION: underline;
            }

            A.top:active {
                COLOR: #0000cc;
                TEXT-DECORATION: underline;
            }

        .c {
            COLOR: #7777cc;
        }

        A.c {
            COLOR: #7777cc;
        }

            A.c:visited {
                COLOR: #7777cc;
            }

        .ntb {
            WIDTH: 100%;
            LINE-HEIGHT: 20px;
            HEIGHT: 20px;
            BACKGROUND-COLOR: #0000cc;
        }

        .pg {
            FONT-SIZE: 14px;
            WORD-SPACING: 4px;
            WIDTH: 80%;
            LINE-HEIGHT: 30px;
            FONT-FAMILY: arial;
            HEIGHT: 30px;
            TEXT-ALIGN: center;
        }

        .pg {
            FONT-FAMILY: arial;
        }

            .pg FONT {
                FONT-SIZE: 16px;
            }

        .d {
            PADDING-LEFT: 10px;
        }

        .s {
            TABLE-LAYOUT: fixed;
            PADDING-LEFT: 10px;
            FONT-SIZE: 14px;
            WORD-BREAK: break-all;
        }

        .u {
            TABLE-LAYOUT: fixed;
            PADDING-LEFT: 10px;
            WORD-BREAK: break-all;
        }

        .BG3 {
            BORDER-RIGHT: #cccccc 1px solid;
            BORDER-TOP: #cccccc 1px solid;
            MARGIN-TOP: 10px;
            BORDER-LEFT: #cccccc 1px solid;
            BORDER-BOTTOM: #cccccc 1px solid;
        }

        .bgr3 {
            LINE-HEIGHT: 24px;
            HEIGHT: 24px;
            BACKGROUND-COLOR: #eeeeee;
        }

        .pad5L {
            PADDING-LEFT: 5px;
        }

        BODY {
            MARGIN: 0px;
        }

        FORM {
            MARGIN: 0px;
        }

        .usrbar {
            PADDING-RIGHT: 10px;
            MARGIN-TOP: 4px;
            FONT-SIZE: 12px;
            LINE-HEIGHT: 19px;
            FONT-FAMILY: Arial;
            HEIGHT: 19px;
            TEXT-ALIGN: right;
        }

        .hdch {
            MARGIN-TOP: 3px;
            FONT-SIZE: 14px;
            FONT-FAMILY: arial;
            HEIGHT: 21px;
        }

        .wlk {
            COLOR: #ffffff;
        }

        A.wlk {
            COLOR: #ffffff;
        }

            A.wlk:visited {
                COLOR: #ffffff;
            }

        .style3 {
            COLOR: #ffffff;
        }

        .gr {
            COLOR: #009933;
        }

        .stytle4 {
            color: #0000FF;
            font-size: 14px;
        }

        .stytle5 {
            font-size: 14px;
        }
    </style>
</head>
<body class="mainbody" >
  <form id="form1" runat="server">
                <!--导航栏-->
        <div class="location">
            <a href="FinancingService_List.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../Center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="FinancingService_List.aspx"><span>投融资服务列表</span></a>
            <i class="arrow"></i>
            <span>查看投融资服务</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->
        <table height="20" cellspacing="0" cellpadding="0" width="80%" bgcolor="#ffffff"
            border="0">
            <tbody>
                <tr>
                    <td class="pad10L">
                        <asp:DataList ID="datalist1" runat="server" RepeatDirection="Vertical" Width="98%">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td><span class="stytle4"><%# DataBinder.Eval(Container.DataItem,"title" )%></span></td>
                                    </tr>
                                    <tr>
                                        <td><span class="stytle5">
                                            <%--<asp:Label ID="LabContent" runat="server" Text='<%#Eval("content") %>'></asp:Label></span></td>--%>
                                            <div id="content" style="width: auto; height: auto"><%#Eval("content") %></div>
                                    </tr>
                                    <tr>
                                        <td>发布人:<asp:Label ID="LabAthor" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"username") %>'/>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem,"datatime" )%>
                                            &nbsp;&nbsp;&nbsp;<a href="#txt" id='<%#Eval("UserName") %>' name="<%#Eval("UserId") %>" "
                                                onclick="syn(this)">快速回复</a>
                                        </td>
                                       
                                      
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <SeparatorStyle BorderColor="Silver" />
                        </asp:DataList>

                        <asp:DataList ID="datalist2" OnItemDataBound="datalist2_ItemDataBound" runat="server" Width="98%" CellPadding="4" ForeColor="#333333" HorizontalAlign="Left" DataKeyField="id">
                            <ItemTemplate>
                                <table style="width: 98%">
                                    <tr>
                                    </tr>
                                    <tr>
                                        <td><span><%# DataBinder.Eval(Container.DataItem,"rowid") %> 楼</span></br></br></br>
                                            回帖人:<asp:Label ID="LabAthor" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"UserName") %>' />
                                        </td>
                                        <td><span class="stytle4"><%# DataBinder.Eval(Container.DataItem,"title" )%> </span></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td style="width: 80%"><span class="stytle5">

                                            <div id="divcontent" style="width: 100%; height: auto"><%#Eval("content") %> </div>

                                            <script type="text/javascript">
                                                var imgObj;
                                                for (i = 0; i < document.getElementById("datalist2").getElementsByTagName("img").length; i++) {
                                                    imgObj = document.getElementById("datalist2").getElementsByTagName("img")[i];
                                                    //建议只判断高度或者宽度其中一个，那样可以自动按比例缩放 
                                                    if (imgObj.width > 400) //判断图片的宽度 
                                                    {
                                                        imgObj.width = 400;
                                                        var link1 = document.createElement("a");
                                                        link1.href = imgObj.src; link1.target = "_blank"; link1.title = "点击放大";
                                                        imgObj.parentNode.insertBefore(link1, imgObj);
                                                        link1.appendChild(imgObj);
                                                    }
                                                    if (imgObj.height > 200) //判断图片的宽度 
                                                    {
                                                        imgObj.height = 200;
                                                    }
                                                }
                                            </script>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td id="tddel" style="text-align: right">&nbsp;&nbsp;回复于:<%# DataBinder.Eval(Container.DataItem,"datatime" )%>
                                            &nbsp;&nbsp;&nbsp;<a href="#sub" id='<%#Eval("UserName") %>' title="<%#Eval("id") %>" "  name="<%#Eval("UserId") %>"
                                                onclick="synchronous(this)">回复</a>
                                           <asp:LinkButton ID="linkdel"  runat="server" ValidationGroup='<%#Eval("id") %>'  OnClick="linkdel_Click" Text="删除" Visible='<%# Eval("flg").ToString()=="y"? true:false %>' ></asp:LinkButton>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <hr />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <AlternatingItemStyle BackColor="White" />
                            <ItemStyle BackColor="#EFF3FB" />
                            <SeparatorStyle BackColor="White" BorderColor="White" Font-Bold="False" Font-Italic="False"
                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        </asp:DataList></td>

                </tr>
            </tbody>
        </table>

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
        <div class="pg">
        </div>
        <table id="tb1" style="display:none" class="f9"  cellspacing="1" cellpadding="3" width="95%" align="center" border="0">
            <tbody>
                <tr>
                    <td width="6%" valign="top" nowap>标　题:</td>
                    <td width="93%">
                        <label>
                            <asp:Label ID="lblTitle" runat="server" Text="回复:发布人" Width="374px" />
                            <asp:HiddenField runat="server" ID="hid" />
                             <asp:HiddenField runat="server" ID="hid1"  />
                            <asp:HiddenField runat="server" ID="hid2"  />
                            <asp:HiddenField runat="server" ID="hid3"  />
                            <a name="sub"></a>
                        </label>
                        <a id="txt" name="txt"></a>
                    </td>

                </tr>
                <tr>
                    <td valign="top" nowap>回复内容:</td>
                    <td width="93%">&nbsp;
                        <textarea runat="server" id="container" name="content" style="height: 120px; width: 75%"></textarea>
                    </td>
                </tr>
                <tr>
                    <td nowap style="height: 42px">用户名:</td>
                    <td width="93%" style="height: 42px"><% if (Session["username"] == null)
                                                            {%><%Response.Write("匿名用户");%>&nbsp;<a href="Userlogin.aspx">登录</a>&nbsp;<a href="reg.aspx">注册</a><%} %>
                        <%else Response.Write(Session["username"].ToString());%></td>
                </tr>
                <tr>
                    <td valign="center" align="left" colspan="3">
                        <div id="yzm"></div>
                    </td>
                </tr>
                <tr>
                    <td valign="top"></td>
                    <td width="93%">
                        <asp:Button ID="ButTure" runat="server" Text="发表回复" OnClick="ButTure_Click" />
                        &nbsp;&nbsp;</td>
                    <td style="width: 13px">&nbsp;</td>
                </tr>
                <tr align="left">
                    <td valign="top" colspan="3"></td>
                </tr>
            </tbody>
        </table>
        <script type="text/javascript">
            window.onload = function () {

                var ue = UE.getEditor('container', {
                    toolbars: [
                        ['simpleupload', 'insertimage', 'justifyleft', 'justifyright', 'justifycenter', 'bold', 'underline ', 'forecolor', 'paragraph', 'fontfamily', 'fontsize', 'forecolor', 'imagecenter', 'spechars', 'emotion', 'insertvideo ', 'snapscreen', 'map']
                    ],
                    autoHeightEnabled: true,
                    autoFloatEnabled: true
                }
                                );


            }


            /*不停地轮询，检查是否有get参数传递过来了*/
            function synchronous(str) {

                var a = str;
                var id = a.getAttribute("Id");
                var name = a.getAttribute("Name");
                var title = a.getAttribute("title");
                //var proinfo = getUrlParam("id");
                document.getElementById("lblTitle").innerText = "回复:" + id;
                document.getElementById("hid").value = "回复:" + id;
                document.getElementById("hid1").value = name;
                document.getElementById("hid2").value = title;
                var myTable = document.getElementById("tb1"); myTable.style.display = "block";

            }
            function syn(str) {

                var a = str;
                var id = a.getAttribute("Id");
                var name = a.getAttribute("Name");
                document.getElementById("lblTitle").innerText = "回复:发布人";
                document.getElementById("hid").value = "回复:" + id;
                document.getElementById("hid1").value = name;
                var myTable = document.getElementById("tb1"); myTable.style.display = "block";

            }
            function DelInfo(id) {
                var a = id;
                $.ajax({
                    type: "post",
                    dataType: "text",
                    data: { "id": id },
                    url: '/xxxx/xxxxx',//目标地址
                    success: function () {
                    },
                })
            }

        </script>
    </form>
</body>
</html>
