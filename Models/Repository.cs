namespace DieGarage.Models
{
    public class Repository
    {
        public List<Fahrzeugen> Autos { get; set; }
        public List<Fahrzeugen> Motorraders { get; set; }

        //public List<Garage> Etage { get; set; }
        //public List<Garage>? Erdgeschoss { get; set; }
        public Garage Erdgeschoss { get; set; }

        public Repository()
        {
            Autos = new List<Fahrzeugen>()
            {
                new Fahrzeugen{ Nummerschild= "1", FahrzeugTyp= "PKW"},
                new Fahrzeugen{ Nummerschild= "2", FahrzeugTyp= "LKW"},
                new Fahrzeugen{ Nummerschild= "3", FahrzeugTyp= "SUV"}
            };

            Motorraders = new List<Fahrzeugen>()
            {
                new Fahrzeugen { Nummerschild = "4", FahrzeugTyp = "Enduro"},
                new Fahrzeugen { Nummerschild = "5", FahrzeugTyp = "Cruiser"}
            };
        }

        public string FahrzeugEinfugen(Fahrzeugen neueFahrzeugen)
        {
            Random rnd = new Random();
            try
            {
                int spot = rnd.Next(1,Erdgeschoss.ParkPlatze);
                neueFahrzeugen.ParkSpot = spot;
                Autos.Add(neueFahrzeugen);
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
            Erdgeschoss.ParkPlatze = parkplätze;

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
