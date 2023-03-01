jQuery.noConflict();

jQuery(document).ready(function ()
{  
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
        var copyrightIdValue = jQuery(formParent).find(".copyright-id").val();

        jQuery(progressIndicator).show();

        jQuery.post(
            jQuery(formParent).attr(action),
            {
                CopyrightId: copyrightIdValue
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