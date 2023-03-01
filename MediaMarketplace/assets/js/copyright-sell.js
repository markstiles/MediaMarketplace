jQuery.noConflict();

jQuery(document).ready(function ()
{  
    //sell copyright
    var sellCopyright = ".sell-copyright";
    var sellCopyrightForm = sellCopyright + " .form";
    var sellCopyrightFormSubmit = sellCopyrightForm + " .submit";
    var sellCopyrightSubmitFailure = sellCopyright + " .submit-results .failure";

    jQuery(sellCopyrightFormSubmit).click(function (e)
    {
        e.preventDefault();

        ResetForms();
        SellCopyright();
    });

    function SellCopyright()
    {
        var copyrightIdValue = jQuery(sellCopyrightForm + " .copyright-id").val();
        var amountValue = jQuery(sellCopyrightForm + " .amount").val();

        jQuery(progressIndicator).show();

        jQuery.post(
            jQuery(sellCopyrightForm).attr("action"),
            {
                CopyrightId: copyrightIdValue,
                Amount: amountValue
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
                jQuery(sellCopyrightSubmitFailure).text(r.ErrorMessage);
                jQuery(sellCopyrightSubmitFailure).show();
            }
        });   
    }

    //delete sell copyright
    var deleteSellCopyright = ".delete-sell-copyright";
    var deleteSellCopyrightForm = deleteSellCopyright + " .form";
    var deleteSellCopyrightFormSubmit = deleteSellCopyrightForm + " .submit";
    var deleteSellCopyrightSubmitFailure = deleteSellCopyright + " .submit-results .failure";

    jQuery(deleteSellCopyrightFormSubmit).click(function (e) {
        e.preventDefault();

        var formParent = jQuery(this).closest(".form");

        ResetForms();
        DeleteSellCopyright(formParent);
    });

    function DeleteSellCopyright(formParent)
    {
        var copyrightSaleIdValue = jQuery(formParent).find(".copyright-sale-id").val();

        jQuery(progressIndicator).show();

        jQuery.post(
            jQuery(formParent).attr("action"),
            {
                CopyrightSaleId: copyrightSaleIdValue
            }
        ).done(function (r) {
            jQuery(progressIndicator).hide();

            if (r.Succeeded)
            {
                location.reload();
            }
            else
            {
                jQuery(deleteSellCopyrightSubmitFailure).show();
            }
        });
    }
});