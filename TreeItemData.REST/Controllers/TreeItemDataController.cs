using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using TreeItemData.Library;

namespace TreeItemData.REST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TreeItemDataController : ControllerBase
    {
        private const string path = @"C:\Users\Emil\Desktop\test";
        private readonly ITreeItemDataHandler _treeItemDataHandler;
        private readonly ILogger<TreeItemDataController> _logger;
        public TreeItemDataController(ILogger<TreeItemDataController> logger)
        {
            _treeItemDataHandler = new TreeItemDataHandler();
            _logger = logger;
        }

        [HttpGet]
        [EnableCors("AllowAll")]
        public JToken Get()
        {
            return _treeItemDataHandler.GetTreeItemDataFromPath(path);
        }
    }
}
