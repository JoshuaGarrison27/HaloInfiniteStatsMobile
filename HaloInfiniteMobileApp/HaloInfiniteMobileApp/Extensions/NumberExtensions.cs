namespace HaloInfiniteMobileApp.Extensions;
public static class NumberExtensions
{
    public static bool IsNullOrValue(this int? value, int valueToCheck)
    {
        return (value ?? valueToCheck) == valueToCheck;
    }
}
