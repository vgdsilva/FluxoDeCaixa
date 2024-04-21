namespace FluxoDeCaixa.Mobile.Core.Domain.Entities;

public class GenericEntity
{
    public object? Key { get; set; }
    public string KeyString { get; set; } = string.Empty;
    public long KeyLong { get; set; }
    public object? Value { get; set; }
    public string ValueSring { get; set; } = string.Empty;
    public long ValueLong { get; set; }

    public GenericEntity() { }

    public GenericEntity(object key, object value)
    {
        Key = key;
        Value = value;
    }

}
