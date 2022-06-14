using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using TestZhilfond.Database;
using TestZhilfond.Database.Models;

namespace TestZhilfond.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        [HttpPost]
        public void Post(string jsonData)
        {
            var payments = JsonConvert.DeserializeObject<List<Payment>>(jsonData);

            using (ZhilfondDbContext context = new ZhilfondDbContext())
            {
                foreach (var payment in payments)
                {
                    context.Payments.Add(payment);
                    context.SaveChanges();
                }
            }
        }
    }
}

