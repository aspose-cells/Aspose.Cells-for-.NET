/* Version: 12.0.3208 */
/*
	Copyright (c) Microsoft Corporation.  All rights reserved.
*/

function G(o)
{
	if(o&&typeof(o)=="string")o=document.getElementById?document.getElementById(o):null;
	return o&&typeof(o)=="object"?o:null;
}

function GS(o)
{
	o=G(o);
	return o?o.style:null;
}

function GDsply(o)
{
	o=GS(o);
	return o?o.display:"";
}

function SDsply(o,d)
{
	o=GS(o);
	if(o)o.display=d;
}

function SDsplyH(o)
{
	SDsply(o,"none");
}

function SDsplyS(o)
{
	SDsply(o,"");
}

function TDsply(o,d)
{
	SDsply(o,(GDsply(o)==d?"none":d));
}

function FVis(o)
{
	return GDsply(o)!="none";
}

function SWdth(o,d)
{
	o=GS(o);
	if(o)o.width=d;
}

function SWdthF(o)
{
	SWdth(o,"768");
}

function SWdthNF(o)
{
	SWdth(o,"100%");
}

function TDB(o)
{
	TDsply(o,"block");
	return false;
}

function FSClk(e)
{
	return e&&e.button<=1&&e.shiftKey;
}

function FSEnt(e)
{
	return e&&e.keyCode==13&&e.shiftKey;
}

function GHlp(u)
{
	var strScrollBars = (window.navigator.appName.toUpperCase().indexOf("NETSCAPE") >= 0) ? ",scrollbars=1" : "" ;
	window.open(u, '_hlp011', 'toolbar=0,status=0,menubar=0' + strScrollBars + ',resizable=1,width=260,height=' + Math.round(window.screen.availHeight*2/3));
	return false;
}

function ChkSrchTxt(wz)
{
	var ws=/^[\s]*$/;
	return wz&&!ws.test(wz);
}

function FocSrchTxt(o)
{
	if(o&&o.value)o.select();
}

function TrySearch(e)
{
	if(oSrchFrm&&SelectAction())
		{

		try {external.AutoCompleteSaveForm(oSrchFrm);} catch (err) {}
		oSrchFrm.submit();
		}
	if(e&&e.stopPropagation)e.stopPropagation(); 
	return false;
}

function EntTextbox(e)
{
	if(e&&e.keyCode==13)return TrySearch(e);
	return true;
}

function TbrGet(tb)
{
	tb=G(tb);
	if(tb&&tb.tagName=="TABLE")
		for(var tbTable=tb.rows[0].cells[0].firstChild; tbTable; tbTable=tbTable.nextSibling)
			if(tbTable.tagName=="TABLE")return tbTable.rows[0];
	return null;
}

function FCIIRange(tr,i)
{
	return tr&&tr.tagName=="TR"&&i!=null&&i>=0&&i<tr.cells.length;
}

function WzGTT(tbic)
{
	var wzType=null;

	tbic=G(tbic);
	if(tbic)
		{
		wzType=tbic.getAttribute("TBICTYPE");
		if(!wzType)wzType="i";
		}

	return wzType;
}

function FIGTbic(tbic)
{
	return FITbic(tbic)||FGTbic(tbic);
}

function FITbic(tbic)
{
	return WzGTT(tbic)=="i";
}

function FGTbic(tbic)
{
	return WzGTT(tbic)=="g";
}

function FSTbic(tbic)
{
	return WzGTT(tbic)=="s";
}

function FPTbic(tbic)
{
	return WzGTT(tbic)=="p";
}

function TbicGet(tb,i,fSkip,tbic)
{
	tbic=G(tbic);
	if(!tbic)
		{
		var tbrow=TbrGet(tb);
		if(!tbrow)return;

		if(i==null)i=0;
		if(fSkip==null)fSkip=true;

		if(FCIIRange(tbrow,i))
			{
			if(!fSkip)
				{
				tbic=tbrow.cells[i];
				}
			else
				{
				for(var iCell=0, cCells=tbrow.cells.length; iCell<cCells; iCell++)
					{
					tbic=tbrow.cells[iCell];

					if(FIGTbic(tbic))
						{
						if(i==0)break; 
						else i--;
						}

					tbic=null;
					if(i<0) break;
					}
				}
			}
		}

	return tbic;
}

function HideTbic(tb,i,tbic)
{
	tbic=TbicGet(tb,i,true,tbic);
	if(tbic)
		{

		SDsplyH(tbic);

		PTBSep(tb);
		}
}

function ShowTbic(tb,i,tbic)
{
	tbic=TbicGet(tb,i,true,tbic);
	if(tbic)
		{

		SDsplyS(tbic);

		PTBSep(tb);
		}
}

function PTBSep(tb)
{
	var tbrow=TbrGet(tb);
	if(!tbrow)return;

	var tbic;
	var iCell, cCells=tbrow.cells.length;

	for(iCell=0, tbic=tbrow.cells[iCell]; tbic&&iCell<cCells; iCell++, tbic=tbrow.cells[iCell])
		if(FSTbic(tbic))SDsplyH(tbic);

	var fVisibleFound=false;
	var tbicNext;
	for(iCell=0, tbic=tbrow.cells[iCell]; tbic&&iCell<cCells; iCell++, tbic=tbrow.cells[iCell])
		{
		if(FIGTbic(tbic)&&FVis(tbic))fVisibleFound=true;
		else if(FPTbic(tbic))fVisibleFound=false;

		tbicNext=tbrow.cells[iCell+1];
		if(fVisibleFound&&FSTbic(tbic)&&FIGTbic(tbicNext)&&FVis(tbicNext))SDsplyS(tbic);
		}
}

function chkStar(){

}

function SetTopNavSiteMapLinkBorder(strTdId, fIsHover)
{
	if (!document.getElementById ||
		'undefined' == typeof(document.getElementById))
		return;

	var tdCell = document.getElementById(strTdId);
	if ('undefined' == typeof(tdCell) ||
		null == tdCell ||
		'undefined' == typeof(tdCell.className))
		return;

	if (fIsHover)
		tdCell.className = 'TopNavCellLinkHover';
	else
		tdCell.className = 'TopNavCellLink';
}

function EncodeUrlComponent(strUrlComponent)
{
	if (typeof(strUrlComponent) == "undefined" ||
		null == strUrlComponent)
		return "";

	if (typeof(encodeURIComponent) != "undefined")
		return EncodeUrlComponent55(strUrlComponent);

	return EncodeUrlComponent50(strUrlComponent);
}

function EncodeUrlComponent55(strUrlComponent)
{
	return encodeURIComponent(strUrlComponent);
}

function EncodeUrlComponent50(strUrlComponent)
{
	var i=0;
	var strEncoded = "";
	for (i=0; i < strUrlComponent.length; i++)
		{
		var chr = strUrlComponent.charAt(i);
		var iChr = strUrlComponent.charCodeAt(i);

		if (iChr < 128)
			{
			if ('!' == chr || '\'' == chr || '(' == chr || 	')' == chr || '~' == chr)
				strEncoded += chr;
			else if (0 == iChr)
				strEncoded += "%00";
			else if (127 == iChr)
				strEncoded += "%7F";
			else if ('+' == chr)
				strEncoded += "%2B";
			else if ('/' == chr)
				strEncoded += "%2F";
			else if ('@' == chr)
				strEncoded += "%40";
			else
				strEncoded += escape(chr);
			}
		else if (iChr < 2048)
			{
			strEncoded += "%";
			strEncoded += ( (iChr >> 6) + 192).toString(16).toUpperCase();

			strEncoded += "%";
			strEncoded += ( (iChr & 63) + 128).toString(16).toUpperCase();
			}
		else 
			{
			strEncoded += "%";
			strEncoded += ( (iChr >> 12) + 224).toString(16).toUpperCase();

			strEncoded += "%";
			strEncoded += ( ((iChr >> 6) & 63) + 128).toString(16).toUpperCase();

			strEncoded += "%";
			strEncoded += ( (iChr & 63) + 128).toString(16).toUpperCase();
			}
		}

	return strEncoded;
}

function StrReplaceParam(strUrl, strParam, strNewValue)
{
	var strUpperUrl = strUrl.toUpperCase();
	var strUpperParam = strParam.toUpperCase();

	var iStart = strUpperUrl.indexOf('?' + strUpperParam);
	if (iStart < 0)
		iStart = strUpperUrl.indexOf('&' + strUpperParam);

	if (iStart < 0)
		return strUrl;

	var iEnd = strUpperUrl.indexOf('&', iStart+1);

	if (iEnd < 0)
		iStart--;

	var strRet = strUrl.substring(0, iStart+1);

	if (iEnd >= 0)
		strRet += strUrl.substring(iEnd+1, strUrl.length);

	if (typeof(strNewValue) != 'undefined' &&
		null != strNewValue && strNewValue.length > 0)
		{
		var strSeparator = strRet.indexOf('?') < 0 ? '?' : '&';
		if (strRet.charAt(strRet.length-1) == strSeparator)
			strSeparator=''; 
		strRet += strSeparator + strParam + '=' + strNewValue;
		}

	return strRet;
}

function CheckElementID(strID)
{
	if ('undefined' == typeof(document.getElementById(strID)))
		return false;

	if (null == document.getElementById(strID))
		return false;

	return true;
}

function FeedbackWizCheckIDs()
{
	if (CheckElementID('divFeedbackPanel1') &&
		(CheckElementID('divFeedbackPanel2') || fIsSimpleFeedbackWiz) &&
		(CheckElementID('divFeedbackPanel3') || fIsSimpleFeedbackWiz) &&
		CheckElementID('imgRatingStar1') &&
		CheckElementID('imgRatingStar2') &&
		CheckElementID('imgRatingStar3') &&
		CheckElementID('imgRatingStar4') &&
		CheckElementID('imgRatingStar5') &&
		(CheckElementID('tbFeedbackText') || fIsSimpleFeedbackWiz))
		{
		return true;
		}

	return false;
}

function NavigateIFrameIE(strIFrameId, strLocation)
{
	var ifrmSubmitTarget = frames[strIFrameId];
	if (typeof(ifrmSubmitTarget) != 'undefined' && null != ifrmSubmitTarget)
		ifrmSubmitTarget.location.replace(strLocation);
}

function NavigateIFrameNetscape(strIFrameId, strLocation)
{
	var ifrmSubmitTarget = document.getElementById(strIFrameId);

	if (typeof(ifrmSubmitTarget) != 'undefined' && null != ifrmSubmitTarget)
		{
		if (typeof(ifrmSubmitTarget.contentWindow) != 'undefined')
			ifrmSubmitTarget.contentWindow.location.replace(strLocation); 
		else
			ifrmSubmitTarget.src = strLocation; 
		}
}

function NavigateIFrame(strIFrameId, strLocation)
{
	if (window.navigator.appName.toUpperCase().indexOf("NETSCAPE") >= 0)
		NavigateIFrameNetscape(strIFrameId, strLocation);
	else
		NavigateIFrameIE(strIFrameId, strLocation);
}

function FeedbackWizShowFirstPane()
{
	document.getElementById('divFeedbackPanel1').style.display = 'block';
	document.getElementById('divFeedbackPanel2').style.display = 'none';
	document.getElementById('divFeedbackPanel3').style.display = 'none';
	iFeedbackWizStarRated = 0;
	iRvasap = 0; 
	FeedbackWizMouseOutStar();

	FeedbackWizUpdateCounter();
}

function FeedbackWizShowThankYouPane()
{
	document.getElementById('divFeedbackPanel1').style.display = 'none';
	document.getElementById('divFeedbackPanel2').style.display = 'none';
	document.getElementById('divFeedbackPanel3').style.display = 'block';
}

function FeedbackWizShowPane(iPane, iSubPane)
{
	for (var i=1; i <= 4; i++)
	{
		var strPane = 'divFeedbackPanel' + i;

		if (!CheckElementID(strPane))
			continue;

		if (i != iPane)
		{
			document.getElementById(strPane).style.display = 'none';
			continue;
		}

		document.getElementById(strPane).style.display = 'block';

		if (typeof(iSubPane) == 'undefined')
			continue;

		for (var j=1; j <= 3; j++)
		{
			var strSubPane = strPane + 'Sub' + j;
			if (!CheckElementID(strSubPane))
				continue;

			if (j == iSubPane)
				document.getElementById(strSubPane).style.display = 'block';
			else
				document.getElementById(strSubPane).style.display = 'none';
		}
	}

	if (2 == iPane)
	{
		var tbFeedback = document.getElementById('tbFeedbackText');
		if (null != tbFeedback && typeof(tbFeedback) != 'undefined')
			tbFeedback.focus();
	}

	if (1 == iPane && iSubPane < 0)
		iRvasap = 0; 
}

function FeedbackWizDoSubmit(fChangePanel)
{
	if (typeof(window.navigator) != 'undefined' &&
		typeof(window.navigator.onLine) != 'undefined')
		{
		if (!window.navigator.onLine)
			{
			alert(strYouAreNotOnlineErrMsg);
			return;
			}
		}

	if (!FeedbackWizCheckIDs())
		return;

	if ('undefined' == typeof(strPageAssetId) ||
		null == strPageAssetId ||
		0 >= strPageAssetId.length)
		{
		return;
		}

	if (fChangePanel)
		{
		document.getElementById('divFeedbackPanel1').style.display = 'none';
		document.getElementById('divFeedbackPanel2').style.display = 'block';
		document.getElementById('divFeedbackPanel3').style.display = 'none';
		}

	if (1 != iFeedbackWizStarRated && 2 != iFeedbackWizStarRated &&
		3 != iFeedbackWizStarRated && 4 != iFeedbackWizStarRated &&
		5 != iFeedbackWizStarRated)
		{
		iFeedbackWizStarRated = 0;
		iRvasap = 0; 
		}

	var strAPFeedbackId = "";
	if (1 == iRvasap)
	{
		strAPFeedbackId = GetCookie("apfbkid", ""); 
		if (null != strAPFeedbackId && 36 == strAPFeedbackId.length)
		{
			strAPFeedbackId = "&" + "apfbkid" + "=" + EncodeUrlComponent(strAPFeedbackId);
		}
		else
		{
			strAPFeedbackId = "";
		}

		mSetCookie("apfbkid", ""); 
		iRvasap = 0; 
	}
	else
	{
		iRvasap = 1; 
	}

	var strFeedbackUrl = strFeedbackPageUrl +
		"?rating=" + iFeedbackWizStarRated.toString() +
		strAPFeedbackId +
		'&AssetID=' + strPageAssetId +
		"&AssetVersion=" + strAssetVersion +
		"&" + strPageLoggingParams;

	var strComment = '';
	if (fChangePanel)
		strComment = document.getElementById('tbFeedbackText').value;

	if (typeof(strComment) == 'undefined')
		strComment = '';
	else if (null == strComment)
		strComment = '';

	var iMaxLength = 1024 * 4;

	if (typeof(document.cookie) != undefined && null != document.cookie)
		iMaxLength -= document.cookie.length;

	iMaxLength -= 23; 
	iMaxLength -= 64; 

	strComment = escape(strComment);
	if (iMaxLength <= 0)
		strComment = '';
	else if (strComment.length > iMaxLength)
		strComment = strComment.substring(0, iMaxLength);

	document.cookie = 'feedbackComment=' + strComment + ';path=/';

	var strDelayedCmd = 'FeedbackWizDelayedSubmit("' + strFeedbackUrl + '", ' + (fChangePanel ? 'true' : 'false') + ');';
	window.setTimeout(strDelayedCmd, 100);
}

function FeedbackWizDoSubmitAsst(iRating, fComment)
{
	if (typeof(window.navigator) != 'undefined' &&
		typeof(window.navigator.onLine) != 'undefined')
		{
		if (!window.navigator.onLine)
			{
			alert(strYouAreNotOnlineErrMsg);
			return;
			}
		}

	if ('undefined' == typeof(strPageAssetId) ||
		null == strPageAssetId ||
		0 >= strPageAssetId.length)
		{
		return;
		}

	if (!CheckElementID('divFeedbackPanel1') ||
		!CheckElementID('divFeedbackPanel2') ||
		!CheckElementID('divFeedbackPanel3') ||
		!CheckElementID('divFeedbackPanel4'))
	{
		return;
	}

	if (iRating < 0)
		iRating = iFeedbackWizStarRated;
	else
	{
		iFeedbackWizStarRated = iRating;
		iRvasap = 0; 
	}

	var strAPFeedbackId = "";
	if (1 == iRvasap)
	{
		strAPFeedbackId = GetCookie("apfbkid", ""); 
		if (null != strAPFeedbackId && 36 == strAPFeedbackId.length)
		{
			strAPFeedbackId = "&" + "apfbkid" + "=" + EncodeUrlComponent(strAPFeedbackId);
		}
		else
		{
			strAPFeedbackId = "";
		}

		mSetCookie("apfbkid", ""); 
		iRvasap = 0; 
	}
	else
	{
		iRvasap = 1; 
	}

	var strFeedbackUrl = strFeedbackPageUrl +
		"?rating=" + iRating.toString() +
		strAPFeedbackId +
		'&AssetID=' + strPageAssetId +
		"&AssetVersion=" + strAssetVersion +
		"&" + strPageLoggingParams;

	var strComment = '';
	if (fComment)
	{
		strComment = document.getElementById('tbFeedbackText').value;

		if (typeof(strComment) == 'undefined')
			strComment = '';
		else if (null == strComment)
			strComment = '';

		strComment = escape(strComment);
		if (strComment.length > 1024 * 4)
			strComment = strComment.substring(0, 1024 * 4);
	}

	if (strComment.length > 0)
		document.cookie = 'feedbackComment=' + strComment + ';path=/';

	var iSubPanel = 3; 
	if (5 == iRating)
		iSubPanel = 1; 
	else if (1 == iRating)
		iSubPanel = 2; 

	var strDelayedCmd =
		'FeedbackWizDelayedSubmitAsst("' +
			strFeedbackUrl + '", ' +
			(fComment ? '4' : '2') + ', ' +
			iSubPanel + ');';

	window.setTimeout(strDelayedCmd, 100);

	if (fComment)
		FeedbackWizShowPane(3, -1);

	if (1 == iRating || 5 == iRating || 3 == iRating)
	{
		var taTextArea = document.getElementById("tbFeedbackText");
		if (typeof(taTextArea) == "undefined" ||
			null == taTextArea ||
			typeof(taTextArea.title) == "undefined")
		{
			return;
		}

		var strSpan = "";

		if (5 == iRating)
			strSpan = "divFeedbackPanel2Sub1";
		else if (1 == iRating)
			strSpan = "divFeedbackPanel2Sub2";
		else
			strSpan = "divFeedbackPanel2Sub3";

		var divLabel = document.getElementById(strSpan);
		if (typeof(divLabel) == "undefined" ||
			null == divLabel ||
			typeof(divLabel.innerHTML) == "undefined" ||
			null == divLabel.innerHTML)
		{
			return;
		}

		taTextArea.title = divLabel.innerHTML;
	}
}

function FeedbackWizDelayedSubmitAsst(strFeedbackUrl, iPanel, iSubPanel)
{
	var fWasOK = true;
	try
	{
		NavigateIFrame('submitTarget', strFeedbackUrl);
	}
	catch (e)
	{
		fWasOK = false;
		alert(strCannotSubmitFeedbackErrmsg);
		FeedbackWizShowPane(1, -1);
	}

	if (true == fWasOK)
	{
		if (0 != iPanel)
		{
			if (4 == iPanel)
				window.setTimeout('FeedbackWizShowPane(' + iPanel + ', ' + iSubPanel + ');', 1200);
			else
				FeedbackWizShowPane(iPanel, iSubPanel);
		}
	}
	else
	{
		FeedbackWizShowPane(1, -1);
	}
}

function FeedbackWizDelayedSubmit(strFeedbackUrl, fChangePanel)
{
	var fWasOK = true;
	try
		{
		NavigateIFrame('submitTarget', strFeedbackUrl);
		}
	catch (e)
		{
		fWasOK = false;
		alert(strCannotSubmitFeedbackErrmsg);
		FeedbackWizShowFirstPane();
		}

	if (true == fWasOK)
		{
		if (fChangePanel)
			window.setTimeout('FeedbackWizShowThankYouPane();', 1200);
		}
	else
		{
		FeedbackWizShowFirstPane();
		}
}

function FeedbackWizGenerateFXHeader()
{
	document.write('<DIV>&nbsp;</DIV>');
	document.write('<DIV CLASS="OLn">&nbsp;</DIV>\n');
}

function RgFeedbackWizGetImages()
{
	var imgs = new Array(5);
	imgs[0] = document.getElementById("imgRatingStar1");
	imgs[1] = document.getElementById("imgRatingStar2");
	imgs[2] = document.getElementById("imgRatingStar3");
	imgs[3] = document.getElementById("imgRatingStar4");
	imgs[4] = document.getElementById("imgRatingStar5");
	return imgs;
}

function FeedbackWizUpdateCounter()
{
	goDisplayCount(650, 'tbFeedbackText', 'spnFeedbackCounter', 'btnFeedbackWizSubmit');
}

function FeedbackWizUpdateCounterDelay()
{
	if (typeof(window) != 'undefined' && null != window)
		window.setTimeout("FeedbackWizUpdateCounter()", 25);
}

function FeedbackWizMouseOverStar(iStar)
{
	if (!FeedbackWizCheckIDs())
		return;

	var imgs = RgFeedbackWizGetImages();

	for (var i=0; i < imgs.length; i++)
		if (fFeedbackWizJustRated)
			{
			if (iStar > i)
				imgs[i].src = "/global/images/ratings/lg_output_full.gif";
			else
				imgs[i].src = "/global/images/ratings/lg_output_empty.gif";
			}
		else
			{
			if (iStar > i)
				imgs[i].src = "/global/images/ratings/lg_input_full.gif";
			else
				imgs[i].src = "/global/images/ratings/lg_output_empty.gif";
			}
}

function FeedbackWizMouseOutStar()
{
	if (!FeedbackWizCheckIDs())
		return;

	fFeedbackWizJustRated = false;
	var imgs = RgFeedbackWizGetImages();

	for (var i=0; i < imgs.length; i++)
		{
		if (iFeedbackWizStarRated < 1 || iFeedbackWizStarRated > 5)
			{
			imgs[i].src = "/global/images/ratings/lg_output_empty.gif";
			}
		else
			{
			if (iFeedbackWizStarRated > i)
				imgs[i].src = "/global/images/ratings/lg_output_full.gif";
			else
				imgs[i].src = "/global/images/ratings/lg_output_empty.gif";
			}
		}
}

function CommentOnThisTemplate()
{
	var strNewUrl = strCommentOnThisTemplateLnk;

	var strAPFeedbackId = GetCookie("apfbkid", ""); 
	if (null != strAPFeedbackId && 36 == strAPFeedbackId.length)
		strNewUrl += "&" + "apfbkid" + "=" + EncodeUrlComponent(strAPFeedbackId);

	mSetCookie("apfbkid", ""); 

	location.href = strNewUrl;
}

function FeedbackWizStarClicked(iStar)
{
	if (!FeedbackWizCheckIDs())
		return;

	if (iFeedbackWizStarRated == iStar)
		return;

	iFeedbackWizStarRated = iStar;
	fFeedbackWizJustRated = true;
	iRvasap = 0; 

	FeedbackWizUpdateCounter();

	var imgs = RgFeedbackWizGetImages();
	for (var i=0; i < imgs.length; i++)
		{
		if (i == iStar-1)
			{
			imgs[i].style.cursor = "default";
			imgs[i].alt = rgStrYouRated[i];
			}
		else
			{
			imgs[i].style.cursor = "hand";
			imgs[i].alt = rgStrClickToRate[i];
			}

		if (iStar > i)
			imgs[i].src = "/global/images/ratings/lg_output_full.gif";
		else
			imgs[i].src = "/global/images/ratings/lg_output_empty.gif";
		}

	FeedbackWizDoSubmit(false);

	if (fIsSimpleFeedbackWiz)
		strCommentOnThisTemplateLnk = StrReplaceParam(strCommentOnThisTemplateLnk, "Rating", iStar.toString());

	for (var i=1; i <= 3; i++)
		{
		var divSub = document.getElementById("divFeedbackPanel2Sub" + i.toString());
		if (typeof(divSub) != "undefined" && null != divSub)
			divSub.style.display = "block";
		}
}

function FeedbackWizGenerateControl(
	strLabel1a, strLabel1b, strLabel1c, 
	strLabel2, 
	strLabel3, strLabel3Text,
	strLnkContactUsLink, strContactUsText, strContactUsUrl,
	strSubmit,
	strChangeMyFeedback,
	strFeedbackWizWidth,
	fShow1a,
	fShow1b,
	fShow1c,
	fAsstParam, strNotHelpful, strVeryHelpful)
{
	mSetCookie("apfbkid", ""); 

	var fAsst = false;
	var iDivHeight = 151;
	if (typeof(fAsstParam) != 'undefined' && fAsstParam)
		{
		fAsst = true;
		iDivHeight = 166;
		}

	var strLnkContactUsCellText = strLnkContactUsLink.replace('{0}',
		'<A CLASS="OAnc" HREF="javascript:OpenInNewWindow(\'' + strContactUsUrl +
		'\')">' + strContactUsText + '</A>');

	strSubmit = strSubmit.replace("\'", "&apos;");
	strSubmit = strSubmit.replace('\"', '&quot;');

	if (fAsst && '100%' == strFeedbackWizWidth)
		document.write('<BR>');

	document.write('<TABLE CLASS="FeedbackControlMainTable OTbl" CELLPADDING="0" ' +
		'CELLSPACING="0" BORDER="0" WIDTH="' + strFeedbackWizWidth + '"><TR>' +
		'<TD CLASS="FeedbackControl" WIDTH="' + strFeedbackWizWidth + '" ' +
		'STYLE="border-bottom: 0px;">');

	if (fIsSimpleFeedbackWiz)
		{
		document.write('<DIV ID="divFeedbackPanel1" ALIGN="left" STYLE="display: block;">');
		document.write('	<TABLE BORDER="0" CELLPADDING="0" CELLSPACING="0" WIDTH="100%" CLASS="OTbl">');
		}
	else
		{
		document.write('<DIV ID="divFeedbackPanel1" ALIGN="left" STYLE="display: block;">');
		document.write('	<TABLE BORDER="0" CELLPADDING="0" CELLSPACING="0" WIDTH="100%" CLASS="OTbl" HEIGHT="' + iDivHeight + '">');

		if (fShow1a)
			{
			document.write('	<TR>');
			document.write('		<TD STYLE="font-weight: bold;">');
			document.write('			<SPAN CLASS="OLbl">' + strLabel1a + '</SPAN>');
			document.write('		</TD>');
			document.write('	</TR>');
			}
		}

	document.write('		<TR>');

	if (fIsOn2Lines)
		document.write('		<TD NOWRAP="true">');
	else if (fIsSimpleFeedbackWiz)
		document.write('		<TD>');
	else if (fAsst)
		document.write('		<TD STYLE="padding-top: 3px; padding-bottom: 5px;">');
	else
		document.write('		<TD STYLE="padding-top: 8px;">');

	if (fShow1b)
		document.write('				<SPAN CLASS="OLbl" NOWRAP="true">' + strLabel1b + '</SPAN>');

	if (!fIsOn2Lines)
		{
		document.write('			</TD>');
		document.write('		</TR>');
		document.write('		<TR>');
		document.write('			<TD STYLE="padding-top: 4px;" NOWRAP="true">');
		}
	else
		document.write(' ');

	if (fAsst)
		{
		document.write('<TABLE CLASS="OTbl" BORDER="0" CELLPADDING="0" CELLSPACING="0" WIDTH="100%"><TR>');
		document.write('<TD VALIGN="middle">' + strNotHelpful + '</TD>');
		document.write('<TD VALIGN="middle" STYLE="padding: 0.5em 12px 0.5em 12px;" NOWRAP="true">');
		}

	for (var i=1; i <= 5; i++)
		{
		document.write(				'<A BORDER="0" ID="lnkRatingStar' + i + '" ');
		document.write(					'HREF="javascript:FeedbackWizStarClicked(' + i + ')" ');
		document.write(					'ONMOUSEOVER="javascript:FeedbackWizMouseOverStar(' + i + ')" ');
		document.write(					'ONMOUSEOUT="javascript:FeedbackWizMouseOutStar()">');
		document.write(				'<IMG BORDER="0" ID="imgRatingStar' + i + '" NAME="imgRatingStar' + i + '" ');
		document.write(					'SRC="' + "/global/images/ratings/lg_output_empty.gif" + '" ');
		document.write(					'STYLE="cursor:hand;" ');
		document.write(					'ALT="' + rgStrClickToRate[i-1] + '">');
		document.write(				'</A>');
		}

	if (fAsst)
		{
		document.write('</TD>');
		document.write('<TD VALIGN="middle">' + strVeryHelpful + '</TD>');
		document.write('<TD WIDTH="100%">&nbsp;</TD>');
		document.write('</TR></TABLE>');
		}

	document.write('			</TD>');
	document.write('		</TR>');

	if (fIsSimpleFeedbackWiz)
		{
		if (fShow1c)
			{
			document.write('		<TR>');
			document.write('			<TD STYLE="padding-top: 4px;" NOWRAP="true">' + strLabel1c + '</TD>');
			document.write('		</TR>');
			}
		}
	else
		{
		if (fShow1c)
			{
			document.write('		<TR>');
			document.write('			<TD STYLE="padding-top: 8px;">');

			if (fAsst)
				document.write('<DIV ID="divFeedbackPanel2Sub1" STYLE="display: none;">');

			document.write('				<SPAN CLASS="OLbl">' + strLabel1c + '</SPAN>');

			if (fAsst)
				document.write('</DIV>');

			document.write('			</TD>');
			document.write('		</TR>');
			}
		document.write('		<TR>');
		document.write('			<TD>');

		if (fAsst)
			document.write('<DIV ID="divFeedbackPanel2Sub2" STYLE="display: none;">');

		document.write('				<TEXTAREA CLASS="OTBM" ROWS="3" COLS="36" ID="tbFeedbackText" STYLE="width:100%;" ');
		document.write('					TITLE="' + strLabel1c.replace('\"', '&quot;') + '"');
		document.write('					ONFOCUS="FeedbackWizUpdateCounter();" ');
		document.write('					ONCHANGE="FeedbackWizUpdateCounter();" ');
		document.write('					ONPASTE="FeedbackWizUpdateCounterDelay();" ');
		document.write('					ONKEYUP="FeedbackWizUpdateCounter();">');
		document.write(					'</TEXTAREA>');

		if (fAsst)
			document.write('</DIV>');

		document.write('			</TD>');
		document.write('		</TR>');
		document.write('		<TR>');
		document.write('			<TD STYLE="padding-top: 2px;">');

		if (fAsst)
			document.write('<DIV ID="divFeedbackPanel2Sub3" STYLE="display: none;">');

		document.write('				<TABLE CLASS="OTbl" BORDER="0" CELLPADDING="0" CELLSPACING="0">');
		document.write('					<TR><TD WIDTH="100%"><SPAN ID="spnFeedbackCounter"></SPAN></TD>');
		document.write('					<TD CLASS="FeedbackWizButtonCell">');
		document.write('					<INPUT CLASS="OBtn FeedbackWizButton" TYPE="button" ID="btnFeedbackWizSubmit" ');
		document.write(							'VALUE="' + strSubmit + '" ONCLICK="FeedbackWizDoSubmit(true);"/>');
		document.write('					</TD></TR>');
		document.write('				</TABLE>');

		if (fAsst)
			document.write('</DIV>');

		document.write('			</TD>');
		document.write('		</TR>');
		}

	document.write('		<TR>');
	document.write('			<TD HEIGHT="100%"/>');
	document.write('		</TR>');
	document.write('	</TABLE>');
	document.write('</DIV>');

	if (!fIsSimpleFeedbackWiz)
		{

		document.write('<DIV ID="divFeedbackPanel2" STYLE="display:none;" ALIGN="left">');
		document.write('	<TABLE WIDTH="100%" BORDER="0" CELLPADDING="0" CELLSPACING="0" CLASS="OTbl" HEIGHT="' + iDivHeight + '">');
		document.write('		<TR>');
		document.write('			<TD STYLE="font-weight: bold;">');
		document.write('				<SPAN CLASS="OLbl">' + strLabel2 + '</SPAN>');
		document.write('			</TD>');
		document.write('		</TR>');
		document.write('		<TR>');
		document.write('			<TD HEIGHT="100%"/>');
		document.write('		</TR>');
		document.write('	</TABLE>');
		document.write('</DIV>');

		document.write('<DIV ID="divFeedbackPanel3" STYLE="display:none;" ALIGN="left">');
		document.write('	<TABLE WIDTH="100%" BORDER="0" CELLPADDING="0" CELLSPACING="0" CLASS="OTbl" HEIGHT="' + iDivHeight + '">');
		document.write('		<TR>');
		document.write('			<TD STYLE="font-weight: bold;">');
		document.write('				<SPAN CLASS="OLbl">' + strLabel3 + '</SPAN>');
		document.write('			</TD>');
		document.write('		</TR>');
		document.write('		<TR>');
		document.write('			<TD>');
		document.write('				<SPAN><A HREF="javascript:FeedbackWizShowFirstPane()" CLASS="OAnc">' + strChangeMyFeedback + '</A></SPAN>');
		document.write('			</TD>');
		document.write('		</TR>');
		document.write('		<TR>');
		document.write('			<TD STYLE="padding-top: 8px;">');
		document.write('				<SPAN>' + strLabel3Text + '</SPAN>');
		document.write('			</TD>');
		document.write('		</TR>');

		document.write('		<TR><TD HEIGHT="6"><SPAN/></TD></TR>');

		document.write('		<TR>');
		document.write('			<TD WIDTH="100%">');
		document.write(					strLnkContactUsCellText);
		document.write('			</TD>');
		document.write('		</TR>');

		document.write('		<TR>');
		document.write('			<TD HEIGHT="100%"/>');
		document.write('		</TR>');
		document.write('	</TABLE>');
		document.write('</DIV>');
		}

	document.write('</TD></TR></TABLE>');

	var img0 = new Image();
	img0.src = "/global/images/ratings/lg_output_full.gif";

	var img1 = new Image();
	img1.src = "/global/images/ratings/lg_output_empty.gif";

	var img2 = new Image();
	img2.src = "/global/images/ratings/lg_input_full.gif";

	FeedbackWizUpdateCounter();
}

function FeedbackWizGenerateControl_Buttons(
	strP1Question, strP1Yes, strP1No, strP1DontKnow, 
	strP2QYes, strP2QNo, strP2QDontKnow, 
	strP2Back, strP2Submit, 
	strP3Label, 
	strP4Label,
	strP4ContactUsLine, strP4ContactUsText, strP4ContactUsUrl,
	strP4ChangeMyFeedback, strP4ThankYou,
	strFeedbackWizWidth)
{
	mSetCookie("apfbkid", ""); 

	var strP4ContactUsCellText = strP4ContactUsLine.replace('{0}',
		'<A CLASS="OAnc" HREF="javascript:OpenInNewWindow(\'' + strP4ContactUsUrl +
		'\')">' + strP4ContactUsText + '</A>');

	if ('100%' == strFeedbackWizWidth)
		document.write('<BR>');

	document.write('<TABLE CLASS="FeedbackControlMainTable OTbl" CELLPADDING="0" ' +
		'CELLSPACING="0" BORDER="0" WIDTH="' + strFeedbackWizWidth + '"><TR>' +
		'<TD CLASS="FeedbackControl" WIDTH="' + strFeedbackWizWidth + '" ' +
		'STYLE="border-bottom: 0px;">');

	document.write('<DIV ID="divFeedbackPanel1" ALIGN="left" STYLE="display: block;">');
	document.write('<TABLE VALIGN="top" BORDER="0" CELLPADDING="0" CELLSPACING="0" WIDTH="100%" CLASS="OTbl" HEIGHT="' + 106 + '">');
	document.write('	<TR>');
	document.write('		<TD VALIGN="top" STYLE="font-weight: bold; height: 1em;">');
	document.write('			<SPAN CLASS="OLbl">' + strP1Question + '</SPAN>');
	document.write('		</TD>');
	document.write('	</TR>');
	document.write('	<TR>');
	document.write('		<TD VALIGN="top" STYLE="padding-top: 4px;" NOWRAP="true">');
	document.write('			<INPUT TYPE="button" CLASS="OBtn FeedbackWizButton" value="' + strP1Yes + '" ONCLICK="javascript:FeedbackWizDoSubmitAsst(5, false);"/>&nbsp;&nbsp;');
	document.write(				'<INPUT TYPE="button" CLASS="OBtn FeedbackWizButton" value="' + strP1No + '" ONCLICK="javascript:FeedbackWizDoSubmitAsst(1, false);"/>');

	if (strP1DontKnow.length > 0)
		document.write('&nbsp;&nbsp;<INPUT TYPE="button" CLASS="OBtn FeedbackWizButtonBig" value="' + strP1DontKnow + '" ONCLICK="javascript:FeedbackWizDoSubmitAsst(3, false);"/>');

	document.write('		</TD>');
	document.write('	</TR>');
	document.write('	<TR><TD>&nbsp;</TD></TR>');
	document.write('</TABLE>');
	document.write('</DIV>');

	document.write('<DIV ID="divFeedbackPanel2" ALIGN="left" STYLE="display: none;">');
	document.write('<TABLE BORDER="0" CELLPADDING="0" CELLSPACING="0" WIDTH="100%" CLASS="OTbl" HEIGHT="' + 106 + '">');
	document.write('	<TR>');
	document.write('		<TD VALIGN="top" STYLE="font-weight: bold; height: 1em;">');
	document.write('			<SPAN CLASS="OLbl" STYLE="display: none;" ID="divFeedbackPanel2Sub1">' + strP2QYes + '</SPAN>');
	document.write('			<SPAN CLASS="OLbl" STYLE="display: none;" ID="divFeedbackPanel2Sub2">' + strP2QNo + '</SPAN>');
	document.write('			<SPAN CLASS="OLbl" STYLE="display: block;" ID="divFeedbackPanel2Sub3">' + strP2QDontKnow + '</SPAN>');
	document.write('		</TD>');
	document.write('	</TR>');
	document.write('	<TR>');
	document.write('		<TD VALIGN="top" STYLE="height: 4em;">');
	document.write('			<TEXTAREA CLASS="OTBM" ROWS="3" COLS="36" ID="tbFeedbackText" STYLE="width:100%;" ');
	document.write('				TITLE="' + strP1Question.replace('\"', '&quot;') + '"');
	document.write('				ONFOCUS="FeedbackWizUpdateCounter();" ');
	document.write('				ONCHANGE="FeedbackWizUpdateCounter();" ');
	document.write('				ONPASTE="FeedbackWizUpdateCounterDelay();" ');
	document.write('				ONKEYUP="FeedbackWizUpdateCounter();">');
	document.write(				'</TEXTAREA>');
	document.write('		</TD>');
	document.write('	</TR>');
	document.write('	<TR>');
	document.write('		<TD VALIGN="top" STYLE="padding-top: 2px;">');
	document.write('			<TABLE VALIGN="top" CLASS="OTbl" BORDER="0" CELLPADDING="0" CELLSPACING="0">');
	document.write('				<TR>');
	document.write('					<TD VALIGN="top" WIDTH="100%"><SPAN ID="spnFeedbackCounter"></SPAN></TD>');
	document.write('					<TD VALIGN="top" NOWRAP="true">');
	document.write('						<INPUT CLASS="OBtn FeedbackWizButton" TYPE="button" ID="btnFeedbackWizBack" ');
	document.write(								'VALUE="' + strP2Back + '" ONCLICK="javascript:FeedbackWizShowPane(1, -1);"/>&nbsp;');
	document.write('						<INPUT CLASS="OBtn FeedbackWizButton" TYPE="button" ID="btnFeedbackWizSubmit" ');
	document.write(								'VALUE="' + strP2Submit + '" ONCLICK="FeedbackWizDoSubmitAsst(-1, true);"/>');
	document.write('					</TD>');
	document.write('				</TR>');
	document.write('			</TABLE>');
	document.write('		</TD>');
	document.write('	</TR>');
	document.write('</TABLE>');
	document.write('</DIV>');

	document.write('<DIV ID="divFeedbackPanel3" STYLE="display: none;" ALIGN="left">');
	document.write('<TABLE WIDTH="100%" BORDER="0" CELLPADDING="0" CELLSPACING="0" CLASS="OTbl" HEIGHT="' + 106 + '">');
	document.write('	<TR>');
	document.write('		<TD VALIGN="top" STYLE="font-weight: bold;">');
	document.write('			<SPAN CLASS="OLbl">' + strP3Label + '</SPAN>');
	document.write('		</TD>');
	document.write('	</TR>');
	document.write('</TABLE>');
	document.write('</DIV>');

	document.write('<DIV ID="divFeedbackPanel4" STYLE="display: none;" ALIGN="left">');
	document.write('<TABLE WIDTH="100%" BORDER="0" CELLPADDING="0" CELLSPACING="0" CLASS="OTbl" HEIGHT="' + 106 + '">');
	document.write('	<TR>');
	document.write('		<TD VALIGN="top" STYLE="font-weight: bold;">');
	document.write('			<SPAN CLASS="OLbl">' + strP4Label + '</SPAN>');
	document.write('		</TD>');
	document.write('	</TR>');
	document.write('	<TR>');
	document.write('		<TD>');
	document.write('			<SPAN><A HREF="javascript:FeedbackWizShowPane(1, -1);" CLASS="OAnc">' + strP4ChangeMyFeedback + '</A></SPAN>');
	document.write('		</TD>');
	document.write('	</TR>');
	document.write('	<TR>');
	document.write('		<TD STYLE="padding-top: 8px;">');
	document.write('			<SPAN>' + strP4ThankYou + '</SPAN>');
	document.write('		</TD>');
	document.write('	</TR>');
	document.write('	<TR><TD HEIGHT="6"><SPAN/></TD></TR>');
	document.write('	<TR>');
	document.write('		<TD WIDTH="100%">');
	document.write(				strP4ContactUsCellText);
	document.write('		</TD>');
	document.write('	</TR>');
	document.write('	<TR>');
	document.write('		<TD HEIGHT="100%"/>');
	document.write('	</TR>');
	document.write('</TABLE>');
	document.write('</DIV>');

	document.write('</TD></TR></TABLE>');

}

function GetCookie(tName, DefaultReturn)
{
	if ("undefined" == typeof(DefaultReturn))
		DefaultReturn = "";

	var tArg = tName + "=";
	var nArgLen = tArg.length;
	var nCookieLen = document.cookie.length;
	var nStartPos = 0;

	while (nStartPos < nCookieLen)
		{
		var nEndPos = nStartPos + nArgLen;

		if (document.cookie.substring(nStartPos, nEndPos) == tArg)
			{
			var n2EndPos = document.cookie.indexOf(";", nEndPos);
			if (n2EndPos == -1)
				{
				n2EndPos = document.cookie.length;
				}
			return unescape(document.cookie.substring(nEndPos, n2EndPos));
			}

		nStartPos = document.cookie.indexOf(" ", nStartPos) + 1;
		if (nStartPos == 0)
			break;
		}

	return DefaultReturn;
}

function SetPersistentCookie(szName, szValue)
{
	var dateNow = new Date();
	var dateExpire = new Date();
	dateExpire.setTime(dateNow.getTime() + 1000 * 60 * 60 * 24 * 365);
	mSetCookie(szName, szValue, false, dateExpire);

	return;
}

function FIsVariableInCookie(szName, DefaultValue)
{
	if ("undefined" == typeof(DefaultValue))
		DefaultValue = "";

	return (DefaultValue != GetCookie(szName, DefaultValue));
}

function mSetCookie(tName, vValue)
{
	var aArgs = mSetCookie.arguments;
	var nArgs = mSetCookie.arguments.length;
	var bAppendToCurrentCookie = (nArgs > 2) ? aArgs[2] : false;
	var expires = (nArgs > 3) ? aArgs[3] : null;
	var path = (nArgs > 4) ? aArgs[4] : "/";
	var domain = (nArgs > 5) ? aArgs[5] : null;
	var secure = (nArgs > 6) ? aArgs[6] : false;

	if (bAppendToCurrentCookie && "" != GetCookie(tName))
		vValue = GetCookie(tName) + "," + vValue;

	document.cookie = tName + "=" + vValue +
		((expires == null) ? "" : ("; expires=" + expires.toGMTString())) +
		((path == null) ? "" : ("; path=" + path)) +
		((domain == null) ? "" : ("; domain=" + domain)) +
		((secure == true) ? "; secure" : "");

	return;
}

function mGetCookie(tName)
{
	return GetCookie(tName, "na");
}

function mDeleteCookie(tName) {
		var exp = new Date();
		exp.setDate (exp.getDate() -10);
		mSetCookie(tName, "", false, exp);
}

function SzGetArgumentValue(strQueryName)
{
	var iStart;
	var iEnd;
	var strQueryUpper = unescape(location.search.toUpperCase());
	var strQuery = "&" + strQueryName.toUpperCase() + "=";

	iStart = strQueryUpper.indexOf(strQuery);

	if (-1 == iStart)
		{
		strQuery = "?" + strQueryName.toUpperCase() + "=";
		iStart = strQueryUpper.indexOf(strQuery);
		}

	if (-1 == iStart)
		return null;

	iStart += strQuery.length;
	iEnd = strQueryUpper.indexOf("&", iStart);

	if (-1 == iEnd)
		iEnd = strQueryUpper.indexOf("?", iStart);
	if (-1 == iEnd)
		iEnd = strQueryUpper.length;

	return unescape(location.search).substring(iStart, iEnd);
}

function Rollover(normal, high, ratedOn, ratedOff)
{
	this.normal = new Image();
	this.normal.src = normal;
	this.high = new Image();
	this.high.src = high;
	this.ratedOn = new Image();
	this.ratedOn.src = ratedOn;
	this.ratedOff = new Image();
	this.ratedOff.src = ratedOff;
}

function GetName(imgName)
{
	var pos = imgName.lastIndexOf("_Image");
	var baseName = imgName.substring(0, pos) + "_Image";
	return baseName;
}

function GetIndex(imgName)
{
	var pos = imgName.lastIndexOf("_Image");
	var num = imgName.substring(pos+6, imgName.length);
	return num;
}

function DoMouseOver(img, star)
{
	var prefixName = GetName(img.name);
	var imgNumber = new Number(GetIndex(img.name));
	for (var i = 1; i <= imgNumber; i++)
		{
		document.images[prefixName+i].src = star.high.src;
		}
}

function DoMouseOut(img, maxRating, star)
{
	var prefixName = GetName(img.name);
	for (var i = 1; i <= maxRating; i++)
		{
		document.images[prefixName+i].src = star.normal.src;
		}
}

function DoRating(controlName, rating)
{
	var strAssetIdParam = strAssetId;
	if (typeof(strAssetIdParam) != 'undefined' && null != strAssetIdParam && strAssetIdParam.length > 0)
		strAssetIdParam = '&AssetID=' + strAssetIdParam;
	else
		strAssetIdParam = '';

	var strNewLocation = strRatingPage + '?Rating=' + rating + strAssetIdParam + '&RatingType='
		+ strRatingType + '&AssetVersion=' + strAssetVersion + '&Overwrite=' + strOverwrite
		+ '&' + strLogging;

	NavigateIFrame('submitTarget', strNewLocation);

	ChangeRatingElements(controlName, rating);

	return;
}

function ResetRatings(controlName)
{
	document.getElementById('sectionStarsBeforeRating').style.display = '';
	document.getElementById('sectionStarsAfterRating').style.display = 'none';
	document.getElementById('spanBeforeRating').style.display = '';
	document.getElementById('spanAfterRating').style.display = 'none';

	if (fShowFeedback == true)
		{
		document.getElementById('divFeedbackLink').style.display = 'none';
		}

	for (i = 1; i <= 5; i++)
		{
		document.images['Before' + controlName + '_Image' + i].src = ctlRating_Star.normal.src;
		document.images[controlName + '_Image' + i].src = ctlRating_Star.ratedOff.src;
		}
}

function ChangeRatingElements(controlName, rating)
{
	document.getElementById('sectionStarsBeforeRating').style.display = 'none';
	document.getElementById('sectionStarsAfterRating').style.display = '';
	document.getElementById('spanBeforeRating').style.display = 'none';
	document.getElementById('spanAfterRating').style.display = '';
	if (fShowFeedback == true)
		{
		document.getElementById('divFeedbackLink').style.display = '';
		document.getElementById('ctlRating_Feedback').href = strFeedbackLink + rating;
		}

	for (i = 1; i <= rating; i++)
		{
		document.images[controlName + '_Image' + i].src = ctlRating_Star.ratedOn.src;
		}
}

var m_wndwProgress = null;
var m_Downloading = false;

function StrDisplayTitle()
{
	if ("undefined" == typeof(m_strDisplayTitle))
		return "?";

	return m_strDisplayTitle;
}

function StrDownloadDetails()
	{
	if ("undefined" == typeof(m_strDownloadDetails))
		return "";

	return (null == m_strDownloadDetails ? "" : m_strDownloadDetails);
	}

function FIsDownloading()
	{
	if ("undefined" == typeof(m_Downloading))
		return false;

	return m_Downloading;
	}

function OpenProgressWindow()
	{
	m_Downloading = true;
	m_wndwProgress = window.open("/templates/progress.aspx", "idProgressWindow", "height=134,width=294");
	if (null != m_wndwProgress)
		m_wndwProgress.focus();

	return;
	}

function CloseProgressWindow()
	{
	m_Downloading = false;

	if (null != m_wndwProgress && !m_wndwProgress.closed && "undefined" != typeof(m_wndwProgress.Finish))
		m_wndwProgress.Finish();

	return;
	}

function OnProgress(iProgress, iGoal)
	{
	if (null != m_wndwProgress && "undefined" != typeof(m_wndwProgress) && "undefined" != typeof(m_wndwProgress.DoProgress))
		return m_wndwProgress.DoProgress(iProgress, iGoal);

	return true;
	}

function GotoDirectDownloadURLTemplates(iResult)
{
	var strLocation;

	strLocation  = "/templates/directdownload.aspx?AssetID=" + m_strAsset +
		"&Application=" + m_strApp +
		"&Result=" + iResult +
		"&Version=" + m_iVersion;

	if ("undefined" != typeof(m_strQuery) && 0 != m_strQuery.length)
		strLocation += "&QueryID=" + m_strQuery;

	window.location.href = strLocation;

    	return;
}

function OnComplete(iResult)
{

	CloseProgressWindow();

	if (fInstallingActiveX)
		return;

	if (1 == iResult && !fSupportsActiveX)
		iResult = 2;

	if (0 != iResult && 18 != iResult)
		GotoDirectDownloadURLTemplates(iResult);

	return;
}

function FCheckOfficeRestriction(iRes)
{
	if (typeof(iRes) == 'undefined' || !(iRes >= 0 && iRes <= 6))
		return false;

	var strRes = StrGetOfficeRestrictionsCookie();

	if (typeof(strRes) == 'undefined' || null == strRes || iRes >= strRes.length)
		return false;

	return '1' == strRes.charAt(iRes);
}

function RedirectIfOfficeRestriction(iRes)
{
	if (!FCheckOfficeRestriction(iRes))
		return false;

	var strSite = "";
	var strResult = "";

	if (0 == iRes) 
		{
		strResult = "20"; 
		}
	else if (1 == iRes) 
		{
		strSite = "TC";
		strResult = "21"; 
		}
	else if (2 == iRes) 
		{
		strSite = "RC";
		strResult = "22"; 
		}
	else if (3 == iRes) 
		{
		strSite = "TC";
		strResult = "23"; 
		}
	else if (5 == iRes) 
		{
		strResult = "25"; 
		}
	else if (6 == iRes) 
		{
		strResult = "26"; 
		}
	else
		{
		return false;
		}

	var strNewHREF = "/templates/directdownload.aspx?result=" + strResult;
	if (null != strSite && strSite.length > 0)
	{
		strNewHREF += "&site=";
		strNewHREF += strSite;
	}

	window.location.href = strNewHREF;

	return true;
}

function StartEditTemplate(fIsCSC)
{
	if (RedirectIfOfficeRestriction(1))
		return;

	if (fIsCSC && RedirectIfOfficeRestriction(3))
		return;

	var rgstrApp;

	if (null != m_strApp)
		{
		rgstrApp = m_strApp.split(",");
		for (var i=0; i < rgstrApp.length; i++)
			{
			m_strApp = StrTrim(rgstrApp[i]);
			if (null != m_strApp && m_strApp.length > 0)
				break;

			m_strApp = null;
			}
		}

	if (null == m_strApp)
		{
		OnComplete(5); 
		return;
		}

	if (m_strApp == "IP")
		{
		m_strApp == "XD";
		}

	if (("undefined" != typeof(m_fAcceptedTOU) && !m_fAcceptedTOU) ||
		("undefined" == typeof(m_fAcceptedTOU) && 0 != m_strTouUrl.length))
		{

		mSetCookie("AWS_CheckingEULA_Sess", "1");
		window.location.href = m_strTouUrl;
		return;
		}

	if(!InstallActiveX())
		{
		if (FIsSupportedWindows())
			OnComplete(1); 
		else
			OnComplete(14); 

		return;
		}

	if (fIsCSC && !FActiveXSupportsStartEditEx())
		{

		OnComplete(2); 
		return;
		}

	var fJustInstalledAX = FIsVariableInCookie("AWS_DontPrompt_Sess");

	if(!fJustInstalledAX)
		OpenProgressWindow();

	if (null == m_strAsset)
		m_strAsset = "";

	var iResult = FActiveXSupportsStartEditEx() ?
		DCTRL.StartEditEx(
			m_strDisplayTitle,
			m_strAsset.toUpperCase(),
			"",
			m_strApp,
			m_strMetric,
			m_iVersion,
			fIsCSC) :
		DCTRL.StartEdit(
			m_strDisplayTitle,
			m_strAsset.toUpperCase(),
			"",
			m_strApp,
			m_strMetric,
			m_iVersion);

	if(fJustInstalledAX)
		OnComplete(iResult);

	return;
}

function ResizeClientArea(iClientWidth, iClientHeight)
{
	if (null != iClientWidth && null != iClientHeight &&
		!isNaN(iClientWidth) && !isNaN(iClientHeight) && 
		iClientWidth > 0 && iClientHeight > 0)
		{
		var iResizeWidthBy = 0;
		var iResizeHeightBy = 0;

		for (var i=0; i < 3; i++)
			{
			iResizeWidthBy = iClientWidth - document.body.clientWidth;
			iResizeHeightBy = iClientHeight - document.body.clientHeight;
			window.resizeBy(iResizeWidthBy, iResizeHeightBy);
			}
		}
}

function CreateVideoPage(fIsNetscape, fIsOther, fIsMPlayer, strLTRorRTL,
	iControlWidth, iControlHeight, strUrl,
	strErrWMPNotInstalled, strErrFlashNotInstalled)
{
	document.writeln('<BODY ' +
		'MARGINHEIGHT="0" ' +
		'MARGINWIDTH="0" ' +
		'LEFTMARGIN="0" ' +
		'RIGHTMARGIN="0" ' +
		'TOPMARGIN="0" ' +
		'BOTTOMMARGIN="0" ' +
		'CLASS="ONBody" ' +
		(fIsNetscape ? '' : 'SCROLL="auto" ') +
		strLTRorRTL + '>');

	if (!fIsOther)
		{
		if (fIsMPlayer)
			{
			if (!fIsNetscape)
				{
				document.writeln('<OBJECT CLASSID="CLSID:6BF52A52-394A-11D3-B153-00C04F79FAA6" ID="objMediaPlayer" ' +
					'WIDTH="' + iControlWidth + '" ' +
					'HEIGHT="' + iControlHeight + '" ' +
					'BORDER="0">');

				document.writeln('<PARAM NAME="URL" VALUE="' + strUrl + '"/>');
				document.writeln('<PARAM NAME="ENABLECONTEXTMENU" VALUE="true"/>');
				document.writeln('<PARAM NAME="AUTOSTART" VALUE="true"/>');
				document.writeln('<PARAM NAME="STRETCHTOFIT" VALUE="true"/>');

				document.writeln('</OBJECT>');
				}
			else
				{
				document.writeln('<EMBED TYPE="application/x-mplayer2" ' +
					'PLUGINSPAGE = "http://www.microsoft.com/Windows/MediaPlayer/" ' +
					'SRC="' + strUrl + '" ' +
					'ID="objMediaPlayer" ' +
					'WIDTH="' + iControlWidth + '" ' +
					'HEIGHT="' + iControlHeight + '" ' +
					'AUTOSTART="true" ' +
					'UIMODE="mini" ' +
					'STRETCHTOFIT="true" ' +
					'SHOWAUDIOCONTROLS="true" ' +
					'SHOWPOSITIONCONTROLS="true">');
				document.write('</EMBED>');
				}
			}
		else
			{
			if (!fIsNetscape)
				{
				document.writeln('<OBJECT CLASSID="CLSID:D27CDB6E-AE6D-11CF-96B8-444553540000" ID="objFlashPlayer" ' +
					'WIDTH="' + iControlWidth + '" ' +
					'HEIGHT="' + iControlHeight + '" ' +
					'BORDER="0" ' +
					'CODEBASE="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0">');
				document.writeln('<PARAM NAME="movie" VALUE="' + strUrl + '"/>');
				document.writeln('<PARAM NAME="menu" VALUE="true"/>');
				document.writeln('<PARAM NAME="quality" VALUE="high"/>');
				document.writeln('</OBJECT>');
				}
			else
				{
				document.writeln('<EMBED ' +
					'ID="objFlashPlayer" ' +
					'SRC="' + strUrl + '" ' +
					'MENU="true" ' +
					'QUALITY="high" ' +
					'WIDTH="' + iControlWidth + '" ' +
					'HEIGHT="' + iControlHeight + '" ' +
					'TYPE="application/x-shockwave-flash" ' +
					'PLUGINSPAGE="http://www.macromedia.com/go/getflashplayer">');
				document.writeln('</EMBED>');
				}
			}
		}

	if (!fIsOther)
		{
		if (fIsMPlayer)
			{
			var fIsInstalled = false;

			if (!fIsNetscape)
				{
				fIsInstalled = ((typeof(objMediaPlayer) != "undefined") &&
					(typeof(objMediaPlayer.url) != "undefined"));
				}
			else
				{
				fIsInstalled = ((null != document.body.getElementsByTagName("EMBED")["objMediaPlayer"]) &&
					(typeof(document.body.getElementsByTagName("EMBED")["objMediaPlayer"]) != "undefined") &&
					(typeof(document.body.getElementsByTagName("EMBED")["objMediaPlayer"].src) != "undefined"));
				}

			if (!fIsInstalled)
				{
				alert(strErrWMPNotInstalled);
				}
			}
		else
			{
			var fIsInstalled = false;

			if (!fIsNetscape)
				{
				fIsInstalled = ((typeof(objFlashPlayer) != "undefined") &&
					(typeof(objFlashPlayer.movie) != "undefined"));
				}
			else
				{
				fIsInstalled = ((null != document.body.getElementsByTagName("EMBED")["objFlashPlayer"]) &&
					(typeof(document.body.getElementsByTagName("EMBED")["objFlashPlayer"]) != "undefined") &&
					(typeof(document.body.getElementsByTagName("EMBED")["objFlashPlayer"].src) != "undefined"));
				}

			if (!fIsInstalled)
				{
				alert(strErrFlashNotInstalled);
				}
			}
		}

	ResizeClientArea(iControlWidth, iControlHeight);
}

function CloseVideoPageBody()
{
	document.writeln('</BODY>');
}

function OpenVideo(url, width, height)
{
	if (FIsMac())
		{
		if (url.indexOf('?') < 0)
			url += '?';
		else
			url += '&';

		url += 'IsMac=1';
		}

	if (-1 != window.navigator.appName.toUpperCase().indexOf("NETSCAPE"))
		{

		window.open(url, '_AsstVidWnd');
		}
	else
		{
		window.open(url, '_AsstVidWnd', 'toolbar=0,status=0,menubar=0,resizable=0,width=' + width + ',height=' + height);
		}
}

var strIsRtl = '';
var allDivsInPage = null;
var allImagesInPage = null;
var fExpandedAssistance = false;
var popupWin;

function openWindow(url, example)
{
	if (typeof(popupWin) != "object" || null == popupWin) 
		popupWin = window.open(url, example, "width=452,height=572,top=0,left=0,alwaysRaised=yes,toolbar=0,directories=0,menubar=0,status=1,resizable=yes,location=0,scrollbars=1,copyhistory=0");
	else
		{
		if (!popupWin.closed) 
			popupWin.location.href = url;
		else 
			popupWin = window.open(url, example, "width=452,height=572,top=0,left=0,alwaysRaised=yes,toolbar=0,directories=0,menubar=0,status=1,resizable=yes,location=0,scrollbars=1,copyhistory=0");
		}	  

	popupWin.focus();
}

function ExpandDiv(theDivName)
{
    var strHide = 'Hide';
	InitializeGlobalData();

	if (null == theDivName || typeof(theDivName) == "undefined") return; var theDiv = allDivsInPage[theDivName]; if (null == theDiv || typeof(theDiv) == "undefined") return;
	theDiv.style.display = "block";

	var thePic = allImagesInPage[theDivName + "_img"];
	if (null != thePic && typeof(thePic) != "undefined")
		{
		//thePic.src = "/global/images/bluedrop.gif";
		thePic.src = "Image/bluedrop.gif";
		thePic.alt = strHide;
		}
}

function CollapseDiv(theDivName)
{
    var strShow = 'Show';
	InitializeGlobalData();

	if (null == theDivName || typeof(theDivName) == "undefined") return; var theDiv = allDivsInPage[theDivName]; if (null == theDiv || typeof(theDiv) == "undefined") return;
	theDiv.style.display = "none";

	var thePic = allImagesInPage[theDivName + "_img"];
	if (null != thePic && typeof(thePic) != "undefined")
		{
		//thePic.src = "/global/images/blueup" + strIsRtl + ".gif";
		thePic.src = "Image/blueup.gif";
		thePic.alt = strShow;
		}
}

function ToggleDiv(theDivName)
{
	InitializeGlobalData();

	if (null == theDivName || typeof(theDivName) == "undefined") return; var theDiv = allDivsInPage[theDivName]; if (null == theDiv || typeof(theDiv) == "undefined") return;

	if (theDiv.style.display.toUpperCase() != "BLOCK")
		ExpandDiv(theDivName);
	else
		CollapseDiv(theDivName);
}

function AlterAllDivs(displayStyle)
{
	InitializeGlobalData();

	if (null == allDivsInPage || typeof(allDivsInPage) == "undefined")
		return;

	if (typeof(allDivsInPage["divShowAll"]) != "undefined" &&
		typeof(allDivsInPage["divHideAll"]) != "undefined")
		{
		if (displayStyle == "block")
			{
			allDivsInPage["divShowAll"].style.display = "none";
			allDivsInPage["divHideAll"].style.display = "block";
			}
		else
			{
			allDivsInPage["divShowAll"].style.display = "block";
			allDivsInPage["divHideAll"].style.display = "none";
			}
		}

	AlterAllDivsSpans(document.body.getElementsByTagName("DIV"), displayStyle);
	AlterAllDivsSpans(document.body.getElementsByTagName("SPAN"), displayStyle);
}

function AlterAllDivsSpans(allDivsSpans, displayStyle)
{   
	if (typeof(allDivsSpans) == "undefined" ||
		null == allDivsSpans)
		return;

	for (i=0; i < allDivsSpans.length; i++)
		if (typeof(allDivsSpans[i]) != "undefined" &&
			null != allDivsSpans[i] &&
			typeof(allDivsSpans[i].id) != "undefined" &&
			null != allDivsSpans[i].id &&
			allDivsSpans[i].id.length > 0)
			{
			if (0 == allDivsSpans[i].id.indexOf("divExpCollAsst_")) 
				{
				var thePic = allImagesInPage[allDivsSpans[i].id + "_img"];

				if (displayStyle == "block")
					{
					allDivsSpans[i].style.display = "block";

					if (typeof(thePic) != "undefined" && null != thePic)
						{
						thePic.src = "/global/images/bluedrop.gif";
						thePic.alt = strHide;
						}
					}
				else
					{
					allDivsSpans[i].style.display = "none";

					if (typeof(thePic) != "undefined" && null != thePic)
						{
						thePic.src = "/global/images/blueup" + strIsRtl + ".gif";
						thePic.alt = strShow;
						}
					}
				}

			if (0 == allDivsSpans[i].id.indexOf("divInlineDef_")) 
				if (displayStyle == "block")
					allDivsSpans[i].style.display = "inline";
				else
					allDivsSpans[i].style.display = "none";
			}
}

function ToggleAllDivs()
{
	InitializeGlobalData();

	if (fExpandedAssistance)
		AlterAllDivs("none");
	else
		AlterAllDivs("block");

	fExpandedAssistance = !fExpandedAssistance;
}

function ToggleAll()
{
	InitializeGlobalData();
	ToggleAllDivs();
}

function InitializeGlobalData()
{
	if ('undefined' != typeof(strRtl))
		strIsRtl = strRtl;

	var divs = document.body.getElementsByTagName("DIV");
	var spans = document.body.getElementsByTagName("SPAN");

	var countDiv = 0;
	var countSpan = 0;
	if (typeof(divs) != "undefined" && null != divs)
		countDiv = divs.length;

	if (typeof(spans) != "undefined" && null != spans)
		countSpan = spans.length;

	allDivsInPage = new Array();
	for (i=0; i < countDiv; i++)
		if (typeof(divs[i].id) != "undefined" &&
			null != divs[i].id &&
			divs[i].id.length > 0)
			allDivsInPage[divs[i].id] = divs[i];

	for (i=0; i < countSpan; i++)
		if (typeof(spans[i].id) != "undefined" &&
			null != spans[i].id &&
			spans[i].id.length > 0)
			allDivsInPage[spans[i].id] = spans[i];

	allImagesInPage = document.body.getElementsByTagName("IMG");
}

function OnSeeAlsoClicked()
{
	InitializeGlobalData();

	if (null == allDivsInPage || typeof(allDivsInPage) == "undefined")
		return;

	if (typeof(allDivsInPage["divSeeAlsoShowBullet"]) != "undefined" &&
		typeof(allDivsInPage["divSeeAlsoHideBullet"]) != "undefined")
		{
		if (allDivsInPage["divSeeAlsoShowBullet"].style.display.toUpperCase() == "INLINE")
			{
			allDivsInPage["divSeeAlso"].style.display = "block";
			allDivsInPage["divSeeAlsoShowBullet"].style.display = "none";
			allDivsInPage["divSeeAlsoHideBullet"].style.display = "inline";
			}
		else
			{
			allDivsInPage["divSeeAlso"].style.display = "none";
			allDivsInPage["divSeeAlsoShowBullet"].style.display = "inline";
			allDivsInPage["divSeeAlsoHideBullet"].style.display = "none";
			}
		}
}

var QUIZ_COOKIE_NAME = "QUIZ_DATA";

function SetQuizCookie(strName, strValue)
{
	var strQuizCookie = GetCookie(QUIZ_COOKIE_NAME);
	if (null != strQuizCookie && 0 != strQuizCookie.length)
	{
		var iStart = strQuizCookie.indexOf(strName);
		if (iStart >= 0)
		{
			var iEnd = strQuizCookie.indexOf(" ", iStart + 1);
			var strEnd = (iEnd > 0 ? strQuizCookie.substr(iEnd) : "");
			var strCookie = (strValue == null ? "" : strName + ":" + strValue);
			strQuizCookie = strQuizCookie.substr(0, iStart) + strCookie + strEnd;
		}
		else if (strValue != null)
		{
			strQuizCookie += " " + strName + ":" + strValue;
		}
	}
	else
	{
		strQuizCookie = strName + ":" + strValue;
	}
	mSetCookie(QUIZ_COOKIE_NAME, strQuizCookie);
}

function GetQuizCookie(strName)
{
	var strQuizCookie = GetCookie(QUIZ_COOKIE_NAME);
	if (null != strQuizCookie && 0 != strQuizCookie.length)
	{
		var iStart = strQuizCookie.indexOf(strName);
		if (iStart >= 0)
		{
			iStart = strQuizCookie.indexOf(":", iStart + 1);
			if (iStart > 0)
			{
				iStart++;
				var	iEnd = strQuizCookie.indexOf(" ", iStart + 1);
				if (iEnd == -1)
				{
					return strQuizCookie.substr(iStart);
				}
				else
				{
					return strQuizCookie.substring(iStart, iEnd);
				}
			}
		}
	}
	return "";
}

function ShowElement(name)
{
	var objElement = GetPageElementQuiz(name);
	if (objElement != null)
		{
		objElement.style.display = 'inline';
		}
}

function GetPageElementQuiz(strElementID)
{
	if (document.all)
		{
		return document.all[strElementID];
		}
	else if (document.getElementById)
		{
		return document.getElementById(strElementID);
		}
	else if (document.layers)
		{
		return document.MainForm.elements[strElementID];
		}
	return null;
}

function fnMail()
{
	var re;

	g_strMailToUrl = UpdateQuizTokens(g_strMailToUrl);

	var sUrl = location.href;
	var iEnd = sUrl.indexOf('?');
	if (iEnd > -1)
		{
		sUrl = sUrl.substr(0, iEnd);
		}

	re = /%Quiz_Url%%26/g;
	g_strMailToUrl = g_strMailToUrl.replace(re, sUrl + '?');

	location.href = XMLDecode(g_strMailToUrl);
}

function fnMaintainAnswer(opt)
{
	var strID = opt.id;
	var iPos = strID.indexOf('_', 0);
	var iQuestion = parseInt(strID.substring(1, iPos));
	var strAnswer = strID.substring(iPos + 1);

	g_strUserAnswers = '0' + 
		g_strUserAnswers.substring(1, iQuestion) + 
		strAnswer + 
		(iQuestion == g_iTotalQuestions ? '' : g_strUserAnswers.substring(iQuestion + 1));

	SetQuizCookie(g_strQuizID, g_strUserAnswers);
}

function SubmitAnswers()
{
	g_strUserAnswers = '1' +
		g_strUserAnswers.substring(1, g_strUserAnswers.length);
	SetQuizCookie(g_strQuizID, g_strUserAnswers);
	document.location.href = g_strQuizID + '.aspx?ctt=6&submit=1';
	return true;
}

function PreloadAnswers()
{
	var strUserAnswer = '';

	for (var i = 1; i <= g_iTotalQuestions; i++)
		{

		strUserAnswer = g_strUserAnswers.charAt(i);

		if (strUserAnswer == '0')
			{
			ShowElement('q' + i + '_Unanswered');
			}
		else
			{

			if (strUserAnswer == g_strCorrectAnswers.charAt(i))
				{
				ShowElement('q' + i + '_Correct');
				}

			else
				{
				ShowElement('q' + i + '_Incorrect');
				ShowElement('q' + i + '_' + strUserAnswer);
				}
			}
		}

	if ((g_sAvgScore != '0.0') && (g_sAvgScore != '0,0'))
		{
		ShowElement('quizMetrics');
		}
}

function PreloadQuestions()
{
	var strUserAnswer;
	var obj;

	g_strUserAnswers = GetQuizCookie(g_strQuizID);

	for (var i = 1; i <= g_iTotalQuestions; i++)
		{
		strUserAnswer = g_strUserAnswers.substring(i, i + 1);
		if (strUserAnswer != "0")
			{
			obj = GetPageElementQuiz('q' + i + '_' + strUserAnswer);
			if (obj != null)
				{
				obj.checked = true;
				}
			}
		}
}

function UpdateQuizTokens(s)
{
	if (typeof(s) == 'undefined')
		return "";

	var re;

	re = /%Quiz_AvgScore%/g;
	s = s.replace(re, g_sAvgScore);

	re = /%Quiz_NumberOfScores%/g;
	s = s.replace(re, g_iTotalUsers);

	re = /%Quiz_Questions%/g;
	s = s.replace(re, g_iTotalQuestions);

	re = /%Quiz_Score%/g;
	s = s.replace(re, g_iScore);

	return s;	
}

function XMLEncode(s)
{
	if (typeof(s) == 'undefined')
		return "";

	s = s.replace(/&/g, "&amp;");
	s = s.replace(/>/g, "&gt;");
	s = s.replace(/</g, "&lt;");
	s = s.replace(/'/g, "&apos;");
	s = s.replace(/"/g, "&quot;");	
	return s;
}

function XMLDecode(s)
{
	if (typeof(s) == 'undefined')
		return "";

	var re;

	re = /&amp;/g;
	s = s.replace(re, "&");

	re = /&gt;/g;
	s = s.replace(re, ">");

	re = /&lt;/g;
	s = s.replace(re, "<");

	re = /&apos;/g;
	s = s.replace(re, "'");

	re = /&quot;/g;
	s = s.replace(re, "\"");

	return s;
}

function SetAWSPanels(strSetDivFeedbackDropDownWeb, strSetDivComment, strSetDivNewContent, strSetDivFeedbackAsset)
{
	{ allDivs["divFeedbackDropDownWeb"].style.display = strSetDivFeedbackDropDownWeb; }
	{ allDivs["divComment"].style.display = strSetDivComment; }
	{ allDivs["divNewContent"].style.display = strSetDivNewContent; }
	{ allDivs["divFeedbackAsset"].style.display = strSetDivFeedbackAsset; }
	{ allDivs["divThirdImage"].style.display = strSetDivFeedbackAsset; }
}

function SetExtraAWSPanels(strSetDivClipArtComplaint, strSetDivNewContentCategory, strSetDivNewContentProduct) 
{
	{ allDivs["divClipArtComplaint"].style.display = strSetDivClipArtComplaint; }
	{ allDivs["divNewContentCategoryPanel"].style.display = strSetDivNewContentCategory; }
	{ allDivs["divNewContentProductPanel"].style.display = strSetDivNewContentProduct; }
}

function SetBottomPanels(strSetDivDisclaimerPanel, strSetDivButtonPanel)
{
	{ allDivs["divDisclaimerPanel"].style.display = strSetDivDisclaimerPanel; }
	{ allDivs["divButtonPanel"].style.display = strSetDivButtonPanel; }
}

function SetPageMode(mode)
{
	{ allDivs["divDownloadsProblem"].style.display = "none"; };
	{ allDivs["divDownloadsProblemEmail"].style.display = "none"; };

	switch (mode)
		{
		case iAWSCompliment:
			SetAWSPanels("block", "block", "none", "none"); 
			SetExtraAWSPanels("none", "none", "none");
			SetBottomPanels("block", "block"); 
		break;

		case iAWSComplaint:
			SetAWSPanels("block", "block", "none", "none"); 
			SetExtraAWSPanels("none", "none", "none");
			SetBottomPanels("block", "block"); 
			if (iWebOfficeUpdate == allSelects["m_ddlFeedbackRegardingWeb"].selectedIndex)
				{
				{ allDivs["divDownloadsProblem"].style.display = "block"; };
				{ allDivs["divDownloadsProblemEmail"].style.display = "block"; };
				}
		break;

		case iAWSComplaint_Clipart:
			SetAWSPanels("block", "block", "none", "none"); 
			SetExtraAWSPanels("block", "none", "none"); 
			SetBottomPanels("block", "block"); 
		break;

		case iAWSSuggestion:
			SetAWSPanels("block", "none", "block", "none"); 
			SetExtraAWSPanels("none", "none", "none");
			SetBottomPanels("block", "block"); 
		break;

		case iAWSSuggestion_Cat:
			SetAWSPanels("block", "none", "block", "none"); 
			SetExtraAWSPanels("none", "block", "none"); 
			SetBottomPanels("block", "block"); 
		break;

		case iAWSSuggestion_Prod:
			SetAWSPanels("block", "none", "block", "none"); 
			SetExtraAWSPanels("none", "none", "block"); 
			SetBottomPanels("block", "block"); 
		break;

		case iAWSAsset:
			SetAWSPanels("block", "none", "none", "block"); 
			SetExtraAWSPanels("none", "none", "none");
			SetBottomPanels("block", "block"); 
			SetStepGraphics(2);
			{ allDivs["divSecondImage"].style.display = "none"; }
			{ allDivs["divThirdImage"].style.display = "block"; }
		break;

		case iAWSNo_Bottom:
			SetAWSPanels("block", "none", "none", "none"); 
			SetExtraAWSPanels("none", "none", "none");
			SetBottomPanels("none", "none");
		break;
		};
}

function SetStepGraphics(step)
{
	var active = "";
	var inactive = "";
	if (!fIsRTL) 
		{
		active = "/assistance/images/icon_right_arrow_active.gif";
		inactive = "/assistance/images/icon_right_arrow_inactive.gif";
		}
	else
		{
		active = "/assistance/images/icon_left_arrow_active.gif";
		inactive = "/assistance/images/icon_left_arrow_inactive.gif";
		}

	switch (step) 
		{
		case 1:
			allImages["imgFirstPanel"].src = active; allImages["imgFirstPanel"].alt = strAltTextCurrent;
			allImages["imgSecondPanel"].src = inactive; allImages["imgSecondPanel"].alt = strAltTextCompleted;
			allImages["imgThirdPanel"].src = inactive; allImages["imgThirdPanel"].alt = strAltTextCompleted;

			{ allDivs["divSecondImage"].style.display = "none"; }
			{ allDivs["divThirdImage"].style.display = "none"; }
		break;

		case 2:
			allImages["imgFirstPanel"].src = inactive; allImages["imgFirstPanel"].alt = strAltTextCompleted;
			allImages["imgSecondPanel"].src = active; allImages["imgSecondPanel"].alt = strAltTextCurrent;
			allImages["imgThirdPanel"].src = active; allImages["imgThirdPanel"].alt = strAltTextCurrent;

			{ allDivs["divSecondImage"].style.display = "block"; }
			{ allDivs["divThirdImage"].style.display = "none"; }
		break;

		case 3:
			allImages["imgFirstPanel"].src = inactive; allImages["imgFirstPanel"].alt = strAltTextCompleted;
			allImages["imgSecondPanel"].src = inactive; allImages["imgSecondPanel"].alt = strAltTextCompleted;
			allImages["imgThirdPanel"].src = active; allImages["imgThirdPanel"].alt = strAltTextCurrent;

			{ allDivs["divSecondImage"].style.display = "block"; }
			{ allDivs["divThirdImage"].style.display = "block"; }
		break;
		};
}

function Complete_Page() 
{
	{ allDivs["divSuggestNewContent_EntireWebSite"].style.display = "none"; };
	{ allDivs["divSuggestNewContent_Assistance"].style.display = "none"; };
	{ allDivs["divSuggestNewContent_Training"].style.display = "none"; };
	{ allDivs["divSuggestNewContent_TemplateGallery"].style.display = "none"; };
	{ allDivs["divSuggestNewContent_Clipart"].style.display = "none"; };
	{ allDivs["divSuggestNewContent_PartnerMarketplace"].style.display = "none"; };
	{ allDivs["divSuggestNewContent_OfficeUpdate"].style.display = "none"; };
	{ allDivs["divSuggestNewContent_TFYJ"].style.display = "none"; };

	{ allDivs["divSuggestNewContent_a_EntireWebSite"].style.display = "none"; };
	{ allDivs["divSuggestNewContent_a_Assistance"].style.display = "none"; };
	{ allDivs["divSuggestNewContent_a_Training"].style.display = "none"; };
	{ allDivs["divSuggestNewContent_a_TemplateGallery"].style.display = "none"; };
	{ allDivs["divSuggestNewContent_a_Clipart"].style.display = "none"; };
	{ allDivs["divSuggestNewContent_a_PartnerMarketplace"].style.display = "none"; };
	{ allDivs["divSuggestNewContent_a_OfficeUpdate"].style.display = "none"; };
	{ allDivs["divSuggestNewContent_a_TFYJ"].style.display = "none"; };

	{ allDivs["divSuggestNewContent_b_EntireWebSite"].style.display = "none"; };
	{ allDivs["divSuggestNewContent_b_Assistance"].style.display = "none"; };
	{ allDivs["divSuggestNewContent_b_Training"].style.display = "none"; };
	{ allDivs["divSuggestNewContent_b_TemplateGallery"].style.display = "none"; };
	{ allDivs["divSuggestNewContent_b_Clipart"].style.display = "none"; };
	{ allDivs["divSuggestNewContent_b_PartnerMarketplace"].style.display = "none"; };
	{ allDivs["divSuggestNewContent_b_OfficeUpdate"].style.display = "none"; };
	{ allDivs["divSuggestNewContent_b_TFYJ"].style.display = "none"; };

	{ allDivs["divProvideComments_Compliment"].style.display = "none"; };
	{ allDivs["divProvideComments_Complaint"].style.display = "none"; };

	var fIsAsset = false;

	if (iWebAsset == allSelects["m_ddlFeedbackRegardingWeb"].selectedIndex)
		{
		fIsAsset = true;
		}

	if (0 == iFeedbackType)
		{

		SetPageMode(iAWSCompliment);
		SetStepGraphics(2);
		{ allDivs["divProvideComments_Compliment"].style.display = "block"; };
		}
	else if (1 == iFeedbackType)
		{

		if (allSelects["m_ddlFeedbackRegardingWeb"].selectedIndex == iWebClipart)
			SetPageMode(iAWSComplaint_Clipart);
		else
			SetPageMode(iAWSComplaint);

		SetStepGraphics(2);
		{ allDivs["divProvideComments_Complaint"].style.display = "block"; };
		}
	else if (2 == iFeedbackType)
		{

		switch (allSelects["m_ddlFeedbackRegardingWeb"].selectedIndex) 
			{
			case iWebEntire_Web_Site:
				SetPageMode(iAWSSuggestion);
				{ allDivs["divSuggestNewContent_EntireWebSite"].style.display = "block"; };
				{ allDivs["divSuggestNewContent_a_EntireWebSite"].style.display = "block"; };
				{ allDivs["divSuggestNewContent_b_EntireWebSite"].style.display = "block"; };
			break;

			case iWebAssistance:
				SetPageMode(iAWSSuggestion);
				{ allDivs["divSuggestNewContent_Assistance"].style.display = "block"; };
				{ allDivs["divSuggestNewContent_a_Assistance"].style.display = "block"; };
				{ allDivs["divSuggestNewContent_b_Assistance"].style.display = "block"; };
			break;

			case iWebTraining: 
				SetPageMode(iAWSSuggestion_Prod);
				{ allDivs["divSuggestNewContent_Training"].style.display = "block"; };
				{ allDivs["divSuggestNewContent_a_Training"].style.display = "block"; };
				{ allDivs["divSuggestNewContent_b_Training"].style.display = "block"; };
			break;

			case iWebTemplateGallery: 
				SetPageMode(iAWSSuggestion_Cat);
				{ allDivs["divSuggestNewContent_TemplateGallery"].style.display = "block"; };
				{ allDivs["divSuggestNewContent_a_TemplateGallery"].style.display = "block"; };
				{ allDivs["divSuggestNewContent_b_TemplateGallery"].style.display = "block"; };
			break;

			case iWebClipart:
				SetPageMode(iAWSSuggestion);
				{ allDivs["divSuggestNewContent_Clipart"].style.display = "block"; };
				{ allDivs["divSuggestNewContent_a_Clipart"].style.display = "block"; };
				{ allDivs["divSuggestNewContent_b_Clipart"].style.display = "block"; };
			break;

			case iWebMarketplace:
				SetPageMode(iAWSSuggestion);
				{ allDivs["divSuggestNewContent_PartnerMarketplace"].style.display = "block"; };
				{ allDivs["divSuggestNewContent_a_PartnerMarketplace"].style.display = "block"; };
				{ allDivs["divSuggestNewContent_b_PartnerMarketplace"].style.display = "block"; };
			break

			case iWebOfficeUpdate:
				SetPageMode(iAWSSuggestion);
				{ allDivs["divSuggestNewContent_OfficeUpdate"].style.display = "block"; };
				{ allDivs["divSuggestNewContent_a_OfficeUpdate"].style.display = "block"; };
				{ allDivs["divSuggestNewContent_b_OfficeUpdate"].style.display = "block"; };
			break;

			case iWebWorkEssentials:
				SetPageMode(iAWSSuggestion);
				{ allDivs["divSuggestNewContent_TFYJ"].style.display = "block"; };
				{ allDivs["divSuggestNewContent_a_TFYJ"].style.display = "block"; };
				{ allDivs["divSuggestNewContent_b_TFYJ"].style.display = "block"; };
			break;

			default: 
				SetPageMode(iAWSAsset);
			};

		SetStepGraphics(2);
		if (fIsAsset)
			{
			{ allDivs["divSecondImage"].style.display = "none"; }
			{ allDivs["divThirdImage"].style.display = "block"; }
			}
		}
	else
		{

		SetPageMode(iAWSNo_Bottom);
		SetStepGraphics(2);
		}
}

function StrTrim(str)
{
	if (typeof(str) == "undefined" || null == str)
		return null;

	while (str.length > 0 && str.charCodeAt(0) <= 32)
		str = str.substring(1);

	while (str.length > 0 && str.charCodeAt(str.length-1) <= 32)
		str = str.substring(0, str.length-1);

	return str;
}

function FIsCommentValid(str, err, limit, auxError)
{
	if (typeof(str) == "undefined" || null == str)
		{
		alert(err);
		return false;
		}

	str = StrTrim(str);

	if (str.length <= 0)
		{
		alert(err);
		return false;
		}

	if (limit > 0 && str.length > limit)
		{
		if (auxError.length > 0)
			alert(auxError);

		return false;
		}

	return true;
}

function FIsEmailAddressValid(strEmail)
{
	if (typeof(strEmail) == "undefined")
		return true;

	if (null == strEmail)
		return true;

	if (0 == strEmail.length)
		return true;

	for (var i=0; i < strEmail.length; i++)
		{
		if (strEmail.charCodeAt(i) > 127 )
			return false;
		}

	return true;
}

function AttemptSubmit()
{
	{ allDivs["divDownloadsInvalidEmailAddress"].style.display = "none"; };

	if ((allDivs["divFeedbackAsset"].style.display == "block"))
		if (!FIsCommentValid(allTextAreas["m_txbAssetBox"].value, strErrorDescription, 650, ""))
			return;

	if ((allDivs["divComment"].style.display == "block"))
		if (!FIsCommentValid(allTextAreas["m_txbCommentBox"].value, strErrorDescription, 650, ""))
			return;

	if ((allDivs["divNewContent"].style.display == "block"))
		{
		if (!FIsCommentValid(allTextAreas["m_txbNewContentDescribe"].value, strErrorDescription, 650, ""))
			return;
		}

	var fInvalidInput = false;

	if ((allDivs["divDownloadsProblemEmail"].style.display == "block"))
		{
		if (!FIsEmailAddressValid(allInputs["m_txbDownloadsEmail"].value))
			{
			{ allDivs["divDownloadsInvalidEmailAddress"].style.display = "block"; };
			fInvalidInput = true;
			}
		}

	if (fInvalidInput)
		return;

	document.forms["Form1"].submit();
}

function StrReplace(strSource, strWhat, strNew)
{
	if (typeof(strSource) == 'undefined' ||
		typeof(strWhat) == 'undefined' ||
		typeof(strNew) == 'undefined' ||
		null == strSource ||
		null == strSource ||
		null == strSource)
		{
		return strSource;
		}

	var iPos = strSource.indexOf(strWhat);
	if (iPos < 0)
		return strSource;

	return strSource.substring(0, iPos) + strNew + strSource.substring(iPos+strWhat.length);
}

function goDisplayCount(max_len, box, label, strSubmitButtonId)
{
	if ('undefined' == typeof(fDisableCounter) ||
		'undefined' == typeof(fDisableCounterFirst) ||
		'undefined' == typeof(fWasLastCountOver))
		{
		return;
		}

	var txbBox = document.getElementById(box);
	if ('undefined' == typeof(txbBox) || null == txbBox)
		return;

	var fDoCount = true;
	if (fDisableCounter)
		{
		if (fDisableCounterFirst)
			{
			document.getElementById(label).innerHTML =
				'<SPAN CLASS="FeedbackWizCounterText">' + strGoDisplayCountOK + '</SPAN>';

			fDisableCounterFirst = false;
			}

		fDoCount = false;
		}

	var strDescr = txbBox.value;
	var nLen = max_len - strDescr.length;

	var btnFeedback = null;
	var fFoundButton = false;
	if ('undefined' != typeof(strSubmitButtonId) && null != strSubmitButtonId)
		{
		btnFeedback = document.getElementById(strSubmitButtonId);
		if ('undefined' != typeof(btnFeedback) && null != btnFeedback)
			fFoundButton = true;
		}

	if (nLen >= 0) 
		{
		if (fDoCount)
			{
			document.getElementById(label).innerHTML = '<SPAN CLASS="FeedbackWizCounterText">' +
				StrReplace(strGoDisplayCountOK, '{0}', '' + nLen) + '</SPAN>';
			}
		else if (fWasLastCountOver)
			{
			document.getElementById(label).innerHTML =
				'<SPAN CLASS="FeedbackWizCounterText">' + strGoDisplayCountOK + '</SPAN>';
			}

		fWasLastCountOver = false;

		if (fFoundButton)
			{

			var fCanDisable = true;
			if ('undefined' != typeof(iFeedbackWizStarRated))
				fCanDisable = (iFeedbackWizStarRated < 1 || iFeedbackWizStarRated > 5);

			if (0 == strDescr.length && fCanDisable)
				btnFeedback.disabled = true;
			else
				btnFeedback.disabled = false;
			}
		}
	else
		{
		if (fDoCount)
			{
			var strError = strGoDisplayCountOver;
			strError = StrReplace(strError, '{0}',  '' + (max_len-nLen));
			strError = StrReplace(strError, '{1}',  '' + max_len);
			document.getElementById(label).innerHTML = '<SPAN CLASS="FeedbackWizCounterStar">' +
				strGoDisplayCountOverStar + '</SPAN><SPAN CLASS="FeedbackWizCounterOverText">' +
				strError + '</SPAN>';
			}
		else if (!fWasLastCountOver)
			{
			document.getElementById(label).innerHTML = '<SPAN CLASS="FeedbackWizCounterStar">' +
				strGoDisplayCountOverStar + '</SPAN><SPAN CLASS="FeedbackWizCounterOverText">' +
				strGoDisplayCountOK + '</SPAN>';
			}

		fWasLastCountOver = true;

		if (fFoundButton)
			btnFeedback.disabled = true;
		}
}

function modifyDisplayCount(nMaxLen, strTextBoxName, strSpanName)
{
	var txbBox = G(strTextBoxName);
	if (null == txbBox)
		return;

	var strDescr = txbBox.value;
	var nLen = nMaxLen - strDescr.length;
	var allSpans = document.body.getElementsByTagName("SPAN");	

	if (nLen >= 0) 
		{
		allSpans[strSpanName].className = 'OFLbl';
		allSpans[strSpanName].innerHTML = StrReplace(strGoDisplayCountOK, '{0}', '' + nLen)
		}
	else 
		{
		var strError = strGoDisplayCountOver;
		strError = StrReplace(strError, '{0}',  '' + (nMaxLen-nLen));
		strError = StrReplace(strError, '{1}',  '' + nMaxLen);
		allSpans[strSpanName].className = 'OILbl2';
		allSpans[strSpanName].innerHTML = strError;
		}	
}

function FeedbackRegardingAppsValid(s,e)
{
	var sDescr = allSelects["m_ddlFeedbackRegardingApps"].value;
	if (sDescr == "-1")
		{
		e.IsValid = false;
		}
	else
		{
		e.IsValid = true;
		}
}

function SetClipArtClientURLCookie()
{
	if (FIsMac() || null != SzGetArgumentValue("CAG"))
		mSetCookie("AWS_ClientURL_Sess", "CIL");

	return;
}

function ClipartPreviewCreateWMPControl()
{
	try
		{
		WMP7Obj = new ActiveXObject("WMPlayer.OCX.7");
		}
	catch(e)
		{

		}

	try
		{
		if (typeof(WMP7Obj) == "object") 
			{
			document.write('<OBJECT ID="MediaPlayer7" WIDTH="175" HEIGHT="175" CLASSID="CLSID:6BF52A52-394A-11D3-B153-00C04F79FAA6">');
			document.write('<PARAM name="url" VALUE="' + sMediaURL + '">');
			document.write('<PARAM NAME="enablecontextmenu" VALUE="false">');
			document.write('<PARAM NAME="uimode" VALUE="mini">');
			document.write('<PARAM NAME="autostart" VALUE="true">');
			document.write('</OBJECT>');
			}
		else  
			{
			document.write('<OBJECT ID="MediaPlayer6" WIDTH="200" HEIGHT="200" CLASSID="CLSID:22D6F312-B0F6-11D0-94AB-0080C74C7E95">');
			document.write('<PARAM name="filename" VALUE="' + sMediaURL + '">');
			document.write('<PARAM NAME="animationatstart" VALUE="true">');
			document.write('<PARAM NAME="autorewind" VALUE="true">');
			document.write('<PARAM NAME="autostart" VALUE="true">');
			document.write('<PARAM NAME="showaudiocontrols" VALUE="true">');
			document.write('<PARAM NAME="showpositioncontrols" VALUE="false">');
			document.write('<PARAM NAME="showstatusbar" VALUE="false">');
			document.write('<EMBED TYPE="application/x-mplayer2"');
			document.write('	PLUGINSPAGE = "http://www.microsoft.com/Windows/MediaPlayer/"');
			document.write('	SRC="' + sMediaURL + '"');
			document.write('	NAME="MediaPlayer1"');
			document.write('	WIDTH="200"');
			document.write('	HEIGHT="200"');
			document.write('	ANIMATIONATSTART="true"');
			document.write('	AUTOREWIND="true"');
			document.write('	AUTOSTART="true"');
			document.write('	SHOWAUDIOCONTROLS="true"');
			document.write('	SHOWPOSITIONCONTROLS="false"');
			document.write('	SHOWSTATUSBAR="true">');
			document.write('</EMBED>');
			document.write('</OBJECT>');
			}
		}
	catch(e)
		{

		}
}

function FIsMac()
{
	if (typeof(window.navigator.platform) != 'undefined')
		return (-1 != window.navigator.platform.toUpperCase().indexOf("MAC"));
	else
		return (-1 != navigator.userAgent.toUpperCase().indexOf("MAC"));
}

function SetReturnParameterValue(strReturn)
{
	strAxInstallReturnParameter = escape(strReturn);
}

function FIsSupportedWindows()
{
	return ("Win32" == navigator.platform &&
		-1 == navigator.userAgent.indexOf("Windows 95") &&
		-1 == navigator.userAgent.indexOf("Windows 98") &&
		-1 == navigator.userAgent.indexOf("Windows ME") &&
		-1 == navigator.userAgent.indexOf("Windows NT 4") &&
		-1 == navigator.userAgent.indexOf("Windows CE"));
}

function FIsCorrectVersion()
{
	var rgstrVersion;
	var iVerMajor;
	var iVerMinor;
	var iVerBuild;
	var iVerRev;

	strVersion = GetCookie("AWS_ActivexVersion_Perm");
	if ("" == strVersion || "0" == strVersion)
		return false;

	rgstrVersion = strVersion.split(".");

	iVerMajor = Number(rgstrVersion[0]);
	iVerMinor = Number(rgstrVersion[1]);
	iVerBuild = Number(rgstrVersion[2]);
	iVerRev = Number(rgstrVersion[3]);

	var iReqVerMajor = 11;
	var iReqVerMinor = 0;
	var iReqRevMajor = 6006;
	var iReqRevMinor = 0;

	if (typeof(strOverwriteAXRequiredVersion) != 'undefined' &&
		null != strOverwriteAXRequiredVersion &&
		strOverwriteAXRequiredVersion.length > 0)
	{
		var rgstrReqVer = strOverwriteAXRequiredVersion.split(".");
		if (4 == rgstrReqVer.length)
		{
			iReqVerMajor = Number(rgstrReqVer[0]);
			iReqVerMinor = Number(rgstrReqVer[1]);
			iReqRevMajor = Number(rgstrReqVer[2]);
			iReqRevMinor = Number(rgstrReqVer[3]);
		}
	}

	if (iVerMajor > iReqVerMajor)
		return true;

	if (iVerMajor < iReqVerMajor)
		return false;

	if (iVerMinor > iReqVerMinor)
		return true;

	if (iVerMinor < iReqVerMinor)
		return false;

	if (iVerBuild > iReqRevMajor)
		return true;

	if (iVerBuild < iReqRevMajor)
		return false;

	if (iVerRev < iReqRevMinor)
		return false;

	return true;
}

function SetActiveXInstallStatus()
{
	fIsActiveXInstalled = false;

	if (!fSupportsActiveX || fDisableActivex)
		return;

	var fIsCorectVersion = FIsCorrectVersion();

	if (fIsCorectVersion)
		{

		document.write('<SPAN style="display:none"><OBJECT CLASSID="clsid:02BCC737-B171-4746-94C9-0D8A0B2C0089" ID="DCTRL" WIDTH="0" HEIGHT="0"></OBJECT></SPAN>');
		fIsActiveXInstalled = (typeof(DCTRL) != "undefined" &&	typeof(DCTRL.Version) != "undefined");

		if (!fIsActiveXInstalled)
			SetPersistentCookie("AWS_ActivexVersion_Perm", 0);
		}
}

function FShouldPromptForAx()
{
	return !(FIsVariableInCookie("AWS_DontPrompt_Sess") ||
		FIsVariableInCookie("AWS_DontPrompt_Perm") ||
		fDisableActivex);
}

function FIsDCTRLInstalled()
{
	return fIsActiveXInstalled;
}

function InstallActiveX(fIgnoreCookie, wnd, fUseWndUrl)
{
	var strAxInstallStyle = "";
	if ("undefined" != typeof(strActiveXInstallStyle))
		strAxInstallStyle = strActiveXInstallStyle;

	if ("undefined" == typeof(fIgnoreCookie) || null == fIgnoreCookie)
		fIgnoreCookie = false;

	if ("undefined" == typeof(wnd) || null == wnd)
		wnd = window;

	if ("undefined" == typeof(fUseWndUrl) || null == fUseWndUrl)
		fUseWndUrl = false;

	if (!fIsActiveXInstalled &&
		!fInstallingActiveX &&
		fSupportsActiveX &&
		(fIgnoreCookie || FShouldPromptForAx()))
		{

		fInstallingActiveX = true;

		var strNewUrl = strAxInstall;
		strNewUrl = strNewUrl.replace("{0}", strAxInstallStyle);
		strNewUrl = strNewUrl.replace("{2}", strAxInstallReturnParameter);

		if (fUseWndUrl)
			strNewUrl = strNewUrl.replace("{1}", escape(wnd.location.pathname.slice(1) + wnd.location.search + wnd.location.hash));

		else
			strNewUrl = strNewUrl.replace("{1}", escape(document.location.pathname.slice(1) + document.location.search + wnd.location.hash));

		if (typeof(strOverwriteAXRequiredVersion) != 'undefined' &&
			null != strOverwriteAXRequiredVersion &&
			strOverwriteAXRequiredVersion.length > 0)
		{
			if (strNewUrl.indexOf('?') < 0)
				strNewUrl += '?';
			else
				strNewUrl += '&';

			strNewUrl += "reqver=" + escape(strOverwriteAXRequiredVersion);
		}

		wnd.location.href = strNewUrl;

		return false;
		}

	return fIsActiveXInstalled;
}

function StrRemoveParameterFromUrl(strUrl, strParam)
{
	var strUpperUrl = strUrl.toUpperCase();
	var strUpperParam = strParam.toUpperCase();

	var iStart = strUpperUrl.indexOf("?" + strUpperParam);
	if (iStart < 0)
		iStart = strUpperUrl.indexOf("&" + strUpperParam);

	if (iStart < 0)
		return strUrl;

	var iEnd = strUpperUrl.indexOf("&", iStart+1);

	if (iEnd < 0)
		iStart--;

	var strRet = strUrl.substring(0, iStart+1);

	if (iEnd >= 0)
		strRet += strUrl.substring(iEnd+1, strUrl.length);

	return strRet;
}

function SetDontPrompt()
{
	if (chkDontPrompt.checked)
		{
		SetPersistentCookie("AWS_DontPrompt_Perm", "1");
		}
	else
		{
		mDeleteCookie("AWS_DontPrompt_Perm");
		}
}

function FIsActiveXInstalled()
{
	return (typeof(DCTRL) != "undefined" &&
		typeof(DCTRL.Version) != "undefined")
}

function FActiveXSupportsStartEditEx()
{
	return (typeof(DCTRL) != 'undefined' && typeof(DCTRL.StartEditEx) != 'undefined');
}

function ReturnToCaller()
{
	var strReturn;
	strParameter = unescape(strQueryStringParameter);

	if (0 == strParameter.length)
		strParameter = "1";

	mSetCookie("AWS_DontPrompt_Sess", 1);

	if (FIsActiveXInstalled())
		mDeleteCookie("AWS_DontPrompt_Perm");

	strReturn = strQueryStringReturn;

	if (0 == strReturn.length)
		location.replace(".");
	else if ("{1}" == strReturn)
		history.back();
	else
		{
		var regExp = /&amp;/g;
		strReturn = strReturn.replace(regExp, "&");
		strReturn = StrRemoveParameterFromUrl(strReturn, "AxInstalled");
		strReturn += (-1 == strReturn.indexOf("?")) ? "?" : "&";
		strReturn += "AxInstalled=" + unescape(strParameter);
		location.replace("http://" + location.hostname + "/" + strReturn);
		}
}

function SetInstallStatus()
{
	document.getElementById("divStatus").style.display = "none";
	if (FIsActiveXInstalled())
		document.getElementById("divSuccess").style.display = "inline";
	else
		{
		document.getElementById("divFailure").style.display = "inline";
		document.getElementById("opnlRetry").style.visibility = "visible";
		document.getElementById("btnRetry").disabled = false;
		}
}

function SafePrintWindow()
{
	try
		{
		window.print();
		}
	catch(e)
		{

		}
}

function TryChapter(e)
{
	var oCNFrm = document.frmChapterNav;
	if (!oCNFrm) return false;

	var oChapter = oCNFrm.ChapterNav;
	if (!oChapter) return false;

	var nIndex = oChapter.selectedIndex;
	var strUrl = oChapter[nIndex].value;
	if (typeof(strUrl) != "undefined" &&
		null != strUrl && strUrl.length > 0)
	{
		window.location.href = strUrl;
	}
}

function SStyle(selector,style)
{
	if (window.navigator.appName.toUpperCase().indexOf("NETSCAPE") >= 0)
	{
		SStyleNetscape(selector,style);
	}
	else if (window.navigator.userAgent.toUpperCase().indexOf("OPERA") >= 0)
	{
		SStyleOpera(selector,style);
	}
	else
	{
		SStyleIE(selector,style);
	}
}

function SStyleNetscape(selector,style)
{
	var e=document.createElement('style');
	e.type='text/css';
	var h=document.getElementsByTagName('head')[0];
	h.appendChild(e);
	var s=e.sheet;
	s.insertRule(selector+' {'+style+'}',s.cssRules.length);
}

function SStyleOpera(selector,style)
{
	var e=document.createElement('style');
	e.type='text/css';
	var h=document.getElementsByTagName('head')[0];
	e.appendChild(document.createTextNode(selector+' {'+style+'}'));
	h.appendChild(e);
}

function SStyleIE(selector, style)
{
	var o=document.styleSheets[document.styleSheets.length - 1]
	o.addRule(selector,style);
}

function SStyleH(selector)
{
	SStyle(selector, 'display:none;');
}

function FixPageForPrinting()
{
	AlterAllDivs('block');
	SWdthNF('_TopHtmlTableCell');
	SWdthNF('_TopHtmlTableCellChild');
	SWdthNF('_TopTmpltHtmlTable');
	SDsplyH('_BottomHtmlRightSide');
	SDsplyH('_Ont_LeftNav_Cell');
	SDsplyH('OntTocCell');
	SDsplyH('tblRatings');
	SDsplyH('m_RightNav');
	SDsplyH('_Ont_BrowserNotice');
	SStyleH('.RightNavBackgroundNew');
	SStyleH('.BOSiblingNav');
}

function UpdateOfficeRestrictionsCookie()
{
	if (window.navigator.appName.toUpperCase().indexOf("NETSCAPE") >= 0 ||
		window.navigator.appName.toUpperCase().indexOf("FIREFOX") >= 0 ||
		window.navigator.appName.toUpperCase().indexOf("OPERA") >= 0)
		{
		return;
		}

	var strAlreadySet = "ofcresset=1"; 
	if (typeof(location) == 'undefined' || null == location ||
		typeof(location.href) == 'undefined' || null == location.href ||
		location.href.indexOf(strAlreadySet) >= 0)
		{
		return;
		}

	var strOldCookie = StrGetOfficeRestrictionsCookie();
	if (null != strOldCookie && strOldCookie.length >= 7 && '1' == mGetCookie("_ofcresset"))
		{
		SetOfficeRestrictionsCookie(strOldCookie);
		return;
		}

	var dateNow = new Date();
	var dateExpire = new Date();
	dateExpire.setTime(dateNow.getTime() + 1000 * 60 * 60 * 24); 
	mSetCookie("_ofcresset", "1", false, dateExpire);
	if ('1' != mGetCookie("_ofcresset"))
		{
		SetOfficeRestrictionsCookie("0000000");
		return; 
		}

	document.write(
		'<SPAN style="display:none">' +
			'<OBJECT ' +
				'ID="AuthzCtrl" ' +
				'CLASSID="clsid:C9712B19-838B-45A5-ABF2-9A315DDDED50" ' +
				'WIDTH="1" ' +
				'HEIGHT="1"></OBJECT>' +
		'</SPAN>');

	if (typeof(AuthzCtrl) == 'undefined' || typeof(AuthzCtrl.GetOfficeRestrictions) == 'undefined')
		{
		SetOfficeRestrictionsCookie("0000000");
		return;
		}

	var dwOffRes = AuthzCtrl.GetOfficeRestrictions();
	var strCookie = "";
	for (var i=0; i < 7; i++)
		{
		if (0 != (dwOffRes & (1 << i)))
			strCookie += '1';
		else
			strCookie += '0';
		}

	SetOfficeRestrictionsCookie(strCookie);

	var strNewCookie = StrGetOfficeRestrictionsCookie();
	if (strCookie != strNewCookie)
		return; 

	if (strCookie == strOldCookie)
		return; 

	var strNewLocation = location.href;

	if (strNewLocation.indexOf('?') < 0)
		strNewLocation += '?';
	else
		strNewLocation += '&';

	location.replace(strNewLocation + strAlreadySet);
}

function SetOfficeRestrictionsCookie(strCookie)
{
	var strNewCookie = "";

	if (typeof(strCookie) != 'undefined' && null != strCookie)
		strNewCookie = strCookie;

	var dateNow = new Date();
	var dateExpire = new Date();
	dateExpire.setTime(dateNow.getTime() + 1000 * 60 * 60 * 24 * 365 * 2); 
	mSetCookie("_ofcres", strNewCookie, false, dateExpire);
}

function StrGetOfficeRestrictionsCookie()
{
	return GetCookie("_ofcres", "");
}

function OnFilterItemClick(level)
{
	SetPersistentCookie("AWS_TrustLevel", level);
	window.location.href = StrRemoveParameterFromUrl(window.location.href, 'iStartAt');
}

function AppSetAutoDetectApp(strApp)
{
	if (typeof(strApp) == 'undefined' || null == strApp)
		return;

	if (typeof(DCTRL) == 'undefined' || typeof(DCTRL.GetInstalledVersion) == 'undefined')
		return;

	if (typeof(document) == 'undefined' || typeof(document.getElementById) == 'undefined')
		return;

	strApp = strApp.toUpperCase();
	var strId8 = "cbAppSet" + strApp + "8";
	var strId9 = "cbAppSet" + strApp + "9";
	var strId10 = "cbAppSet" + strApp + "10";
	var strId11 = "cbAppSet" + strApp + "11";
	var strId12 = "cbAppSet" + strApp + "12";

	var cb;

	cb = document.getElementById(strId8);
	if (typeof(cb) != 'undefined' && null != cb)
		cb.checked = false;

	cb = document.getElementById(strId9);
	if (typeof(cb) != 'undefined' && null != cb)
		cb.checked = false;

	cb = document.getElementById(strId10);
	if (typeof(cb) != 'undefined' && null != cb)
		cb.checked = false;

	cb = document.getElementById(strId11);
	if (typeof(cb) != 'undefined' && null != cb)
		cb.checked = false;

	cb = document.getElementById(strId12);
	if (typeof(cb) != 'undefined' && null != cb)
		cb.checked = false;

	var iVer = DCTRL.GetInstalledVersion(strApp);
	if (!(iVer >= 8 && iVer <= 12))
		return;

	var strId = "cbAppSet" + strApp + iVer.toString();

	cb = document.getElementById(strId);
	if (typeof(cb) != 'undefined' && null != cb)
		cb.checked = true;
}

function AppSetAutoDetect()
{
	if(!InstallActiveX())
	{
		if (window.location.href.toLowerCase().indexOf("axinstalled=1") < 0)
		{
			mDeleteCookie("AWS_DontPrompt_Sess")
			mDeleteCookie("AWS_AXInstalled_Sess")
		}

		if(!InstallActiveX())
			return;
	}

	if (typeof(DCTRL) == 'undefined' || typeof(DCTRL.GetInstalledVersion) == 'undefined')
		return;

	AppSetAutoDetectApp("WD");
	AppSetAutoDetectApp("XL");
	AppSetAutoDetectApp("PP");
	AppSetAutoDetectApp("OL");
	AppSetAutoDetectApp("SC");
	AppSetAutoDetectApp("VO");
	AppSetAutoDetectApp("AC");
	AppSetAutoDetectApp("FP");
	AppSetAutoDetectApp("XD");
	AppSetAutoDetectApp("RM");
	AppSetAutoDetectApp("PJ");
	AppSetAutoDetectApp("PB");

	AppSetSetStatus(1); 
}

function StrAppSetGetAppCookie(strApp)
{
	if (typeof(strApp) == 'undefined' || null == strApp)
		return "";

	if (typeof(document) == 'undefined' || typeof(document.getElementById) == 'undefined')
		return "";

	strApp = strApp.toUpperCase();
	var strId8 = "cbAppSet" + strApp + "8";
	var strId9 = "cbAppSet" + strApp + "9";
	var strId10 = "cbAppSet" + strApp + "10";
	var strId11 = "cbAppSet" + strApp + "11";
	var strId12 = "cbAppSet" + strApp + "12";

	var cb;
	var strRet = "";

	cb = document.getElementById(strId8);
	if (typeof(cb) != 'undefined' && null != cb && cb.checked)
		strRet += strApp + "8;";

	cb = document.getElementById(strId9);
	if (typeof(cb) != 'undefined' && null != cb && cb.checked)
		strRet += strApp + "9;";

	cb = document.getElementById(strId10);
	if (typeof(cb) != 'undefined' && null != cb && cb.checked)
		strRet += strApp + "10;";

	cb = document.getElementById(strId11);
	if (typeof(cb) != 'undefined' && null != cb && cb.checked)
		strRet += strApp + "11;";

	cb = document.getElementById(strId12);
	if (typeof(cb) != 'undefined' && null != cb && cb.checked)
		strRet += strApp + "12;";

	return strRet;
}

function AppSetCreateCookie()
{
	var strCookie =
		StrAppSetGetAppCookie("WD") +
		StrAppSetGetAppCookie("XL") +
		StrAppSetGetAppCookie("PP") +
		StrAppSetGetAppCookie("OL") +
		StrAppSetGetAppCookie("SC") +
		StrAppSetGetAppCookie("VO") +
		StrAppSetGetAppCookie("AC") +
		StrAppSetGetAppCookie("FP") +
		StrAppSetGetAppCookie("XD") +
		StrAppSetGetAppCookie("RM") +
		StrAppSetGetAppCookie("PJ") +
		StrAppSetGetAppCookie("PB");

	if (strCookie.length > 0 && ';' == strCookie.charAt(strCookie.length-1))
		strCookie = strCookie.substring(0, strCookie.length-1);

	var dtExpire = new Date();
	var dtNow = new Date();
	dtExpire.setTime(dtNow.getTime() + 1000 * 60 * 60 * 24 * 365 * 2); 
	mSetCookie("_ofcapp", escape(strCookie), false, dtExpire);

	if (typeof(window) == 'undefined' ||
		typeof(window.location) == 'undefined' ||
		typeof(window.location.href) == 'undefined')
	{
		return;
	}

	var strNewUrl = window.location.href;
	if (strNewUrl.indexOf('?') < 0)
		strNewUrl += '?';
	else
		strNewUrl += '&';
	strNewUrl += "postback=1";

	window.location.href = strNewUrl;
}

function AppSetParseCookieAndSetCheckboxes()
{
	var strApps = GetCookie("_ofcapp", "");
	if (typeof(strApps) == 'undefined' || null == strApps || strApps.length <= 0)
		return;

	var rgstrApps = strApps.toUpperCase().split(';');
	for (var i=0; i < rgstrApps.length; i++)
	{
		var cb = document.getElementById("cbAppSet" + rgstrApps[i]);
		if (typeof(cb) != 'undefined' && null != cb)
			cb.checked = true;
	}
}

function AppSetSetStatus(iStatus)
{
	if (0 == iStatus) 
	{
		document.getElementById("spnStoryIE").style.display = "block";
		document.getElementById("spnStoryIEDetail").style.display = "none";
		document.getElementById("spnAutoDetect").style.display = "block";
		document.getElementById("spnManual").style.display = "block";
		document.getElementById("spnSave").style.display = "none";
		document.getElementById("spnDisclaimer").style.display = "block";
		document.getElementById("spnAppList").style.display = "none";
	}
	else if (1 == iStatus) 
	{
		document.getElementById("spnStoryIE").style.display = "none";
		document.getElementById("spnStoryIEDetail").style.display = "block";
		document.getElementById("spnAutoDetect").style.display = "block";
		document.getElementById("spnManual").style.display = "none";
		document.getElementById("spnSave").style.display = "block";
		document.getElementById("spnDisclaimer").style.display = "none";
		document.getElementById("spnAppList").style.display = "block";
	}
	else 
	{
		document.getElementById("spnStoryIE").style.display = "none";
		document.getElementById("spnStoryIEDetail").style.display = "none";
		document.getElementById("spnAutoDetect").style.display = "none";
		document.getElementById("spnManual").style.display = "none";
		document.getElementById("spnSave").style.display = "block";
		document.getElementById("spnDisclaimer").style.display = "none";
		document.getElementById("spnAppList").style.display = "block";
	}
}

var SURVEY_COOKIE_NAME = "SURVEY_PROMPT";

function checkForSurvey()
{	
	if (!validSurveyVars())
		return;		

	if (Math.random() < (L_UserPercentage_Number / 100))
	{	
		var startDate = convertSurveyDate(L_StartDate_Text);
		var endDate = convertSurveyDate(L_EndDate_Text);
		endDate.setDate(endDate.getDate() + 1);	
		var dateNow = new Date();		

		if (dateNow >= startDate && dateNow < endDate)
		{		
			var prompted = GetCookie(SURVEY_COOKIE_NAME);		
			if (prompted == "")
			{
				setSurveyCookie();
				doSurveyPrompt();				
			}
		}
	}
}

function validSurveyVars()
{	
	if (typeof(L_SurveyURL_Text) != 'string')
		return false;		

	if (typeof(L_PrivacyStatement_Text) != 'string')
		return false;

	if (typeof(L_UserPercentage_Number) != 'number')
		return false;

	if (typeof(L_SurveyText_Text) != 'string')
		return false;

	if (typeof(L_TopCoordinate_Number) != 'number')
		return false;

	if (typeof(L_LeftCoordinate_Number) != 'number')
		return false;

	if (typeof(L_StartDate_Text) != 'string')
		return false;

	if (typeof(L_EndDate_Text) != 'string')
		return false;

	if (L_UserPercentage_Number < 0 || L_UserPercentage_Number > 100)
		return false;

	if (L_LeftCoordinate_Number < 0 || L_LeftCoordinate_Number > document.body.clientWidth)
		return false;

	if (L_TopCoordinate_Number < 0 || L_TopCoordinate_Number > document.body.clientHeight)
		return false;

	return true;
}

function convertSurveyDate(sDate)
{	
	var year = parseInt(sDate.substring(0,4));
	var month = parseInt(sDate.substring(5,7)) - 1;
	var day = parseInt(sDate.substring(8,10));
	return new Date(year, month, day);
}

function setSurveyCookie()
{
	var dateNow = new Date();
	var dateExpire = new Date();
	dateExpire.setTime(dateNow.getTime() + 7776000000); 
	mSetCookie(SURVEY_COOKIE_NAME, "1", false, dateExpire);	
}

function doSurveyPrompt()
{	
	var divSurvey = document.getElementById("divSurvey");
	if (typeof(divSurvey) == "undefined")
		return;		
	divSurvey.style.left = L_LeftCoordinate_Number;
	divSurvey.style.top = L_TopCoordinate_Number;	

	var divSurveyText = document.getElementById("divSurveyText");
	if (typeof(divSurveyText) == "undefined")
		return;
	divSurveyText.innerHTML = L_SurveyText_Text;

	var divSurveyPrivacyStatement = document.getElementById("divSurveyPrivacyStatement");
	if (typeof(divSurveyPrivacyStatement) == "undefined")
		return;
	divSurveyPrivacyStatement.innerHTML = L_PrivacyStatement_Text;

	divSurvey.style.display = "block";

	var btnYes = document.getElementById("btnSurveyYes");
	if (typeof(btnYes) != "undefined")
	{
		btnYes.focus();		
	}
}

function closeSurveyPrompt()
{
	var div = document.getElementById("divSurvey");
	div.style.display = "none";
}

function launchSurvey()
{	
	window.open(L_SurveyURL_Text, "_Survey", "toolbar=0,location=0,status=0,menubar=0,scrollbars=yes,resizable=1,width=600,height=400");
	closeSurveyPrompt();
}

