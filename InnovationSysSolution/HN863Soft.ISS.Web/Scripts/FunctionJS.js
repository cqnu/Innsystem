/*====================================
 *基于JQuery 1.10.2以上主框架
 *后台管理页JS函数，Jquery扩展
 *作者：三原色
====================================*/
$.ajaxSetup({
    cache: false
});
$(function () {
    $('.aspNetHidden').hide();
    ////Loading(false);
    publicobjcss();
    $("#txt_Search").focus().select(); //搜索框默认焦点
})
//=============================切换验证码======================================
function ToggleCode(obj, codeurl) {
    $("#txtCode").val("");
    $("#" + obj).attr("src", codeurl + "?time=" + Math.random());
}
//回调
function windowload() {
    rePage();
}
/**
刷新页面
**/
function rePage() {
    //////Loading(true);
    window.location.href = window.location.href.replace('#', '');
    return false;
}

//刷新父页面
function rePage2Parent() {    
    parent.location.href = parent.location.href.replace('#', '');
    return false;
}

/**
* 返回上一级
*/
function back(backNum) {
    if (backNum == undefined || backNum == "")
        backNum = -1;
    window.history.go(backNum);
    //Loading(true);
}
//跳转页面
function Urlhref(url) {
    ////Loading(true);
    window.location.href = url;
    return false;
}

//跳转页面（子页面跳到父页面）
function Urlhref2Parent(url) {
    parent.location.href = url;
    return false;
}

/**
中间加载对话窗
**/
function Loading(bool) {
    if (bool) {
    } else {
        setInterval(loadinghide, 800);
    }
}
function loadinghide() {
}
/**
Top 加载对话窗
msg:提示信息
time：停留时间ms
**/
function TopLoading(msg, time) {
    var _time = 1000;
    if (IsNullOrEmpty(time)) {
        _time = time;
    }
    setInterval(Toploadinghide, _time);

}
function Toploadinghide() {
    //top.$("#Toploading").hide();
}
function BeautifulGreetings() {
    var now = new Date();
    var hour = now.getHours();
    if (hour < 3) { return ("夜深了,早点休息吧！") }
    else if (hour < 9) { return ("早上好！") }
    else if (hour < 12) { return ("上午好！") }
    else if (hour < 14) { return ("中午好！") }
    else if (hour < 18) { return ("下午好！") }
    else if (hour < 23) { return ("晚上好！") }
    else { return ("夜深了,早点休息吧！") }
}
/**
短暂提示
msg: 显示消息
time：停留时间ms
type：类型 4：成功，5：失败，3：警告
**/
function showTipsMsg(msg, time, type) {
    ZENG.msgbox.show(msg, type, time);
}

function showFaceMsg(msg) {
    art.dialog({
        id: 'faceId',
        title: '温馨提醒',
        content: msg,
        icon: 'face-smile',
        time: 10,
        background: '#000',
        opacity: 0.1,
        lock: true,
        okVal: '关闭',
        ok: true
    });
}
function showWarningMsg(msg) {
    art.dialog({
        id: 'warningId',
        title: '系统提示',
        content: msg,
        icon: 'warning',
        time: 10,
        background: '#000',
        opacity: 0.1,
        lock: true,
        okVal: '关闭',
        ok: true
    });
}
/**
警告提示
msg: 显示消息
callBack：函数
**/
function showConfirmMsg(msg, callBack) {
    art.dialog({
        id: 'confirmId',
        title: '系统提示',
        content: msg,
        icon: 'warning',
        background: '#000000',
        opacity: 0.1,
        lock: true,
        button: [{
            name: '确定',
            callback: function () {
                callBack(true);
            },
            focus: true
        }, {
            name: '取消',
            callback: function () {
                this.close();
                return false;
            }
        }]
    });
}
function showConfirmMsgWithSeting(msg, sucessBtnName, cancelBtnName, sucessCallBack, cancelCallBack) {
    art.dialog({
        id: 'confirmId',
        title: '系统提示',
        content: msg,
        icon: 'warning',
        background: '#000000',
        opacity: 0.1,
        lock: true,
        button: [{
            name: sucessBtnName,
            callback: function () {
                sucessCallBack(this);
            },
            focus: true
        }, {
            name: cancelBtnName,
            callback: function () {
                cancelCallBack(this);
            }
        }]
    });
}
/*弹出网页
/*url:          表示请求路径
/*_id:          ID
/*_title:       标题名称
/*width:        宽度
/*height:       高度
---------------------------------------------------*/
function openDialog(url, _id, _title, _width, _height, left, top, resizeEnable) {
    if (resizeEnable == undefined || resizeEnable == "")
        resizeEnable = false;
    art.dialog.open(url, {
        id: _id,
        title: _title,
        width: _width,
        height: _height,
        left: left + '%',
        top: top + '%',
        background: '#000000',
        opacity: 0.1,
        lock: true,
        resize: resizeEnable,
        close: function () { }
    }, false);
}
//窗口关闭
function OpenClose() {
    art.dialog.close();
}
/*验证
/*id:        表示请求
--------------------------------------------------*/
function IsEditdata(id) {
    var isOK = true;
    if (id == undefined || id == "") {
        isOK = false;
        showWarningMsg("未选中任何一行");
    } else if (id.split(",").length > 1) {
        isOK = false;
        showFaceMsg("一次只能选择一条记录");
    }
    return isOK;
}
function IsDelData(id) {
    var isOK = true;
    if (id == undefined || id == "") {
        isOK = false;
        showWarningMsg("未选中任何一行");
    }
    return isOK;
}
function IsNullOrEmpty(str) {
    var isOK = true;
    if (str == undefined || str == "") {
        isOK = false;
    }
    return isOK;
}
/*数据放入回收站
/*url:        表示请求路径
/*parm：      条件参数
--------------------------------------------------*/
function delConfig(url, parm) {
    showConfirmMsg('注：您确认要把此数据放入回收站吗？', function (r) {
        if (r) {
            getAjax(url, parm, function (rs) {
                if (parseInt(rs) > 0) {
                    showTipsMsg("删除成功！", 2000, 4);
                    windowload();
                } else if (parseInt(rs) == 0) {
                    showTipsMsg("删除失败，0 行受影响！", 3000, 3);
                }
                else {
                    showTipsMsg("<span style='color:red'>删除失败，请稍后重试！</span>", 4000, 5);
                }
            });
        }
    });
}
/*删除数据
/*url:        表示请求路径
/*parm：      条件参数
--------------------------------------------------*/
function DeleteData(url, parm) {
    showConfirmMsg("此操作不可恢复，您确定要删除吗？", function (r) {
        if (r) {
            getAjax(url, parm, function (rs) {
                if (parseInt(rs) > 0) {
                    showTipsMsg("删除成功！", 2000, 4);
                    windowload();
                } else if (parseInt(rs) == 0) {
                    showTipsMsg("删除失败，0 行受影响！", 3000, 3);
                }
                else {
                    showTipsMsg("<span style='color:red'>删除失败，请稍后重试！</span>", 4000, 5);
                }
            });
        }
    });
}
/*验证数据是否存在
/*url:        表示请求路径
/*parm：      条件参数
--------------------------------------------------*/
function IsExist_Data(url, parm) {
    var num = 0;
    getAjax(url, parm, function (rs) {
        num = parseInt(rs);
    });
    return num;
}
/* 请求Ajax 带返回值，并弹出提示框提醒
--------------------------------------------------*/
function getAjax(url, parm, callBack) {
    $.ajax({
        type: 'post',
        dataType: "text",
        url: url,
        data: parm,
        cache: false,
        async: false,
        success: function (msg) {
            callBack(msg);
        }
    });
}
/**
数据验证完整性
**/
function CheckDataValid(id) {
    if (!JudgeValidate(id)) {
        return false;
    } else {
        return true;
    }
}
/**
文本框，下拉框输入事件
作用是，如果没有对表单值更新，就不提交到数据库
**/
var haveinputValue = "";
function Haveinput() {
    $("textarea,input[type='text']").keydown(function () {
        haveinputValue = 1;
    })
    $("select").change(function () {
        haveinputValue = 1;
    });
}
/********
接收地址栏参数
key:参数名称
**********/
function GetQuery(key) {
    var search = location.search.slice(1); //得到get方式提交的查询字符串
    var arr = search.split("&");
    for (var i = 0; i < arr.length; i++) {
        var ar = arr[i].split("=");
        if (ar[0] == key) {
            return ar[1];
        }
    }
}
/**
文本框只允许输入数字
**/
function Keypress(obj) {
    $("#" + obj).bind("contextmenu", function () {
        return false;
    });
    $("#" + obj).css('ime-mode', 'disabled');
    $("#" + obj).keypress(function (e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            return false;
        }
    });
}
/**
获取选中复选框值
值：1,2,3,4
**/
function CheckboxValue() {
    var reVal = '';
    $('[type = checkbox]').each(function () {
        if ($(this).attr("checked")) {
            reVal += $(this).val() + ",";
        }
    });
    reVal = reVal.substr(0, reVal.length - 1);
    return reVal;
}
/**
Table固定表头
gv:             table id
scrollHeight:   高度
**/
function FixedTableHeader(gv, scrollHeight) {
    var gvn = $(gv).clone(true).removeAttr("id");
    $(gvn).find("tr:not(:first)").remove();
    $(gv).before(gvn);
    $(gv).find("tr:first").remove();
    $(gv).wrap("<div id='FixedTable' style='width:auto;height:" + scrollHeight + "px;overflow-y: auto; overflow-x: hidden;scrollbar-face-color: #e4e4e4;scrollbar-heightlight-color: #f0f0f0;scrollbar-3dlight-color: #d6d6d6;scrollbar-arrow-color: #240024;scrollbar-darkshadow-color: #d6d6d6; padding: 0;margin: 0;'></div>");
    var lie = $(gvn).find('thead').find("td").length - 1;
    var arr = $(gvn).find('thead').find("td");
    if ($("#FixedTable").height() > scrollHeight) {
        var lastwidth = $(arr[lie]).width() + 17;
        $(arr[lie]).attr('style', 'width:' + lastwidth + 'px;border-right: 0px');
    } else {
        $(arr[lie]).attr('style', 'border-right: 0px')
    }
}
/**.div-body 自应表格高度**/
function divresize(height) {
    resizeU();
    $(window).resize(resizeU);
    function resizeU() {
        $(".div-body").css("height", $(window).height() - height);
    }
}
//Tab标签切换
function GetTabClick(e) {
    ////Loading(true);
    $("#menutab div").each(function () {
        this.className = "Tabremovesel";
    });
    e.className = "Tabsel";
    ////Loading(false);
}
/**
初始化样式
**/
function publicobjcss() {
    /*****************普通表格********************************/
    $('.grid tr').hover(function () {
        $(this).addClass("trhover");
    }, function () {
        $(this).removeClass("trhover");
    });
    $('.grid tbody tr:odd').addClass('alt');
    if ($('.grid').attr('singleselect') == 'true') {
        $('.grid tr td').click(function (e) {
            if ($(this).parents('tr').find("td").hasClass('selected')) {
                $('.grid tr td').parents('tr').find("td").removeClass('selected');
                $('.grid tr td').parents('tr').find('input[type="checkbox"]').removeAttr('checked');
            } else {
                $('.grid tr td').parents('tr').find("td").removeClass('selected');
                $('.grid tr td').parents('tr').find('input[type="checkbox"]').removeAttr('checked');
                $(this).parents('tr').find("td").addClass('selected');
                $(this).parents('tr').find('input[type="checkbox"]').attr('checked', 'checked');
            }
        });
    } else {
        $('.grid tr td').click(function (e) {
            if (!$(this).hasClass('oper')) {
                if ($(this).parents('tr').find("td").hasClass('selected')) {
                    $(this).parents('tr').find("td").removeClass('selected');
                    $(this).parents('tr').find('input[type="checkbox"]').removeAttr('checked');
                } else {
                    $(this).parents('tr').find("td").addClass('selected');
                    $(this).parents('tr').find('input[type="checkbox"]').attr('checked', 'checked');
                }
            }
        });
    }
    /*****************树表格********************************/
    $('#dnd-example tbody tr:odd').addClass('alt');
    $("#dnd-example tr").click(function () {
        $('#dnd-example tr').removeClass("selected");
        $(this).addClass("selected"); //添加选中样式   
    })
    /*****************按钮********************************/
    $(".l-btn").hover(function () {
        $(this).addClass("l-btnhover");
        $(this).find('span').addClass("l-btn-lefthover");
    }, function () {
        $(this).removeClass("l-btnhover");
        $(this).find('span').removeClass("l-btn-lefthover");
    });
}
/*****************树形样式********************************/
function treeAttrCss() {
    $('.strTree').lightTreeview({
        collapse: true,
        line: true,
        nodeEvent: false,
        unique: false,
        style: 'black',
        animate: 100,
        fileico: false,
        folderico: true
    });
    treeCss();
}
function treeCss() {
    $(".strTree li div").css("cursor", "pointer");
    $(".strTree li div").click(function () {
        if ($(this).attr('class') == "" || $(this).attr('class') == undefined) {
            $(".strTree li div").removeClass("collapsableselected");
            $(this).addClass("collapsableselected"); //添加选中样式
        }
    })
}
/**********复选框 全选/反选**************/
var CheckAllLinestatus = 0;
function CheckAllLine() {
    if (CheckAllLinestatus == 0) {
        CheckAllLinestatus = 1;
        $("#checkAllOff").attr('title', '反选');
        $("#checkAllOff").attr('id', 'checkAllOn');
        $(".grid :checkbox").attr("checked", true);
        $('.grid tr').find('td').addClass('selected');
        $("#dnd-example :checkbox").attr("checked", true);
        $('#dnd-example tr').find('td').addClass('selected');
    } else {
        CheckAllLinestatus = 0;
        $("#checkAllOn").attr('title', '全选');
        $("#checkAllOn").attr('id', 'checkAllOff');
        $(".grid :checkbox").attr("checked", false);
        $('.grid tr').find('td').removeClass('selected');
        $("#dnd-example :checkbox").attr("checked", false);
        $('#dnd-example tr').find('td').removeClass('selected');
    }
}
///防止重复提交
function SubmitCheckForRC() {
    $("#Save .l-btn-left").html('<img src="/Themes/Images/loading1.gif" alt="" />正在提交');
    $("#Save").attr('disabled', "true");
    $("#Close").hide();
}
///清空防止重复提交
function SubmitCheckEmpty() {
    $("#Save").removeAttr("disabled")
    $("#Save .l-btn-left").html('<img src="/Themes/Images/disk.png" alt="" />保 存');
    $("#Close").show();
}
//树表格复选框，点击子，把父也打勾
function ckbValueObj(e) {
    var item_id = '';
    var arry = new Array();
    arry = e.split('-');
    for (var i = 0; i < arry.length - 1; i++) {
        item_id += arry[i] + '-';
    }
    item_id = item_id.substr(0, item_id.length - 1);
    if (item_id != "") {
        $("#" + item_id).attr("checked", true);
        ckbValueObj(item_id);
    }
}

/* 
    功能：将货币数字（阿拉伯数字）(小写)转化成中文(大写） 
    
    参数：Num为字符型,小数点之后保留两位,例：numtochinese('123.12')
    说明：1.目前本转换仅支持到 拾亿（元） 位，金额单位为元，不能为万元，最小单位为分 
          2.不支持负数 
*/
function numtochinese(Num) {
    for (i = Num.length - 1; i >= 0; i--) {
        Num = Num.replace(",", "")//替换tomoney()中的“,” 
        Num = Num.replace(" ", "")//替换tomoney()中的空格 
    }

    Num = Num.replace("￥", "")//替换掉可能出现的￥字符 
    if (isNaN(Num)) {
        //验证输入的字符是否为数字 
        alert("请检查小写金额是否正确");
        return;
    }
    //---字符处理完毕，开始转换，转换采用前后两部分分别转换---// 
    part = String(Num).split(".");
    newchar = "";
    //小数点前进行转化 
    for (i = part[0].length - 1; i >= 0; i--) {
        if (part[0].length > 10) { alert("位数过大，无法计算"); return ""; }//若数量超过拾亿单位，提示 
        tmpnewchar = ""
        perchar = part[0].charAt(i);
        switch (perchar) {
            case "0": tmpnewchar = "零" + tmpnewchar; break;
            case "1": tmpnewchar = "壹" + tmpnewchar; break;
            case "2": tmpnewchar = "贰" + tmpnewchar; break;
            case "3": tmpnewchar = "叁" + tmpnewchar; break;
            case "4": tmpnewchar = "肆" + tmpnewchar; break;
            case "5": tmpnewchar = "伍" + tmpnewchar; break;
            case "6": tmpnewchar = "陆" + tmpnewchar; break;
            case "7": tmpnewchar = "柒" + tmpnewchar; break;
            case "8": tmpnewchar = "捌" + tmpnewchar; break;
            case "9": tmpnewchar = "玖" + tmpnewchar; break;
        }
        switch (part[0].length - i - 1) {
            case 0: tmpnewchar = tmpnewchar + "元"; break;
            case 1: if (perchar != 0) tmpnewchar = tmpnewchar + "拾"; break;
            case 2: if (perchar != 0) tmpnewchar = tmpnewchar + "佰"; break;
            case 3: if (perchar != 0) tmpnewchar = tmpnewchar + "仟"; break;
            case 4: tmpnewchar = tmpnewchar + "万"; break;
            case 5: if (perchar != 0) tmpnewchar = tmpnewchar + "拾"; break;
            case 6: if (perchar != 0) tmpnewchar = tmpnewchar + "佰"; break;
            case 7: if (perchar != 0) tmpnewchar = tmpnewchar + "仟"; break;
            case 8: tmpnewchar = tmpnewchar + "亿"; break;
            case 9: tmpnewchar = tmpnewchar + "拾"; break;
        }
        newchar = tmpnewchar + newchar;
    }
    //小数点之后进行转化 
    if (Num.indexOf(".") != -1) {
        if (part[1].length > 2) {
            alert("小数点之后只能保留两位,系统将自动截段");
            part[1] = part[1].substr(0, 2)
        }
        for (i = 0; i < part[1].length; i++) {
            tmpnewchar = ""
            perchar = part[1].charAt(i)
            switch (perchar) {
                case "0": tmpnewchar = "零" + tmpnewchar; break;
                case "1": tmpnewchar = "壹" + tmpnewchar; break;
                case "2": tmpnewchar = "贰" + tmpnewchar; break;
                case "3": tmpnewchar = "叁" + tmpnewchar; break;
                case "4": tmpnewchar = "肆" + tmpnewchar; break;
                case "5": tmpnewchar = "伍" + tmpnewchar; break;
                case "6": tmpnewchar = "陆" + tmpnewchar; break;
                case "7": tmpnewchar = "柒" + tmpnewchar; break;
                case "8": tmpnewchar = "捌" + tmpnewchar; break;
                case "9": tmpnewchar = "玖" + tmpnewchar; break;
            }
            if (i == 0) tmpnewchar = tmpnewchar + "角";
            if (i == 1) tmpnewchar = tmpnewchar + "分";
            newchar = newchar + tmpnewchar;
        }
    }
    //替换所有无用汉字 
    while (newchar.search("零零") != -1)
        newchar = newchar.replace("零零", "零");
    newchar = newchar.replace("零亿", "亿");
    newchar = newchar.replace("亿万", "亿");
    newchar = newchar.replace("零万", "万");
    newchar = newchar.replace("零元", "元");
    newchar = newchar.replace("零角", "");
    newchar = newchar.replace("零分", "");

    if (newchar.charAt(newchar.length - 1) == "元" || newchar.charAt(newchar.length - 1) == "角")
        newchar = newchar + "整"
    return newchar;
}

function checkValid() {
    return CheckDataValid('#form1');
}

function onlyNum(obj) {
    var type = "^[0-9]*$";
    var re = new RegExp(type);
    if ($(obj).val().match(re) == null) {
        $(obj).val("");
    }
}

function onlyMathNumber() {
    if ((event.keyCode < 48 || event.keyCode > 57) && event.keyCode != 46)
        return false;
}

//设置导航条事件
function toggleNavigator() {
    var naviDiv = $("#divLeftNavigatorLine");

    if (naviDiv == undefined) return;
    $(naviDiv).css("height", (window.screen.availHeight - 185) + "px");
    $(naviDiv).attr("title", "收起左侧导航");
    $(naviDiv).toggle(function () {
        $(naviDiv).removeClass("divLeftNavigator");
        $(naviDiv).addClass("divLeftNavigator01");
        $(naviDiv).attr("title", "展开左侧导航");
        var leftFrame = window.parent.document.getElementById("bottomFrameset");
        if (leftFrame != undefined)
            leftFrame.cols = "0,*";
        //window.parent.document.getElementById("bottomFrameset").cols = "0,*";
    }, function () {
        $(naviDiv).removeClass("divLeftNavigator01");
        $(naviDiv).addClass("divLeftNavigator");
        $(naviDiv).attr("title", "收起左侧导航");
        var leftFrame = window.parent.document.getElementById("bottomFrameset");
        if (leftFrame != undefined)
            leftFrame.cols = "132,*";
        //window.parent.document.getElementById("bottomFrameset").cols = "132,*";
    });
}

//打印页面
function pintHmtl(printDivID, exceptControlIDStr) {
    var exceptArray = new Array();
    if (exceptControlIDStr != undefined)
        exceptArray = exceptControlIDStr.split(",");
    var originalHtml = $(document)[0].body.innerHTML;
    var textArray = new Array();
    var i = 0;
    $.each($("#" + printDivID).find("input:text"), function () {
        textArray[i] = { ID: $(this).attr("id"), Value: $(this).val() };
        $(this).addClass("NoneBorder");
        i++;
    });
    $("#" + printDivID).find("textarea").addClass("NoneBorder");
    $("#" + printDivID).find("select").addClass("NoneBorder");
    $.each(exceptArray, function () {
        $(this).hide();
    });
    window.document.body.innerHTML = $("#" + printDivID).html();
    $.each(textArray, function () {
        $("#" + this.ID).val(this.Value);
    });
    window.print();
    window.document.body.innerHTML = originalHtml;
    $.each(textArray, function () {
        $("#" + this.ID).val(this.Value);
    });
}

function checkNumRange(txtControl,startNum,endNum) {
    if (isNaN(txtControl.value) == false) {
        var currentNum = Number(txtControl.value);
        if (currentNum < startNum || currentNum > endNum) {
            showWarningMsg("数值不在范围之内。");
            txtControl.value = "";
            txtControl.focus();
            return false;
        }
    }
    else
        return false;
}

function setFormDisabled(exceptArray,formID)
{
    if (formID == undefined || formID == "")
        formID = "#form1";
    setControlDisabled($(formID).find("input"), exceptArray);
    setControlDisabled($(formID).find("select"), exceptArray);
    setControlDisabled($(formID).find("textarea"), exceptArray);
}

function setControlDisabled(contorls,exceptArray) {
    $.each(contorls, function (i, item) {
        var flag = false;
        if (exceptArray != undefined) {
            $.each(exceptArray, function (index, child) {
                if (child == $(item).attr("id")) {
                    flag = true;
                    return false;
                }
            });
        }
        if (flag == false)
            $(this).attr("disabled", "disabled");
    });
}

//文本框内不准含有特殊字符
function checkForms(txt_Arry) {
    var regArray = new Array("◎", "■", "●", "№", "①", "②", "③", "④", "⑤", "⑥", "⑦", "⑧", "⑨", "⑩", +
    "~", "`", "!", "！", "@", "#", "$", "￥", "%", "^", "“", "”", "&", "*", "（", "）", "(", ")", "_", "+", "=", "|", "＼", "[", "]", "？", +
    "<", ">", "‰", "→", "←", "↑", "↓", "¤", "§", "＃", "＆", "≡", "≠", "/", "，", "。", +
    "≈", "∈", "∪", "∏", "∑", "∧", "∨", "⊥", "‖", "∠", "⊙", "≌", "≌", "√", "∝", "∞", "∮", +
    "∫", "≯", "≮", "＞", "≥", "≤", "≠", "±", "＋", "÷", "×", "/", "Ⅱ", "Ⅰ", "Ⅲ", "Ⅳ", "Ⅴ", "Ⅵ", "Ⅶ", "Ⅷ", "Ⅹ", "Ⅻ", +
    "╄", "╅", "╇", "┻", "┇", "┭", "┷", "┦", "┣", "┝", "┤", "┷", "┹", "╉", "╇", "【", "】", +
    "┌", "├", "┬", "┼", "┍", "┕", "┗", "┏", "┅", "—", "〖", "〗", "〓", "☆", "□", "◇", "＾", +
    "＠", "△", "▲", "＃", "℃", "※", ".", "￠");

    var i = j = 0;
    for (i = 0; i < txt_Arry.length; i++) {
        var txtval = $(txt_Arry[i]).val();
        for (j = 1; j <= regArray.length; j++) {
            if (txtval != undefined && txtval != "") {
                if (txtval.indexOf(regArray[j]) != -1) {
                    alert("输入框内不可以包含：" + regArray[j]);
                    $(txt_Arry[i]).focus();
                    return false;
                }
            }
        }
    }

    return true;
}

String.prototype.trim = function () {
    return this.replace(/(^\s*)|(\s*$)/g, "");
}

function checkChinese(objValue)
{
    var reg=/[^\x00-\xff]/g;//Unicode编码中的汉字范围
    return reg.test(objValue);
}

//生成GUID
function generateGuidStr() {
    var guid = "";
    for (var i = 1; i <= 32; i++) {
        var n = Math.floor(Math.random() * 16.0).toString(16);
        guid += n;
        if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
            guid += "-";
    }
    return guid;
}

function Clock() {
    var date = new Date();
    this.year = date.getFullYear();
    this.month = date.getMonth() + 1;
    this.date = date.getDate();
    this.day = new Array("星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六")[date.getDay()];
    this.hour = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
    this.minute = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
    this.second = date.getSeconds() < 10 ? "0" + date.getSeconds() : date.getSeconds();

    this.toString = function () {
        return "现在是:" + this.year + "年" + this.month + "月" + this.date + "日 " + this.hour + ":" + this.minute + ":" + this.second + " " + this.day;
    };

    this.toSimpleDate = function () {
        return this.year + "-" + this.month + "-" + this.date;
    };

    this.toDetailDate = function () {
        return this.year + "-" + this.month + "-" + this.date + " " + this.hour + ":" + this.minute + ":" + this.second;
    };

    this.display = function (ele) {
        var clock = new Clock();
        ele.innerHTML = clock.toString();
        window.setTimeout(function () { clock.display(ele); }, 1000);
    };
}

//资金数千位符分割
function ZiJin2format(n, sep, decimals) {
    sep = sep || "."; // Default to period as decimal separator
    decimals = decimals || 2; // Default to 2 decimals
    
    return n.toLocaleString().split(sep)[0] + sep + n.toFixed(decimals).split(sep)[1];
}

//获取URL的参数值
function getQueryStringV(vhref, name) {
    // 如果链接没有参数，或者链接中不存在我们要获取的参数，直接返回空 
    if (vhref.indexOf("?") == -1 || vhref.indexOf(name + '=') == -1) {
        return '';
    }
    // 获取链接中参数部分 
    var queryString = vhref.substring(vhref.indexOf("?") + 1);
    // 分离参数对 ?key=value&key2=value2 
    var parameters = queryString.split("&");
    var pos, paraName, paraValue;
    for (var i = 0; i < parameters.length; i++) {
        // 获取等号位置 
        pos = parameters[i].indexOf('=');
        if (pos == -1) {
            continue;
        }
        // 获取name 和 value 
        paraName = parameters[i].substring(0, pos);
        paraValue = parameters[i].substring(pos + 1);

        if (paraName == name) {
            return encodeURI(paraValue.replace(/\+/g, " "));
        }
    }

    return '';
}

/*
    @function     JsonSort 对json排序
    @param        json     用来排序的json
    @param        key      排序的键值
*/
function JsonSort(json, key) {
    for (var j = 1, jl = json.length; j < jl; j++) {
        var temp = json[j],
            val = temp[key],
            i = j - 1;
        while (i >= 0 && json[i][key] > val) {
            json[i + 1] = json[i];
            i = i - 1;
        }
        json[i + 1] = temp;

    }

    return json;

}