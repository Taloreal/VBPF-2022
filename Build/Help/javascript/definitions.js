//Copyright 2004 Knowledge Matters, Inc.
//Code written by Brock Bouchard
//6-11-04


//for holding the last search query
var lastSearchResult = "";

//retrieves the value of the specified query string variable from the
//current page's url
function getQueryVariable(variable)
{
    var query = window.location.search.substring(1);
    var vars = query.split("&");
    for (var i=0;i<vars.length;i++)
    {
        var pair = vars[i].split("=");
        if (pair[0] == variable)
        {
             return pair[1];
        }
    } 
    return "";
}

//called when the definitions.htm page is loaded
function pageLoad()
{
    //check to see if this page was loaded directly;
    //if so, redirect to the frameset.
    if(window.parent == window)
    {
        window.location.replace("index.htm?topic=DEFINITIONS&lastSearchResult=" + lastSearchResult);
    }
    
    lastSearchResult = getQueryVariable("lastSearchResult");
}