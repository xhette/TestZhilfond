using System;
using System.Collections.Generic;

namespace TestZhilfond.Database.Models
{
    public partial class Balance
    {
        public int Id { get; set; }
        public double? InBalance { get; set; }
        public double? Calculation { get; set; }
        public int? AccountId { get; set; }
        public DateTime? Period { get; set; }
    }
}
