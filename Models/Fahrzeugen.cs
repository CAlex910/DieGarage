using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DieGarage.Models
{
    public class Fahrzeugen
    {
        public string? Nummerschild { get; set; }
        public string? FahrzeugTyp { get; set; }
        //public Fahrzeugen? FahrzeugTyp { get; set; }

        [ScaffoldColumn(false)]
        public int ParkSpot { get; set; }
        [ScaffoldColumn(false)]

        public Garage? Garage { get; set; }

    }
}
