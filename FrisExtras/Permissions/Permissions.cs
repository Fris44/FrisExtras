using System.Runtime.InteropServices;
using System.Security.Principal;

namespace FrisExtras.Permissions;

/// <summary>
/// Class containing methods to check if the program has certain permissions.
/// </summary>
public class Permissions
{
    /// <summary>
    /// Checks if the program has permission to write in the given directory.
    /// </summary>
    /// <param name="dirPath">Directory to check.</param>
    /// <param name="throwIfFails">If the method should throw the error. Defaults to false.</param>
    /// <returns><c>True</c> if the directory is writeable. <c>False</c> if not.</returns>
    public static bool IsDirectoryWritable(string dirPath, bool throwIfFails = false)
    {
        try
        {
            using var fs = File.Create(
                Path.Combine(
                    dirPath,
                    Path.GetRandomFileName()
                ),
                1,
                FileOptions.DeleteOnClose);

            return true;
        }
        catch (UnauthorizedAccessException)
        {
            if (throwIfFails)
                throw;
            return false;
        }
    }

    
    
    [DllImport("libc")]
    private static extern uint getuid();

    /// <summary>
    /// Checks if the program is run with elevated privileges.
    /// Taken from https://stackoverflow.com/a/49373723
    /// </summary>
    /// <returns><c>True</c> if run with elevated privileges. Otherwise <c>False</c>.</returns>
    public static bool IsRoot()
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return getuid() == 0;
        using var identity = WindowsIdentity.GetCurrent();
        var principal = new WindowsPrincipal(identity);
        var isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
        return isAdmin;
    }
}