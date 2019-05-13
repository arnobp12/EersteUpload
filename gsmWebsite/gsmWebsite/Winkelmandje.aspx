<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Winkelmandje.aspx.cs" Inherits="gsmWebsite.Winkelmandje" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 500px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Online GSM-shop - Winkelmand</h1>
            <table class="auto-style1">
                <tr>
                    <td>Klantnummer:</td>
                    <td>
                        <asp:Label ID="lblKlantNr" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Naam:</td>
                    <td>
                        <asp:Label ID="lblNaam" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Adres:</td>
                    <td>
                        <asp:Label ID="lblAdres" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lblPC" runat="server"></asp:Label>
&nbsp;&nbsp;
                        <asp:Label ID="lblgemeente" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Besteldatum</td>
                    <td>
                        <asp:Label ID="lblBesteldatum" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <asp:GridView ID="gvWinkelmand" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvWinkelmand_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/Images/deletebutton.jpg" >
                <ControlStyle Height="75px" Width="75px" />
                </asp:CommandField>
                <asp:ImageField HeaderText="Foto" DataImageUrlField="Foto" DataImageUrlFormatString="~/Images/{0}">
                    <ControlStyle Height="175px" Width="175px" />
                </asp:ImageField>
                <asp:BoundField DataField="ArtNR" HeaderText="ArtNR">
                <ItemStyle Width="75px" />
                </asp:BoundField>
                <asp:BoundField DataField="Naam" HeaderText="Naam">
                <ItemStyle Width="250px" />
                </asp:BoundField>
                <asp:BoundField DataField="Aantal" HeaderText="Aantal">
                <ItemStyle Width="125px" />
                </asp:BoundField>
                <asp:BoundField DataField="Prijs" HeaderText="Prijs" DataFormatString="{0:c}">
                <ItemStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="Totaal" HeaderText="Totaal" DataFormatString="{0:c}" />
            </Columns>
        </asp:GridView>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="btnbestel" runat="server" OnClick="btnbestel_Click" Text="bestellen" Width="313px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnTerugCat" runat="server" OnClick="btnTerugCat_Click" Text="Terug naar de catalogus" Width="269px" />
        </p>
    </form>
</body>
</html>
