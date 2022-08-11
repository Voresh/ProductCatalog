public interface ISerializer {
    public T Deserialize<T>(byte[] bytes);
    public byte[] Serialize<T>(T data);
}
