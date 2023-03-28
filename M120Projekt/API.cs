using System;
using System.Diagnostics;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace M120Projekt
{
    static class API
    {
        #region KlasseA
        // Create
        public static void CreateNirvana()
        {
            // Schallplatte 1
            Data.Record Record1 = new Data.Record();
            Record1.AlbumTitle = "Nevermind";
            Record1.Artist = "Nirvana";
            Record1.Price = 24.90;
            Record1.Genre = "Grung";
            Record1.Own = true;
            Record1.ReleaseDate = new DateTime(1991, 9, 24);
            Int64 AlbumId = Record1.Create();
            Debug.Print("Artikel erstellt mit Id:" + AlbumId);
        }
        public static void CreateACDC()
        {
            // Schallplatte 2
            Data.Record Record2 = new Data.Record();
            Record2.AlbumTitle = "Back In Black";
            Record2.Artist = "ACDC";
            Record2.Price = 29.90;
            Record2.Genre = "Rock";
            Record2.Own = false;
            Record2.ReleaseDate = new DateTime(1980, 7, 25);
            Int64 AlbumId = Record2.Create();
            Debug.Print("Artikel erstellt mit Id:" + AlbumId);
        }

        // Read
        public static void RecordRead()
        {
            Debug.Print("--- DemoARead ---");
            // Demo liest alle
            foreach (Data.Record RecordA in Data.Record.ReadTable())

            {
                Debug.Print("Artikel Id:" + RecordA.RecordId + " Name:" + RecordA.AlbumTitle);
            }
        }
        // Update
        public static void RecordUpdate()
        {
            Debug.Print("--- DemoAUpdate ---");
            // Records ändert Attribute
            Data.Record RecordA = Data.Record.ReadID(1);
            RecordA.AlbumTitle = "Artikel 1 nach Update";
            RecordA.Update();
        }
        // Delete
        public static void RecordDelete()
        {
            Debug.Print("--- DemoADelete ---");
            Data.Record.ReadID(2).Delete();
            Debug.Print("Artikel mit Id 2 gelöscht");
        }
        #endregion
    }
}
