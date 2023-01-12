//Copyright (c) 2001-2016 Aspose Pty Ltd. All Rights Reserved.

//Copyright (c) 2001-2011 Aspose Pty Ltd. All Rights Reserved.

/*****************************************************
 * Aspose.Cells.GridWeb Component Script File
 * Copyright 2003-2011, All Rights Reserverd.
 * V2.5.1
 *****************************************************/
var acell;
var olist = null;
var setborder = null;
function initDlg()
{
	acell = dialogArguments;
	if (acell.list != null && (typeof acell.list.length) == "number" && acell.list.length > 0)
	{
		olist = acell;
		var range = olist.list[0];
		acell = olist.g.getCell(range.startRow, range.startCol);
	}
	
	table2.style.height = table1.offsetHeight;
	window.returnValue = false;
	getSystemFonts();
	
	preview.style.fontFamily = txtFont.value = acell.currentStyle.fontFamily;
	preview.style.fontStyle = acell.currentStyle.fontStyle;
	preview.style.fontWeight = acell.currentStyle.fontWeight;
	preview.style.display = "table-cell";
	preview_parent_td.style.verticalAlign = acell.currentStyle.verticalAlign;
	preview.style.textAlign = acell.currentStyle.textAlign;
	//alert(preview_parent_td.style.height + ";" + acell.id + "---" + acell.style.verticalAlign + "acell.currentStyle.verticalAlign----------init;" + acell.currentStyle.verticalAlign + " & " + acell.align);
	
	var tmps = "";
	if (acell.currentStyle.fontStyle != "normal")
		tmps += "Italic";
		
	if (acell.currentStyle.fontWeight != "normal" && acell.currentStyle.fontWeight != "400")
	{
		if (tmps != "")
			tmps += " Bold";
		else
			tmps = "Bold";
	}
	
	if (tmps == "")
		tmps = "Regular";

	txtStyle.value = tmps;
	
	preview.style.fontSize = txtSize.value = acell.currentStyle.fontSize;
	preview.style.color = btnFC.style.backgroundColor = acell.orgColor;
	preview.style.backgroundColor = btnBG.style.backgroundColor = acell.orgBgColor;
	
	//chkSub.checked = acell.parentElement.currentStyle.verticalAlign == "sub";
	//chkSuper.checked = acell.parentElement.currentStyle.verticalAlign == "super";
	//preview.style.verticalAlign = acell.parentElement.currentStyle.verticalAlign;
	
	for (var op1 = 0; op1 < selHalign.options.length; op1++)
	{
		if (selHalign.options[op1].value == acell.currentStyle.textAlign)
		{
			selHalign.selectedIndex = op1;
			break;
		}
	}
	for (var op1 = 0; op1 < selValign.options.length; op1++)
	{
		if (selValign.options[op1].value == acell.currentStyle.verticalAlign)
		{
			selValign.selectedIndex = op1;
			break;
		}
	}

	if (acell.tdstyle)
	{
		preview.style.textDecorationUnderline = chkUnderline.checked = acell.style.textDecorationUnderline;
		preview.style.textDecorationLineThrough = chkStrike.checked = acell.style.textDecorationLineThrough;
	}
	else
	{
		acell.tdstyle = true;
		acell.style.textDecoration = "none";
		for (var s1 = 0; s1 < acell.ownerDocument.styleSheets.length; s1++)
		{
			var styleSheet = acell.ownerDocument.styleSheets[s1];
			for (var s2 = 0; s2 < styleSheet.rules.length; s2++)
			{
				var rule = styleSheet.rules[s2];
				if (rule.selectorText == "."+acell.className)
				{
					acell.style.textDecorationUnderline = preview.style.textDecorationUnderline = chkUnderline.checked = rule.style.textDecorationUnderline;
					acell.style.textDecorationLineThrough = preview.style.textDecorationLineThrough = chkStrike.checked = rule.style.textDecorationLineThrough;
					s1 = acell.ownerDocument.styleSheets.length;
					break;
				}
			}
		}
	}

	var ss = acell.all.tags("SPAN");
	if (ss.length > 0)
	{
		var txt = ss[0].innerText;
		if (txt != "")
			preview.innerText = txt;
	}
	else if (acell.innerText != "")
		preview.innerText = acell.innerText;

	selValign.onchange = function () {
	    preview_parent_td.style.verticalAlign = this.value;
	   // preview.style.verticalAlign = this.value;
	    //alert("value updated1");

	};
	selHalign.onchange = function () {
	    preview.style.textAlign = this.value;
	   // alert("value updated2");
	};
}

function getSystemFonts()
{
	var a=dlgHelper.fonts.count;
	var fArray = new Array();
	var oDropDown = selFont;
	for (var i = 1;i < dlgHelper.fonts.count;i++){ 
		fArray[i] = dlgHelper.fonts(i);
		var oOption = document.createElement("OPTION");
		oDropDown.add(oOption);	
		oOption.text = fArray[i];
		oOption.Value = i;
	} 
}
function convertRGBDecimalToHex(rgb)
{
    var regex = /rgb *\( *([0-9]{1,3}) *, *([0-9]{1,3}) *, *([0-9]{1,3}) *\)/;
    var values = regex.exec(rgb);
    if(values==null||values.length != 4)
    {
        return rgb; // fall back to what was given.              
    }
    var r = Math.round(parseFloat(values[1]));
    var g = Math.round(parseFloat(values[2]));
    var b = Math.round(parseFloat(values[3]));
    return "#" 
        + (r + 0x10000).toString(16).substring(3).toUpperCase() 
        + (g + 0x10000).toString(16).substring(3).toUpperCase()
        + (b + 0x10000).toString(16).substring(3).toUpperCase();
}
function chooseColor(rgbColor)
{
	var sColor = dlgHelper.ChooseColorDlg(rgbColor);
		
	//change decimal to hex
	sColor = sColor.toString(16);
	//add extra zeroes if hex number is less than 6 digits
	if (sColor.length < 6) {
  		var sTempString = "000000".substring(0,6-sColor.length);
  		sColor = sTempString.concat(sColor);
	}
	//btnBorderColor.style.backgroundColor=sColor;
	//btnBorderColor.style.backgroundColor="#"+sColor;
    // alert("ie raise:"+(convertRGBDecimalToHex(btnBorderColor.style.backgroundColor))+";"+("#"+sColor));
	return "#"+sColor;
}

function OnForeColorChange()
{
	preview.style.color = btnFC.style.backgroundColor;
}

function OnBGColorChange()
{
	preview.style.backgroundColor = btnBG.style.backgroundColor;
    preview_parent_td.style.backgroundColor = btnBG.style.backgroundColor;
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
	}
	acell.style.fontSize = txtSize.value;
	acell.style.textDecorationUnderline = chkUnderline.checked;
	acell.style.textDecorationLineThrough = chkStrike.checked;

	acell.orgColor = btnFC.style.backgroundColor;
	acell.orgBgColor = btnBG.style.backgroundColor;
	
	acell.style.textAlign = selHalign.options[selHalign.selectedIndex].value;
	acell.style.verticalAlign = selValign.options[selValign.selectedIndex].value;
	acell.align = selHalign.options[selHalign.selectedIndex].value;

	acell.styleStr += txtSize.value + "|" + chkUnderline.checked + "|"
		+ chkStrike.checked + "|" + convertRGBDecimalToHex(btnFC.style.backgroundColor) + "|" + convertRGBDecimalToHex(btnBG.style.backgroundColor)
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
				        cell.style.textDecorationUnderline = acell.style.textDecorationUnderline;
				        cell.style.textDecorationLineThrough = acell.style.textDecorationLineThrough;
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
	window.returnValue = true;
	window.close();
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

function clickBorderBtn()
{
	var o = event.srcElement;
	var id = o.id;
	var i;
	for (i = 1; i<=8; i++)
	{
		eval("b"+i+".style.border='3px ridge white';");
	}
	o.style.border = "3px inset white";
	setborder = id;
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
	var bstr = borderWidth.options[borderWidth.selectedIndex].value + " " + borderStyle.options[borderStyle.selectedIndex].text + " " + convertRGBDecimalToHex(btnBorderColor.style.backgroundColor);
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

function getattr(o, name)
{
	if (o.attributes[name] != null)
		return o.attributes[name].nodeValue;
	return o.attributes[name];
}