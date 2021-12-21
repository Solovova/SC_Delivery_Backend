using System;
using System.Collections.Generic;

namespace SoloVova.Delivery.Backend.Domain{
    public class Address{
        public Guid Id{ get; set; }
        public string Name{ get; set; }
        public decimal X{ get; set; }
        public decimal Y{ get; set; }
        
        public ICollection<Package> packages { get; set; }
    }
}