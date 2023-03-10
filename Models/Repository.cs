using Microsoft.AspNetCore.Routing.Patterns;
using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Xml;

namespace DieGarage.Models
{
    public class Repository
    {
        public List<Fahrzeugen> FahrzeugenListe { get; set; }

        public Fahrzeugen Autos = new Autos();
        public Fahrzeugen Motorraders = new Motorrader();

        // Liste mit besetzte Parkplätze
        List<int> containSpot = new List<int>();

        // Liste mit besetzte Nummerschild
        List<string> containSchild = new List<string>();

        public Garage Parkhaus { get; set; }

        public Repository()
        {
            FahrzeugenListe = new List<Fahrzeugen>()
            {
            };
        }

        public Fahrzeugen FahrzeugenErstellen(Fahrzeugen neueFahrzeugen)
        {
            Random random = new Random();

            int index = random.Next(2);

            neueFahrzeugen.Nummernschild = NummernschildGenerator(containSchild);

            if (index == 0)
            {
                neueFahrzeugen.FahrzeugTyp = "Auto";
                Autos = neueFahrzeugen;
                return Autos;
            }
            else if (index == 1)
            {
                neueFahrzeugen.FahrzeugTyp = "Motorrad";
                Motorraders = neueFahrzeugen;
                return Motorraders;
            }

            return default;
        }

        public string NummernschildGenerator(List<string> excludeNummernschild)
        {
            Random random = new Random();

            // Ein zufällige Stadt - Kennzeichen
            int indexStadt = random.Next(1, 4);
            int indexBuchstabenReihe = random.Next(1, 3);

            // Aufbau der Nummernschild

            var nummernschild = "";
            for (char c = 'A'; c <= 'Z'; c++)
            {
                nummernschild += c.ToString();
            }

            var stadtKennung = new char[indexStadt];
            var buchstabeReihe = new char[indexBuchstabenReihe];

            // Stadt Kennzeichen erzeugen
            for (int i = 0; i < stadtKennung.Length; i++)
            {
                stadtKennung[i] = nummernschild[random.Next(nummernschild.Length)];
            }
            string stadt = new string(stadtKennung);

            // Buchstabe Reihe erzeugen
            for (int i = 0; i < buchstabeReihe.Length; i++)
            {
                buchstabeReihe[i] = nummernschild[random.Next(nummernschild.Length)];
            }
            string buchstabe = new string(buchstabeReihe);

            // Zufällige nummer für Nummernschild
            int nummer = random.Next(1, 9999);

            var kennzeichen = string.Format("{0} {1} {2}", stadt, buchstabe, nummer);

            // Prüfen ob die Nummernschild schon gibt
            if (excludeNummernschild.Count != null)
            {
                while (excludeNummernschild.Contains(kennzeichen))
                {
                    kennzeichen = string.Format("{0} {1} {2}", stadt, buchstabe, nummer);
                }
            }

            containSchild.Add(kennzeichen);

            return kennzeichen;
        }

        public int RandomSpot(int min, int max, List<int> excludeSpot)
        {
            Random random = new Random();
            int currentSpot = random.Next(min, max + 1);

            // Prüfen ob die Parkplatz besetzt ist
            if (excludeSpot.Count != null)
            {
                while (excludeSpot.Contains(currentSpot))
                {
                    currentSpot = random.Next(min, max + 1);
                }
            }
            return currentSpot;
        }

        public string? Einparken(Fahrzeugen fahrzeugen)
        {
            Random random = new Random();
            // Parkplatz Nummer
            int spot;
            int etage;

            try
            {
                spot = RandomSpot(1, Parkhaus.ParkPlatze, containSpot);
                etage = random.Next(1, Parkhaus.Etagen +1);

                fahrzeugen.ParkEbene = etage;
                fahrzeugen.ParkSpot = spot;

                FahrzeugenListe.Add(FahrzeugenErstellen(fahrzeugen));
                
                containSpot.Add(spot);

                Parkhaus.FreiePlatze = Parkhaus.ParkPlatze - FahrzeugenListe.Count();
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return default;
        }

        public string? Ausparken()
        {
            try
            {
                if (FahrzeugenListe.Count() > 0)
                {
                    Random random = new Random();
                    int index = random.Next(FahrzeugenListe.Count());

                    // Fahrzeug von zufällige Parkplatz ausparken
                    FahrzeugenListe.RemoveAt(index);
                    containSpot.RemoveAt(index);

                    Parkhaus.FreiePlatze = Parkhaus.ParkPlatze - FahrzeugenListe.Count();
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return default;
        }

        public void GarageErstellen(int parkplätze, int etagen)
        {
            Parkhaus = new Garage();
                        
            Parkhaus.ParkPlatze = parkplätze;
            Parkhaus.Etagen = etagen;
        }
    }
}
