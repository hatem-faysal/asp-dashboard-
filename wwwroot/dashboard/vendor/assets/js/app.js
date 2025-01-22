$(function () {
    "use strict";
    
    new PerfectScrollbar(".header-message-list"), new PerfectScrollbar(".header-notifications-list"), $(".mobile-search-icon").on("click", function () {
        $(".search-bar").addClass("full-search-bar")
    }), $(".search-close").on("click", function () {
        $(".search-bar").removeClass("full-search-bar")
    }), $(".mobile-toggle-menu").on("click", function () {
        $(".wrapper").addClass("toggled")
    }), $(".toggle-icon").click(function () {
        $(".wrapper").hasClass("toggled") ? ($(".wrapper").removeClass("toggled"), $(".sidebar-wrapper").unbind("hover")) : ($(".wrapper").addClass("toggled"), $(".sidebar-wrapper").hover(function () {
            $(".wrapper").addClass("sidebar-hovered")
        }, function () {
            $(".wrapper").removeClass("sidebar-hovered")
        }))
    }), $(document).ready(function () {
        $(window).on("scroll", function () {
            $(this).scrollTop() > 300 ? $(".back-to-top").fadeIn() : $(".back-to-top").fadeOut()
        }), $(".back-to-top").on("click", function () {
            return $("html, body").animate({
                scrollTop: 0
            }, 600), !1
        })
    }), $(function () {
        for (var e = window.location, o = $(".metismenu li a").filter(function () {
                return this.href == e
            }).addClass("").parent().addClass("mm-active"); o.is("li");) o = o.parent("").addClass("mm-show").parent("").addClass("mm-active")
    }), $(function () {
        $("#menu").metisMenu()
    }), $(".chat-toggle-btn").on("click", function () {
        $(".chat-wrapper").toggleClass("chat-toggled")
    }), $(".chat-toggle-btn-mobile").on("click", function () {
        $(".chat-wrapper").removeClass("chat-toggled")
    }), $(".email-toggle-btn").on("click", function () {
        $(".email-wrapper").toggleClass("email-toggled")
    }), $(".email-toggle-btn-mobile").on("click", function () {
        $(".email-wrapper").removeClass("email-toggled")
    }), $(".compose-mail-btn").on("click", function () {
        $(".compose-mail-popup").show()
    }), $(".compose-mail-close").on("click", function () {
        $(".compose-mail-popup").hide()
    }), $(".switcher-btn").on("click", function () {
        $(".switcher-wrapper").toggleClass("switcher-toggled")
    }), $(".close-switcher").on("click", function () {
        $(".switcher-wrapper").removeClass("switcher-toggled")
    }), $("#lightmode").on("click", function () {
        $("html").attr("class", "light-theme")
             localStorage.setItem('lightTheme', 'light-theme')
             localStorage.removeItem('semi-dark');
             localStorage.removeItem('minimaltheme');
             localStorage.removeItem('darkmode');
    }), $("#darkmode").on("click", function () {
        $("html").attr("class", "dark-theme")
                localStorage.setItem('darkmode', 'dark-theme')
                          localStorage.removeItem('minimaltheme');
    }), $("#semidark").on("click", function () {
        $("html").attr("class", "semi-dark")
             localStorage.setItem('semi-dark', 'semi-dark')
             localStorage.removeItem('minimaltheme');
             localStorage.removeItem('darkmode');

    }), $("#minimaltheme").on("click", function () {
        $("html").attr("class", "minimal-theme")
        localStorage.setItem('minimaltheme', 'minimal-theme')
                        localStorage.removeItem('darkmode');
    }), $("#headercolor1").on("click", function () {
        $("html").addClass("color-header headercolor1"), $("html").removeClass("headercolor2 headercolor3 headercolor4 headercolor5 headercolor6 headercolor7 headercolor8");
        localStorage.setItem('header1', 'color-header headercolor1');
        localStorage.setItem('removeheader1', 'headercolor2 headercolor3 headercolor4 headercolor5 headercolor6 headercolor7 headercolor8');
    }), $("#headercolor2").on("click", function () {
        $("html").addClass("color-header headercolor2"), $("html").removeClass("headercolor1 headercolor3 headercolor4 headercolor5 headercolor6 headercolor7 headercolor8")
        localStorage.setItem('header1', 'color-header headercolor2');
        localStorage.setItem('removeheader1', 'headercolor1 headercolor3 headercolor4 headercolor5 headercolor6 headercolor7 headercolor8');
    }), $("#headercolor3").on("click", function () {
        $("html").addClass("color-header headercolor3"), $("html").removeClass("headercolor1 headercolor2 headercolor4 headercolor5 headercolor6 headercolor7 headercolor8")
        localStorage.setItem('header1', 'color-header headercolor3');
        localStorage.setItem('removeheader1', 'headercolor1 headercolor2 headercolor4 headercolor5 headercolor6 headercolor7 headercolor8');
    }), $("#headercolor4").on("click", function () {
        $("html").addClass("color-header headercolor4"), $("html").removeClass("headercolor1 headercolor2 headercolor3 headercolor5 headercolor6 headercolor7 headercolor8")
        localStorage.setItem('header1', 'color-header headercolor4');
        localStorage.setItem('removeheader1', 'headercolor1 headercolor2 headercolor3 headercolor5 headercolor6 headercolor7 headercolor8');
    }), $("#headercolor5").on("click", function () {
        $("html").addClass("color-header headercolor5"), $("html").removeClass("headercolor1 headercolor2 headercolor4 headercolor3 headercolor6 headercolor7 headercolor8")
        localStorage.setItem('header1', 'color-header headercolor5');
        localStorage.setItem('removeheader1', 'headercolor1 headercolor2 headercolor4 headercolor3 headercolor6 headercolor7 headercolor8');
    }), $("#headercolor6").on("click", function () {
        $("html").addClass("color-header headercolor6"), $("html").removeClass("headercolor1 headercolor2 headercolor4 headercolor5 headercolor3 headercolor7 headercolor8")
        localStorage.setItem('header1', 'color-header headercolor6');
        localStorage.setItem('removeheader1', 'headercolor1 headercolor2 headercolor4 headercolor5 headercolor3 headercolor7 headercolor8');
    }), $("#headercolor7").on("click", function () {
        $("html").addClass("color-header headercolor7"), $("html").removeClass("headercolor1 headercolor2 headercolor4 headercolor5 headercolor6 headercolor3 headercolor8")
        localStorage.setItem('header1', 'color-header headercolor7');
        localStorage.setItem('removeheader1', 'headercolor1 headercolor2 headercolor4 headercolor5 headercolor6 headercolor3 headercolor8');
    }), $("#headercolor8").on("click", function () {
        $("html").addClass("color-header headercolor8"), $("html").removeClass("headercolor1 headercolor2 headercolor4 headercolor5 headercolor6 headercolor7 headercolor3")
        localStorage.setItem('header1', 'color-header headercolor8');
        localStorage.setItem('removeheader1', 'headercolor1 headercolor2 headercolor4 headercolor5 headercolor6 headercolor7 headercolor3');
    }), $("#headercolor9").on("click", function () {
        localStorage.removeItem('header1');
        localStorage.removeItem('removeheader1');
        location.reload(true);
    });




    // headercolor9
    const themePage = localStorage.getItem('themePage');
    if (themePage) {
        $("html").attr("class", themePage);
    }
    // headercolor9
    const header1 = localStorage.getItem('header1');
    const removeheader1 = localStorage.getItem('removeheader1');
    if (header1 && removeheader1) {
        $("html").addClass(header1), $("html").removeClass(removeheader1)
    }




    // }), $("#minimaltheme").on("click", function() {
    // 	$("html").attr("class", "minimal-theme")
    // 	   localStorage.setItem('minimaltheme', 'minimal-theme')
    // sidebar colors 


    $('#sidebarcolor1').click(theme1);
    $('#sidebarcolor2').click(theme2);
    $('#sidebarcolor3').click(theme3);
    $('#sidebarcolor4').click(theme4);
    $('#sidebarcolor5').click(theme5);
    $('#sidebarcolor6').click(theme6);
    $('#sidebarcolor7').click(theme7);
    $('#sidebarcolor8').click(theme8);
    $('#sidebarcolor9').click(theme9);

    function theme1() {
        $('html').attr('class', 'color-sidebar sidebarcolor1');
        localStorage.setItem('theme1', 'color-sidebar sidebarcolor1')
            localStorage.removeItem('minimaltheme');
            localStorage.removeItem('darkmode');
            localStorage.removeItem('semi-dark');
            localStorage.removeItem('lightTheme');
    }

    function theme2() {
        $('html').attr('class', 'color-sidebar sidebarcolor2');
        localStorage.setItem('theme1', 'color-sidebar sidebarcolor2')
            localStorage.removeItem('minimaltheme');
            localStorage.removeItem('darkmode');
            localStorage.removeItem('semi-dark');
            localStorage.removeItem('lightTheme');
    }

    function theme3() {
        $('html').attr('class', 'color-sidebar sidebarcolor3');
        localStorage.setItem('theme1', 'color-sidebar sidebarcolor3')
            localStorage.removeItem('minimaltheme');
            localStorage.removeItem('darkmode');
            localStorage.removeItem('semi-dark');
            localStorage.removeItem('lightTheme');
    }

    function theme4() {
        $('html').attr('class', 'color-sidebar sidebarcolor4');
        localStorage.setItem('theme1', 'color-sidebar sidebarcolor4')
            localStorage.removeItem('minimaltheme');
            localStorage.removeItem('darkmode');
            localStorage.removeItem('semi-dark');
            localStorage.removeItem('lightTheme');
    }

    function theme5() {
        $('html').attr('class', 'color-sidebar sidebarcolor5');
        localStorage.setItem('theme1', 'color-sidebar sidebarcolor5')
            localStorage.removeItem('minimaltheme');
            localStorage.removeItem('darkmode');
            localStorage.removeItem('semi-dark');
            localStorage.removeItem('lightTheme');
    }

    function theme6() {
        $('html').attr('class', 'color-sidebar sidebarcolor6');
        localStorage.setItem('theme1', 'color-sidebar sidebarcolor6')
            localStorage.removeItem('minimaltheme');
            localStorage.removeItem('darkmode');
            localStorage.removeItem('semi-dark');
            localStorage.removeItem('lightTheme');
    }

    function theme7() {
        $('html').attr('class', 'color-sidebar sidebarcolor7');
        localStorage.setItem('theme1', 'color-sidebar sidebarcolor7')
            localStorage.removeItem('minimaltheme');
            localStorage.removeItem('darkmode');
            localStorage.removeItem('semi-dark');
            localStorage.removeItem('lightTheme');
    }

    function theme8() {
        $('html').attr('class', 'color-sidebar sidebarcolor8');
        localStorage.setItem('theme1', 'color-sidebar sidebarcolor8')
            localStorage.removeItem('minimaltheme');
            localStorage.removeItem('darkmode');
            localStorage.removeItem('semi-dark');
            localStorage.removeItem('lightTheme');
    }

    function theme9() {
        $('html').attr('class', 'color-sidebar sidebarcolor9');
        localStorage.setItem('theme1', 'color-sidebar sidebarcolor9')
            localStorage.removeItem('minimaltheme');
            localStorage.removeItem('darkmode');
            localStorage.removeItem('semi-dark');
            localStorage.removeItem('lightTheme');
    }




             
    const lightTheme = localStorage.getItem('lightTheme');
    if (lightTheme) {
                localStorage.removeItem('header1');
                localStorage.removeItem('theme1');
        $('html').attr('class', lightTheme);
       			    $('#lightmode').attr('checked', true); 
    }             
             
    const semidark = localStorage.getItem('semi-dark');
    if (semidark) {
                localStorage.removeItem('header1');
                localStorage.removeItem('theme1');
        $('html').attr('class', semidark);
       			    $('#semidark').attr('checked', true); 
    }

    const minimaltheme = localStorage.getItem('minimaltheme');
    if (minimaltheme) {
                localStorage.removeItem('header1');
                localStorage.removeItem('theme1');
        $('html').attr('class', minimaltheme);
       			    $('#minimaltheme').attr('checked', true); 
    }
      
    
    
    const darkmode = localStorage.getItem('darkmode');
    if (darkmode) {
                localStorage.removeItem('header1');
                localStorage.removeItem('theme1');
        $('html').attr('class', darkmode);
       			    $('#darkmode').attr('checked', true); 
    }



    const getColor = localStorage.getItem('theme1');
    if (getColor) {
        $('html').attr('class', getColor);
    }


    const $header = localStorage.getItem('header1');
    if ($header) {
        $('html').addClass($header);
    }
    


});
