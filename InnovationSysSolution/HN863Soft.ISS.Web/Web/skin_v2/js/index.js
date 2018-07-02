$(document).ready(function() {
    $(window).scroll(function(b) {
        var a = $(this).scrollTop();
        if (a > 0) {
            $("#header").removeClass("nobg")
        } else {
            $("#header").addClass("nobg")
        }
    });
});