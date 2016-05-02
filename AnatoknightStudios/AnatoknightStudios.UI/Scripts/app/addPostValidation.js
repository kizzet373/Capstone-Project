$(document).ready(function () {
    $('#addPost').validate({
        rules: {
            PostTitle: {
                required: true
            },
            PostContent: {
                required: true
            }
        },
        messages: {
            PostTitle: "Enter your blog title",
            PostContent: "Enter your blog content!"
        }
    });
});