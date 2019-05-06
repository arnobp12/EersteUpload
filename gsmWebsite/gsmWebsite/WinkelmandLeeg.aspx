<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WinkelmandLeeg.aspx.cs" Inherits="gsmWebsite.WinkelmandLeeg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Online GSM-Shop - Winkelmandje</h2>
            <p>
                &nbsp;</p>
            <p>
                Het winkelmandje is leeg. Klik op de knop om terug te keren naar de catalogus.</p>
            <p>
                <asp:Button ID="btnGoback" runat="server" OnClick="btnGoback_Click" Text="terug naar catalogus..." />
            </p>
        </div>
    </form>
</body>
</html>
