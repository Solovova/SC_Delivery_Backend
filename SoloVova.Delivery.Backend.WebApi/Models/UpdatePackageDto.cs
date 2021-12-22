using System;

namespace SoloVova.Delivery.Backend.WebApi.Models{
    public class UpdatePackageDto{
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Details { get; set; }
    }
}