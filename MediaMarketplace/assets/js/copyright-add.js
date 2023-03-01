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
        var formData = new FormData(document.getElementById("add-copyright-form"));

        jQuery.ajax({
            type: 'POST',
            url: jQuery(addCopyrightForm).attr("action"),
            data: formData,
            processData: false,
            contentType: false,
            success: function (r)
            {
                jQuery(progressIndicator).hide();

                if (r.Succeeded) {
                    jQuery(addCopyrightForm).find("input[type=text],input[type=file]").val("");
                    jQuery(addCopyrightSubmitSuccess).show();
                }
                else {
                    jQuery(addCopyrightSubmitFailure).text(r.ErrorMessage);
                    jQuery(addCopyrightSubmitFailure).show();
                }
            }
        });
    }
});