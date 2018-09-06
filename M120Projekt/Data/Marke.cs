using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace M120Projekt.Data
{
    public class Marke
    {
        #region Datenbankschicht
        [Key]
        public Int64 MarkeId { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public DateTime Gruendungsjahr { get; set; }
        public Boolean Aktiv { get; set; }
        public String Herkunftsland { get; set; }
        public Int32 Mitarbeiterzahl { get; set; }
        public Int32 Umsatz { get; set; }
        public Int32 Modellanzahl { get; set; }
        public ICollection<Modell> Modelle { get; set; }
        #endregion
        #region Applikationsschicht
        public Marke() { }
        [NotMapped]
        public String BerechnetesAttribut
        {
            get
            {
                return "Im Getter kann Code eingefügt werden für berechnete Attribute";
            }
        }
        public static List<Data.Marke> LesenAlle()
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Marke.Include(x => x.Modelle) select record).ToList();
            }
        }
        public static Data.Marke LesenID(Int64 MarkeId)
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Marke.Include(x => x.Modelle) where record.MarkeId == MarkeId select record).FirstOrDefault();
            }
        }
        public static List<Data.Marke> LesenAttributGleich(String suchbegriff)
        {
            using (var context = new Data.Context())
            {
                var Markequery = (from record in context.Marke.Include(x => x.Modelle) where record.Name == suchbegriff select record).ToList();
                return Markequery;
            }
        }
        public static List<Data.Marke> LesenAttributWie(String suchbegriff)
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Marke.Include(x => x.Modelle) where record.Name.Contains(suchbegriff) select record).ToList();
            }
        }
        public Int64 Erstellen()
        {
            if (this.Name == null || this.Name == "") this.Name = "leer";
            // Option mit Fehler statt Default Value
            // if (Marke.TextAttribut == null) throw new Exception("Null ist ungültig");
            if (this.Gruendungsjahr == null) this.Gruendungsjahr = DateTime.MinValue;
            using (var context = new Data.Context())
            {
                context.Marke.Add(this);
                context.SaveChanges();
                return this.MarkeId;
            }
        }
        public void Aktualisieren()
        {
            using (var context = new Data.Context())
            {
                //TODO null Checks?
                context.Entry(this).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Loeschen()
        {
            using (var context = new Data.Context())
            {
                context.Entry(this).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public override string ToString()
        {
            return MarkeId.ToString(); // Für bessere Coded UI Test Erkennung
        }
        #endregion
    }
}
