# ProductCatalog API

ProductCatalogService.GetPurchases() - returns enumerable catalogue of purchases.
You can apply sorting and filtering to this catalogue using this methods:
- Purchases.AddFilterItem(item id) (Adds item id to list of shown items)
- Purchases.AddItemsFiltering() (Applies items filtering)
- Purchases.AddCustomFiltering(Func (Purchase, bool)) (Applies custom filtering with predicate)
- Purchases.SetItemOrder(item id, order) (Adds items sorting order)
- Purchases.SetSortingByItems(descending?) (Applies sorting by items in descending or ascending order)
- Purchases.SetSortingByName(descending?) (Applies sorting by name in descending or ascending order)
- Purchases.SetSortingByPrice(descending?) (Applies sorting by price in descending or ascending order)
- Purchases.SetCustomSorting(Func (Purchase, Key), descending?) (Applies custom sorting with key selector function in descending or ascending order)
After sorting and filtering you can enumerate Purchases using foreach in example.

# Task Overview

We need to come up with a new product catalog API that will be shared among many game projects. This new system is going to be used on a daily basis by other developers so it is expected to be extensible, flexible and maintainable.


# Requirements 

The product catalog should contain both products and bundles:
- 3 different items for now: Coins, Gems and Tickets.
- Product: has one item and its amount, name, short description, and price in USD.
- Bundle: has a name, short description and price in USD. It contains up to three different items and their respective amounts.
- The catalog will read a JSON file as the data source. This JSON file should be created and structured by you.

The product catalog must have runtime sorting and filtering mechanisms, such as:
- Sort by ascending or descending (e.g. price, name).
- Sort everything by item, in any order (e.g. Coins > Gems > Tickets or Tickets > Coins > Gems etc).
- Filtering products and bundles by item (e.g. only show products and bundles with Coins and/or Tickets).
- The catalog API should facilitate custom sorting and filtering for the products and bundles. Different game teams will have different needs.

A “demo” script & scene should be provided. This should demonstrate:
- How someone would integrate your catalog. 
- API usage.
- Custom sorting & filtering.

Other requirements:
- The catalog must be functional at runtime.
- Provide a short document describing how to use the API.


# Additional information 

- Take as much time as you need to complete the test, but ideally, it should be finished and returned to us within 10 days.
- All code should be written from scratch.
- Placeholder UI elements (texts, images) everywhere are enough.
- Third-party libraries should be avoided, except for JSON handling (e.g. JSON .NET).
- Do not wire up the product catalog to UnityIAP. This is not part of the test.
- Do not implement actual inventory usage (i.e. keeping track of purchased items). This is not part of the test.
- Use C# code and Unity LTS 2020.3.30.


# REVIEW 

We will look at your code architecture, structure and overall project organisation.
