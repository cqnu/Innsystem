<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TechnicalInformation_Show.aspx.cs" Inherits="HN863Soft.ISS.Web.TechnicalInformation.Show" Title="显示页" %>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>后台导航管理</title>
    <script src="../Ueditor/ueditor.config.js"></script>
    <script src="../Ueditor/ueditor.all.min.js"></script>
    <script src="../Ueditor/lang/zh-cn/zh-cn.js"></script>
    <link href="../../Manage/JS/artDialog/skins/blue.css" rel="stylesheet" />
    <link href="../../Manage/skin/default/style.css" rel="stylesheet" />
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="/Manage/TechnicalInformation/TechnicalInformation_List.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../Center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="/Manage/TechnicalInformation/TechnicalInformation_List.aspx"><span>技术信息资源列表</span></a>
            <i class="arrow"></i>
            <span>查看技术信息资源</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->
        <table style="width: 100%; height: 20%" cellpadding="2" cellspacing="1" class="border">
            <tr>
                <td class="tdbg">

                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td height="25" width="30%" align="right">产品名称
	：</td>
                            <td height="25" width="50%" align="left">

                                <label id="lblEntryName" runat="server" width="60%"></label>
                            </td>


                        </tr>
                        <tr>
                            <td height="25" width="30%" align="right">产品关键字
	：</td>
                            <td height="25" width="50%" align="left">
                                <label id="lblKeyword" runat="server" width="60%"></label>
                            </td>
                        </tr>
                    </table>
                    <script src="/js/calendar1.js" type="text/javascript"></script>

                </td>
            </tr>
            <tr>
            </tr>
        </table>

        <table style="width: 100%; height: 50%">
            <tr>
                <td style="width: 80%; height: 100%">
                    <div id="floatHead" class="content-tab-wrap">
                        <div class="content-tab">
                            <div class="content-tab-ul-wrap">
                                <ul>
                                    <li><a class="selected" href="javascript:;">服务范围</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div style="width: 100%"><%=stra%></div>

                    <%--<textarea runat="server" id="traDetailedContent" style="height: 200px; width: 700px"><%=stra%></textarea>--%>
                    <br />
                    <br />
                    <div id="Div1" class="content-tab-wrap">
                        <div class="content-tab">
                            <div class="content-tab-ul-wrap">
                                <ul>
                                    <li><a class="selected" href="javascript:;">公司简介</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <textarea style="height: 30%; width: 100%"></textarea>
                    <br />
                    <br />

                    <div id="Div2" class="content-tab-wrap">
                        <div class="content-tab">
                            <div class="content-tab-ul-wrap">
                                <ul>
                                    <li><a class="selected" href="javascript:;">机构展示</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div id="content" style="width: 100%; height: 100px"><%=strInstitutionalDisplay%></div>

                    <%-- <textarea runat="server" id="traInstitutionalDisplay" style="height: 200px; width: 700px"></textarea>--%>
                </td>
                <td style="text-align: left; width: 30%; vertical-align: top">

                    <table id="draggable1_2">
                        <tr>
                            <td>
                                <h3>联系方式</h3>
                                <br />
                            </td>
                        </tr>

                        <tr>
                            <td style="text-align: right">
                                <asp:Image ID="Image2" ImageUrl="~/Img/yx.ico" runat="server" />
                                姓名：
                            </td>
                        </tr>

                        <tr>
                            <td style="text-align: right">
                                <asp:Image ID="Image1" ImageUrl="~/Img/地址.ico" runat="server" />
                                地址：
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                <asp:Image ID="Image3" ImageUrl="~/Img/电话.ico" runat="server" />
                                手机：
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                <asp:Image ID="Image4" ImageUrl="~/Img/邮箱.ico" runat="server" />
                                邮件：
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                <asp:Image ID="Image5" ImageUrl="~/Img/微信.ico" runat="server" />
                                微信：
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                <asp:Image ID="Image6" ImageUrl="~/Img/QQ.ico" runat="server" />
                                QQ&nbsp;：
                            </td>
                        </tr>
                    </table>

                </td>
            </tr>
        </table>
    </form>

    <script type="text/javascript">
        window.onload = function () {

            var imgObj;
            for (i = 0; i < document.getElementById("content").getElementsByTagName("img").length; i++) {
                imgObj = document.getElementById("content").getElementsByTagName("img")[i];
                //建议只判断高度或者宽度其中一个，那样可以自动按比例缩放 
                //if (imgObj.width > 100) //判断图片的宽度 
                //{

                imgObj.width = 200;
                var link1 = document.createElement("a");
                link1.href = imgObj.src; link1.target = "_blank"; link1.title = "点击放大";
                imgObj.parentNode.insertBefore(link1, imgObj);
                link1.appendChild(imgObj);
                //}
                //if (imgObj.height > 100) //判断图片的宽度 
                //{
                imgObj.height = 100;

            }

        }


    </script>

</body>

</html>




