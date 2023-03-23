namespace FrisExtras.Misc;

/// <summary>
/// Collection of miscellaneous methods that don't fit anywhere else.
/// </summary>
public static class Misc
{
    private static readonly char[] IllegalChar = "<>:\"\'/\\|?*#%&{}$!@+`=".ToCharArray();
    
    /// <summary>
    /// Checks if a number is even.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns><c>True</c> if <paramref name="number"/> is even. 
    /// <c>False</c> if <paramref name="number"/> is uneven.</returns>
    public static bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    /// <summary>
    /// Checks if a string contains illegal filename characters.
    /// </summary>
    /// <param name="str">The string to check</param>
    /// <returns><c>True</c> if <paramref name="str"/> contains at least one illegal character.
    /// Otherwise returns <c>False</c>.</returns>
    public static bool IllegalCharCheck(string str)
    {
        if (str.StartsWith(".") || str.EndsWith("."))
            return true;
        if (WhitespaceCheck(str))
            return true;
        return str.IndexOfAny(IllegalChar) >= 0;
    }
    
    /// <summary>
    /// Checks if any of the strings in a list contain illegal filename characters.
    /// </summary>
    /// <param name="strList">The list of strings to check</param>
    /// <returns><c>True</c> if any of the strings in <paramref name="strList"/> contains at least on illegal character.
    /// Otherwise returns <c>False</c>.</returns>
    public static bool IllegalCharCheck(IEnumerable<string> strList)
    {
        foreach (var str in strList)
        {
            if (str.StartsWith(".") || str.EndsWith("."))
                return true;
            if (str.IndexOfAny(IllegalChar) >= 0)
                return true;
            if (WhitespaceCheck(str))
                return true;
        }
        return false;
    }

    /// <summary>
    /// Checks if a string is empty, null or only contains whitespaces.
    /// </summary>
    /// <param name="str">The string to check.</param>
    /// <returns><c>True</c> if the string is empty, null or only contains whitespaces.
    /// Otherwise returns <c>False></c>.</returns>
    public static bool WhitespaceCheck(string str)
    {
        return string.IsNullOrWhiteSpace(str);
    }
    
    /// <summary>
    /// Checks if any of the strings in a list are empty, null or contain only whitespaces.
    /// </summary>
    /// <param name="strList">The list of strings to check.</param>
    /// <returns><c>True</c> if any of the strings are empty, null or contain only whitespaces.
    /// Otherwise returns <c>False</c>.</returns>
    public static bool WhitespaceCheck(IEnumerable<string> strList)
    {
        return strList.Any(string.IsNullOrWhiteSpace);
    }
}