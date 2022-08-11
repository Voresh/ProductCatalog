namespace ProductCatalog.Data.Purchases {
    public class Product {
        public readonly string Id;
        public readonly string Name;
        public readonly string ShortDescription;
        public readonly decimal PriceUSD;
        public readonly ProductItem IncludedItem;

        public Product(string id,
            string name, 
            string shortDescription,
            decimal priceUsd, 
            ProductItem includedItem) {
            Id = id;
            Name = name;
            ShortDescription = shortDescription;
            PriceUSD = priceUsd;
            IncludedItem = includedItem;
        }
    }
}