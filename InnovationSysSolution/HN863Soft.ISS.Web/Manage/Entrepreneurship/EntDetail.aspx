<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="EntDetail.aspx.cs" Inherits="HN863Soft.ISS.Web.Manage.Entrepreneurship.EntDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        textarea {
            display: block;
        }

        table.altrowstable {
            font-family: verdana,arial,sans-serif;
            font-size: 11px;
            color: #333333;
            border-width: 1px;
            background-color: #d4e3e5;
            border-color: #a9c6c9;
            border-collapse: collapse;
        }

            /*table.altrowstable th {
                border-width: 1px;
                padding: 8px;
                border-style: solid;
                border-color: #a9c6c9;
            }*/

            table.altrowstable td {
                border-width: 1px;
                /*padding: 8px;*/
                border-style: solid;
                border-color: #a9c6c9;
            }
    </style>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />

      <link href="../JS/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../JS/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/common.js"></script>
    <script src="../JS/artDialog/artDialog.source.js" type="text/javascript"></script>
    <link href="../JS/artDialog/skins/blue.css" rel="stylesheet" type="text/css" />
    <script src="../JS/FunctionJS.js"></script>

    <script src="../../../Scripts/jquery-3.1.1.min.js"></script>
    <link href="../../../Scripts/kindeditor-4.1.7/themes/default/default.css" rel="stylesheet" />
    <script type="text/javascript" src="../../../Scripts/kindeditor-4.1.7/kindeditor-min.js"></>
    <script type="text/javascript"   src="../../../Scripts/kindeditor-4.1.7/lang/zh_CN.js"></script>

    <script type="text/javascript">
        var editor;
        KindEditor.ready(function (K) {
            editor = K.create('textarea[id="txtContent"]', {
                //themeType : 'qq',
                resizeType: 0,
                allowPreviewEmoticons: false,
                allowImageUpload: false,
                items: [
                    'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
                    'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
                    'insertunorderedlist', '|', 'emoticons']
                //, 'link','image',
            })
        });

        //回复人
        function focuss(values) {
            var depremark = $(values).attr("Id")
            var name = $(values).attr("name");
            $("#txtContent").val(name);
            $("#txtId").val(depremark);//主键Id
            editor.html("@" + name);
        }

        //插入回复信息
        function InsertInfo() {
            var content = editor.html();  //内容
            var sId = 6;                //服务信息Id
            var responserId = 2;        //回复者Id
            var commentId = $("#txtId").val();//评论对象ID
            $.ajax({
                url: "../Ajax/InsertReply.aspx",
                data: { content: content, sId: sId, responserId: responserId, commentId: commentId },
                success: function (result) {
                    $("txtContent").val("");
                    $("txtId").val("");
                    editor.html("");
                    alert(result);
                    //document.getElementById('lbl').click();

                }
            }
            );
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <!--导航栏-->
        <div class="location">
            <a href="EntList.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../Center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="EntList.aspx"><span>辅导信息列表</span></a>
            <i class="arrow"></i>
            <span>编辑辅导信息</span>
        </div>
        <div class="line10"></div>
        <div class="Info">
            <input type="text" id="txtMethod" hidden="hidden" />
            <h1><%= conductModel.Title %></h1>
            <%--<label>作者：<%=conductModel.PublisherId %></label>--%>
            <label>发布时间：<%=Convert.ToDateTime(conductModel.CreateTime).ToString("yyyy/MM/dd") %></label>
            <br />
            <br />
            <%-- <hr />
            <br />--%>
        </div>
        <%-- <div>
            <%= serviceModel.Title %>
        </div>--%>
        <%--     <h3>服务范围</h3>
        <br />
        <hr />
        <br />
        <div class="Content">
            <%= conductModel.Content %>
        </div>
        <br />--%>
        <%--<hr />--%>
        <br />
        <h4>最新回答</h4>
        <br />
        <hr />
        <br />
        <asp:DataList runat="server" ID="dlReplyInfo" RepeatColumns="1" OnItemCommand="dlReplyInfo_ItemCommand" DataKeyField="Id" CellSpacing="10" Width="100%">
            <ItemTemplate>
                <table style="width: 100%; height: auto" class="altrowstable" id="alternatecolor">
                    <tr>
                        <td rowspan="3" style="width: 200px">
                            <div style="width: 100%; height: 100%">
                                <ul style="list-style-type: none; padding-left: 0px; margin-left: 5px; margin-top: 5px">
                                    <li>
                                        <img src="#" height="100px" width="100px " />
                                    </li>
                                    <li>用户名：<%#Eval("UserName") %>
                                    </li>
                                </ul>
                            </div>
                        </td>
                        <td style="height: 20px">
                            <div style="position: relative">
                                回复于：<%# Eval("Time")%>
                                <div style="position: absolute; right: 10px; top: 1px">
                                    #<%#Eval("Floor") %>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 5px">
                            <div class="content">
                                <%# Convert.ToInt32(Eval("IsVis"))==0?"此评论已被删除！":Eval("Content") %>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px">
                            <div style="position: relative">
                                <%#  Convert.ToString(Eval("FL"))==""? "":"引用第"+ Eval("FL")+"楼的回复！" %>
                                <div style="position: absolute; bottom: 0px; right: 0px; display: block">
                                    <a href="#txtContent" id='<%#Eval("Id")%>' name="<%#Eval("UserName") %>" onclick="focuss(this)">快速回复</a>
                                    <asp:LinkButton Text="删除" ID="lbtnDel" CommandName="Delete" Visible='<%#(Convert.ToInt32(Eval("IsVis"))==0?false:true) %>' OnClientClick="return confirm('确认删除？');" runat="server" />
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
                <br />
            </ItemTemplate>
        </asp:DataList>
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

        <hr />
        <br />
        <div style="width: 100%; position: relative;">
            <div class="Img" style="float: left; display: inline; width: 10%">
                <img src="../../Css/095838603.jpg" height="100px" width="100px" />
            </div>
            <div style="float: left; width: 80%">
                <a name="txtContent"></a>
                <textarea runat="server" name="txtContent" id="txtContent" style="width: 100%; height: 100px; visibility: hidden;">来说两句吧。。。</textarea>
            </div>
            <div style="float: left; width: 9%; position: absolute; right: 0px">
                <input type="text" id="txtId" hidden="hidden" runat="server" />
                <asp:Button Text="发表" runat="server" ID="btnReply" OnClick="btnSubmit_Click" />
            </div>
        </div>

    </form>
</body>
</html>
