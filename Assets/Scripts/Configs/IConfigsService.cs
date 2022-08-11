namespace Configs {
    public interface IConfigsService {
        T LoadConfig<T>(string name);
    }
}
