$(document).ready(function() {
    $('#btnShowAddPost').click(function() {
        $('#addPostModal').modal('show');
    });
});

//$(document).on('focusin', function (e) {
//    if ($(e.target).closest(".mce-window, .moxman-window").length) {
//        e.stopImmediatePropagation();
//    }
//});

// Open dialog and add tinymce to it
//$('#btnShowAddPost').click(function() {
//    $("#addPostModal").dialog({
//        width: 800,
//        modal: true
//    });

//    $('textarea').tinymce({
//        script_url: 'Scripts/app/TinyMcePage.js',
//        toolbar: 'link',
//        plugins: 'link'
//    });
//});