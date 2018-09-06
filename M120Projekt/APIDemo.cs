﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120Projekt
{
    static class APIDemo
    {
        #region KlasseA
        // Create
        public static void DemoACreate()
        {
            Debug.Print("--- DemoACreate ---");
            // KlasseA (lange Syntax)
            Data.Modell klasseA1 = new Data.Modell();
            klasseA1.Name = "Artikel 1";
            klasseA1.Jahrgang = DateTime.Today;
            klasseA1.Marke = Data.Marke.LesenAttributWie("Artikelgruppe 1").FirstOrDefault();
            klasseA1.Bauart = "SuperSport";
            klasseA1.Leistung = 157;
            klasseA1.Drehmoment = 124;
            klasseA1.Hubraum = 1103;
            klasseA1.Höchstgeschwindigkeit = 300;
            klasseA1.MotorBauart = "V4";
            klasseA1.Gewicht = 164;
            klasseA1.Aktiv = true;
            klasseA1.MarkeId = 1;
            Int64 KlasseAId = klasseA1.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + KlasseAId);
        }
        // Read
        public static void DemoARead()
        {
            Debug.Print("--- DemoARead ---");
            // Demo liest alle
            foreach (Data.Modell klasseA in Data.Modell.LesenAlle())
            {
                Debug.Print("Artikel Id:" + klasseA.ModellId + " Name:" + klasseA.Name + " Artikelgruppe:" + klasseA.Marke.Name);
            }
        }
        // Update
        public static void DemoAUpdate()
        {
            Debug.Print("--- DemoAUpdate ---");
            // KlasseA ändert Attribute
            Data.Modell klasseA1 = Data.Modell.LesenID(1);
            klasseA1.Name = "Artikel 1 nach Update";
            klasseA1.MarkeId = 2;  // Wichtig: Fremdschlüssel muss über Id aktualisiert werden!
            klasseA1.Aktualisieren();
        }
        // Delete
        public static void DemoADelete()
        {
            Debug.Print("--- DemoADelete ---");
            Data.Modell.LesenID(1).Loeschen();
            Debug.Print("Artikel mit Id 1 gelöscht");
        }
        #endregion
        #region KlasseB
        // Create
        public static void DemoBCreate()
        {
            Debug.Print("--- DemoBCreate ---");
            // KlasseB (kurze Syntax)
            Data.Marke klasseB1 = new Data.Marke {
                Name = "Artikelgruppe 1",
                Gruendungsjahr = DateTime.Today.AddDays(-1),
                Aktiv = true,
                Herkunftsland = "Italien",
                Mitarbeiterzahl = 1243,
                Umsatz = 702,
                Modellanzahl = 102
            };
            Int64 klasseB1Id = klasseB1.Erstellen();
            Debug.Print("Gruppe erstellt mit Id:" + klasseB1Id);
            Data.Marke klasseB2 = new Data.Marke {
                Name = "BMW",
                Gruendungsjahr = DateTime.Today,
                Aktiv = true,
                Herkunftsland = "Deutschland",
                Mitarbeiterzahl = 42000,
                Umsatz = 5000,
                Modellanzahl = 400
            };
            Int64 klasseB2Id = klasseB2.Erstellen();
            Debug.Print("Gruppe erstellt mit Id:" + klasseB2Id);
        }
        // Read
        public static void DemoBRead()
        {
            Debug.Print("--- DemoBRead ---");
            // Demo liest 1 Objekt
            Data.Marke klasseB = Data.Marke.LesenAttributGleich("Artikelgruppe 1").FirstOrDefault();
            Debug.Print("Auslesen einzelne Gruppe mit Name: " + klasseB.Name + " Datum" + klasseB.Gruendungsjahr.ToString("dd.MM.yyyy"));
            // Liste auslesen
            foreach(Data.Modell klasseA in klasseB.FremdListeAttribut)
            {
                Debug.Print("Artikelgruppe: " + klasseB.Name + " enthält Artikel:" + klasseA.Name);
            }
        }
        // Update
        public static void DemoBUpdate()
        {
            Debug.Print("--- DemoBUpdate ---");
            Data.Marke klasseB = Data.Marke.LesenID(1);
            klasseB.Name = "Artikelgruppe 2 nach Update";
            klasseB.Aktualisieren();
            Debug.Print("Gruppe mit Name 'Artikelgruppe 1' verändert");
        }
        // Delete
        public static void DemoBDelete()
        {
            Debug.Print("--- DemoBDelete ---");
            // Achtung! Referentielle Integrität darf nicht verletzt werden!
            try
            {
                Data.Marke klasseB = Data.Marke.LesenID(1);
                klasseB.Loeschen();
                Debug.Print("Gruppe mit Id 1 gelöscht");
            } catch (Exception ex)
            {
                Debug.Print("Fehler beim Löschen:" + ex.Message);
            }
        }
        #endregion
    }
}
