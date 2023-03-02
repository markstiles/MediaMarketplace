jQuery.noConflict();

jQuery(document).ready(function ()
{  
    //buy license
    var buyLicense = ".buy-license";
    var buyLicenseForm = buyLicense + " .form";
    var buyLicenseFormSubmit = buyLicenseForm + " .submit";
    var buyLicenseSubmitFailure = buyLicense + " .submit-results .failure";
    
    jQuery(buyLicenseFormSubmit).click(function (e)
    {
        e.preventDefault();

        ResetForms();
        BuyLicense();
    });

    function BuyLicense()
    {
        var licenseIdValue = jQuery(buyLicenseForm + " .license-id").val();

        jQuery(progressIndicator).show();

        jQuery.post(
            jQuery(buyLicenseForm).attr("action"),
            {
                LicenseId: licenseIdValue
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
                jQuery(buyLicenseSubmitFailure).text(r.ErrorMessage);
                jQuery(buyLicenseSubmitFailure).show();
            }
        });   
    }
});