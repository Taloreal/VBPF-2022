//Copyright 2004 Knowledge Matters, Inc.
//Code written by Brock Bouchard
//6-11-04


//for holding the last search query
var lastSearchResult = "";

//the previous help topic that was viewed (used to remove visibility
//of old arrow pointer when topic changes; see the linkClick() method)
var previousTopic;

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

//called when the help_menu.htn page is loaded;
//if no topic or a non-existent one is provided the user is
//redirected to the beginning of help
function pageLoad()
{
    //check to see if this page was loaded directly;
    //if so, redirect to the frameset.
    if(window.parent == window)
    {
        window.location.replace("index.htm?lastSearchResult=" + lastSearchResult);
    }
    
    lastSearchResult = getQueryVariable("lastSearchResult");

    var defaultTopic = "BASICS";
    var topic = getQueryVariable("topic");
    if(topic == "")
    {
        topic = defaultTopic;
    }
    previousTopic = topic;

    //initialize the help menu pointer
    try
    {
        document.images[topic + "_image"].style.visibility = "visible";
    }
    catch(error)
    {
        if(topic != "")
        {
            alert("Could not find the topic \"" + topic + "\".  Redirecting to the beginning of Help.");
            window.parent.location.replace("index.htm?lastSearchResult=" + lastSearchResult);
        }
    }
}

//called when the user clicks on a link in the menu;
//switches visibility of the help menu pointer to
//the topic chosen.
function linkClick(topic)
{  
    try
    {
        document.images[previousTopic + "_image"].style.visibility = "hidden";        
        document.images[topic + "_image"].style.visibility = "visible";
        previousTopic = topic;
        if(topic == "DEFINITIONS")
        {
            window.parent.location.replace("index.htm?topic=DEFINITIONS&lastSearchResult=" + lastSearchResult);
        }
        else
        {
            window.parent.location.replace("index.htm?topic=" + topic + "&index=0&lastSearchResult=" + lastSearchResult);
        }
    }
    catch(error)
    {
        alert("An error occurred; redirecting to the beginning of Help.");
        window.parent.location.replace("index.htm?lastSearchResult=" + lastSearchResult);
    }
}
