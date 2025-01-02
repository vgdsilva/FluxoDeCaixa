namespace FluxoDeCaixa.MAUI.Utils.Classes;

public class Parameters
{
    static Parameters _instance;
    readonly Dictionary<string, object> _parameters;

    public Parameters()
    {
        _parameters = new Dictionary<string, object>();
    }

    public static Parameters Instance
    {
        get
        {
            _instance ??= new Parameters();
            return _instance;
        }
    }

    public void AddParameter(string key, object value)
    {
        _parameters[key] = value;
    }

    public object GetParameter(string key)
    {
        if (_parameters.TryGetValue(key, out object value))
        {
            _parameters.Remove(key);
            return value;
        }

        return null;
    }

    public TValue GetParameter<TValue>(string key)
    {
        if (_parameters.TryGetValue(key, out TValue value))
        {
            _parameters.Remove(key);
            return value;
        }
        return default;
    }

    public bool TryGetParameter(string key, out object value)
    {
        if (_parameters.TryGetValue(key, out value))
        {
            _parameters.Remove(key);
            return true;
        }
        return false;
    }

    public bool TryGetParameter<TValue>(string key, out TValue value)
    {
        if (_parameters.TryGetValue(key, out value))
        {
            _parameters.Remove(key);
            return true;
        }
        return false;
    }

    public void RemoveParameter(string key)
    {
        if (_parameters.TryGetValue(key, out var value))
            _parameters.Remove(key);
    }


}

public static class DCParametersExtensions
{
    public static bool TryGetValue<T>(this Dictionary<string, object> parameters, string key, out T value)
    {
        foreach (var parameter in parameters)
        {
            if (string.Compare(parameter.Key, key, StringComparison.Ordinal) == 0)
            {
                var success = TryGetValueInternal(parameter, typeof(T), out object valueAsObject);
                value = (T)valueAsObject;
                return success;
            }
        }

        value = default;
        return false;
    }

    private static bool TryGetValueInternal(KeyValuePair<string, object> parameters, Type type, out object value)
    {
        value = GetDefault(type);
        var success = false;
        if (parameters.Value == null)
        {
            success = true;
        }
        else if (parameters.Value.GetType() == type)
        {
            success = true;
            value = parameters.Value;
        }
        else if (type.IsAssignableFrom(parameters.Value.GetType()))
        {
            success = true;
            value = parameters.Value;
        }
        else if (type.IsEnum)
        {
            var valueAsString = parameters.Value.ToString();
            if (Enum.IsDefined(type, valueAsString))
            {
                success = true;
                value = Enum.Parse(type, valueAsString);
            }
            else if (int.TryParse(valueAsString, out var numericValue))
            {
                success = true;
                value = Enum.ToObject(type, numericValue);
            }
        }

        if (!success && type.GetInterface("System.IConvertible") != null)
        {
            success = true;
            value = Convert.ChangeType(parameters.Value, type);
        }

        return success;
    }

    private static object GetDefault(Type type)
    {
        if (type.IsValueType)
        {
            return Activator.CreateInstance(type);
        }
        return null;
    }
}
