using Microsoft.EntityFrameworkCore;

using TestZhilfond.Database.Extentions.Classes;
using TestZhilfond.Database.Models;

namespace TestZhilfond.Database.Extentions
{
    public class DbRepository
    {
        private readonly ZhilfondDbContext _dbContext;

        public DbRepository()
        {
            _dbContext = new ZhilfondDbContext();
        }

        public async Task<DbResult<IEnumerable<Balance>>> GetBalances(int accountId)
        {
            DbResult<IEnumerable<Balance>> result;

            try
            {
                var balances = await _dbContext.Balances.Where(c => c.AccountId == accountId).ToListAsync();

                result = new DbResult<IEnumerable<Balance>>
                {
                    ResultCode = DbResultCode.OK,
                    Result = balances,
                    ErrorMessage = ""
                };
            }
            catch (Exception ex)
            {
                result = new DbResult<IEnumerable<Balance>>
                {
                    ResultCode = DbResultCode.Error,
                    ErrorMessage = ex.Message,
                    Result = null
                };
            }

            return result;
        }

        public async Task<DbResult<IEnumerable<Payment>>> GetPayments(int accountId)
        {
            DbResult<IEnumerable<Payment>> result;

            try
            {
                var payments = await _dbContext.Payments.Where(c => c.AccountId == accountId).ToListAsync();

                result = new DbResult<IEnumerable<Payment>>
                {
                    ResultCode = DbResultCode.OK,
                    Result = payments,
                    ErrorMessage = ""
                };
            }
            catch (Exception ex)
            {
                result = new DbResult<IEnumerable<Payment>>
                {
                    ResultCode = DbResultCode.Error,
                    ErrorMessage = ex.Message,
                    Result = null
                };
            }

            return result;
        }
    }
}
