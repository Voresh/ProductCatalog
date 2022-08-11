using System;
using System.Collections.Generic;
using ProductCatalog.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Demo {
    public class ShopController : MonoBehaviour {
        [SerializeField]
        private Transform _PurchasesRoot;
        [SerializeField]
        private Dropdown _SortingDropdown; //note: should be filled by code
        [SerializeField]
        private Toggle _CoinsToggle;
        [SerializeField]
        private Toggle _TicketsToggle;
        [SerializeField]
        private Toggle _GemsToggle;
        [SerializeField]
        private Toggle _FreeToggle;
        
        private ProductCatalogService _ProductCatalogService;
        private readonly List<GameObject> _PurchasesWidgets = new List<GameObject>();

        public void Initialize(ProductCatalogService service) {
            _ProductCatalogService = service;
            _SortingDropdown.onValueChanged.AddListener(value => {
                RefreshPurchases();
            });
            _CoinsToggle.onValueChanged.AddListener(value => {
                RefreshPurchases();
            });
            _TicketsToggle.onValueChanged.AddListener(value => {
                RefreshPurchases();
            });
            _GemsToggle.onValueChanged.AddListener(value => {
                RefreshPurchases();
            });
            _FreeToggle.onValueChanged.AddListener(value => {
                RefreshPurchases();
            });
            RefreshPurchases();
        }

        private void RefreshPurchases() { //note: very straightforward sample
            var purchases = _ProductCatalogService.GetPurchases();
            purchases.SetItemOrder("GemUniqueId", 1);
            purchases.SetItemOrder("TicketUniqueId", 2);
            purchases.SetItemOrder("CoinUniqueId", 3);
            var sortingType = (SortingType) _SortingDropdown.value;
            switch (sortingType) {
                case SortingType.NameAscending:
                    purchases.SetSortingByName(false);
                    break;
                case SortingType.NameDescending:
                    purchases.SetSortingByName(true);
                    break;
                case SortingType.PriceAscending:
                    purchases.SetSortingByPrice(false);
                    break;
                case SortingType.PriceDescending:
                    purchases.SetSortingByPrice(true);
                    break;
                case SortingType.ItemsCountAscending:
                    purchases.SetCustomSorting(_ => _.IncludedItems.Count, false); //note: custom sorting
                    break;
                case SortingType.ItemsCountDescending:
                    purchases.SetCustomSorting(_ => _.IncludedItems.Count, true); //note: custom sorting
                    break;
                case SortingType.ItemTypeAscending:
                    purchases.SetSortingByItems(false);
                    break;
                case SortingType.ItemTypeDescending:
                    purchases.SetSortingByItems(true);
                    break;
                default: throw new ArgumentOutOfRangeException();
            }
            if (_CoinsToggle.isOn)
                purchases.AddFilterItem("CoinUniqueId");
            if (_GemsToggle.isOn)
                purchases.AddFilterItem("GemUniqueId");
            if (_TicketsToggle.isOn)
                purchases.AddFilterItem("TicketUniqueId");
            purchases.AddItemsFiltering();
            if (_FreeToggle.isOn)
                 purchases.AddCustomFiltering(_ => _.PriceUSD == 0); //note: custom filtering
            foreach (var purchaseWidget in _PurchasesWidgets)
                Destroy(purchaseWidget);
            _PurchasesWidgets.Clear();
            foreach (var purchase in purchases) {
                var resource = Resources.Load<GameObject>($"Prefabs/{purchase.Id}"); //note: temp way to load widgets
                var instance = Instantiate(resource, _PurchasesRoot);
                // note: load and setup widget here from purchase data
                _PurchasesWidgets.Add(instance);
            }
        }
    }
}
