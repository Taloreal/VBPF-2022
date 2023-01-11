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

//gets the last search result and updates the search frame 
function getLastSearchResult()
{
    lastSearchResult = getQueryVariable("lastSearchResult");
    if(lastSearchResult != "")
    {
        window.frames["HelpSearchFrame"].document.getElementById("returnLink").href = "javascript:window.parent.location.replace(\"index.htm?search=true&query=" + lastSearchResult + "&lastSearchResult=" + lastSearchResult + "\");";
        window.frames["HelpSearchFrame"].document.getElementById("returnLink").style.visibility = "visible";
        window.frames["HelpSearchFrame"].document.forms["searchForm"].queryTextBox.value = unescape(lastSearchResult);
    }
    else
    {
        window.frames["HelpSearchFrame"].document.getElementById("returnLink").style.visibility = "hidden";
    }
}

//called when the frameset index.htm is loaded
function pageLoad()
{
    browserTest();
    getLastSearchResult();
    changeFrameSrc();
}

//called when the frameset is loaded
//
//retrieves the help topic from the query string and loads the help_menu
//and help_item pages in their appropriate states
function changeFrameSrc()
{
    var search = getQueryVariable("search");
    if(search == "true")
    {
        window.frames["HelpMenuFrame"].location.replace("help_menu.htm?lastSearchResult=" + lastSearchResult);
        var query = getQueryVariable("query");
        if(query != "")
        {
            window.frames["HelpItemFrame"].location.replace("search.htm?query=" + query + "&lastSearchResult=" + lastSearchResult);
        }
        else
        {
            window.frames["HelpItemFrame"].location.replace("search.htm?lastSearchResult=" + lastSearchResult);
        }
    }
    else
    {
        var topic = getQueryVariable("topic");
        //if no topic was specified, assign the topic to the first topic of the help
        if(topic == "")
        {
            topic = "BASICS";
        }
        try
        {
            window.frames["HelpMenuFrame"].location.replace("help_menu.htm?topic=" + topic + "&lastSearchResult=" + lastSearchResult + "#" + topic + "_anchor");
            //check to see if we are loading a definition
            if(topic == "DEFINITIONS")
            {
                var term = getQueryVariable("term");
                window.frames["HelpItemFrame"].location.replace("definitions.htm?lastSearchResult=" + lastSearchResult + "#" + term);
            }
            //else we are loading a regular help topic
            else
            {
                var index = getQueryVariable("index");
                if(index == "")
                {
                    index = 0;
                }
                window.frames["HelpItemFrame"].location.replace("help_item.htm?" + "topic=" + topic + "&index=" + index + "&lastSearchResult=" + lastSearchResult);
            }
        }
        catch(error)
        {
            alert("Error loading Help.");
        }
    }
}

//checks for browsers known not to work with this system
function browserTest()
{
    //IE explorer for mac
    if(navigator.appName == "Microsoft Internet Explorer" && navigator.platform == "MacPPC")
    {
        window.location.replace("browser.htm");
    }
    //Netscape version 4
    else if(navigator.appName == "Netscape" && parseInt(navigator.appVersion) < 5)
    {
        window.location.replace("browser.htm");
    }
    else if(navigator.appName == "Microsoft Internet Explorer" && parseInt(navigator.appVersion.substr(navigator.appVersion.search(/MSIE/gi) + 5)) < 5)
    {
        window.location.replace("browser.htm");
    }
}
