namespace FluxoDeCaixa;

public class ResoucesExtensions
{
    public static object GetResourceValue(string key)
    {
        Application.Current!.Resources.TryGetValue(key, out var result);
        return result;
    }
}
