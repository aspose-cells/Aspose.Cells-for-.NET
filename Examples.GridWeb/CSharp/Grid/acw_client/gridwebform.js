//Copyright (c) 2001-2016 Aspose Pty Ltd. All Rights Reserved.

/*****************************************************
 * Aspose.Cells.GridWeb Component Script File
 * Copyright 2003-2011, All Rights Reserverd.
 * V2.4.0
 *****************************************************/
function onselectchange(o)
{
	o.parentNode.firstChild.value=o.options[o.selectedIndex].value;
}

function oncheckboxclick(o)
{
	o.parentNode.firstChild.value = o.checked? "TRUE":"FALSE";
}

function savePos(gform)
{
	var pos = document.getElementById(gform.id + "_POS");
	pos.value = document.body.scrollLeft + "|" + document.body.scrollTop;
}

function initPos(gform)
{
	if (getattr(gform, "bodyleft") != null)
		document.body.scrollLeft = getattr(gform, "bodyleft");
	if (getattr(gform, "bodytop") != null)
		document.body.scrollTop = getattr(gform, "bodytop");
}

function formValidateAll(gform)
{
	var vresult = true;
	var ftab = document.getElementById(gform.id + "_ETAB");
	var decimalpoint = getattr(gform, "decimalpoint");
	for (var r=0; r<ftab.rows.length; r++)
	{
		var row = ftab.rows[r];
		var cell = row.cells[1];
		if (cell.hasChildNodes() && cell.firstChild.hasChildNodes() && cell.firstChild.firstChild.type == "text")
		{
			if (!validateInput(cell, decimalpoint))
				vresult = false;
		}
	}
	return vresult;
}

function getattr(o, name)
{
	if (o.attributes[name] != null)
		return o.attributes[name].nodeValue;
	return null;
}

function validateInput(o, decimalpoint)
{
	var vtype = getattr(o, "vtype");
	var value = o.firstChild.firstChild.value;
	if (value == null || value == "")
	{
		if (getattr(o, "isrequired") == "1")
		{
			setInvalid(o);
			return false;
		}
		else
		{
			setValid(o);
			return true;
		}
	}
	var formula = getattr(o, "formula");
	var ufv = getattr(o, "ufv");
	var nv;

	if (vtype == "regex" || getattr(o, "regex") != null)
	{
		var rx = new RegExp(getattr(o, "regex"));
		var matches = rx.exec(value);
		if (matches == null || value != matches[0])
		{
			if (formula != null)
			{
				matches = rx.exec(formula);
				if (matches == null || formula != matches[0])
				{
					setInvalid(o);
					return false;
				}
			}
			else if (ufv != null)
			{
				matches = rx.exec(ufv);
				if (matches == null || ufv != matches[0])
				{
					setInvalid(o);
					return false;
				}
			}
			else
			{
				setInvalid(o);
				return false;
			}
		}
	}

	switch (vtype)
	{
		case "regex":
			setValid(o);
			return true;
			break;

		case "bool":
			var bv = value.toUpperCase();
			if (bv == "TRUE" || bv == "FALSE")
			{
				setValid(o);
				return true;
			}
			else
			{
				setInvalid(o);
				return false;
			}
			break;

		case "number":
			nv = validatorConvert(value, "Double", decimalpoint);
			if (nv == null && ufv != null)
				nv = validatorConvert(ufv, "Double", decimalpoint);
			if (nv != null)
			{
				setValid(o);
				return true;
			}
			else
			{
				setInvalid(o);
				return false;
			}
			break;

		case "int":
			nv = validatorConvert(value, "Integer", decimalpoint);
			if (nv == null && ufv != null)
				nv = validatorConvert(ufv, "Integer", decimalpoint);
			if (nv != null)
			{
				setValid(o);
				return true;
			}
			else
			{
				setInvalid(o);
				return false;
			}
			break;

		case "date":
			nv = validatorConvert(value, "Date", decimalpoint);
			if (nv == null && ufv != null)
				nv = validatorConvert(ufv, "Date", decimalpoint);
			if (nv != null)
			{
				setValid(o);
				return true;
			}
			else
			{
				setInvalid(o);
				return false;
			}
			break;

		case "datetime":
			nv = validatorConvert(value, "Date", decimalpoint);
			if (nv == null)
				nv = validatorConvert(value, "DateTime", decimalpoint);
			if (nv == null && ufv != null)
			{
				nv = validatorConvert(ufv, "Date", decimalpoint);
				if (nv == null)
					nv = validatorConvert(ufv, "DateTime", decimalpoint);
			}
			if (nv != null)
			{
				setValid(o);
				return true;
			}
			else
			{
				setInvalid(o);
				return false;
			}
			break;

		case "customfunction":
			var cvf = eval(getattr(o, "cvfn"));
			var cvfResult = cvf(o, value);
			if (!cvfResult)
			{
				if (formula != null)
					cvfResult = cvf(o, formula);
				else if (ufv != null)
					cvfResult = cvf(o, ufv);
			}
			if (cvfResult)
			{
				setValid(o);
				return true;
			}
			else
			{
				setInvalid(o);
				return false;
			}
			break;

		default:
			setValid(o);
			return true;
	}
}

function validatorConvert(op, dataType, decimalpoint) {
    var num, cleanInput, m, exp;
    if (dataType == "Integer") {
        exp = /^\s*[-\+]?\d+\s*$/;
        if (op.match(exp) == null) 
            return null;
        num = parseInt(op, 10);
        return (isNaN(num) ? null : num);
    }
    else if(dataType == "Double") {
		if (decimalpoint == null)
			decimalpoint = ".";
        exp = new RegExp("^\\s*([-\\+])?(\\d+)?(\\" + decimalpoint + "(\\d+))?\\s*$");
        m = op.match(exp);
        if (m == null)
            return null;
        cleanInput = (m[1]!=null?m[1]:"") + (m[2].length>0 ? m[2] : "0") + "." + m[4];
        num = parseFloat(cleanInput);
        return (isNaN(num) ? null : num);
    } 
    else if (dataType == "Date") {
        var yearFirstExp = /^(\d{4})-(\d{2})-(\d{2})$/;
        m = op.match(yearFirstExp);
        var day, month, year;
        if (m != null) {
             year = m[1];
            month = m[2];
           day = m[3];
        }
        else {
			return null;
        }
        month-=1;
        var date = new Date(year, month, day);
        return (typeof(date) == "object" && year == date.getFullYear() && month == date.getMonth() && day == date.getDate()) ? date.valueOf() : null;
    }
    else if (dataType == "DateTime") {
        var yearFirstExp = /^(\d{4})-(\d{2})-(\d{2}) (\d+)\:(\d+)\:(\d+)$/;
        m = op.match(yearFirstExp);
        var day, month, year, hour, minu, sec;
        if (m != null) {
             year = m[1];
            month = m[2];
           day = m[3];
           hour = m[4];
           minu = m[5];
           sec = m[6];
        }
        else {
			return null;
        }
        month-=1;
        var date = new Date(year, month, day, hour, minu, sec);
        return (typeof(date) == "object" && year == date.getFullYear() && month == date.getMonth() && day == date.getDate() && hour == date.getHours() && minu == date.getMinutes() && sec == date.getSeconds()) ? date.valueOf() : null;
    }
    else {
        return op.toString();
    }
}

function setValid(o)
{
	o.style.border = "";
}

function setInvalid(o)
{
	o.style.border = "1px dotted red";
}

function dateBtnClick(gform, o)
{
	var Calendar = o.calendar;
	if (Calendar != null)
	{
		o.calendar = null;
		Calendar.removeNode(true);
	}
	else
	{
		Calendar = document.createElement("SPAN");
		document.body.appendChild(Calendar);
		Calendar.dateBtn = o;
		Calendar.style.position = "absolute";
		Calendar.style.display = "block";
		Calendar.style.width = 280;
		Calendar.style.height = 150;
		Calendar.style.zIndex = 99999999;
		o.calendar = Calendar;
		
		Calendar.style.posLeft = document.body.scrollLeft + event.clientX;
		Calendar.style.posTop = document.body.scrollTop + event.clientY;
		var left = Calendar.offsetLeft - event.offsetX - 1;
		if (left < 0)
			left = 0;
		var top = Calendar.offsetTop + o.offsetHeight - event.offsetY - 1;
		if (top < 0)
			top = 0;
		Calendar.style.posLeft = left;
		Calendar.style.posTop = top;
		
		Calendar.addBehavior(gform.acw_client_path+"calendar.htc");
		if (Calendar.readyState == "complete")
			Calendar.attachEvent("onpropertychange", onCalendarChange);
		else
			Calendar.onreadystatechange = onCalendarReady;
	}
}

function onCalendarReady()
{
	var Calendar = event.srcElement;
	if (Calendar.readyState == "complete")
		Calendar.attachEvent("onpropertychange", onCalendarChange);
}

function onCalendarChange()
{
	var Calendar = event.srcElement;
	var ActiveCell = Calendar.dateBtn.parentElement.firstChild;
	if (event.propertyName == "day")
	{
		var day = Calendar.day.toString();
		if (day.length == 1)
			day = '0' + day;
		var month = Calendar.month.toString();
		if (month.length == 1)
			month = '0' + month;
		var datestr = Calendar.year.toString() + '-' + month + '-' + day;
		ActiveCell.value = datestr;
		Calendar.dateBtn.calendar = null;
		Calendar.removeNode(true);
	}
}

function enableAll(gform)
{
	var eles = gform.getElementsByTagName("INPUT");
	for (var i=0; i<eles.length; i++)
	{
		eles[i].disabled = false;
	}
}
