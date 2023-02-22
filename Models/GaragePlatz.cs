namespace DieGarage.Models
{
    public class GaragePlatz
    {
        public int ID { get; set; }
        public int[] ParkPlatze { get; set; }
        public bool istBesetzt { get; set; }
    }
}
