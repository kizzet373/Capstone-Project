$(document).ready(function () {
    $('.btnShowDeletePost').click(function () {
        $('#deletePostModal').modal('show');
        $('#postToDelete').text($(this).siblings("input").val());
    });

    $('#inputDeletePost').click(function() {
        var post = {};

});