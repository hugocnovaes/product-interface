using System;

namespace medTC.Domain.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime LastUpdatedOn { get; set; }
    }
}
