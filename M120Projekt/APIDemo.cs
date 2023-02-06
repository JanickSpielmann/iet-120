using System;
using System.Diagnostics;

namespace M120Projekt
{
    static class APIDemo
    {
        #region KlasseA
        // Create
        public static void CreateNirvana()
        {
            
            // Schallplatte 1
            Data.Record Record = new Data.Record();
            Record.AlbumTitle = "Nevermind";
            Record.Artist = "Nirvana";
            Record.Price = 24.90;
            Record.Own = true;
            Record.ReleaseDate = new DateTime(1991, 9, 24);
            Int64 AlbumId = Record.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + AlbumId);
        }
        public static void CreateACDC()
        { 
            // Schallplatte 2
            Data.Record Record = new Data.Record();
            Record.AlbumTitle = "Back In Black";
            Record.Artist = "ACDC";
            Record.Price = 29.90;
            Record.Own = false;
            Record.ReleaseDate = new DateTime(1980, 7, 25);
            Int64 AlbumId = Record.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" +AlbumId);
        }

        #endregion
    }
}
