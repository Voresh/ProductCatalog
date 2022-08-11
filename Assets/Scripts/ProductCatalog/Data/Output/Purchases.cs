using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProductCatalog.Data.Output {
    public class Purchases : IEnumerable<IPurchaseDescriptor> {
        private IEnumerable<IPurchaseDescriptor> _Enumerable;
        private readonly Dictionary<string, int> _ItemsOrder = new Dictionary<string, int>();
        private readonly HashSet<string> _FilteredItems = new HashSet<string>(); //todo: filtering by items!!!

        /*
         * note: all methods returns Purchases because you may want to use it like:
         * 
         * purchases
         *      .AddFilterItem("FirstItem")
         *      .AddFilterItem("SecondItem")
         *      .AddItemsFiltering()
         *      .SetSortingByName()
         *      ... etc
         * 
        */
        public Purchases AddFilterItem(string itemId) {
            _FilteredItems.Add(itemId);
            return this;
        }
        
        public Purchases AddItemsFiltering() {
            return AddCustomFiltering(purchase 
                => purchase.IncludedItems.Any(item => _FilteredItems.Any(itemId => itemId == item.Id)));
        }

        public Purchases AddCustomFiltering(Func<IPurchaseDescriptor, bool> filterPredicate) {
            _Enumerable = _Enumerable.Where(filterPredicate);
            return this;
        }

        public Purchases SetCustomSorting<TKey>(Func<IPurchaseDescriptor, TKey> keySelector, bool descending) {
            _Enumerable = descending
                ? _Enumerable.OrderByDescending(keySelector)
                : _Enumerable.OrderBy(keySelector);
            return this;
        }

        public Purchases SetSortingByName(bool descending) {
            return SetCustomSorting(_ => _.Name, descending);
        }
        
        public Purchases SetSortingByPrice(bool descending) {
            return SetCustomSorting(_ => _.PriceUSD, descending);
        }

        public Purchases SetItemOrder(string itemId, int order) {
            _ItemsOrder.Add(itemId, order);
            return this;
        }

        public Purchases SetSortingByItems(bool descending) {
            return SetCustomSorting(product => product.IncludedItems.Min(_ => _ItemsOrder[_.Id]), descending);
        }

        public IEnumerator<IPurchaseDescriptor> GetEnumerator() {
            return _Enumerable.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public Purchases(IReadOnlyCollection<IPurchaseDescriptor> purchases) {
            _Enumerable = purchases;
        }

        //public ProductsQuery SetCustomAdditionalSorting<TKey>(Func<IPurchaseDescriptor, TKey> keySelector) {
        //    if (!(_Enumerable is IOrderedEnumerable<IPurchaseDescriptor>))
        //        throw new Exception("Main sorting not set!");
        //    _Enumerable = ((IOrderedEnumerable<IPurchaseDescriptor>) _Enumerable).ThenBy(keySelector);
        //    return this;
        //} // note: something like this can be added if needed
    }
}
