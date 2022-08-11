using System.Collections.Generic;
using ProductCatalog.Data.Purchases;

namespace ProductCatalog.Data {
    public class Catalog {
        private readonly List<Bundle> _Bundles;
        private readonly List<Product> _Products;

        public IReadOnlyList<Bundle> Bundles => _Bundles;
        public IReadOnlyList<Product> Products => _Products;

        public Catalog(List<Bundle> bundles, List<Product> products) {
            _Bundles = bundles;
            _Products = products;
        }
    }
}
