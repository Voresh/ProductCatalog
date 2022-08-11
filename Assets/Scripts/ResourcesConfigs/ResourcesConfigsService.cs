using System;
using Configs;
using UnityEngine;

public class ResourcesConfigsService : IConfigsService {
    private readonly ISerializer _Serializer;
    private readonly string _ResourcesConfigsPath;

    public ResourcesConfigsService(ISerializer serializer, string resourcesConfigsPath) {
        _Serializer = serializer;
        _ResourcesConfigsPath = resourcesConfigsPath;
    }

    public T LoadConfig<T>(string name) {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException($"Config name is null!");
        var textAsset = Resources.Load<TextAsset>($"{_ResourcesConfigsPath}{name}");
        if (textAsset == null)
            throw new Exception($"Config with name {name} not exists!");
        return _Serializer.Deserialize<T>(textAsset.bytes);
    }
}
