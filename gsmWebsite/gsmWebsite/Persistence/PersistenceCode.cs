﻿using System;
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

        public List<artikel> loadArtikels()  //alle artikels worden opgehaald vanuit de databank
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


        public artikel LoadArtikelMetNR(int ArtNR) //specifiek artikel word opgehaald via het artikelnummer.
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

        public bool ControleerVoorraad(int klantnr) //we gaan de voorraad van een artikel controleren via het artikelnummer
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

        public void toevoegenAanwinkemand(winkelmand winkelmand) //we gaan een artikel toevoegen aan de winkelmand
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string qry = "insert into tblwinkelmand(KlantNr,ArtNr, Aantal) values (" + winkelmand.KlantNr + "," + winkelmand.ArtNr + "," + winkelmand.Aantal + ")";
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

        public List<winkelmand> laadwinkelmand(int Klantnr)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string qry = "select Foto, tblwinkelmand.ArtNr, Naam, Aantal, Prijs, (Aantal * Prijs) as Totaal  from tblwinkelmand inner join " +
                "tblartikel on tblwinkelmand.ArtNr = tblartikel.ArtNr where tblWinkelmand.KlantNr= " + Klantnr + " order by tblwinkelmand.ArtNr";
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
                _lijst.Add(winkelmand);
            }
            conn.Close();
            return _lijst;
        }
        public Klant LoadKlantMetNR(int KlantNR)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string qry = "select KlantNr,Naam,Voornaam,Adres,PC,Gemeente from tblKlant where KlantNr=" + KlantNR;
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
               
            }
            conn.Close();
            return Klant;

        }
        public Klant laadklantnummer(string Gebr)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string qry = "select KlantNr from tblklant where GebrNaam= '" + Gebr + "'";
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            Klant Klant = new Klant();
            while(dtr.Read())
            {
                Klant.KlantNr = Convert.ToInt32(dtr["KlantNr"]);
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
        public void VerwijderProduct(int ArtNr, int KlantNr)
        {
            MySqlConnection sqlConn = new MySqlConnection(connStr);

            sqlConn.Open();
            string query= "Delete from tblWinkelmand where ArtNr=" + ArtNr + " and KlantNr =" + KlantNr;
            MySqlCommand sqlCmd = new MySqlCommand(query, sqlConn);
            sqlCmd.ExecuteNonQuery();
            sqlConn.Close();
        }

        public bool ControleerWinkelMand(int klantnr)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string qry = "select * from tblwinkelmand where KlantNr = " + klantnr;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            bool isleeg;
            if (dtr.HasRows)
            {
                isleeg = false;
            }
            else
            {
                isleeg = true;
            }
            conn.Close();
            return isleeg;
        }

        
       
    }
}