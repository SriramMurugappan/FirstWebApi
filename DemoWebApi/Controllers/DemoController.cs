using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        // api/Calculator/Add?x=10&y=30
        [HttpGet("/demoadd")]
        public int DemoAdd(int x, int y)
        {
            return x + y + 5000;
        }
        
    }
}
