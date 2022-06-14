namespace TestZhilfond.Database.Extentions.Classes
{
    public class BalancePayment
    {
        public int BalanceId { get; set; }
        public double? InBalance { get; set; }
        public double? Calculation { get; set; }
        public int? AccountId { get; set; }
        public DateTime? Period { get; set; }
        public int PaymentId { get; set; }
        public DateTime? Date { get; set; }
        public double? Summ { get; set; }
        public Guid? PaymentGuid { get; set; }
    }
}
