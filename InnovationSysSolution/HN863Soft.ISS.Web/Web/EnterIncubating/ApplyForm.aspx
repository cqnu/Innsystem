<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyForm.aspx.cs" Inherits="HN863Soft.ISS.Web.Web.EnterIncubating.ApplyForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>在线申请入驻</title>
    <link href="../../Manage/skin/default/style.css" rel="stylesheet" />
    <%--<script src="../../Scripts/jquery-3.1.1.min.js"></script>--%>
    <script src="../../Scripts/jquery-1.7.1.min.js"></script>
     <script src="../../Scripts/jquery/PCASClass.js"></script>
    <script src="../../Manage/JS/common.js"></script>
    <script src="../../Scripts/js/ajaxfileupload.js"></script>
    <%--<script src="../../Scripts/jquery/PCASClass.js"></script>--%>
    <%--<script src="../../Manage/JS/common.js"></script>--%>
    
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
        $(".file").on("change", "input[type='file']", function () {
            var filePath = $(this).val();
            //设置上传文件类型
            if (filePath.indexOf("doc") != -1 || filePath.indexOf("docx") != -1) {
                $.ajaxFileUpload({
                    type: "POST",
                    async: false,
                    // data: { "iid": uud},
                    url: "../../WebService/SubmitAjaxHandler.ashx?action=RepplySubmit&Id="+'<%=Request["Id"]%>',
                    dataType: 'json',
                    secureuri: false,
                    fileElementId: "btnfile",
                    success: function (data, status) {
                        if (data.status == "1") {
                            $("#txtFilePath").val(data.filePath)
                        }
                        else {
                            alert(data.msg);
                        }
                        return false;
                    },
                    error: function (e) {
                        //$("#txtFilePath").val(data.filePath)
                        //top.Dialog.alert(e);
                        return false;
                    }
                });
            } else {
                alert("请选择正确的文件格式！");
                //清空上传路径
                return false;
            }
        });

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
            "CreateTime": Date.now,
            "OrId": $("#txtinput").val(),//机构Id
            "Creator": 1,//用户Id
            "Email": $("#txtEmail").val(),
            "Name": $("#txtName").val(),
            "Phone": $("#txtPhone").val(),
            "VisitDate": $("#txtVisDate").val(),//来访日期
            "VisitNum": $("#txtNum").val(),//来访人数
            "IsVis": "0",
            "Remark": $("#txtIntruduction").val(),//业务简介
            "FileUrl": $("#txtFilePath").val()//商业计划书上传路径
        };
        //发送AJAX请求
        $.ajax({
            type: "post",
            url: "../../WebService/SubmitAjaxHandler.ashx?action=RepplySubmits",
            dataType: "html",
            data: postData,
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
    }
</script>
<body>
    <form id="form1" runat="server">
        <div class="tab-content">
            <dl>
                <dt>申请人姓名：
                </dt>
                <dd>
                    <asp:TextBox runat="server" MaxLength="20" ID="txtName" />
                </dd>
            </dl>
            <dl>
                <dt>手机：
                </dt>
                <dd>

                    <asp:TextBox ID="txtPhone" datatype="/^[0-9]{1,12}$/"  MaxLength="12" runat="server"></asp:TextBox>
                </dd>
            </dl>
            <dl>
                <dt>邮箱：</dt>
                <dd>
                    <asp:TextBox runat="server" TextMode="Email" ID="txtEmail" /></dd>
            </dl>
            <dl>
                <dt>入驻人数：</dt>
                <dd>
                    <asp:TextBox runat="server" TextMode="Number" ID="txtNum" datatype="/^[0-9]{0,5}$/" />
                </dd>
            </dl>
            <dl>
                <dt>期望入驻日期：</dt>
                <dd>
                    <asp:TextBox runat="server" ID="txtVisDate" TextMode="Date" />
                </dd>
            </dl>
            <dl>
                <dt>业务简介</dt>
                <dd>
                    <asp:TextBox runat="server" ID="txtIntruduction" TextMode="MultiLine"  MaxLength="250" />
                </dd>
            </dl>
            <dl>
                <dt>商业计划书：</dt>
                <dd>
                    <a class="file">
                         <input type="text" id="txtFilePath" hidden="hidden"  value="" runat="server" />
                        <input id="btnfile" name="btnfile" type="file" /></a>
                </dd>
            </dl>
            <input type="text" id="txtinput" hidden="hidden" value="" runat="server" />
           
        </div>
    </form>
</body>
</html>
