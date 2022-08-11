using ProductCatalog.Services;
using UnityEngine;

namespace Demo {
    public class ProjectContext {
        [RuntimeInitializeOnLoadMethod]
        private static void Initialize() {
            var serializer = new JSONSerializer();
            var configsService = new ResourcesConfigsService(serializer, "Configs/");
            var productCatalogService = new ProductCatalogService(configsService);
            var shopControllerResource = Resources.Load<ShopController>("Prefabs/ShopCanvas");
            var shopController = Object.Instantiate(shopControllerResource);
            shopController.Initialize(productCatalogService);
        }
    }
}
