$(document).ready(function () {
    $('.search .search-trigger').click(function () {
        $(this).parent().toggleClass('opened');
        setTimeout(function () {
            $('.search .search-trigger .input-text').focus();
        },1000);
        
    });
});