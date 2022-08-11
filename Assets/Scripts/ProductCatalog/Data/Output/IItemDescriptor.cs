namespace ProductCatalog.Data.Output {
    public interface IItemDescriptor {
        string Id { get; }
        string Name { get; }
        long Count { get; }
    }
}
