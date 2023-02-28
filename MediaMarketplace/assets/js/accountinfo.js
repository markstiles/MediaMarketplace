jQuery.noConflict();

jQuery(document).ready(function ()
{
    //account info
    var accountInfo = ".account-info";
    var accountInfoForm = accountInfo + " .form";
    var accountInfoFormSubmit = accountInfoForm + " .submit";
    var accountInfoSubmitSuccess = accountInfo + " .submit-results .success";
    var accountInfoSubmitFailure = accountInfo + " .submit-results .failure";

    jQuery(accountInfoFormSubmit).click(function (e)
    {
        e.preventDefault();

        ResetForms();
        UpdateAccountInfo();
    });

    function UpdateAccountInfo()
    {
        var emailValue = jQuery(accountInfoForm + " .email").val();
        var passwordValue = jQuery(accountInfoForm + " .password").val();
        var passwordConfirmValue = jQuery(accountInfoForm + " .password-confirm").val();
        var firstNameValue = jQuery(accountInfoForm + " .first-name").val();
        var lastNameValue = jQuery(accountInfoForm + " .last-name").val();
        var phoneNumberValue = jQuery(accountInfoForm + " .phone-number").val();
        var businessNameValue = jQuery(accountInfoForm + " .business-name").val();

        jQuery(progressIndicator).show();
        
        jQuery.post(
            jQuery(accountInfoForm).attr("action"),
            {
                Email: emailValue,
                Password: passwordValue,
                PasswordConfirm: passwordConfirmValue,
                FirstName: firstNameValue,
                LastName: lastNameValue,
                PhoneNumber: phoneNumberValue,
                BusinessName: businessNameValue
            }
        ).done(function (r)
        {
            jQuery(progressIndicator).hide();

            if (r.Succeeded)
            {
                jQuery(accountInfoSubmitSuccess).show();
            }
            else
            {
                jQuery(accountInfoSubmitFailure).text(r.ErrorMessage);
                jQuery(accountInfoSubmitFailure).show();
            }
        });
    }
});