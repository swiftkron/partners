$(document).ready(function () {
    // Common vars 
    var width = $(window).width();
    // Custom Functions
    $(document).click(function () {
        $('.uDropdown').hide();
    });
    $('.navLink').click(function (event) {
        event.stopPropagation();
        location.href = "http://www.act.com";
    });
    $('#au-nav .navLink').click(function (event) {
        event.stopPropagation();
        location.href = "/au";
    });
    $('#uk-nav .navLink').click(function (event) {
        event.stopPropagation();
        location.href = "/en-gb";
    });
    $('.uIntl').click(function (event) {
        event.stopPropagation();
        $('.lang').slideToggle(400);
    });
    $('.navToggle').click(function (event) {
        event.stopPropagation();
        $('nav').slideToggle(400);
        $('.uAlt').hide();
    });
    $('.uToggle').click(function (event) {
        event.stopPropagation();
        $('.uAlt').slideToggle(400);
    });
});