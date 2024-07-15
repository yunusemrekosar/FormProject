//$(document).ready(function () {
//    $("#ChangeBtn").on('click', function () {
//        $("#RegisterForm").toggleClass("d-none");
//        $("#LoginForm").toggleClass("d-none");
//    });
//});


function ChangeScreen() {
    $("#RegisterForm").toggleClass("d-none");
    $("#LoginForm").toggleClass("d-none");

    if ($("#title").text() == "Oturum Aç") {
        $("#title").text("Kayıt Ol")
    }
    else {
        $("#title").text("Oturum Aç")
    }
}