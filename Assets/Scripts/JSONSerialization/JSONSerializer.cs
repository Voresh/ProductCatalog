using System;
using System.Text;
using Newtonsoft.Json;

public class JSONSerializer : ISerializer {
    private static readonly JsonSerializerSettings _DefaultSettings = new JsonSerializerSettings {
        TypeNameHandling = TypeNameHandling.Auto,
    };

    public T Deserialize<T>(byte[] bytes) {
        if (bytes == null)
            throw new ArgumentNullException($"Trying to deserialize null bytes!");
        var json = Encoding.UTF8.GetString(bytes);
        return JsonConvert.DeserializeObject<T>(json, _DefaultSettings);
    }

    public byte[] Serialize<T>(T data) {
        var json = JsonConvert.SerializeObject(data, _DefaultSettings);
        return Encoding.UTF8.GetBytes(json); //note: alloc can be removed
    }
}
