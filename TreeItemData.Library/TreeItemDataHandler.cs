using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;

namespace TreeItemData.Library
{
    public interface ITreeItemDataHandler
    {
        JToken GetTreeItemDataFromPath(string path);
    }

    public class TreeItemDataHandler : ITreeItemDataHandler
    {
        public JToken GetTreeItemDataFromPath(string path)
        {
            var rootDirectory = new DirectoryInfo(path);

            return GetDirectory(rootDirectory); ;
        }

        JToken GetDirectory(DirectoryInfo directory)
        {
            return JToken.FromObject
            (
                new
                {
                    directories = directory.EnumerateDirectories().ToDictionary(x => x.Name, x => GetDirectory(x)),
                    files = directory.EnumerateFiles().Select(x => x.Name).ToList()
                }
            );
        }
    }
}
