using Newtonsoft.Json;

namespace TestZhilfond.Models
{
    public class BalanceAPIModel
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonProperty("in_balance")]
        public double? InBalance { get; set; }

        [JsonProperty("calculation")]
        public double? Calculation { get; set; }

        [JsonProperty("account_id")]
        public int? AccountId { get; set; }

        [JsonProperty("period")]
        public string? Period { get; set; }
    }
}
