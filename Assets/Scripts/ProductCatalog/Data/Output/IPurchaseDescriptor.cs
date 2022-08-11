using System.Collections.Generic;

namespace ProductCatalog.Data.Output {
    public interface IPurchaseDescriptor {
        string Id { get; }
        string Name { get; }
        string ShortDescription { get; }
        decimal PriceUSD { get; }
        IReadOnlyList<ItemDescriptor> IncludedItems { get; }
    }
}
