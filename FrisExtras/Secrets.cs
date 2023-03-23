using System.Net;
using System.Security.Cryptography;

namespace FrisExtras;

/// <summary>
/// Generate cryptographically strong pseudo-random numbers suitable for
/// managing secrets such as account authentication, tokens, and similar.
/// Based off of the Python library.
/// </summary>
public static class Secrets
{
    /// <summary>
    /// Generates a random URL-safe, Base64 encoded string.
    /// </summary>
    /// <param name="strength">Number of bytes to create. Default is 16.</param>
    /// <returns>A random URL-safe Base64 encoded string.</returns>
    public static string GenUrlSafeToken(int strength = 16)
    {
        var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(strength))
            .Replace("=", string.Empty);
        var urlToken = WebUtility.UrlEncode(token);
        return urlToken;
    }
    
    /// <summary>
    /// Generates a Base64 encoded string.
    /// </summary>
    /// <param name="strength">Number of bytes to create. Default is 16.</param>
    /// <returns>A random Base64 encoded string.</returns>
    public static string GenBase64Token(int strength = 16)
    {
        var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(strength))
            .Replace("=", string.Empty);
        return token;
    }

    /// <summary>
    /// Generates a random text string in hexadecimal.
    /// </summary>
    /// <param name="strength">Number of bytes to create. Default is 16.</param>
    /// <returns>A random hexadecimal string.</returns>
    public static string GenHexToken(int strength = 16)
    {
        var token = Convert.ToHexString(RandomNumberGenerator.GetBytes(strength)).ToLower();
        return token;
    }
}