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

    //view copyright
    var viewCopyright = ".view-copyright";
    var viewCopyrightForm = viewCopyright + " .form";
    var reactivateCopyrightFormSubmit = viewCopyrightForm + " .reactivate";
    var deactivateCopyrightFormSubmit = viewCopyrightForm + " .deactivate";
    var reactivateCopyrightSubmitSuccess = viewCopyright + " .submit-results .reactivate-copyright-success";
    var reactivateCopyrightSubmitFailure = viewCopyright + " .submit-results .reactivate-copyright-failure";
    var deactivateCopyrightSubmitSuccess = viewCopyright + " .submit-results .deactivate-copyright-success";
    var deactivateCopyrightSubmitFailure = viewCopyright + " .submit-results .deactivate-copyright-failure";

    jQuery(reactivateCopyrightFormSubmit).click(function (e) {
        e.preventDefault();

        var formParent = jQuery(this).closest(".form");

        ResetForms();
        ActivateCopyright(formParent, "reactivate-action", reactivateCopyrightSubmitSuccess, reactivateCopyrightSubmitFailure, "True", true);
    });

    jQuery(deactivateCopyrightFormSubmit).click(function (e) {
        e.preventDefault();

        var formParent = jQuery(this).closest(".form");

        ResetForms();
        ActivateCopyright(formParent, "deactivate-action", deactivateCopyrightSubmitSuccess, deactivateCopyrightSubmitFailure, "False", false);
    });

    function ActivateCopyright(formParent, action, successNode, failureNode, newValue, isReactivate)
    {
        var idValue = jQuery(formParent).find(".copyright-id").val();

        jQuery(progressIndicator).show();

        jQuery.post(
            jQuery(formParent).attr(action),
            {
                Id: idValue
            }
        ).done(function (r) {
            jQuery(progressIndicator).hide();

            if (r.Succeeded)
            {
                jQuery(formParent).find(".media-active span").text(newValue);
                if (isReactivate)
                {
                    jQuery(formParent).find(".reactivate").removeClass("show").addClass("hide");
                    jQuery(formParent).find(".deactivate").removeClass("hide").addClass("show");
                }                    
                else
                {
                    jQuery(formParent).find(".reactivate").removeClass("hide").addClass("show");
                    jQuery(formParent).find(".deactivate").removeClass("show").addClass("hide");
                }
                jQuery(successNode).show();
            }
            else {
                jQuery(failureNode).show();
            }
        });
    }
});