jQuery.noConflict();

jQuery(document).ready(function ()
{  
    //add license
    var addLicense = ".add-license";
    var addLicenseForm = addLicense + " .form";
    var addLicenseFormSubmit = addLicenseForm + " .submit";
    var addLicenseSubmitFailure = addLicense + " .submit-results .failure";

    jQuery(addLicenseFormSubmit).click(function (e)
    {
        e.preventDefault();

        ResetForms();
        AddLicense();
    });

    function AddLicense()
    {
        var copyrightIdValue = jQuery(addLicenseForm + " .copyright-id").val();
        var licenseTypeValue = jQuery(addLicenseForm + " .license-type").val();
        var startDateValue = jQuery(addLicenseForm + " .start-date").val();
        var endDateValue = jQuery(addLicenseForm + " .end-date").val();
        var licenseCostValue = jQuery(addLicenseForm + " .license-cost").val();

        jQuery(progressIndicator).show();

        jQuery.post(
            jQuery(addLicenseForm).attr("action"),
            {
                CopyrightId: copyrightIdValue,
                LicenseType: licenseTypeValue,
                StartDate: startDateValue,
                EndDate: endDateValue,
                LicenseCost: licenseCostValue
            }
        ).done(function (r)
        {
            jQuery(progressIndicator).hide();

            if (r.Succeeded)
            {
                location.reload();
            }
            else
            {
                jQuery(addLicenseSubmitFailure).text(r.ErrorMessage);
                jQuery(addLicenseSubmitFailure).show();
            }
        });   
    }

    //delete license
    var deleteLicense = ".delete-license";
    var deleteLicenseForm = deleteLicense + " .form";
    var deleteLicenseFormSubmit = deleteLicenseForm + " .submit";
    var deleteLicenseSubmitFailure = deleteLicense + " .submit-results .failure";

    jQuery(deleteLicenseFormSubmit).click(function (e) {
        e.preventDefault();

        var formParent = jQuery(this).closest(".form");

        ResetForms();
        DeleteLicense(formParent);
    });

    function DeleteLicense(formParent)
    {
        var licenseIdValue = jQuery(formParent).find(".license-id").val();

        jQuery(progressIndicator).show();

        jQuery.post(
            jQuery(formParent).attr("action"),
            {
                LicenseId: licenseIdValue
            }
        ).done(function (r) {
            jQuery(progressIndicator).hide();

            if (r.Succeeded)
            {
                location.reload();
            }
            else
            {
                jQuery(deleteLicenseSubmitFailure).show();
            }
        });
    }
});