using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Diagnostics;
using TreeItemData.Library;

namespace TreeItemData.REST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TreeItemDataController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        private readonly ITreeItemDataHandler _treeItemDataHandler;
        private readonly ILogger<TreeItemDataController> _logger;

        public TreeItemDataController(IConfiguration configuration, ILogger<TreeItemDataController> logger)
        {
            Configuration = configuration;
            _treeItemDataHandler = new TreeItemDataHandler();
            _logger = logger;
        }

        [HttpGet]
        [EnableCors("AllowAll")]
        public JToken Get()
        {
            return _treeItemDataHandler.GetTreeItemDataFromPath(Configuration["TreeItemDataDirectory"]);
        }
    }
}
