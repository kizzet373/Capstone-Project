$(document).ready(function () {
    //shows modal
    $('.btnShowDeletePost').click(function () {
        $('#deletePostModal').modal('show');
        //pulls Id from hidden field on index page and passes into button in modal
        $('#Id').val($(this).siblings("input").val());
    });

  });