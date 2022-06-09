using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TestZhilfond.Models;

namespace TestZhilfond.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<BalanceItem>> GetBalances()
        {

        }
    }
}
