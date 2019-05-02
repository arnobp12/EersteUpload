using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gsmWebsite.Persistence;

namespace gsmWebsite.Business
{
    public class Controller
    {
        PersistenceCode _persistence = new PersistenceCode();

        public List<artikel> HaalArtikelsOp()
        {
            return _persistence.loadArtikels();
        }

        public artikel LaadArtikelmetnummer(int ArtNr)
        {
          return _persistence.LoadArtikelMetNR(ArtNr);
        }
    }
}