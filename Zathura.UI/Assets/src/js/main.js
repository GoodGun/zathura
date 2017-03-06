
$(document).ready(function () {
    innerWidth = window.innerWidth;

    if (innerWidth < 768) {
        $("body").attr("data-device-type","mobile");
    } else if (innerWidth > 767 && innerWidth < 992) {
        $("body").attr("data-device-type", "tablet");
    } else {
        $("body").attr("data-device-type", "web");

        $('.search .search-trigger').click(function () {
            $(this).parent().toggleClass('opened');
            $('.search .search-trigger .input-text').focus();
        });
    }

    if (innerWidth < 992) {
        $(document).on('click', '.mobile-menu-trigger', function () {
            $('.menu-list').toggleClass("opened");
            $(this).toggleClass("opened");
        });
    }

});
