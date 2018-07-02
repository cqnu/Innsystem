$(document).ready(function(){var a=responsiveNav("#min-nav");var b=$(window).width();if(b>640){$("#nav>li").hover(function(){$(this).children("ul").stop().fadeToggle(800);$(this).stop().toggleClass("nav-hover")})}$("#weixin").hover(function(){$("#weixin_qr").toggleClass("gaoliang")})
if (navigator.userAgent.toLowerCase().indexOf("chrome") >= 0)
{
  var _interval = window.setInterval(function () {
    var autofills = $('input:-webkit-autofill');
    if (autofills.length > 0) {
      window.clearInterval(_interval); //
      autofills.each(function() {
        var clone = $(this).clone(true, true);
        $(this).after(clone).remove();
      });
    }
  }, 20);
}
});