using System.Collections.Generic;

namespace ProductCatalog.Data.Purchases {
    public class Bundle {
        public readonly string Id;
        public readonly string Name;
        public readonly string ShortDescription;
        public readonly decimal PriceUSD;
        private readonly List<ProductItem> _IncludedItems;
        
        public IReadOnlyList<ProductItem> IncludedItems => _IncludedItems;

        public Bundle(string id,
            string name, 
            string shortDescription,
            decimal priceUsd, 
            List<ProductItem> includedItems) {
            Id = id;
            Name = name;
            ShortDescription = shortDescription;
            PriceUSD = priceUsd;
            _IncludedItems = includedItems;
        }
    }
}
