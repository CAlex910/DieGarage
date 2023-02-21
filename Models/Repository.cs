namespace DieGarage.Models
{
    public class Repository
    {
        public List<Fahrzeugen> Autos { get; set; }
        public List<Fahrzeugen> Motorraders { get; set; }

        public Garage Garage { get; set; }

        public Repository()
        {
            Autos = new List<Fahrzeugen>()
            {
                new Fahrzeugen{ ID= 1, FahrzeugTyp= "PKW"},
                new Fahrzeugen{ ID= 2, FahrzeugTyp= "LKW"},
                new Fahrzeugen{ ID= 3, FahrzeugTyp= "SUV"}

            };

            Motorraders = new List<Fahrzeugen>()
            {
                new Fahrzeugen { ID = 4, FahrzeugTyp = "Enduro"},
                new Fahrzeugen { ID = 5, FahrzeugTyp = "Cruiser"}
            };
        }

        public string FahrzeugEinfugen(Fahrzeugen neueFahrzeugen)
        {
            try
            {

                Autos.Add(neueFahrzeugen);
                return "test";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
