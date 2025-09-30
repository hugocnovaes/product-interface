namespace pilotTC.Products
{
    public class Product
    {
        public long Id { get; init; }
        public string Name { get; private set; }
        public double Price { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public string ImageUrl { get; private set; }

        public Product(string name) 
        {
            Id = new long();
            Name = name;
            Price = 0.0;
            Description = string.Empty;
            Category = string.Empty;
            ImageUrl = string.Empty;
        }

        public void UpdateProduct(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
