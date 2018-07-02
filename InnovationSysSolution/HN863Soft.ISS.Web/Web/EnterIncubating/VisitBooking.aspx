<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisitBooking.aspx.cs" Inherits="HN863Soft.ISS.Web.Web.EnterIncubating.VisitBooking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>在线预约参观</title>
    <link href="../../Manage/skin/default/style.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../../Scripts/jquery/PCASClass.js"></script>
    <script src="../../Manage/JS/common.js"></script>
</head>
    <script type="text/ecmascript">
        var api = top.dialog.get(window); //获取窗体对象
        var W = api.data;
        $(function () {
        //页面加载完成执行
            //设置按钮及事件
            api.button([{
                value: '确定',
                callback: function () {
                    submitForm();
                },
                autofocus: true
            }, {
                value: '取消',
                callback: function () { }
            }]);
        })
        //提交表单处理
        function submitForm() {
            var currDocument = $(document); //当前文档
            //验证表单
            if ($("#txtName").val() == "") {
                top.dialog({
                    title: '提示',
                    content: '请填写申请人姓名！',
                    okValue: '确定',
                    ok: function () { },
                    onclose: function () {
                        $("#txtName", currDocument).focus();
                    }
                }).showModal(api);
                return false;
            }
            if ($("#txtPhone").val() == "") {
                top.dialog({
                    title: '提示',
                    content: '请填写联系方式！',
                    okValue: '确定',
                    ok: function () { },
                    onclose: function () {
                        $("#txtPhone", currDocument).focus();
                    }
                }).showModal(api);
                return false;
            }
            if ($("#txtEmail").val() == "") {
                top.dialog({
                    title: '提示',
                    content: '请填写邮箱地址！',
                    okValue: '确定',
                    ok: function () { },
                    onclose: function () {
                        $("#txtEmail", currDocument).focus();
                    }
                }).showModal(api);
                return false;
            }
            if ($("#txtNum").val() == "") {
                top.dialog({
                    title: '提示',
                    content: '请填写参观人数！',
                    okValue: '确定',
                    ok: function () { },
                    onclose: function () {
                        $("#txtNum", currDocument).focus();
                    }
                }).showModal(api);
                return false;
            }
            //下一步，AJAX提交表单
            var postData = {
                "CreateTime" : Date.now,
                "EId": $("#txtinput").val(),//孵化器Id
                "Creator" : 1,//用户Id
                "Email" : $("#txtEmail").val(),
                "Name": $("#txtName").val(),
                "Phone": $("#txtPhone").val(),
                "VisitDate": $("#txtVisDate").val(),//来访日期
                "VisitNum": $("#txtNum").val(),//来访人数
                "IsVis": "0",
                "Remark": $("#txtIntruduction").val()//业务简介
            };

            //发送AJAX请求
            $.ajax({
                type: "post",
                url: "../../WebService/SubmitAjaxHandler.ashx?action=VisitBookingSubmit",
                dataType: "html",
                data:postData,
                success: function (data, textStatus) {
                    var i = 1111;
                    if (textStatus == "0") {
                        top.dialog({
                            title: '提示',
                            content: '错误提示：' + data.msg,
                            okValue: '确定',
                            ok: function () { }
                        }).showModal(api);

                    } else {
                        top.dialog({
                            title: '提示',
                            content: '成功提示：' + data.msg,
                            okValue: '确定',
                            ok: function () { }
                        }).showModal(api);

                    }
                }
            });
            return false;

            //发送AJAX请求
            //W.sendAjaxUrl(api, postData, "../../WebService/SubmitAjaxHandler.ashx?action=VisitBookingSubmit");
            //return false;
        }
    </script>
<body>
    <form id="form1" runat="server" action="post">
        <div class="tab-content">
            <dl>
                <dt>姓名：
                </dt>
                <dd>
                    <asp:TextBox runat="server" MaxLength="20" ID="txtName" />
                </dd>
            </dl>
            <dl>
                <dt>手机：
                </dt>
                <dd>
                    
                    <asp:TextBox ID="txtPhone" TextMode="Number" MaxLength="12" runat="server"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>邮箱：</dt>
                <dd>
                    <asp:TextBox runat="server" TextMode="Email" ID="txtEmail" /></dd>
            </dl>
            <dl>
                <dt>人数：</dt>
                <dd>
                    <asp:TextBox runat="server" TextMode="Number" ID="txtNum" datatype="/^[0-9]{0,5}$/" />
                </dd>
            </dl>
            <dl>
                <dt>期望参观日期：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="txtVisDate" TextMode="Date" />
                </dd>
            </dl>
            <dl>
                <dt>业务简介：</dt>
                <dd>
                    <asp:TextBox runat="server" TextMode="MultiLine" Width="200px" Height="100px" ID="txtIntruduction" /></dd>
            </dl>
            <input type="text"  id="txtinput" hidden="hidden" value="" runat="server" />
        </div>
    </form>
</body>
</html>
