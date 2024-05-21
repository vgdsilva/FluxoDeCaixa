namespace FluxoDeCaixa;

public static class ObjectExtencions
{

    public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);

    public static bool IsNewEntity(this string str)
    {
        if (str.IsNullOrEmpty())
            return false;

        if (!str.Equals("00000000-0000-0000-0000-080000000000"))
            return false;

        return true;
    }
}
