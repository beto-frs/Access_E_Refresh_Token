using System.Text.Json.Serialization;

namespace ApiAuth.Models
{
    public class InputRefreshModel
    {
        public string token { get; set; }
        public string refreshToken { get; set; }

        [JsonIgnore]
        public string? create { get; set; }

        [JsonIgnore]
        public string? validate {get; set;}
    }
}
