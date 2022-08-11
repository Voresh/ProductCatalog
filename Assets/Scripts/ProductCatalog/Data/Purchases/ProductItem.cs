namespace ProductCatalog.Data.Purchases {
    public class ProductItem {
        public readonly string Id;
        public readonly int Count;

        public ProductItem(string id, int count) {
            Id = id;
            Count = count;
        }
    }
}
