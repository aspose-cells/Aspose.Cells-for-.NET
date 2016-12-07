@inherits System.Web.Mvc.WebViewPage

<html>
<head>
    <title>
        FAQ Index
    </title>
</head>
<body>
    <h2>Index</h2>

    @Using (Html.BeginForm("Index", "GridWebFAQ", FormMethod.Post, New With {.enctype = "multipart/form-data"}))
       @<p>Please select a file:</p>
       @<input type="file" id="file" name="file" />
       @<input type="hidden" id="mode" value="" name="mode" />
       @<input type="submit" value="Submit" id="submit" />
    End Using

</body>
</html>
