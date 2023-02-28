jQuery.noConflict();

jQuery(document).ready(function ()
{
    //add pay info
    var addPay = ".add-pay-info";
    var addPayForm = addPay + " .form";
    var addPaySubmit = addPayForm + " .submit";
    var addPaySubmitSuccess = addPay + " .submit-results .success";
    var addPaySubmitFailure = addPay + " .submit-results .failure";

    jQuery(addPaySubmit).click(function (e) {
        e.preventDefault();

        ResetForms();
        AddPayInfo();
    });

    function AddPayInfo() {
        var bankAccountValue = jQuery(addPayForm + " .bank-account").val();
        var routingNumberValue = jQuery(addPayForm + " .routing-number").val();

        jQuery(progressIndicator).show();

        jQuery.post(
            jQuery(addPayForm).attr("action"),
            {
                BankAccount: bankAccountValue,
                RoutingNumber: routingNumberValue
            }
        ).done(function (r) {
            jQuery(progressIndicator).hide();

            if (r.Succeeded) {
                jQuery(addPaySubmitSuccess).show();
                jQuery(addPayForm).find("input[type=text]").val("");
            }
            else {
                jQuery(addPaySubmitFailure).show();
            }
        });
    }

    //payment information
    var pay = ".pay-info";
    var payForm = pay + " .form";
    var payUpdateSubmit = payForm + " .update";
    var payDeleteSubmit = payForm + " .delete";
    var payUpdateSubmitSuccess = pay + " .submit-results .update-pay-info-success";
    var payUpdateSubmitFailure = pay + " .submit-results .update-pay-info-failure";
    var payDeleteSubmitSuccess = pay + " .submit-results .delete-pay-info-success";
    var payDeleteSubmitFailure = pay + " .submit-results .delete-pay-info-failure";

    jQuery(payUpdateSubmit).click(function (e)
    {
        e.preventDefault();

        var formParent = jQuery(this).closest(".form");

        ResetForms();
        UpdatePayInfo(formParent);
    });

    function UpdatePayInfo(formParent)
    {
        var idValue = jQuery(formParent).find(".pay-info-id").val();
        var bankAccountValue = jQuery(formParent).find(".bank-account").val();
        var routingNumberValue = jQuery(formParent).find(".routing-number").val();

        jQuery(progressIndicator).show();
        
        jQuery.post(
            jQuery(formParent).attr("update-action"),
            {
                Id: idValue,
                BankAccount: bankAccountValue,
                RoutingNumber: routingNumberValue
            }
        ).done(function (r)
        {
            jQuery(progressIndicator).hide();

            if (r.Succeeded)
            {
                jQuery(payUpdateSubmitSuccess).show();
            }
            else
            {
                jQuery(payUpdateSubmitFailure).show();
            }
        });
    }

    jQuery(payDeleteSubmit).click(function (e)
    {
        e.preventDefault();

        var formParent = jQuery(this).closest(".form");

        ResetForms();
        DeletePayInfo(formParent );
    });

    function DeletePayInfo(formParent)
    {
        var idValue = jQuery(formParent).find(".pay-info-id").val();

        jQuery(progressIndicator).show();

        jQuery.post(
            jQuery(formParent).attr("delete-action"),
            {
                Id: idValue
            }
        ).done(function (r) {
            jQuery(progressIndicator).hide();

            if (r.Succeeded) {
                jQuery(formParent).remove();
                jQuery(payDeleteSubmitSuccess).show();
            }
            else {
                jQuery(payDeleteSubmitFailure).show();
            }
        });
    }
});