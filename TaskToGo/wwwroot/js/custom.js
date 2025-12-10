$(document).ready(function () {
    $("#menuToggle").click(function () {
        $(".sidebar").toggleClass("collapsed");
        if ($(".sidebar").hasClass("collapsed")) {
            $(".main-content").css("margin-left", "0");
        } else {
            $(".main-content").css("margin-left", "250px");
        }
    });
});
