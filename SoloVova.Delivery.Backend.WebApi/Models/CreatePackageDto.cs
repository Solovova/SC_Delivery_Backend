
using System.ComponentModel.DataAnnotations;

namespace SoloVova.Delivery.Backend.WebApi.Models{
    public class CreatePackageDto{
        [Required]
        public string? Title{ get; set; }
        public string? Details{ get; set; }
    }
}