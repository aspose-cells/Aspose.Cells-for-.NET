//Copyright (c) 2001-2016 Aspose Pty Ltd. All Rights Reserved.

/***********************************************************************************************
 * Aspose.Cells.GridWeb Component Script File
 * Copyright 2003-2011, All Rights Reserverd.
 ************************************************************************************************/
 
var _oFindWhat				= null;		// The controll that be input what finding
var _oReplaceWith			= null;		// The controll that be input what replacing whith
var _oCase					= null;		// The check box to determine whether macthing case
var _oWord					= null;		// The check box to determine whether macthing whole word
var _oDirection				= null;		// The check box to determine searching direction. search down and search up.
var _oRegular				= null;		// The check box to determine whether the seaching string is a regular expression.
var _oFindIn				= null;		// The drop down list to indicate target is formulas or values.
var _oBtnFind				= null;		// The find next button.
var _oBtnReplace			= null;		// The replace button.
var _oBtnReplaceAll			= null;		// The replace all button.
var _oBtnClose				= null;		// The close button.

var _parentWindow			= null;		// The parent window
var _element				= null;		// The GridWeb object.
var _viewTable				= null;		// One of the ViewTable objects.
var _viewTable00			= null;		// One of the ViewTable objects.
var _viewTable01			= null;		// One of the ViewTable objects.
var _viewTable10			= null;		// One of the ViewTable objects.
var _activeCell				= null;		// The active cell.
var _startSearchCell		= null;		// The first cell in a searching process.
var _callType				= 0;		// 0 Find; 1 Replace
var _dialogEdgeLeftWidth	= 0;		// The left edge width of the find/replace dialog window
var _dialogEdgeTopHeight	= 0;		// The top edge width of the find/replace dialog window, i.e. The title bar width.
	
var _cidReg					= new RegExp("^\\d+#\\d+$");
var _findReg                = null;
var _findWhat				= null;
var _regexOptions			= null; 
var _freeze					= null;
var _arrCells				= new Array();
var _cellIndex				= 0;

var _currentViewTable		= null;
var _currentCellIndex		= 0;
var _currentRowIndex		= 0;
var _currentRows			= null;
var _currentCells			= null;
var _currentRowsLength		= 0;
var _currentCellsLength		= 0;


//----------------------------------------------------------------------------------------------------
//	Initializes variants, gets parameters from parent window after window on load.
//----------------------------------------------------------------------------------------------------
window.onload = function(){
	_oFindWhat = document.getElementById("txtFindWhat");
	_oReplaceWith = document.getElementById("txtReplaceWith");
	_oCase = document.getElementById("ckbCase");
	_oWord = document.getElementById("ckbWord");
	_oDirection = document.getElementById("ckbDirection");
	_oRegular = document.getElementById("ckbRegular");
	_oFindIn = document.getElementById("ddlFindIn");
	_oBtnFind = document.getElementById("btnFind");
	_oBtnReplace = document.getElementById("btnReplace");
	_oBtnReplaceAll = document.getElementById("btnReplaceAll");
	_oBtnClose = document.getElementById("btnClose");
	
	if(!window.showModelessDialog) // Is not IE
	{
		_parentWindow = window.opener;
		_element = _parentWindow.acwFindReplaceDialog_Element;
		_activeCell = _parentWindow.acwFindReplaceDialog_StartCell;
		 _oBtnFind.style.width = "100px";
		_oBtnReplace.style.width = "100px";
		_oBtnReplaceAll.style.width = "100px";
		_oBtnClose.style.width = "100px";
		_dialogEdgeLeftWidth = (window.outerWidth - innerWidth)/2;
		_dialogEdgeTopHeight = parseInt((window.outerHeight - innerHeight)/2+1);
	}
	else{ //IE
		_parentWindow = window.dialogArguments[0];
		_arrCells = window.dialogArguments[1];
		_cellIndex = window.dialogArguments[2];
		_element = _parentWindow.acwFindReplaceDialog_Element;
		_activeCell = _parentWindow.acwFindReplaceDialog_StartCell;
		_dialogEdgeLeftWidth = window.screenLeft - parseFloat(window.dialogLeft);
		_dialogEdgeTopHeight = window.screenTop - parseFloat(window.dialogTop);
	}
	_callType = getUrlParameter("callType");
	_freeze = _element.freeze;
	
	init();
}

//----------------------------------------------------------------------------------------------------
//	Sets the variants about this window when the window be closed.
//----------------------------------------------------------------------------------------------------
window.onunload = function(){
	if(typeof _parentWindow == "undefined" || typeof _parentWindow.acwFindReplaceDialog == "undefined"){
		return false;
	}
	
	_parentWindow.acwFindReplaceDialog_Element = null;
	_parentWindow.acwFindReplaceDialog_StartCell = null;
	_parentWindow.acwFindReplaceDialog = null;
}

//----------------------------------------------------------------------------------------------------
//	If reload window opener, closes FindReplace Dialog.
//----------------------------------------------------------------------------------------------------
window.onfocus = function(){
	if(typeof _parentWindow == "undefined" 
		|| typeof _parentWindow.acwFindReplaceDialog == "undefined"
		|| (_activeCell != null &&  _activeCell.parentNode == null)){
		window.close();
	}
}

//----------------------------------------------------------------------------------------------------
//	Handles onkeyown events
//----------------------------------------------------------------------------------------------------
document.onkeydown = function(evt){
	if(evt == null)
		evt = event;
	if(evt.keyCode == 27){ // Esc
		window.close();
		return false;
	}
	else if(evt.keyCode == 13){ //enter
		_oBtnFind.click();
		return false;
	}
}

//----------------------------------------------------------------------------------------------------
//	Initializes variants, determines how to lay out page.
//----------------------------------------------------------------------------------------------------
function init(){
	
	_viewTable = _element.ownerDocument.getElementById(_element.id + "_viewTable");
	if (_freeze)
	{
		_viewTable00 = _element.ownerDocument.getElementById(_element.id + "_viewTable00");
		_viewTable01 = _element.ownerDocument.getElementById(_element.id + "_viewTable01");
		_viewTable10 = _element.ownerDocument.getElementById(_element.id + "_viewTable10");
	}
	
	if(_activeCell == null){
		if(_freeze){
			if(_viewTable00.rows.length != 0 && _viewTable00.rows[0].cells.length != 0){
				_activeCell = _viewTable00.rows[0].cells[0];
			}
			else if(_viewTable01.rows.length != 0 && _viewTable01.rows[0].cells.length != 0){
				_activeCell = _viewTable01.rows[0].cells[0];
			}
			else if(_viewTable10.rows.length != 0 && _viewTable10.rows[0].cells.length != 0){
				_activeCell = _viewTable10.rows[0].cells[0];
			}
			else if(_viewTable.rows.length != 0 && _viewTable.rows[0].cells.length != 0){
				_activeCell = _viewTable.rows[0].cells[0];
			}
			else{ // No cell provide for searching 
				window.close();
				return;
			}
		}
		else {
			if(_viewTable.rows.length == 0 || _viewTable.rows[0].cells.length == 0){ // No cell provide for searching 
				window.close();
				return;
			}
			else{
				 _activeCell = _viewTable.rows[0].cells[0];
			}
		}
		setActiveCell(_activeCell);
	}
	
	validateInitArguments();
	
	showElmentByCallType(_callType);
	
	//FillCellsToArray(_activeCell);
	
	if(navigator.appName.indexOf("Microsoft") == -1){ // Is not IE
		_currentViewTable = _activeCell.offsetParent;
		_currentCellIndex = _activeCell.cellIndex;
		_currentRowIndex = _activeCell.parentNode.rowIndex;
		_currentRows = _currentViewTable.rows;
		_currentRowsLength = _currentRows.length;
		_currentCells = _currentRows[_currentRowIndex].cells;
		_currentCellsLength = _currentCells.length;
	}
}

//----------------------------------------------------------------------------------------------------
//	Determines whether can call the Find/Replace feature.
//----------------------------------------------------------------------------------------------------
function validateInitArguments(){
	if(_element == null || _activeCell == null || _callType == null){
		alert("Arguments are null. Can't call Find/Replace feature!");
		window.close();
	}
}

//----------------------------------------------------------------------------------------------------
//	Determines how to lay out page according to call type(find or replace)
//  Arguments: 
//		callType: o indicates find, 1 indicates replace
//----------------------------------------------------------------------------------------------------
function showElmentByCallType(callType){
	if(callType == 0){ // Find
		document.getElementById("trReplaceWhat").style.display = "none";
		document.getElementById("trReplaceAll").style.display = "none";
	}
	else if(callType == 1){ // Replace
		document.getElementById("trReplaceWhat").style.display = "";
		document.getElementById("trReplaceAll").style.display = "";
	}
	
	if (!_element.editmode) {
		document.getElementById("trReplace").style.display = "none";
	}
}

//----------------------------------------------------------------------------------------------------
// Determines whether continueing to execute when executor clicks find next, replace or replace all button
// Arguments:
//		obj: The button object.
// Return: Allows to execute return true, otherwise return false.
//----------------------------------------------------------------------------------------------------
function isEnableGo(obj){
	if((obj == _oBtnReplace || obj == _oBtnReplaceAll) && !_element.editmode)
		return false;
	if(obj == _oBtnReplace && _callType == 0){
		_callType = 1;
		showElmentByCallType(1);
		return false;
	}
	if((obj == _oBtnReplace || obj == _oBtnReplaceAll) && _oFindIn.value == 2){
		if(window.confirm("Findin must be set to Formulas. Now, set it to Formulas and continue?")){
			_oFindIn.value = 1;
		}
		else{
			return false;
		}
	}
	_findWhat = _oFindWhat.value;
	if(_findWhat == ""){
		alert("Please input what will be searched!");
		return false;
	} 
	
	_regexOptions = getRegExpOptions();
	if(!_oRegular.checked){ // RegularExpression checkbox is false
		_findWhat = escapeMetacharacters(_findWhat); // Escapes meta characters. E.g. "\w" to "\\w"
	}
	
	if(_oWord.checked){
		_findWhat = "(\\W|^)" + _findWhat + "(\\W|$)";
	}
	try{
		_findReg = new RegExp(_findWhat, _regexOptions);
	}
	catch(e){//Regular Expression is error
		alert(e.name + ": " + e.message);
		return false;
	}
	
	_startSearchCell = _activeCell;
	return true;
}

//----------------------------------------------------------------------------------------------------
// Find next cell 
//----------------------------------------------------------------------------------------------------
function find_Next() { 
	var findCell = _startSearchCell;
	do{
		findCell = moveToNextCell3();
		
		var sourceString;
		sourceString = getInnerText(findCell);
		
		// Determines the findCell whether contains the spiciel string.
		if(sourceString != null && sourceString != ""){
			
			//_findReg = new RegExp(_findWhat, _regexOptions);
			
			if(_oFindIn.value == 1){ // Find in values or formulas. If cell is set value by formulas, find in formula, but don't find in value. 
													// otherwise, find in values
				var bHadFound = false;									
				if(getAttribute(findCell,"formula") != null ){
					if(_findReg.exec(getAttribute(findCell, "formula"))){
						bHadFound = true;
					}
				}
				else if(getAttribute(findCell, "ufv") != null){
					if(_findReg.exec(getAttribute(findCell, "ufv"))){
						bHadFound = true;
					}
				}
				else if(_findReg.exec(sourceString)){
					bHadFound = true;
				}
				if(bHadFound){ 
					setActiveCell(findCell); // Had found
					_activeCell = findCell;
					return true;
				}
			}
			else if(_oFindIn.value == 2){ //Only Find values in all cells.
				if(_findReg.exec(sourceString)){ 
					setActiveCell(findCell); // Had found
					_activeCell = findCell;
					return true;
				}
			}	
		}
		
		if(findCell == _startSearchCell){
			alert("The specified text was not found!");
			return false;
		}
	}
	while(true);
}

//----------------------------------------------------------------------------------------------------
// Replaces with the specified string and find next cell
//----------------------------------------------------------------------------------------------------
function replace() {
	var replaceCell = _startSearchCell;
	var replaceCount = 0;
	do{
		var sourceString;
		sourceString = getInnerText(replaceCell);
		if(replaceCount == 0){// Replace
			if(isCanReplaced(replaceCell) && sourceString != null && sourceString != ""){
				_findReg = new RegExp(_findWhat, _regexOptions);
				var txt;
				if(getAttribute(replaceCell, "formula") != null ){  // Is Formula
					if(_findReg.exec(getAttribute(replaceCell, "formula"))){
						if(_oWord.checked){
							txt = getAttribute(replaceCell, "formula").replace(_findReg,"$1" + _oReplaceWith.value + "$2");
							setCellValue(replaceCell,txt);
						}
						else{
							txt = getAttribute(replaceCell, "formula").replace(_findReg,_oReplaceWith.value);
							setCellValue(replaceCell,txt);
						}
						replaceCount++;
					}
				}
				else if(getAttribute(replaceCell, "ufv") != null){ // Is Data Format
					if(_findReg.exec(getAttribute(replaceCell, "ufv"))){
						if(_oWord.checked){
							txt = getAttribute(replaceCell, "ufv").replace(_findReg,"$1" + _oReplaceWith.value + "$2");
							setCellValue(replaceCell,txt);
						}
						else{
							txt = getAttribute(replaceCell, "ufv").replace(_findReg,_oReplaceWith.value);
							setCellValue(replaceCell,txt);
						}
						replaceCount++;
					}
				}
				else if(_findReg.exec(sourceString)){
					if(_oWord.checked){
						txt = sourceString.replace(_findReg,"$1" + _oReplaceWith.value + "$2");
						setCellValue(replaceCell,txt); 
					}
					else{
						txt = sourceString.replace(_findReg,_oReplaceWith.value);
						setCellValue(replaceCell,txt);  
					}
					replaceCount++;
				}
			}
		}
		else{ //Had replaced. Finds next and set it active.
			if(isCanReplaced(replaceCell) && sourceString != null && sourceString != ""){
				_findReg = new RegExp(_findWhat, _regexOptions);
				var bHadFound = false;									
				if(getAttribute(replaceCell,"formula") != null ){
					if(_findReg.exec(getAttribute(replaceCell, "formula"))){
						bHadFound = true;
					}
				}
				else if(getAttribute(replaceCell, "ufv") != null){
					if(_findReg.exec(getAttribute(replaceCell, "ufv"))){
						bHadFound = true;
					}
				}
				else if(_findReg.exec(sourceString)){
					bHadFound = true;
				}
				if(bHadFound){ 
					setActiveCell(replaceCell); // Had found
					_activeCell = replaceCell;
					return true;
				}
			}
		}
		
		replaceCell = moveToNextCell3();
		
		if(replaceCell == _startSearchCell){
			if(replaceCount == 0){
				alert("The specified text was not found or the cell is read only!");
			}
			return false;
		}
    }
    while(true);
} 

//----------------------------------------------------------------------------------------------------
// Replaces with the specified string in all cells.
//----------------------------------------------------------------------------------------------------
function replaceAll() {
	var replaceCell = _startSearchCell;
	var replaceCount = 0;
	do{	
		var sourceString;
		sourceString = getInnerText(replaceCell);
		if(isCanReplaced(replaceCell) && sourceString != null && sourceString != ""){
			_findReg = new RegExp(_findWhat, _regexOptions);
			var txt;
			if(getAttribute(replaceCell, "formula") != null ){  // Is Formula
				if(_findReg.exec(getAttribute(replaceCell, "formula"))){
					if(_oWord.checked){
						txt = getAttribute(replaceCell, "formula").replace(_findReg,"$1" + _oReplaceWith.value + "$2");
						setCellValue(replaceCell,txt);
					}
					else{
						txt = getAttribute(replaceCell, "formula").replace(_findReg,_oReplaceWith.value);
						setCellValue(replaceCell,txt);
					}
					_replaceAllCount++;
				}
			}
			else if(getAttribute(replaceCell, "ufv") != null){ // Is Data Format
				if(_findReg.exec(getAttribute(replaceCell, "ufv"))){
					if(_oWord.checked){
						txt = getAttribute(replaceCell, "ufv").replace(_findReg,"$1" + _oReplaceWith.value + "$2");
						setCellValue(replaceCell,txt);
					}
					else{
						txt = getAttribute(replaceCell, "ufv").replace(_findReg,_oReplaceWith.value);
						setCellValue(replaceCell,txt);
					}
					replaceCount++;
				}
			}
			else if(_findReg.exec(sourceString)){
				if(_oWord.checked){
					txt = sourceString.replace(_findReg,"$1" + _oReplaceWith.value + "$2");
					setCellValue(replaceCell,txt); 
				}
				else{
					txt = sourceString.replace(_findReg,_oReplaceWith.value);
					setCellValue(replaceCell,txt); 
				}
				replaceCount++;
			}
		}
		
		replaceCell = moveToNextCell3();
		
		if(replaceCell == _startSearchCell){
			if(replaceCount > 0){
				alert(replaceCount + " occurrence(s) replaced.");
			}
			else{ 
				alert("The specified text was not found or the cell is read only!");
			}
			_startSearchCell = null;
			return false;
		}
    }
    while(true);
} 


//----------------------------------------------------------------------------------------------------
//	Indicates whether the cell can execute replacing featrue.
//----------------------------------------------------------------------------------------------------
function isCanReplaced(cell){
	var r = false;
	if (getAttribute(cell, "protected") != "1" // Is not Read Only
		&& getAttribute(cell, "vtype") != "dlist"){ // Is not DropDownList
		r = true;
	}
	return r;
}

//----------------------------------------------------------------------------------------------------
//	Gets regular expression options
//----------------------------------------------------------------------------------------------------
function getRegExpOptions(){
	var r = "gi";
	if(_oCase.checked){
		r = r.replace("i","");
	}
	return r;
}

//----------------------------------------------------------------------------------------------------
//	Escapes the meta characters in the specified string.
//----------------------------------------------------------------------------------------------------
function escapeMetacharacters(s){
	var syntax = "\\^$*+?{}.()|[]"; // meta characters
	for(var i=0; i<s.length; i++){
		var index = syntax.indexOf(s.charAt(i));
		if(index != -1){
			s = s.substring(0,i) + "\\" + s.substring(i,s.length);
			i++;
		}
	}
	return s;
}

//----------------------------------------------------------------------------------------------------
//	Sets the specified cell active
//----------------------------------------------------------------------------------------------------
function setActiveCell(cell){
	var index = cell.id.lastIndexOf("_");
	var xy = cell.id.substr(index+1,cell.id.length - index + 1).split("#");
	_element.setActiveCell(xy[1],xy[0]);
	
	// If cell is cover by dialog window, move the dialog window to the right down corner of the cell.
	var offsetParent = cell.offsetParent;
	var offsetLeftToBody = cell.offsetLeft;
	var offsetTopToBody = cell.offsetTop;
	do{
		offsetTopToBody += offsetParent.offsetTop;
		offsetLeftToBody += offsetParent.offsetLeft;
		offsetParent = offsetParent.offsetParent;
	}while(offsetParent);
	var panel = cell.offsetParent.parentNode;
	
	var x, y;
	var condition1, condition2,condition3, condition4;
	if(navigator.appName.indexOf("Microsoft") == -1) // Is not IE
	{
		offsetLeftToBody = offsetLeftToBody - panel.scrollLeft - _parentWindow.document.body.scrollLeft;
		offsetTopToBody = offsetTopToBody - panel.scrollTop - _parentWindow.document.body.scrollTop;
		
		x = offsetLeftToBody + _parentWindow.screenX + (_parentWindow.outerWidth - _parentWindow.innerWidth)/2;
		y = offsetTopToBody + _parentWindow.screenY + (_parentWindow.outerHeight - _parentWindow.innerHeight - _dialogEdgeTopHeight);
		
		condition1 =  x >= window.screenX && x < window.screenX + window.outerWidth;
		condition2 =  x + cell.offsetWidth > window.screenX && x + cell.offsetWidth <= window.screenX + window.outerWidth;
		condition3 =  y >= window.screenY && y < window.screenY + window.outerHeight;
		condition4 =  y + cell.offsetHeight > window.screenY && y + cell.offsetHeight <= window.screenY + window.outerHeight;
		
		if((condition1 || condition2) && (condition3 || condition4)){
			window.moveTo(x + cell.offsetWidth,y + cell.offsetHeight);
		}
	}
	else{ // IE
		offsetLeftToBody = offsetLeftToBody - panel.scrollLeft - _parentWindow.document.body.scrollLeft;
		offsetTopToBody = offsetTopToBody - panel.scrollTop - _parentWindow.document.body.scrollTop;
		
		x = offsetLeftToBody + _parentWindow.screenLeft;
		y = offsetTopToBody + _parentWindow.screenTop;
		
		condition1 =  x >= window.screenLeft - _dialogEdgeLeftWidth && x < window.screenLeft - _dialogEdgeLeftWidth + parseFloat(dialogWidth);
		condition2 =  x + cell.offsetWidth > window.screenLeft - _dialogEdgeLeftWidth && x + cell.offsetWidth <= window.screenLeft - _dialogEdgeLeftWidth + parseFloat(dialogWidth);
		condition3 =  y >= window.screenTop - _dialogEdgeTopHeight && y < window.screenTop - _dialogEdgeTopHeight + parseFloat(dialogHeight);
		condition4 =  y + cell.offsetHeight > window.screenTop - _dialogEdgeTopHeight && y + cell.offsetHeight <= window.screenTop - _dialogEdgeTopHeight + parseFloat(dialogHeight);
		
		if((condition1 || condition2) && (condition3 || condition4)){
			dialogLeft = x + cell.offsetWidth; 
			dialogTop  = y + cell.offsetHeight;
		}
	}
}

//----------------------------------------------------------------------------------------------------
//	Sets cell value to txt.
//----------------------------------------------------------------------------------------------------
function setCellValue(cell,txt){
	var index = cell.id.lastIndexOf("_");
	var xy = cell.id.substr(index+1,cell.id.length - index + 1).split("#");
	_element.setCellValue(xy[1], xy[0],txt);
}

//----------------------------------------------------------------------------------------------------
//	Gets the specified name parameter in url string.
//----------------------------------------------------------------------------------------------------
function getUrlParameter(name)
{
	var url = window.location.search;
	
	var reg = new RegExp("(^|\\?|&)"+ name +"=([^&]*)(\\s|&|$)", "i");
  
	if (reg.exec(url)) 
		return RegExp.$2;
	else
		return "";
}

function getTimeDistance(a,b){
	return b.getMilliseconds() - a.getMilliseconds() + 1000*(b.getSeconds() - a.getSeconds());
}

//----------------------------------------------------------------------------------------------------
//	Determines whether the specified object is valid cell.
//----------------------------------------------------------------------------------------------------
function isValidCell(o){
	if (o.tagName == "TD" && o.id != null && o.id.indexOf(_element.id) == 0 && _cidReg.exec(o.id.substring(_element.id.length+1,o.id.length)))
		return true;
	else 
		return false;
}

//----------------------------------------------------------------------------------------------------
//	Obsolete.  Gets the next cell.
//----------------------------------------------------------------------------------------------------
function moveToNextCell(cell){
	var currentViewTable = cell.offsetParent;
	var cellIndex = cell.cellIndex;
	var rowIndex = cell.parentNode.rowIndex;
	if(_freeze){
		if(_oDirection.checked){ // Search up
			if(cellIndex == 0 || currentViewTable.rows.length == 0 || currentViewTable.rows[rowIndex].cells.length == 0){  
				if(rowIndex == 0){
					if(currentViewTable == _viewTable00){
						currentViewTable = _viewTable;
						if(currentViewTable.rows.length > 0)
							rowIndex = currentViewTable.rows.length - 1;
					}
					else if(currentViewTable == _viewTable01){
						currentViewTable = _viewTable00;
					}
					else if(currentViewTable == _viewTable10){
						currentViewTable = _viewTable01;
						if(currentViewTable.rows.length > 0)
							rowIndex = currentViewTable.rows.length - 1;
					}
					else if(currentViewTable == _viewTable){
						currentViewTable = _viewTable10;
					}
				}
				else{
					if(currentViewTable == _viewTable00){
						currentViewTable = _viewTable01;
						rowIndex--;
					}
					else if(currentViewTable == _viewTable01){
						currentViewTable = _viewTable00;
					}
					else if(currentViewTable == _viewTable10){
						currentViewTable = _viewTable;
						rowIndex--;
					}
					else if(currentViewTable == _viewTable){
						currentViewTable = _viewTable10;
					}
				}
				if(currentViewTable.rows.length > 0 && currentViewTable.rows[rowIndex].cells.length > 0)
					cellIndex = currentViewTable.rows[rowIndex].cells.length -1;
			}
			else{ // Is not first cell in the row. Reduces cellIndex to 1 for move to next cell.
				cellIndex--;
			}
		}
		else{ // Search down
			if(currentViewTable.rows.length == 0 ||currentViewTable.rows[rowIndex].cells.length == 0 || cellIndex == currentViewTable.rows[rowIndex].cells.length - 1 ){  
										      
				cellIndex = 0;
				if(rowIndex == currentViewTable.rows.length - 1 
				    || ((currentViewTable == _viewTable00 || currentViewTable == _viewTable01) && _viewTable00.rows.length == 0 && _viewTable01.rows.length == 0)
					|| ((currentViewTable == _viewTable10 || currentViewTable == _viewTable) && _viewTable10.rows.length == 0 && _viewTable.rows.length == 0)){
					if(currentViewTable == _viewTable00){
						currentViewTable = _viewTable01;
					}
					else if(currentViewTable == _viewTable01){
						currentViewTable = _viewTable10;
						rowIndex = 0;
					}
					else if(currentViewTable == _viewTable10){
						currentViewTable = _viewTable;
					}
					else if(currentViewTable == _viewTable){
						currentViewTable = _viewTable00;
						rowIndex = 0;
					}
				}
				else{
					if(currentViewTable == _viewTable00){
						currentViewTable = _viewTable01;
					}
					else if(currentViewTable == _viewTable01){
						currentViewTable = _viewTable00;
						rowIndex++;
					}
					else if(currentViewTable == _viewTable10){
						currentViewTable = _viewTable;
					}
					else if(currentViewTable == _viewTable){
						currentViewTable = _viewTable10;
						rowIndex++;
					}
				}
			}
			else{ // Is not last cell in the row. Adds cellIndex to 1 for move to next cell.
				cellIndex++;
			}
		}
	}
	else{  
		if(_oDirection.checked){ // Search up
			if(cellIndex == 0){ // Is the first cell in the row. 
								// The row move to next row and cellIndex is evaluated to the last cell index of next row.
				if(rowIndex == 0){
					rowIndex = currentViewTable.rows.length - 1;
				}
				else{
					rowIndex--;
				}
				cellIndex = currentViewTable.rows[rowIndex].cells.length -1;
			}
			else{ // Is not first cell in the row. Reduces cellIndex to 1 for move to next cell.
				cellIndex--;
			}
		}
		else{ // Search down
			if(cellIndex == currentViewTable.rows[rowIndex].cells.length -1){ // Is the last cell in the row. 
										      // The row move to next row and cellIndex is evaluated to the first cell index of next row.
				if(rowIndex == currentViewTable.rows.length - 1){
					rowIndex = 0;
				}
				else{
					rowIndex++;
				}
				cellIndex = 0;
			}
			else{ // Is not last cell in the row. Adds cellIndex to 1 for move to next cell.
				cellIndex++;
			}
		}
    }
    
    var cell = null;
    if(currentViewTable.rows.length > 0 && currentViewTable.rows[rowIndex].cells.length > 0){
		cell = currentViewTable.rows[rowIndex].cells[cellIndex];
	}
    if(cell != null && isValidCell(cell))
		return cell;
    else
		return moveToNextCell(cell);
}

//----------------------------------------------------------------------------------------------------
//	Obsolete.  Gets the next cell that is valid cell.
//----------------------------------------------------------------------------------------------------
function moveToNextCell2(cell){
	if(_freeze){
		var currentViewTable = cell.offsetParent;
		var rowIndex;
		if(_oDirection.checked){ // Search up
			if(cell.previousSibling != null){
				cell = cell.previousSibling;
			}
			else if(cell.parentElement.previousSibling != null){
				rowIndex = cell.parentElement.rowIndex;
				if(currentViewTable == _viewTable00){
					cell = _viewTable01.rows[rowIndex - 1].lastChild;
				}
				else if(currentViewTable == _viewTable01){
					cell = _viewTable00.rows[rowIndex].lastChild;
				}
				else if(currentViewTable == _viewTable10){
					cell = _viewTable.rows[rowIndex - 1].lastChild;
				}
				else if(currentViewTable == _viewTable){
					cell = _viewTable10.rows[rowIndex].lastChild;
				}
			} 
			else{
				if(currentViewTable == _viewTable00){
					cell = _viewTable.rows[_viewTable.rows.length - 1].lastChild;
				}
				else if(currentViewTable == _viewTable01){
					cell = _viewTable00.rows[0].lastChild;
				}
				else if(currentViewTable == _viewTable10){
					cell = _viewTable01.rows[_viewTable01.rows.length - 1].lastChild;
				}
				else if(currentViewTable == _viewTable){
					cell = _viewTable10.rows[0].lastChild;
				}
			}
		}
		else{
			if(cell.nextSibling != null){
				cell = cell.nextSibling;
			}
			else if(cell.parentElement.nextSibling != null){
				rowIndex = cell.parentElement.rowIndex;
				if(currentViewTable == _viewTable00){
					cell = _viewTable01.rows[rowIndex].firstChild;
				}
				else if(currentViewTable == _viewTable01){
					cell = _viewTable00.rows[rowIndex + 1].firstChild;
				}
				else if(currentViewTable == _viewTable10){
					cell = _viewTable.rows[rowIndex].firstChild;
				}
				else if(currentViewTable == _viewTable){
					cell = _viewTable10.rows[rowIndex + 1].firstChild;
				}
			}
			else{
				if(currentViewTable == _viewTable00){
					cell = _viewTable01.rows[_viewTable01.rows.length - 1].firstChild;
				}
				else if(currentViewTable == _viewTable01){
					cell = _viewTable10.rows[0].firstChild;
				}
				else if(currentViewTable == _viewTable10){
					cell = _viewTable.rows[_viewTable.rows.length - 1].firstChild;
				}
				else if(currentViewTable == _viewTable){
					cell = _viewTable00.rows[0].firstChild;
				}
			}
		}
	}
	else{  
		if(_oDirection.checked){ // Search up
			if(cell.previousSibling != null){
				cell = cell.previousSibling;
			}
			else if(cell.parentNode.previousSibling != null){
				cell = cell.parentNode.previousSibling.lastChild;
			}
			else{
				cell = cell.parentNode.parentNode.rows[cell.offsetParent.rows.length - 1].lastChild;
			}
		}
		else{
			if(cell.nextSibling != null){
				cell = cell.nextSibling;
			}
			else if(cell.parentNode.nextSibling != null && cell.parentNode.nextSibling.nodeType == 1){
				cell = cell.parentNode.nextSibling.firstChild;
			}
			else{
				cell = cell.parentNode.parentNode.rows[0].firstChild;
			}
		}
    }
    if(isValidCell(cell))
		return cell;
    else
		return moveToNextCell2(cell);
}

//----------------------------------------------------------------------------------------------------
//	Gets the next cell that is valid cell.
//----------------------------------------------------------------------------------------------------
function moveToNextCell3(){
	if(navigator.appName.indexOf("Microsoft") == -1) {// Is not IE
		if(_oDirection.checked){ // Search up
			if(_currentCellIndex == 0){ // Is the first cell in the row. 
								// The row move to next row and cellIndex is evaluated to the last cell index of next row.
				if(_currentRowIndex == 0){
					_currentRowIndex = _currentRowsLength - 1;
				}
				else{
					_currentRowIndex--;
					
				}
				_currentCells = _currentRows[_currentRowIndex].cells;
				_currentCellsLength = _currentCells.length;
				_currentCellIndex = _currentCellsLength -1;
			}
			else{ // Is not first cell in the row. Reduces cellIndex to 1 for move to next cell.
				_currentCellIndex--;
			}
		}
		else{ // Search down
			if(_currentCellIndex == _currentCellsLength -1){ // Is the last cell in the row. 
										      // The row move to next row and cellIndex is evaluated to the first cell index of next row.
				if(_currentRowIndex == _currentRowsLength - 1){
					_currentRowIndex = 0;
				}
				else{
					_currentRowIndex++;
				}
				_currentCells = _currentRows[_currentRowIndex].cells;
				_currentCellsLength = _currentCells.length;
				_currentCellIndex = 0;
			}
			else{ // Is not last cell in the row. Adds cellIndex to 1 for move to next cell.
				_currentCellIndex++;
			}
		}
    
		var cell = null;
		if(_currentRowsLength > 0 && _currentCellsLength > 0){
			cell = _currentCells[_currentCellIndex];
		}
		if(cell != null && isValidCell(cell))
			return cell;
		else
			return moveToNextCell3();
	}
	else{ //IE
		if(_oDirection.checked){ // Search up
			if(_cellIndex == 0){
				_cellIndex = _arrCells.length;
			}
			return _arrCells[--_cellIndex];
		}	
		else{ // Search down
			if(_cellIndex == _arrCells.length - 1){
				_cellIndex = -1;
			}
			return _arrCells[++_cellIndex];
		}
	}	
}

//----------------------------------------------------------------------------------------------------
//	Obsolete. Fills the cells to a array 
//----------------------------------------------------------------------------------------------------
function FillCellsToArray(startCell){
	//var a = new Date();
	var k = 0;
	var i = 0;
	_arrCells[i] = startCell;
	_cellIndex = startCell.cellIndex;
	
	var rows = _viewTable.rows;
	var rowslen = rows.length;
	var i;
	for (i=0; i<rowslen; i++)
	{
		var cells = rows[i].cells;
		var cellslen = cells.length;
		var j;
		for (j=0; j< cellslen; j++)
		{
			var cell = cells[j];
			_arrCells[k++] = cell;
		}
	}
	//alert(getTimeDistance(a,new Date()));
}

//----------------------------------------------------------------------------------------------------
//	Get inner text of the specified object.
//----------------------------------------------------------------------------------------------------
function getInnerText(o){
	if(o.hasChildNodes()){
		var text = "";
		for(var i=0; i<o.childNodes.length; i++){
			if(o.childNodes[i].nodeType == 3){ // Is TEXT_NODE
				text += o.childNodes[i].nodeValue;
			}
			else{
				var childText = getInnerText(o.childNodes[i]);
				if(childText != null)
					text += childText;
			}
		}
		if(text != "")
			return text;
		else
			return null;
	}
	else
		return null;
}

//----------------------------------------------------------------------------------------------------
//	Gets the value of the specified attribute of the specified object.
//----------------------------------------------------------------------------------------------------
function getAttribute(o, name)
{
	if (o.attributes[name] != null)
		return o.attributes[name].nodeValue;
	return null;
}