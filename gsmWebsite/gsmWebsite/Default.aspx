<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="gsmWebsite.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Online GSM-shop - Catalogus</h1>
            <p>
                <asp:GridView ID="gvArtikels" runat="server" AutoGenerateColumns="False" Height="110px" Width="242px" OnSelectedIndexChanged="gvArtikels_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="ArtNr" HeaderText="ArtNr">
                        <ItemStyle Width="75px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Naam" HeaderText="Naam">
                        <ItemStyle Width="250px" />
                        </asp:BoundField>
                        <asp:ImageField HeaderText="Foto" DataImageUrlField="Foto" DataImageUrlFormatString="~/Images/{0}">
                            <ControlStyle Height="150px" Width="110px" />
                        </asp:ImageField>
                        <asp:BoundField DataField="Prijs" HeaderText="Verkoopprijs">
                        <ItemStyle Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Voorraad" HeaderText="Voorraad" >
                        <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:CommandField SelectText="Voeg toe aan winkelmandje.." ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
            </p>
        </div>
        <asp:Button ID="btnWinkelmandje" runat="server" OnClick="btnWinkelmandje_Click" Text="Bekijk de inhoud van het winkelmandje..." Width="342px" />
    </form>
</body>
</html>
