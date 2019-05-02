<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemToevoegenWinkelmandje.aspx.cs" Inherits="gsmWebsite.ItemToevoegenWinkelmandje" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 1058px;
            height: 312px;
        }
        .auto-style2 {
            width: 417px;
        }
        .auto-style3 {
            width: 400px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Online GSM-shop - Item toevoegen aan winkelmandje</h2>
            <p>
                &nbsp;</p>
            <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style2">
                            <asp:Image ID="imgFoto" runat="server" Height="211px" Width="384px" />
                        </td>
                        <td>
                            <asp:DataList ID="DataList1" runat="server">
                                <ItemTemplate>
                                    <table class="auto-style3">
                                        <tr>
                                            <td>ArtNr:</td>
                                            <td>
                                                <asp:Label ID="lblArtNr" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Naam:</td>
                                            <td>
                                                <asp:Label ID="lblNaam" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Verkoopprijs:</td>
                                            <td>
                                                <asp:Label ID="lblVerkoopprijs" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Voorraad:</td>
                                            <td>
                                                <asp:Label ID="lblVoorraad" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                    </tr>
                </table>
&nbsp;</p>
        </div>
        <p>
            Aantal te bestellen exemplaren van dit item: <asp:TextBox ID="txtAantal" runat="server"></asp:TextBox>
&nbsp;&nbsp;
            <asp:Button ID="btnVoegtoe" runat="server" Text="Voeg toe aan mandje..." />
        </p>
    </form>
</body>
</html>
