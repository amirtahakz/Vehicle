$(function () {
    var url = window.location.pathname,
        urlRegExp = new RegExp(url.replace(/\/$/, '') + "$");
    $('#side-nav-secretary li a').each(function () {
        if (urlRegExp.test(this.href.replace(/\/$/, ''))) {
            $('#side-nav-secretary li .active').removeClass('active');
            $(this).addClass('active');
        }
    });
});


