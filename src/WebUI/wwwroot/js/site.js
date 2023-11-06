// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function confirmDeletion(postId, url) {
    if (confirm('Are you sure you want to delete this post?')) {
        // Отправить POST-запрос на сервер для удаления
        var form = document.createElement('form');
        form.method = 'POST';
        form.action = url;
        form.innerHTML = '<input type="hidden" name="id" value="' + postId + '">';
        document.body.appendChild(form);
        form.submit();
    }
}