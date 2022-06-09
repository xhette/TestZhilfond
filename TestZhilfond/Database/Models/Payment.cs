using System;
using System.Collections.Generic;

namespace TestZhilfond.Database.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int? AccountId { get; set; }
        public DateTime? Date { get; set; }
        public double? Summ { get; set; }
        public Guid? PaymentGuid { get; set; }
    }
}
