namespace DieGarage.Models
{
    public class Garage
    {
        public int ParkPlatze { get; set; }
        public int Etagen { get; set; }

        public Garage(int parkPlatze, int etagen)
        {
            ParkPlatze = parkPlatze;
            Etagen = etagen;
        }
    }
}
