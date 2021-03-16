using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LeaguerManagement.APIs.Configurations
{
    public sealed class CamelCaseJsonSerializer : JsonSerializer
    {
        public CamelCaseJsonSerializer()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver();
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            DateTimeZoneHandling = DateTimeZoneHandling.Local;
        }
    }
}
