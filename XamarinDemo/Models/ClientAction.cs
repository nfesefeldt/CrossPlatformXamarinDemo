using System;
using Newtonsoft.Json;
namespace XamarinDemo.Models
{
    public class ClientAction
    {
        [JsonProperty(PropertyName = "purgeLocal")]
        public DateTime PurgeLocal { get; set; }
    }
}
