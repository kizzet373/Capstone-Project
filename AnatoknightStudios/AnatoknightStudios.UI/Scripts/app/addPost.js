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

    $('#Submit').click(function (e) {
        e.preventDefault();
        var post = {};

        post.PostTitle = $('#PostTitle').val();
        post.PostContent = tinyMCE.activeEditor.getContent({ format: 'raw' });
        post.CategoryId = $('#CategoryId').val();
        post.BlogId = $('#BlogId').val();
        var tagNames = JSON.parse($("input[name='TagBox']").val());
        post.PostTags = [];
        for (var i = 0; i < tagNames.length; i++) {
            var item = { TagName : tagNames[i] };
            post.PostTags.push(item);
        }
        
        $.ajax('/Blog/AddPost', {
            method: "post",
            datatype: "json",
            data: post
        }).done(function () {
                $('#addPostModal').modal('hide');
            });
    });
});

