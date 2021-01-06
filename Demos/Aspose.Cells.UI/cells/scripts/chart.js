(function ($) {
    $.chart = function (data) {
        const display = function () {
            let div, img, span, url, imgFolderName, imgFileName;

            $.each(data.charts, function (index, chart) {
                url = encodeURI(o.APIBasePath + `Common/DownloadFile/${chart.ImgFolderName}?file=${chart.ImgFileName}`)

                div = $('<div class="charts">');
                img = $('<img src="' + url + '" alt="' + chart.ChartName + '">');
                span = $('<span>' + chart.ChartName + '</span>');
                imgFolderName = $('<input name="imgFolderName" id="imgFolderName" type="hidden" value="' + chart.ImgFolderName + '" /> ');
                imgFileName = $('<input name="imgFileName" id="imgFileName" type="hidden" value="' + chart.ImgFileName + '" /> ');

                div.append(img);
                div.append(span);
                div.append(imgFolderName);
                div.append(imgFileName);
                div.on('click', onCheck);
                $("#chart-div").append(div);
            });
        };

        const onSave = function () {
            showLoader();

            if ($(".charts2").length <= 0) {
                return showAlert("You should select at least one chart to save.");
            }

            const url = o.APIBasePath + 'AsposeCellsChart/Download';

            let charts = [];
            $(".charts2").each(function () {
                let chart = {
                    "ImgFolderName": $(this).children("input#imgFolderName").val(),
                    "ImgFileName": $(this).children("input#imgFileName").val()
                };
                charts.push(chart);
            });

            $.ajax({
                method: 'POST',
                url: url,
                data: JSON.stringify({outputType: data.outputType, charts: charts}),
                contentType: 'application/json',
                cache: false,
                timeout: 600000,
                success: workSuccess,
                error: (err) => {
                    if (err.data !== undefined && err.data.Status !== undefined)
                        showAlert(err.data.Status);
                    else
                        showAlert("Error " + err.status + ": " + err.statusText);
                }
            });
        };

        const onCheck = function () {
            if ($(this).hasClass("charts2")) {
                $(this).removeClass("charts2");
            } else {
                $(this).addClass("charts2");
            }
        }

        const onCheckAll = function () {
            $(".charts").each(function () {
                if (!$(this).hasClass("charts2")) {
                    $(this).addClass("charts2");
                }
            });
        }

        const onClearAll = function () {
            $(".charts").each(function () {
                if ($(this).hasClass("charts2")) {
                    $(this).removeClass("charts2");
                }
            });
        }

        $("div.saveas").remove();
        $("#uploadButton").remove();

        const clearBtn = $('<input type="button" class="btn btn-success btn-lg" value="CLEAR ALL" style="margin-right: 15px"/>');
        clearBtn.on('click', onClearAll);

        const checkBtn = $('<input type="button" class="btn btn-success btn-lg" value="SELECT ALL" style="margin-right: 15px"/>');
        checkBtn.on('click', onCheckAll);

        const saveBtn = $('<input type="button" class="btn btn-success btn-lg" value="SAVE"/>');
        saveBtn.on('click', onSave);

        $("div.convertbtn").append(clearBtn);
        $("div.convertbtn").append(checkBtn);
        $("div.convertbtn").append(saveBtn);

        $('.filedrop').addClass('hidden');
        $('#ChartPreviewPlaceHolder').removeClass('hidden');
        hideLoader();
        display();
    };
})(jQuery);
