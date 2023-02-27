jQuery.noConflict();

jQuery(document).ready(function ()
{
    //solr
    var solrConfig = ".solr-config";
    var solrConfigForm = solrConfig + " .form";
    var solrTestFormSubmit = solrConfigForm + " .solr-test";
    var solrTestSuccess = solrConfig + " .test-success";
    var solrTestFailure = solrConfig + " .test-failure";
    var solrConfigFormSubmit = solrConfigForm + " .solr-submit";
    var solrSubmitSuccess = solrConfig + " .submit-success";
    var solrSubmitFailure = solrConfig + " .submit-failure";

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