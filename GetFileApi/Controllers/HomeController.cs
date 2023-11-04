using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GetFileApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("{path}")]
        public IActionResult GetFiles(string path)
        {
            string[] listFolder = Directory.GetDirectories(path);
            listFolder = listFolder.Concat(Directory.GetFiles(path)).ToArray();
            List<string> List = new List<string>();
            foreach (var item in listFolder)
            {
                List.Add(item.Remove(0, item.LastIndexOf('\\') + 1));
            }
            if (List.ToArray().Length > 0)
            {
                return Ok(List);
            }

            return NoContent();
        }
    }
}
