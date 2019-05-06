<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="gsmWebsite.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <h2>Online GSM-Shop - Login</h2>
        <table class="auto-style1">
            <tr>
                <td>
    <p>
        GebruikersNaam:&nbsp;
        <asp:TextBox ID="txtGebruikersNaam" runat="server"></asp:TextBox>
                    </p>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvGebr" runat="server" ControlToValidate="txtGebruikersNaam" ErrorMessage="Gebruikersnaam verplicht!" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Wachtwoord:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtWachtwoord" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtWachtwoord" ErrorMessage="Wachtwoord verplicht!" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
        </table>
        <p>
            <asp:Label ID="lblUitvoer" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" Width="170px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
    </form>
</body>
</html>
