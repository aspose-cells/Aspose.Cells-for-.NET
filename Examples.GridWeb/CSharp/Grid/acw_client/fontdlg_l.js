//Copyright (c) 2001-2016 Aspose Pty Ltd. All Rights Reserved.

//Copyright (c) 2001-2012 Aspose Pty Ltd. All Rights Reserved.

/*****************************************************
 * Aspose.Cells.GridWeb Component Script File
 * Copyright 2003-2011, All Rights Reserverd.
 * V2.5.1
 *****************************************************/
var acell;
var olist = null;
var setborder = null;
var _element;

function initDlg()
{
	_element = window.opener.acwDialogElement;
	if (_element._selections != null && _element._selections.list.length > 0)
	{
		olist = _element._selections;
		var range = olist.list[0];
		acell = _element.getCell(range.startRow, range.startCol);
	}
	else
		acell = _element.ActiveCell;
	
	table2.style.height = table1.offsetHeight;
	window.innerWidth = table1.offsetWidth;
	window.innerHeight = document.body.offsetHeight;

	getSystemFonts();
	
	if (!acell.tdstyle)
	{
		try {copyStyles();}
		catch (ex) {}
		acell.tdstyle = true;
	}

	preview.style.fontFamily = txtFont.value = acell.style.fontFamily;
	preview.style.fontStyle = acell.style.fontStyle;
	preview.style.fontWeight = acell.style.fontWeight;
	preview.style.display = "table-cell";
	preview.style.verticalAlign = acell.style.verticalAlign;
	preview.parentNode.align = acell.align;

	
	var tmps = "";
	if (acell.style.fontStyle != "" && acell.style.fontStyle != "normal")
		tmps += "Italic";
		
	if (acell.style.fontWeight != "" && acell.style.fontWeight != "normal")
	{
		if (tmps != "")
			tmps += " Bold";
		else
			tmps = "Bold";
	}
	
	if (tmps == "")
		tmps = "Regular";

	txtStyle.value = tmps;
	
	preview.style.fontSize = txtSize.value = acell.style.fontSize;
	preview.style.color = btnFC.style.backgroundColor = acell.orgColor;
	preview.style.backgroundColor = btnBG.style.backgroundColor = acell.orgBgColor;
	
	for (var op1 = 0; op1 < selHalign.options.length; op1++)
	{
	    if (selHalign.options[op1].value == acell.align)
		{
			selHalign.selectedIndex = op1;
			break;
		}
	}
	for (var op1 = 0; op1 < selValign.options.length; op1++)
	{
		if (selValign.options[op1].value == acell.style.verticalAlign)
		{
			selValign.selectedIndex = op1;
			break;
		}
	}

	preview.style.textDecorationUnderline = chkUnderline.checked = acell.style.textDecoration.indexOf("underline") != -1;
	preview.style.textDecorationLineThrough = chkStrike.checked = acell.style.textDecoration.indexOf("line-through") != -1;

	var itext = acell.innerText;
	if (itext != null && itext != "")
		preview.innerText = itext;

	selValign.onchange = function () {
	    preview.style.verticalAlign = this.value;
	   
	};
	selHalign.onchange = function () {
	    preview.parentNode.align = this.value; 
     };
  
}

function copyStyles()
{
	acell.style.textDecoration = "none";
	for (var s1 = 0; s1 < acell.ownerDocument.styleSheets.length; s1++)
	{
		var styleSheet = acell.ownerDocument.styleSheets[s1];
		for (var s2 = 0; s2 < styleSheet.cssRules.length; s2++)
		{
			var rule = styleSheet.cssRules[s2];
			if (rule.selectorText == "."+acell.className)
			{
				acell.style.fontFamily = rule.style.fontFamily;
				acell.style.fontStyle = rule.style.fontStyle;
				acell.style.fontWeight = rule.style.fontWeight;
				acell.style.fontSize = rule.style.fontSize;
				acell.orgColor = rule.style.color;
				acell.orgBgColor = rule.style.backgroundColor;
				acell.style.textAlign = rule.style.textAlign;
				acell.style.verticalAlign = acell.vAlign;
				acell.style.textDecoration = rule.style.textDecoration;
				
				s1 = acell.ownerDocument.styleSheets.length;
				break;
			}
		}
	}
}

function getSystemFonts()
{
	var fArray = new Array("System","Terminal","Fixedsys","Roman","Script","Modern","Small Fonts","MS Serif","WST_Czec","WST_Engl","WST_Fren","WST_Germ","WST_Ital","WST_Span","WST_Swed","Courier","MS ,ans Serif","Marlett","Arial","Courier New","Lucida Console","Lucida Sans Unicode","Times New ,oman","Wingdings","Symbol","Verdana","Arial Black","Comic Sans MS","Impact","Georgia","Franklin ,othic Medium","Palatino Linotype","Tahoma","Trebuchet MS","Webdings","Estrangelo Edessa","Gautami","Latha","Mangal","MV Boli","Raavi","Shruti","Tunga","Sylfaen","Microsoft Sans ,erif","MS Mincho","MS PMincho","MS Gothic","MS PGothic","MS UI Gothic","Gulim","GulimChe","Dotum","DotumChe","Batang","BatangChe","Gungsuh","GungsuhChe","MingLiU","PMingLiU","Agency FB","Algerian","Arial Narrow","Arial Rounded MT Bold","Arial Unicode MS","Baskerville Old Face","Bauhaus 93","Bell MT","Berlin Sans FB","Bernard MT Condensed","Blackadder ITC","Bodoni MT","Bodoni MT Black","Bodoni MT Condensed","Bodoni MT Poster ,ompressed","Book Antiqua","Bookman Old Style","Bradley Hand ITC","Britannic Bold","Broadway","Brush Script MT","Californian FB","Calisto MT","Castellar","Centaur","Century","Century Gothic","Century Schoolbook","Chiller","Colonna MT","Cooper Black","Copperplate Gothic Bold","Copperplate Gothic Light","Curlz MT","Edwardian ,cript ITC","Elephant","Engravers MT","Eras Bold ITC","Eras Demi ITC","Eras Light ITC","Eras Medium ,TC","Felix Titling","Footlight MT Light","Forte","Franklin Gothic Book","Franklin Gothic Demi","Franklin Gothic Demi Cond","Franklin Gothic Heavy","Franklin Gothic Medium Cond","Freestyle ,cript","French Script MT","Garamond","Gigi","Gill Sans MT Ext Condensed Bold","Gill Sans MT","Gill ,ans MT Condensed","Gill Sans Ultra Bold","Gill Sans Ultra Bold Condensed","Gloucester MT Extra ,ondensed","Goudy Old Style","Goudy Stout","Haettenschweiler","Harlow Solid Italic","Harrington","High Tower Text","Imprint MT Shadow","Jokerman","Juice ITC","Kristen ITC","Kunstler Script","Lucida Bright","Lucida Calligraphy","Lucida Fax","Lucida Handwriting","Lucida Sans","Lucida Sans Typewriter","MS Outlook","Magneto","Maiandra GD","Matura MT ,cript Capitals","Mistral","Modern No. 20","Monotype Corsiva","Niagara Engraved","Niagara Solid","OCR A Extended","Old English Text MT","Onyx","Palace Script MT","Papyrus","Parchment","Perpetua","Perpetua Titling MT","Playbill","Poor Richard","Pristina","Rage Italic","Ravie","Rockwell","Rockwell Condensed","Rockwell Extra Bold","Informal Roman","Script MT Bold","Showcard Gothic","Snap ITC","Stencil","Tw Cen MT","Tw Cen ,T Condensed","Tempus Sans ITC","Viner Hand ITC","Vivaldi","Vladimir Script","Wide Latin","Wingdings 2","Wingdings 3","Berlin Sans FB Demi","MS Reference Sans Serif","MS Reference ,pecialty","Tw Cen MT Condensed Extra Bold","MT Extra","Bookshelf Symbol 7","Kingsoft Phonetic ,lain","Basemic","Basemic Symbol","Basemic Times","Addled","Calligraphic","DicotMedium","Geotype ,T","Harvest","HarvestItal","Lissen","PalentItal","Palent","Unpact","Whimsy TT");
	var oDropDown = selFont;
	for (var i = 0;i < fArray.length;i++)
	{ 
		var oOption = document.createElement("OPTION");
		oDropDown.appendChild(oOption);	
		oOption.text = fArray[i];
		oOption.Value = i;
	} 
}

function chooseColor() {
    var url = window.location.pathname;
    var lastIndex = url.lastIndexOf("/");
    var colordlghtml = url.substr(0, lastIndex) + "/colordlg.htm";
	window.colorElement = btnFC;
	window.colorChanged = OnForeColorChange;
	window.open(colordlghtml, "colordlg", "chrome,dependent,dialog,modal");
}

function chooseBgColor() {
    var url = window.location.pathname;
    var lastIndex = url.lastIndexOf("/");
    var colordlghtml = url.substr(0, lastIndex) + "/colordlg.htm";
	window.colorElement = btnBG;
	window.colorChanged = OnBGColorChange;
	window.open(colordlghtml, "colordlg", "chrome,dependent,dialog,modal");
}

function chooseBorderColor() {
    var url = window.location.pathname;
    var lastIndex = url.lastIndexOf("/");
    var colordlghtml = url.substr(0, lastIndex) + "/colordlg.htm";
	window.colorElement = btnBorderColor;
	window.colorChanged = OnBorderColorChange;
	window.open(colordlghtml, "colordlg", "chrome,dependent,dialog,modal");
}

function OnForeColorChange()
{
	preview.style.color = btnFC.style.backgroundColor;
}

function OnBGColorChange()
{
	preview.style.backgroundColor = btnBG.style.backgroundColor;
}

function OnBorderColorChange()
{
}

function OnFontChange()
{
	txtFont.value = selFont.options[selFont.selectedIndex].text;
	OnFontChange1();
}

function OnFontChange1()
{
	preview.style.fontFamily = txtFont.value;
}

function OnStyleChange()
{
	txtStyle.value = selStyle.options[selStyle.selectedIndex].text;
	switch (txtStyle.value)
	{
		case "Regular":
			preview.style.fontStyle="normal";
			preview.style.fontWeight="normal";
			break;
		case "Italic":
			preview.style.fontStyle="italic";
			preview.style.fontWeight="normal";
			break;
		case "Bold":
			preview.style.fontStyle="normal";
			preview.style.fontWeight="bold";
			break;
		case "Italic Bold":
			preview.style.fontStyle="italic";
			preview.style.fontWeight="bold";
			break;
	}
}

function OnSizeChange()
{
	txtSize.value = selSize.options[selSize.selectedIndex].text;
	OnSizeChange1();
}

function OnSizeChange1()
{
	preview.style.fontSize = txtSize.value;
}

function OnUnderline()
{
	preview.style.textDecorationUnderline = chkUnderline.checked;
}

function OnLineThrough()
{
	preview.style.textDecorationLineThrough = chkStrike.checked;
}

function FontOk()
{
	if (setborder != null)
		setBorders();
		
	if (getattr(acell, "protected") == "1")
		acell = document.createElement("TD");
	acell.styleStr = acell.style.fontFamily = txtFont.value;
	acell.styleStr += "|";
	switch (txtStyle.value)
	{
		case "Regular":
			acell.style.fontStyle = "normal";
			acell.style.fontWeight = "normal";
			acell.styleStr += "r|";
			break;
			
		case "Italic":
			acell.style.fontStyle = "italic";
			acell.style.fontWeight = "normal";
			acell.styleStr += "i|";
			break;
		
		case "Bold":
			acell.style.fontStyle = "normal";
			acell.style.fontWeight = "bold";
			acell.styleStr += "b|";
			break;
			
		case "Italic Bold":
			acell.style.fontStyle = "italic";
			acell.style.fontWeight = "bold";
			acell.styleStr += "ib|";
			break;

		default:
			acell.style.fontStyle = "normal";
			acell.style.fontWeight = "normal";
			acell.styleStr += "r|";
			break;
	}
	acell.style.fontSize = txtSize.value;
	
	if (chkUnderline.checked)
		acell.style.textDecoration = "underline";
	else
		acell.style.textDecoration = "";
	if (chkStrike.checked)
	{
		if (chkUnderline.checked)
			acell.style.textDecoration += " line-through";
		else
			acell.style.textDecoration = "line-through";
	}
	
	if (!chkUnderline.checked && !chkStrike.checked)
		acell.style.textDecoration = "none";

	var color = acell.orgColor = btnFC.style.backgroundColor;
	var bcolor = acell.orgBgColor = btnBG.style.backgroundColor;
	if (color != null && color != "" && color.charAt(0) != "#")
		color = transColor(color);
	if (bcolor != null && bcolor != "" && bcolor.charAt(0) != "#")
		bcolor = transColor(bcolor);
	//acell.style.textAlign = selHalign.options[selHalign.selectedIndex].value;
	acell.style.verticalAlign = selValign.options[selValign.selectedIndex].value;
    //new added
	acell.align =selHalign.options[selHalign.selectedIndex].value;
	acell.styleStr += txtSize.value + "|" + chkUnderline.checked + "|"
		+ chkStrike.checked + "|" + color + "|" + bcolor
		+ "|" + selHalign.options[selHalign.selectedIndex].value + "|" + selValign.options[selValign.selectedIndex].value;

	if (olist != null)
	{
		for (var i = 0; i < olist.list.length; i++)
		{
			var range = olist.list[i];
			for (var r = range.startRow; r <= range.endRow; r++)
            {
                for (var c = range.startCol; c <= range.endCol; c++)
                {
                    var cell = olist.g.getCell(r, c);
					if (cell != null && cell != acell && getattr(cell, "protected") != "1")
				    {
					    cell.styleStr = acell.styleStr + "|" + (cell.tbstr!=null?cell.tbstr:"") + "|" + (cell.bbstr!=null?cell.bbstr:"") + "|" + (cell.lbstr!=null?cell.lbstr:"") + "|" + (cell.rbstr!=null?cell.rbstr:"");
					    cell.style.fontFamily = acell.style.fontFamily;
					    cell.style.fontStyle = acell.style.fontStyle;
					    cell.style.fontWeight = acell.style.fontWeight;
					    cell.style.fontSize = acell.style.fontSize;
					    cell.style.textDecoration = acell.style.textDecoration;
					    cell.orgColor = acell.orgColor;
					    cell.orgBgColor = acell.orgBgColor;
					    //cell.style.textAlign = acell.style.textAlign;
					    cell.align = acell.align;
					    cell.style.verticalAlign = acell.style.verticalAlign;
				    }
				}
			}
		}
	}
	acell.styleStr = acell.styleStr + "|" + (acell.tbstr!=null?acell.tbstr:"") + "|" + (acell.bbstr!=null?acell.bbstr:"") + "|" + (acell.lbstr!=null?acell.lbstr:"") + "|" + (acell.rbstr!=null?acell.rbstr:"");
	_element.closeFontDialog();
	window.returnValue = true;
	window.close();
	window.opener.fontdialogcallback();
}

function showFont()
{
	btnFont.style.border = "1px inset white";
	btnBorders.style.border = "1px outset white";
	table1.style.display = "block";
	table2.style.display = "none";
}

function showBorders()
{
	btnBorders.style.border = "1px inset white";
	btnFont.style.border = "1px outset white";
	table1.style.display = "none";
	table2.style.display = "block";
}

function clickBorderBtn(ev)
{
	var o = ev.target;
	var id = o.id;
	var i;
	for (i = 1; i<=8; i++)
	{
		eval("b"+i+".style.border='3px ridge white';");
	}
	o.style.border = "3px inset white";
	setborder = id;
}

function transColor(color)
{
	var rx = /^rgb\(\s*(\d+),\s*(\d+),\s*(\d+)\s*\)$/;
	var matches = rx.exec(color);
	if (matches != null)
	{
		var sColor = Number(Number(matches[1])*65536+Number(matches[2])*256+Number(matches[3]));
		sColor = sColor.toString(16);
  		var sTempString = "#000000".substring(0,7-sColor.length);
  		sColor = sTempString.concat(sColor);
  		return sColor;
	}
	return "";
}


function setBorderWidthSelect (it) {
	
	 
     if(it=="Dashed")
    {  //only thin ,medium for dashed options
        if(borderWidth.options.length==3)
	    {borderWidth.options.remove(2);
		}
	 }else
	 {  //thin,medium,thick for other options 
       if(borderWidth.options.length==2){
        var option=document.createElement("option");
		option.value="3px";
		option.text="thick";
		 borderWidth.options.add(option);
	     }
	 }
	 if(it=="Double"||it=="Dotted")
	 {borderlinelabel.style.display="none";
      borderWidth.style.display="none";
	  if(it=="Double")
	  {//3px for double
		  borderWidth.selectedIndex=2;
	  }else{
		 //2px for dotted in order to show it,if we set 1px,we can not see the effect in the browser,
		  //however in the server code ,the dotted is only dotted type it does not care the border width
	   borderWidth.selectedIndex=1;
	  }
	 }else
	 {	borderlinelabel.style.display="block";
        borderWidth.style.display="block";
	 }
	 
}

function setBorders()
{
	var bcolor = btnBorderColor.style.backgroundColor;
	if (bcolor != null && bcolor != "")
		bcolor = transColor(bcolor);
	var bstr = borderWidth.options[borderWidth.selectedIndex].value + " " + borderStyle.options[borderStyle.selectedIndex].text + " " + bcolor;
	if (olist == null)
	{
		switch (setborder)
		{
			case "b1":
				acell.style.borderTop = "none";
				acell.style.borderBottom = "none";
				acell.style.borderLeft = "none";
				acell.style.borderRight = "none";
				acell.tbstr = acell.bbstr = acell.lbstr = acell.rbstr = "none";
				break;
				
			case "b2":
				acell.style.borderBottom = bstr;
				acell.bbstr = bstr;
				break;
				
			case "b3":
				acell.style.borderLeft = bstr;
				acell.lbstr = bstr;
				break;
				
			case "b4":
				acell.style.borderRight = bstr;
				acell.rbstr = bstr;
				break;
				
			case "b5":
				acell.style.borderTop = bstr;
				acell.tbstr = bstr;
				break;

			case "b6":
			case "b7":
				acell.style.borderBottom = bstr;
				acell.style.borderLeft = bstr;
				acell.style.borderRight = bstr;
				acell.style.borderTop = bstr;
				acell.tbstr = acell.bbstr = acell.lbstr = acell.rbstr = bstr;
				break;
				
			case "b8":
				acell.style.borderTop = bstr;
				acell.style.borderBottom = bstr;
				acell.tbstr = acell.bbstr = bstr;
				break;
		}
	}
	else
	{
		switch (setborder)
		{
			case "b1":
			    for (var i = 0; i < olist.list.length; i++)
		        {
			        var range = olist.list[i];
			        for (var r = range.startRow; r <= range.endRow; r++)
                    {
                        for (var c = range.startCol; c <= range.endCol; c++)
                        {
                            var o = olist.g.getCell(r, c);
						    if (o == null || getattr(o, "protected") == "1") continue;
						    o.style.borderTop = "none";
						    o.style.borderBottom = "none";
						    o.style.borderLeft = "none";
						    o.style.borderRight = "none";
						    o.tbstr = o.bbstr = o.lbstr = o.rbstr = "none";
                        }
                    }
				}
				break;
				
			case "b2":
			    for (var i = 0; i < olist.list.length; i++)
		        {
			        var range = olist.list[i];
			        var r = range.endRow;
			        for (var c = range.startCol; c <= range.endCol; c++)
                    {
                        var o = olist.g.getCell(r, c);
				        if (o == null || getattr(o, "protected") == "1") continue;
				        o.style.borderBottom = bstr;
				        o.bbstr = bstr;
				    }
				}
				break;
				
			case "b3":
			    for (var i = 0; i < olist.list.length; i++)
		        {
			        var range = olist.list[i];
			        for (var r = range.startRow; r <= range.endRow; r++)
                    {
                        var o = olist.g.getCell(r, range.startCol);
                        if (o == null || getattr(o, "protected") == "1") continue;
					    o.style.borderLeft = bstr;
					    o.lbstr = bstr;
                    }        
				}
				break;
			
			case "b4":
			    for (var i = 0; i < olist.list.length; i++)
		        {
			        var range = olist.list[i];
			        for (var r = range.startRow; r <= range.endRow; r++)
                    {
                        var o = olist.g.getCell(r, range.endCol);
                        if (o == null || getattr(o, "protected") == "1") continue;
					    o.style.borderRight = bstr;
					    o.rbstr = bstr;
				    }
				}
				break;
			
			case "b5":
			    for (var i = 0; i < olist.list.length; i++)
		        {
			        var range = olist.list[i];
                    for (var c = range.startCol; c <= range.endCol; c++)
                    {
                        var o = olist.g.getCell(range.startRow, c);
					    if (o == null || getattr(o, "protected") == "1") continue;
					    o.style.borderTop = bstr;
					    o.tbstr = bstr;
					}	    
				}
				break;
			
			case "b6":
			    for (var i = 0; i < olist.list.length; i++)
		        {
			        var range = olist.list[i];
			        for (var r = range.startRow; r <= range.endRow; r++)
                    {
                        for (var c = range.startCol; c <= range.endCol; c++)
                        {
                            var o = olist.g.getCell(r, c);
						    if (o == null || getattr(o, "protected") == "1") continue;
				            o.style.borderTop = bstr;
				            o.style.borderBottom = bstr;
				            o.style.borderLeft = bstr;
				            o.style.borderRight = bstr;
				            o.tbstr = o.bbstr = o.lbstr = o.rbstr = bstr;
					    }
					}
				}
				break;
				
			case "b7":
				setborder = "b2";
				setBorders();
				setborder = "b3";
				setBorders();
				setborder = "b4";
				setBorders();
				setborder = "b5";
				setBorders();
				break;
				
			case "b8":
				setborder = "b2";
				setBorders();
				setborder = "b5";
				setBorders();
				break;
		}
	}
}

function disableEvent(ele)
{
	_omd = ele.onmousedown;
	_omu = ele.onmouseup;
	_oc = ele.onclick;
	_omo = ele.onmouseover;
	_odc = ele.ondblclick;
	_omm = ele.onmousemove;
	_ocm = ele.oncontextmenu;
	ele.onmousedown = null;
	ele.onmouseup = null;
	ele.onclick = null;
	ele.onmouseover = null;
	ele.ondblclick = null;
	ele.onmousemove = null;
	ele.oncontextmenu = null;
}

function enableEvent(ele)
{
	ele.onmousedown = _omd;
	ele.onmouseup = _omu;
	ele.onclick = _oc;
	ele.onmouseover = _omo;
	ele.ondblclick = _odc;
	ele.onmousemove = _omm;
	ele.oncontextmenu = _ocm;
}

function closeDlg()
{
	window.opener.acwDialogWindow = null;
}

function getattr(o, name)
{
	if (o.attributes[name] != null)
		return o.attributes[name].nodeValue;
	return o.attributes[name];
}
