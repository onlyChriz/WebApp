document.querySelector('.post-body').addEventListener('click', function (event) {
    var clickedElement = event.target;

    if (clickedElement.classList.contains('post-card')) {
        var postLink = clickedElement.querySelector('a').getAttribute('href');
        navigateToURL(postLink);
    }
});

function navigateToURL(url) {
    window.location.href = url;
}
