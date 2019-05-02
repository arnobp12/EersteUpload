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
                _artikel.Prijs = Convert.ToDouble(dtr[("Prijs")]);
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
            string qry = "select ArtNr,Naam,Prijs,Voorraad from tblartikel where ArtNr=" + ArtNR;
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
    }
}