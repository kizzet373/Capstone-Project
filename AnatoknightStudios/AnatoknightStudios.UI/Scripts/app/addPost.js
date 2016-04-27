$(document).ready(function() {
    $('#btnShowAddPost').click(function() {
        $('#addPostModal').modal('show');
    });

    $("#addPostModal").on("shown", function() {
        tinyMCE.init({
            mode: "none",
            theme: "simple"
        });
    });
});

