using System.Reflection;

namespace AntSK.Domain.Utils
{
    public static class RepoFiles
    {
        /// <summary>
        /// Scan the local folders from the repo, looking for "samples/plugins" folder.
        /// </summary>
        /// <returns>The full path to samples/plugins</returns>
        public static string SamplePluginsPath()
        {
            string parent = AppContext.BaseDirectory;
            string folder = "plugins";

            bool SearchPath(string currDir, out string result, int maxAttempts = 10)
            {
                bool found;
                do
                {
                    result = currDir;
                    found = Directory.Exists(currDir);
                    currDir = Path.GetFullPath(Path.Combine(currDir, ".."));
                } while (maxAttempts-- > 0 && !found);

                return found;
            }

            if (!SearchPath(Path.Combine(parent, folder), out string path))
            {
                throw new YourAppException("Plugins directory not found. The app needs the plugins from the repo to work.");
            }

            return path;
        }
    }

    public class YourAppException : Exception
    {
        public YourAppException() : base()
        {
        }

        public YourAppException(string message) : base(message)
        {
        }

        public YourAppException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
