using System.Collections.Generic;

namespace ProductCatalog.Data.Items {
    public class ItemsStorage {
        private readonly List<Item> _Items;

        public IReadOnlyList<Item> Items => _Items;

        public ItemsStorage(List<Item> items) {
            _Items = items;
        }
    }
}
