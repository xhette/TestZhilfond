using Newtonsoft.Json;


namespace TestZhilfond.Database.Models
{
    public partial class Payment
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonProperty("account_id")]
        public int? AccountId { get; set; }

        [JsonProperty("date")]
        public DateTime? Date { get; set; }

        [JsonProperty("sum")]
        public double? Summ { get; set; }

        [JsonProperty("payment_guid")]
        public Guid? PaymentGuid { get; set; }
    }
}
