let xs1;
let xs2;
let uniqueid1;
let uniqueid2;
const imagediv1 = "imagedive1";
const imagediv2 = "imagedive2";
const basiczorder = 5678;
let sheets1 = [];
let sheets2 = [];
const file1 = decodeURIComponent(getQueryString("FileName1"));
const file2 = decodeURIComponent(getQueryString("FileName2"));
const folderName = decodeURIComponent(getQueryString("FolderName"));
const callbackURL = decodeURIComponent(getQueryString("CallbackURL"));
const APIBasePath = decodeURIComponent(getQueryString("APIBasePath"));

$(function () {
    $("#left-filename").text(file1);
    $("#right-filename").text(file2);

    const baseUrl = `${APIBasePath}ComparisonApi/DetailJson`;
    const finalUrl = `${baseUrl}?file1=${encodeURIComponent(file1)}&file2=${encodeURIComponent(file2)}&folder=${encodeURIComponent(folderName)}`;
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

    function errorFunction() {
        alert("error");
        closeWindow();
    }

    function successFunction(data) {
        const jsonData1 = JSON.parse(data.File1Json);
        const jsonData2 = JSON.parse(data.File2Json);

        if (jsonData1.Error) {
            alert(jsonData1.Error);
            closeWindow();
            return;
        }

        if (jsonData2.Error) {
            alert(jsonData2.Error);
            closeWindow();
            return;
        }

        load(jsonData1, jsonData2);
    }
});

function load(jsonData1, jsonData2) {
    uniqueid1 = jsonData1.uniqueid;
    uniqueid2 = jsonData2.uniqueid;
    sheets1 = jsonData1.data;
    sheets2 = jsonData2.data;
    const imageUrl = APIBasePath + "ComparisonApi/ImageUrl";
    xs1 = x_spreadsheet('#xs-div1', {
        showToolbar: false,
        showGrid: true,
        mode: 'read',
        showContextmenu: false,
        view: {
            height: () => {
                return document.documentElement.clientHeight - 56 - 20;
            },
            width: () => {
                return document.documentElement.clientWidth / 2;
            }
        }
    }).loadData(sheets1);
    xs2 = x_spreadsheet('#xs-div2', {
        showToolbar: false,
        showPartToolbar: false,
        showGrid: true,
        mode: 'read',
        showContextmenu: false,
        view: {
            height: () => {
                return document.documentElement.clientHeight - 56 - 20;
            },
            width: () => {
                return document.documentElement.clientWidth / 2;
            }
        }
    }).loadData(sheets2);

    const overLayerContentEl1 = $("#xs-div1 .x-spreadsheet-overlayer-content");
    overLayerContentEl1.append('<div id="' + imagediv1 + '" style="position:relative" /> ');
    const imageDivEl1 = $("#" + imagediv1);

    const overLayerContentEl2 = $("#xs-div2 .x-spreadsheet-overlayer-content");
    overLayerContentEl2.append('<div id="' + imagediv2 + '" style="position:relative" /> ');
    const imageDivEl2 = $("#" + imagediv2);

    xs1.uniqueid = uniqueid1;
    xs1.setImageInfo(imageDivEl1, imageUrl, basiczorder);

    xs2.uniqueid = uniqueid2;
    xs2.setImageInfo(imageDivEl2, imageUrl, basiczorder);

    const oldSwapFunc1 = xs1.bottombar.swapFunc;
    const oldSwapFunc2 = xs2.bottombar.swapFunc;

    xs1.bottombar.swapFunc = function (id) {
        oldSwapFunc1(id);

        if (sheets2.length > id) {
            if (xs2.bottombar.activeEl !== null)
                xs2.bottombar.activeEl.toggle();
            xs2.bottombar.activeEl = xs2.bottombar.items[id];
            xs2.bottombar.activeEl.toggle();
            oldSwapFunc2(id);
        }

        if (xs1.sheet.data.autoFilter.filters.length > 0) {
            xs1.sheet.data.resetAutoFilter();
            xs1.sheet.data.deleteExceptRowHideForAutoFilter();
        }
    }
    xs1.setActiveSheetByName(jsonData1.actname).setActiveCell(jsonData1.actrow, jsonData1.actcol);

    xs2.bottombar.swapFunc = function (id) {
        oldSwapFunc2(id);

        if (sheets1.length > id) {
            if (xs1.bottombar.activeEl !== null)
                xs1.bottombar.activeEl.toggle();
            xs1.bottombar.activeEl = xs1.bottombar.items[id];
            xs1.bottombar.activeEl.toggle();
            oldSwapFunc1(id);
        }

        if (xs2.sheet.data.autoFilter.filters.length > 0) {
            xs2.sheet.data.resetAutoFilter();
            xs2.sheet.data.deleteExceptRowHideForAutoFilter();
        }
    }
    xs2.setActiveSheetByName(jsonData2.actname).setActiveCell(jsonData2.actrow, jsonData2.actcol);

    const horizontalScrollbarEl1 = $("#xs-div1 .x-spreadsheet-scrollbar.horizontal");
    const horizontalScrollbarEl2 = $("#xs-div2 .x-spreadsheet-scrollbar.horizontal");
    let flagX = 0;
    horizontalScrollbarEl1.mouseover(() => {
        flagX = 1;
        horizontalScrollbarEl1.scroll(() => {
            if (flagX === 1) {
                const left = xs1.sheet.data.scroll.x;
                imageDivEl1.css("left", -left);
                imageDivEl2.css("left", -left);
                xs2.sheet.horizontalScrollbar.move({left: left});
            }
        });
    });
    horizontalScrollbarEl2.mouseover(() => {
        flagX = 2;
        horizontalScrollbarEl2.scroll(() => {
            if (flagX === 2) {
                const left = xs2.sheet.data.scroll.x;
                imageDivEl1.css("left", -left);
                imageDivEl2.css("left", -left);
                xs1.sheet.horizontalScrollbar.move({left: left});
            }
        });
    });

    const verticalScrollbarEl1 = $("#xs-div1 .x-spreadsheet-scrollbar.vertical");
    const verticalScrollbarEl2 = $("#xs-div2 .x-spreadsheet-scrollbar.vertical");
    const overlayerEl1 = xs1.sheet.overlayerEl;
    const overlayerEl2 = xs2.sheet.overlayerEl;
    let flagY = 0;
    overlayerEl1.on('mousewheel.stop', () => {
        flagY = 1;
        verticalScrollbarEl1Scroll();
    });
    overlayerEl2.on('mousewheel.stop', () => {
        flagY = 2;
        verticalScrollbarEl2Scroll();
    });
    verticalScrollbarEl1.mouseover(() => {
        flagY = 1;
        verticalScrollbarEl1.scroll(() => {
            verticalScrollbarEl1Scroll();
        });
    });
    verticalScrollbarEl2.mouseover(() => {
        flagY = 2;
        verticalScrollbarEl2.scroll(() => {
            verticalScrollbarEl2Scroll();
        });
    });

    function verticalScrollbarEl1Scroll() {
        if (flagY === 1) {
            const top = xs1.sheet.data.scroll.y;
            imageDivEl1.css("top", -top);
            imageDivEl2.css("top", -top);
            xs2.sheet.verticalScrollbar.move({top: top});
        }
    }

    function verticalScrollbarEl2Scroll() {
        if (flagY === 2) {
            const top = xs2.sheet.data.scroll.y;
            imageDivEl1.css("top", -top);
            imageDivEl2.css("top", -top);
            xs1.sheet.verticalScrollbar.move({top: top});
        }
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

function getQueryString(name) {
    const reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    const r = window.location.search.substr(1).match(reg);
    if (r != null) return decodeURI(r[2]);
    return null;
}

function closeWindow() {
    if (window.parent && window.parent.closeIframe) {
        parent.fileDrop.reset();
        parent.fileDrop2.reset();
        window.parent.closeIframe();
    } else {
        window.location.href = callbackURL;
    }
}