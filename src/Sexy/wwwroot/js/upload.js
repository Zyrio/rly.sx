$(document).ready(function () {
    $("#upload").click(function (event) {
        $("#files").click();
        //console.log("Custom upload button clicked");
        $("#files").change(function () {
            //console.log("Click the file input");
            if ($(this).val()) {
                //console.log("File input has changed");
                $("#file-submit").click();
                // or, as has been pointed out elsewhere:
                // $('input:submit').removeAttr('disabled'); 
            }
        });
    });
    $("#file").change(function () {
        //console.log("Click the file input");
        if ($(this).val()) {
            //console.log("File input has changed");
            $("#file-submit").click();
            // or, as has been pointed out elsewhere:
            // $('input:submit').removeAttr('disabled'); 
        }
    });
});