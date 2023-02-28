jQuery.noConflict();

jQuery(document).ready(function ()
{
    //register
    var register = ".register";
    var registerForm = register + " .form";
    var registerFormSubmit = registerForm + " .submit";
    var registerSubmitSuccess = register + " .submit-results .success";
    var registerSubmitFailure = register + " .submit-results .failure";

    jQuery(registerFormSubmit).click(function (e)
    {
        e.preventDefault();

        ResetForms();
        RegisterUser();
    });

    function RegisterUser()
    {
        var emailValue = jQuery(registerForm + " .email").val();
        var phoneValue = jQuery(registerForm + " .phone-number").val();
        var passwordValue = jQuery(registerForm + " .password").val();
        var passwordConfirmValue = jQuery(registerForm + " .password-confirm").val();
        var firstNameValue = jQuery(registerForm + " .first-name").val();
        var lastNameValue = jQuery(registerForm + " .last-name").val();
        var businessNameValue = jQuery(registerForm + " .business-name").val();
        var bankAccountValue = jQuery(registerForm + " .bank-account").val();
        var routingNumberValue = jQuery(registerForm + " .routing-number").val();

        jQuery(progressIndicator).show();
        
        jQuery.post(
            jQuery(registerForm).attr("action"),
            {
                Email: emailValue,
                PhoneNumber: phoneValue,
                Password: passwordValue,
                PasswordConfirm: passwordConfirmValue,
                FirstName: firstNameValue,
                LastName: lastNameValue,
                BusinessName: businessNameValue,
                BankAccount: bankAccountValue,
                RoutingNumber: routingNumberValue
            }
        ).done(function (r)
        {
            jQuery(progressIndicator).hide();

            if (r.Succeeded)
            {
                jQuery(registerForm).find("input[type=text],input[type=password]").val("");
                jQuery(registerSubmitSuccess).show();
            }
            else
            {
                jQuery(registerSubmitFailure).text(r.ErrorMessage);
                jQuery(registerSubmitFailure).show();
            }
        });
    }
});