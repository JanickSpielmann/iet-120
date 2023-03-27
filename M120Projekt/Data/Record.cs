using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M120Projekt.Data
{
    public class Record
    {
        #region Datenbankschicht
        [Key]
        public Int64 RecordId { get; set; }
        [Required]
        public String AlbumTitle { get; set; }
        [Required]
        public String Artist { get; set; }
        [Required]
        public Double Price { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public Boolean Own { get; set; }

        #endregion
        #region Applikationsschicht
        public Record() { }
        [NotMapped]
        public String BerechnetesAttribut
        {
            get
            {
                return "Im Getter kann Code eingefügt werden für berechnete Attribute";
            }
        }
        public static List<Record> LesenAlle()
        {
            using (var db = new Context())
            {
                return (from record in db.Record select record).ToList();
            }
        }
        public static Record LesenID(Int64 klasseAId)
        {
            using (var db = new Context())
            {
                return (from record in db.Record where record.RecordId == klasseAId select record).FirstOrDefault();
            }
        }
        public static List<Record> LesenAttributGleich(String suchbegriff)
        {
            using (var db = new Context())
            {
                return (from record in db.Record where record.AlbumTitle == suchbegriff select record).ToList();
            }
        }
        public static List<Record> LesenAttributWie(String suchbegriff)
        {
            using (var db = new Context())
            {
                return (from record in db.Record where record.AlbumTitle.Contains(suchbegriff) select record).ToList();
            }
        }
        public Int64 Erstellen()
        {
            if (this.AlbumTitle == null || this.AlbumTitle == "") this.AlbumTitle = "leer";
            if (this.ReleaseDate == null) this.ReleaseDate = DateTime.MinValue;
            using (var db = new Context())
            {
                db.Record.Add(this);
                db.SaveChanges();
                return this.RecordId;
            }
        }
        public Int64 Aktualisieren()
        {
            using (var db = new Context())
            {
                db.Entry(this).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return this.RecordId;
            }
        }
        public void Loeschen()
        {
            using (var db = new Context())
            {
                db.Entry(this).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public override string ToString()
        {
            return RecordId.ToString(); // Für bessere Coded UI Test Erkennung
        }
        #endregion
    }
}
