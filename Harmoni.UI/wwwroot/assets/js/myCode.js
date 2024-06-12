document.addEventListener("DOMContentLoaded", function() {
    // Get the current URL path
    var currentPath = window.location.pathname;

    // Select all anchor tags within the menu
    var menuLinks = document.querySelectorAll('.menu-item-has-children a');

    // Loop through each anchor tag
    menuLinks.forEach(function(link) {
        // Check if the href attribute matches the current path
        if (link.getAttribute('href') === currentPath) {
            // Add the 'active' class to the parent element with class 'menu-item-has-children'
            link.closest('.menu-item-has-children').classList.add('active');
        }
    });
});