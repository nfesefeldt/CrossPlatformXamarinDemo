using Newtonsoft.Json;

namespace XamarinDemo.Models
{
    public class ResponseObject
    {
        [JsonProperty(PropertyName = "loginModes")]
        public LoginMode LoginModes { get; set; }

        [JsonProperty(PropertyName = "clients")]
        public Client Clients { get; set; }

        [JsonProperty(PropertyName = "isProduction")]
        public bool IsProduction { get; set; }

        [JsonProperty(PropertyName = "apiDomain")]
        public string ApiDomain { get; set; }

        [JsonProperty(PropertyName = "pingOneLogoutUrl")]
        public string PingOneLogoutUrl { get; set; }

        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }

        [JsonIgnore]
        public bool HasClients => this.Clients != null;
    }
}
