using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DieGarage.Models
{
    public class Fahrzeugen
    {
        public string? Nummernschild { get; set; }
        public string? FahrzeugTyp { get; set; }
        //public Fahrzeugen? FahrzeugTyp { get; set; }

        [DisplayName("Parkplatz")]
        public int ParkSpot { get; set; }

        [DisplayName("Etage")]
        public int ParkEbene { get; set; }

        public Garage? Garage { get; set; }

    }
}
