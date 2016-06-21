$(document).ready(function () {
    // language nav
    $('.intl').click(function () {
        $('.regions').slideToggle(500);
    });
    // get window width.
    var window_width = $(window).width();
    // main nav dropdown
    $('nav li a').mouseenter(function () {
        $(this).next('.child').addClass('active');
    });
    $('.dropdown').mouseleave(function () {
        $('.child').removeClass('active');
    });
    // mobile nav toggle
    $('.navToggle').click(function () {
        $('nav').slideToggle(300);
    });
    $(window).on("resize", function () {
        if ($(window).width() > 908) {
            $('nav').show();
        } else {
            $('nav').hide();
        }
        if ($(window).width() <+ 701) {
            $('header span.glyphicon').removeClass('glyphicon-globe');
            $('header span.glyphicon').addClass('glyphicon-chevron-down');
        }
        if ($(window).width() > 701) {
            $('header span.glyphicon').removeClass('glyphicon-chevron-down');
            $('header span.glyphicon').addClass('glyphicon-globe');
        }

    });
    // enewsletter (footer)
    $('#enews_button').click(function () {
        $('input[name=elqFormName]').attr('value', 'emailsubscribehome')
        $('input[name=LeadSource]').attr('value', 'LCRMAA0001WQ')
        $('#form1').attr('action', 'https://s1966950654.t.eloqua.com/e/f2');
        $('#form1').attr('method', 'post');
        $('#form1').submit();
    });

});

// Get URL Parameters
function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
    results = regex.exec(location.search);
    return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

// Define UTM Variables
var utm_source = getParameterByName('utm_source');
var utm_medium = getParameterByName('utm_medium');
var utm_content = getParameterByName('utm_content');
var utm_campaign = getParameterByName('utm_campaign');
var utm_name = getParameterByName('utm_name');
var utm_term = getParameterByName('utm_term');
// Preload UTM Data for Elq Forms
$(document).ready(function () {
    $('input[name="elq_utm_source"]').attr('value', utm_source);
    $('input[name="elq_utm_medium"]').attr('value', utm_medium);
    $('input[name="elq_utm_content"]').attr('value', utm_content);
    $('input[name="elq_utm_campaign"]').attr('value', utm_campaign);
    $('input[name="elq_utm_name"]').attr('value', utm_name);
    $('input[name="elq_utm_term"]').attr('value', utm_term);
});