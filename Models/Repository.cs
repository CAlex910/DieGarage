using System.Runtime.InteropServices;

namespace DieGarage.Models
{
    public class Repository
    {
        public List<Fahrzeugen> Autos { get; set; }
        public List<Fahrzeugen> Motorraders { get; set; }

        public List<Fahrzeugen> FahrzeugenListe { get; set; }

        //public List<Garage> Etage { get; set; }
        //public List<Garage>? Erdgeschoss { get; set; }
        public Garage Erdgeschoss { get; set; }

        public Repository()
        {
            FahrzeugenListe = new List<Fahrzeugen>()
            {
                //new Fahrzeugen{ Nummerschild= "1", FahrzeugTyp= "PKW"},
                //new Fahrzeugen{ Nummerschild= "2", FahrzeugTyp= "LKW"},
                //new Fahrzeugen{ Nummerschild= "3", FahrzeugTyp= "SUV"}
            };

            //Motorraders = new List<Fahrzeugen>()
            //{
            //    new Fahrzeugen { Nummerschild = "4", FahrzeugTyp = "Enduro"},
            //    new Fahrzeugen { Nummerschild = "5", FahrzeugTyp = "Cruiser"}
            //};
        }

        public string FahrzeugEinfugen(Fahrzeugen neueFahrzeugen)
        {
            // Random Objekt erstellen
            Random random = new Random();

            // Array mit Fahrzeugen Typen
            string[] fahrzeugenTyp = { "Autos", "Motorräder" };

            string[] license = {"a","b","a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z","1","2","3","4","5","6","7","8","9","0"};
            string pattern = @"^[A-ZÖÜÄ]{1,3} [A-ZÖÜÄ]{1,2} [1-9]{1}[0-9]{1,3}$";

            int stadtKennung = random.Next(1, 4);
            int buchstabenReihe = random.Next(1, 3);


            string stadt = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, stadtKennung).ToUpper();
            string buchstabe = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, buchstabenReihe).ToUpper();
            int nummer = random.Next(1, 9999);


            var kennzeichen = string.Format("{0} {1} {2}", stadt, buchstabe, nummer);

            // Ein zufällige index von fahrzeugenTyp
            int index = random.Next(fahrzeugenTyp.Length);
            try
            {
                // Ein zufällige Parkplatz
                int spot = random.Next(1,Erdgeschoss.ParkPlatze);

                neueFahrzeugen.FahrzeugTyp = fahrzeugenTyp[index];
                //neueFahrzeugen.Nummerschild = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 3).ToUpper();
                neueFahrzeugen.Nummerschild = kennzeichen;

                neueFahrzeugen.ParkSpot = spot;
                FahrzeugenListe.Add(neueFahrzeugen);
                return "Autos angelegt";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public void GarageErstellen(int parkplätze, int etagen)
        {
            //Garage garage1 = new Garage(parkplätze, etagen);
            //garages.ParkPlatze = parkplätze;

            Erdgeschoss = new Garage();
            //{
            //    new Garage { ParkPlatze = parkplätze }
            //};
            Erdgeschoss.ParkPlatze = 33;
            Erdgeschoss.Etagen = 2;
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
