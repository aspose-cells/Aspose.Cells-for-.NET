var fileName = 'toconvertmyaccounts.docx';
var productName = 'psd';
var folderName = 'e98f9b3b-8aa2-4ed9-bf4b-88effc5f2494';
var featureName = '';
var callbackURL = '';
var apiURL = '/AsposeAPI';
var currentPageCount = 1;
var totalPages = 1;
var currentSelectedPage = 1;
var customPageList = [];
var IsLoadingGif = false;
var prevoiusIndx = -1;
var imagedata = [];
var ZoomValue = 0.65;
var PageWidth = '65';

function UpdatePager() {
	//if (customPageList.length > 1) {
	//	ZoomPages(ZoomValue);
	//}

	TotalDocumentPages = totalPages;
	document.getElementById('spantoolpager').innerHTML = currentSelectedPage + ' of ' + totalPages;
	document.getElementById('inputcurrentpage').value = '';

	for (var i = 0; i <= totalPages; i++) {
		var element = document.getElementById('imgt-page-' + i);
		if (element !== undefined && element !== null) {
			element.className = '';
			if (i === currentSelectedPage) {
				element.className = 'selectedthumbnail';
				element.scrollIntoView();
			}
		}
	}
	//console.log('in at end of UpdatePager();');
}

function ZoomPages(zoomOption) {
	ZoomValue = parseFloat(ZoomValue).toFixed(2);
	//console.log('--------------  zoomOption: ' + zoomOption);
	//console.log('Befor ZoomValue: ' + ZoomValue);
	if (zoomOption === '+') {
		if (ZoomValue >= 3.00) {
			//console.log('>=3.00: ' + ZoomValue);
			ZoomValue = parseFloat(ZoomValue) + (0.50);
		}
		else if (ZoomValue >= 0.25) {
			ZoomValue = parseFloat(ZoomValue) + (0.25);
			//console.log('>=0.25: ' + ZoomValue);
		}
		else {
			//console.log('+.05 ZoomValue: ' + ZoomValue);
			ZoomValue = parseFloat(ZoomValue) + (0.05);
		}
	}
	else if (zoomOption === '-') {
		if (ZoomValue >= 3.00) {
			//console.log('>=3.00: ' + ZoomValue);
			ZoomValue -= 0.50;
		}
		else if (ZoomValue > 0.25) {
			//console.log('>=0.25: ' + ZoomValue);
			ZoomValue -= 0.25;
		}
		else {
			//console.log('-.05 ZoomValue: ' + ZoomValue);
			ZoomValue -= 0.05;
		}
	}
	else {
		//console.log('else zoomOption: ' + zoomOption);
		ZoomValue = parseFloat(zoomOption);
	}

	if (ZoomValue < 0.05) {
		ZoomValue = 0.05;
	}
	else if (ZoomValue > 6) {
		ZoomValue = 6;
	}

	//console.log('Before Parse ZoomValue: ' + ZoomValue);
	ZoomValue = parseFloat(ZoomValue).toFixed(2);
	//console.log('After ZoomValue: ' + ZoomValue);
	var lstdvPages = document.getElementsByName("dvInnerPages");

	for (var i = 0; i < lstdvPages.length; i++) {
		document.getElementById("img-page-" + (i + 1)).style.cssText = "width: 100%;";
		PageWidth = (100 * ZoomValue);
		lstdvPages[i].style.cssText = "border: 1px solid #000000; margin: 20px; display: inline-block; position: relative; 2px; box-shadow: #333 4px 4px 4px; border-radius: 4px; height: auto; width: " + PageWidth + "%;";

		//if (ZoomValue > 1.40 || ZoomValue < 0.70) {
		//	lstdvPages[i].style.cssText = "float: left; border: 1px solid #058cda; margin: 10px; border-radius: 2px; height: auto; width: " + (100 * ZoomValue) + "%;";
		//}
		//else {
		//	lstdvPages[i].style.cssText = "float: left; border: 1px solid #058cda; margin: 10px; border-radius: 2px;";
		//}
	}
}