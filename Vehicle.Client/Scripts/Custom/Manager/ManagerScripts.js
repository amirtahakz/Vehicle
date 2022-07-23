$(function () {
    var url = window.location.pathname,
        urlRegExp = new RegExp(url.replace(/\/$/, '') + "$");
    $('#side-nav-manager li a').each(function () {
        if (urlRegExp.test(this.href.replace(/\/$/, ''))) {
            $('#side-nav-manager li .active').removeClass('active');
            $(this).addClass('active');
        }
    });
});