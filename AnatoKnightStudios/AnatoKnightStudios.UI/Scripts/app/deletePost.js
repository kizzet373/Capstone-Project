$(document).ready(function() {
    $('.btnShowDeletePost').click(function() {
        $('#deletePostModal').modal('show');
        $('#Id').val($(this).siblings("input").val());
    });

  });