using Newtonsoft.Json;
namespace XamarinDemo.Models
{
    public class Client
    {
        [JsonProperty(PropertyName = "web")]
        public Web Web { get; set; }

        [JsonProperty(PropertyName = "android")]
        public Android Android { get; set; }

        [JsonProperty(PropertyName = "ios")]
        public Ios Ios { get; set; }
    }
}
