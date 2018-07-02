<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrganizationEdit.aspx.cs" ValidateRequest="false" Inherits="HN863Soft.ISS.Web.Manage.Organization.OrganizationEdit" %>

<%@ Import Namespace="HN863Soft.ISS.Common" %>
<!DOCTYPE html>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0,user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>机构信息完善</title>
    <link href="../JS/artdialog/ui-dialog.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>

    <link href="../../Uploadify/uploadify.css" rel="stylesheet" />
    <script src="../../Uploadify/jquery.uploadify.v2.1.4.js"></script>
    <script src="../../Uploadify/jquery.uploadify.v2.1.4.min.js"></script>
    <script src="../../Uploadify/swfobject.js"></script>

    <script type="text/javascript" src="../JS/artdialog/dialog-plus-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/laymain.js"></script>
    <script type="text/javascript" charset="utf-8" src="../JS/common.js"></script>
    <script src="../JS/artDialog/artDialog.source.js" type="text/javascript"></script>
    <link href="../JS/artDialog/skins/blue.css" rel="stylesheet" type="text/css" />
    <script src="../JS/FunctionJS.js"></script>

    <link href="../../../Scripts/kindeditor-4.1.7/themes/default/default.css" rel="stylesheet" />
    <script src="../../../Scripts/kindeditor-4.1.7/kindeditor-min.js"></script>
    <script src="../../../Scripts/kindeditor-4.1.7/lang/zh_CN.js"></script>
    <script src="../../Ueditor/ueditor.config.js"></script>
    <script src="../../Ueditor/ueditor.all.min.js"></script>
    <script src="../../Ueditor/lang/zh-cn/zh-cn.js"></script>
    <style>
        .SelectdivCss {
            display: block;
        }

        .NoDivCss {
            display: none;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#uploadify').uploadify({
                'uploader': '../../Uploadify/uploadify.swf',
                'script': '../../WebService/Uploadify.ashx',
                'cancelImg': '../../Uploadify/cancel.png',
                'buttonText': '浏览视频',
                'folder': '/uploads',
                'auto': true,
                'sizeLimit': '209715200',
                'buttonText': '',
                'fileDesc': 'mp4.',
                'fileExt': '*.mp4',
                'buttonImg': '../../Uploadify/browse.jpg',
                'scriptData': { 'methed': 'uploadFile', 'arg1': 'value1' },
                'onComplete': function (event, queueID, file, serverData, data) {

                    //清除div
                    $('#uploadify').uploadifyClearQueue();

                    //设置后台数据保存路径
                    document.getElementById("hid").value = '/uploads/' + serverData;

                    alert("上传成功！点击播放按钮可播放视频");

                    playClicked(document.getElementById("hid").value);
                },

            });
        });
        function playClicked(element) {

            //设置路径
            document.getElementById("example_video_1").src = element;

            //播放按钮可用
            document.getElementById("example_video_1").controls = "metadata";

            ////设置自动加载
            //document.getElementById("example_video_1").autoplay = "autoplay";
            ////视频文件开始播放
            //document.getElementById("example_video_1").play();
        }
    </script>
    <style>
        /*body {
            margin: 0;
            padding: 0;
            background: url(../bg.gif) 0 0 repeat #f7f5f5;
            color: #333;
            font-family: Cambria, Georgia, serif;
            font-size: 15px;
            overflow-x: hidden;
        }*/

        a {
            color: black;
            text-decoration: none;
        }

            a:hover, a:active {
                color: black;
            }

        /* clearfix */
        .clearfix {
            clear: both;
        }

        /* container */
        #container {
            position: relative;
            width: 1100px;
            margin: 0 auto 25px;
            padding-bottom: 10px;
        }



        .gridimg {
            position: relative;
            width: 188px;
            min-height: 100px;
            padding: 15px;
            background: #fff;
            margin: 8px;
            font-size: 12px;
            float: left;
            box-shadow: 0 1px 3px rgba(34,25,25,0.4);
            -moz-box-shadow: 0 1px 3px rgba(34,25,25,0.4);
            -webkit-box-shadow: 0 1px 3px rgba(34,25,25,0.4);
            -webkit-transition: top 1s ease, left 1s ease;
            -moz-transition: top 1s ease, left 1s ease;
            -o-transition: top 1s ease, left 1s ease;
            -ms-transition: top 1s ease, left 1s ease;
        }

            /*.border {
            box-shadow: 2px 2px 3px rgba(34,25,25,0.4);
            -moz-box-shadow: 2px 2px 3px rgba(34,25,25,0.4);
            -webkit-box-shadow: 2px 2px 3px rgba(34,25,25,0.4);
            cursor: pointer;
        }*/


            .gridimg .closeimg {
                position: absolute;
                top: -25px;
                right: -16px;
                width: 50px;
                height: 50px;
                display: none;
            }

            .gridimg strong {
                border-bottom: 1px solid #ccc;
                margin: 10px 0;
                display: block;
                padding: 0 0 5px;
                font-size: 17px;
            }

            .gridimg .meta {
                text-align: right;
                color: #777;
                font-style: italic;
            }

            .gridimg .imgholder img {
                max-width: 100%;
                background: #ccc;
                display: block;
            }
    </style>
    <script src="../JS/blocksit.js"></script>
    <script src="../JS/blocksit.min.js"></script>
    <script>

        var action = GetQueryString('action');

        function GetQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }

        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
            if ($("#ddlOrganizationType").val() == "12") {
                $("#EIdiv").removeClass("NoDivCss").addClass("SelectdivCss");
                $("#LiImg").removeAttr("style").attr("style", "display:block");
                $("[name='tbOrgIntro']").removeAttr("datatype").attr("datatype", "*");
                $("[name='tbOrgShow']").removeAttr("datatype").attr("datatype", "*");
                //LiImg
            } else {
                $("#EIdiv").removeClass("SelectdivCss").addClass("NoDivCss");
                $("#LiImg").removeAttr("style").attr("style", "display:none");
                $("[name='tbOrgIntro']").removeAttr("datatype");
                $("[name='tbOrgShow']").removeAttr("datatype");
            }

            $("#ddlOrganizationType").change(function () {
                if ($("#ddlOrganizationType").val() == "12") {
                    $("#EIdiv").removeClass("NoDivCss").addClass("SelectdivCss");
                    $("#LiImg").removeAttr("style").attr("style", "display:block");
                    $("[name='tbOrgIntro']").removeAttr("datatype").attr("datatype", "*");
                    $("[name='tbOrgShow']").removeAttr("datatype").attr("datatype", "*");
                    //$("#dlqq").attr("datatype", "/^[1-9][0-9]{4,}$/");
                    $("#dlqq").show();
                } else {
                    $("#EIdiv").removeClass("SelectdivCss").addClass("NoDivCss");
                    $("#LiImg").removeAttr("style").attr("style", "display:none");
                    $("[name='tbOrgIntro']").removeAttr("datatype");
                    $("[name='tbOrgShow']").removeAttr("datatype");
                    //$("#dlqq").removeAttr("datatype");
                    $("#dlqq").hide();
                }

            })

        });
        function show(obj) {

            var array = new Array('jpeg', 'png', 'jpg'); //可以上传的文件类型 
            if (obj.value == '') {
                alert("让选择要上传的图片!");
                return false;
            }
            else {

                try {

                    var fileContentType = obj.match(/^(.*)(\.)(.{1,8})$/)[3]; //文件类型正则
                    var isExists = false;
                    for (var i in array) {
                        if (fileContentType.toLowerCase() == array[i].toLowerCase()) {
                            isExists = true;
                            var docObj = document.getElementById("FileUpload1");

                            var imgObjPreview = document.getElementById("Image1");
                            if (docObj.files && docObj.files[0]) {

                                imgObjPreview.src = window.URL.createObjectURL(docObj.files[0]);
                                imgObjPreview.width = 300;
                                imgObjPreview.height = 200;

                            }
                                //360兼容模式下
                            else {
                                var imgObj = document.getElementById("Image1");
                                imgObj.src = obj;

                            }
                            return true;
                        }
                    }
                    if (isExists == false) {
                        obj = "";
                        alert("上传图片类型不正确!");
                        //document.getElementById("Image1").src = "";
                        document.getElementById("FileUpload1").value = "";
                        return false;
                    }
                }
                catch (e) {

                }

                return false;
            }
        }


        function showJust(obj) {

            var array = new Array('jpeg', 'png', 'jpg'); //可以上传的文件类型 
            if (obj.value == '') {
                alert("让选择要上传的图片!");
                return false;
            }
            else {

                try {

                    var fileContentType = obj.match(/^(.*)(\.)(.{1,8})$/)[3]; //文件类型正则
                    var isExists = false;
                    for (var i in array) {
                        if (fileContentType.toLowerCase() == array[i].toLowerCase()) {
                            isExists = true;
                            var docObj = document.getElementById("FileUpload2");

                            var imgObjPreview = document.getElementById("Image2");
                            if (docObj.files && docObj.files[0]) {

                                imgObjPreview.src = window.URL.createObjectURL(docObj.files[0]);
                                imgObjPreview.width = 300;
                                imgObjPreview.height = 200;

                            }
                                //360兼容模式下
                            else {
                                var imgObj = document.getElementById("Image2");
                                imgObj.src = obj;

                            }
                            return true;
                        }
                    }
                    if (isExists == false) {
                        obj = "";
                        alert("上传图片类型不正确!");
                        //document.getElementById("Image1").src = "";
                        document.getElementById("FileUpload2").value = "";
                        return false;
                    }
                }
                catch (e) {

                }

                return false;
            }
        }

        function showBack(obj) {

            var array = new Array('jpeg', 'png', 'jpg'); //可以上传的文件类型 
            if (obj.value == '') {
                alert("让选择要上传的图片!");
                return false;
            }
            else {

                try {

                    var fileContentType = obj.match(/^(.*)(\.)(.{1,8})$/)[3]; //文件类型正则
                    var isExists = false;
                    for (var i in array) {
                        if (fileContentType.toLowerCase() == array[i].toLowerCase()) {
                            isExists = true;
                            var docObj = document.getElementById("FileUpload3");

                            var imgObjPreview = document.getElementById("Image3");
                            if (docObj.files && docObj.files[0]) {

                                imgObjPreview.src = window.URL.createObjectURL(docObj.files[0]);
                                imgObjPreview.width = 300;
                                imgObjPreview.height = 200;

                            }
                                //360兼容模式下
                            else {
                                var imgObj = document.getElementById("Image3");
                                imgObj.src = obj;

                            }
                            return true;
                        }
                    }
                    if (isExists == false) {
                        obj = "";
                        alert("上传图片类型不正确!");
                        //document.getElementById("Image1").src = "";
                        document.getElementById("FileUpload3").value = "";
                        return false;
                    }
                }
                catch (e) {

                }

                return false;
            }
        }

    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <!--导航栏-->
        <div class="location">
            <a href="OrganizationList.aspx" class="back" runat="server" id="reBack"><i></i><span>返回列表页</span></a>
            <a href="../Center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>机构信息完善</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div id="floatHead" class="content-tab-wrap">
            <div class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a class="selected" href="javascript:;">机构信息</a></li>
                        <li id="LiImg" style="display: none;"><a href="javascript:;">附件上传</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>类型</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlOrganizationType" runat="server" datatype="*" errormsg="请选择所属类型！" sucmsg=" "></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>机构名称</dt>
                <dd>
                    <asp:TextBox ID="orgName" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*名称必填</span></dd>
            </dl>
            <dl>
                <dt>机构Logo</dt>
                <dd>
                    <asp:FileUpload ID="FileUpload1" accept=".jpeg,.png,.jpg" CssClass="upload-box" datatype="*" runat="server" onchange="show(this.value)" />
                </dd>
            </dl>
            <dl>
                <dt></dt>
                <dd>
                    <asp:Image ID="Image1" runat="server" Height="200px" CssClass="photo-list" Width="300px" />
                </dd>
            </dl>
            <dl>
                <dt>机构简介</dt>
                <dd>
                    <asp:TextBox ID="txtIntroduce" runat="server" CssClass="input" TextMode="MultiLine" MaxLength="500" datatype="*1-100" sucmsg=" " Height="70px" Width="600px"></asp:TextBox>

                </dd>
            </dl>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <dl>
                        <dt>省份</dt>
                        <dd>
                            <div>
                                <asp:DropDownList runat="server" AutoPostBack="true" CausesValidation="true" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged" ID="ddlProvince">
                                </asp:DropDownList>
                            </div>
                        </dd>
                    </dl>
                    <dl>
                        <dt>市/区</dt>
                        <dd>
                            <div>
                                <asp:DropDownList runat="server" ID="ddlCity">
                                </asp:DropDownList>
                            </div>
                        </dd>
                    </dl>
                </ContentTemplate>
            </asp:UpdatePanel>
            <dl>
                <dt>机构位置</dt>
                <dd>
                    <asp:TextBox ID="orgLocation" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*位置必填</span></dd>
            </dl>
            <dl>
                <dt>微信</dt>
                <dd>
                    <asp:TextBox ID="tbOrgWeiXin" runat="server" CssClass="input normal" sucmsg=" "></asp:TextBox>
            </dl>
            <dl>
                <dt>申请人姓名</dt>
                <dd>
                    <asp:TextBox ID="tbUserName" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*申请人姓名必填</span></dd>
            </dl>

            <dl>
                <dt>身份证正面(法人或团队负责人身份证)</dt>
                <dd>
                    <asp:FileUpload ID="FileUpload2" accept=".jpeg,.png,.jpg" CssClass="upload-box" datatype="*" runat="server" onchange="showJust(this.value)" />
                </dd>
            </dl>
            <dl>
                <dt></dt>
                <dd>
                    <asp:Image ID="Image2" runat="server" Height="200px" CssClass="photo-list" Width="300px" />
                </dd>
            </dl>
            <dl>
                <dt>身份证反面</dt>
                <dd>
                    <asp:FileUpload ID="FileUpload3" accept=".jpeg,.png,.jpg" CssClass="upload-box" datatype="*" runat="server" onchange="showBack(this.value)" />
                </dd>
            </dl>
            <dl>
                <dt></dt>
                <dd>
                    <asp:Image ID="Image3" runat="server" Height="200px" CssClass="photo-list" Width="300px" />
                </dd>
            </dl>

            <dl>
                <dt>申请人手机</dt>
                <dd>
                    <asp:TextBox ID="tbMobile" runat="server" CssClass="input normal" datatype="/^0?(13|14|15|18)[0-9]{9}$/" errormsg="请输入正确的手机号码" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*申请人手机必填</span></dd>
            </dl>

            <dl id="dlqq" visible="false">
                <dt>QQ客服</dt>
                <dd>
                    <asp:TextBox ID="tbUserCard" runat="server" CssClass="input normal" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*孵化器用户QQ客服必填(请填写正确的QQ,以确保其他用户能联系 )</span></dd>
            </dl>
            <dl>
                <dt>申请人邮箱</dt>
                <dd>
                    <asp:TextBox ID="tbUserEmail" runat="server" CssClass="input normal" datatype="/^\w[-\w.+]*@([A-Za-z0-9][-A-Za-z0-9]+\.)+[A-Za-z]{2,14}$/" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*申请人邮箱必填</span></dd>
            </dl>
            <dl>
                <dt>证明文件</dt>
                <dd>
                    <textarea runat="server" id="tbOrgFile" name="tbOrgFile" cssclass="input normal" datatype="*" style="height: 200px; width: 80%"></textarea>
                    <span class="Validform_checktip">*机构或专家证明文件必填（包括营业执照、组织机构代码证等...）</span>
                    <script type="text/javascript">
                        var ue = UE.getEditor('tbOrgFile', {
                            toolbars: [
                                ['fullscreen', 'simpleupload', 'insertimage', 'justifyleft', 'justifyright', 'justifycenter', 'forecolor', 'imagecenter']
                            ],
                            autoHeightEnabled: true,
                            autoFloatEnabled: true
                        });
                    </script>
                </dd>
            </dl>
            <div class="NoDivCss" id="EIdiv" runat="server">
                <dl>
                    <dt>入驻标准</dt>
                    <dd>
                        <textarea runat="server" id="tbOrgShow" name="tbOrgShow" cssclass="input normal" datatype="*" style="height: 200px; width: 80%; max-height: 400px"></textarea>
                        <script type="text/javascript">
                            var ue = UE.getEditor('tbOrgShow', {
                                toolbars: [
                                    ['fullscreen', 'justifyleft', 'justifyright', 'justifycenter', 'forecolor']
                                ],
                                autoHeightEnabled: true,
                                autoFloatEnabled: true
                            });
                        </script>
                    </dd>
                </dl>
                <dl>
                    <dt>特色</dt>
                    <dd>
                        <textarea runat="server" id="tbOrgIntro" name="tbOrgIntro" cssclass="input normal" datatype="*" style="height: 200px; width: 80%; max-height: 400px"></textarea>
                        <script type="text/javascript">
                            var ue = UE.getEditor('tbOrgIntro', {
                                toolbars: [
                                    ['fullscreen', 'justifyleft', 'justifyright', 'justifycenter', 'forecolor']
                                ],
                                autoHeightEnabled: true,
                                autoFloatEnabled: true
                            });
                        </script>
                    </dd>
                </dl>
            </div>



            <dl>
                <dt>地址选择</dt>
                <dd>
                    <div style="height: 580px; width: 80%">
                        <div id="allmap" style="height: 400px; width: 100%"></div>
                        <div id="r-result">
                            <dl>
                                <dt>地址搜索:</dt>
                                <dd>
                                    <input type="text" id="suggestId" size="20" value="百度" style="width: 150px;" class="input" /></dd>
                            </dl>
                        </div>
                        <div id="searchResultPanel" style="border: 1px solid #C0C0C0; width: 150px; height: auto; display: none;"></div>
                        <div id="Div1">
                            <dl>
                                <dt>经度:</dt>
                                <dd>
                                    <asp:TextBox ID="longitude" runat="server" CssClass="input normal" datatype="/^(-?\d+)(\.\d+)?$/" sucmsg=" "></asp:TextBox>
                                    <span class="Validform_checktip">*经度必填</span>
                                </dd>
                            </dl>
                            <dl>
                                <dt>纬度:</dt>
                                <dd>
                                    <asp:TextBox ID="latitude" runat="server" CssClass="input normal" datatype="/^(-?\d+)(\.\d+)?$/" sucmsg=" "></asp:TextBox>
                                    <span class="Validform_checktip">*纬度必填</span>
                                </dd>
                            </dl>
                            <dl>
                                <dt></dt>
                                <dd>
                                    <input type="button" value="查询" class="btn" onclick="theLocation()" /></dd>
                            </dl>
                        </div>
                    </div>
                </dd>
            </dl>
        </div>
        <%--<script src="../JS/ImgUp/jquery.js"></script>--%>
        <link href="../../video/video-js.css" rel="stylesheet" />
        <script src="../../video/video.js"></script>
        <script src="../JS/ImgUp/zyupload-1.0.0.min.js"></script>
        <link href="../JS/ImgUp/zyupload-1.0.0.min.css" rel="stylesheet" />
        <div class="tab-content" style="display: none">
            <dl>
                <dt>孵化器网站主页</dt>
                <dd>
                    <asp:TextBox ID="weburl" runat="server" CssClass="input normal"  sucmsg=" " />
                    <span class="Validform_checktip">您公司的网站主页</span>
                </dd>
            </dl>
            <dl>
                <dt>项目宣传视频</dt>
                <dd>
                    <input type="file" name="uploadify" id="uploadify" />
                    <span class="Validform_checktip">*最大支持200M的视频文件。</span>
                </dd>
            </dl>
            <dl>
                <dd>
                    <asp:HiddenField runat="server" ID="hid" />
                    <video id="example_video_1" controls="metadata" src='<%=strSrc%>' class="video-js vjs-default-skin" width="800" height="500">
                    </video>
                </dd>
                <dd style="color: red">*为确保视频正确加载，如果是IE浏览器，请使用IE9以上版本。如果是其他浏览器，请用兼容性模式打开本站。</dd>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:CheckBox Text="text" hidden="hidden" OnCheckedChanged="b2_CheckedChanged" ID="b2" AutoPostBack="true" runat="server" />
                        <dl>
                            <dt>图片上传</dt>
                            <dd>
                                <asp:Repeater ID="dlImg" OnItemCommand="dlImg_ItemCommand1" runat="server">
                                    <HeaderTemplate>
                                        <div class="imglist">
                                            <ul>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <li>
                                            <br />
                                            <div name="container">
                                                <div class="gridimg" onmouseover="if(action!='View') {$(this).addClass('border');$(this).find('.closeimg').css('display', 'block');}" onmouseout="$(this).removeClass('border'); $(this).find('.closeimg').css('display', 'none');">
                                                    <asp:ImageButton ID="ImageButton2" ImageUrl="../JS/ImgUp/images/20140107145946140.png" class="closeimg" CommandName="del" runat="server" />
                                                    <div class="imgholder">
                                                        <asp:Image ID="Image1" ImageUrl='<%#Eval("ImgUrl")%>' Width="200px" runat="server" />

                                                    </div>
                                                </div>

                                            </div>
                                        </li>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </ul>   
                            </div>                    
                                    </FooterTemplate>
                                </asp:Repeater>
                            </dd>
                        </dl>
                        <asp:HiddenField runat="server" ID="hfCount" />
                        <asp:HiddenField runat="server" ID="ImgAddPath" />
                        <asp:HiddenField runat="server" ID="ImgAddPaths" />
                        <asp:HiddenField runat="server" ID="ImgDelPath" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </dl>
            <dl>
                <dt></dt>
                <dd>
                    <div id="zyupload" class="zyupload" runat="server" style="margin-left: 0px;"></div>
                    <script type="text/javascript">
                        $(function () {
                            // 初始化插件
                            $("#zyupload").zyUpload({
                                width: "650px",                 // 宽度
                                height: "auto",                 // 宽度
                                itemWidth: "140px",                 // 文件项的宽度
                                itemHeight: "115px",                 // 文件项的高度
                                url: "../../WebService/SubmitAjaxHandler.ashx?action=UploadImg&Id=" + '<%=Convert.ToInt32(Request["Id"])%>',  // 上传文件的路径
                                fileType: ["jpg", "png", "jpeg"],// 上传文件的类型
                                fileSize: 51200000,                // 上传文件的大小
                                multiple: true,                    // 是否可以多个文件上传
                                dragDrop: true,                    // 是否可以拖动上传文件
                                tailor: false,                    // 是否可以裁剪图片
                                del: true,                    // 是否可以删除文件
                                finishDel: true,  				  // 是否在上传文件完成后删除预览
                                /* 外部获得的回调接口 */
                                onSelect: function (selectFiles, allFiles) {    // 选择文件的回调方法  selectFile:当前选中的文件  allFiles:还没上传的全部文件
                                    //console.info("当前选择了以下文件：");
                                    //console.info(selectFiles);
                                },
                                onDelete: function (file, files) {              // 删除一个文件的回调方法 file:当前删除的文件  files:删除之后的文件
                                    //console.info("当前删除了此文件：");
                                    //console.info(file.name);
                                },
                                onSuccess: function (file, response) {
                                    $('#ImgAddPath').val(response);
                                    var strvalue = $('#ImgAddPaths').val();
                                    $('#ImgAddPaths').val(strvalue + "*" + response);
                                    // 文件上传成功的回调方法


                                },
                                onFailure: function (file, response) {          // 文件上传失败的回调方法
                                    //console.info("此文件上传失败：");
                                    //console.info(file.name);
                                },
                                onComplete: function (response) {
                                    $('#b2').trigger('click');
                                }
                            });
                        });
                    </script>
                </dd>
            </dl>
        </div>



        <div class="page-footer">
            <div class="btn-wrap">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClientClick="return Check()" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
        </div>
        <script src="../../map/demo/api/api.js"></script>
        <script type="text/javascript">

            function Check() {
                var num = parseInt($("#hfCount").val());
                if ($("#ddlOrganizationType").val() == "12") {
                    if (($("#hfCount").val()) == "") {
                        num = 0;
                    }
                    if (parseInt(num) < 4) {
                        //alert("")
                        showWarningMsg('最少四张图片！');
                        return false;
                    }
                }
                return true;
            }

            // 百度地图API功能
            var map = new BMap.Map("allmap");

            var lngint = document.getElementById("longitude").value;
            var latint = document.getElementById("latitude").value;
            if (lngint != "" && latint != "") {
                var new_point = new BMap.Point(lngint, latint);
                map.centerAndZoom(new_point, 12);
                var marker = new BMap.Marker(new_point);  // 创建标注
                map.addOverlay(marker);
                map.panTo(new_point);
            }
            else {
                map.centerAndZoom("重庆", 12);
            }
            map.enableScrollWheelZoom();   //启用滚轮放大缩小，默认禁用
            map.enableContinuousZoom();





            //单击获取点击的经纬度
            map.addEventListener("click", function (e) {
                //alert(e.point.lng + "," + e.point.lat);
                map.clearOverlays();
                document.getElementById("longitude").value = e.point.lng;
                document.getElementById("latitude").value = e.point.lat;
                var new_point = new BMap.Point(e.point.lng, e.point.lat);
                var marker = new BMap.Marker(new_point);  // 创建标注
                map.addOverlay(marker);              // 将标注添加到地图中
                map.panTo(new_point);
            });

            // 百度地图API功能
            function G(id) {
                return document.getElementById(id);
            }


            var ac = new BMap.Autocomplete(    //建立一个自动完成的对象
                {
                    "input": "suggestId"
                , "location": map
                });

            ac.addEventListener("onhighlight", function (e) {  //鼠标放在下拉列表上的事件
                var str = "";
                var _value = e.fromitem.value;
                var value = "";
                if (e.fromitem.index > -1) {
                    value = _value.province + _value.city + _value.district + _value.street + _value.business;
                }
                str = "FromItem<br />index = " + e.fromitem.index + "<br />value = " + value;

                value = "";
                if (e.toitem.index > -1) {
                    _value = e.toitem.value;
                    value = _value.province + _value.city + _value.district + _value.street + _value.business;
                }
                str += "<br />ToItem<br />index = " + e.toitem.index + "<br />value = " + value;
                G("searchResultPanel").innerHTML = str;
            });

            var myValue;
            ac.addEventListener("onconfirm", function (e) {    //鼠标点击下拉列表后的事件
                var _value = e.item.value;
                myValue = _value.province + _value.city + _value.district + _value.street + _value.business;
                G("searchResultPanel").innerHTML = "onconfirm<br />index = " + e.item.index + "<br />myValue = " + myValue;

                setPlace();
            });

            function setPlace() {
                map.clearOverlays();    //清除地图上所有覆盖物
                function myFun() {
                    var pp = local.getResults().getPoi(0).point;
                    document.getElementById("longitude").value = pp.lng;//获取第一个智能搜索的结果
                    document.getElementById("latitude").value = pp.lat;
                    map.centerAndZoom(pp, 18);
                    map.addOverlay(new BMap.Marker(pp));    //添加标注
                }
                var local = new BMap.LocalSearch(map, { //智能搜索
                    onSearchComplete: myFun
                });
                local.search(myValue);
            }

            //// 用经纬度设置地图中心点
            function theLocation() {
                if (document.getElementById("longitude").value != "" && document.getElementById("latitude").value != "") {
                    map.clearOverlays();
                    var new_point = new BMap.Point(document.getElementById("longitude").value, document.getElementById("latitude").value);
                    var marker = new BMap.Marker(new_point);  // 创建标注
                    map.addOverlay(marker);              // 将标注添加到地图中
                    map.panTo(new_point);
                }
            }


        </script>

        <script>
            window.onload = function () {



                //blocksit define  
                $(window).load(function () {
                    $("[name='container']").BlocksIt({
                        numOfCol: 5,
                        offsetX: 8,
                        offsetY: 8
                    });
                });

                //window resize  
                var currentWidth = 1100;
                $(window).resize(function () {
                    var winWidth = $(window).width();
                    var conWidth;
                    if (winWidth < 660) {
                        conWidth = 440;
                        col = 2
                    } else if (winWidth < 880) {
                        conWidth = 660;
                        col = 3
                    } else if (winWidth < 1100) {
                        conWidth = 880;
                        col = 4;
                    } else {
                        conWidth = 1100;
                        col = 5;
                    }

                    if (conWidth != currentWidth) {
                        currentWidth = conWidth;
                        $("[name='container']").width(conWidth);
                        $("[name='container']").BlocksIt({
                            numOfCol: col,
                            offsetX: 8,
                            offsetY: 8
                        });
                    }
                });


            };



        </script>

        <!--/工具栏-->
    </form>
</body>
</html>
