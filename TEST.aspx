<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TEST.aspx.cs" Inherits="TEST" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#tool').tooltip();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 600px; width: 900px; padding-top: 200px; padding-left: 200px;">
        <a href="#" id="tool" data-toggle="tooltip" data-placement="right" title="" data-original-title="Tooltip on top">Tooltip on top</a>
    </div>
    </form>
</body>
</html>
