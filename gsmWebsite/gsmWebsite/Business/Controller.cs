﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gsmWebsite.Persistence;

namespace gsmWebsite.Business
{
    public class Controller
    {
        PersistenceCode _persistence = new PersistenceCode();
        winkelmand _winkelmand = new winkelmand();
        Gebruiker _gebruiker = new Gebruiker();

        public List<artikel> HaalArtikelsOp()
        {
            return _persistence.loadArtikels();
        }

        public artikel LaadArtikelmetnummer(int ArtNr)
        {
          return _persistence.LoadArtikelMetNR(ArtNr);
        }

        public bool controleervoorraad(int ArtNr)
        {
            return _persistence.ControleerVoorraad(ArtNr);
        }

        public void voegProductAanMandjeToe(int klantnr, int artnr, int aantal)
        {
            _winkelmand.KlantNr = klantnr;
            _winkelmand.ArtNr = artnr;
            _winkelmand.aantal = aantal;
            

        }
        public void SaveProduct()
        {
            _persistence.toevoegenAanwinkemand(_winkelmand);
        }

        public void PasDeVoorraadAAN(int ArtNr, int Voorraad)
        {
            _persistence.PasVoorraadAan(ArtNr, Voorraad);
        }

        public List<winkelmand> haalwinkelmandop()
        {
            return _persistence.laadwinkelmand();
        }

        public Klant Laadklant(int Klantnr)
        {
            return _persistence.LoadKlantMetNR(Klantnr);
        }
        


        public Boolean controleerCredentials(string GN, string WW)

        {
            _gebruiker.Gebr = GN;
            _gebruiker.Wachtwoord = WW;
            return _persistence.controleerCredentials(_gebruiker);

        }
        public void deleteKlant(int ArtNr)

        {
            _persistence.VerwijderProduct(ArtNr);
        }
    }
}