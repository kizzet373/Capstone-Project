$(document).ready(function() {
    $('#btnShowAddPost').click(function() {
        $('#addPostModal').modal('show');
        $('#BlogId').val($(this).siblings("input").val());
    });

    $("#addPostModal").on("shown", function() {
        tinyMCE.init({
            mode: "none",
            theme: "simple"
        });
    });

    $('#Submit').click(function () {
        var post = {};

        post.PostTitle = $('#PostTitle').val();
        post.PostContent = $('#PostContent').val();

        $.post(post)
            .done(function () {
                $('#addPostModal').modal('hide');
            });
    });
});

