namespace Domain;

public static class EntidadesUtils
{
    public static bool IsPrimitiveOrEnum(Type _Type)
    {
        if ( _Type.IsPrimitive || _Type.IsEnum || _Type.IsValueType )
            return true;

        if ( _Type == typeof(string) )
            return true;

        bool _Nullable = Nullable.GetUnderlyingType(_Type) != null;
        if ( _Nullable && _Type.GetGenericArguments().Any(t => t.IsPrimitive || t.IsEnum || t.IsValueType) )
            return true;

        return false;
    }
}
