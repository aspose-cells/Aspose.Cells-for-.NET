let xs;
let uniqueid;
const imagediv = "imagedive";
const basiczorder = 5678;
let sheets = [];
let file = decodeURIComponent(getQueryString("FileName"));
let folderName = decodeURIComponent(getQueryString("FolderName"));
const callbackURL = decodeURIComponent(getQueryString("CallbackURL"));
const APIBasePath = decodeURIComponent(getQueryString("APIBasePath"));
const Method = decodeURIComponent(getQueryString("Method"));

$(function () {
    $("#file_name").text(file);

    if (Method === "new")
        getNewWorkbook();
    if (Method === "edit")
        getDetailJson();
});

function getDetailJson() {
    const baseUrl = `${APIBasePath}AsposeCellsEditor/DetailJson`;
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
}

function getNewWorkbook() {
    const url = `${APIBasePath}AsposeCellsEditor/NewWorkbook`;
    $.ajax({
        url: url,
        success: (data) => {
            file = data.FileName;
            folderName = data.FolderName;
            getDetailJson();
        },
        error: (e) => {
            console.error(e);
            alert("error");
            closeWindow();
        }
    });
}

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
    const imageUrl = APIBasePath + "AsposeCellsEditor/Image";
    const updateUrl = APIBasePath + "AsposeCellsEditor/UpdateCell";
    xs = x_spreadsheet('#xs-div', {
        updateMode: 'server',
        updateUrl: updateUrl,
        mode: 'edit',
        view: {
            height: () => {
                return document.documentElement.clientHeight - 56;
            }
        }
    }).loadData(sheets).updateCellError((msg) => {
        alert(msg);
    });

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

function downloadDocument(outputTypeEnum, FolderName, FileName) {
    let outputType;
    switch (outputTypeEnum) {
        case 0:
            outputType = "Original";
            break;
        case 1:
            outputType = "XLSX";
            break;
        case 2:
            outputType = "PDF";
            break;
        case 3:
            outputType = "HTML";
            break;
        default:
            outputType = "Original";
    }
    window.location = encodeURI(APIBasePath + `AsposeCellsEditor/DownloadDocument?file=${encodeURIComponent(FileName)}&folderName=${encodeURIComponent(FolderName)}&outputType=${encodeURIComponent(outputType)}`);
    closeMask().then();
}

async function zip(str) {
    const geoJsonGz = pako.gzip(str);
    return new Blob([geoJsonGz]);
}

function save(outputTypeEnum) {
    if (!xs.buffer.isFinish()) {
        showMask("The update operation is being processed, please try again later.");

        setTimeout(() => {
            closeMask().then();
        }, 1500);
        return;
    }

    try {
        showMask();

        const datas = xs.datas;
        delete datas.history;
        delete datas.search;
        delete datas.images;
        delete datas.shapes;
        const jsonData = {
            "sheetname": xs.sheet.data.name,
            "actrow": xs.sheet.data.selector.ri,
            "actcol": xs.sheet.data.selector.ci,
            "datas": datas
        };

        const data = {
            "p": JSON.stringify(jsonData),
            "uid": uniqueid,
            "file": file,
        };
        zip(JSON.stringify(data)).then((zipData) => {
            const url = APIBasePath + "AsposeCellsEditor/Download";
            $.ajax({
                url: url,
                type: "post",
                header: {
                    'contentType': 'application/octet-stream',
                    'Content-Encoding': 'gzip'
                },
                data: zipData,
                processData: false,
                success: (res) => {
                    if (res.StatusCode === 200) {
                        downloadDocument(outputTypeEnum, res.FolderName, res.FileName);
                    } else {
                        closeMask().then(() => {
                            alert("Download failed, please try again");
                        });
                    }
                },
                error: (err) => {
                    console.error(err);
                    closeMask().then(() => {
                        alert("Download failed, please try again");
                    });
                }
            });
        });
    } catch (e) {
        console.error(e);
        closeMask().then(() => {
            alert("Download failed, please try again");
        });
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

function showMask(msg = "Downloading, please wait...") {
    const mask_bg = document.createElement("div");
    mask_bg.id = "aspose_mask_bg";
    mask_bg.style.position = "absolute";
    mask_bg.style.top = "0px";
    mask_bg.style.left = "0px";
    mask_bg.style.width = "100%";
    mask_bg.style.height = "100%";
    mask_bg.style.backgroundColor = "#777";
    mask_bg.style.opacity = "0.6";
    mask_bg.style.zIndex = "10001";
    document.body.appendChild(mask_bg);

    const mask_msg = document.createElement("div");
    mask_msg.style.width = "460px";
    mask_msg.style.position = "absolute";
    mask_msg.style.top = "33%";
    mask_msg.style.backgroundColor = "white";
    mask_msg.style.border = "#336699 1px solid";
    mask_msg.style.textAlign = "center";
    mask_msg.style.fontSize = "medium";
    mask_msg.style.textAlign = "center";

    mask_msg.style.padding = "1.5em 4em 1.5em 4em";
    mask_msg.innerText = msg;
    const left = (document.documentElement.clientWidth - 460) / 2;
    mask_msg.style.left = left + "px";
    mask_bg.appendChild(mask_msg);
}

async function closeMask() {
    const mask_bg = document.getElementById("aspose_mask_bg");
    if (mask_bg != null)
        mask_bg.parentNode.removeChild(mask_bg);
}