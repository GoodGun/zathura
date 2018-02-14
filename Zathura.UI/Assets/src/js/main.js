$(document).ready(function () {

    $(".mobile-menu").click(function () {
        $(this).next(".main-menu").addClass("opened");
    });

    $(".close-menu").click(function () {
        $(".main-menu").removeClass("opened"); 
    });
    
    openSubMenu(".main-menu-item-wrapper", ".wide-menu");
    openSubMenu(".opened .sub-menu-title", ".sub-menu");

    var mySwiper = new Swiper('.main-slider', {
        slidesPerView: 1,
        spaceBetween: 30,
        loop: true,
        pagination: {
            el: '.swiper-pagination',
            clickable: true,
        },
        navigation: {
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev',
        },
        effect: 'fade'
    });

});

function openSubMenu(clicked, opened) {
    $(document).on("click", clicked, function () {
        $(this).next(opened).toggleClass("opened");
    });
}

