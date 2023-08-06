// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//это всплывающие сообщения
window.setTimeout(function () {
    $(".alert").fadeTo(500, 0).slideUp(500, function () {
        $(this).remove();
    });
}, 6000);


@(document).ready(function () {
    setInterval(clock, 1000);
    clock();
})

// Update the count down every 1 second
function clock() {
    
    document.getElementById('time-text').innerHTML(HTMLObjectElement);
}
