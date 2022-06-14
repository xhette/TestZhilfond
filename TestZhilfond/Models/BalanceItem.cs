namespace TestZhilfond.Models
{
    public class BalanceItem
    {
        public string PeriodName { get; set; }
        public double? InBalanceStart { get; set; }
        public double? InBalanceEnd { get; set; }
        public double? Calculation { get; set; }
        public double? Payment { get; set; }
    }
}
