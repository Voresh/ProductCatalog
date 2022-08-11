namespace ProductCatalog.Data.Output {
    public class ItemDescriptor : IItemDescriptor {
        public readonly string Id;
        public readonly string Name;
        public readonly long Count;

        string IItemDescriptor.Id => Id;
        string IItemDescriptor.Name => Name;
        long IItemDescriptor.Count => Count;

        public ItemDescriptor(string id, string name, long count) {
            Id = id;
            Name = name;
            Count = count;
        }
    }
}
