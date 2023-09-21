using Microsoft.AspNetCore.Mvc;

namespace DemoWebApi.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class CalculatorController : Controller
    {
        // api/Calculator/Add?x=10&y=30
        [HttpGet("/addcalculator")]
        public int Add(int x, int y)
        {
            return x + y;
        }
        [HttpGet("/sum")]
        public int Sum(int x, int y)
        {
            return x + y + 1000;
        }
        // api/calculator/subtract?x=100&y=30
        [HttpPost]
        public int Subtract(int x, int y)
        {
            return x - y;
        }
        // api/calculator/multiply?x=10&y=30
        [HttpPut]
        public int Multiply(int x, int y)
        {
            return x * y;
        }
        // api/calculator/division?x=50&y=10
        [HttpDelete]
        public int Division(int x, int y)
        {
            return x / y;
        }
    }
}
