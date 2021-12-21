using System;

namespace SoloVova.Delivery.Backend.Domain{
    public class Package{
        public Guid IdCreateUser{ get; set; }
        public Guid IdDeliveryman{ get; set; }
        public Guid Id{ get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public Address? AddressFrom {get; set;}
    }
}