﻿
//global
var progressIndicator = ".progress-indicator";
var contentContainer = ".content-container";

function parseJsonDate(jsonDateString)
{
    return new Date(parseInt(jsonDateString.replace('/Date(', '')));
}

//Shared Functions
function ResetForms() {
    jQuery(".submit-results .success, .submit-results .failure").hide();
}