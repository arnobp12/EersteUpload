<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemToevoegenWinkelmandje.aspx.cs" Inherits="gsmWebsite.ItemToevoegenWinkelmandje" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 500px;
        }
        .auto-style2 {
            width: 250px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Online GSM-shop - Item toevoegen aan winkelmandje</h2>
            <table class="auto-style1">
                <tr>
                    <td>
                        <asp:Image ID="imgArtikel" runat="server" Height="194px" Width="251px" />
                    </td>
                    <td>
                        <table class="auto-style2">
                            <tr>
                                <td>ArtNr:</td>
                                <td>
                                    <asp:Label ID="lblArtNr" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Naam</td>
                                <td>
                                    <asp:Label ID="lblNaam" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Verkoopprijs</td>
                                <td>
                                    <asp:Label ID="lblPrijs" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Voorraad</td>
                                <td>
                                    <asp:Label ID="lblVoorraad" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;</p>
        </div>
        <p>
            Aantal te bestellen exemplaren van dit item: <asp:TextBox ID="txtAantal" runat="server"></asp:TextBox>
&nbsp;&nbsp;
            <asp:Button ID="btnVoegtoe" runat="server" Text="Voeg toe aan mandje..." OnClick="btnVoegtoe_Click" />
        </p>
        <asp:Label ID="lblfout" runat="server"></asp:Label>
    </form>
</body>
</html>
