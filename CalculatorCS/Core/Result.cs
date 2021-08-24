using System.Text.Json.Serialization;

namespace CalculatorCS.Core
{
    public class Result
    {
        [JsonPropertyName("operation")]
        public string Operation { get; set; }
        
        [JsonPropertyName("result")]
        public string ResultValue { get; set; }
        
        [JsonPropertyName("expression")]
        public string Expression { get; set; }
        
        public bool IsError { get; set; } = false;
    }
}