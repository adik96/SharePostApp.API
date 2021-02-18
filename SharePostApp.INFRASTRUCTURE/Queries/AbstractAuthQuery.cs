using System.Text.Json.Serialization;

namespace SharePostApp.INFRASTRUCTURE.Queries
{
    public class AbstractAuthQuery
    {
        [JsonIgnore]
        public long UserId { get; set; }
    }
}
