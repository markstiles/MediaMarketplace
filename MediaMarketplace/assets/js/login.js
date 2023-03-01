jQuery.noConflict();

jQuery(document).ready(function ()
{
    //login
    var login = ".login";
    var loginForm = login + " .form";
    var loginFormSubmit = loginForm + " .submit";
    var loginSubmitFailure = login + " .submit-results .failure";

    jQuery(loginFormSubmit).click(function (e)
    {
        e.preventDefault();

        ResetForms();
        LoginUser();
    });

    function LoginUser()
    {
        var emailValue = jQuery(loginForm + " .email").val();
        var passwordValue = jQuery(loginForm + " .password").val();

        jQuery(progressIndicator).show();
        
        jQuery.post(
            jQuery(loginForm).attr("action"),
            {
                Email: emailValue,
                Password: passwordValue
            }
        ).done(function (r)
        {
            if (r.Succeeded)
            {
                window.location.replace(r.RedirectUrl);
            }
            else
            {
                jQuery(progressIndicator).hide();
                jQuery(loginSubmitFailure).show();
            }
        });
    }

    /* TODO get radio list
     * 
        var sitesValue = [];
        jQuery(crawlerConfigForm + " .sites input[type=checkbox]").each(function ()
        {
            if (jQuery(this).is(":checked"))
                sitesValue.push(jQuery(this).val());
        });
     * */
});