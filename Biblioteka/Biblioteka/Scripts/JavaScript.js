$(document).ready(function () {
    $("#flip").click(function () {
        $("#panel").slideToggle("slow");
    });
});
$().ready(function () {
    $("#StartDate").datepicker();
    $("#EndDate").datepicker();
    return false;
});