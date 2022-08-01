//Global XMLHTTP Request object
var XmlHttp;

//Global variable for keeping the image name
var	ImageName;

//Global variable for keeping the page number of the document
var PageNumber;

//Creating and setting the instance of appropriate XMLHTTP Request object to a “XmlHttp?variable  
function CreateXmlHttp()
{
	//Creating object of XMLHTTP in IE
	try
	{
		XmlHttp = new ActiveXObject("Msxml2.XMLHTTP");
	}
	catch(e)
	{
		try
		{
			XmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
		} 
		catch(oc)
		{
			XmlHttp = null;
		}
	}
	//Creating object of XMLHTTP in Mozilla and Safari 
	if(!XmlHttp && typeof XMLHttpRequest != "undefined") 
	{
		XmlHttp = new XMLHttpRequest();
	}
}

//Gets called when country combo box selection changes
function CategoryListOnChange() 
{
	var ddCat = document.getElementById("_ctl0_ddCat");

	//Getting the selected country from country combo box.
	var selectedCat = ddCat.options[ddCat.selectedIndex].value;
	
	
	// URL to get states for a given country
	var requestUrl = AjaxServerPageName + "?Action=ReloadDropDown&SelectedCat=" + encodeURIComponent(selectedCat)+"&SSN=0";
	CreateXmlHttp();
	
	// If browser supports XMLHTTPRequest object
	if(XmlHttp)
	{
		//Setting the event handler for the response
		XmlHttp.onreadystatechange = GetDocumentType;
		
		//Initializes the request object with GET (METHOD of posting), 
		//Request URL and sets the request as asynchronous.
		XmlHttp.open("GET", requestUrl,  true);
		
		//Sends the request to server
		XmlHttp.send(null);		
	}
}
function ClientListOnclick() 
{
	var txtSSN = document.getElementById("_ctl0:txtSSN");

	//Getting the selected country from country combo box.
	var ssn = txtSSN.value;
	
	// URL to get states for a given country
	var requestUrl =AjaxServerPageName  + "?Action=FindClient&SSN=" + encodeURIComponent(ssn);
	CreateXmlHttp();
	
	// If browser supports XMLHTTPRequest object
	if(XmlHttp)
	{
		//Setting the event handler for the response
		XmlHttp.onreadystatechange = GetClientData;
		
		//Initializes the request object with GET (METHOD of posting), 
		//Request URL and sets the request as asynchronous.
		XmlHttp.open("GET", requestUrl,  true);
		
		//Sends the request to server
		XmlHttp.send(null);		
	}
}

//Called when response comes back from server
function GetDocumentType()
{
	// To make sure receiving response data from server is completed
	if(XmlHttp.readyState == 4)
	{
		// To make sure valid response is received from the server, 200 means response received is OK
		if(XmlHttp.status == 200)
		{			
			ClearAndSetTypeListItems(XmlHttp.responseXML.documentElement);
		}
		else
		{
			alert("There was a problem retrieving data from the server." );
		}
		document.getElementById("_ctl0_lblDropDownStatus").innerHTML="";
	}
	else
		document.getElementById("_ctl0_lblDropDownStatus").innerHTML="<img src='../Images/AjaxRed.gif'> loading...";
}
function GetClientData()
{
	// To make sure receiving response data from server is completed
	
	if(XmlHttp.readyState == 4)
	{
		// To make sure valid response is received from the server, 200 means response received is OK
		if(XmlHttp.status == 200)
		{			
			SetClientInfo(XmlHttp.responseXML.documentElement);
			
		}
		else
		{
			alert("There was a problem retrieving data from the server." );
		}
		document.getElementById("_ctl0:btnLookUp").disabled=false;
		document.getElementById("_ctl0_lblClientLookUpStatus").innerHTML="";
	}
	else
	{
		document.getElementById("_ctl0:btnLookUp").disabled=true;
		document.getElementById("_ctl0_lblClientLookUpStatus").innerHTML="<img src='../Images/AjaxRed.gif'> loading...";
	}
}

//Clears the contents of state combo box and adds the states of currently selected country
function ClearAndSetTypeListItems(CatNode)
{
    var dlType = document.getElementById("_ctl0:ddType");
	//Clears the state combo box contents.
	for (var count = dlType.options.length-1; count >-1; count--)
	{
		dlType.options[count]=null;
	}
	if(CatNode!=null)
	{ 
		var DescriptionNodes = CatNode.getElementsByTagName('Description');
		var TypeIdNodes = CatNode.getElementsByTagName('TypeID');
		var optionText; 
		var optionValue;
		var optionItem;
		//Add new states list to the state combo box.
		optionItem = new Option( "[Select a type from drop down]", "0",  false, false);
		dlType.options[dlType.length] = optionItem;
		for (var count = 0; count < TypeIdNodes.length; count++)
		{
   			optionText = GetInnerText(DescriptionNodes[count]);
   			optionValue = GetInnerText(TypeIdNodes[count]);
			optionItem = new Option( optionText, optionValue,  false, false);
			dlType.options[dlType.length] = optionItem;
		}
	}
	
}

function SetClientInfo(ClientNode)
{
	var lblSSN = document.getElementById("_ctl0_lblSSN");
    var lblFirstName = document.getElementById("_ctl0_lblFirstName");
    var lblLastName = document.getElementById("_ctl0_lblLastName");
    var lblCaseNumber = document.getElementById("_ctl0_lblCaseNumber");
    var lblSiteId = document.getElementById("_ctl0_lblSiteId");
    var lblSuffix = document.getElementById("_ctl0_lblSuffix");
    var lblDOB = document.getElementById("_ctl0_lblDOB");
    var lblClientID = document.getElementById("_ctl0_lblClientID");
    var lblMsg= document.getElementById("_ctl0_lblMsg");
	
	//Clears the state combo box contents.
	lblMsg.innerHTML="";
	lblSSN.innerHTML="";
	lblFirstName.innerHTML="";
	lblLastName.innerHTML="";
	lblCaseNumber.innerHTML="";
	lblSiteId.innerHTML="";
	lblSuffix.innerHTML="";
	lblDOB.innerHTML="";
	lblClientID.innerHTML="";
	
			
	if(ClientNode!=null)
	{ 
		var SSN = ClientNode.getElementsByTagName('SSN');
		var FirstName = ClientNode.getElementsByTagName('FirstName');
		var LastName = ClientNode.getElementsByTagName('LastName');
		var CaseNumber= ClientNode.getElementsByTagName('CaseNumber');
		var SiteID= ClientNode.getElementsByTagName('SiteID');
		var Suffix= ClientNode.getElementsByTagName('Suffix');
		var DOB= ClientNode.getElementsByTagName('DOB');
		var ClientID= ClientNode.getElementsByTagName('ClientID');
		
		//Sets the values in the respective labels
		lblSSN.innerHTML=GetInnerText(SSN[0]);
		lblFirstName.innerHTML=GetInnerText(FirstName[0]);
		lblLastName.innerHTML=GetInnerText(LastName[0]);;
		lblCaseNumber.innerHTML=GetInnerText(CaseNumber[0]);;
		lblSiteId.innerHTML=GetInnerText(SiteID[0]);;
		lblSuffix.innerHTML=GetInnerText(Suffix[0]);;
		lblDOB.innerHTML=GetInnerText(DOB[0]);;
		lblClientID.innerHTML=GetInnerText(ClientID[0]);;
		
		
	}
	else{
	
			lblSSN.innerHTML="";
	        lblFirstName.innerHTML="";
			lblLastName.innerHTML="";
			lblCaseNumber.innerHTML="";
			lblSiteId.innerHTML="";
			lblSuffix.innerHTML="";
			lblDOB.innerHTML="";
			lblClientID.innerHTML="";
			lblMsg.innerHTML="<font color=red>The client Does Not Exist</font>";
	}
	
}
//Returns the node text value 
function IndexButtonOnclick()
{
	if(ReadyForIndexing())
	{
		//Getting the selected type and category from combo boxes.
		var lblMsg= document.getElementById("_ctl0_lblMsg");
		var docTypeIndex = document.getElementById("_ctl0_tabContainer_tabPanelDDList_ddType").selectedIndex;
		var typeID = document.getElementById("_ctl0_tabContainer_tabPanelDDList_ddType").options[docTypeIndex].value;
		var docCatIndex = document.getElementById("_ctl0_tabContainer_tabPanelDDList_ddCat").selectedIndex;
		//var catID = document.getElementById("_ctl0:ddCat").options[docCatIndex].value;
		
		//for server control label, tis innerHTML is actually the content of the control
		var clientID = document.getElementById("_ctl0_lblClientID").innerHTML;
		
		getSort();
		var orderInfo = document.getElementById("order").value;
		
		// URL to index document
		//var requestUrl =AjaxServerPageName  + "?Action=Index&catId=0&SSN=0&type=" +typeID+ "&cat="+catID+"&pageOrder="+orderInfo+"&clientID="+clientID;
        var requestUrl =AjaxServerPageName  + "?Action=Index&catId=0&SSN=0&type=" +typeID+ "&pageOrder="+orderInfo+"&clientID="+clientID;

		CreateXmlHttp();
	
		// If browser supports XMLHTTPRequest object
		if(XmlHttp)
		{
			//Setting the event handler for the response
			XmlHttp.onreadystatechange = IndexDocument;
			
			//Initializes the request object with GET (METHOD of posting), 
			//Request URL and sets the request as asynchronous.
			XmlHttp.open("GET", requestUrl,  true);
			
			//Sends the request to server
			XmlHttp.send(null);	
		}
	}
}
function ReadyForIndexing()
{
	var lblMsg= document.getElementById("_ctl0_lblMsg");
	var docCat = document.getElementById("_ctl0_tabContainer_tabPanelDDList_ddCat").selectedIndex;
	var docType = document.getElementById("_ctl0_tabContainer_tabPanelDDList_ddType").selectedIndex;
	var clientID = document.getElementById("_ctl0_lblClientID");
	var SSN = document.getElementById("_ctl0_lblSSN");
	var SSNBox = document.getElementById("_ctl0:txtSSN").value;
	
	if(docCat==0 && docType==0)
	{
		lblMsg.innerHTML="<font color=red>You must select a document category</font>";
		return false;
	}
	
	if(docType==0)
	{
		lblMsg.innerHTML="<font color=red>You must select a document type</font>";
		return false;
	}
	if(SSNBox=="")
	{
		lblMsg.innerHTML="<font color=red>client ssn cannot be blank</font>";
		return false;
	}
	if(SSN.innerHTML=="")
	{
		lblMsg.innerHTML="<font color=red>client ssn cannot be blank</font>";
		return false;
	}

	if(clientID.innerHTML=="")
	{
		lblMsg.innerHTML="<font color=red>client ID cannot be blank</font>";
		return false;
	}
	
	return true;
}

function GetInnerText (node)
{
	 return (node.textContent || node.innerText || node.text) ;
}


function GetLabelValue(label)
{
	return document.getElementById(label).innerHTML;
}

//-----------Ming's function starts here------------------------
function ClearIndexArea(column4, column5)
{
	//document.getElementById("lblFindEmployeeStatus").innerHTML="";
	document.getElementById(column4).innerHTML="";
	document.getElementById(column5).innerHTML="";
	
}
 
function ReindexButtonOnClick()
{
	if(ReadyForReindexing())
	{
		//Getting the selected type and category from combo boxes.
		var lblMsg= document.getElementById("_ctl0_lblMsg");
		
		//HTMLSelectElement in DOM
		var docTypeIndex = document.getElementById("_ctl0_tabContainer_tabPanelDDList_ddType").selectedIndex;
		var typeID = document.getElementById("_ctl0_tabContainer_tabPanelDDList_ddType").options[docTypeIndex].value;
		//var docCatIndex = document.getElementById("_ctl0:ddCat").selectedIndex;
		//var catID = document.getElementById("_ctl0:ddCat").options[docCatIndex].value;
		//var docID = GetLabelValue("_ctl0_lblDocID");
		
		//because it is a asp:lable control, and it convert to <span> tag
		//so we should use .innerHTML
		//var docID = document.getElementById("_ctl0_lblDocID").innerHTML;
		var docID = document.getElementById("_ctl0_docID").value;

		
		// URL to index document
		var requestUrl =AjaxServerPageName  + "?Action=Reindex&typeID="+typeID+"&docID="+docID;
		CreateXmlHttp();
	
		// If browser supports XMLHTTPRequest object
		if(XmlHttp)
		{
			//Setting the event handler for the response
			XmlHttp.onreadystatechange = ReindexDocument;
			
			//Initializes the request object with GET (METHOD of posting), 
			//Request URL and sets the request as asynchronous.
			XmlHttp.open("GET", requestUrl,  true);
			
			//Sends the request to server
			XmlHttp.send(null);	
		}
	
	}
}

function ReadyForReindexing()
{
	//need to access it for displaying warning message
	var lblMsg= document.getElementById("_ctl0_lblMsg");
	
	var docCat = document.getElementById("_ctl0_tabContainer_tabPanelDDList_ddCat").selectedIndex;
	var docType = document.getElementById("_ctl0_tabContainer_tabPanelDDList_ddType").selectedIndex;
	
	if(docCat==0 && docType==0)
	{
		lblMsg.innerHTML="<font color=red>You must select a document category</font>";
		return false;
	}
	
	if(docType==0)
	{
		lblMsg.innerHTML="<font color=red>You must select a document type</font>";
		return false;
	}
	
	return true;
}

function ReindexDocument()
{
	// To make sure receiving response data from server is completed	
	if(XmlHttp.readyState == 4)
	{
		// To make sure valid response is received from the server, 200 means response received is OK
		if(XmlHttp.status == 200)
		{			
			document.getElementById("_ctl0_lblMsg").innerHTML = "<font color=green>Document has been reindexed successfully</font>"
		}
		else
		{
			alert("There was a problem retrieving data from the server." );
		}
	}
}




function DeleteImageOnClick()
{		
	var requestUrl =AjaxServerPageName  + "?Action=DeleteImage&imgName="+ImageName;
	CreateXmlHttp();

	// If browser supports XMLHTTPRequest object
	if(XmlHttp)
	{
		//do NOT set any event handler for the reponse,
		//we just want to access server in JavaScript only
		//XmlHttp.onreadystatechange = DisplayImage;
		
		//Initializes the request object with GET (METHOD of posting), 
		//Request URL and sets the request as asynchronous.
		XmlHttp.open("GET", requestUrl,  true);
		
		//Sends the request to server
		XmlHttp.send(null);	
	}
}

function DeleteDocumentOnClick(path, docID, fileName)
{
	if(window.confirm("Do you want to delete this document?"))
	{
		var requestUrl =AjaxServerPageName  + "?Action=DeleteDocument&Path="+path+"&DocID="+docID+"&FileName="+fileName;
		CreateXmlHttp();

		// If browser supports XMLHTTPRequest object
		if(XmlHttp)
		{
			//do NOT set any event handler for the reponse,
			//we just want to access server in JavaScript only
			XmlHttp.onreadystatechange = GoBackPreviousPage;
			
			//Initializes the request object with GET (METHOD of posting), 
			//Request URL and sets the request as asynchronous.
			XmlHttp.open("GET", requestUrl,  true);
			
			//Sends the request to server
			XmlHttp.send(null);	
		}
	}
}

function GoBackPreviousPage()
{	
	// To make sure receiving response data from server is completed
	
	if(XmlHttp.readyState == 4)
	{
		// To make sure valid response is received from the server, 200 means response received is OK
		if(XmlHttp.status == 200)
		{			
			//IndexStatus(XmlHttp.responseXML.documentElement);
			//ClearIndexArea();
			
			window.location = "../MyZone.aspx?Control=IndexDocuments";
			
		}
	}	
}

function IndexButtonOnclickAutoComp(labelKeyFieldValue, textDocType, labelMsg, labelDocID, column4, column5)
{
	if(ReadyForIndexingAutoComp(labelKeyFieldValue, textDocType, labelMsg, labelDocID, column4, column5))
	{
		var lblMsg= document.getElementById(labelMsg);
        var txtType=document.getElementById(textDocType).value;
        var startIndex = txtType.lastIndexOf("[");
        var endIndex = txtType.lastIndexOf("]");
        var typeID = txtType.substring(startIndex + 1, endIndex);
        var docID = document.getElementById(labelDocID).value
        
		//for server control label, tis innerHTML is actually the content of the control
		var keyFieldValue = document.getElementById(labelKeyFieldValue).innerHTML;
		
		getSort();
		var orderInfo = document.getElementById("order").value;
		
		// URL to index document
		//var requestUrl =AjaxServerPageName  + "?Action=Index&catId=0&SSN=0&type=" +typeID+ "&cat="+catID+"&pageOrder="+orderInfo+"&clientID="+clientID;
        var requestUrl =AjaxServerPageName  + "?Action=Index&DocID="+docID+"&DocType=" +typeID+ "&pageOrder="+orderInfo+"&FHNumber="+keyFieldValue;

		CreateXmlHttp();
	
		// If browser supports XMLHTTPRequest object
		if(XmlHttp)
		{
			//Setting the event handler for the response
			//Passing variable to a function
			XmlHttp.onreadystatechange = function () { IndexDocument(labelMsg, column4, column5); };

			//Initializes the request object with GET (METHOD of posting), 
			//Request URL and sets the request as asynchronous.
			XmlHttp.open("GET", requestUrl,  true);
			
			//Sends the request to server
			XmlHttp.send(null);	
		}
	}
}

function IndexDocument(labelMsg, column4, column5)
{

	// To make sure receiving response data from server is completed	
	if(XmlHttp.readyState == 4)
	{
	    
	    //alert(XmlHttp.status);
	    
		// To make sure valid response is received from the server, 200 means response received is OK
		if(XmlHttp.status == 200)
		{			
			IndexStatus(XmlHttp.responseXML.documentElement, labelMsg, column4, column5);
			//ClearIndexArea();
			
		}
		else
		{
			alert("There was a problem retrieving data from the server." );
		}
		document.getElementById("btnCommitAutoComp").disabled=false;
		//document.getElementById("_ctl0_lblCommittingStatus").innerHTML="";
		//this is to making the page reloading again
		//history.go(0);
	}
	else
	{
		document.getElementById("btnCommitAutoComp").disabled=true;
	//	document.getElementById("_ctl0_lblCommittingStatus").innerHTML="<img src='../Images/loadingBlue.gif'> Committing Document <img src='../Images/loadingRed.gif'>";	
	}
}

function IndexStatus(MessageNode, labelMsg, column4, column5)
{
    var lblMsg= document.getElementById(labelMsg);
    
	if(MessageNode!=null)
	{ 
		var msg = MessageNode.getElementsByTagName('Message');
		
		var indexStatus = GetInnerText(msg[0]);
		
		if(indexStatus.toLowerCase() == "indexed successfully")
		{
		    lblMsg.innerHTML = "<font color=green>The document has been indexed successfully</font>"
		    ClearIndexArea(column4, column5);
		}
		
		if(indexStatus.toLowerCase() == "indexed failed")
		{
		    lblMsg.innerHTML = "<font color=red>Could not index the document, please contact Support Team for help</font>"
		}
	}
	else
	{   
		lblMsg.innerHTML="<font color=red>A problem occurred while indexing file. The file may not have been indexed</font>";
	}
	
}

//HRAImaging Needed
function ReadyForIndexingAutoComp(labelKeyFieldValue, textDocType, labelMsg, labelDocID, column4, column5)
{
    var txtType=document.getElementById(textDocType).value;
    
    var startIndex = txtType.lastIndexOf("[");
    var endIndex = txtType.lastIndexOf("]");
    var typeID = txtType.substring(startIndex + 1, endIndex);
	
	var lblMsg= document.getElementById(labelMsg);
	var KeyField = document.getElementById(labelKeyFieldValue);
	//var KeyFieldBox = document.getElementById("ctl04_txtKeyFieldValue").value;

    var indexAreaOne = document.getElementById(column4).innerHTML;
    var indexAreaTwo = document.getElementById(column5).innerHTML;
//	if(docCat==0 && docType==0)
//	{
//		lblMsg.innerHTML="<font color=red>You must select a document category</font>";
//		return false;
//	}
//	
//	if(docType==0)
//	{
//		lblMsg.innerHTML="<font color=red>You must select a document type</font>";
//		return false;
//	}


	if(txtType=="")
	{
		lblMsg.innerHTML="<font color=red>You must enter a document type</font>";
		return false;
	}
	if(typeID=="")
	{
		lblMsg.innerHTML="<font color=red>You must enter a document type</font>";
		return false;
	}
	if(indexAreaOne=="" && indexAreaTwo=="")
	{
		lblMsg.innerHTML="<font color=red>You must drag at least one page to the right empty area to Index</font>";
		return false;
	}
//	if(KeyFieldBox=="")
//	{
//		lblMsg.innerHTML="<font color=red>Key Field value cannot be blank</font>";
//		return false;
//	}
	if(KeyField.innerHTML=="")
	{
		lblMsg.innerHTML="<font color=red>client ssn cannot be blank</font>";
		return false;
	}

//	if(clientID.innerHTML=="")
//	{
//		lblMsg.innerHTML="<font color=red>client ID cannot be blank</font>";
//		return false;
//	}
	
	return true;
}

function ReindexButtonOnClickAutoComp()
{
	if(ReadyForReindexingAutoComp())
	{
		//Getting the selected type and category from combo boxes.
		var lblMsg= document.getElementById("_ctl0_lblMsg");
		
		//HTMLSelectElement in DOM
        var txtType=document.getElementById("_ctl0_tabContainer_tabPanelAutoComp_txtDocType").value;       	
        	
        var startIndex = txtType.lastIndexOf("[");
        var endIndex = txtType.lastIndexOf("]");
        var typeID = txtType.substring(startIndex + 1, endIndex);      
              
        var docID = document.getElementById("_ctl0_docID").value;
        document.getElementById("_ctl0_lblSSN");
        var ssn = document.getElementById("_ctl0_lblSSN").innerHTML;
        
		//var docID = document.getElementById("_ctl0_lblDocID").innerHTML;
		
		// URL to index document
		var requestUrl =AjaxServerPageName  + "?Action=Reindex&typeID="+typeID+"&docID="+docID+"&SSN="+ssn;
		CreateXmlHttp();
	
		// If browser supports XMLHTTPRequest object
		if(XmlHttp)
		{
			//Setting the event handler for the response
			XmlHttp.onreadystatechange = ReindexDocument;
			
			//Initializes the request object with GET (METHOD of posting), 
			//Request URL and sets the request as asynchronous.
			XmlHttp.open("GET", requestUrl,  true);
			
			//Sends the request to server
			XmlHttp.send(null);	
		}
	
	}
}

function ReadyForReindexingAutoComp()
{
	//need to access it for displaying warning message
	var lblMsg= document.getElementById("_ctl0_lblMsg");
	
	var txtType=document.getElementById("_ctl0_tabContainer_tabPanelAutoComp_txtDocType").value;
    var startIndex = txtType.lastIndexOf("[");
    var endIndex = txtType.lastIndexOf("]");
    var typeID = txtType.substring(startIndex + 1, endIndex);
	
	if(txtType=="")
	{
		lblMsg.innerHTML="<font color=red>You must enter a document type</font>";
		return false;
	}
	if(typeID=="")
	{
		lblMsg.innerHTML="<font color=red>You must enter a document type</font>";
		return false;
	}
	
	return true;
}

//delete a single document page
function DeleteDocumentPageOnClick(docID, pageNumber)
{
	if(window.confirm("Do you want to delete this page?"))
	{
		var requestUrl =AjaxServerPageName  + "?Action=DeleteDocumentPage&DocID="+docID+"&PageNumber="+pageNumber;
		CreateXmlHttp();
        
        //setting the Global variable PageNumber for later use
        PageNumber = pageNumber;
        
		// If browser supports XMLHTTPRequest object
		if(XmlHttp)
		{
			//do NOT set any event handler for the reponse,
			//we just want to access server in JavaScript only
			XmlHttp.onreadystatechange = ClearThumbnail;
			
			//Initializes the request object with GET (METHOD of posting), 
			//Request URL and sets the request as asynchronous.
			XmlHttp.open("GET", requestUrl,  true);
			
			//Sends the request to server
			XmlHttp.send(null);	
		}
	}
}

function ClearThumbnail()
{	
	if(XmlHttp.readyState == 4)
	{
		// To make sure valid response is received from the server, 200 means response received is OK
		if(XmlHttp.status == 200)
		{			
            //alert("Testing successful");
            var thumbnail = document.getElementById(PageNumber);
            //alert(l.innerHTML);
            var thumbnailContainer = thumbnail.parentElement;
            //alert(r.innerHTML);
            thumbnailContainer.removeChild(thumbnail);	
		}
		else
		{
			alert("There was a problem in deleting the page" );
		}
	}	
}

//----------------------Display Image on Click-------------------------------
//Parameter:	
//	pageIndex - page number of the original PDF document 
function EnlargeImageOnClick(filePath, pageIndex)
{	
	// URL to index document
	var requestUrl =AjaxServerPageName  + "?Action=EnlargeImage&path="+filePath+"&index="+pageIndex;

	CreateXmlHttp();

	// If browser supports XMLHTTPRequest object
	if(XmlHttp)
	{
		//Setting the event handler for the response
		XmlHttp.onreadystatechange = DisplayImage;
		
		//Initializes the request object with GET (METHOD of posting), 
		//Request URL and sets the request as asynchronous.
		XmlHttp.open("GET", requestUrl,  true);
		
		//Sends the request to server
		XmlHttp.send(null);	
	}
}


function DisplayImage()
{
	// To make sure receiving response data from server is completed	
	if(XmlHttp.readyState == 4)
	{
		// To make sure valid response is received from the server, 200 means response received is OK
		if(XmlHttp.status == 200)
		{						
			var clientNode = XmlHttp.responseXML.documentElement;
			if(clientNode != null)
			{
				var image = clientNode.getElementsByTagName('Name');
				ImageName = GetInnerText(image[0]);			
				
				var imgURL = 'ThumbImages/'+ ImageName;
				
				//calling function sm() located in modalbox.js file 
				return sm('box',200,30,imgURL );
			}
		}
		else
		{
			alert("There was a problem displaying the image." );
		}
	}	
}
//----------------------Display Image on Click End-------------------------------