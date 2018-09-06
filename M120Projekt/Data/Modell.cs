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
    public class Modell
    {
        #region Datenbankschicht
        [Key]
        public Int64 ModellId { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public DateTime Jahrgang { get; set; }
        public String Bauart { get; set; }
        public Double Leistung { get; set; }
        public Int16 Drehmoment { get; set; }
        public Int16 Hubraum { get; set; }
        public Int16 Höchstgeschwindigkeit { get; set; }
        public String MotorBauart { get; set; }
        public Int16 Gewicht { get; set; }
        public Boolean Aktiv { get; set; }
        public Int64 MarkeId { get; set; }
        public Marke Marke { get; set; }
        #endregion
        #region Applikationsschicht
        public Modell() { }
        [NotMapped]
        public String BerechnetesAttribut
        {
            get
            {
                return "Im Getter kann Code eingefügt werden für berechnete Attribute";
            }
        }
        public static List<Data.Modell> LesenAlle()
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Modell.Include(x => x.Marke) select record).ToList();
            }
        }
        public static Data.Modell LesenID(Int64 ModellId)
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Modell.Include(x => x.Marke) where record.ModellId == ModellId select record).FirstOrDefault();
            }
        }
        public static List<Data.Modell> LesenAttributGleich(String suchbegriff)
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Modell.Include(x => x.Marke) where record.Name == suchbegriff select record).ToList();
            }
        }
        public static List<Data.Modell> LesenAttributWie(String suchbegriff)
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Modell.Include(x => x.Marke) where record.Name.Contains(suchbegriff) select record).ToList();
            }
        }
        public static List<Data.Modell> LesenFremdschluesselGleich(Data.Marke suchschluessel)
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Modell.Include(x => x.Marke) where record.Marke == suchschluessel select record).ToList();
            }
        }
        public Int64 Erstellen()
        {
            if (this.Name == null || this.Name == "") this.Name = "leer";
            // Option mit Fehler statt Default Value
            // if (Modell.TextAttribut == null) throw new Exception("Null ist ungültig");
            if (this.Jahrgang == null) this.Jahrgang = DateTime.MinValue;
            using (var context = new Data.Context())
            {
                context.Modell.Add(this);
                //TODO Check ob mit null möglich, sonst throw Ex
                if (this.Marke != null) context.Marke.Attach(this.Marke);
                context.SaveChanges();
                return this.ModellId;
            }
        }
        public Int64 Aktualisieren()
        {
            using (var context = new Data.Context())
            {
                //TODO null Checks?
                this.Marke = null;
                context.Entry(this).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return this.ModellId;
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
            return ModellId.ToString(); // Für bessere Coded UI Test Erkennung
        }
        #endregion
    }
}
