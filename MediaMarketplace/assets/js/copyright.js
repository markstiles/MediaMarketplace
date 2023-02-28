jQuery.noConflict();

jQuery(document).ready(function ()
{  
    //add copyright
    var addCopyright = ".add-copyright";
    var addCopyrightForm = addCopyright + " .form";
    var addCopyrightFormSubmit = addCopyrightForm + " .submit";
    var addCopyrightSubmitSuccess = addCopyright + " .submit-results .success";
    var addCopyrightSubmitFailure = addCopyright + " .submit-results .failure";

    jQuery(addCopyrightFormSubmit).click(function (e)
    {
        e.preventDefault();

        ResetForms();
        AddCopyright();
    });

    function AddCopyright()
    {
        var fileTypeValue = jQuery(addCopyrightForm + " .file-type").val();

        jQuery(progressIndicator).show();

        jQuery.post(
            jQuery(addCopyrightForm).attr("action"),
            {
                File: new FormData(jQuery(addCopyrightForm)[0]),
                FileType: fileTypeValue
            }
        ).done(function (r) {
            jQuery(progressIndicator).hide();

            if (r.Succeeded) {
                jQuery(addCopyrightSubmitSuccess).show();
            }
            else {
                jQuery(addCopyrightSubmitFailure).show();
            }
        });
    }
});