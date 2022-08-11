using System.Collections.Generic;

namespace ProductCatalog.Data.Output {
    public class ProductDescriptor : IPurchaseDescriptor {
        public readonly string Id;
        public readonly string Name;
        public readonly string ShortDescription;
        public readonly decimal PriceUSD;
        public readonly ItemDescriptor IncludedItem;
        
        private List<ItemDescriptor> _IncludedItems;

        string IPurchaseDescriptor.Id => Id;
        string IPurchaseDescriptor.Name => Name;
        string IPurchaseDescriptor.ShortDescription => ShortDescription;
        decimal IPurchaseDescriptor.PriceUSD => PriceUSD;
        IReadOnlyList<ItemDescriptor> IPurchaseDescriptor.IncludedItems 
            => _IncludedItems ??= new List<ItemDescriptor> { IncludedItem };

        public ProductDescriptor(
            string id,
            string name, 
            string shortDescription, 
            decimal priceUSD, 
            ItemDescriptor includedItem) {
            Id = id;
            Name = name;
            ShortDescription = shortDescription;
            PriceUSD = priceUSD;
            IncludedItem = includedItem;
        }
    }
}
