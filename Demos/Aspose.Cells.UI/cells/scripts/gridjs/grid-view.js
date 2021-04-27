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
        url: encodeURI(finalUrl),
        timeout: 600000,
        cache: false,
        beforeSend: LoadFunction,
        error: errorFunction,
        success: successFunction
    });

    function LoadFunction() {
    }

    function errorFunction(err) {
        console.error(err);

        if (err !== undefined && err.Status !== undefined) {
            alert(err.Status);
            closeWindow();
            return;
        }

        if (err.responseJSON !== undefined && err.responseJSON.Status !== undefined) {
            alert(err.responseJSON.Status);
            closeWindow();
            return;
        }

        alert("Error");
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
        showPartToolbar: true,
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
    xs.setActiveSheetByName(jsonData.actname).setActiveCell(jsonData.actrow, jsonData.actcol);

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