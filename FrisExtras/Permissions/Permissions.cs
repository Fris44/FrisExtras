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
}