using System.Collections.Generic;
using Newtonsoft.Json;
namespace XamarinDemo.Models
{
    public class LoginMode
    {
        [JsonProperty(PropertyName = "organizations")]
        public List<Organization> Organizations { get; set; }
    }
}
