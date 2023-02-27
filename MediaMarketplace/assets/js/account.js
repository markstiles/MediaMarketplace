jQuery.noConflict();

jQuery(document).ready(function ()
{
    //site
    var siteConfig = ".site-config";
    var siteConfigForm = siteConfig + " .form";
    var siteConfigFormSubmit = siteConfigForm + " .site-submit";
    var siteSubmitSuccess = siteConfig + " .submit-success";
    var siteSubmitFailure = siteConfig + " .submit-failure";

    //Solr

    jQuery(solrConfigFormSubmit).click(function (e)
    {
        e.preventDefault();

        ResetConfigForms();
        CreateSolrConfig();
    });

    function CreateSolrConfig()
    {
        var solrUrlValue = jQuery(solrConfigForm + " .solr-url").val();
        var solrCoreValue = jQuery(solrConfigForm + " .solr-core").val();

        jQuery(progressIndicator).show();
        
        jQuery.post(
            jQuery(solrConfigForm).attr("action"),
            {
                SolrUrl: solrUrlValue,
                SolrCore: solrCoreValue
            }
        ).done(function (r)
        {
            jQuery(progressIndicator).hide();
           
            if (r.Succeeded)
            {
                jQuery(solrConfigForm + " .solr-url").val("");
                jQuery(solrConfigForm + " .solr-core").val("");
                jQuery(solrSubmitSuccess).show();
            }
            else
            {
                jQuery(solrSubmitFailure).show();
            }
        });
    }
});