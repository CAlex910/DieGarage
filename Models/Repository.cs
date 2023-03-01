using System.Runtime.InteropServices;

namespace DieGarage.Models
{
    public class Repository
    {
        public List<Fahrzeugen> Autos { get; set; }
        public List<Fahrzeugen> Motorraders { get; set; }
        public List<Fahrzeugen> FahrzeugenListe { get; set; }

        public Garage[,] Ebene { get; set; }

        //public List<Garage> Etage { get; set; }
        //public List<Garage>? Erdgeschoss { get; set; }
        public Garage Parkhaus { get; set; }

        public Repository()
        {
            FahrzeugenListe = new List<Fahrzeugen>()
            {
            };
        }

        public string? Einparken(Fahrzeugen neueFahrzeugen)
        {
            // Random Objekt erstellen
            Random random = new Random();

            // Array mit Fahrzeugen Typen
            string[] fahrzeugenTyp = { "Autos", "Motorräder" };

            // Ein zufällige index von fahrzeugenTyp / Stadt - Kennzeichen
            int indexTyp = random.Next(fahrzeugenTyp.Length);
            int indexStadt = random.Next(1, 4);
            int indexBuchstabenReihe = random.Next(1, 3);

            // Aufbau der Nummerschild

            var nummerSchild = "";
            for (char c = 'A'; c <= 'Z'; c++)
            {
                nummerSchild += c.ToString();
            }

            var stadtKennung = new char[indexStadt];
            var buchstabeReihe = new char[indexBuchstabenReihe];

            // Stadt Kennzeichen erzeugen
            for (int i = 0; i < stadtKennung.Length; i++)
            {
                stadtKennung[i] = nummerSchild[random.Next(nummerSchild.Length)];
            }
            string stadt = new string(stadtKennung);


            // Buchstabe Reihe erzeugen
            for (int i = 0; i < buchstabeReihe.Length; i++)
            {
                buchstabeReihe[i] = nummerSchild[random.Next(nummerSchild.Length)];
            }
            string buchstabe = new string(buchstabeReihe);

            // Zufällige nummer für Nummerschild
            int nummer = random.Next(1, 9999);

            var kennzeichen = string.Format("{0} {1} {2}", stadt, buchstabe, nummer);


            // Ein zufällige Parkplatz
            int spot = random.Next(1, Parkhaus.ParkPlatze + 1);

            var contain = new List<int>();

            try
            {
                neueFahrzeugen.IstBesetzt = false;

                if (neueFahrzeugen.IstBesetzt == false)
                {
                    neueFahrzeugen.ParkSpot = spot;
                    neueFahrzeugen.FahrzeugTyp = fahrzeugenTyp[indexTyp];
                    neueFahrzeugen.Nummerschild = kennzeichen;

                    for (int i = 0; i < Parkhaus.Etagen; i++)
                    {
                        for (int j = 0; j < Parkhaus.ParkPlatze; j++)
                        {
                            Ebene[i, j].Fahrzeugen1 = neueFahrzeugen;

                        }
                    }

                    FahrzeugenListe.Add(neueFahrzeugen);


                }

                contain.Add(spot);

                if (contain.Contains(spot) == true)
                {
                    neueFahrzeugen.IstBesetzt = true;
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            foreach (var item in FahrzeugenListe)
            {
                Console.WriteLine(item.FahrzeugTyp);
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
                    FahrzeugenListe.RemoveAt(index);
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
            //Garage garage1 = new Garage(parkplätze, etagen);
            //garages.ParkPlatze = parkplätze;

            Parkhaus = new Garage();
            //{
            //    new Garage { ParkPlatze = parkplätze }
            //};
            Parkhaus.ParkPlatze = parkplätze;
            //Erdgeschoss.Etagen = etagen;

            Ebene = new Garage[etagen, parkplätze];

            //int[,] test = new int[parkplätze, etagen];
            int[,] test = { { 1, 2, 3 }, { 4, 5, 6 } };

            //foreach (var item in test)
            //{
            //    Console.WriteLine(item);
            //}

            //foreach (var item in Ebene)
            //{

            //    Console.WriteLine(item);
            //}

            //foreach (var item in Ebene)
            //{
            //    for (int i = 0; i < item.Etagen; i++)
            //    {
            //        item.Etagen= i;
            //    }
            //    for (int i = 0; i < item.ParkPlatze; i++)
            //    {
            //        item.ParkPlatze = i;
            //    }
            //}

            //for (int i = 0; i < parkplätze; i++)
            //{
            //    Platz = new List<Garage>()
            //        {
            //            new GaragePlatz { ParkPlatze = i }
            //        };
            //}

            //if (etagen > 1)
            //{
            //    for (int i = 0; i < etagen; i++)
            //    {
            //        Etage = new List<Garage>()
            //        {
            //            new Garage { ParkPlatze = parkplätze, Etagen= etagen }
            //        };
            //    }
            //}

            int[] garages = new int[etagen];


            //int[] erdgeschoss = new int[parkplätze];

            //for (int i = 0; i < parkplätze; i++)
            //{
            //    erdgeschoss[i] = i;
            //}


            //Garage[] garages1 = new Garage[parkplätze];

            ////if (etagen > 1)
            ////{
            ////    garages.Append(etagen);
            ////}

            //for (int i = 0; i < parkplätze; i++)
            //{
            //    erdgeschoss[i] = i;
            //}

        }
    }
}
