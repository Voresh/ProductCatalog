using System;
using System.Collections.Generic;
using System.Linq;
using Configs;
using ProductCatalog.Data;
using ProductCatalog.Data.Items;
using ProductCatalog.Data.Output;
using ProductCatalog.Data.Purchases;

namespace ProductCatalog.Services {
    public class ProductCatalogService {
        private readonly Catalog _Catalog;
        private readonly ItemsStorage _ItemsStorage;
        private readonly List<IPurchaseDescriptor> _Purchases;

        public ProductCatalogService(IConfigsService configsService) {
            _ItemsStorage = configsService.LoadConfig<ItemsStorage>("Items");
            _Catalog = configsService.LoadConfig<Catalog>("Catalog");
            // TODO: validate configs here (required empty fields, unique id's etc)
            var purchases = new List<IPurchaseDescriptor>();
            ItemDescriptor GetItemDescriptor(ProductItem productItem) {
                var itemConfig = _ItemsStorage.Items.FirstOrDefault(_ => _.Id == productItem.Id);
                if (itemConfig == null)
                    throw new Exception($"Item with id {productItem.Id} not found!");
                return new ItemDescriptor(productItem.Id, itemConfig.Name, productItem.Count);
            }
            var bundlesEnumerable = _Catalog.Bundles
                .Select(bundle => new BundleDescriptor(
                    bundle.Id,
                    bundle.Name,
                    bundle.ShortDescription,
                    bundle.PriceUSD,
                    bundle.IncludedItems.Select(GetItemDescriptor).ToList()));
            var productsEnumerable = _Catalog.Products
                .Select(product => new ProductDescriptor(
                    product.Id,
                    product.Name,
                    product.ShortDescription,
                    product.PriceUSD,
                    GetItemDescriptor(product.IncludedItem)));
            purchases.AddRange(bundlesEnumerable);
            purchases.AddRange(productsEnumerable);
            _Purchases = purchases;
        }
        
        public Purchases GetPurchases() {
            return new Purchases(_Purchases); //TODO: it can be made reusable, but needs some tuning
        }
    }
}
