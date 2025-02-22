using System.ComponentModel.DataAnnotations;

namespace SmallUsedCars_WebApp.Models
{
    public class VehicleViewModel
    {
        public int Id { get; set; }
        [Required] public string Make { get; set; }
        [Required] public string Model { get; set; }
        [Required] public int Year { get; set; }
        public string Status { get; set; } = "Available";
    }
}
