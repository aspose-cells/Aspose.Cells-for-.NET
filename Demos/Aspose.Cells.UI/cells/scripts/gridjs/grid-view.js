let xs;
let uniqueid;
const imagediv = "imagedive";
const basiczorder = 5678;
let sheets = [];
const file = decodeURIComponent(getQueryString("FileName"));
const folderName = decodeURIComponent(getQueryString("FolderName"));
const callbackURL = decodeURIComponent(getQueryString("CallbackURL"));
const APIBasePath = decodeURIComponent(getQueryString("APIBasePath"));

$(function () {
    $("#file_name").text(file);

    const baseUrl = `${APIBasePath}AsposeCellsViewer/DetailJson`;
    const finalUrl = `${baseUrl}?file=${encodeURIComponent(file)}&folderName=${encodeURIComponent(folderName)}`;
    $.ajax({
        url: finalUrl,
        timeout: 59000,
        cache: false,
        beforeSend: LoadFunction,
        error: errorFunction,
        success: successFunction
    });

    function LoadFunction() {
    }

    function errorFunction() {
        alert("error");
        closeWindow();
    }

    function successFunction(data) {
        const jsonData = JSON.parse(data);
        if (jsonData.Error) {
            alert(jsonData.Error);
            closeWindow();
        } else {
            load(jsonData);
        }
    }
});

function removeTags(tagName, tagClass) {
    const tagElements = document.getElementsByTagName(tagName);
    const count = tagElements.length;
    if (count >= 1) {
        for (let m = count - 1; m >= 0; m--) {
            if (tagElements[m].parentElement.className === tagClass) {
                tagElements[m].parentNode.parentNode.removeChild(tagElements[m].parentNode);
            }
        }
    }
}

function load(jsonData) {
    // record uniqueid
    uniqueid = jsonData.uniqueid;
    sheets = jsonData.data;
    // console.log("sheets", sheets);
    const imageUrl = APIBasePath + "AsposeCellsViewer/Image";
    // x.spreadsheet.locale('zh-cn');
    xs = x_spreadsheet('#xs-div', {
        showToolbar: false,
        showGrid: true,
        mode: 'read',
        showContextmenu: false,
        view: {
            height: () => {
                return document.documentElement.clientHeight - 96;
            }
        }
    }).loadData(sheets);

    $(".x-spreadsheet-overlayer-content").append('<div id="' + imagediv + '" style="position:relative" /> ');
    const imageDivEl = $("#" + imagediv);

    xs.uniqueid = uniqueid;
    xs.setImageInfo(imageDivEl, imageUrl, basiczorder);

    // need to extend swapFunc
    const oldSwapFunc = xs.bottombar.swapFunc;
    xs.bottombar.swapFunc = function (id) {
        // xs.sheet.data.settings.showGrid = sheets[id].showGrid;
        oldSwapFunc(id);
        if (xs.sheet.data.autoFilter.filters.length > 0) {
            xs.sheet.data.resetAutoFilter();
            xs.sheet.data.deleteExceptRowHideForAutoFilter();
        }
    }
    xs.setActiveSheet(jsonData.actsheet).setActiveCell(jsonData.actrow, jsonData.actcol);

    // var i1=new resizeableImage($('#img1'),0);
    // xs.loadData(jsondata);
    $(".x-spreadsheet-scrollbar.horizontal").scroll(function () {
        // console.log("horizontal move");
        imageDivEl.css("left", -xs.sheet.data.scroll.x);
        const myDiv = this;
        if (myDiv.offsetWidth + myDiv.scrollLeft >= myDiv.scrollWidth) {
            scrolledToRight();
        }
    });

    const verticalScrollbarEl = $(".x-spreadsheet-scrollbar.vertical");
    verticalScrollbarEl.scroll(function () {
        // xs.datas[0].scroll
        // console.log("vertical move" + this.scrollTop + ",actual off:" + xs.sheet.data.scroll);
        imageDivEl.css("top", -xs.sheet.data.scroll.y);
        const myDiv = this;
        if (myDiv.offsetHeight + myDiv.scrollTop >= myDiv.scrollHeight) {
            scrolledToBottom();
        }
    });

    function scrolledToRight() {
        // console.log("end reach horizontal");
    }

    function scrolledToBottom() {
        // console.log("end reach vertical");
    }

    $.fn.scrollEnd = function (callback, timeout) {
        $(this).scroll(function () {
            const $this = $(this);
            if ($this.data('scrollTimeout')) {
                clearTimeout($this.data('scrollTimeout'));
            }
            $this.data('scrollTimeout', setTimeout(callback, timeout));
        });
    }
}

function save(isImage = false) {
    window.location = encodeURI(APIBasePath + `AsposeCellsViewer/DownloadDocument?file=${encodeURIComponent(file)}&folderName=${encodeURIComponent(folderName)}&isImage=${isImage}`);
}

function print() {
    const zoom = 1;
    const chrome = true;
    const newWin = window.open("", "");
    if (chrome) {
        newWin.window.focus();
        newWin.onbeforeunload = function () {
            return 'Please use the cancel button on the left side of the print preview to close this window.\n';
        }
    }
    newWin.document.writeln('<html lang="en"><head><title>Print Preview</title>');
    newWin.document.writeln('</head>');
    newWin.document.writeln('<body style=\"zoom:' + zoom + ';\" onload="window.print();" style="margin: 0">');
    newWin.document.writeln('<form>');

    let gHtml;
    const vt = document.getElementById("xs-div");
    const fCol = document.getElementById("aaaa_FCOL");
    if (fCol == null) {
        gHtml = "<TABLE>" + "<TR>" + "<TD>" + vt.outerHTML + "</TD>" + "</TR>" + "</TABLE>";
    }

    newWin.document.writeln(gHtml);
    newWin.document.writeln('</form></body></HTML>');
    if (chrome) {
        newWin.document.close();
    } else {
        newWin.location.reload();
    }
}

function fallbackCopyTextToClipboard(text) {
    const textArea = document.createElement("textarea");
    textArea.value = text;

    // Avoid scrolling to bottom
    textArea.style.position = "fixed";
    textArea.style.top = "0";
    textArea.style.left = "0";

    document.body.appendChild(textArea);
    textArea.focus();
    textArea.select();

    document.execCommand('copy');

    document.body.removeChild(textArea);
}

function copyTextToClipboard(text) {
    if (!navigator.clipboard) {
        fallbackCopyTextToClipboard(text);
        return;
    }
    navigator.clipboard.writeText(text).then();
}

function getQueryString(name) {
    const reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    const r = window.location.search.substr(1).match(reg);
    if (r != null) return decodeURI(r[2]);
    return null;
}

function closeWindow() {
    if (window.parent && window.parent.closeIframe) {
        parent.fileDrop.reset();
        window.parent.closeIframe();
    } else {
        window.location.href = callbackURL;
    }
}