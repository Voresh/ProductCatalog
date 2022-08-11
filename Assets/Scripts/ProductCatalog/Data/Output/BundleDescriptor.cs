using System.Collections.Generic;

namespace ProductCatalog.Data.Output {
    public class BundleDescriptor : IPurchaseDescriptor {
        public readonly string Id;
        public readonly string Name;
        public readonly string ShortDescription;
        public readonly decimal PriceUSD;
        public readonly IReadOnlyList<ItemDescriptor> IncludedItems;

        string IPurchaseDescriptor.Id => Id;
        string IPurchaseDescriptor.Name => Name;
        string IPurchaseDescriptor.ShortDescription => ShortDescription;
        decimal IPurchaseDescriptor.PriceUSD => PriceUSD;
        IReadOnlyList<ItemDescriptor> IPurchaseDescriptor.IncludedItems => IncludedItems;

        public BundleDescriptor(
            string id, 
            string name, 
            string shortDescription, 
            decimal priceUSD, 
            IReadOnlyList<ItemDescriptor> includedItems) {
            Id = id;
            Name = name;
            ShortDescription = shortDescription;
            PriceUSD = priceUSD;
            IncludedItems = includedItems;
        }
    }
}
