const VIEWABLE_EXTENSIONS = [
    'XLS', 'XLSX', 'XLSM', 'XLSB', 'ODS'
];

// filedrop component
var fileDrop = {};
var fileDrop2 = {};

$.extend($.expr[':'], {
    isEmpty: function (e) {
        return e.value === '';
    }
});

// Restricts input for the set of matched elements to the given inputFilter function.
(function ($) {
    $.fn.inputFilter = function (inputFilter) {
        return this.on("input keydown keyup mousedown mouseup select contextmenu drop", function () {
            if (inputFilter(this.value)) {
                this.oldValue = this.value;
                this.oldSelectionStart = this.selectionStart;
                this.oldSelectionEnd = this.selectionEnd;
            } else if (this.hasOwnProperty("oldValue")) {
                this.value = this.oldValue;
                this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);
            } else {
                this.value = "";
            }
        });
    };
}(jQuery));

function showLoader() {
    $('.progress > .progress-bar').html('15%');
    $('.progress > .progress-bar').css('width', '15%');
    $('#loader').removeClass("hidden");
    hideAlert();
}

function hideLoader() {
    $('#loader').addClass("hidden");
}

function generateViewerLink(data) {
    var id = data.FolderName !== undefined ? data.FolderName : data.id;
    return encodeURI(o.ViewerPath +
        'FolderName=' +
        id +
        '&CallbackURL=' +
        o.AppURL +
        "&APIBasePath=" +
        o.APIBasePath) + '&FileName=' +
        encodeURIComponent(data.FileName);
}

function generateEditEditorLink(data) {
    var id = data.FolderName !== undefined ? data.FolderName : data.id;
    return encodeURI(
        o.EditorPath +
        'FolderName=' +
        id +
        '&CallbackURL=' +
        o.AppURL +
        "&APIBasePath=" +
        o.APIBasePath +
        "&Method=edit"
        ) + '&FileName=' +
        encodeURIComponent(data.FileName);
}

function generateNewEditorLink(data) {
    var id = data.FolderName !== undefined ? data.FolderName : data.id;
    return encodeURI(
        o.EditorPath +
        'FileName=book1.xlsx&FolderName=' +
        id +
        '&CallbackURL=' +
        o.AppURL +
        "&APIBasePath=" +
        o.APIBasePath +
        "&Method=new"
    );
}

function sendPageView(url) {
    if ('ga' in window)
        try {
            var tracker = ga.getAll()[0];
            if (tracker !== undefined) {
                tracker.send('pageview', url);
            }
        } catch (e) {
            /**/
        }
}

function workSuccess(data, textStatus, xhr) {
    hideLoader();

    if (data.StatusCode === 200) {
        if (data.FileProcessingErrorCode !== undefined && data.FileProcessingErrorCode !== 0) {
            showAlert(o.FileProcessingErrorCodes[data.FileProcessingErrorCode]);
            return;
        }

        $('#WorkPlaceHolder').addClass('hidden');
        $('.appfeaturesectionlist').addClass('hidden');
        $('.howtolist').addClass('hidden');
        $('.app-features-section').addClass('hidden');
        $('.app-product-section').addClass('hidden');
        $('#TextPlaceHolder').addClass('hidden');

        $('#DownloadPlaceHolder').removeClass('hidden');
        $('#OtherApps').removeClass('hidden');

        if (o.ReturnFromViewer === undefined) {
            const pos = o.AppDownloadURL.indexOf('?');
            const url = pos === -1 ? o.AppDownloadURL : o.AppDownloadURL.substring(0, pos);
            sendPageView(url);
        }

        const url = encodeURI(o.APIBasePath + `Common/DownloadFile/${data.FolderName}`) + `?file=${encodeURIComponent(data.FileName)}`;
        $('#DownloadButton').attr("href", url);
        o.DownloadUrl = url;

        if (o.ShowViewerButton) {
            let viewerlink = $('#ViewerLink');
            let dotPos = data.FileName.lastIndexOf('.');
            let ext = dotPos >= 0 ? data.FileName.substring(dotPos + 1).toUpperCase() : null;
            if (ext !== null && viewerlink.length && VIEWABLE_EXTENSIONS.indexOf(ext) !== -1) {
                viewerlink.on('click', function (evt) {
                    evt.preventDefault();
                    evt.stopPropagation();

                    requestViewer(data);
                });
            } else {
                viewerlink.hide();
                $(viewerlink[0].parentNode.previousElementSibling).hide(); // div.clearfix
            }
        }

        if (o.ShowDeleteButton) {
            const delBtn = $("#DeleteButton");
            delBtn.click(function () {
                ShowDelModal(data.FolderName);
            });
        }
    } else {
        showAlert(data.Status);
        ShowReportModal(data);
    }
}

function sendEmail() {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    var email = $('#EmailToInput').val();
    if (!email || !re.test(String(email).toLowerCase())) {
        window.alert('Please specify the valid email address!');
        return;
    }

    var data = {
        appname: o.AppName,
        email: email,
        url: o.DownloadUrl,
        title: $('#ProductTitle')[0].innerText
    };

    $('#sendEmailModal').modal('hide');
    $('#sendEmailButton').addClass('hidden');

    $.ajax({
        method: 'POST',
        url: '/cells/sendemail',
        data: data,
        dataType: 'json',
        success: (data) => {
            showMessage(data.message);
        },
        complete: () => {
            $('#sendEmailButton').removeClass('hidden');
            hideLoader();
        },
        error: (data) => {
            showAlert(data.responseJSON.message);
        }
    });
}

function sendFeedback(text) {
    var msg = (typeof text === 'string' ? text : $('#feedbackText').val());
    if (!msg || msg.match(/^\s+$/) || msg.length > 1000) {
        return;
    }

    var data = {
        appname: o.AppName,
        text: msg
    };

    if (!text) {
        if ('ga' in window) {
            try {
                var tracker = window.ga.getAll()[0];
                if (tracker !== undefined) {
                    tracker.send('event', {
                        'eventCategory': 'Social',
                        'eventAction': 'feedback-in-download'
                    });
                }
            } catch (e) {
            }
        }
    }

    $.ajax({
        method: "POST",
        url: '/cells/sendfeedback',
        data: data,
        dataType: "json",
        success: (data) => {
            showMessage(data.message);
            $('#feedback').hide();
        },
        error: (data) => {
            showAlert(data.responseJSON.message);
        }
    });
}

function hideAlert() {
    $('#alertMessage').addClass("hidden");
    $('#alertMessage').text("");
    $('#alertSuccess').addClass("hidden");
    $('#alertSuccess').text("");
}

function showAlert(msg) {
    hideLoader();
    $('#alertMessage').html(msg);
    $('#alertMessage').removeClass("hidden");
    $('#alertMessage').fadeOut(100).fadeIn(100).fadeOut(100).fadeIn(100);
}

function showMessage(msg) {
    hideLoader();
    $('#alertSuccess').text(msg);
    $('#alertSuccess').removeClass("hidden");
}

(function ($) {
    $.QueryString = (function (paramsArray) {
        let params = {};

        for (let i = 0; i < paramsArray.length; ++i) {
            let param = paramsArray[i]
                .split('=', 2);

            if (param.length !== 2)
                continue;

            params[param[0]] = decodeURIComponent(param[1].replace(/\+/g, " "));
        }

        return params;
    })(window.location.search.substr(1).split('&'))
})(jQuery);

function progress(evt) {
    if (evt.lengthComputable) {
        var max = evt.total;
        var current = evt.loaded;

        var percentage = Math.round((current * 100) / max);
        percentage = (percentage < 15 ? 15 : percentage) + '%';

        $('.progress > .progress-bar').html(percentage);
        $('.progress > .progress-bar').css('width', percentage);
    }
}

function removeAllFileBlocks() {
    fileDrop.droppedFiles.forEach(function (item) {
        $('#fileupload-' + item.id).remove();
    });
    fileDrop.droppedFiles = [];
    hideLoader();
}

function openIframe(url, fakeUrl, pageViewUrl) {
    // push fake state to prevent from going back
    window.history.pushState(null, null, fakeUrl);

    // remove body scrollbar
    $('body').css('overflow-y', 'hidden');

    // create iframe and add it into body
    var div = $('<div id="iframe-wrap"></div>');
    $('<iframe>', {
        src: url,
        id: 'iframe-document',
        frameborder: 0,
        scrolling: 'yes'
    }).appendTo(div);
    div.appendTo('body');
    sendPageView(pageViewUrl);
}

function closeIframe() {
    removeAllFileBlocks();
    $('div#iframe-wrap').remove();
    $('body').css('overflow-y', 'auto');
}

function request(url, data) {
    showLoader();
    $.ajax({
        method: 'POST',
        url: url,
        data: data,
        processData: false,
        contentType: false,
        cache: false,
        timeout: 600000,
        success: workSuccess,
        xhr: function () {
            var myXhr = $.ajaxSettings.xhr();
            if (myXhr.upload)
                myXhr.upload.addEventListener('progress', progress, false);
            return myXhr;
        },
        error: function (err) {
            if (err.data !== undefined && err.data.Status !== undefined)
                showAlert(err.data.Status);
            else
                showAlert("Error " + err.status + ": " + err.statusText);
        }
    });
}

function ShowReportModal(data) {
    $('#errorTitle').text(data.Status);
    $('#errorModal').modal('show');
    $("#errorFolderName").val(data.FolderName);
    $("#errorAction").val(data.Text);
    $("#errorMessage").val(data.Status);
}

function ShowDelModal(folderName) {
    $('#delModal').modal({
        backdrop: "static",
        keyboard: false,
        show: true
    });

    $("#confirmDelBtn").unbind("click").bind("click", function () {
        const DownloadButton = $('#DownloadButton');
        DownloadButton.removeAttr("href");
        DownloadButton.removeAttr("onclick");

        reqDel(folderName);
    });
}

function reqDel(folderName) {
    $("#confirmDelBtn").attr("disabled", "true");

    const url = o.APIBasePath + "Common/Delete";
    $.ajax({
        method: 'POST',
        url: url,
        data: JSON.stringify({FolderName: folderName}),
        contentType: 'application/json',
        cache: false,
        timeout: 600000,
        success: () => {
            delRes(true);
        },
        error: () => {
            delRes(false);
        }
    });
}

function delRes(res) {
    $('#delModal').modal("hide");
    $("#confirmDelBtn").removeAttr("disabled");

    const msg = res ? "Your files have been deleted successfully!" : "Deletion failed! Please try again later";

    $("#delResModalBody").html(msg);

    $("#delResModal").modal({
        backdrop: "static",
        keyboard: false,
        show: true
    });

    setTimeout(function () {
        $("#delResModal").modal("hide")
    }, 1500);

    if (res) {
        $("#DeleteButton").unbind("click");

        $('#delResModal').on("hide.bs.modal", function () {
            window.location.reload();
        });
    }
}

function requestErrorReport() {
    if ($("#errorEmail").val().trim() == "") {
        return;
    }
    var reg = new RegExp("^[a-z0-9]+([._\\-]*[a-z0-9])*@([a-z0-9]+[-a-z0-9]*[a-z0-9]+.){1,63}[a-z0-9]+$");
    if (!reg.test($("#errorEmail").val())) {
        alert("email is invalid");
        return;
    }
    if ($('#forumPrivate').prop('checked')) {
        $("#errorPrivate").val("true");
    } else {
        $("#errorPrivate").val("false");
    }
    var url = o.APIBasePath + "Report/Error";
    $.ajax({
        method: 'POST',
        url: url,
        data: $("#errorForm").serialize(),
        contentType: 'application/x-www-form-urlencoded',
        cache: false,
        timeout: 600000,
        success: (d) => {
            if (d.StatusCode == 200) {
                $('#errorModal').modal('hide');
                $('#lnkForums').attr("href", d.ForumLink);
                $('#reportResultModal').modal('show');
            } else {
                alert(d.Status);
            }
        },
        error: (err) => {
            //alert("Internal Server Error");
        }
    });
}

function requestConversion() {
    let data = fileDrop.prepareFormData();
    if (data === null)
        return;

    let url = o.APIBasePath + 'AsposeCellsConversion/Convert?outputType=' + $('#saveAs').val();
    request(url, data);
}

function requestParser() {
    let data = fileDrop.prepareFormData();
    if (data === null)
        return;

    let url = o.APIBasePath + 'AsposeCellsParser/Parse';
    request(url, data);
}

function requestMetadata(data) {
    let url = o.APIBasePath + 'AsposeCellsMetadata/Properties';

    $.ajax({
        method: 'POST',
        url: url,
        data: JSON.stringify(data),
        contentType: 'application/json',
        cache: false,
        timeout: 600000,
        success: (d) => {
            $.metadata(d, data.id, data.FileName);
        },
        error: (err) => {
            if (err.responseJSON !== undefined && err.responseJSON.Status !== undefined) {
                showAlert(err.responseJSON.Status);
                ShowReportModal(err.responseJSON);
            } else {
                showAlert("Error " + err.status + ": " + err.statusText);
            }
        }
    });
}

function requestViewer(data) {
    let pathname = window.location.pathname;
    openIframe(generateViewerLink(data), pathname, '/cells/view');
}

function validateWatermark() {
    if ($("#textWatermark").val().length)
        return true;
    showAlert(o.validationWatermark);
    return false;
}

function requestWatermark() {
    let data = fileDrop.prepareFormData();
    if (data === null)
        return;

    if (!validateWatermark())
        return;

    let url = o.APIBasePath +
        'AsposeCellsWatermark/AddTextWatermark?watermarkText=' + encodeURI($("#textWatermark").val()) +
        "&watermarkColor=" + encodeURI($("#pickcolor").val().substr(1));
    request(url, data);
}

function requestMerger() {
    let data = fileDrop.prepareFormData(2, o.MaximumUploadFiles);
    if (data === null)
        return;

    let url = o.APIBasePath + 'AsposeCellsMerger/Merge?outputType=' + $('#saveAs').val() + '&mergerType=' + $("input[name='mergeTo']:checked").val();
    request(url, data);
}

function requestAnnotation() {
    let data = fileDrop.prepareFormData();
    if (data === null)
        return;

    let url = o.APIBasePath + 'AsposeCellsAnnotation/Remove';
    request(url, data);
}

function validateSearch() {
    if ($("#searchQuery").val().length)
        return true;
    showAlert(o.validationSearchMessage);
    return false;
}

function requestSearch() {
    if (!validateSearch())
        return;

    let data = fileDrop.prepareFormData();
    if (data === null)
        return;

    let url = o.APIBasePath + 'AsposeCellsSearch/Search?query=' + encodeURI($('#searchQuery').val());
    request(url, data);
}

function validateUnlock() {
    if ($("#passw").val().length)
        return true;
    showAlert(o.validationMessage);
    return false;
}

function requestUnlock() {
    if (!validateUnlock())
        return;

    let data = fileDrop.prepareFormData();
    if (data === null)
        return;

    // let url = o.APIBasePath + 'AsposeCellsUnlock/Unlock?passw=' + encodeURI($('#passw').val()) + '&outputType=' + $('#saveAs').val();
    let url = o.APIBasePath + 'AsposeCellsUnlock/Unlock?passw=' + encodeURI($('#passw').val());
    request(url, data);
}

function validateDatasourceName() {
    if ($("#datasourceName").val().length)
        return true;
    showAlert(o.validationDatasourceMessage);
    return false;
}

function requestAssembly() {
    if (!validateDatasourceName())
        return;

    let data = fileDrop.prepareFormData(2, o.MaximumUploadFiles);
    if (data === null)
        return;

    let url = o.APIBasePath + 'AsposeCellsAssembly/Assemble?datasourceName=' + encodeURI($('#datasourceName').val());
    request(url, data);
}

function requestProtect() {
    if (!validateUnlock())
        return;

    let data = fileDrop.prepareFormData();
    if (data === null)
        return;

    // let url = o.APIBasePath + 'AsposeCellsUnlock/Unlock?passw=' + encodeURI($('#passw').val()) + '&outputType=' + $('#saveAs').val();
    let url = o.APIBasePath + 'AsposeCellsProtect/Protect?password=' + encodeURI($('#passw').val());
    request(url, data);
}

function validateComparison() {
    if (fileDrop.droppedFiles.length === 1 && fileDrop.droppedFiles.length === 1)
        return true;
    showAlert(o.FileSelectMessage);
    return false;
}

function requestEditEditor() {
    let data = fileDrop.prepareFormData();
    if (data === null)
        return;

    showLoader();
    let url = o.APIBasePath + 'AsposeCellsEditor/Editor';
    $.ajax({
        method: 'POST',
        url: url,
        data: data,
        contentType: false,
        processData: false,
        cache: false,
        timeout: 600000,
        success: (res) => {
            hideLoader();

            if (res.StatusCode === 200) {
                if (res.FileProcessingErrorCode !== undefined && res.FileProcessingErrorCode !== 0) {
                    showAlert(o.FileProcessingErrorCodes[res.FileProcessingErrorCode]);
                    return;
                }

                let pathname = window.location.pathname;
                openIframe(generateEditEditorLink(res), pathname, '/cells/edit');
            } else {
                showAlert(res.Status);
                ShowReportModal(res);
            }
        },
        xhr: function () {
            let myXhr = $.ajaxSettings.xhr();
            if (myXhr.upload)
                myXhr.upload.addEventListener('progress', progress, false);
            return myXhr;
        },
        error: (err) => {
            if (err.responseJSON !== undefined && err.responseJSON.Status !== undefined) {
                showAlert(err.responseJSON.Status);
                ShowReportModal(err.responseJSON);
            } else {
                showAlert("Error " + err.status + ": " + err.statusText);
            }
        }
    });
}

function requestNewEditor(data) {
    let pathname = window.location.pathname;
    openIframe(generateNewEditorLink(data), pathname, '/cells/edit');
}

function requestSplitter() {
    let data = fileDrop.prepareFormData();
    if (data === null)
        return;

    let url = o.APIBasePath + 'AsposeCellsSplitter/Split?outputType=' + $('#saveAs').val();
    request(url, data);
}

function requestChart() {
    let data = fileDrop.prepareFormData();
    if (data === null)
        return;

    let url = o.APIBasePath + 'AsposeCellsChart/PreChart?outputType=' + $('#saveAs').val();
    // request(url, data);

    showLoader();

    $.ajax({
        method: 'POST',
        url: url,
        data: data,
        processData: false,
        contentType: false,
        cache: false,
        timeout: 600000,
        success: (d) => {
            hideLoader();

            $.chart(d);
        },
        xhr: function () {
            let myXhr = $.ajaxSettings.xhr();
            if (myXhr.upload)
                myXhr.upload.addEventListener('progress', progress, false);
            return myXhr;
        },
        error: function (err) {
            if (err.responseJSON !== undefined && err.responseJSON.Status !== undefined) {
                showAlert(err.responseJSON.Status);
                ShowReportModal(err.responseJSON);
            } else {
                showAlert("Error " + err.status + ": " + err.statusText);
            }
        }
    });
}

function prepareDownloadUrl() {
    o.AppDownloadURL = o.AppURL;
    var pos = o.AppDownloadURL.indexOf(':');
    if (pos > 0)
        o.AppDownloadURL = (pos > 0 ? o.AppDownloadURL.substring(pos + 3) : o.AppURL) + '/download';
    pos = o.AppDownloadURL.indexOf('/');
    o.AppDownloadURL = o.AppDownloadURL.substring(pos);
}

function checkReturnFromViewer() {
    var query = window.location.search;
    if (query.length > 0) {
        o.ReturnFromViewer = true;
        var data = {
            StatusCode: 200,
            FolderName: $.QueryString['id'],
            FileName: $.QueryString['FileName'],
            FileProcessingErrorCode: 0
        };
        var beforeQueryString = window.location.href.split("?")[0];
        window.history.pushState({}, document.title, beforeQueryString);

        if (!o.UploadAndRedirect)
            workSuccess(data);
    }
}

function shareApp(type) {
    if (['facebook', 'twitter', 'linkedin', 'cloud', 'feedback', 'otherapp', 'bookmark'].indexOf(type) !== -1) {
        var gaEvent = function (action, category) {
            if (!category) {
                category = 'Social';
            }
            if ('ga' in window) {
                try {
                    var tracker = window.ga.getAll()[0];
                    if (tracker !== undefined) {
                        tracker.send('event', {
                            'eventCategory': category,
                            'eventAction': action
                        });
                    }
                } catch (err) {
                }
            }
        };
        /*var appPath = window.location.pathname.split('/');
        var appURL = 'https://' + window.location.hostname + '/' + appPath[2];*/
        let appURL = window.location.href;
        var title = document.title.replace('&', 'and');
        // Google Analytics event
        gaEvent(type.charAt(0).toUpperCase() + type.slice(1));

        // perform an action
        switch (type) {
            case 'facebook':
                var a = document.createElement('a');
                a.href = 'https://www.facebook.com/sharer/sharer.php?u=#' + encodeURI(appURL);
                a.setAttribute('target', '_blank');
                a.click();
                break;
            case 'twitter':
                var a = document.createElement('a');
                a.href = 'https://twitter.com/intent/tweet?text=' + encodeURI(title) + '&url=' + encodeURI(appURL);
                a.setAttribute('target', '_blank');
                a.click();
                break;
            case 'linkedin':
                var a = document.createElement('a');
                a.href = 'https://www.linkedin.com/sharing/share-offsite/?url=' + encodeURI(appURL);
                a.setAttribute('target', '_blank');
                a.click();
                break;
            case 'feedback':
                $('#feedbackModal').modal({
                    keyboard: true
                });
                break;
            case 'otherapp':
                document.location.href = 'https://products.aspose.app/cells/family';
                break;
            case 'cloud':
                var e = e || window.event;
                e = e.target || e.srcElement;
                if (e.tagName !== "A") {
                    var a = document.createElement('a');
                    a.href = 'https://products.aspose.cloud/cells/family';
                    a.setAttribute('target', '_blank');
                    a.click();
                }
                break;
            case 'bookmark':
                $('#bookmarkModal').modal({
                    keyboard: true
                });
                break;
            default:
            // nothing
        }
    }
}

function sendFeedbackExtended() {
    var text = $('#feedbackBody').val();
    if (text && !text.match(/^.s+$/)) {
        $('#feedbackModal').modal('hide');
        sendFeedback(text);
    }
}

function otherAppClick(name, left = false) {
    if ('ga' in window) {
        try {
            var tracker = window.ga.getAll()[0];
            if (tracker !== undefined) {
                tracker.send('event', {
                    'eventCategory': 'Other App Click' + (left ? ' Left' : ''),
                    'eventAction': name
                });
            }
        } catch (e) {
        }
    }
}

$(document).ready(function () {
    prepareDownloadUrl();
    checkReturnFromViewer();

    if (o.AppName === "Conversion" && o.Accept === ".excel") {
        o.Accept = ".xls,.xlsx,.xlsm,.xlsb";
        o.UploadOptions = ".XLS,.XLSX,.XLSM,.XLSB";
    }
    fileDrop = $('form#UploadFile').filedrop(Object.assign({
        showAlert: showAlert,
        hideAlert: hideAlert,
        showLoader: showLoader,
        progress: progress
    }, o));

    if (o.AppName === "Comparison") {
        fileDrop2 = $('form#UploadFile').filedrop(Object.assign({
            showAlert: showAlert,
            hideAlert: hideAlert,
            showLoader: showLoader,
            progress: progress
        }, o));
    }

    // close iframe if it was opened
    window.onpopstate = function (event) {
        if ($('div#iframe-wrap').length > 0) {
            closeIframe();
        }
    };

    if (!o.UploadAndRedirect) {
        $('#uploadButton').on('click', o.Method);
    }

    if (!o.UploadAndRedirect) {
        $('#newButton').on('click', o.NewMethod);
    }
    if (!o.UploadAndRedirect) {
        $('#editButton').on('click', o.EditMethod);
    }

    if (!o.ShowHelpButton) {
        $('#showHelpButton').on('click', function () {
            // const helpTemplate = o.getTrustedResourceUrl('/assembly/' + ASPOSE_PRODUCTNAME + 'HelpTemplate.html');
            alert("showHelpButton");
            const helpTemplate = "/assembly/cellsHelpTemplate.html";
            $("#help-dialog-template > .modal-dialog > .modal-content").html(helpTemplate).contents();
        });
    }

    // social network modal
    $('#bookmarkModal').on('show.bs.modal', function (e) {
        $('#bookmarkModal').css('display', 'flex');
        $('#bookmarkModal').on('keydown', function (evt) {
            if ((evt.metaKey || evt.ctrlKey) && String.fromCharCode(evt.which).toLowerCase() === 'd') {
                $('#bookmarkModal').modal('hide');
            }
        });
    });
    $('#bookmarkModal').on('hidden.bs.modal', function (e) {
        $('#bookmarkModal').off('keydown');
    });

    // send email modal
    $('#sendEmailButton').on('click', function () {
        $('#sendEmailModal').modal({
            keyboard: true
        });
    });
    $('#sendEmailModal').on('show.bs.modal', function () {
        $('#sendEmailModal').css('display', 'flex');
    });
    $('#sendEmailModal').on('shown.bs.modal', function () {
        $('#EmailToInput').focus();
    });

    // send feedback modal
    $('#feedbackModal').on('show.bs.modal', function (e) {
        $('#feedbackModal').css('display', 'flex');
    });
    $('#feedbackModal').on('shown.bs.modal', function () {
        $('#feedbackBody').focus();
    });

    //$('#sendFeedbackBtn').on('click', sendFeedback);

    // detect Ctrl + D keypress
    $(document).on('keydown', function (evt) {
        if (evt.originalEvent.code === 'KeyD' && evt.originalEvent.ctrlKey && !evt.originalEvent.altKey && !evt.originalEvent.shiftKey && !evt.originalEvent.metaKey) {
            if ('ga' in window) {
                try {
                    var tracker = window.ga.getAll()[0];
                    if (tracker !== undefined) {
                        tracker.send('event', {
                            'eventCategory': '[Ctrl + D] keypress',
                            'eventAction': 'Target: ' + window.location.pathname
                        });
                    }
                } catch (e) {
                }
            }
        }
    });
});