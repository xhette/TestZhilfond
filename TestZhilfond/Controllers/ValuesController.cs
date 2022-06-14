using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TestZhilfond.Database;
using TestZhilfond.Database.Extentions;
using TestZhilfond.Database.Models;
using TestZhilfond.Models;
using TestZhilfond.Models.Enums;

namespace TestZhilfond.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DbRepository _dbRepository;

        public ValuesController()
        {
            _dbRepository = new DbRepository();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BalanceItem>>> GetBalances(int accountId, string periodType)
        {
            try
            {
                DateGroupTypeEnum type = DateGroupTypeEnumExtensions.GetEnum(periodType);
                var dbBalancesResult = await _dbRepository.GetBalances(accountId);

                if (dbBalancesResult?.ResultCode == Database.Extentions.Classes.DbResultCode.OK && dbBalancesResult.Result != null)
                {
                    List<IGrouping<int?, Balance>> groupedItems = null;

                    switch (type)
                    {
                        case DateGroupTypeEnum.Quarter: 
                            groupedItems = dbBalancesResult.Result.GroupBy(c => (c.Period?.Month - 1) / 3).ToList();
                            break;
                        case DateGroupTypeEnum.Year:
                            groupedItems = dbBalancesResult.Result.GroupBy(c => c.Period?.Year).ToList();
                            break;
                        case DateGroupTypeEnum.Month:
                            groupedItems = dbBalancesResult.Result.GroupBy(c => c.Period?.Month).ToList();
                            break;
                        default: throw new Exception("Неверно указан период");
                    }

                    if (groupedItems != null)
                    {
                        var dbPaymentsResult = await _dbRepository.GetPayments(accountId);

                        if (dbBalancesResult?.ResultCode == Database.Extentions.Classes.DbResultCode.OK)
                        {
                            List<BalanceItem> items = groupedItems.Select(c => new BalanceItem
                            {
                                Calculation = c.Sum(u => u.Calculation),
                                InBalanceStart = c.First(u => u.Period == c.Min(i => i.Period)).InBalance,
                                InBalanceEnd = c.First(u => u.Period == c.Max(i => i.Period)).InBalance,
                                Payment = dbPaymentsResult.Result.Where(u => u.Date >= c.Min(i => i.Period) && u.Date < c.Max(i => i.Period?.AddMonths(1))).Sum(o => o.Summ),
                                PeriodName = DateGroupTypeEnumExtensions.GetEnumName(type)
                            }).ToList();

                            return Ok(items);
                        }
                    }
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
