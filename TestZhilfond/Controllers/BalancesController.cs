using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using System.Globalization;

using TestZhilfond.Database;
using TestZhilfond.Database.Models;
using TestZhilfond.Models;

namespace TestZhilfond.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalancesController : ControllerBase
    {
        [HttpPost]
        public void Post(string jsonData)
        {
            var balances = JsonConvert.DeserializeObject<List<BalanceAPIModel>>(jsonData);

            var dbBalances = balances.Select(b => new Balance
            {
                InBalance = b.InBalance,
                AccountId = b.AccountId,
                Calculation = b.Calculation,
                Period = DateTime.ParseExact(b.Period, "yyyyMM", CultureInfo.InvariantCulture)
            }).ToList();  

            using (ZhilfondDbContext context = new ZhilfondDbContext())
            {
                foreach (var balance in dbBalances)
                {
                    context.Balances.Add(balance);
                    context.SaveChanges();
                }
            }
        }
    }
}
