using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryToModel
{
    class TreeItemData
    {
        public string nodeId;
        public string label;
        public List<TreeItemData> children;

        public TreeItemData(string nodeId, string label, List<TreeItemData> children)
        {
            this.nodeId = nodeId;
            this.label = label;
            this.children = children;
        }
    }
}
