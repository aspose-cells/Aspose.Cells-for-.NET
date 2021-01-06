<%@ Page Language="C#" CodeBehind="Default.aspx.cs" Inherits="Aspose.Cells.UI.Default" %>

<!DOCTYPE html>
<html lang="en-us">
<head runat="server">
    <title>Online Excel Worksheet Apps</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta http-equiv="content-type" content="text/html; charset=utf-8"/>
    <meta name="description" content="Save time and software maintenance costs by running single instance of software, but serving multiple tenants/websites. Customization available for Joomla, Wordpress, Discourse, Confluence and other popular applications."/>
    <meta name="generator" content="aspose.app"/>

    <link href="cells/img/favicon.ico" rel="shortcut icon" type="image/vnd.microsoft.icon"/>

    <!-- Bootstrap & Font CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@3.3.1/dist/css/bootstrap.min.css" type="text/css"/>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Open+Sans:400,600,700" type="text/css"/>

    <!-- Common CSS -->
    <link rel="stylesheet" href="https://cms.dynabic.com/templates/aspose/css/common.css" type="text/css"/>
    <link rel="stylesheet" href="https://products.aspose.app/css/error404.css" type="text/css"/>

    <!-- Dynabic.Menu CSS -->
    <!-- script src="https://code.jquery.com/jquery-1.10.2.js" -->

    <link href="https://cms.admin.containerize.com/templates/aspose/css/AsposePtyLtdMenu.css" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet" href="https://cdn.staticfile.org/font-awesome/4.6.3/css/font-awesome.min.css" type="text/css"/>

    <script src="https://cdn.jsdelivr.net/npm/jquery@3.4.1/dist/jquery.min.js"></script>

    <link rel="stylesheet" href="~/cells/css/asposeapp.css" type="text/css"/>

    <noscript>
        <div>
            <img src="https://mc.yandex.ru/watch/56651713" style="position: absolute; left: -9999px;" alt=""/>
        </div>
    </noscript>
    <!-- /Yandex.Metrika counter -->
</head>
<body>
<form id="HtmlForm" runat="server">
    <div class="container-fluid header1 header2 minify-header appfamily-header">
        <div class="container">
            <div class="row">
                <div class="col-md-8">
                    <h1><%= Resources["cellsPageMainTitle"] %></h1>
                    <h4><%= Resources["cellsPageSubHeading"] %> </h4>
                </div>
                <div class="col-md-4 tc">
                    <img class=" col-xs-12" src="/cells/img/aspose-cells-app.png" alt="Aspose.Cells" width="320"/>
                </div>
                <!--/col6 -->
            </div>
            <!--/row -->
        </div>
        <!--/container -->
    </div>
    <div class="container-fluid productfamilypage bg-white pdb-5">
        <div class="row">
            <div class="container tc">
                <div class="clearfix">&nbsp;</div>
                <div class="clearfix">&nbsp;</div>
                <h3><%= string.Format(Resources["AsposeProductFamilyInclude"], Resources["AsposeCells"]) %> </h3>
                <div class="clearfix">&nbsp;</div>
                <div class="clearfix">&nbsp;</div>
                <div class="col-lg-4 productfamily_box">
                    <div class="productfamilytitle">
                        <div class="imgblock">
                            <img src="/cells/img/aspose_cells-for-net.png" alt="Aspose.Cells for .NET"/>
                        </div>
                        <a href="/cells/conversion">
                            <span class="spanclass">
                                <%= Resources["AsposeCells"] %> <% = Resources["AsposeProductFor"] %> <em><%= Resources["Conversionh4"] %></em>
                            </span><em><%= Resources["cellsConversionDesc"] %>.</em>
                        </a>
                    </div>
                </div>

                <div class="col-lg-4 productfamily_box">
                    <div class="productfamilytitle">
                        <div class="imgblock">
                            <img src="/cells/img/aspose_cells-for-net.png" alt="Aspose.Cells for .NET"/>
                        </div>
                        <a href="/cells/parser">
                            <span class="spanclass">
                                <%= Resources["AsposeCells"] %> <% = Resources["AsposeProductFor"] %> <em>Parser</em>
                            </span><em><%= Resources["cellsParserDesc"] %></em>
                        </a>
                    </div>
                </div>

                <div class="col-lg-4 productfamily_box">
                    <div class="productfamilytitle">
                        <div class="imgblock">
                            <img src="/cells/img/aspose_cells-for-net.png" alt="Aspose.Cells for .NET"/>
                        </div>
                        <a href="/cells/metadata">
                            <span class="spanclass">
                                <%= Resources["AsposeCells"] %> <% = Resources["AsposeProductFor"] %> <em>Metadata</em>
                            </span><em><%= Resources["cellsMetadataDesc"] %></em>
                        </a>
                    </div>
                </div>

                <div class="col-lg-4 productfamily_box">
                    <div class="productfamilytitle">
                        <div class="imgblock">
                            <img src="/cells/img/aspose_cells-for-net.png" alt="Aspose.Cells Product Family"/>
                        </div>
                        <a href="/cells/viewer">
                            <span class="spanclass">
                                <%= Resources["AsposeCells"] %> <% = Resources["AsposeProductFor"] %> <em><%= Resources["Viewerh4"] %></em>
                            </span><em><%= Resources["cellsViewerDesc"] %>.</em>
                        </a>
                    </div>
                </div>
                <div class="col-lg-4 productfamily_box">
                    <div class="productfamilytitle">
                        <div class="imgblock">
                            <img src="/cells/img/aspose_cells-for-net.png" alt="Aspose.Cells for .NET"/>
                        </div>
                        <a href="/cells/watermark">
                            <span class="spanclass">
                                <%= Resources["AsposeCells"] %> <% = Resources["AsposeProductFor"] %> <em><%= Resources["Watermarkh4"] %></em>
                            </span><em><%= Resources["cellsWatermarkDesc"] %>.</em>
                        </a>
                    </div>
                </div>

                <div class="col-lg-4 productfamily_box">
                    <div class="productfamilytitle">
                        <div class="imgblock">
                            <img src="/cells/img/aspose_cells-for-net.png" alt="Aspose.Cells for .NET"/>
                        </div>
                        <a href="/cells/merger">
                            <span class="spanclass">
                                <%= Resources["AsposeCells"] %> <% = Resources["AsposeProductFor"] %> <em>Merger</em>
                            </span><em><%= Resources["cellsMergerDesc"] %></em>
                        </a>
                    </div>
                </div>

                <div class="col-lg-4 productfamily_box">
                    <div class="productfamilytitle">
                        <div class="imgblock">
                            <img src="/cells/img/aspose_cells-for-net.png" alt="Aspose.Cells for .NET"/>
                        </div>
                        <a href="/cells/search">
                            <span class="spanclass">
                                <%= Resources["AsposeCells"] %> <% = Resources["AsposeProductFor"] %> <em><%= Resources["SearchAPPName"] %></em>
                            </span><em><%= Resources["cellsSearchDesc"] %></em>
                        </a>
                    </div>
                </div>

                <div class="col-lg-4 productfamily_box">
                    <div class="productfamilytitle">
                        <div class="imgblock">
                            <img src="/cells/img/aspose_cells-for-net.png" alt="Aspose.Cells for .NET"/>
                        </div>
                        <a href="/cells/assembly">
                            <span class="spanclass">
                                <%= Resources["AsposeCells"] %> <% = Resources["AsposeProductFor"] %> <em><%= Resources["AssemblyAPPName"] %></em>
                            </span><em><%= Resources["cellsAssemblyDesc"] %></em>
                        </a>
                    </div>
                </div>

                <div class="col-lg-4 productfamily_box">
                    <div class="productfamilytitle">
                        <div class="imgblock">
                            <img src="/cells/img/aspose_cells-for-net.png" alt="Aspose.Cells for .NET"/>
                        </div>
                        <a href="/cells/annotation">
                            <span class="spanclass">
                                <%= Resources["AsposeCells"] %> <% = Resources["AsposeProductFor"] %> <em><%= Resources["AnnotationAPPName"] %></em>
                            </span><em><%= Resources["cellsAnnotationDesc"] %></em>
                        </a>
                    </div>
                </div>

                <div class="col-lg-4 productfamily_box">
                    <div class="productfamilytitle">
                        <div class="imgblock">
                            <img src="/cells/img/aspose_cells-for-net.png" alt="Aspose.Cells for .NET"/>
                        </div>
                        <a href="/cells/unlock">
                            <span class="spanclass">
                                <%= Resources["AsposeCells"] %> <% = Resources["AsposeProductFor"] %> <em><%= Resources["UnlockAPPName"] %></em>
                            </span><em><%= Resources["cellsUnlockDesc"] %></em>
                        </a>
                    </div>
                </div>

                <div class="col-lg-4 productfamily_box">
                    <div class="productfamilytitle">
                        <div class="imgblock">
                            <img src="/cells/img/aspose_cells-for-net.png" alt="Aspose.Cells for .NET"/>
                        </div>
                        <a href="/cells/protect">
                            <span class="spanclass">
                                <%= Resources["AsposeCells"] %> <% = Resources["AsposeProductFor"] %> <em><%= Resources["ProtectAPPName"] %></em>
                            </span><em><%= Resources["cellsProtectDesc"] %></em>
                        </a>
                    </div>
                </div>

                <div class="col-lg-4 productfamily_box">
                    <div class="productfamilytitle">
                        <div class="imgblock">
                            <img src="/cells/img/aspose_cells-for-net.png" alt="Aspose.Cells for .NET"/>
                        </div>
                        <a href="/cells/editor">
                            <span class="spanclass">
                                <%= Resources["AsposeCells"] %> <% = Resources["AsposeProductFor"] %> <em><%= Resources["EditorAPPName"] %></em>
                            </span><em><%= Resources["cellsEditorDesc"] %></em>
                        </a>
                    </div>
                </div>

                <div class="col-lg-4 productfamily_box">
                    <div class="productfamilytitle">
                        <div class="imgblock">
                            <img src="/cells/img/aspose_cells-for-net.png" alt="Aspose.Cells for .NET"/>
                        </div>
                        <a href="/cells/splitter">
                            <span class="spanclass">
                                <%= Resources["AsposeCells"] %> <% = Resources["AsposeProductFor"] %> <em><%= Resources["cellsSplitterAPPName"] %></em>
                            </span><em><%= Resources["cellsSplitterDesc"] %></em>
                        </a>
                    </div>
                </div>

                <div class="col-lg-4 productfamily_box">
                    <div class="productfamilytitle">
                        <div class="imgblock">
                            <img src="/cells/img/aspose_cells-for-net.png" alt="Aspose.Cells for .NET"/>
                        </div>
                        <a href="/cells/chart">
                            <span class="spanclass">
                                <%= Resources["AsposeCells"] %> <% = Resources["AsposeProductFor"] %> <em><%= Resources["cellsChartAPPName"] %></em>
                            </span><em><%= Resources["cellsChartDesc"] %></em>
                        </a>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <div class="spacer">&nbsp;</div>
</form>
</body>
</html>