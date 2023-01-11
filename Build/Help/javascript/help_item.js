//Copyright 2004 Knowledge Matters, Inc.
//Code written by Brock Bouchard
//6-11-04


/*
The help_item.htm page works as follows:

Each Table of Contents heading, or Help Topic, has a set of 1 or more
Help Frames associated with it.

The frames within the current Help Topic can be thought to have a numeric
index of 0 to (#_of_frames_in_topic - 1).

The Help Topic is provided to this page via the query variable "topic."
The frame index is provided to this page via the query variable "index."

When the user clicks on a Help Topic in the Table of Contents, it loads the
topic with an index of 0.  The user navigates through the Help Frames using
the "<< Back" and "Next >>" links.  This decreases or increases the value of
the index, and updates the display of all frame components (background, 
foreground, callout, etc).  When the user clicks back from frame 0, or
forward from frame (count - 1) the previous or next topic is loaded.
*/


//for holding the last search query
var lastSearchResult = "";

//the current Help Topic
var topic;

//the index within the current help topic
var index;

//the number of Help Frames within in the current Help Topic
var count;

//the previous Help Topic
var previousTopic;

//the next Help Topic
var nextTopic;

/*
Topics are displayed using the following data:
var %TOPIC%_FrameCount;
var %TOPIC%_BackgroundSrc;
var %TOPIC%_ForegroundSrc;
var %TOPIC%_ForegroundLeft;
var %TOPIC%_ForegroundTop;
var %TOPIC%_CalloutSrc;
var %TOPIC%_CalloutLeft;
var %TOPIC%_CalloutTop;
var %TOPIC%_CalloutText;
var %TOPIC%_TextLeft;
var %TOPIC%_TextTop;
var %TOPIC%_BackLinkLeft;
var %TOPIC%_NextLinkLeft;
var %TOPIC%_LinkTop;
var %TOPIC%_PreviousTopic;
var %TOPIC%_NextTopic;
*/


var BASICS_FrameCount = 1;
var BASICS_BackgroundSrc = new Array("City View.png");
var BASICS_ForegroundSrc = new Array("");
var BASICS_ForegroundLeft = new Array("0");
var BASICS_ForegroundTop = new Array("0");
var BASICS_CalloutSrc = new Array("callout_center.gif");
var BASICS_CalloutLeft = new Array("249");
var BASICS_CalloutTop = new Array("100");
var BASICS_CalloutText = new Array("Welcome to the Tutorial. This program will help you to better understand the views and menus found within this simulation.<br />");
var BASICS_TextLeft = new Array("253");
var BASICS_TextTop = new Array("108");
var BASICS_BackLinkLeft = new Array("257");
var BASICS_NextLinkLeft = new Array("367");
var BASICS_LinkTop = new Array("156");

var Overview_FrameCount = 11;
var Overview_BackgroundSrc = new Array("City View.png","City View.png","City View.png","City View.png","Search for Job Shift Manager.png","Banking Options.png","City View.png","City View.png","Apartment View With Furniture.png","City View.png","City View.png");
var Overview_ForegroundSrc = new Array("","","","","","","Schedule with Host a Party Option.png","Health Screen with Social Life.png","","View Portfolio Screen.png","Personal Balance Sheet with Net Worth.png");
var Overview_ForegroundLeft = new Array("0","0","0","0","0","0","18","169","0","6","65");
var Overview_ForegroundTop = new Array("0","0","0","0","0","0","6","90","0","3","12");
var Overview_CalloutSrc = new Array("callout_center.gif","callout_center.gif","callout_center.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_center.gif","callout_left.gif","callout_center.gif","callout_center.gif","callout_left.gif");
var Overview_CalloutLeft = new Array("249","249","249","192","19","342","249","21","249","249","232");
var Overview_CalloutTop = new Array("100","100","100","331","84","209","100","25","100","100","303");
var Overview_CalloutText = new Array("You may end this Tutorial at any time by closing the browser.","In Virtual Business - Personal Finance (VBPF), you will manage your life.<br />","You normally begin VBPF by completing the lessons and then moving on to the New Career Project and competitions.","Within this simulation, you will choose a location to live . . .<br />",". . . find a job . . .",". . . manage your money . . .",". . . organize your own schedule . . . ",". . . maintain your health . . .",". . . buy food and goods . . .",". . . and invest.","You will be judged on your net worth.");
var Overview_TextLeft = new Array("253","253","253","196","23","346","253","25","253","253","236");
var Overview_TextTop = new Array("108","108","108","339","92","217","108","33","108","108","311");
var Overview_BackLinkLeft = new Array("257","257","257","200","27","350","257","29","257","257","240");
var Overview_NextLinkLeft = new Array("367","367","367","310","137","460","367","139","367","367","350");
var Overview_LinkTop = new Array("156","156","156","387","140","265","156","81","156","156","359");

var Assignments_FrameCount = 3;
var Assignments_BackgroundSrc = new Array("City View.png","City View.png","City View.png");
var Assignments_ForegroundSrc = new Array("View Assignment.png","Assignment.png","");
var Assignments_ForegroundLeft = new Array("226","34","0");
var Assignments_ForegroundTop = new Array("156","7","0");
var Assignments_CalloutSrc = new Array("callout_left.gif","callout_right.gif","callout_left.gif");
var Assignments_CalloutLeft = new Array("87","437","231");
var Assignments_CalloutTop = new Array("94","20","11");
var Assignments_CalloutText = new Array("Whenever you open a lesson or start your project portfolio, the first thing displayed is the option to view or print your assignment.","This is an example of an assignment. ","If you ever need to reopen the assignment, here is the Assignment button to do so.<br />");
var Assignments_TextLeft = new Array("91","457","235");
var Assignments_TextTop = new Array("102","28","19");
var Assignments_BackLinkLeft = new Array("95","461","239");
var Assignments_NextLinkLeft = new Array("205","571","349");
var Assignments_LinkTop = new Array("150","76","67");

var Getting_Around_FrameCount = 5;
var Getting_Around_BackgroundSrc = new Array("City View.png","Stop Button.png","City View.png","Faster Slower Buttons.png","City View.png");
var Getting_Around_ForegroundSrc = new Array("","","","","");
var Getting_Around_ForegroundLeft = new Array("0","0","0","0","0");
var Getting_Around_ForegroundTop = new Array("0","0","0","0","0");
var Getting_Around_CalloutSrc = new Array("callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif");
var Getting_Around_CalloutLeft = new Array("113","37","32","85","452");
var Getting_Around_CalloutTop = new Array("398","8","4","-5","407");
var Getting_Around_CalloutText = new Array("As you run VBPF, time passes. You can always find the date and time down here.","If you want to stop time in order to make some decisions, click this STOP button.","To restart time, click the green GO button.","The rate of time passing is controlled by these FASTER and SLOWER buttons.","Your net worth is found here.");
var Getting_Around_TextLeft = new Array("133","57","52","105","456");
var Getting_Around_TextTop = new Array("406","16","12","3","415");
var Getting_Around_BackLinkLeft = new Array("137","61","56","109","460");
var Getting_Around_NextLinkLeft = new Array("247","171","166","219","570");
var Getting_Around_LinkTop = new Array("454","64","60","51","463");

var Message_Center_FrameCount = 4;
var Message_Center_BackgroundSrc = new Array("City View.png","City View.png","City View.png","Message Envelope.png");
var Message_Center_ForegroundSrc = new Array("Message Center Screen.png","Message Center Screen.png","Message Center Screen.png","");
var Message_Center_ForegroundLeft = new Array("23","23","14","0");
var Message_Center_ForegroundTop = new Array("240","241","250","0");
var Message_Center_CalloutSrc = new Array("callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif");
var Message_Center_CalloutLeft = new Array("226","251","298","219");
var Message_Center_CalloutTop = new Array("179","185","193","410");
var Message_Center_CalloutText = new Array("This is your Message Center. It tells you if you have bills waiting, if you are late for work or school, if you are out of food, . . .",". . . if your car has broken down, if you are sick, if you have lost your job, etc. It is critical that you monitor your messages.","You may close the Message Center at any time by clicking this box.","A yellow envelope indicates that you have new messages. Click it and the message screen will reappear.");
var Message_Center_TextLeft = new Array("246","271","318","239");
var Message_Center_TextTop = new Array("187","193","201","418");
var Message_Center_BackLinkLeft = new Array("250","275","322","243");
var Message_Center_NextLinkLeft = new Array("360","385","432","353");
var Message_Center_LinkTop = new Array("235","241","249","466");

var City_View_FrameCount = 6;
var City_View_BackgroundSrc = new Array("City View.png","City View.png","Condo Symbol.png","Work Bubble in City View.png","City View with Message Waiting.png","City View.png");
var City_View_ForegroundSrc = new Array("","","","","","");
var City_View_ForegroundLeft = new Array("0","0","0","0","0","0");
var City_View_ForegroundTop = new Array("0","0","0","0","0","0");
var City_View_CalloutSrc = new Array("callout_center.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_right.gif","callout_left.gif");
var City_View_CalloutLeft = new Array("249","386","285","232","252","196");
var City_View_CalloutTop = new Array("100","322","215","177","192","288");
var City_View_CalloutText = new Array("This view is the City view. ","It shows where you live. If you live in an apartment, you'll see this symbol.","If you live in a condo, you will see this symbol instead.","It also shows where you work and . . .",". . . where you go to school.","This symbol here always lets you know where you are during the day. You are at home right now.");
var City_View_TextLeft = new Array("253","406","305","236","272","200");
var City_View_TextTop = new Array("108","330","223","185","200","296");
var City_View_BackLinkLeft = new Array("257","410","309","240","276","204");
var City_View_NextLinkLeft = new Array("367","520","419","350","386","314");
var City_View_LinkTop = new Array("156","378","271","233","248","344");

var Legend_FrameCount = 3;
var Legend_BackgroundSrc = new Array("City View.png","City View.png","City View.png");
var Legend_ForegroundSrc = new Array("","Legend.png","Legend.png");
var Legend_ForegroundLeft = new Array("450","446","455");
var Legend_ForegroundTop = new Array("30","35","35");
var Legend_CalloutSrc = new Array("callout_left.gif","callout_left.gif","callout_left.gif");
var Legend_CalloutLeft = new Array("178","283","285");
var Legend_CalloutTop = new Array("9","19","27");
var Legend_CalloutText = new Array("To open the Legend, click here.","The legend will tell you what all of the buildings represent within the City view.","Any building that is listed in the legend is a building you can click on in the City view in order to accomplish an action.");
var Legend_TextLeft = new Array("182","287","289");
var Legend_TextTop = new Array("17","27","35");
var Legend_BackLinkLeft = new Array("186","291","293");
var Legend_NextLinkLeft = new Array("296","401","403");
var Legend_LinkTop = new Array("65","75","83");

var Apartment_or_Condo_View_FrameCount = 2;
var Apartment_or_Condo_View_BackgroundSrc = new Array("Enter Apartment or Condo.png","Apartment View With Nothing.png");
var Apartment_or_Condo_View_ForegroundSrc = new Array("","");
var Apartment_or_Condo_View_ForegroundLeft = new Array("0","0");
var Apartment_or_Condo_View_ForegroundTop = new Array("0","0");
var Apartment_or_Condo_View_CalloutSrc = new Array("callout_left.gif","callout_center.gif");
var Apartment_or_Condo_View_CalloutLeft = new Array("90","249");
var Apartment_or_Condo_View_CalloutTop = new Array("302","100");
var Apartment_or_Condo_View_CalloutText = new Array("In order to enter your Apartment or Condo view, you click on your building and then select Enter.","Your apartment or condo will be unfurnished when you move in.");
var Apartment_or_Condo_View_TextLeft = new Array("94","253");
var Apartment_or_Condo_View_TextTop = new Array("310","108");
var Apartment_or_Condo_View_BackLinkLeft = new Array("98","257");
var Apartment_or_Condo_View_NextLinkLeft = new Array("208","367");
var Apartment_or_Condo_View_LinkTop = new Array("358","156");

var School_View_FrameCount = 3;
var School_View_BackgroundSrc = new Array("Enter Classroom.png","Classroom View with you in it.png","Classroom View with message.png");
var School_View_ForegroundSrc = new Array("","","");
var School_View_ForegroundLeft = new Array("0","0","0");
var School_View_ForegroundTop = new Array("0","0","0");
var School_View_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_left.gif");
var School_View_CalloutLeft = new Array("225","140","146");
var School_View_CalloutTop = new Array("238","277","271");
var School_View_CalloutText = new Array("To enter a classroom, you must first click on the building and then click here.","You can observe yourself while you are in class.","If you click on your person while in this view, you'll see a message telling you course title and time to complete the course.");
var School_View_TextLeft = new Array("245","144","150");
var School_View_TextTop = new Array("246","285","279");
var School_View_BackLinkLeft = new Array("249","148","154");
var School_View_NextLinkLeft = new Array("359","258","264");
var School_View_LinkTop = new Array("294","333","327");

var REPORTS_FrameCount = 1;
var REPORTS_BackgroundSrc = new Array("Reports.png");
var REPORTS_ForegroundSrc = new Array("");
var REPORTS_ForegroundLeft = new Array("0");
var REPORTS_ForegroundTop = new Array("0");
var REPORTS_CalloutSrc = new Array("callout_right.gif");
var REPORTS_CalloutLeft = new Array("171");
var REPORTS_CalloutTop = new Array("12");
var REPORTS_CalloutText = new Array("You have a number of reports available to you within this simulation.");
var REPORTS_TextLeft = new Array("191");
var REPORTS_TextTop = new Array("20");
var REPORTS_BackLinkLeft = new Array("195");
var REPORTS_NextLinkLeft = new Array("305");
var REPORTS_LinkTop = new Array("68");

var Snapshot_FrameCount = 9;
var Snapshot_BackgroundSrc = new Array("City View.png","Snapshot from under Reports menu.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png");
var Snapshot_ForegroundSrc = new Array("","","Snapshot Second Copy.png","Snapshot Second Copy.png","Snapshot Second Copy.png","Snapshot Second Copy.png","Snapshot Second Copy.png","Snapshot with Bus Tokens.png","Snapshot with Bus Tokens.png");
var Snapshot_ForegroundLeft = new Array("0","0","428","412","428","436","423","404","395");
var Snapshot_ForegroundTop = new Array("0","0","356","329","337","331","348","351","325");
var Snapshot_CalloutSrc = new Array("callout_right.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif");
var Snapshot_CalloutLeft = new Array("241","186","262","244","305","362","400","260","319");
var Snapshot_CalloutTop = new Array("7","-1","283","292","296","296","307","289","284");
var Snapshot_CalloutText = new Array("In order to access the Snapshot, you may click here, or . . . ",". . . select it here under the Reports menu.","This report can stay open while you are running the simulation and time is passing.","The Snapshot tells you how your health is doing . . . ",". . . how many meals you have left . . .",". . . how many gallons of gas you have left if you own a car . . .",". . . and if your car is operating okay.","If you don't own a car, your Snapshot may look like this if you are taking the bus instead.","The Snapshot will show you how many bus tokens you have left.");
var Snapshot_TextLeft = new Array("261","206","266","248","309","366","404","264","323");
var Snapshot_TextTop = new Array("15","7","291","300","304","304","315","297","292");
var Snapshot_BackLinkLeft = new Array("265","210","270","252","313","370","408","268","327");
var Snapshot_NextLinkLeft = new Array("375","320","380","362","423","480","518","378","437");
var Snapshot_LinkTop = new Array("63","55","339","348","352","352","363","345","340");

var Wealth_FrameCount = 5;
var Wealth_BackgroundSrc = new Array("City View.png","Wealth from under Reports menu.png","City View.png","City View.png","City View.png");
var Wealth_ForegroundSrc = new Array("","","Personal Balance Sheet.png","Personal Balance Sheet with Net Worth.png","Personal Balance Sheet with Net Worth.png");
var Wealth_ForegroundLeft = new Array("0","0","179","48","36");
var Wealth_ForegroundTop = new Array("0","0","22","-2","3");
var Wealth_CalloutSrc = new Array("callout_left.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_left.gif");
var Wealth_CalloutLeft = new Array("85","184","156","25","178");
var Wealth_CalloutTop = new Array("7","11","38","104","300");
var Wealth_CalloutText = new Array("You may access your personal balance sheet by clicking here, or . . . ",". . . by clicking here under the Reports menu.","The Personal Balance Sheet lists your assets (things you own) . . .",". . . and your liabilities (things you owe) . . .",". . . which are used to calculate your net worth (Assets minus Liabilities).");
var Wealth_TextLeft = new Array("89","204","160","29","182");
var Wealth_TextTop = new Array("15","19","46","112","308");
var Wealth_BackLinkLeft = new Array("93","208","164","33","186");
var Wealth_NextLinkLeft = new Array("203","318","274","143","296");
var Wealth_LinkTop = new Array("63","67","94","160","356");

var Health_FrameCount = 21;
var Health_BackgroundSrc = new Array("City View.png","Health from under Reports menu.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","Apartment View With Person Sleeping.png","City View.png","Apartment View With Person on Treadmill.png","City View.png","City View.png","Apartment View With Furniture.png","City View.png","Apartment View with Party Going On.png","City View.png","City View.png","City View.png","Person Gets Sick.png");
var Health_ForegroundSrc = new Array("","","Health Screen.png","Health Screen with Social Life.png","Schedule with eat relax exercise.png","Health Screen with Bars Changed.png","Health Screen with Social Life.png","Schedule with eat relax exercise.png","Health Screen with Social Life.png","","Health Screen with Social Life.png","","Transportation Screen.png","Health Screen with Social Life.png","","Health Screen with Social Life.png","","Health screen with yellow bar.png","Health screen with red bar for sleep.png","Message Center Screen with sick message.png","");
var Health_ForegroundLeft = new Array("0","0","227","180","21","111","175","23","124","0","102","0","164","140","0","92","0","89","84","34","0");
var Health_ForegroundTop = new Array("0","0","121","103","7","78","104","0","76","0","84","0","61","97","0","57","0","101","62","251","0");
var Health_CalloutSrc = new Array("callout_left.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_left.gif","callout_right.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif");
var Health_CalloutLeft = new Array("128","174","92","29","365","351","417","400","346","326","354","405","29","396","58","329","119","297","221","263","364");
var Health_CalloutTop = new Array("12","29","120","188","100","101","114","167","105","198","133","198","70","166","268","146","217","132","92","315","185");
var Health_CalloutText = new Array("You may access your detailed Health report by clicking here, or . . .",". . . by clicking here under the Reports menu.","The Health report monitors your nutrition, sleep, exercise and relaxation.","During Levels 2 & 3 of the New Career Project, it also monitors your social life.","You need to make sure you schedule enough time for these activities or you will be at risk for poor health.","Your Health report will indicate when you are not doing enough of something. These bars will start shrinking.","You need to eat twice a day for a 1/2 hour each time. ","You need to allow a minimum of four hours in between the times you eat in order for this activity to have a positive effect.","You need to sleep for a minimum of six hours a day for this activity to effect you positively.","However, if you don't have a bed, you'll need twice as much sleep to get by.","You need to exercise for a minimum of two hours per day.","If you purchase a treadmill, this cuts down on the amount of time you need to exercise per day to one hour.","If you walk to school or work, this counts as exercise.","You need to relax for a minimum of two hours per day.","If you have a couch and TV, you may be able to get by with less relaxation time.","In Levels 2 or 3, you need to socialize by either hosting a party or attending a party at least once a month.","Caution, if no one attends your party, you don't get any credit for socializing.","When a bar changes from green to yellow, there is a chance that you will get sick.","When the bar changes from yellow to red, there is a very high likelihood that you will get sick.","You will receive this message in your message center.","And, you will not be able to leave your apartment for 24 hours. Too many absences can cause you to lose your job.");
var Health_TextLeft = new Array("132","194","96","33","385","371","437","420","366","330","374","409","33","416","62","349","123","317","241","283","368");
var Health_TextTop = new Array("20","37","128","196","108","109","122","175","113","206","141","206","78","174","276","154","225","140","100","323","193");
var Health_BackLinkLeft = new Array("136","198","100","37","389","375","441","424","370","334","378","413","37","420","66","353","127","321","245","287","372");
var Health_NextLinkLeft = new Array("246","308","210","147","499","485","551","534","480","444","488","523","147","530","176","463","237","431","355","397","482");
var Health_LinkTop = new Array("68","85","176","244","156","157","170","223","161","254","189","254","126","222","324","202","273","188","148","371","241");

var Resume_FrameCount = 4;
var Resume_BackgroundSrc = new Array("Resume from under Reports menu.png","City View.png","City View.png","City View.png");
var Resume_ForegroundSrc = new Array("","Resume with Education.png","Resume with Education.png","Resume with Education.png");
var Resume_ForegroundLeft = new Array("0","176","162","172");
var Resume_ForegroundTop = new Array("0","17","7","40");
var Resume_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_left.gif","callout_left.gif");
var Resume_CalloutLeft = new Array("172","42","38","22");
var Resume_CalloutTop = new Array("50","43","154","6");
var Resume_CalloutText = new Array("To access your resume, click here under the Reports menu.","Each time you complete a course or receive a degree, that information will appear here.","Your past and present work history will be recorded here.","The information on your resume will be helpful to you when applying for new jobs.");
var Resume_TextLeft = new Array("192","46","42","26");
var Resume_TextTop = new Array("58","51","162","14");
var Resume_BackLinkLeft = new Array("196","50","46","30");
var Resume_NextLinkLeft = new Array("306","160","156","140");
var Resume_LinkTop = new Array("106","99","210","62");

var Credit_Score_FrameCount = 4;
var Credit_Score_BackgroundSrc = new Array("Credit Score from under Reports menu.png","City View.png","City View.png","City View.png");
var Credit_Score_ForegroundSrc = new Array("","Credit Score Screen.png","Credit Score Screen.png","Credit Score Screen.png");
var Credit_Score_ForegroundLeft = new Array("0","95","119","92");
var Credit_Score_ForegroundTop = new Array("0","61","13","41");
var Credit_Score_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_left.gif","callout_center.gif");
var Credit_Score_CalloutLeft = new Array("171","82","19","249");
var Credit_Score_CalloutTop = new Array("80","85","197","100");
var Credit_Score_CalloutText = new Array("You may view your Credit Score by clicking here under the Reports menu.","Your actual credit score is listed up here.","This tells you how your score fares in relation to the rest of the population.","Your credit score is often a determinant as to whether or not you qualify for certain types of loans or credit cards.");
var Credit_Score_TextLeft = new Array("191","86","23","253");
var Credit_Score_TextTop = new Array("88","93","205","108");
var Credit_Score_BackLinkLeft = new Array("195","90","27","257");
var Credit_Score_NextLinkLeft = new Array("305","200","137","367");
var Credit_Score_LinkTop = new Array("136","141","253","156");

var Credit_Report_FrameCount = 3;
var Credit_Report_BackgroundSrc = new Array("Credit Report from under Reports menu.png","City View.png","City View.png");
var Credit_Report_ForegroundSrc = new Array("","Credit Report with more loans.png","Credit Report with more loans.png");
var Credit_Report_ForegroundLeft = new Array("0","153","178");
var Credit_Report_ForegroundTop = new Array("0","4","8");
var Credit_Report_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_left.gif");
var Credit_Report_CalloutLeft = new Array("165","7","35");
var Credit_Report_CalloutTop = new Array("96","241","333");
var Credit_Report_CalloutText = new Array("To access your Credit Report, click here under the Reports menu.","Your credit report lists any credit that is open in your name.","This report also lists any late credit card or loan payments that you have accrued on your credit history.");
var Credit_Report_TextLeft = new Array("185","11","39");
var Credit_Report_TextTop = new Array("104","249","341");
var Credit_Report_BackLinkLeft = new Array("189","15","43");
var Credit_Report_NextLinkLeft = new Array("299","125","153");
var Credit_Report_LinkTop = new Array("152","297","389");

var Bank_Statements_FrameCount = 7;
var Bank_Statements_BackgroundSrc = new Array("Bank Statements under Reports menu.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png");
var Bank_Statements_ForegroundSrc = new Array("","Bank Statement Screen.png","Bank Statement Scroll to diff month.png","Bank Statement Screen.png","Bank Statement Screen.png","Bank Statement Screen.png","Bank Statement Screen.png");
var Bank_Statements_ForegroundLeft = new Array("0","134","80","126","92","111","78");
var Bank_Statements_ForegroundTop = new Array("0","1","10","8","-7","5","2");
var Bank_Statements_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif");
var Bank_Statements_CalloutLeft = new Array("181","339","302","140","46","189","209");
var Bank_Statements_CalloutTop = new Array("123","11","179","122","115","111","119");
var Bank_Statements_CalloutText = new Array("To access your Bank Statements, click here under the Reports menu.","You can view statements for your checking or your savings account by clicking here.","If you want to look at different statements, you can click these arrows to move backwards or forwards.","Credits are amounts of money that have been deposited to your account.","Debits are amounts of money that have been withdrawn from your account.","The dates of your transactions are listed here.","After each transaction is made, the balance of your account is listed here.");
var Bank_Statements_TextLeft = new Array("201","343","306","144","50","193","213");
var Bank_Statements_TextTop = new Array("131","19","187","130","123","119","127");
var Bank_Statements_BackLinkLeft = new Array("205","347","310","148","54","197","217");
var Bank_Statements_NextLinkLeft = new Array("315","457","420","258","164","307","327");
var Bank_Statements_LinkTop = new Array("179","67","235","178","171","167","175");

var Credit_Card_Statements_FrameCount = 8;
var Credit_Card_Statements_BackgroundSrc = new Array("Credit Card Statements under Reports menu.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png");
var Credit_Card_Statements_ForegroundSrc = new Array("","Credit Card Statement Screen.png","Credit Card Statement Screen.png","Credit Card Statement Screen.png","Credit Card Statement Screen with Finance.png","Credit Card Offer Screen.png","Credit Card Statement Screen with Past Due.png","Credit Card Statement Screen with Past Due.png");
var Credit_Card_Statements_ForegroundLeft = new Array("0","140","71","97","87","29","93","48");
var Credit_Card_Statements_ForegroundTop = new Array("0","-2","2","2","0","133","-1","-1");
var Credit_Card_Statements_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif");
var Credit_Card_Statements_CalloutLeft = new Array("192","24","11","90","159","161","6","291");
var Credit_Card_Statements_CalloutTop = new Array("137","150","78","84","136","102","188","162");
var Credit_Card_Statements_CalloutText = new Array("To access your credit card statements, click here under the Reports menu.","Your credit card statement shows you the date of your purchase, where you made your purchase and the amount.","The statement also lists your previous balance, any payments you have made, any credits that have been made to your . . .",". . . account, the total amount of your purchases during that period, any finance charges and your new balance on your card.","You accrue finance charges when you don't pay off the full balance on your credit card.","Your finance charge will depend on the APR you were offered when you signed up for your credit card.","If you do not pay your credit card bill on time, you will be charged a late fee.","If you need to look at a different month's statement, click these arrows to scroll forwards and backwards.");
var Credit_Card_Statements_TextLeft = new Array("212","28","15","94","163","165","10","295");
var Credit_Card_Statements_TextTop = new Array("145","158","86","92","144","110","196","170");
var Credit_Card_Statements_BackLinkLeft = new Array("216","32","19","98","167","169","14","299");
var Credit_Card_Statements_NextLinkLeft = new Array("326","142","129","208","277","279","124","409");
var Credit_Card_Statements_LinkTop = new Array("193","206","134","140","192","158","244","218");

var Loan_Statements_FrameCount = 9;
var Loan_Statements_BackgroundSrc = new Array("Loan Statements under Reports menu.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png");
var Loan_Statements_ForegroundSrc = new Array("","Loan Statement Screen.png","Mortgage Statement.png","Auto Loan Statement.png","Mortgage Statement.png","Mortgage Statement.png","Mortgage Statement.png","Mortgage Statement.png","Loan Statement with Arrows.png");
var Loan_Statements_ForegroundLeft = new Array("0","113","86","80","92","149","131","112","62");
var Loan_Statements_ForegroundTop = new Array("0","-1","2","1","3","2","-2","0","0");
var Loan_Statements_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif");
var Loan_Statements_CalloutLeft = new Array("179","0","283","282","178","229","206","210","296");
var Loan_Statements_CalloutTop = new Array("149","0","18","7","145","89","201","375","167");
var Loan_Statements_CalloutText = new Array("To access Loan Statements, click here under the Reports menu.","If you decide to take a class, you may have a student loan. You won't make payments on the loan until you finish the class.","If you have an auto loan or a mortgage, payments will start coming due the month after you make your purchase.","If you have taken different types of loans, you can choose which statement you'd like to view by selecting it here.","Your loan statement will tell you the total amount due for that particular month and it tells you what . . .",". . . the due date is.","It also tells you what your payoff amount would be if you decided to pay your loan off by a certain date.","And, it tells you how much interest has accrued during the month.","If you need to view different statements, click on these arrows to move backwards or forwards.");
var Loan_Statements_TextLeft = new Array("199","4","287","286","182","233","210","214","300");
var Loan_Statements_TextTop = new Array("157","8","26","15","153","97","209","383","175");
var Loan_Statements_BackLinkLeft = new Array("203","8","291","290","186","237","214","218","304");
var Loan_Statements_NextLinkLeft = new Array("313","118","401","400","296","347","324","328","414");
var Loan_Statements_LinkTop = new Array("205","56","74","63","201","145","257","431","223");

var Investment_Statements_FrameCount = 6;
var Investment_Statements_BackgroundSrc = new Array("Investment Statements from under Reports menu.png","City View.png","City View.png","City View.png","City View.png","City View.png");
var Investment_Statements_ForegroundSrc = new Array("","Investment Statement Screen.png","View Portfolio Screen.png","Investment Statement Screen.png","Investment Statement Screen.png","Investment Statement Screen.png");
var Investment_Statements_ForegroundLeft = new Array("0","72","0","85","93","113");
var Investment_Statements_ForegroundTop = new Array("0","1","0","-1","0","2");
var Investment_Statements_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_center.gif","callout_left.gif","callout_left.gif","callout_left.gif");
var Investment_Statements_CalloutLeft = new Array("191","285","249","111","193","349");
var Investment_Statements_CalloutTop = new Array("170","28","100","106","106","172");
var Investment_Statements_CalloutText = new Array("To view your Investment Statements, click here under the Reports menu.","You can look at the statements for your different funds, by making your selection here.","In VBPF, you can invest in a wide variety of mutual funds.","This statement shows you how much each fund was worth at the beginning of the month and . . .",". . . how much it was worth by the end of the month.","To look at statements from different months, click these arrows to move backwards and forwards.");
var Investment_Statements_TextLeft = new Array("211","289","253","115","197","353");
var Investment_Statements_TextTop = new Array("178","36","108","114","114","180");
var Investment_Statements_BackLinkLeft = new Array("215","293","257","119","201","357");
var Investment_Statements_NextLinkLeft = new Array("325","403","367","229","311","467");
var Investment_Statements_LinkTop = new Array("226","84","156","162","162","228");

var Retirement_Statements_FrameCount = 6;
var Retirement_Statements_BackgroundSrc = new Array("Retirement Statements from under Reports menu.png","City View.png","City View.png","City View.png","City View.png","City View.png");
var Retirement_Statements_ForegroundSrc = new Array("","Retirement Statement Screen.png","401K Retirement Savings Elections Screen with Numbers Changed.png","Retirement Statement Screen.png","Retirement Statement Screen.png","Retirement Statement Screen.png");
var Retirement_Statements_ForegroundLeft = new Array("0","143","170","71","91","82");
var Retirement_Statements_ForegroundTop = new Array("0","1","30","2","4","-2");
var Retirement_Statements_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif");
var Retirement_Statements_CalloutLeft = new Array("193","353","0","118","212","316");
var Retirement_Statements_CalloutTop = new Array("187","21","0","112","114","177");
var Retirement_Statements_CalloutText = new Array("To access your Retirement Statements, click here under the Reports menu.","You can look at the statements for your different funds, by making your selection here.","In VBPF, you can invest in mutual funds for your retirement through your employer's 401K plan. ","This statement shows you how much each retirement fund was worth at the beginning of the month and . . .",". . . how much it was worth by the end of the month.","To look at statements from different months, click these arrows to move backwards and forwards.");
var Retirement_Statements_TextLeft = new Array("213","357","4","122","216","320");
var Retirement_Statements_TextTop = new Array("195","29","8","120","122","185");
var Retirement_Statements_BackLinkLeft = new Array("217","361","8","126","220","324");
var Retirement_Statements_NextLinkLeft = new Array("327","471","118","236","330","434");
var Retirement_Statements_LinkTop = new Array("243","77","56","168","170","233");

var Check_Register_FrameCount = 9;
var Check_Register_BackgroundSrc = new Array("Check Register from under Reports menu.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png");
var Check_Register_ForegroundSrc = new Array("","Check Register Screen.png","Check Register Screen.png","Check Register Screen.png","Check Register Screen.png","Check Register Screen.png","Check Register Screen.png","Check Register Screen.png","Check Register Screen.png");
var Check_Register_ForegroundLeft = new Array("0","10","11","12","8","15","13","16","6");
var Check_Register_ForegroundTop = new Array("0","0","12","5","14","16","2","3","2");
var Check_Register_CalloutSrc = new Array("callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_right.gif");
var Check_Register_CalloutLeft = new Array("159","87","246","148","269","393","0","0","241");
var Check_Register_CalloutTop = new Array("206","33","33","52","33","61","0","0","379");
var Check_Register_CalloutText = new Array("To access your Check Register, click here under the Reports menu.","Your check register lists the date of your transaction.","It lists a description of your transaction.","It shows if the transaction was a payment/debit (withdrawn from your account) or . . .",". . . if the transaction was a deposit/credit (money was put into your account).","It then adds or subtracts the amount depending on the type of transaction and keeps a running balance of your account.","In the New Career Project, the check register is automatically filled in.","In the lesson, Choosing and Balancing a Checking Account, you fill in the register manually and balance your account.","If you have multiple checking accounts, you may select which check register you'd like to view by clicking here.");
var Check_Register_TextLeft = new Array("179","107","266","152","273","397","4","4","261");
var Check_Register_TextTop = new Array("214","41","41","60","41","69","8","8","387");
var Check_Register_BackLinkLeft = new Array("183","111","270","156","277","401","8","8","265");
var Check_Register_NextLinkLeft = new Array("293","221","380","266","387","511","118","118","375");
var Check_Register_LinkTop = new Array("262","89","89","108","89","117","56","56","435");

var Pay__Tax_Records_FrameCount = 14;
var Pay__Tax_Records_BackgroundSrc = new Array("Pay & Tax Records from under Reports menu.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png");
var Pay__Tax_Records_ForegroundSrc = new Array("","Pay Stub Screen.png","Pay Stub Screen.png","Pay Stub Screen.png","Pay Stub Screen.png","Pay Stub Screen.png","Pay Stub Screen.png","Pay Stub Screen.png","Pay Stub Screen.png","W-2 Screen.png","W-2 Screen.png","W-2 Screen.png","1099 Screen.png","1099 Screen.png");
var Pay__Tax_Records_ForegroundLeft = new Array("0","44","24","34","39","42","34","52","36","48","46","67","46","37");
var Pay__Tax_Records_ForegroundTop = new Array("0","6","5","5","39","4","3","19","5","1","32","30","3","12");
var Pay__Tax_Records_CalloutSrc = new Array("callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_left.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_left.gif");
var Pay__Tax_Records_CalloutLeft = new Array("171","184","176","156","87","216","294","247","146","92","130","365","94","141");
var Pay__Tax_Records_CalloutTop = new Array("226","63","68","113","168","115","255","352","329","336","18","13","358","39");
var Pay__Tax_Records_CalloutText = new Array("To access your Pay andTax Records, click here under the Reports menu.","Your pay stub tells you how much you are witholding for taxes based on what you filled out on your W-4 form.","It tells you what your pay rate is.","It lists how many hours you worked and how much you earned for that particular pay period.","This statement also lists how much you have earned so far throughout the year.","Your statement lists how much money was deducted from the paycheck for various taxes and possibly retirement plans. ","This is your take home pay, the actual amount you received from your paycheck after all of the deductions.","If you'd like to view pay stubs from different years, you may click here and then make your selection.","If you want to view different month's statements, you may click on these arrows to move backwards and forwards.","To view your W-2 forms, you should click here. W-2 forms are sent to you by your employer each January.","Your W-2 form lists how much money you have earned throughout the past year here.","It lists how much money has been withheld for federal taxes here.","To view your 1099-INT form, click here. 1099-INT forms are sent by the bank each January.","The 1099-INT form lists how much interest you have earned throughout the year here.");
var Pay__Tax_Records_TextLeft = new Array("191","204","196","176","91","220","298","267","150","112","134","369","114","145");
var Pay__Tax_Records_TextTop = new Array("234","71","76","121","176","123","263","360","337","344","26","21","366","47");
var Pay__Tax_Records_BackLinkLeft = new Array("195","208","200","180","95","224","302","271","154","116","138","373","118","149");
var Pay__Tax_Records_NextLinkLeft = new Array("305","318","310","290","205","334","412","381","264","226","248","483","228","259");
var Pay__Tax_Records_LinkTop = new Array("282","119","124","169","224","171","311","408","385","392","74","69","414","95");

var Past_Tax_Returns_FrameCount = 3;
var Past_Tax_Returns_BackgroundSrc = new Array("Past Tax Returns from under Reports menu.png","City View.png","City View.png");
var Past_Tax_Returns_ForegroundSrc = new Array("","Past Tax Record from Level 1.png","Tax Pro Screen.png");
var Past_Tax_Returns_ForegroundLeft = new Array("0","54","19");
var Past_Tax_Returns_ForegroundTop = new Array("0","2","11");
var Past_Tax_Returns_CalloutSrc = new Array("callout_right.gif","callout_right.gif","callout_center.gif");
var Past_Tax_Returns_CalloutLeft = new Array("168","217","249");
var Past_Tax_Returns_CalloutTop = new Array("249","409","100");
var Past_Tax_Returns_CalloutText = new Array("To view your Past Tax Returns, click here under the Reports menu. (You'll learn more about filliing out tax returns later.)","If you'd like to look at tax returns from previous years, click here and then make your selection.","Past tax returns from Levels 2 and 3 of the New Career Project will look like this. (Yes, a tax professional does them for you!)");
var Past_Tax_Returns_TextLeft = new Array("188","237","253");
var Past_Tax_Returns_TextTop = new Array("257","417","108");
var Past_Tax_Returns_BackLinkLeft = new Array("192","241","257");
var Past_Tax_Returns_NextLinkLeft = new Array("302","351","367");
var Past_Tax_Returns_LinkTop = new Array("305","465","156");

var Actions_Journal_FrameCount = 3;
var Actions_Journal_BackgroundSrc = new Array("Actions Journal from under Reports menu.png","City View.png","City View.png");
var Actions_Journal_ForegroundSrc = new Array("","Actions Journal Screen.png","Actions Journal Screen.png");
var Actions_Journal_ForegroundLeft = new Array("0","27","27");
var Actions_Journal_ForegroundTop = new Array("0","4","0");
var Actions_Journal_CalloutSrc = new Array("callout_right.gif","callout_right.gif","callout_left.gif");
var Actions_Journal_CalloutLeft = new Array("175","280","11");
var Actions_Journal_CalloutTop = new Array("272","27","222");
var Actions_Journal_CalloutText = new Array("To access the Actions Journal, click here under the Reports menu.","The actions journal keeps a record of all of the actions you have taken throughout the simulation.","It also creates this graph, showing how your decisions have impacted your net worth.");
var Actions_Journal_TextLeft = new Array("195","300","15");
var Actions_Journal_TextTop = new Array("280","35","230");
var Actions_Journal_BackLinkLeft = new Array("199","304","19");
var Actions_Journal_NextLinkLeft = new Array("309","414","129");
var Actions_Journal_LinkTop = new Array("328","83","278");

var ACTIONS_FrameCount = 1;
var ACTIONS_BackgroundSrc = new Array("Actions Menu.png");
var ACTIONS_ForegroundSrc = new Array("");
var ACTIONS_ForegroundLeft = new Array("0");
var ACTIONS_ForegroundTop = new Array("0");
var ACTIONS_CalloutSrc = new Array("callout_right.gif");
var ACTIONS_CalloutLeft = new Array("243");
var ACTIONS_CalloutTop = new Array("1");
var ACTIONS_CalloutText = new Array("In VBPF, you control all the financial actions that you will control in the real world.");
var ACTIONS_TextLeft = new Array("263");
var ACTIONS_TextTop = new Array("9");
var ACTIONS_BackLinkLeft = new Array("267");
var ACTIONS_NextLinkLeft = new Array("377");
var ACTIONS_LinkTop = new Array("57");

var Apartments_for_Rent_FrameCount = 16;
var Apartments_for_Rent_BackgroundSrc = new Array("Apartments for Rent under Actions.png","City View.png","City View.png","Available Housing in City View.png","Available Housing in City View.png","Available Housing in City View.png","Available Housing with higher rent.png","Search for Job Data Entry.png","Enter Apartment.png","Enter Apartment.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png");
var Apartments_for_Rent_ForegroundSrc = new Array("","To Select Housing Screen.png","","","","","","","","","Choose Yourself Screen.png","Choose Yourself with Person chosen.png","Choose Yourself Name Typed In.png","Choose Yourself Name Typed In.png","Got Apartment Screen.png","");
var Apartments_for_Rent_ForegroundLeft = new Array("0","149","0","0","0","0","0","0","0","0","37","27","55","46","207","0");
var Apartments_for_Rent_ForegroundTop = new Array("0","112","0","0","0","0","0","0","0","0","63","33","45","27","142","0");
var Apartments_for_Rent_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_center.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_left.gif");
var Apartments_for_Rent_CalloutLeft = new Array("367","33","249","161","200","192","116","163","166","206","471","475","336","100","60","191");
var Apartments_for_Rent_CalloutTop = new Array("0","53","100","302","253","248","109","186","303","325","50","96","33","303","84","325");
var Apartments_for_Rent_CalloutText = new Array("To rent an apartment, click here under the Actions menu.","This message will appear and asks you to make your selection in the City view.","IMPORTANT: You won't be able to control any of the other actions until you rent your apartment.","To see what kind of housing is available, you must scroll over buildings that look like this in the City view.","Messages like this will pop up and will tell you what the lease terms are.","Apartments that are further from the downtown area are usually less expensive.","This apartment is closer to the office buildings and has a higher rent per month.","Before selecting your apartment, you may want to see where potential jobs are located.","For simplicity, all of the apartments are one bedroom with the same layout.","If you want to rent an apartment, you must first click on the building and then click here.","If this is the first time you are renting an apartment, you are asked to choose a person to represent you.","Choose your person by clicking on that person.","You must then type in the name of your person here.","When you are done, click here.","After you've done this, you will then receive a confirmation message letting you know that you got the apartment.","Once you have rented an apartment, your apartment will be labeled like this.");
var Apartments_for_Rent_TextLeft = new Array("387","37","253","165","204","196","120","167","186","226","491","495","356","104","64","195");
var Apartments_for_Rent_TextTop = new Array("8","61","108","310","261","256","117","194","311","333","58","104","41","311","92","333");
var Apartments_for_Rent_BackLinkLeft = new Array("391","41","257","169","208","200","124","171","190","230","495","499","360","108","68","199");
var Apartments_for_Rent_NextLinkLeft = new Array("501","151","367","279","318","310","234","281","300","340","605","609","470","218","178","309");
var Apartments_for_Rent_LinkTop = new Array("56","109","156","358","309","304","165","242","359","381","106","152","89","359","140","381");

var Transportation_FrameCount = 9;
var Transportation_BackgroundSrc = new Array("Transportation under Actions menu.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png");
var Transportation_ForegroundSrc = new Array("","Transportation Screen.png","Transportation Screen with Bus Selection.png","Transportation Screen with Bus Selection.png","Transportation Screen.png","Schedule With Work Filled In.png","","","");
var Transportation_ForegroundLeft = new Array("0","164","143","161","128","22","0","0","0");
var Transportation_ForegroundTop = new Array("0","54","35","15","43","7","0","0","0");
var Transportation_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_right.gif");
var Transportation_CalloutLeft = new Array("351","22","259","22","16","155","186","87","168");
var Transportation_CalloutTop = new Array("12","61","250","75","154","139","222","122","280");
var Transportation_CalloutText = new Array("To access Transportation, click here under the Actions menu.","This screen will then appear and you have to decide if you will travel by foot, bus, or by car.","Once you have made your choice, you must click here.","If you decide to travel by bus, you must be sure to purchase bus tokens.","You must have either purchased or leased a car to choose this option.","Some transportation options can take longer than others. Be sure to consult your schedule when deciding on your transportation.","If you live close to a bus stop, this is usually a feasible mode of transportation.","If you live close to where you work, you can usually use walking as your mode of transportation.","If you work as a pizza delivery person or pharmaceutical sales person, you will be required to have a car.");
var Transportation_TextLeft = new Array("371","26","279","26","20","175","190","91","188");
var Transportation_TextTop = new Array("20","69","258","83","162","147","230","130","288");
var Transportation_BackLinkLeft = new Array("375","30","283","30","24","179","194","95","192");
var Transportation_NextLinkLeft = new Array("485","140","393","140","134","289","304","205","302");
var Transportation_LinkTop = new Array("68","117","306","131","210","195","278","178","336");

var Schedule_FrameCount = 22;
var Schedule_BackgroundSrc = new Array("City View.png","Schedule under Actions menu.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png");
var Schedule_ForegroundSrc = new Array("","","Schedule.png","Schedule.png","Schedule.png","Change Activity Screen.png","Change Activity Screen with Different Times.png","Change Activity Screen with Different Times.png","Schedule with eat relax exercise.png","Schedule with eat relax exercise.png","Hours Conflict with other Activities.png","Schedule with School Filled In.png","Schedule with School Filled In.png","Schedule with School Filled In.png","Schedule With Work Filled In.png","Schedule With Work Filled In.png","Schedule with eat relax exercise.png","Change Activity Screen with Witholding and Payment.png","Schedule with eat relax exercise.png","Change Activity Screen with Different Times.png","Schedule with eat relax exercise.png","Change Activity Screen with 401K Option.png");
var Schedule_ForegroundLeft = new Array("0","0","23","23","11","214","195","221","9","19","49","21","13","10","8","8","8","224","4","207","32","138");
var Schedule_ForegroundTop = new Array("0","0","2","1","2","28","29","17","4","2","158","-2","0","-2","2","2","4","18","1","15","9","15");
var Schedule_CalloutSrc = new Array("callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_right.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_right.gif","callout_left.gif","callout_right.gif","callout_left.gif");
var Schedule_CalloutLeft = new Array("182","328","162","379","179","78","390","92","135","139","10","162","155","161","139","148","110","104","108","68","137","160");
var Schedule_CalloutTop = new Array("10","21","25","27","69","59","44","332","99","166","87","93","97","380","110","122","215","263","308","154","189","261");
var Schedule_CalloutText = new Array("To access your schedule, click here.","Or, you may access it here under the Actions menu.","This form allows you to plan your weekday schedule . . . ",". . . as well as your weekend schedule.","In order to schedule an activity, you must click on the activity.","This screen will then appear. You must select the start time of your activity by clicking on a time here.","Then you must select the end time for your activity by making a selection over here.","Once you are done making your selections, you should click here.","Once you have scheduled an activity, it will show up in your schedule.","When you apply for a job and are hired, your schedule will be filled in automaticlly for  work.","If you try to apply for a job that you don't have room for in your schedule, you will receive this message.","These pink bars represent your estimated travel time to get from place to place.","This particular schedule is using a car for transportation.","To change your mode of transportation, you may click here.","Some modes of transportation will take longer than others depending on where you live.","Be careful, because some modes of transportation won't get you to work on time.","If you want to quit an activity, you need to click on that activity . . .",". . . and then click here.","You can also change the time of an activity by clicking on that activity . . . ",". . . and then by clicking on different start or end times. You will then have to click \"OK\" after you make your changes.","Some jobs offer health benefits. To see if your current job offers them, you must first click here.","If this picture appears on this screen, then that means your current job offers health insurance.");
var Schedule_TextLeft = new Array("202","348","182","399","199","82","410","96","155","159","14","182","175","165","159","168","130","108","128","72","157","164");
var Schedule_TextTop = new Array("18","29","33","35","77","67","52","340","107","174","95","101","105","388","118","130","223","271","316","162","197","269");
var Schedule_BackLinkLeft = new Array("206","352","186","403","203","86","414","100","159","163","18","186","179","169","163","172","134","112","132","76","161","168");
var Schedule_NextLinkLeft = new Array("316","462","296","513","313","196","524","210","269","273","128","296","289","279","273","282","244","222","242","186","271","278");
var Schedule_LinkTop = new Array("66","77","81","83","125","115","100","388","155","222","143","149","153","436","166","178","271","319","364","210","245","317");

var Socializing_FrameCount = 9;
var Socializing_BackgroundSrc = new Array("City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","Apartment View with Party Going On.png","City View.png","City View.png");
var Socializing_ForegroundSrc = new Array("Schedule with Host a Party Option.png","Schedule with Host a Party Option.png","Plan Your Party Screen.png","Plan Your Party Screen with date and time selected.png","Plan Your Party Screen with date and time selected.png","Schedule with party scheduled.png","","Schedule Screen with other party invites.png","Schedule Screen with other party invites.png");
var Socializing_ForegroundLeft = new Array("15","9","113","77","120","9","0","16","9");
var Socializing_ForegroundTop = new Array("0","2","12","82","57","5","0","11","13");
var Socializing_CalloutSrc = new Array("callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif");
var Socializing_CalloutLeft = new Array("278","294","109","164","265","276","125","283","315");
var Socializing_CalloutTop = new Array("31","17","72","93","267","75","169","89","394");
var Socializing_CalloutText = new Array("Once you have made it to Level 2 of the New Career Project, you will be able to start hosting and attending parties.","To host a party, click here.","To plan your party, you need to choose a date by clicking on it.","You must then choose a starting and ending time for your party.","Click here once you've made your selections.","Once you have scheduled your party, it will show up here. Be sure to have music and party food or no one may come.","If you planned your party a few days in advance and have food and music, this is what a party will look like.","Once you start hosting parties, you will be invited to other peoples' parties. If you want to attend, click inside the box.","Once you have made your selections or changes, click here to exit this screen.");
var Socializing_TextLeft = new Array("282","298","113","168","285","280","129","287","319");
var Socializing_TextTop = new Array("39","25","80","101","275","83","177","97","402");
var Socializing_BackLinkLeft = new Array("286","302","117","172","289","284","133","291","323");
var Socializing_NextLinkLeft = new Array("396","412","227","282","399","394","243","401","433");
var Socializing_LinkTop = new Array("87","73","128","149","323","131","225","145","450");

var Condos_For_Sale_FrameCount = 30;
var Condos_For_Sale_BackgroundSrc = new Array("Condos for Sale from under Actions menu.png","City View.png","Condo Availability in Aerial View.png","Condo Availability in Aerial View.png","Enter Condo.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","Move to Condo from Aerial View.png","City View With C for Condo.png","City View With C for Condo.png","Change Insurance from Aerial View.png");
var Condos_For_Sale_ForegroundSrc = new Array("","To Select Housing Screen Includes Condo Ref.png","","","","Credit Denied MEssage.png","Pay for Condo Screen with Full Payment Needed.png","Pay for Condo Screen don't need full payment.png","Pay for Condo Screen don't need full payment.png","Pay for Condo Screen with payment changed.png","Pay for Condo Screen with payment changed.png","Pay for Condo Screen with payment changed.png","Pay for Condo Screen with Points.png","Pay for Condo Screen with type of mortgage.png","Pay for Condo Screen with payment changed.png","Pay for Condo Screen with payment changed.png","Pay for Condo Screen with payment changed.png","Home Owners Insurance Screen.png","Home Owners Insurance Screen.png","Home Owners Insurance Screen.png","Home Owners Insurance Screen with Amounts Changed.png","Home Owners Insurance Screen with Amounts Changed.png","Home Owners Insurance with premium.png","Home Owners Insurance with premium.png","Confirm Move Screen.png","Confirm Move Screen.png","","","","");
var Condos_For_Sale_ForegroundLeft = new Array("0","170","0","0","0","37","181","171","91","85","86","85","70","63","82","125","94","186","124","161","140","125","146","159","30","31","0","0","0","0");
var Condos_For_Sale_ForegroundTop = new Array("0","61","0","0","0","180","40","38","8","4","0","7","7","5","-1","4","2","42","31","46","30","55","47","66","128","144","0","0","0","0");
var Condos_For_Sale_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_left.gif","callout_left.gif");
var Condos_For_Sale_CalloutLeft = new Array("355","34","36","71","91","22","289","36","430","433","433","427","408","400","421","474","196","52","360","394","369","360","343","223","168","183","78","281","249","91");
var Condos_For_Sale_CalloutTop = new Array("45","11","257","196","325","116","49","170","28","145","237","223","85","112","44","299","343","12","57","108","131","188","196","261","69","111","295","223","100","328");
var Condos_For_Sale_CalloutText = new Array("In Level 3 of the New Career Project you can buy condos. To access Condos For Sale, you may click here.","This message will appear and asks you to make your selection in the City view.","To see which buildings are condos, mouse around the City view over buildings that look like this.","If the building is a condo, a message like this will appear. ","If you'd like to buy the condo, you should click on the building and then click here.","If your credit score is too low, you will receive this message. You don't qualify for a loan and you'd have to pay in full.","If your credit score is too low, you'll be required to pay in full. Note, the down payment is the sale price!","If you do qualify for a loan, you'll be offered a mortgage.","You can change the amount of your down payment by clicking these arrows here.","When you increase or decrease your down payment, the amount of your mortgage will change . . .",". . . as well as the amount of your monthly payment.","If your down payment is at least 20%, you won't be required to pay PMI (Private Mortgage Insurance).","Paying points, a fee do at closing, can reduce your interest rate and monthly payments.","The type of mortgage you select will affect your monthly payment.","If you have multiple bank accounts and you'd like to choose a different account, click here and make your selection.","After you have made your mortgage selections, the amount of money you will need for your closing will be listed here.","Click here when you are finished.","This screen will then appear. It explains that you must purchase insurance for your new condo.","This tells you the value of your condo.","You will be able to decide the amount of coverage you'd like for your condo by clicking these arrows.","You may then decide the amount of your deductible by clicking here and then making your selection.","The amount of your deductible is how much you will have to pay if something happens to the condo.","After you have made your selections, your yearly premium will be calculated and it  will appear here.","Click here when you are done.","Once you have purchased your condo, you will be asked if you want to move in right away.","You may do so, but if you have any months left on your lease, you will have to pay for them.","If you decide to move into your condo at a later time, you should click on the condo and then select here.","Once you have purchased your condo, it will be labeled like this in the City view.","You can purchase as many condos as you can afford.","If you decide you'd like to change the insurance for your condo, you may click on the condo and then select here.");
var Condos_For_Sale_TextLeft = new Array("375","38","40","75","95","26","293","40","450","453","453","447","428","420","441","494","216","56","380","414","389","380","363","243","188","187","82","301","253","95");
var Condos_For_Sale_TextTop = new Array("53","19","265","204","333","124","57","178","36","153","245","231","93","120","52","307","351","20","65","116","139","196","204","269","77","119","303","231","108","336");
var Condos_For_Sale_BackLinkLeft = new Array("379","42","44","79","99","30","297","44","454","457","457","451","432","424","445","498","220","60","384","418","393","384","367","247","192","191","86","305","257","99");
var Condos_For_Sale_NextLinkLeft = new Array("489","152","154","189","209","140","407","154","564","567","567","561","542","534","555","608","330","170","494","528","503","494","477","357","302","301","196","415","367","209");
var Condos_For_Sale_LinkTop = new Array("101","67","313","252","381","172","105","226","84","201","293","279","141","168","100","355","399","68","113","164","187","244","252","317","125","167","351","279","156","384");

var Work_FrameCount = 20;
var Work_BackgroundSrc = new Array("Work Under Actions Menu.png","City View.png","Cashier Employment Opp with benefits.png","Cashier Employment Opp with benefits.png","Cashier Employment Opp with benefits.png","Cashier Employment Opp with benefits.png","Cashier Employment Opp with benefits.png","Shift Manager Opportunity.png","Shift Manager Opportunity.png","Store Manager Opp.png","Data Entry Specialist Job Opp.png","IT Supervisor Job Opp.png","VP of IT Job Opp.png","Job Web Designer Web Engineer.png","Job VP Engineer.png","Job VP Engineer.png","Pharmaceutical Salesperson Job.png","Job Nurse Resident Doctor.png","Pizza Delivery Person Job.png","Apply for Job 1.png");
var Work_ForegroundSrc = new Array("","To find jobs screen.png","","","","","","","","","","","","","","","","","","");
var Work_ForegroundLeft = new Array("0","170","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0");
var Work_ForegroundTop = new Array("0","161","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0");
var Work_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif");
var Work_CalloutLeft = new Array("361","99","94","122","124","121","124","121","118","103","236","142","166","30","206","201","184","100","225","243");
var Work_CalloutTop = new Array("5","108","167","103","63","70","125","200","225","150","121","70","109","49","138","183","63","36","88","206");
var Work_CalloutText = new Array("To access Work, click here under the Actions menu.","This message will appear and asks you to make your selection in the City view.","If you mouse over this view, you will be able to find the job opportunities available to you.","This particular job doesn't require any experience or course credits.","It lists the job title, hours, days and hourly pay here.","If you don't have room in your schedule for this job, you should clear your schedule first or choose a different job.","You will also see any benefits your job may offer listed here.","Other types of job opportunities may require experience and course credits.","You may also see the same job opportunity listed, but they are for different days during the week or weekend.","Here is an opportunity for a store manager.","Here is an opportunity for a data entry specialist.","This is a job opportunity for an IT supervisor.","This one is for the vice president of IT. It requires a Bachelor's Degree and a lot of work experience.","Here are job opportunities for a web designer and software engineer.","Here is a job opportunity for a VP of Engineering.","The hourly pay rate is lower for these jobs compared to the other IT jobs, but there is opportunity for bonuses.","This job opportunity is for a pharmaceutical salesperson.","Here are available opportunities for a nurse, doctor and resident.","Here are opportunities for a pizza delivery person.","To apply for a job, you must click on the company's building and then make your selection here.");
var Work_TextLeft = new Array("381","103","98","126","128","125","128","125","122","107","240","146","170","34","226","221","188","104","229","247");
var Work_TextTop = new Array("13","116","175","111","71","78","133","208","233","158","129","78","117","57","146","191","71","44","96","214");
var Work_BackLinkLeft = new Array("385","107","102","130","132","129","132","129","126","111","244","150","174","38","230","225","192","108","233","251");
var Work_NextLinkLeft = new Array("495","217","212","240","242","239","242","239","236","221","354","260","284","148","340","335","302","218","343","361");
var Work_LinkTop = new Array("61","164","223","159","119","126","181","256","281","206","177","126","165","105","194","239","119","92","144","262");

var Applying_For_A_Job_FrameCount = 9;
var Applying_For_A_Job_BackgroundSrc = new Array("City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png");
var Applying_For_A_Job_ForegroundSrc = new Array("Apply for Job Name Filled In.png","Resume Screen.png","Apply for Job Education Choice.png","Apply for Job Work History Filled In.png","Apply for Job Months of Experience Filled In.png","Apply for Job Months of Experience Filled In.png","Apply for Job Months of Experience Filled In.png","Lying on Resume.png","Got Job Screen.png");
var Applying_For_A_Job_ForegroundLeft = new Array("80","144","70","99","70","127","103","27","39");
var Applying_For_A_Job_ForegroundTop = new Array("2","31","0","-7","-8","-20","-25","111","96");
var Applying_For_A_Job_CalloutSrc = new Array("callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_right.gif","callout_left.gif","callout_left.gif");
var Applying_For_A_Job_CalloutLeft = new Array("347","377","421","373","423","26","218","33","23");
var Applying_For_A_Job_CalloutTop = new Array("22","25","79","240","235","346","385","46","30");
var Applying_For_A_Job_CalloutText = new Array("The job application will appear and you must type in the correct name you used for your person here.","If you forget the name of your person, you may look at the resume under the Reports menu and you'll see it listed here.","You must then click here and make your selection if you have completed any courses or degrees.","Click here and select any job experience.","You can enter your months of experience by typing the number directly into this box or by using these arrow buttons.","If you have access to an automobile, you should click here. The job description will tell you if a car is required.","Once you have completed the application, you should click here.","If you have listed any false information on your resume, you will receive a message like this.","If you got the job, you will receive this message.");
var Applying_For_A_Job_TextLeft = new Array("367","397","441","393","443","30","238","37","27");
var Applying_For_A_Job_TextTop = new Array("30","33","87","248","243","354","393","54","38");
var Applying_For_A_Job_BackLinkLeft = new Array("371","401","445","397","447","34","242","41","31");
var Applying_For_A_Job_NextLinkLeft = new Array("481","511","555","507","557","144","352","151","141");
var Applying_For_A_Job_LinkTop = new Array("78","81","135","296","291","402","441","102","86");

var Getting_Paid_FrameCount = 12;
var Getting_Paid_BackgroundSrc = new Array("City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png");
var Getting_Paid_ForegroundSrc = new Array("Method of Pay Screen.png","Method of Pay Screen.png","Method of Pay Screen.png","W4 Tax Form.png","W4 Tax Form.png","W4 Tax Form.png","Travel Mode Notification.png","Transportation Screen.png","Schedule With Work Filled In.png","Schedule With Work Filled In.png","Message Center Screen with laid off message.png","You recently quit the job message.png");
var Getting_Paid_ForegroundLeft = new Array("164","147","205","14","7","29","83","150","30","13","19","141");
var Getting_Paid_ForegroundTop = new Array("76","54","83","-162","-44","-180","120","46","0","-1","251","162");
var Getting_Paid_CalloutSrc = new Array("callout_left.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif");
var Getting_Paid_CalloutLeft = new Array("28","399","108","12","408","224","55","12","145","155","262","77");
var Getting_Paid_CalloutTop = new Array("75","117","202","94","344","400","62","91","173","116","252","106");
var Getting_Paid_CalloutText = new Array("You will then need to determine how you would like to be paid by clicking inside the bubble next to the option of your choice.","If you choose direct deposit and you have multiple checking accounts, you must select your account by clicking here.","Once you are done making your selections, you must click here.","Then, a W-4 form will appear. A W-4 form is an IRS form that lets you choose how much tax to have withheld.","You can accept the defaults or choose to have more or less tax withheld.","When you are done, you may click here.","If this is the first job you have applied for, you will receive this message.","You will then have to select your mode of transportation by clicking in the bubble beside  your choice.","If you have been hired, your schedule will automatically be filled in.","Make sure you keep an eye on your estimated travel time so that you make it to work on time.","If you are late for work or if you have been laid off or fired, you will receive these types of messages here.","If you quit a job (via your schedule), you will not be able to reapply for 90 days.");
var Getting_Paid_TextLeft = new Array("32","419","112","16","412","244","59","16","165","175","282","81");
var Getting_Paid_TextTop = new Array("83","125","210","102","352","408","70","99","181","124","260","114");
var Getting_Paid_BackLinkLeft = new Array("36","423","116","20","416","248","63","20","169","179","286","85");
var Getting_Paid_NextLinkLeft = new Array("146","533","226","130","526","358","173","130","279","289","396","195");
var Getting_Paid_LinkTop = new Array("131","173","258","150","400","456","118","147","229","172","308","162");

var Education_FrameCount = 12;
var Education_BackgroundSrc = new Array("Education under the Actions menu.png","City View.png","Course Options Assoc Degree and Food Service Mgt.png","Course Options Assoc Degree and Food Service Mgt.png","Course Options Assoc Degree and Food Service Mgt.png","Course Options Bach Degree.png","Course Options Intro to Data and IT Mgt.png","Course Nurse Medical.png","Course Web Design.png","Enroll in Course.png","City View.png","City View.png");
var Education_ForegroundSrc = new Array("","To find Courses Screen.png","","","","","","","","","Schedule with School Filled In.png","Schedule with School Filled In.png");
var Education_ForegroundLeft = new Array("0","146","0","0","0","0","0","0","0","0","21","14");
var Education_ForegroundTop = new Array("0","101","0","0","0","0","0","0","0","0","0","0");
var Education_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_right.gif");
var Education_CalloutLeft = new Array("365","36","7","5","41","27","65","157","294","56","142","143");
var Education_CalloutTop = new Array("28","39","247","245","88","159","69","76","263","215","280","287");
var Education_CalloutText = new Array("To access Education, click here under the Actions menu.","You will then receive this message which asks you to mouse-over buildings in the City view to find your course.","When you mouse-over these buildings, you will see course descriptions pop up.","This particular building houses courses for an Associate's Degree and Food Service MGT I.","This screen gives you information regarding course title, hours, days, cost and length.","You also have a Bachelors Degree option as well as . . .",". . . Intro To Data Entry and IT Management. . .",". . . Nursing Degree and Medical Degree . . ."," . . . And Web Design.","If you'd like to enroll in a course, you must first click on the building that offers the course and then make the selection.","You should make sure your schedule is free at the time you'd like to take the course. ","Your course will appear on your schedule automatically once you decide which one you are going to take.");
var Education_TextLeft = new Array("385","40","11","9","45","31","69","161","298","60","162","163");
var Education_TextTop = new Array("36","47","255","253","96","167","77","84","271","223","288","295");
var Education_BackLinkLeft = new Array("389","44","15","13","49","35","73","165","302","64","166","167");
var Education_NextLinkLeft = new Array("499","154","125","123","159","145","183","275","412","174","276","277");
var Education_LinkTop = new Array("84","95","303","301","144","215","125","132","319","271","336","343");

var Student_Loans_FrameCount = 12;
var Student_Loans_BackgroundSrc = new Array("City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","Diploma for Completing Course.png");
var Student_Loans_ForegroundSrc = new Array("Request Student Loan Screen.png","Request Student Loan Screen.png","Request Student Loan Screen.png","Request Student Loan Screen with Amounts Changed.png","Request Student Loan Screen with Amounts Changed.png","Request Student Loan Screen with Amounts Changed.png","Request Student Loan Screen with Amounts Changed.png","Request Student Loan Screen with Amounts Changed.png","Request Student Loan Screen with Amounts Changed.png","Request Student Loan Screen with Amounts Changed.png","Request Student Loan Screen with Amounts Changed.png","");
var Student_Loans_ForegroundLeft = new Array("88","116","100","72","66","138","116","71","61","57","61","0");
var Student_Loans_ForegroundTop = new Array("51","50","43","45","36","37","51","57","34","23","55","0");
var Student_Loans_CalloutSrc = new Array("callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif");
var Student_Loans_CalloutLeft = new Array("372","458","442","414","412","486","459","413","407","389","400","229");
var Student_Loans_CalloutTop = new Array("30","43","62","105","113","130","165","195","212","229","70","163");
var Student_Loans_CalloutText = new Array("This student loan screen will appear after you have made your course selection.","This screen lists the cost of the course.","You may request the loan amount by typing it in here or by clicking these arrow buttons.","The interest rate on your loan appears here.","Your first payment will not be due until after the completion of the course.","The number of payments you will have to make will be listed here.","The amount of your monthly payment will be listed here. It is dependent on the amount of  loan that you requested.","The total payments you will make on the loan is listed here.","If you have decide to partially pay for the course up front, the amount you have elected to pay will be listed here.","You must decide how you will be paying your balance by clicking here and then making your selection.","If you don't have a bank account open at the time you apply for this loan, you will have to take a loan for the full course amount.","Once you have finished your course or degree, a diploma will appear here on the wall in your apartment.");
var Student_Loans_TextLeft = new Array("392","478","462","434","432","506","479","433","427","409","420","233");
var Student_Loans_TextTop = new Array("38","51","70","113","121","138","173","203","220","237","78","171");
var Student_Loans_BackLinkLeft = new Array("396","482","466","438","436","510","483","437","431","413","424","237");
var Student_Loans_NextLinkLeft = new Array("506","592","576","548","546","620","593","547","541","523","534","347");
var Student_Loans_LinkTop = new Array("86","99","118","161","169","186","221","251","268","285","126","219");

var Taxes_FrameCount = 29;
var Taxes_BackgroundSrc = new Array("Taxes under Actions menu.png","City View.png","Reports.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","Past Tax Returns from under Reports menu.png","City View.png");
var Taxes_ForegroundSrc = new Array("","Message Center Screen with Taxes are Ready.png","","Tax Screen.png","Tax Screen.png","W-2 Screen.png","Tax Screen.png","1099 Screen.png","Tax Screen.png","Tax Screen.png","Tax Screen.png","Tax Screen.png","Tax Screen.png","W-2 Screen.png","Taxes Screen Second Half.png","Tax Rate Schedule.png","Tax Rate Schedule.png","Tax Rate Schedule.png","Tax Rate Schedule.png","Tax Rate Schedule.png","Taxes Screen Second Half.png","Taxes Screen Second Half.png","Taxes Screen Second Half.png","Taxes Screen Second Half.png","Tax Filing Confirmation Screen.png","Pay By Screen.png","Past Tax Record from Level 1.png","","Tax Pro Screen.png");
var Taxes_ForegroundLeft = new Array("0","5","0","41","4","2","49","26","-10","26","15","29","-13","45","3","36","31","34","16","26","-18","0","1","40","223","177","22","0","20");
var Taxes_ForegroundTop = new Array("0","263","0","1","-14","15","1","5","-5","-4","-22","-23","-44","34","-17","37","20","51","39","49","-15","-9","-8","-17","110","69","-4","0","10");
var Taxes_CalloutSrc = new Array("callout_right.gif","callout_right.gif","callout_right.gif","callout_center.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_right.gif","callout_left.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_center.gif","callout_right.gif","callout_right.gif");
var Taxes_CalloutLeft = new Array("400","257","147","249","310","106","336","114","312","493","496","494","456","341","450","0","183","176","239","370","467","496","470","135","48","14","249","178","422");
var Taxes_CalloutTop = new Array("45","275","229","100","136","0","171","25","217","272","285","283","273","13","143","0","127","215","197","215","144","177","247","395","52","13","100","246","6");
var Taxes_CalloutText = new Array("To access Taxes, click here under the Actions menu.","You will not be able to file your taxes until after you receive this message on Jan. 1. You must file taxes by April 15.","Once that has happened, you'll want to retrieve your pay and tax records from the past year so that you can file your taxes.","The dollar amounts entered on this screen should be whole dollar amounts. ","You must fill in the amount of money you earned during the past year here.","This info is found on your W-2 form.","You must fill in any interest you've earned during the past year here. ","This may be found on your 1099-INT form.","You'll want to add the amounts you entered in lines 1 and 2 and enter it here.","Since you are single, you'll want to enter $8,450 on this line.","You'll need to subtract line 5 from line 4 and enter it here. This is your taxable income.","If line 5 is greater than line 4, you will enter a zero here which means you don't have any taxable income.","Enter the amount of taxes you have already paid to the federal government during the year here. ","This may be found on the W-2.","You must then use the tax table by clicking this link in order to find out what taxes you owe the government.","This Tax Rate Schedule will appear.","You must determine which tax category you fall into based on your taxable income which is line 6 on your 1040EZ form.","Once you figure out your tax category, you need to take this first number in the appropriate row and add it to . . . ",". . . the percentage listed here which you must multiply by . . .",". . . the amount of your taxable income which is over the amount listed in this column.","You must then enter that number here.","If line 7 is larger than line 11, you should subtract line 11 from line 7 and this will be your refund.","However, if line 11 is larger than line 7, you should subtract line 7 from line 11 and this is the amount you owe.","Once you are done filling in your tax form, you must click here.","Once you have submitted your tax form, you will receive this confirmation.","If you owe money to the government, you will be asked which method you'd like to use for payment.","Here is an example of a completed 1040EZ tax form.","You may access your Past Tax Returns by clicking here under the Reports menu.","In the New Career Project, once you make it to Level 2, this is what your tax form will look like. A tax professional prepares it.");
var Taxes_TextLeft = new Array("420","277","167","253","314","110","340","118","316","513","516","514","476","345","470","4","203","180","243","374","487","516","490","139","52","18","253","198","442");
var Taxes_TextTop = new Array("53","283","237","108","144","8","179","33","225","280","293","291","281","21","151","8","135","223","205","223","152","185","255","403","60","21","108","254","14");
var Taxes_BackLinkLeft = new Array("424","281","171","257","318","114","344","122","320","517","520","518","480","349","474","8","207","184","247","378","491","520","494","143","56","22","257","202","446");
var Taxes_NextLinkLeft = new Array("534","391","281","367","428","224","454","232","430","627","630","628","590","459","584","118","317","294","357","488","601","630","604","253","166","132","367","312","556");
var Taxes_LinkTop = new Array("101","331","285","156","192","56","227","81","273","328","341","339","329","69","199","56","183","271","253","271","200","233","303","451","108","69","156","302","62");

var Change_Witholding_FrameCount = 8;
var Change_Witholding_BackgroundSrc = new Array("Change Witholding under Actions menu.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png");
var Change_Witholding_ForegroundSrc = new Array("","Change Witholding Screen.png","","Schedule With Work Filled In.png","Change Activity Screen with Witholding and Payment.png","W4 Tax Form.png","W4 Tax Form.png","");
var Change_Witholding_ForegroundLeft = new Array("0","77","0","15","228","4","12","0");
var Change_Witholding_ForegroundTop = new Array("0","121","0","2","12","-36","-182","0");
var Change_Witholding_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_center.gif");
var Change_Witholding_CalloutLeft = new Array("377","29","182","109","127","433","231","249");
var Change_Witholding_CalloutTop = new Array("69","57","5","164","298","360","398","100");
var Change_Witholding_CalloutText = new Array("You can change the amount of taxes withheld from your paycheck. To Change Witholding, click here.","You will then receive this message which . . . ",". . . asks you to click the Schedule button and then . . . ",". . . click here . . .",". . . and then here.","You may then change your witholding amount by entering a new number here.","After you  have made your changes, you should then click here.","If you do not withhold enough money, you may end up owing a lot of taxes in April.");
var Change_Witholding_TextLeft = new Array("397","33","202","129","131","437","251","253");
var Change_Witholding_TextTop = new Array("77","65","13","172","306","368","406","108");
var Change_Witholding_BackLinkLeft = new Array("401","37","206","133","135","441","255","257");
var Change_Witholding_NextLinkLeft = new Array("511","147","316","243","245","551","365","367");
var Change_Witholding_LinkTop = new Array("125","113","61","220","354","416","454","156");

var Change_Method_of_Payment_FrameCount = 6;
var Change_Method_of_Payment_BackgroundSrc = new Array("Change Method of Payment under Actions menu.png","City View.png","City View.png","City View.png","City View.png","City View.png");
var Change_Method_of_Payment_ForegroundSrc = new Array("","Change Method of Payment Screen.png","","Schedule With Work Filled In.png","Change Activity Screen with Witholding and Payment.png","Method of Pay Screen.png");
var Change_Method_of_Payment_ForegroundLeft = new Array("0","83","0","12","206","182");
var Change_Method_of_Payment_ForegroundTop = new Array("0","176","0","-2","5","81");
var Change_Method_of_Payment_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_left.gif");
var Change_Method_of_Payment_CalloutLeft = new Array("400","70","171","115","165","29");
var Change_Method_of_Payment_CalloutTop = new Array("86","110","7","177","290","79");
var Change_Method_of_Payment_CalloutText = new Array("You can change how you are paid. To access Change Method of Payment, click here under the Actions menu.","You will then receive this message which asks you . . . ",". . . to click here on the Schedule button.","You must then click here . . .",". . . and then here.","This screen will then appear and you may then click next to the option of your choice.");
var Change_Method_of_Payment_TextLeft = new Array("420","74","191","135","169","33");
var Change_Method_of_Payment_TextTop = new Array("94","118","15","185","298","87");
var Change_Method_of_Payment_BackLinkLeft = new Array("424","78","195","139","173","37");
var Change_Method_of_Payment_NextLinkLeft = new Array("534","188","305","249","283","147");
var Change_Method_of_Payment_LinkTop = new Array("142","166","63","233","346","135");

var Change_Retirement_Contribution_FrameCount = 6;
var Change_Retirement_Contribution_BackgroundSrc = new Array("Change Retirement Contribution under Actions menu.png","City View.png","City View.png","City View.png","City View.png","City View.png");
var Change_Retirement_Contribution_ForegroundSrc = new Array("","Change 401K Contribution Screen.png","","Schedule With Work Filled In.png","Change Activity Screen with 401K Option.png","401K Retirement Savings Elections Screen with Numbers Changed.png");
var Change_Retirement_Contribution_ForegroundLeft = new Array("0","75","0","7","224","131");
var Change_Retirement_Contribution_ForegroundTop = new Array("0","190","0","1","25","23");
var Change_Retirement_Contribution_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_right.gif");
var Change_Retirement_Contribution_CalloutLeft = new Array("412","60","174","122","245","376");
var Change_Retirement_Contribution_CalloutTop = new Array("98","122","10","162","314","24");
var Change_Retirement_Contribution_CalloutText = new Array("You can change 401K retirement contributions.To access Change Retirement Contribution, you should click here.","This message will appear which asks you to . . ",". . . click here on the Schedule button and then . . .",". . . click here.","You must then click here.","This screen will appear. You may make your changes and then click \"OK\".");
var Change_Retirement_Contribution_TextLeft = new Array("432","64","194","142","249","396");
var Change_Retirement_Contribution_TextTop = new Array("106","130","18","170","322","32");
var Change_Retirement_Contribution_BackLinkLeft = new Array("436","68","198","146","253","400");
var Change_Retirement_Contribution_NextLinkLeft = new Array("546","178","308","256","363","510");
var Change_Retirement_Contribution_LinkTop = new Array("154","178","66","218","370","80");

var Pay_Bills_FrameCount = 19;
var Pay_Bills_BackgroundSrc = new Array("Pay Bills from Actions menu.png","Apartment View with Bills Waiting for Payment.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","Apartment View with Cash.png","Apartment View with Cash.png","City View.png","City View.png");
var Pay_Bills_ForegroundSrc = new Array("","","Pay Bills Screen.png","Pay Bills Screen.png","Pay By Screen.png","Pay by Check Screen.png","Pay by Check Screen.png","Pay by Check Screen.png","Pay by Check Screen.png","Select Credit Card Screen for Payment.png","Select Credit Card Screen with multiple cards.png","Select Credit Card Screen with credit card selected.png","Pay By Debit Card Screen.png","Pay by Debit Card Screen with two cards.png","Pay By Screen.png","","","Past Due Bill.png","Credit Score Screen.png");
var Pay_Bills_ForegroundLeft = new Array("0","0","61","60","201","10","10","18","6","63","36","57","65","52","250","0","0","84","85");
var Pay_Bills_ForegroundTop = new Array("0","0","-6","-12","55","5","5","1","2","133","99","35","31","44","66","0","0","-39","27");
var Pay_Bills_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_center.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_center.gif","callout_center.gif","callout_right.gif","callout_center.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif");
var Pay_Bills_CalloutLeft = new Array("310","197","7","295","56","249","335","253","320","249","238","220","249","0","153","267","329","53","254");
var Pay_Bills_CalloutTop = new Array("28","182","17","42","48","100","247","377","375","100","73","232","100","0","204","196","181","186","28");
var Pay_Bills_CalloutText = new Array("Bills arrive on the 28th of each month. To access Pay Bills, you may click here under the Actions menu.","Or, you may click here on the stack of bills found in your Apartment or Condo view.","This screen will appear.","To pay your bill, click here.","You may then click on the payment option of your choice.","If you decide to pay by check, your checkbook will then appear.","To change the amount of your payment, you may click within this area and alter the amount.","If you have different checking accounts, you may choose which account to use by clicking here and making your selection.","Once you are ready to submit your check, you may click here.","If you decide to pay by credit card, this screen will appear.","If you have multiple credit cards, you will have to select which card to use by clicking on it.","You may click here once you are ready to pay.","If you choose to pay by debit card, this screen will appear.","If you have multiple debit cards, you must choose the card you'd like to use for payment and then click \"OK\".","If you decide to pay by cash . . .",". . . you must make sure you have cash available. You can determine that by looking here in your Apartment view.","All bill payments are due by the 28th day the following month.","If you don't pay your bills on time, you will see this message on some of your bills. ","Not paying bills on time will affect your credit score negatively.");
var Pay_Bills_TextLeft = new Array("330","201","11","299","60","253","339","273","340","253","242","240","253","4","157","271","333","57","258");
var Pay_Bills_TextTop = new Array("36","190","25","50","56","108","255","385","383","108","81","240","108","8","212","204","189","194","36");
var Pay_Bills_BackLinkLeft = new Array("334","205","15","303","64","257","343","277","344","257","246","244","257","8","161","275","337","61","262");
var Pay_Bills_NextLinkLeft = new Array("444","315","125","413","174","367","453","387","454","367","356","354","367","118","271","385","447","171","372");
var Pay_Bills_LinkTop = new Array("84","238","73","98","104","156","303","433","431","156","129","288","156","56","260","252","237","242","84");

var Banking_FrameCount = 6;
var Banking_BackgroundSrc = new Array("Banking under Actions menu.png","City View.png","Bank Offer in Aerial View.png","Bank Offer in Aerial View.png","Bank Offer in Aerial View.png","Bank Offer in Aerial View.png");
var Banking_ForegroundSrc = new Array("","Banking Screen.png","","","","");
var Banking_ForegroundLeft = new Array("0","118","0","0","0","0");
var Banking_ForegroundTop = new Array("0","107","0","0","0","0");
var Banking_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_left.gif");
var Banking_CalloutLeft = new Array("320","31","36","468","471","42");
var Banking_CalloutTop = new Array("46","42","61","73","114","154");
var Banking_CalloutText = new Array("To access Banking, click here under the Actions menu.","This message will appear and will instruct you to mouse-over the bank buildings in the City view.","When you do so, you will see this type of information appear.","You'll find out if there is a monthly fee if you don't keep your checking account balance at a certain level.","You'll see what interest you'll earn on a savings account and if you'll be charged a monthly fee for the account.","You'll also see if the bank offers credit cards.");
var Banking_TextLeft = new Array("340","35","40","488","491","46");
var Banking_TextTop = new Array("54","50","69","81","122","162");
var Banking_BackLinkLeft = new Array("344","39","44","492","495","50");
var Banking_NextLinkLeft = new Array("454","149","154","602","605","160");
var Banking_LinkTop = new Array("102","98","117","129","170","210");

var Open_Checking_Account_FrameCount = 5;
var Open_Checking_Account_BackgroundSrc = new Array("Banking Options.png","City View.png","City View.png","City View.png","City View.png");
var Open_Checking_Account_ForegroundSrc = new Array("","Open Checking Account Screen.png","Open Checking Account Screen.png","Open Checking Account Screen With Amount.png","Congratulations Your New Account Has been opened.png");
var Open_Checking_Account_ForegroundLeft = new Array("0","203","257","233","249");
var Open_Checking_Account_ForegroundTop = new Array("0","42","51","14","168");
var Open_Checking_Account_CalloutSrc = new Array("callout_left.gif","callout_left.gif","callout_right.gif","callout_left.gif","callout_left.gif");
var Open_Checking_Account_CalloutLeft = new Array("345","69","407","101","78");
var Open_Checking_Account_CalloutTop = new Array("247","48","164","174","119");
var Open_Checking_Account_CalloutText = new Array("To open a checking account, you must click on the bank and then select here.","If this is your first account, your initial deposit  will have to be cash.","You may determine how much you'd like to deposit by typing in the amount here or by using these arrow buttons.","Once you are finished, you may click here.","You will receive this confirmation notice once your account has been opened.");
var Open_Checking_Account_TextLeft = new Array("349","73","427","105","82");
var Open_Checking_Account_TextTop = new Array("255","56","172","182","127");
var Open_Checking_Account_BackLinkLeft = new Array("353","77","431","109","86");
var Open_Checking_Account_NextLinkLeft = new Array("463","187","541","219","196");
var Open_Checking_Account_LinkTop = new Array("303","104","220","230","175");

var Open_Savings_Account_FrameCount = 6;
var Open_Savings_Account_BackgroundSrc = new Array("Open Savings Account.png","City View.png","City View.png","City View.png","City View.png","City View.png");
var Open_Savings_Account_ForegroundSrc = new Array("","Open Savings Account Screen.png","Open Savings Account Screen.png","Open Savings Account Screen.png","Open Savings Account Screen With Different Amount.png","Congratulations Your New Account Has been opened.png");
var Open_Savings_Account_ForegroundLeft = new Array("0","208","149","207","207","244");
var Open_Savings_Account_ForegroundTop = new Array("0","52","39","52","27","179");
var Open_Savings_Account_CalloutSrc = new Array("callout_left.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_left.gif");
var Open_Savings_Account_CalloutLeft = new Array("323","83","378","355","65","84");
var Open_Savings_Account_CalloutTop = new Array("203","68","99","171","185","126");
var Open_Savings_Account_CalloutText = new Array("To open a savings account, you should click on the bank of your choice and then select here.","This screen will appear. You must decide if your initial deposit will come from another account at the bank or from cash.","If you have multiple accounts at the bank, you will be able to choose your account by clicking here and then selecting.","You may enter the amount of your initial deposit by entering it here or by clicking on these arrow buttons.","After you have made your selections, you may click here.","You will receive this confirmation once the account has been opened.");
var Open_Savings_Account_TextLeft = new Array("327","87","398","375","69","88");
var Open_Savings_Account_TextTop = new Array("211","76","107","179","193","134");
var Open_Savings_Account_BackLinkLeft = new Array("331","91","402","379","73","92");
var Open_Savings_Account_NextLinkLeft = new Array("441","201","512","489","183","202");
var Open_Savings_Account_LinkTop = new Array("259","124","155","227","241","182");

var Deposit_Funds_FrameCount = 13;
var Deposit_Funds_BackgroundSrc = new Array("Deposit Funds.png","City View.png","Apartment View with Cash.png","Apartment View with Check Waiting for Deposit.png","Apartment View with Cash.png","Apartment View with Cash.png","Apartment View with Cash.png","Apartment View with Cash.png","City View.png","City View.png","Apartment View with Cash.png","City View.png","City View.png");
var Deposit_Funds_ForegroundSrc = new Array("","Deposit Funds Screen.png","","","Deposit Cash Window.png","Deposit Cash Window.png","Deposit Cash Window.png","Deposit Cash Window.png","Cash or Deposit Check Screen 2.png","Cash or Deposit Check Screen 2.png","","Cash or Deposit Check Screen 2.png","Cash or Deposit Check Screen 2.png");
var Deposit_Funds_ForegroundLeft = new Array("0","29","0","0","142","187","174","134","30","16","0","24","12");
var Deposit_Funds_ForegroundTop = new Array("0","135","0","0","62","68","63","71","41","49","0","14","21");
var Deposit_Funds_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_right.gif");
var Deposit_Funds_CalloutLeft = new Array("390","24","268","348","0","431","377","199","213","14","267","477","122");
var Deposit_Funds_CalloutTop = new Array("213","65","200","105","0","79","108","178","13","302","198","286","258");
var Deposit_Funds_CalloutText = new Array("To deposit funds into your account, you must click on your bank and then select here.","This message will appear which asks you to either . . .",". . . click on the pile of cash in your Apartment or Condo view or . . .",". . . click on the check in your Apartment or Condo view.","When you are depositing cash, this screen will appear.","You will  need to choose to which account you'd like to deposit the money by clicking here and then making your selection.","You will then type in the amount you would like to deposit or you may choose the amount by using these arrow buttons.","You should then click here when you are finished.","If you click on a check, this screen will appear.","You must decide if you'd like to cash the check or deposit the check by clicking next to the option of your choice.","If you cash the check, the money will appear here.","If you deposit the check, you need to choose your account by clicking here and then making your selection.","If you have multiple checks, you will be able to scroll through by clicking on the backwards and forwards arrows.");
var Deposit_Funds_TextLeft = new Array("410","28","272","352","4","451","397","219","233","18","271","497","142");
var Deposit_Funds_TextTop = new Array("221","73","208","113","8","87","116","186","21","310","206","294","266");
var Deposit_Funds_BackLinkLeft = new Array("414","32","276","356","8","455","401","223","237","22","275","501","146");
var Deposit_Funds_NextLinkLeft = new Array("524","142","386","466","118","565","511","333","347","132","385","611","256");
var Deposit_Funds_LinkTop = new Array("269","121","256","161","56","135","164","234","69","358","254","342","314");

var Withdraw_Cash_FrameCount = 5;
var Withdraw_Cash_BackgroundSrc = new Array("Withdraw Funds.png","City View.png","City View.png","City View.png","City View.png");
var Withdraw_Cash_ForegroundSrc = new Array("","Withdraw Cash Window.png","Withdraw Cash Window.png","Withdraw Cash Window.png","Withdraw Cash Window.png");
var Withdraw_Cash_ForegroundLeft = new Array("0","173","149","153","167");
var Withdraw_Cash_ForegroundTop = new Array("0","116","71","94","112");
var Withdraw_Cash_CalloutSrc = new Array("callout_left.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif");
var Withdraw_Cash_CalloutLeft = new Array("332","62","394","355","219");
var Withdraw_Cash_CalloutTop = new Array("314","52","84","135","212");
var Withdraw_Cash_CalloutText = new Array("If you'd like to withdraw funds, you first must click on your bank and then select here.","This window will appear.","You can decide from which account you'd like to withdraw your cash by clicking here and then making your selection.","You must then determine the amount you'd like to withdraw by entering it here or by using the arrow selection buttons.","Once you are done making your selections, you may click here.");
var Withdraw_Cash_TextLeft = new Array("336","66","414","375","239");
var Withdraw_Cash_TextTop = new Array("322","60","92","143","220");
var Withdraw_Cash_BackLinkLeft = new Array("340","70","418","379","243");
var Withdraw_Cash_NextLinkLeft = new Array("450","180","528","489","353");
var Withdraw_Cash_LinkTop = new Array("370","108","140","191","268");

var Transfer_Funds_FrameCount = 6;
var Transfer_Funds_BackgroundSrc = new Array("Transfer Funds.png","City View.png","City View.png","City View.png","City View.png","City View.png");
var Transfer_Funds_ForegroundSrc = new Array("","Transfer Funds Screen.png","Transfer Funds Screen.png","Transfer Funds Screen.png","Transfer Funds Screen.png","Transfer Funds Screen.png");
var Transfer_Funds_ForegroundLeft = new Array("0","215","188","156","172","177");
var Transfer_Funds_ForegroundTop = new Array("0","70","92","60","60","67");
var Transfer_Funds_CalloutSrc = new Array("callout_left.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif");
var Transfer_Funds_CalloutLeft = new Array("328","36","436","403","371","54");
var Transfer_Funds_CalloutTop = new Array("333","27","101","122","145","204");
var Transfer_Funds_CalloutText = new Array("To transfer funds, you must click on your bank and then select here.","This screen will then appear.","You may choose from which account you'd like to take the money by clicking here and then making your selection.","You may choose to which account you'd like to move the funds by clicking here and then making your selection.","You may determine the amount you'd like to transfer by entering it here or by using the arrow buttons.","Once you have finished making your selections, you may click here.");
var Transfer_Funds_TextLeft = new Array("332","40","456","423","391","58");
var Transfer_Funds_TextTop = new Array("341","35","109","130","153","212");
var Transfer_Funds_BackLinkLeft = new Array("336","44","460","427","395","62");
var Transfer_Funds_NextLinkLeft = new Array("446","154","570","537","505","172");
var Transfer_Funds_LinkTop = new Array("389","83","157","178","201","260");

var Close_Account_FrameCount = 4;
var Close_Account_BackgroundSrc = new Array("Close Account.PNG","City View.png","City View.png","City View.png");
var Close_Account_ForegroundSrc = new Array("","Close Account Screen.png","Close Account Screen.png","Close Account Screen.png");
var Close_Account_ForegroundLeft = new Array("0","216","156","190");
var Close_Account_ForegroundTop = new Array("0","108","77","70");
var Close_Account_CalloutSrc = new Array("callout_left.gif","callout_left.gif","callout_right.gif","callout_left.gif");
var Close_Account_CalloutLeft = new Array("322","57","400","79");
var Close_Account_CalloutTop = new Array("344","55","78","184");
var Close_Account_CalloutText = new Array("If you want to close your bank account or cancel your credit card, you may first click on your bank and the select here.","This screen will then appear.","You must choose the account you'd like to close by clicking here and then making your selection.","Once you have made your choice, you may click here.");
var Close_Account_TextLeft = new Array("326","61","420","83");
var Close_Account_TextTop = new Array("352","63","86","192");
var Close_Account_BackLinkLeft = new Array("330","65","424","87");
var Close_Account_NextLinkLeft = new Array("440","175","534","197");
var Close_Account_LinkTop = new Array("400","111","134","240");

var Online_Banking_FrameCount = 23;
var Online_Banking_BackgroundSrc = new Array("Online Banking from under Actions menu.png","Apartment View with Notebook Computer.png","Internet Connection in the Aerial View.png","Online Banking from under Actions menu.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png");
var Online_Banking_ForegroundSrc = new Array("","","","","Online Banking Screen.png","Pay Bills from Online Banking Screen.png","Pay Bills from Online Banking Screen Filled In.png","Pay Bills from Online Banking Screen Filled In.png","Pay Bills from Online Banking Screen Filled In.png","Online Banking Screen.png","Recurring Payments from Online Banking Screen.png","Recurring Payments from Online Banking Screen.png","Recurring Payments from Online Banking Screen.png","Recurring Payments from Online Banking Filled In.png","Online Banking Screen.png","Transfer Funds under Online Banking Screen.png","Transfer Funds under Online Banking Screen.png","Transfer Funds under Online Banking Screen.png","Transfer Funds under Online Banking Screen.png","Online Banking Screen.png","Checking Account Detail under Online Banking Screen.png","Online Banking Screen.png","Savings Account History under Online Banking Screen.png");
var Online_Banking_ForegroundLeft = new Array("0","0","0","0","37","45","35","36","32","53","29","6","33","31","35","15","47","20","31","33","35","31","32");
var Online_Banking_ForegroundTop = new Array("0","0","0","0","18","14","12","26","29","19","4","10","19","12","18","14","4","7","13","34","8","20","25");
var Online_Banking_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif");
var Online_Banking_CalloutLeft = new Array("330","199","67","320","87","419","409","99","344","131","404","480","394","127","107","282","314","346","339","142","392","129","391");
var Online_Banking_CalloutTop = new Array("58","160","255","64","35","36","107","329","45","72","37","131","142","340","94","81","100","146","190","157","40","165","50");
var Online_Banking_CalloutText = new Array("To access Online Banking, you must click here under the Actions menu.","In order for you to be able to use online banking, you must own a computer.","You must also have an Internet connection in your apartment or condo.","In the New Career Project, you will not be able to access this option until you reach Level 2.","To pay your bills using online banking, you must first click here. These will be one time payments.","You may select the account you'd like to use to pay your bills by clicking here and then making your selection.","You must then type in the amount you'd like to pay here.","When you are finished, you may click here to schedule your payments.","If you need to return to the main page at any point, you can always click this link.","To set up recurring payments, you may click here.","You may select the account you'd like to use for payments by clicking here and then making your selection.","You may select which day during the month your payment willl be made by clicking here and making your selection.","You must then type in the amount you'd like to pay each month, by typing it in here.","When you are done making your selections, you may click here.","If you'd like to transfer funds using online banking, you may click here.","You must select the account from which you'd like to transfer your money by clicking here and making your selection.","You must then select the account to which you like to transfer the money by clicking here and making your selection","You will enter the amount of money you'd like to transfer by typing it in here or by using the arrow buttons.","When you are done making your selections, you may click here to perform the transfer.","To look at your checking account records, you may click here.","You will then be brought to this screen which gives you your checking account history.","To view your savings account information, you must click here.","You will then be brought to this screen which gives you your savings account history.");
var Online_Banking_TextLeft = new Array("350","203","71","340","107","439","429","103","348","151","424","500","414","131","127","302","334","366","359","162","412","149","411");
var Online_Banking_TextTop = new Array("66","168","263","72","43","44","115","337","53","80","45","139","150","348","102","89","108","154","198","165","48","173","58");
var Online_Banking_BackLinkLeft = new Array("354","207","75","344","111","443","433","107","352","155","428","504","418","135","131","306","338","370","363","166","416","153","415");
var Online_Banking_NextLinkLeft = new Array("464","317","185","454","221","553","543","217","462","265","538","614","528","245","241","416","448","480","473","276","526","263","525");
var Online_Banking_LinkTop = new Array("114","216","311","120","91","92","163","385","101","128","93","187","198","396","150","137","156","202","246","213","96","221","106");

var Credit_Cards_FrameCount = 10;
var Credit_Cards_BackgroundSrc = new Array("Credit Cards under actions menu.png","City View.png","Apply for Credit Card.png","City View.png","City View.png","City View.png","City View.png","City View.png","Close Account.PNG","Credit Card Statements under Reports menu.png");
var Credit_Cards_ForegroundSrc = new Array("","To get a credit card screen.png","","Credit Card Offer Screen.png","Credit Card Offer Screen.png","Credit Card Offer Screen.png","Credit Card Offer Screen Different Offer.png","Credit Card Offer Screen Different Offer.png","","");
var Credit_Cards_ForegroundLeft = new Array("0","123","0","32","10","20","11","8","-26","0");
var Credit_Cards_ForegroundTop = new Array("0","137","0","109","104","138","141","94","50","0");
var Credit_Cards_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_left.gif","callout_right.gif");
var Credit_Cards_CalloutLeft = new Array("346","13","307","170","293","436","109","280","319","188");
var Credit_Cards_CalloutTop = new Array("46","77","219","78","73","108","72","116","345","137");
var Credit_Cards_CalloutText = new Array("Smart credit card use is key to personal finance. To access Credit Cards, click here under the Actions menu.","This screen will appear which asks you to mouse-over the banks in the city view in order to check out your options.","To apply for a credit card, you must first click on a bank and then select here.","An offer screen will pop up which tells you what your interest rate would be . . .",". . . what your credit limit would be . . .",". . . as well as what your late payment fee would be.","Different banks will make different credit card offers.","If you'd like to accept an offer, you should click here.","If you ever need to cancel a credit card, you may click here.","To review your credit card statements, you may select the report here under the Reports menu.");
var Credit_Cards_TextLeft = new Array("366","17","311","174","297","440","113","300","323","208");
var Credit_Cards_TextTop = new Array("54","85","227","86","81","116","80","124","353","145");
var Credit_Cards_BackLinkLeft = new Array("370","21","315","178","301","444","117","304","327","212");
var Credit_Cards_NextLinkLeft = new Array("480","131","425","288","411","554","227","414","437","322");
var Credit_Cards_LinkTop = new Array("102","133","275","134","129","164","128","172","401","193");

var Shop_For_Food_FrameCount = 13;
var Shop_For_Food_BackgroundSrc = new Array("Shop For Food under Actions menu.png","Apartment View With Furniture.png","City View.png","City View.png","City View.png","City View.png","Food in the fridge.png","City View.png","City View.png","City View.png","City View.png","City View.png","Apartment View with Party Foods.png");
var Shop_For_Food_ForegroundSrc = new Array("","","","Shop for Food Screen.png","Shop for Groceries with option selected.png","Shop for Groceries with option selected.png","","Snapshot Second Copy.png","Shop for Food Screen with Party Foods.png","Shop for Food Screen with Party Foods.png","Shop for Food Screen with Party Foods.png","Shop for Food Screen with Party Foods Selected.png","");
var Shop_For_Food_ForegroundLeft = new Array("0","0","0","13","-2","23","0","379","36","36","35","6","0");
var Shop_For_Food_ForegroundTop = new Array("0","0","0","15","6","6","0","362","17","17","20","5","0");
var Shop_For_Food_CalloutSrc = new Array("callout_right.gif","callout_right.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_center.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif");
var Shop_For_Food_CalloutLeft = new Array("388","95","311","495","469","128","225","439","249","446","460","482","119");
var Shop_For_Food_CalloutTop = new Array("70","146","157","20","127","318","242","325","100","5","7","105","91");
var Shop_For_Food_CalloutText = new Array("You'll need food to eat. To access Shop For Food, you must click here under the Actions menu.","Or, you may access the screen by clicking here in the Apartment view.","You may also access the screen by clicking on the supermarket in the City view.","You will be able to buy enough groceries to last you one, two or three weeks.","To make your selection, click here within one of these boxes.","Once you have made your selection, you may click here.","You will be able to see how much food is in the fridge by mousing-over the fridge.","You will also be able to see how much food is left in the fridge by clicking here on your Snapshot report.","Once you reach Level 2 of the New Career Project, you will be able to start hosting parties.","You will then be able to purchase party foods. ","If you offer food at your parties, more people will attend.","You can check multiple boxes at a time.","Once you purchase party foods, they will show up here in your Apartment or Condo view.");
var Shop_For_Food_TextLeft = new Array("408","115","315","515","489","148","245","459","253","466","480","502","123");
var Shop_For_Food_TextTop = new Array("78","154","165","28","135","326","250","333","108","13","15","113","99");
var Shop_For_Food_BackLinkLeft = new Array("412","119","319","519","493","152","249","463","257","470","484","506","127");
var Shop_For_Food_NextLinkLeft = new Array("522","229","429","629","603","262","359","573","367","580","594","616","237");
var Shop_For_Food_LinkTop = new Array("126","202","213","76","183","374","298","381","156","61","63","161","147");

var Shop_For_Goods_FrameCount = 9;
var Shop_For_Goods_BackgroundSrc = new Array("Shop for Goods under Actions menu.png","City View.png","Shop for Goods City view.png","City View.png","City View.png","City View.png","City View.png","Apartment View With Nothing.png","Apartment View with Dance Mat and Stereo.png");
var Shop_For_Goods_ForegroundSrc = new Array("","To shop for goods screen.png","","Shop for Goods Screen with Diff Prices.png","Shop for Goods Screen with item on sale.png","Shop for Goods Screen with Diff Prices.png","Shop for Goods Screen with item on sale.png","","");
var Shop_For_Goods_ForegroundLeft = new Array("0","126","0","8","4","13","29","0","0");
var Shop_For_Goods_ForegroundTop = new Array("0","95","0","3","9","12","8","0","0");
var Shop_For_Goods_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_left.gif");
var Shop_For_Goods_CalloutLeft = new Array("345","28","490","488","496","487","145","106","0");
var Shop_For_Goods_CalloutTop = new Array("83","35","270","13","37","139","329","70","0");
var Shop_For_Goods_CalloutText = new Array("To access Shop For Goods, click here under the Actions menu.","This screen will appear which asks you to click on the department stores in the City view in order to compare prices.","Department stores look like this. You may find out the names of the stores by clicking on them in the City view.","Once you click on the store, this screen will appear. All the department stores offer the same range of goods.","You should check out all of the stores in the city because they offer different pricing and often times have sales.","If you'd like to purchase a certain item, click here in this box.","When you are done shopping, you may click here to pay.","When you move into your apartment, it is empty except for what you see here.","Once you purchase goods, you will see them show up in your apartment or condo.");
var Shop_For_Goods_TextLeft = new Array("365","32","510","508","516","507","165","110","4");
var Shop_For_Goods_TextTop = new Array("91","43","278","21","45","147","337","78","8");
var Shop_For_Goods_BackLinkLeft = new Array("369","36","514","512","520","511","169","114","8");
var Shop_For_Goods_NextLinkLeft = new Array("479","146","624","622","630","621","279","224","118");
var Shop_For_Goods_LinkTop = new Array("139","91","326","69","93","195","385","126","56");

var Shop_For_Car_FrameCount = 28;
var Shop_For_Car_BackgroundSrc = new Array("Shop for Car under Actions menu.png","Shop for Car.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View with Car.png","City View with Car Moving.png");
var Shop_For_Car_ForegroundSrc = new Array("","","Shop for Car Screen.png","Shop for Car Screen Car Chosen.png","Shop for Car Screen Car Chosen.png","Pay for Car Screen.png","Pay for Car Screen.png","Pay for Car Screen.png","Pay for Car Screen.png","Pay for Car Screen.png","Pay for Car Screen.png","Pay for Car Screen.png","Pay for Car Screen.png","Pay for Car Screen.png","Pay for Car Screen.png","Pay for Car Screen.png","Pay for Car Screen.png","Pay for Car Screen.png","Pay for Car Screen.png","Pay for Car Screen.png","Pay for Car Screen.png","Pay for Car Screen.png","Auto Insurance Screen.png","Auto Insurance Screen.png","Auto Insurance Screen With Deductible Choices.png","Auto Insurance Screen.png","","");
var Shop_For_Car_ForegroundLeft = new Array("0","141","6","5","41","154","163","101","71","64","84","62","41","56","56","75","38","74","46","49","60","116","87","78","105","141","0","0");
var Shop_For_Car_ForegroundTop = new Array("0","71","8","6","7","7","2","-4","-13","2","20","7","2","7","17","9","13","10","13","7","6","5","13","3","13","50","0","0");
var Shop_For_Car_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif");
var Shop_For_Car_CalloutLeft = new Array("345","226","493","485","148","0","18","474","441","432","457","426","409","430","427","450","410","448","417","420","439","219","332","286","316","321","110","286");
var Shop_For_Car_CalloutTop = new Array("113","230","26","26","320","0","227","245","262","295","35","49","77","107","137","128","149","170","193","190","175","336","139","66","79","222","208","159");
var Shop_For_Car_CalloutText = new Array("To access Shop For Car, click here under the Actions menu.","Or, you may click on the car dealership in the City view and click here. There is only one dealership in town.","This screen will appear which allows you to look at the car selection the dealership has to offer.","To buy a car, you must click here next to the car of your choice.","And then you must click here in order to pay.","This screen will appear. You must choose between buying the car . . .",". . . or leasing the car.","If you lease the car, you will be responsible for making the payment listed here each month.","Your lease will last for two years.","If you decide to terminate your lease before your time is up, you will be responsible for making this payment.","If you decide to buy the car, the price of the car will be listed here.","You may enter an amount for your down payment here or you may use these arrow buttons.","If you have multiple checking accounts you may click here and select the account you'd like to use for payment.","The amount that you finance in order to pay for the car will be dependent on what your down payment will be.","This is the interest rate you will be charged  on your monthly payments in order to borrow the money to pay for the car.","The interest rate is dependent on your credit score.","The total number of monthly payments that you will have to make is listed here.","The amount of your monthly payment will be listed here.","The amount listed here is what you will have ended up paying for the car after you are finished with all of your payments.","You'll notice that this  is greater than the sale price. This is because you are paying interest on the money you borrow.","The monthly and total payments are also dependent on the amount of your down payment.","When you are done making your selections, you must click here.","This screen will then appear. You are required to carry liability coverage on your vehicle. ","You are free to choose if you would like to carry collision coverage","If you choose to carry this coverage, you must click here and then select your deductible.","The amount of your premium is dependent on what you choose as your deductible.","Once you purchase or lease a car, you will see it appear in front of your apartment or condo in the City view.","You will be able to watch your car move in the City view  when you are traveling somewhere.");
var Shop_For_Car_TextLeft = new Array("365","230","513","505","168","4","22","494","461","452","477","446","429","450","447","470","430","468","437","440","459","239","352","306","336","341","130","290");
var Shop_For_Car_TextTop = new Array("121","238","34","34","328","8","235","253","270","303","43","57","85","115","145","136","157","178","201","198","183","344","147","74","87","230","216","167");
var Shop_For_Car_BackLinkLeft = new Array("369","234","517","509","172","8","26","498","465","456","481","450","433","454","451","474","434","472","441","444","463","243","356","310","340","345","134","294");
var Shop_For_Car_NextLinkLeft = new Array("479","344","627","619","282","118","136","608","575","566","591","560","543","564","561","584","544","582","551","554","573","353","466","420","450","455","244","404");
var Shop_For_Car_LinkTop = new Array("169","286","82","82","376","56","283","301","318","351","91","105","133","163","193","184","205","226","249","246","231","392","195","122","135","278","264","215");

var Sell_Car_FrameCount = 6;
var Sell_Car_BackgroundSrc = new Array("Sell Car under Actions menu.png","Sell Car in the City View.png","City View.png","Apartment View with Bills Waiting for Payment.png","City View.png","City View.png");
var Sell_Car_ForegroundSrc = new Array("","","Confirm Sale Screen to End Lease.png","","Confirm Sale When you Own Car.png","Confirm Sale When you Own Car.png");
var Sell_Car_ForegroundLeft = new Array("0","0","23","0","18","17");
var Sell_Car_ForegroundTop = new Array("0","0","108","0","152","146");
var Sell_Car_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_right.gif");
var Sell_Car_CalloutLeft = new Array("365","205","32","204","15","290");
var Sell_Car_CalloutTop = new Array("128","198","41","190","85","173");
var Sell_Car_CalloutText = new Array("To access Sell Car, click here under the Actions menu.","Or, you may click on the auto dealership and select here.","If you are leasing a car, this message will appear. You'll have to pay a penalty if you want to end your lease early.","A bill will then show up here so that you can pay your early termination penalty.","If you own the car, then this message will appear.","If you agree to the terms of the sale and you want to sell your car, then click here to confirm.");
var Sell_Car_TextLeft = new Array("385","209","36","208","19","310");
var Sell_Car_TextTop = new Array("136","206","49","198","93","181");
var Sell_Car_BackLinkLeft = new Array("389","213","40","212","23","314");
var Sell_Car_NextLinkLeft = new Array("499","323","150","322","133","424");
var Sell_Car_LinkTop = new Array("184","254","97","246","141","229");

var Shop_For_Gas__Repairs_FrameCount = 11;
var Shop_For_Gas__Repairs_BackgroundSrc = new Array("Shop for Gas and Repairs under Actions menu.png","Shop for Gas in the Aerial View.png","City View.png","City View.png","City View.png","City View.png","City View.png","Gas Remaining when click on car.png","City View.png","Gas Remaining when click on car.png","Gas Remaining when click on car.png");
var Shop_For_Gas__Repairs_ForegroundSrc = new Array("","","Shop for Gas Screen.png","Shop for Gas Screen.png","Shop for Gas Screen Scrolled Down.png","Shop for Gas Screen Scrolled Down.png","Shop for Gas Screen Scrolled Down.png","","Snapshot.png","Message Center With Late message.png","");
var Shop_For_Gas__Repairs_ForegroundLeft = new Array("0","0","36","8","6","11","44","0","414","10","0");
var Shop_For_Gas__Repairs_ForegroundTop = new Array("0","0","18","21","2","6","9","0","379","265","0");
var Shop_For_Gas__Repairs_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_center.gif");
var Shop_For_Gas__Repairs_CalloutLeft = new Array("366","126","0","486","501","495","166","367","339","252","249");
var Shop_For_Gas__Repairs_CalloutTop = new Array("145","224","0","42","175","135","332","188","347","311","100");
var Shop_For_Gas__Repairs_CalloutText = new Array("If you own or lease a car, you'll need to buy gas.To access Shop For Gas and Repairs, click here under the Actions menu.","Or, you may click here on the Auto Garage.","This screen will then appear.","You may purchase 10, 20 or 30 gallons of gas by clicking here next to the appropriate selection","You may also purchase an oil change or a major repair if necessary by cliking in the box next to your selection.","You should get an oil change for your car every few months to help prevent the need for a major repair.","Once you are done making your selections, you may click here to pay.","You can always see how much gas your car has left by clicking on it in the City view . . .",". . . or, by clicking here on the Snapshot report.","If you don't have enough gas, you may not be able to get to class or work on time. ","If you are late too often, you may get fired from work or kicked out of school.");
var Shop_For_Gas__Repairs_TextLeft = new Array("386","130","4","506","521","515","186","371","343","272","253");
var Shop_For_Gas__Repairs_TextTop = new Array("153","232","8","50","183","143","340","196","355","319","108");
var Shop_For_Gas__Repairs_BackLinkLeft = new Array("390","134","8","510","525","519","190","375","347","276","257");
var Shop_For_Gas__Repairs_NextLinkLeft = new Array("500","244","118","620","635","629","300","485","457","386","367");
var Shop_For_Gas__Repairs_LinkTop = new Array("201","280","56","98","231","191","388","244","403","367","156");

var Buy_Bus_Tokens_FrameCount = 10;
var Buy_Bus_Tokens_BackgroundSrc = new Array("Buy Bus Tokens under Actions menu.png","Buy Bus Tokens.png","City View.png","City View.png","City View.png","Apartment View with Bills Waiting for Payment.png","Bus Tokens left.png","City View.png","Bus Tokens left.png","Bus Tokens left.png");
var Buy_Bus_Tokens_ForegroundSrc = new Array("","","Bus Token Screen.png","Bus Token Screen.png","Bus Token Screen.png","","","Snapshot with Bus Tokens.png","","");
var Buy_Bus_Tokens_ForegroundLeft = new Array("0","0","15","20","74","0","0","478","0","0");
var Buy_Bus_Tokens_ForegroundTop = new Array("0","0","24","15","5","0","0","355","0","0");
var Buy_Bus_Tokens_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_center.gif","callout_center.gif");
var Buy_Bus_Tokens_CalloutLeft = new Array("349","176","491","500","178","210","153","406","249","249");
var Buy_Bus_Tokens_CalloutTop = new Array("174","241","23","39","328","121","135","321","100","100");
var Buy_Bus_Tokens_CalloutText = new Array("To buy bus tokens, click here under the Actions menu.","Or, you may click on one of the bus stops to buy the tokens.","You may purchase bus tokens for 20, 60 or 100 rides.","To buy tokens, click in this box next to the appropriate selection.","Then you may click here to pay.","The bus tokens will appear here in your apartment or condo.","In order to see how many bus tokens you have left, you may mouse-over the stack of tokens and this message will appear.","Or, you may click here on your Snapshot report.","Remember, you can't take the bus if you don't have enough tokens. If you can't take the bus, you may be late for work . . .",". . . or school and if you're late too often, you may get fired or kicked out of school.");
var Buy_Bus_Tokens_TextLeft = new Array("369","180","511","520","198","230","157","410","253","253");
var Buy_Bus_Tokens_TextTop = new Array("182","249","31","47","336","129","143","329","108","108");
var Buy_Bus_Tokens_BackLinkLeft = new Array("373","184","515","524","202","234","161","414","257","257");
var Buy_Bus_Tokens_NextLinkLeft = new Array("483","294","625","634","312","344","271","524","367","367");
var Buy_Bus_Tokens_LinkTop = new Array("230","297","79","95","384","177","191","377","156","156");

var Internet_Access_FrameCount = 7;
var Internet_Access_BackgroundSrc = new Array("Internet Access from under the Actions menu.png","City View.png","Internet Connection in the Aerial View.png","Subscribe to Internet Access in Aerial View.png","City View.png","Cancel Internet Subscription.png","City View.png");
var Internet_Access_ForegroundSrc = new Array("","To subscribe to the Internet message.png","","","Confirm Subscription message for Internet.png","","Confirm Internet Cancellation message.png");
var Internet_Access_ForegroundLeft = new Array("0","94","0","0","193","0","222");
var Internet_Access_ForegroundTop = new Array("0","117","0","0","122","0","148");
var Internet_Access_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif");
var Internet_Access_CalloutLeft = new Array("333","31","65","55","55","63","63");
var Internet_Access_CalloutTop = new Array("194","56","254","267","55","288","88");
var Internet_Access_CalloutText = new Array("To purchase Internet access, which is required for online banking, click here under the Actions menu.","This message will appear which asks you to click on the Internet provider in the City view.","Once you click on the Internet provider's building . . .",". . . you must then click here to activate your Internet subcription.","This confirmation message will then appear.","To cancel your Internet subcription, click on the Internet provider's building and then click here.","This message will appear confirming your cancellation.");
var Internet_Access_TextLeft = new Array("353","35","69","59","59","67","67");
var Internet_Access_TextTop = new Array("202","64","262","275","63","296","96");
var Internet_Access_BackLinkLeft = new Array("357","39","73","63","63","71","71");
var Internet_Access_NextLinkLeft = new Array("467","149","183","173","173","181","181");
var Internet_Access_LinkTop = new Array("250","112","310","323","111","344","144");

var Health_Insurance_FrameCount = 10;
var Health_Insurance_BackgroundSrc = new Array("Healthcare under Actions menu.png","Healthcare under Actions menu.png","Healthcare from City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png");
var Health_Insurance_ForegroundSrc = new Array("","","","Health Insurance Screen.png","Health Insurance Screen with copay options.png","Healthcare screen with copay selected.png","Healthcare screen with copay selected.png","Health Insurance Bill.png","Healthcare screen with copay selected.png","");
var Health_Insurance_ForegroundLeft = new Array("0","0","0","141","140","86","131","79","142","0");
var Health_Insurance_ForegroundTop = new Array("0","0","0","43","31","52","57","-21","78","0");
var Health_Insurance_CalloutSrc = new Array("callout_right.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_center.gif");
var Health_Insurance_CalloutLeft = new Array("339","317","151","5","393","284","209","409","385","249");
var Health_Insurance_CalloutTop = new Array("62","61","270","3","102","161","212","160","147","100");
var Health_Insurance_CalloutText = new Array("Insurance is important for protecting your personal finances. ","To access Healthcare insurance, click here under the Actions menu.","Or, you may click here in the City view once you click on the insurance company building.","This screen will then appear. If your employer doesn't offer healthcare benefits, it is a good idea to sign up on your own.","To choose the type of coverage you'd like, you must click here and then make your selection.","The copay option you choose will determine your yearly cost for carrying the insurance.","Once you are finished making your decisions, click here.","You will be responsible for paying your health insurance bill each month.","This option means you will be responsible for $50 of your medical bill and the rest will be paid by the insurance company.","If you don't have health insurance, you will be responsible for paying all of your medical bills in full.");
var Health_Insurance_TextLeft = new Array("359","337","155","9","413","304","229","429","405","253");
var Health_Insurance_TextTop = new Array("70","69","278","11","110","169","220","168","155","108");
var Health_Insurance_BackLinkLeft = new Array("363","341","159","13","417","308","233","433","409","257");
var Health_Insurance_NextLinkLeft = new Array("473","451","269","123","527","418","343","543","519","367");
var Health_Insurance_LinkTop = new Array("118","117","326","59","158","217","268","216","203","156");

var Renters_Insurance_FrameCount = 9;
var Renters_Insurance_BackgroundSrc = new Array("Renters under Actions menu.png","Renters from City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png");
var Renters_Insurance_ForegroundSrc = new Array("","","Renter's Insurance Screen.png","Renter's Insurance Screen with Amounts Changed.png","Renter's Insurance Screen with Amounts Changed.png","Renter's Insurance Screen with Amounts Changed.png","Renter's Insurance All Filled In.png","Renter's Insurance All Filled In.png","Health Insurance Bill.png");
var Renters_Insurance_ForegroundLeft = new Array("0","0","155","91","185","145","159","154","59");
var Renters_Insurance_ForegroundTop = new Array("0","0","41","44","45","70","54","55","-2");
var Renters_Insurance_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif");
var Renters_Insurance_CalloutLeft = new Array("317","148","0","313","411","366","350","204","391");
var Renters_Insurance_CalloutTop = new Array("80","286","0","51","97","165","150","209","193");
var Renters_Insurance_CalloutText = new Array("To access Renter's insurance, click here. This insurance covers loss of property in your apartment.","Or, you may click here in the City view once you click on the insurance company's building.","This screen will appear. Right now, there is no coverage.","Type in the amount of coverage you'd like for your property here or use the arrow buttons to make your selection.","To choose the amount of your deductible, click here and then make your selection.","A deductible of $1000 means that if anything happens to your property, you will be responsible for $1000 of the damage.","Your insurance cost for the year is determined by your amount of coverage and your deductible.","Once you finish choosing your options, you should click here.","You will be responsible for paying your renter's insurance bill monthly.");
var Renters_Insurance_TextLeft = new Array("337","152","4","333","431","386","370","224","411");
var Renters_Insurance_TextTop = new Array("88","294","8","59","105","173","158","217","201");
var Renters_Insurance_BackLinkLeft = new Array("341","156","8","337","435","390","374","228","415");
var Renters_Insurance_NextLinkLeft = new Array("451","266","118","447","545","500","484","338","525");
var Renters_Insurance_LinkTop = new Array("136","342","56","107","153","221","206","265","249");

var Homeowners_Insurance_FrameCount = 11;
var Homeowners_Insurance_BackgroundSrc = new Array("Homeowners from under Actions menu.png","Homeowners from City View.png","City View.png","City View With C for Condo.png","City View.png","City View.png","City View.png","City View.png","City View.png","Homeowners insurance from Condo.png","City View.png");
var Homeowners_Insurance_ForegroundSrc = new Array("","","To Change Homeowners Insurance Screen.png","","Home Owners Insurance Screen.png","Home Owners Insurance Screen.png","Homeowners Insurance Screen with deductible options.png","Homeowners Insurance Screen with deductible options.png","Homeowners Insurance Screen with deductible options.png","","Homeowners Insurance Bill.png");
var Homeowners_Insurance_ForegroundLeft = new Array("0","0","113","0","148","142","163","138","119","0","71");
var Homeowners_Insurance_ForegroundTop = new Array("0","0","127","0","50","57","95","46","71","0","-12");
var Homeowners_Insurance_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_right.gif");
var Homeowners_Insurance_CalloutLeft = new Array("330","167","45","95","417","379","391","370","344","232","405");
var Homeowners_Insurance_CalloutTop = new Array("98","306","65","233","47","82","159","158","209","268","221");
var Homeowners_Insurance_CalloutText = new Array("To access Homeowner's insurance, click here under the Actions menu.","Or, you may click here once you click on the insurance company's building.","This screen will appear. It asks you to click on your condo within the City view in order to change your homeowner's insurance.","When you first purchase your condo, you are required to get insurance.","At the time of purchase you would have filled out the information on this screen.","This screen tells you the market value of your condo.","You may choose the amount of coverage you want by typing it in here or by using these arrow buttons to make your selection.","You may choose the amount of your deductible by clicking here and then making your selection.","This deductible means you'll be responsible for $500 worth of any damage or theft that occurs in your home.","Once you own your condo, you may make changes to your insurance by clicking the condo and then selecting here.","You will be responsible for making monthly payments on your homeowner's insurance.");
var Homeowners_Insurance_TextLeft = new Array("350","171","49","99","437","399","411","390","364","236","425");
var Homeowners_Insurance_TextTop = new Array("106","314","73","241","55","90","167","166","217","276","229");
var Homeowners_Insurance_BackLinkLeft = new Array("354","175","53","103","441","403","415","394","368","240","429");
var Homeowners_Insurance_NextLinkLeft = new Array("464","285","163","213","551","513","525","504","478","350","539");
var Homeowners_Insurance_LinkTop = new Array("154","362","121","289","103","138","215","214","265","324","277");

var Auto_Insurance_FrameCount = 10;
var Auto_Insurance_BackgroundSrc = new Array("Automobile under Actions menu.png","Automobile from City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png");
var Auto_Insurance_ForegroundSrc = new Array("","","Auto Insurance Screen.png","Auto Insurance Screen.png","Auto Insurance Screen With Deductible Choices.png","Auto Insurance Screen With Deductible Choices.png","Auto Insurance Screen.png","Auto Insurance Screen.png","Auto Insurance Screen.png","Homeowners Insurance Bill.png");
var Auto_Insurance_ForegroundLeft = new Array("0","0","174","171","123","157","153","130","196","53");
var Auto_Insurance_ForegroundTop = new Array("0","0","41","46","15","43","23","58","27","-16");
var Auto_Insurance_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_right.gif");
var Auto_Insurance_CalloutLeft = new Array("315","154","0","343","330","370","405","313","66","391");
var Auto_Insurance_CalloutTop = new Array("110","380","0","61","85","154","152","227","268","161");
var Auto_Insurance_CalloutText = new Array("To access automobile insurance, click here under the Actions menu.","Or, you may click on the insurance company and then click here.","This screen will then appear.","This is the estimated value of your car.","If you choose to have collision coverage, you may choose your deductible by clicking here and making your selection.","This means that you will have to pay up to $1000 for any collision damage done to your car in an accident.","Having liability coverage is mandatory.","This is how much your auto insurance will cost for the entire year. It is dependent on the amount of your deductible.","Click here once you are done with your selection.","You wil be responsible for making a monthly payment on your auto insurance.");
var Auto_Insurance_TextLeft = new Array("335","158","4","363","350","390","425","333","70","411");
var Auto_Insurance_TextTop = new Array("118","388","8","69","93","162","160","235","276","169");
var Auto_Insurance_BackLinkLeft = new Array("339","162","8","367","354","394","429","337","74","415");
var Auto_Insurance_NextLinkLeft = new Array("449","272","118","477","464","504","539","447","184","525");
var Auto_Insurance_LinkTop = new Array("166","436","56","117","141","210","208","283","324","217");

var Research_Funds_FrameCount = 11;
var Research_Funds_BackgroundSrc = new Array("Research Funds from under Actions menu.png","Research Funds from under Actions menu.png","Research Funds in City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png");
var Research_Funds_ForegroundSrc = new Array("","","","Research Funds Screen.png","Research Funds Screen with Category Selection.png","Research Funds Screen.png","Research Funds Screen.png","Research Funds Screen.png","Research Funds 5 Year.png","Research Funds 5 Year.png","Research Funds Screen.png");
var Research_Funds_ForegroundLeft = new Array("0","0","0","0","-128","-68","-1","0","0","3","0");
var Research_Funds_ForegroundTop = new Array("0","0","0","16","44","11","5","5","3","2","3");
var Research_Funds_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_left.gif");
var Research_Funds_CalloutLeft = new Array("350","0","92","247","497","503","419","142","206","210","316");
var Research_Funds_CalloutTop = new Array("77","0","317","34","48","68","111","302","295","122","324");
var Research_Funds_CalloutText = new Array("As your money grows, you will want to invest it. You can invest in a number of different mutual funds.","To Research Funds, click here under the Actions menu.","Or, you may click on the investment company in the City view and click here.","This screen will appear.","You may choose to research funds by category or all at once by clicking here and then making your selection.","To research a particular fund, click on it here.","The fund perfomance will be shown here.","If you click here, you will see a one year fund performance.","To see a five year performance, click here.","The fund's value and return information will be listed here.","If you want to export the funds' price histories to Excel, you may click here.");
var Research_Funds_TextLeft = new Array("370","4","96","267","517","523","439","146","210","230","320");
var Research_Funds_TextTop = new Array("85","8","325","42","56","76","119","310","303","130","332");
var Research_Funds_BackLinkLeft = new Array("374","8","100","271","521","527","443","150","214","234","324");
var Research_Funds_NextLinkLeft = new Array("484","118","210","381","631","637","553","260","324","344","434");
var Research_Funds_LinkTop = new Array("133","56","373","90","104","124","167","358","351","178","380");

var Buy_Shares_FrameCount = 7;
var Buy_Shares_BackgroundSrc = new Array("City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png");
var Buy_Shares_ForegroundSrc = new Array("Research Funds Screen.png","Buy Shares Screen.png","Buy Shares with Fund Selection.png","Buy Shares Screen.png","Buy Shares Screen.png","Buy Shares Screen.png","Research Funds Screen.png");
var Buy_Shares_ForegroundLeft = new Array("5","118","119","111","143","152","4");
var Buy_Shares_ForegroundTop = new Array("4","76","60","58","82","59","3");
var Buy_Shares_CalloutSrc = new Array("callout_left.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif");
var Buy_Shares_CalloutLeft = new Array("160","6","377","356","390","230","214");
var Buy_Shares_CalloutTop = new Array("322","8","53","89","159","181","377");
var Buy_Shares_CalloutText = new Array("If you decide you would like to purchase some shares, you may click here.","This screen will appear.","To choose the fund you'd like to purchase, click here and then make your selection.","You may type in the dollar amount you'd like to purchase here or you may use these arrow buttons to make the selection.","Select any checking account or cash as your source of payment.","When you are done making your selections, you may click here.","When you are finished with this screen click here to exit.");
var Buy_Shares_TextLeft = new Array("164","10","397","376","410","250","234");
var Buy_Shares_TextTop = new Array("330","16","61","97","167","189","385");
var Buy_Shares_BackLinkLeft = new Array("168","14","401","380","414","254","238");
var Buy_Shares_NextLinkLeft = new Array("278","124","511","490","524","364","348");
var Buy_Shares_LinkTop = new Array("378","64","109","145","215","237","433");

var View_Portfolio_FrameCount = 10;
var View_Portfolio_BackgroundSrc = new Array("View Portfolio from under Actions menu.png","View Portfolio in City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png");
var View_Portfolio_ForegroundSrc = new Array("","","View Portfolio Screen.png","View Portfolio Screen.png","View Portfolio Screen.png","View Portfolio Screen.png","View Portfolio Screen.png","Research Funds Screen.png","View Portfolio Screen.png","Buy Shares Screen.png");
var View_Portfolio_ForegroundLeft = new Array("0","0","0","-9","-3","4","12","3","11","104");
var View_Portfolio_ForegroundTop = new Array("0","0","4","9","3","0","8","11","11","39");
var View_Portfolio_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_left.gif");
var View_Portfolio_CalloutLeft = new Array("396","190","374","302","324","276","66","270","195","0");
var View_Portfolio_CalloutTop = new Array("93","346","22","138","157","37","84","43","94","0");
var View_Portfolio_CalloutText = new Array("To access View Portfolio, click here under the Actions menu.","Or, you may click on the investment company and then select here in the City view.","This screen will appear.","Here is a chart which describes your fund allocation.","Right  now you are most heavily invested in bonds and least invested in U.S. Stocks.","This report lists the funds you own, the number of shares of each fund, the price and change and the value of each fund.","If you want to review a fund, click on the fund . . .",". . . and this screen will appear.","If you want to buy more of a fund, click here and . . . ",". . . this screen will appear.");
var View_Portfolio_TextLeft = new Array("416","194","394","306","328","296","86","290","199","4");
var View_Portfolio_TextTop = new Array("101","354","30","146","165","45","92","51","102","8");
var View_Portfolio_BackLinkLeft = new Array("420","198","398","310","332","300","90","294","203","8");
var View_Portfolio_NextLinkLeft = new Array("530","308","508","420","442","410","200","404","313","118");
var View_Portfolio_LinkTop = new Array("149","402","78","194","213","93","140","99","150","56");

var Sell_Shares_FrameCount = 7;
var Sell_Shares_BackgroundSrc = new Array("City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png");
var Sell_Shares_ForegroundSrc = new Array("View Portfolio Screen.png","Sell Shares.png","Sell Shares with share selection.png","Sell Shares.png","Sell Shares.png","Sell Shares.png","View Portfolio Screen.png");
var Sell_Shares_ForegroundLeft = new Array("-11","86","136","110","139","115","6");
var Sell_Shares_ForegroundTop = new Array("14","61","68","71","102","65","0");
var Sell_Shares_CalloutSrc = new Array("callout_left.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_right.gif");
var Sell_Shares_CalloutLeft = new Array("206","25","389","353","391","188","193");
var Sell_Shares_CalloutTop = new Array("96","24","65","101","177","189","368");
var Sell_Shares_CalloutText = new Array("If you want to sell some of your shares, you need to click here and . . .",". . . this screen will appear.","To sell shares, you must click here and then select the fund you'd like to sell.","You must then either type in the dollar amount of the shares you'd like to sell or make your selection by using the arrow buttons.","Select to receive your proceeds in any checking account or as cash.","When you are finished making your selections, click here.","When you are done with this screen, you may click here to exit.");
var Sell_Shares_TextLeft = new Array("210","29","409","373","411","208","213");
var Sell_Shares_TextTop = new Array("104","32","73","109","185","197","376");
var Sell_Shares_BackLinkLeft = new Array("214","33","413","377","415","212","217");
var Sell_Shares_NextLinkLeft = new Array("324","143","523","487","525","322","327");
var Sell_Shares_LinkTop = new Array("152","80","121","157","233","245","424");

var View_Retirement_Portfolio_FrameCount = 21;
var View_Retirement_Portfolio_BackgroundSrc = new Array("View Retirement Portfolio from under Actions menu.png","View Retirement Portfolio in Cit View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png","City View.png");
var View_Retirement_Portfolio_ForegroundSrc = new Array("","","Retirement Portfolio Screen.png","Retirement Portfolio Screen.png","Retirement Portfolio Screen.png","Retirement Portfolio Screen.png","Retirement Portfolio Screen.png","Research Funds Screen.png","Retirement Portfolio Screen.png","Sell Shares.png","Retirement Withdrawl Too Early.png","401K Plan Screen.png","401K Retirement Savings Elections Screen.png","401K Retirement Savings Elections Screen with Numbers Changed.png","401K Retirement Savings Elections Screen with Numbers Changed.png","401K Retirement Savings Elections Screen with Numbers Changed.png","401K Retirement Savings Elections Screen with Numbers Changed.png","401K Retirement Savings Elections Screen with Numbers Changed.png","401K Retirement Savings Elections Screen with Numbers Changed.png","401K Retirement Savings Elections Screen with Numbers Changed.png","401K Retirement Savings Elections Screen with Numbers Changed.png");
var View_Retirement_Portfolio_ForegroundLeft = new Array("0","0","1","1","0","0","-5","4","5","82","20","11","163","178","176","197","177","158","171","165","179");
var View_Retirement_Portfolio_ForegroundTop = new Array("0","0","6","6","5","7","2","4","3","83","125","138","56","91","74","51","55","81","30","45","12");
var View_Retirement_Portfolio_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_left.gif","callout_right.gif","callout_left.gif");
var View_Retirement_Portfolio_CalloutLeft = new Array("369","182","329","320","327","283","103","252","219","35","11","142","13","405","404","59","461","224","19","250","19");
var View_Retirement_Portfolio_CalloutTop = new Array("112","366","7","135","140","48","88","1","90","46","58","75","1","92","106","151","178","199","171","293","43");
var View_Retirement_Portfolio_CalloutText = new Array("To access View Retirement Portfolio, click here under the Actions menu.","Or, you may click on the investment company in the City view and then click here.","This screen will then appear.","This chart shows your fund allocation in your retirement portfolio.","This portfolio is highly invested in money market funds and least invested in bonds.","The retirement portfolio shows you how many shares of which funds you own as well as price and change and value info.","If you want to research a fund that you own, click on it and . . .",". . . this screen will appear.","If you want to sell shares that you own, click here and . . .",". . . this screen will appear.","If you sell shares from your 401K before you are 59 1/2 years old, you will have to pay a penalty.","You would have set up your retirement portfolio initially when you accepted this option from a new employer that offered one.","If you accepted this option, this screen would have appeared.","You may type in the percent of your paycheck that you'd like to withold  to put into your retirement account here.","The percentage that your company will contribute towards your retirement plan will appear here.","You must then decide in which funds you'd like to invest your retirement money.","You may scroll up and down to look at the funds by clicking here and moving this bar or by using the arrow buttons.","If you want to invest in a fund, you must type in the percentage you want to invest here or you may use the arrow buttons.","The percentages you enter must add up to 100%.","When you are done making your selections, you may click here.","You can change these allocations later. See Change Retirement Contribution.");
var View_Retirement_Portfolio_TextLeft = new Array("389","186","349","324","331","303","123","272","223","39","15","162","17","425","424","63","481","244","23","270","23");
var View_Retirement_Portfolio_TextTop = new Array("120","374","15","143","148","56","96","9","98","54","66","83","9","100","114","159","186","207","179","301","51");
var View_Retirement_Portfolio_BackLinkLeft = new Array("393","190","353","328","335","307","127","276","227","43","19","166","21","429","428","67","485","248","27","274","27");
var View_Retirement_Portfolio_NextLinkLeft = new Array("503","300","463","438","445","417","237","386","337","153","129","276","131","539","538","177","595","358","137","384","137");
var View_Retirement_Portfolio_LinkTop = new Array("168","422","63","191","196","104","144","57","146","102","114","131","57","148","162","207","234","255","227","349","99");

var USEFUL_TOOLS_FrameCount = 1;
var USEFUL_TOOLS_BackgroundSrc = new Array("City View.png");
var USEFUL_TOOLS_ForegroundSrc = new Array("");
var USEFUL_TOOLS_ForegroundLeft = new Array("0");
var USEFUL_TOOLS_ForegroundTop = new Array("0");
var USEFUL_TOOLS_CalloutSrc = new Array("callout_center.gif");
var USEFUL_TOOLS_CalloutLeft = new Array("249");
var USEFUL_TOOLS_CalloutTop = new Array("100");
var USEFUL_TOOLS_CalloutText = new Array("Virtual Business - Personal Finance also includes a number of other useful tools. Here is an overview.<br />");
var USEFUL_TOOLS_TextLeft = new Array("253");
var USEFUL_TOOLS_TextTop = new Array("108");
var USEFUL_TOOLS_BackLinkLeft = new Array("257");
var USEFUL_TOOLS_NextLinkLeft = new Array("367");
var USEFUL_TOOLS_LinkTop = new Array("156");

var Saving_FrameCount = 2;
var Saving_BackgroundSrc = new Array("Save As from under File menu.png","City View.png");
var Saving_ForegroundSrc = new Array("","Save As Screen.png");
var Saving_ForegroundLeft = new Array("0","84");
var Saving_ForegroundTop = new Array("0","25");
var Saving_CalloutSrc = new Array("callout_right.gif","callout_center.gif");
var Saving_CalloutLeft = new Array("132","249");
var Saving_CalloutTop = new Array("75","100");
var Saving_CalloutText = new Array("To save a file, choose this option under the File menu.","You may choose a name for your file and save it to any directory you select.<br />");
var Saving_TextLeft = new Array("152","253");
var Saving_TextTop = new Array("83","108");
var Saving_BackLinkLeft = new Array("156","257");
var Saving_NextLinkLeft = new Array("266","367");
var Saving_LinkTop = new Array("131","156");

var Loading_a_File_FrameCount = 1;
var Loading_a_File_BackgroundSrc = new Array("File menu.png");
var Loading_a_File_ForegroundSrc = new Array("");
var Loading_a_File_ForegroundLeft = new Array("0");
var Loading_a_File_ForegroundTop = new Array("0");
var Loading_a_File_CalloutSrc = new Array("callout_right.gif");
var Loading_a_File_CalloutLeft = new Array("145");
var Loading_a_File_CalloutTop = new Array("24");
var Loading_a_File_CalloutText = new Array("To load a file, you may choose either the New, Open Lesson, or Open Saved Sim option from the File menu.<br />");
var Loading_a_File_TextLeft = new Array("165");
var Loading_a_File_TextTop = new Array("32");
var Loading_a_File_BackLinkLeft = new Array("169");
var Loading_a_File_NextLinkLeft = new Array("279");
var Loading_a_File_LinkTop = new Array("80");

var Printing_FrameCount = 3;
var Printing_BackgroundSrc = new Array("Print View from under File menu.png","City View.png","City View.png");
var Printing_ForegroundSrc = new Array("","Student Name Screen for Printing.png","Credit Report Screen.png");
var Printing_ForegroundLeft = new Array("0","162","100");
var Printing_ForegroundTop = new Array("0","108","3");
var Printing_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_left.gif");
var Printing_CalloutLeft = new Array("118","41","216");
var Printing_CalloutTop = new Array("115","175","372");
var Printing_CalloutText = new Array("To print a view, select Print View from the File menu.<br />","This screen will pop up. Enter your name or initials to help identify your paper and click \"OK\".<br />","You are also able to print most of the reports by clicking on the \"print\" button within each report.<br />");
var Printing_TextLeft = new Array("138","45","220");
var Printing_TextTop = new Array("123","183","380");
var Printing_BackLinkLeft = new Array("142","49","224");
var Printing_NextLinkLeft = new Array("252","159","334");
var Printing_LinkTop = new Array("171","231","428");

var Run_To_FrameCount = 8;
var Run_To_BackgroundSrc = new Array("Run To.png","City View New.png","City View New.png","City View New.png","City View New.png","City View New.png","City View New.png","City View New.png");
var Run_To_ForegroundSrc = new Array("","Run To Screen.png","Run To Screen.png","Run To Screen.png","Run To Screen.png","Run To Screen.png","Run To Screen Select Day Week.png","Run To Screen.png");
var Run_To_ForegroundLeft = new Array("0","167","182","161","175","112","120","144");
var Run_To_ForegroundTop = new Array("0","16","5","7","-14","-11","-15","-34");
var Run_To_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_right.gif","callout_right.gif","callout_left.gif");
var Run_To_CalloutLeft = new Array("296","28","155","160","39","330","426","4");
var Run_To_CalloutTop = new Array("67","6","52","54","149","193","192","220");
var Run_To_CalloutText = new Array("If you would like the simulation to stop on a certain date automatically, click here under the Options menu.<br />","Click here if you'd like to run the sim until a certain date.<br />","This is the date on which you are on currently.<br />","You must then click on the date on which you'd like for the simulation to stop and then click OK.<br />","If you would like to run the simulation for a certain amount of days or weeks, you should click here.<br />","Then you should select the number of days or weeks by clicking here.<br />","Then you need to select whether you are running it for a certain number of days or weeks and then you should click OK.<br />","To go back to running the simulation normally, select this button here and then click OK.<br />");
var Run_To_TextLeft = new Array("316","32","159","164","43","350","446","8");
var Run_To_TextTop = new Array("75","14","60","62","157","201","200","228");
var Run_To_BackLinkLeft = new Array("320","36","163","168","47","354","450","12");
var Run_To_NextLinkLeft = new Array("430","146","273","278","157","464","560","122");
var Run_To_LinkTop = new Array("123","62","108","110","205","249","248","276");

var Sounds_and_Music_FrameCount = 1;
var Sounds_and_Music_BackgroundSrc = new Array("Background Music under Options menu.png");
var Sounds_and_Music_ForegroundSrc = new Array("");
var Sounds_and_Music_ForegroundLeft = new Array("0");
var Sounds_and_Music_ForegroundTop = new Array("0");
var Sounds_and_Music_CalloutSrc = new Array("callout_right.gif");
var Sounds_and_Music_CalloutLeft = new Array("285");
var Sounds_and_Music_CalloutTop = new Array("68");
var Sounds_and_Music_CalloutText = new Array("To turn background music on or off, you must select or deselect this option found under the Options menu.<br />");
var Sounds_and_Music_TextLeft = new Array("305");
var Sounds_and_Music_TextTop = new Array("76");
var Sounds_and_Music_BackLinkLeft = new Array("309");
var Sounds_and_Music_NextLinkLeft = new Array("419");
var Sounds_and_Music_LinkTop = new Array("124");

var Instructors_Area_FrameCount = 1;
var Instructors_Area_BackgroundSrc = new Array("Instructor's Area from under Options menu.png");
var Instructors_Area_ForegroundSrc = new Array("");
var Instructors_Area_ForegroundLeft = new Array("0");
var Instructors_Area_ForegroundTop = new Array("0");
var Instructors_Area_CalloutSrc = new Array("callout_right.gif");
var Instructors_Area_CalloutLeft = new Array("250");
var Instructors_Area_CalloutTop = new Array("131");
var Instructors_Area_CalloutText = new Array("For information about how to use the Instructor's Area found under the Options menu, please refer to the Teacher Guide.<br />");
var Instructors_Area_TextLeft = new Array("270");
var Instructors_Area_TextTop = new Array("139");
var Instructors_Area_BackLinkLeft = new Array("274");
var Instructors_Area_NextLinkLeft = new Array("384");
var Instructors_Area_LinkTop = new Array("187");

var MULTIPLAYER_FrameCount = 1;
var MULTIPLAYER_BackgroundSrc = new Array("City View.png");
var MULTIPLAYER_ForegroundSrc = new Array("");
var MULTIPLAYER_ForegroundLeft = new Array("0");
var MULTIPLAYER_ForegroundTop = new Array("0");
var MULTIPLAYER_CalloutSrc = new Array("callout_center.gif");
var MULTIPLAYER_CalloutLeft = new Array("249");
var MULTIPLAYER_CalloutTop = new Array("100");
var MULTIPLAYER_CalloutText = new Array("The Multiplayer function allows students to compete against one another within the same simulated economy.<br />");
var MULTIPLAYER_TextLeft = new Array("253");
var MULTIPLAYER_TextTop = new Array("108");
var MULTIPLAYER_BackLinkLeft = new Array("257");
var MULTIPLAYER_NextLinkLeft = new Array("367");
var MULTIPLAYER_LinkTop = new Array("156");

var Start_Session_FrameCount = 10;
var Start_Session_BackgroundSrc = new Array("Multiplayer from under File menu.png","Start Session from under File menu.png","City View.png","City View.png","City View.png","City View.png","City View.png","Multiplayer Host Session.png","Save As from under File menu.png","Multiplayer Host Session.png");
var Start_Session_ForegroundSrc = new Array("","","Students in Session Screen.png","Students in Session Screen.png","Students in Session Screen.png","New Multiplayer Session Screen.png","New Multiplayer Session Screen.png","","","");
var Start_Session_ForegroundLeft = new Array("0","0","217","189","178","196","184","0","0","0");
var Start_Session_ForegroundTop = new Array("0","0","154","114","88","63","74","0","0","0");
var Start_Session_CalloutSrc = new Array("callout_right.gif","callout_right.gif","callout_left.gif","callout_right.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_center.gif","callout_right.gif","callout_right.gif");
var Start_Session_CalloutLeft = new Array("123","213","78","351","96","97","58","249","126","65");
var Start_Session_CalloutTop = new Array("74","98","94","156","171","120","230","100","61","-2");
var Start_Session_CalloutText = new Array("Access Multiplayer from the File menu when you are already in the program.<br />","To start a new multiplayer session, select this option found under Multiplayer from the File menu.","You will then be prompted with this screen asking you how many students you'd lik to have in the session.","You may type in the amount here or you may make your selection with the arrow buttons.","When you are done with your selection, you may click here.","After you make the students in the session decision, you will be asked to enter a session name of your choice here. <br />","Click here when you are done.","A new simulation is created. You can see your role as the \"host\" in the title bar along with the session name.<br />","During a multiplayer session, the host session is the only one that has the capability to save the session.","During a multiplayer session, the host controls stopping and starting the session as well as the speed of the session.");
var Start_Session_TextLeft = new Array("143","233","82","371","100","101","62","253","146","85");
var Start_Session_TextTop = new Array("82","106","102","164","179","128","238","108","69","6");
var Start_Session_BackLinkLeft = new Array("147","237","86","375","104","105","66","257","150","89");
var Start_Session_NextLinkLeft = new Array("257","347","196","485","214","215","176","367","260","199");
var Start_Session_LinkTop = new Array("130","154","150","212","227","176","286","156","117","54");

var Join_Session_FrameCount = 8;
var Join_Session_BackgroundSrc = new Array("Join Session from under File menu.png","City View.png","City View.png","City View.png","City View.png","City View.png","Multiplayer Client Session.png","Multiplayer Client Session with everything enabled.png");
var Join_Session_ForegroundSrc = new Array("","Join Multiplayer Session Screen.png","Join Multiplayer Session Screen.png","Join Multiplayer Session Screen.png","Join Multiplayer Session Screen.png","Join Multiplayer Session Screen Filled In.png","","");
var Join_Session_ForegroundLeft = new Array("0","231","192","207","170","174","0","0");
var Join_Session_ForegroundTop = new Array("0","78","94","46","39","34","0","0");
var Join_Session_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif","callout_center.gif","callout_left.gif");
var Join_Session_CalloutLeft = new Array("227","124","96","93","78","68","249","351");
var Join_Session_CalloutTop = new Array("87","86","103","107","148","231","100","216");
var Join_Session_CalloutText = new Array("To join a multiplayer session, choose this option under Multiplayer from the File menu.","Enter the computer name (the name of the computer that started the session) here.","The Host name should have been provided to your instructor after the installation process was completed.<br />","Enter the Session Name which is the name typed in by the instructor when the multiplayer session was started.<br />","Enter the Team Name here which is chosen by you, but must be different from other teams in the session.<br />","After you fill this information in, click \"OK\". You will then be brought to the City view of the session you joined.<br />","The title bar of your main window should show your role as a host or client and the session name.<br />","Once you rent your apartment, all of the actions and reports will be enabled for you.");
var Join_Session_TextLeft = new Array("247","128","100","97","82","72","253","355");
var Join_Session_TextTop = new Array("95","94","111","115","156","239","108","224");
var Join_Session_BackLinkLeft = new Array("251","132","104","101","86","76","257","359");
var Join_Session_NextLinkLeft = new Array("361","242","214","211","196","186","367","469");
var Join_Session_LinkTop = new Array("143","142","159","163","204","287","156","272");

var Scoreboard_FrameCount = 4;
var Scoreboard_BackgroundSrc = new Array("Multiplayer Host Session.png","Multiplayer Host Session.png","Multiplayer Host Session.png","Multiplayer Host Session.png");
var Scoreboard_ForegroundSrc = new Array("","Scoreboard Screen.png","Scoreboard Screen.png","Scoreboard Screen.png");
var Scoreboard_ForegroundLeft = new Array("0","194","174","163");
var Scoreboard_ForegroundTop = new Array("0","49","16","20");
var Scoreboard_CalloutSrc = new Array("callout_left.gif","callout_left.gif","callout_left.gif","callout_left.gif");
var Scoreboard_CalloutLeft = new Array("310","24","83","20");
var Scoreboard_CalloutTop = new Array("6","11","204","208");
var Scoreboard_CalloutText = new Array("A new button called the Scoreboard appears on the main toolbar during a multiplayer session.<br />","The scoreboard displays a bar graph indicating each player's net worth.<br />","At the end of a session you can click the \"Replay\" button to see how a player's profits changed and grew over time.<br />","If you would like to print this information, click here.");
var Scoreboard_TextLeft = new Array("314","28","87","24");
var Scoreboard_TextTop = new Array("14","19","212","216");
var Scoreboard_BackLinkLeft = new Array("318","32","91","28");
var Scoreboard_NextLinkLeft = new Array("428","142","201","138");
var Scoreboard_LinkTop = new Array("62","67","260","264");

var Team_List_FrameCount = 4;
var Team_List_BackgroundSrc = new Array("Team List under file menu.png","Multiplayer Host Session.png","Multiplayer Host Session.png","City View.png");
var Team_List_ForegroundSrc = new Array("","Team List Filled In.png","Team List Filled In.png","");
var Team_List_ForegroundLeft = new Array("0","182","165","0");
var Team_List_ForegroundTop = new Array("0","153","87","0");
var Team_List_CalloutSrc = new Array("callout_right.gif","callout_left.gif","callout_left.gif","callout_center.gif");
var Team_List_CalloutLeft = new Array("330","39","33","249");
var Team_List_CalloutTop = new Array("177","124","43","100");
var Team_List_CalloutText = new Array("Once a new session is created, the host session will show this Team List option found under Multiplayer from the File menu.","This screen lists all of the players that have joined a particular session. It includes players that have been eliminated. <br />","This list is only accessible from the host session.","Congratulations! You have finished the Virtual Business - Personal Finance tutorial. Good luck!<br />");
var Team_List_TextLeft = new Array("350","43","37","253");
var Team_List_TextTop = new Array("185","132","51","108");
var Team_List_BackLinkLeft = new Array("354","47","41","257");
var Team_List_NextLinkLeft = new Array("464","157","151","367");
var Team_List_LinkTop = new Array("233","180","99","156");

var BASICS_PreviousTopic = "%BeginHelpTopics%";
var BASICS_NextTopic = "Overview";
var Overview_PreviousTopic = "BASICS";
var Overview_NextTopic = "Assignments";
var Assignments_PreviousTopic = "Overview";
var Assignments_NextTopic = "Getting_Around";
var Getting_Around_PreviousTopic = "Assignments";
var Getting_Around_NextTopic = "Message_Center";
var Message_Center_PreviousTopic = "Getting_Around";
var Message_Center_NextTopic = "City_View";
var City_View_PreviousTopic = "Message_Center";
var City_View_NextTopic = "Legend";
var Legend_PreviousTopic = "City_View";
var Legend_NextTopic = "Apartment_or_Condo_View";
var Apartment_or_Condo_View_PreviousTopic = "Legend";
var Apartment_or_Condo_View_NextTopic = "School_View";
var School_View_PreviousTopic = "Apartment_or_Condo_View";
var School_View_NextTopic = "REPORTS";
var REPORTS_PreviousTopic = "School_View";
var REPORTS_NextTopic = "Snapshot";
var Snapshot_PreviousTopic = "REPORTS";
var Snapshot_NextTopic = "Wealth";
var Wealth_PreviousTopic = "Snapshot";
var Wealth_NextTopic = "Health";
var Health_PreviousTopic = "Wealth";
var Health_NextTopic = "Resume";
var Resume_PreviousTopic = "Health";
var Resume_NextTopic = "Credit_Score";
var Credit_Score_PreviousTopic = "Resume";
var Credit_Score_NextTopic = "Credit_Report";
var Credit_Report_PreviousTopic = "Credit_Score";
var Credit_Report_NextTopic = "Bank_Statements";
var Bank_Statements_PreviousTopic = "Credit_Report";
var Bank_Statements_NextTopic = "Credit_Card_Statements";
var Credit_Card_Statements_PreviousTopic = "Bank_Statements";
var Credit_Card_Statements_NextTopic = "Loan_Statements";
var Loan_Statements_PreviousTopic = "Credit_Card_Statements";
var Loan_Statements_NextTopic = "Investment_Statements";
var Investment_Statements_PreviousTopic = "Loan_Statements";
var Investment_Statements_NextTopic = "Retirement_Statements";
var Retirement_Statements_PreviousTopic = "Investment_Statements";
var Retirement_Statements_NextTopic = "Check_Register";
var Check_Register_PreviousTopic = "Retirement_Statements";
var Check_Register_NextTopic = "Pay__Tax_Records";
var Pay__Tax_Records_PreviousTopic = "Check_Register";
var Pay__Tax_Records_NextTopic = "Past_Tax_Returns";
var Past_Tax_Returns_PreviousTopic = "Pay__Tax_Records";
var Past_Tax_Returns_NextTopic = "Actions_Journal";
var Actions_Journal_PreviousTopic = "Past_Tax_Returns";
var Actions_Journal_NextTopic = "ACTIONS";
var ACTIONS_PreviousTopic = "Actions_Journal";
var ACTIONS_NextTopic = "Apartments_for_Rent";
var Apartments_for_Rent_PreviousTopic = "ACTIONS";
var Apartments_for_Rent_NextTopic = "Transportation";
var Transportation_PreviousTopic = "Apartments_for_Rent";
var Transportation_NextTopic = "Schedule";
var Schedule_PreviousTopic = "Transportation";
var Schedule_NextTopic = "Socializing";
var Socializing_PreviousTopic = "Schedule";
var Socializing_NextTopic = "Condos_For_Sale";
var Condos_For_Sale_PreviousTopic = "Socializing";
var Condos_For_Sale_NextTopic = "Work";
var Work_PreviousTopic = "Condos_For_Sale";
var Work_NextTopic = "Applying_For_A_Job";
var Applying_For_A_Job_PreviousTopic = "Work";
var Applying_For_A_Job_NextTopic = "Getting_Paid";
var Getting_Paid_PreviousTopic = "Applying_For_A_Job";
var Getting_Paid_NextTopic = "Education";
var Education_PreviousTopic = "Getting_Paid";
var Education_NextTopic = "Student_Loans";
var Student_Loans_PreviousTopic = "Education";
var Student_Loans_NextTopic = "Taxes";
var Taxes_PreviousTopic = "Student_Loans";
var Taxes_NextTopic = "Change_Witholding";
var Change_Witholding_PreviousTopic = "Taxes";
var Change_Witholding_NextTopic = "Change_Method_of_Payment";
var Change_Method_of_Payment_PreviousTopic = "Change_Witholding";
var Change_Method_of_Payment_NextTopic = "Change_Retirement_Contribution";
var Change_Retirement_Contribution_PreviousTopic = "Change_Method_of_Payment";
var Change_Retirement_Contribution_NextTopic = "Pay_Bills";
var Pay_Bills_PreviousTopic = "Change_Retirement_Contribution";
var Pay_Bills_NextTopic = "Banking";
var Banking_PreviousTopic = "Pay_Bills";
var Banking_NextTopic = "Open_Checking_Account";
var Open_Checking_Account_PreviousTopic = "Banking";
var Open_Checking_Account_NextTopic = "Open_Savings_Account";
var Open_Savings_Account_PreviousTopic = "Open_Checking_Account";
var Open_Savings_Account_NextTopic = "Deposit_Funds";
var Deposit_Funds_PreviousTopic = "Open_Savings_Account";
var Deposit_Funds_NextTopic = "Withdraw_Cash";
var Withdraw_Cash_PreviousTopic = "Deposit_Funds";
var Withdraw_Cash_NextTopic = "Transfer_Funds";
var Transfer_Funds_PreviousTopic = "Withdraw_Cash";
var Transfer_Funds_NextTopic = "Close_Account";
var Close_Account_PreviousTopic = "Transfer_Funds";
var Close_Account_NextTopic = "Online_Banking";
var Online_Banking_PreviousTopic = "Close_Account";
var Online_Banking_NextTopic = "Credit_Cards";
var Credit_Cards_PreviousTopic = "Online_Banking";
var Credit_Cards_NextTopic = "Shop_For_Food";
var Shop_For_Food_PreviousTopic = "Credit_Cards";
var Shop_For_Food_NextTopic = "Shop_For_Goods";
var Shop_For_Goods_PreviousTopic = "Shop_For_Food";
var Shop_For_Goods_NextTopic = "Shop_For_Car";
var Shop_For_Car_PreviousTopic = "Shop_For_Goods";
var Shop_For_Car_NextTopic = "Sell_Car";
var Sell_Car_PreviousTopic = "Shop_For_Car";
var Sell_Car_NextTopic = "Shop_For_Gas__Repairs";
var Shop_For_Gas__Repairs_PreviousTopic = "Sell_Car";
var Shop_For_Gas__Repairs_NextTopic = "Buy_Bus_Tokens";
var Buy_Bus_Tokens_PreviousTopic = "Shop_For_Gas__Repairs";
var Buy_Bus_Tokens_NextTopic = "Internet_Access";
var Internet_Access_PreviousTopic = "Buy_Bus_Tokens";
var Internet_Access_NextTopic = "Health_Insurance";
var Health_Insurance_PreviousTopic = "Internet_Access";
var Health_Insurance_NextTopic = "Renters_Insurance";
var Renters_Insurance_PreviousTopic = "Health_Insurance";
var Renters_Insurance_NextTopic = "Homeowners_Insurance";
var Homeowners_Insurance_PreviousTopic = "Renters_Insurance";
var Homeowners_Insurance_NextTopic = "Auto_Insurance";
var Auto_Insurance_PreviousTopic = "Homeowners_Insurance";
var Auto_Insurance_NextTopic = "Research_Funds";
var Research_Funds_PreviousTopic = "Auto_Insurance";
var Research_Funds_NextTopic = "Buy_Shares";
var Buy_Shares_PreviousTopic = "Research_Funds";
var Buy_Shares_NextTopic = "View_Portfolio";
var View_Portfolio_PreviousTopic = "Buy_Shares";
var View_Portfolio_NextTopic = "Sell_Shares";
var Sell_Shares_PreviousTopic = "View_Portfolio";
var Sell_Shares_NextTopic = "View_Retirement_Portfolio";
var View_Retirement_Portfolio_PreviousTopic = "Sell_Shares";
var View_Retirement_Portfolio_NextTopic = "USEFUL_TOOLS";
var USEFUL_TOOLS_PreviousTopic = "View_Retirement_Portfolio";
var USEFUL_TOOLS_NextTopic = "Saving";
var Saving_PreviousTopic = "USEFUL_TOOLS";
var Saving_NextTopic = "Loading_a_File";
var Loading_a_File_PreviousTopic = "Saving";
var Loading_a_File_NextTopic = "Printing";
var Printing_PreviousTopic = "Loading_a_File";
var Printing_NextTopic = "Run_To";
var Run_To_PreviousTopic = "Printing";
var Run_To_NextTopic = "Sounds_and_Music";
var Sounds_and_Music_PreviousTopic = "Run_To";
var Sounds_and_Music_NextTopic = "Instructors_Area";
var Instructors_Area_PreviousTopic = "Sounds_and_Music";
var Instructors_Area_NextTopic = "MULTIPLAYER";
var MULTIPLAYER_PreviousTopic = "Instructors_Area";
var MULTIPLAYER_NextTopic = "Start_Session";
var Start_Session_PreviousTopic = "MULTIPLAYER";
var Start_Session_NextTopic = "Join_Session";
var Join_Session_PreviousTopic = "Start_Session";
var Join_Session_NextTopic = "Scoreboard";
var Scoreboard_PreviousTopic = "Join_Session";
var Scoreboard_NextTopic = "Team_List";
var Team_List_PreviousTopic = "Scoreboard";
var Team_List_NextTopic = "%EndHelpTopics%";

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

//updates all elements of the page to reflect their desired appearance
function update(index)
{
    try
    {
        if( eval(topic + "_BackgroundSrc[index]") != "" )
        {
            document.images["backgroundImage"].src = "images/" + eval(topic + "_BackgroundSrc[index]");
        }
        else
        {
		    document.images["backgroundImage"].src = "common_images/empty.gif";
        }
        if( eval(topic + "_ForegroundSrc[index]") != "" )
        {
            document.images["foregroundImage"].src = "images/" + eval(topic + "_ForegroundSrc[index]");
        }
        else
        {
            document.images["foregroundImage"].src = "common_images/empty.gif";
        }
        
        document.getElementById("foreground").style.left = eval(topic + "_ForegroundLeft[index]") + "px";
        document.getElementById("foreground").style.top = eval(topic + "_ForegroundTop[index]") + "px";
        document.images["calloutImage"].src = "common_images/" + eval(topic + "_CalloutSrc[index]");
        document.getElementById("callout").style.left = eval(topic + "_CalloutLeft[index]") + "px";
        document.getElementById("callout").style.top = eval(topic + "_CalloutTop[index]") + "px";          
        document.getElementById("calloutText").innerHTML = "<p>" + eval(topic + "_CalloutText[index]") + "</p>";
        document.getElementById("calloutText").style.left = eval(topic + "_TextLeft[index]") + "px";
        document.getElementById("calloutText").style.top = eval(topic + "_TextTop[index]") + "px";
        document.getElementById("backLink").style.left = eval(topic + "_BackLinkLeft[index]") + "px";
        document.getElementById("backLink").style.top = eval(topic + "_LinkTop[index]") + "px";
        document.getElementById("nextLink").style.left = eval(topic + "_NextLinkLeft[index]") + "px";
        document.getElementById("nextLink").style.top = eval(topic + "_LinkTop[index]") + "px";

        if(index == count - 1 && nextTopic == "%EndHelpTopics%")
        {
            document.getElementById("nextLink").style.visibility = "hidden";
        }
        else
        {
            document.getElementById("nextLink").style.visibility = "visible";
        }
        if(index == 0 && previousTopic == "%BeginHelpTopics%")
        {
            document.getElementById("backLink").style.visibility = "hidden";
        }
        else
        {
            document.getElementById("backLink").style.visibility = "visible";
        }
    }
    catch(error)
    {
        alert("An error occurred; Redirecting to the beginning of Help.");
        window.parent.location.replace("index.htm?lastSearchResult=" + lastSearchResult);
    }
}

//moves to next item in help
function next()
{
    if(index == count - 1)
    {
        window.parent.location.replace("index.htm?topic=" + nextTopic + "&index=0&lastSearchResult=" + lastSearchResult);
    }
    else
    {  
        index++;
        window.parent.location.replace("index.htm?topic=" + topic + "&index=" + index + "&lastSearchResult=" + lastSearchResult);
    }
}

//moves to previous item in help
function previous()
{
    if(index == 0)
    {
        window.parent.location.replace("index.htm?topic=" + previousTopic + "&index=" + (eval(previousTopic + "_FrameCount") - 1) + "&lastSearchResult=" + lastSearchResult);
    }
    else
    {
        index--;
        window.parent.location.replace("index.htm?topic=" + topic + "&index=" + index + "&lastSearchResult=" + lastSearchResult);
    }
}

//called when the help_item.htm page is loaded
function pageLoad()
{
    //check to see if this page was loaded directly
    //if so, redirect to the frameset.
    if(window.parent == window)
    {
        window.location.replace("index.htm?lastSearchResult=" + lastSearchResult);
        return;
    }
    
    lastSearchResult = getQueryVariable("lastSearchResult");

    topic = getQueryVariable("topic");
    index = getQueryVariable("index");
    //check to see if we can obtain a valid value for count, previousTopic and nextTopic
    try
    {
        count = eval(topic + "_FrameCount");
        previousTopic = eval(topic + "_PreviousTopic");
        nextTopic = eval(topic + "_NextTopic");
    }
    catch(error)
    {
        alert("Could not find the topic \"" + topic + "\".  Redirecting to the beginning of Help.");
        window.parent.location.replace("index.htm?lastSearchResult=" + lastSearchResult);
        return;
    }
    //check to see if the index is out of bounds, or not a number
    //if so, load the desired topic at index 0
    if(index > count || index < 0 || isNaN(index))
    {
        alert("The help index specified was not valid.");
        window.parent.location.replace("index.htm?topic=" + topic + "&index=0&lastSearchResult=" + lastSearchResult);
    }
    //everything is good to go, so update the display of help_item.htm on the current index
    update(index);
}
