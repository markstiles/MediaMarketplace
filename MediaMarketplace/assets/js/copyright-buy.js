jQuery.noConflict();

jQuery(document).ready(function ()
{  
    //buy copyright
    var buyCopyright = ".buy-copyright";
    var buyCopyrightForm = buyCopyright + " .form";
    var buyCopyrightFormSubmit = buyCopyrightForm + " .submit";
    var buyCopyrightSubmitFailure = buyCopyright + " .submit-results .failure";

    jQuery(buyCopyrightFormSubmit).click(function (e)
    {
        e.preventDefault();

        ResetForms();
        
        BuyCopyright();
    });

    function BuyCopyright()
    {
        var copyrightSaleIdValue = jQuery(buyCopyrightForm + " .copyright-sale-id").val();
        var payInfoIdValue = jQuery(buyCopyrightForm + " .pay-info-id").val();
        
        jQuery(progressIndicator).show();

        jQuery.post(
            jQuery(buyCopyrightForm).attr("action"),
            {
                CopyrightSaleId: copyrightSaleIdValue,
                PayInfoId: payInfoIdValue
            }
        ).done(function (r)
        {
            jQuery(progressIndicator).hide();

            if (r.Succeeded)
            {
                window.location.replace(r.RedirectUrl);
            }
            else
            {
                jQuery(buyCopyrightSubmitFailure).text(r.ErrorMessage);
                jQuery(buyCopyrightSubmitFailure).show();
            }
        });   
    }
});