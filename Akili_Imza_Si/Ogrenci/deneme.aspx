<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deneme.aspx.cs" Inherits="Akili_Imza_Si.Ogrenci.deneme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function doSubmit() {
            var confirmation = window.confirm("Are you sure?");
            document.getElementById("HiddenField1")["value"] = confirmation;
            return true;
        }
    </script>
</head>
<body onload="doSubmit()">
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="HiddenField1" runat="server" />
        </div>
    </form>
</body>
</html>
