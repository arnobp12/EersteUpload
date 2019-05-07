using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using gsmWebsite.Business;

namespace gsmWebsite.Persistence
{
    public class PersistenceCode
    {


        string connStr = "server=localhost; user id = root; password=Test123; database=dbgsm";

        public List<artikel> loadArtikels()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string qry = "select * from tblartikel";
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            List<artikel> lijst = new List<artikel>();
            while (dtr.Read())
            {
                artikel _artikel = new artikel();
                _artikel.ArtNr = Convert.ToInt32(dtr[("ArtNr")]);
                _artikel.Naam = Convert.ToString(dtr[("Naam")]);
                _artikel.Voorraad = Convert.ToInt32(dtr[("Voorraad")]);
                _artikel.Prijs =  Convert.ToDouble(dtr[("Prijs")]);
                _artikel.Foto = Convert.ToString(dtr[("Foto")]);
                lijst.Add(_artikel);
            }
            conn.Close();
            return lijst;
        }


        public artikel LoadArtikelMetNR(int ArtNR)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string qry = "select ArtNr,Naam,Prijs,Voorraad,Foto from tblartikel where ArtNr=" + ArtNR;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            artikel artikel = new artikel();
            while (dtr.Read())
            {
                artikel.ArtNr = Convert.ToInt32(dtr["ArtNr"]);
                artikel.Naam = Convert.ToString(dtr["Naam"]);
                artikel.Prijs = Convert.ToDouble(dtr["Prijs"]);
                artikel.Voorraad = Convert.ToInt32(dtr["Voorraad"]);
                artikel.Foto = Convert.ToString(dtr["Foto"]);
            }
            conn.Close();
            return artikel;

        }

        public bool ControleerVoorraad(int klantnr)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string qry = "select * from tblwinkelmand where KlantNr = " + klantnr;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            bool isleeg;
            if (dtr.HasRows)
            {
                isleeg = true;
            }
            else
            {
                isleeg = false;
            }
            conn.Close();
            return isleeg;
        }

        public void toevoegenAanwinkemand(winkelmand winkelmand)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string qry = "insert into tblwinkelmand(KlantNr,ArtNr, Aantal) values (" + winkelmand.KlantNr + "," + winkelmand.ArtNr + "," + winkelmand.aantal + ")";
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void PasVoorraadAan(int ArtNr, int Voorraad)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string qry = "update tblartikel set Voorraad = " + Voorraad + " where ArtNr=" + ArtNr;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<winkelmand> laadwinkelmand()
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string qry = "select Foto, tblwinkelmand.ArtNr, Naam, Aantal, Prijs, sum(Aantal * Prijs) as Totaal  from tblwinkelmand inner join " +
                "tblartikel on tblwinkelmand.ArtNr = tblartikel.ArtNr";
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            List<winkelmand> _lijst = new List<winkelmand>();
            while (dtr.Read())
            {
                winkelmand winkelmand = new winkelmand();
               winkelmand.Foto = dtr["Foto"].ToString();
                winkelmand.ArtNr = Convert.ToInt32(dtr["ArtNr"]);
                winkelmand.Naam = dtr["Naam"].ToString();
                winkelmand.Aantal = Convert.ToInt32(dtr["Aantal"]);
                winkelmand.Prijs = Convert.ToDouble(dtr["Prijs"]);
                winkelmand.Totaal = Convert.ToDouble(dtr["Totaal"]);
            }
            conn.Close();
            return _lijst;
        }
        public Klant LoadKlantMetNR(int KlantNR)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string qry = "select KlantNR,Naam,Voornaam,Adres,PC,Gemeente,Orderdatum from tblKlant inner join tblbestelling on tblKlant.KlantNr = tblbestelling.KlantNr  where KlantNr=" + KlantNR;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            Klant Klant = new Klant();
            while (dtr.Read())
            {
                Klant.KlantNr = Convert.ToInt32(dtr["KlantNr"]);
                Klant.Naam = Convert.ToString(dtr["Naam"]);
                Klant.Voornaam = Convert.ToString(dtr["Voornaam"]);
                Klant.adres = Convert.ToString(dtr["Adres"]);
                Klant.PC = Convert.ToInt32(dtr["PC"]);
                Klant.Gemeente = Convert.ToString(dtr["Gemeente"]);
                Klant.Orderdatum = Convert.ToString(dtr["orderdatum"]);
            }
            conn.Close();
            return Klant;

        }
        public Boolean controleerCredentials(Gebruiker gebruiker)

        {

            MySqlConnection sqlConn = new MySqlConnection(connStr);
            sqlConn.Open();
            string query = "select GebrNaam,Wachtwoord from tblklant where GebrNaam='" +
            gebruiker.Gebr + "' and binary wachtwoord='" +
            gebruiker.Wachtwoord + "'";
            MySqlCommand sqlCmd = new MySqlCommand(query, sqlConn);
            MySqlDataReader dataReader = sqlCmd.ExecuteReader();
            Gebruiker _gebruiker = new Gebruiker();
            if (dataReader.HasRows)
            {
                sqlConn.Close();
                return true;
            }
            else
            {
                sqlConn.Close();
                return false;
            }

        }
    }
}