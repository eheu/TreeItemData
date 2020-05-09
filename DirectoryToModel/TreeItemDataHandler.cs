using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DirectoryToModel
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
            return JToken.FromObject(new
            {
                directory = directory.EnumerateDirectories()
                    .ToDictionary(x => x.Name, x => GetDirectory(x)),
                file = directory.EnumerateFiles().Select(x => x.Name).ToList()
            });
        }
    }
}
