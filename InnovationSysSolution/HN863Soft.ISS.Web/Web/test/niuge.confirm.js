(function () {
  $.MsgBox = {
    Alert: function (msg) {
      createHtml("alert", msg);
      btnOk(); //alert只是弹出消息，因此没必要用到回调函数callback
      btnNo();
    },
    Confirm: function (msg, callback) {
      createHtml("confirm", msg);
      btnOk(callback);
      btnNo();
    }
  }
 
  //生成Html
  var createHtml = function (type, msg) {
 
    var _html = "";
 
    if (type == "alert") {
		    	 _html += '<div id="mb_box" style="width:100%;height:100%;z-index:1111111111110;position:fixed;filter:alpha(opacity=5);opacity:0.05;background:black;top:0;left:0;"></div><div id="mb_con" style="z-index:1111111111111;position:fixed;background:#000;border-radius:3px;padding:20px 0;font-size:16px;">';
		    
			 
			_html += '<div id="mb_msg" style="text-align:center;padding:0 20px;color:#ffffcc">' + msg + '</div><div id="mb_btnbox" style="text-align:center;">';
     
			$("#mb_box,#mb_con").fadeOut(2500);
			setTimeout(function(){
				$("#mb_box,#mb_con").remove();
			},2500);
    }
    if (type == "confirm") {
	    	 _html += '<div id="mb_box" style="width:100%;height:100%;z-index:1111111111110;position:fixed;filter:alpha(opacity=5);opacity:0.05;background:black;top:0;left:0;"></div><div id="mb_con" style="z-index:1111111111111;position:fixed;background:#fff;border-radius:3px;padding:30px 0;font-size:16px;width:260px;height:140px;">';
	    
		 
		_html += '<div id="mb_msg" style="text-align:center;padding:0 20px;color:#666;margin-bottom:15px;">' + msg + '</div><div id="mb_btnbox" style="text-align:center;">';
      _html += '<input class="btn-css" id="mb_btn_ok" type="button" value="确定" style="width:85px;height:26px;background:#fff;color:#679CD2;border-radius:3px;border:1px #679CD2 solid;margin-top:10px;">';
      _html += '<input class="btn-css" id="mb_btn_no" type="button" value="取消" style="width:85px;height:26px;background:#fff;color:#679cd2;border-radius:3px;margin-left:15px;border:1px #679CD2 solid;margin-top:10px;">';
    }
    _html += '</div></div>';
 
    //必须先将_html添加到body，再设置Css样式
    $("body").append(_html); createCss();
  }
 
  //生成Css
  var createCss = function () {
 
    var _widht = document.documentElement.clientWidth; //屏幕宽
    var _height = document.documentElement.clientHeight; //屏幕高
 
    var boxWidth = $("#mb_con").width();
    var boxHeight = $("#mb_con").height();
 
    //让提示框居中
    $("#mb_con").css({ top: (_height - boxHeight) / 2 + "px", left: (_widht - boxWidth) / 2 + "px" });
  }
 
 
  //确定按钮事件
  var btnOk = function (callback) {
    $("#mb_btn_ok").click(function () {
      $("#mb_box,#mb_con").remove();
      if (typeof (callback) == 'function') {
        callback();
      }
    });
  }
 
  //取消按钮事件
  var btnNo = function () {
    $("#mb_btn_no,#mb_ico").click(function () {
      $("#mb_box,#mb_con").remove();
    });
  }
})();