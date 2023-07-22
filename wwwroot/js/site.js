// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//это всплывающие сообщения
window.setTimeout(function () {
    $(".alert").fadeTo(500, 0).slideUp(500, function () {
        $(this).remove();
    });
}, 8000);



// Update the count down every 1 second
var x = setInterval(function () {
    let $elem = document.querySelector('.date1');
    let textByTextContent = $elem.textContent; // 
    
    

    // Output the result in an element with id="demo"
    document.getElementById($elem.textContent).innerHTML;

    
    }
}, 1000);
