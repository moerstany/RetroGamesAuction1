// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//это всплывающие сообщения
window.setTimeout(function () {
    $(".alert").fadeTo(500, 0).slideUp(500, function () {
        $(this).remove();
    });
}, 6000);




// Update the count down every 1 second

// при наведении мышкой увеличиваем все картинки
$(function () {
    $(".img-fluid").mouseover(function () {
        $(this).animate({ height: '+=6', width: '+=6' });
    });
    $(".img-fluid").mouseout(function () {
        $(this).animate({ height: '-=6', width: '-=6' });
    });
});

$(function () {
    $(".imgpr").mouseover(function () {
        $(this).animate({ height: '+=10', width: '+=10' });
    });
    $(".imgpr").mouseout(function () {
        $(this).animate({ height: '-=10', width: '-=10' });
    });
});

//слайды карусели меняют цвет обводки
$(document).ready(function () {
    $('.TrumbConteiner img').on({
        mousemove: function () {
            $(this).css({
                'cursor': 'pointer',
                'border': '6px solid grey'
            });
        },
        mouseout: function () {
            $(this).css({
                'cursor': 'pointer',
                'border': '6px solid #c0c0c0'
            });
        },
        click: function () {
            var x = $(this).attr('src');
            $('#MainImage').attr('src', x);
        }
    });
});

//пагинация табличек бутстрап
$(document).ready(function () {
    $('#table').DataTable();
});

new DataTable('#table');